---
title: "Decrypting Data"
description: Learn how to decrypt data in .NET, using a symmetric algorithm or an asymmetric algorithm.
ms.date: 07/16/2020
ms.technology: dotnet-standard
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "data [.NET], decryption"
  - "symmetric decryption"
  - "asymmetric decryption"
  - "decryption"
ms.assetid: 9b266b6c-a9b2-4d20-afd8-b3a0d8fd48a0
---

# Decrypting Data

Decryption is the reverse operation of encryption. For secret-key encryption, you must know both the key and IV that were used to encrypt the data. For public-key encryption, you must know either the public key (if the data was encrypted using the private key) or the private key (if the data was encrypted using the public key).

## Symmetric Decryption

The decryption of data encrypted with symmetric algorithms is similar to the process used to encrypt data with symmetric algorithms. The <xref:System.Security.Cryptography.CryptoStream> class is used with symmetric cryptography classes provided by .NET to decrypt data read from any managed stream object.

The following example illustrates how to create a new instance of the default implementation class for the <xref:System.Security.Cryptography.Aes> algorithm. The instance is used to perform decryption on a <xref:System.Security.Cryptography.CryptoStream> object. This example first creates a new instance of the **Aes** implementation class. Next it creates a **CryptoStream** object and initializes it to the value of a managed stream called `myStream`. Next, the **CreateDecryptor** method from the **Aes** class is passed the same key and IV that was used for encryption and is then passed to the **CryptoStream** constructor.

```vb
Dim aes As Aes = Aes.Create()
Dim cryptStream As New CryptoStream(myStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read)
```

```csharp
Aes aes = Aes.Create();
CryptoStream cryptStream = new CryptoStream(myStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read);
```

The following example shows the entire process of creating a stream, decrypting the stream, reading from the stream, and closing the streams. A file stream object is created that reads a file named *TestData.txt*. The file stream is then decrypted using the **CryptoStream** class and the **Aes** class. This example specifies key and IV values that are used in the symmetric encryption example for [Encrypting Data](encrypting-data.md). It does not show the code needed to encrypt and transfer these values.

```vb
Imports System
Imports System.IO
Imports System.Security.Cryptography

Module Module1
    Sub Main()
            'The key and IV must be the same values that were used
            'to encrypt the stream.
            Dim key As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
            Dim iv As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
        Try
            'Create a file stream.
            Dim myStream As FileStream = new FileStream("TestData.txt", FileMode.Open)

            'Create a new instance of the default Aes implementation class
            'and decrypt the stream.
            Dim aes As Aes = Aes.Create()

            'Create an instance of the CryptoStream class, pass it the file stream, and decrypt
            'it with the Rijndael class using the key and IV.
            Dim cryptStream As New CryptoStream(myStream, aes.CreateDecryptor(key, iv), CryptoStreamMode.Read)

            'Read the stream.
            Dim sReader As New StreamReader(cryptStream)

            'Display the message.
            Console.WriteLine("The decrypted original message: {0}", sReader.ReadToEnd())

            'Close the streams.
            sReader.Close()
            myStream.Close()
            'Catch any exceptions.
        Catch
            Console.WriteLine("The decryption Failed.")
            Throw
        End Try
    End Sub
End Module
```

```csharp
using System;
using System.IO;
using System.Security.Cryptography;

class Class1
{
    static void Main(string[] args)
    {
        //The key and IV must be the same values that were used
        //to encrypt the stream.
        byte[] key = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
        byte[] iv = { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
        try
        {
            //Create a file stream.
            FileStream myStream = new FileStream("TestData.txt", FileMode.Open);

            //Create a new instance of the default Aes implementation class
            Aes aes = Aes.Create();

            //Create a CryptoStream, pass it the file stream, and decrypt
            //it with the Aes class using the key and IV.
            CryptoStream cryptStream = new CryptoStream(
               myStream,
               aes.CreateDecryptor(key, iv),
               CryptoStreamMode.Read);

            //Read the stream.
            StreamReader sReader = new StreamReader(cryptStream);

            //Display the message.
            Console.WriteLine("The decrypted original message: {0}", sReader.ReadToEnd());

            //Close the streams.
            sReader.Close();
            myStream.Close();
        }
        //Catch any exceptions.
        catch
        {
            Console.WriteLine("The decryption failed.");
            throw;
        }
    }
}
```

The preceding example uses the same key, IV, and algorithm used in the symmetric encryption example for [Encrypting Data](encrypting-data.md). It decrypts the *TestData.txt* file that is created by that example and displays the original text on the console.

## Asymmetric Decryption

Typically, a party (party A) generates both a public and private key and stores the key either in memory or in a cryptographic key container. Party A then sends the public key to another party (party B). Using the public key, party B encrypts data and sends the data back to party A. After receiving the data, party A decrypts it using the private key that corresponds. Decryption will be successful only if party A uses the private key that corresponds to the public key Party B used to encrypt the data.

For information on how to store an asymmetric key in secure cryptographic key container and how to later retrieve the asymmetric key, see [How to: Store Asymmetric Keys in a Key Container](how-to-store-asymmetric-keys-in-a-key-container.md).

The following example illustrates the decryption of two arrays of bytes that represent a symmetric key and IV. For information on how to extract the asymmetric public key from the <xref:System.Security.Cryptography.RSA> object in a format that you can easily send to a third party, see [Encrypting Data](encrypting-data.md).

```vb
'Create a new instance of the RSA class.
Dim rsa As RSA = RSA.Create()

' Export the public key information and send it to a third party.
' Wait for the third party to encrypt some data and send it back.

'Decrypt the symmetric key and IV.
symmetricKey = rsa.Decrypt(encryptedSymmetricKey, RSAEncryptionPadding.Pkcs1)
symmetricIV = rsa.Decrypt(encryptedSymmetricIV, RSAEncryptionPadding.Pkcs1)
```

```csharp
//Create a new instance of the RSA class.
RSA rsa = RSA.Create();

// Export the public key information and send it to a third party.
// Wait for the third party to encrypt some data and send it back.

//Decrypt the symmetric key and IV.
symmetricKey = rsa.Decrypt(encryptedSymmetricKey, RSAEncryptionPadding.Pkcs1);
symmetricIV = rsa.Decrypt(encryptedSymmetricIV , RSAEncryptionPadding.Pkcs1);
```

## See also

- [Generating Keys for Encryption and Decryption](generating-keys-for-encryption-and-decryption.md)
- [Encrypting Data](encrypting-data.md)
- [Cryptographic Services](cryptographic-services.md)
- [Cryptography Model](cryptography-model.md)
- [Cross-Platform Cryptography](cross-platform-cryptography.md)
- [Timing vulnerabilities with CBC-mode symmetric decryption using padding](vulnerabilities-cbc-mode.md)
- [ASP.NET Core Data Protection](/aspnet/core/security/data-protection/introduction)
