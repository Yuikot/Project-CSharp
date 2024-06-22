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
    //
    //
    //ASCII jest nieprawidłowe. Klucze DES są niemożliwe do stworzenia z 6 bajtów, musi być 8
    //
    //

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