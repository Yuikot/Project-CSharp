using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace csharp_project_4._3___serwer
{
    internal class SecurityServer
    {
        private Dictionary<string, string> savedChecksums = new Dictionary<string, string>();

        public void HandleClientRequest(HttpListenerContext context)
        {
            try
            {
                var request = context.Request;
                var body = new StreamReader(request.InputStream).ReadToEnd();

                Log($"Received encrypted data from client: {body}");

                var requestData = JsonConvert.DeserializeObject<EncryptedData>(body);

                var decryptedData = DecryptData(requestData);

                CheckIntegrity(decryptedData);

                var response = context.Response;
                response.StatusCode = (int)HttpStatusCode.OK;
                response.Close();

                Log($"Processed client request successfully.");
            }
            catch (Exception ex)
            {
                Log($"Error handling request: {ex.Message}");
            }
        }

        private string DecryptData(EncryptedData encryptedData)
        {
            using (var aes = Aes.Create())
            {
                aes.Key = GetEncryptionKey();
                aes.IV = Convert.FromBase64String(encryptedData.IV);

                using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (var ms = new MemoryStream(Convert.FromBase64String(encryptedData.Ciphertext)))
                    {
                        using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (var sr = new StreamReader(cs))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
        }

        private void CheckIntegrity(string decryptedData)
        {
            var filesData = JsonConvert.DeserializeObject<List<FileData>>(decryptedData);

            foreach (var fileData in filesData)
            {
                string savedChecksum;
                if (savedChecksums.TryGetValue(fileData.FilePath, out savedChecksum))
                {
                    if (savedChecksum != fileData.Checksum)
                    {
                        Log($"Checksum mismatch found for file: {fileData.FilePath}");
                    }
                }
                else
                {
                    Log($"Checksum not found for file: {fileData.FilePath}");
                }
            }
        }

        private byte[] GetEncryptionKey()
        {
            return Encoding.UTF8.GetBytes("12345678901234567890123456789012");
        }

        private void Log(string message)
        {
            Console.WriteLine(message);
        }

        private class EncryptedData
        {
            public string IV { get; set; }
            public string Ciphertext { get; set; }
            public string Tag { get; set; }
        }

        private class FileData
        {
            public string FilePath { get; set; }
            public string Checksum { get; set; }
        }
    }
}