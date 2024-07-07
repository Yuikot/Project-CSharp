using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

internal class SecurityService
{
    //
    //zmieniłam ścieżkę z sys32 na swoją testową
    //
    private string directoryToMonitor = @"C:\Users\ijhkfxsd\Desktop\test";
    private string serverUrl = "http://localhost:8080/security";

    public async Task MonitorAndSendDataAsync()
    {
        List<object> filesData = new List<object>();

        try
        {
            foreach (string filePath in Directory.GetFiles(directoryToMonitor, "*", SearchOption.AllDirectories))
            {
                string checksum = CalculateChecksum(filePath);
                var fileData = new
                {
                    FilePath = filePath,
                    Checksum = checksum
                };
                filesData.Add(fileData);
            }

            string jsonData = JsonConvert.SerializeObject(filesData);

            byte[] encryptionKey = new byte[32]; 
            new Random().NextBytes(encryptionKey);

            var (iv, ciphertext, tag) = EncryptData(jsonData, encryptionKey);

            var encryptedDataToSend = new
            {
                IV = Convert.ToBase64String(iv),
                Ciphertext = Convert.ToBase64String(ciphertext),
                Tag = Convert.ToBase64String(tag)
            };

            await SendDataToServerAsync(encryptedDataToSend);

            Console.WriteLine($"Data successfully sent to server: {serverUrl}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while monitoring and sending data: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    private string CalculateChecksum(string filePath)
    {
        using (var sha256 = SHA256.Create())
        {
            using (var stream = File.OpenRead(filePath))
            {
                byte[] hash = sha256.ComputeHash(stream);
                return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
            }
        }
    }

    private (byte[], byte[], byte[]) EncryptData(string data, byte[] key)
    {
        using (var aes = Aes.Create())
        {
            aes.Key = key;
            aes.GenerateIV();

            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        byte[] plaintextBytes = Encoding.UTF8.GetBytes(data);
                        cs.Write(plaintextBytes, 0, plaintextBytes.Length);
                        cs.FlushFinalBlock();

                        byte[] ciphertext = ms.ToArray();
                        byte[] iv = aes.IV;
                        byte[] tag = aes.IV;

                        return (iv, ciphertext, tag);
                    }
                }
            }
        }
    }

    private async Task SendDataToServerAsync(object data)
    {
        try
        {
            string jsonData = JsonConvert.SerializeObject(data);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(serverUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine($"Data successfully sent to server: {serverUrl}");
                }
                else
                {
                    Console.WriteLine($"Error sending data to server. Response code: {response.StatusCode}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while communicating with the server: {ex.Message}");
        }
    }
}
