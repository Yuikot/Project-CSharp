using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

void z2()
{
    //  ------------------------------------------------------------------------------------
    //  | Algorytm / Rozmiar klucza | Sekundy na blok  | Bajtów / s(RAM) | Bajtów / s(HDD) |
    //  ------------------------------------------------------------------------------------
    //  |  AES(CSP) 128 bit         |    0.00023       |   4,347,826     |   195,312       | 
    //  |  AES(CSP) 256 bit         |    0.00042       |  2,380,952      |   107,142       |  
    //  |   AES Managed 128 bit     |    0.00017       |   5,882,353     |   264,706       |  
    //  |   AES Managed 256 bit     |    0.00031       |   3,225,806     |   145,161       |  
    //  |   Rindael Managed 128 bit |    0.00017       |   5,882,353     |   264,706       |  
    //  |   Rindael Managed 256 bit |    0.00031       |   3,225,806     |   145,161       |  
    //  |   DES 56 bit              |    0.00015       |   6,666,667     |   300,000       |  
    //  |   3DES 168 bit            |    0.00052       |   1,923,077     |   86,538        |  
    //  ------------------------------------------------------------------------------------

}

void z3()
{
    string encryptedHex = "23c73dde8faedd91413fb5dd1d7e066d70425ed1e058d0e2f7e9e43501824a95446baf28f6ce7ffd3c544f40efb5c80f235de1321214328781a6ea0c0c4c7b74be3968ca1ffb8455";
    byte[] encryptedBytes = HexStringToByteArray(encryptedHex);
    string knownPlaintext = "test";

    byte[] key = new byte[8];
    key[2] = key[3] = key[4] = key[5] = (byte)'5';

    key[6] = key[7] = 0;

    Stopwatch stopwatch = Stopwatch.StartNew();

    for (int i = 0; i <= 0xFFFF; i++)
    {
        key[0] = (byte)(i >> 8);
        key[1] = (byte)i;

        if (TryDecrypt(encryptedBytes, key, knownPlaintext))
        {
            stopwatch.Stop();
            Console.WriteLine("Key found: " + BitConverter.ToString(key).Replace("-", ""));
            Console.WriteLine("Time taken: " + stopwatch.Elapsed);
            break;
        }
        else
        {
            Console.WriteLine("Key not found: " + BitConverter.ToString(key).Replace("-", ""));
        }
    }


    static bool TryDecrypt(byte[] encryptedBytes, byte[] key, string knownPlaintext)
    {
        using (var des = DES.Create())
        {
            des.Key = key;
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.None;

            try
            {
                using (var decryptor = des.CreateDecryptor())
                {
                    byte[] decryptedBytes = decryptor.TransformFinalBlock(encryptedBytes, 0, encryptedBytes.Length);
                    string decryptedText = Encoding.ASCII.GetString(decryptedBytes);

                    if (decryptedText.StartsWith(knownPlaintext))
                    {
                        Console.WriteLine("Decrypted text: " + decryptedText);
                        return true;
                    }
                }
            }
            catch (CryptographicException)
            {
                return false;
            }
        }
        return false;
    }

    static byte[] HexStringToByteArray(string hex)
    {
        int numberChars = hex.Length;
        byte[] bytes = new byte[numberChars / 2];
        for (int i = 0; i < numberChars; i += 2)
        {
            bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
        }
        return bytes;
    }

}

void z4()
{
    try
    {
        string inputFile = "input.txt";
        string encryptedFile = "encryption.txt"; 
        string decryptedFile = "decryption.txt"; 

        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            string publicKey = rsa.ToXmlString(false);
            File.WriteAllText("public_key.xml", publicKey);

            string privateKey = rsa.ToXmlString(true);
            File.WriteAllText("private_key.xml", privateKey);
        }

        EncryptFile(inputFile, encryptedFile, "public_key.xml");

        DecryptFile(encryptedFile, decryptedFile, "private_key.xml");

        Console.WriteLine("Operacja zakończona pomyślnie.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Wystąpił błąd: {ex.Message}");
    }

    Console.ReadKey();


    //szyfrowanie pliku RSA
    static void EncryptFile(string inputFile, string outputFile, string publicKeyFile)
    {
        try
        {
            string publicKey = File.ReadAllText(publicKeyFile);
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(publicKey);

            byte[] inputData = File.ReadAllBytes(inputFile);

            byte[] encryptedData = rsa.Encrypt(inputData, false);

            File.WriteAllBytes(outputFile, encryptedData);
        }
        catch (Exception ex)
        {
            throw new Exception($"Błąd podczas szyfrowania pliku: {ex.Message}");
        }
    }

    //deszyfrowanie pliku RSA
    static void DecryptFile(string inputFile, string outputFile, string privateKeyFile)
    {
        try
        {
            string privateKey = File.ReadAllText(privateKeyFile);
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(privateKey);

            byte[] encryptedData = File.ReadAllBytes(inputFile);

            byte[] decryptedData = rsa.Decrypt(encryptedData, false);

            File.WriteAllBytes(outputFile, decryptedData);
        }
        catch (Exception ex)
        {
            throw new Exception($"Błąd podczas deszyfrowania pliku: {ex.Message}");
        }
    }
}

z3();
