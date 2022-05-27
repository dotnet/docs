---
title: "Walkthrough: Create a Cryptographic Application"
description: Walk through the creation of a cryptographic application. Learn how to encrypt and decrypt content in a Windows Forms application.
ms.date: 11/29/2021
dev_langs:
  - "csharp"
  - "vb"
helpviewer_keywords:
  - "cryptography [NET], example"
  - "cryptography [NET], cryptographic application example"
  - "cryptography [NET], application example"
ms.topic: tutorial
---

# Walkthrough: Create a Cryptographic Application

> [!NOTE]
> This article applies to Windows.
>
> For information about ASP.NET Core, see [ASP.NET Core Data Protection](/aspnet/core/security/data-protection/introduction).

This walkthrough demonstrates how to encrypt and decrypt the contents of a file. The code examples are designed for a Windows Forms application. This application does not demonstrate real-world scenarios, such as using smart cards. Instead, it demonstrates the fundamentals of encryption and decryption.

This walkthrough uses the following guidelines for encryption:

- Use the <xref:System.Security.Cryptography.Aes> class, a symmetric algorithm, to encrypt and decrypt data by using its automatically generated <xref:System.Security.Cryptography.SymmetricAlgorithm.Key%2A> and <xref:System.Security.Cryptography.SymmetricAlgorithm.IV%2A>.
- Use the <xref:System.Security.Cryptography.RSA> asymmetric algorithm to encrypt and decrypt the key to the data encrypted by <xref:System.Security.Cryptography.Aes>. Asymmetric algorithms are best used for smaller amounts of data, such as a key.

  > [!NOTE]
  > If you want to protect data on your computer instead of exchanging encrypted content with other people, consider using the <xref:System.Security.Cryptography.ProtectedData> class.

The following table summarizes the cryptographic tasks in this topic.

| Task | Description |
|--|--|
| Create a Windows Forms application | Lists the controls that are required to run the application. |
| Declare global objects | Declares string path variables, the <xref:System.Security.Cryptography.CspParameters>, and the <xref:System.Security.Cryptography.RSACryptoServiceProvider> to have global context of the <xref:System.Windows.Forms.Form> class. |
| Create an asymmetric key | Creates an asymmetric public and private key-value pair and assigns it a key container name. |
| Encrypt a file | Displays a dialog box to select a file for encryption and encrypts the file. |
| Decrypt a file | Displays a dialog box to select an encrypted file for decryption and decrypts the file. |
| Get a private key | Gets the full key pair using the key container name. |
| Export a public key | Saves the key to an XML file with only public parameters. |
| Import a public key | Loads the key from an XML file into the key container. |
| Test the application | Lists procedures for testing this application. |

## Prerequisites

You need the following components to complete this walkthrough:

- References to the <xref:System.IO> and <xref:System.Security.Cryptography> namespaces.

## Create a Windows Forms application

Most of the code examples in this walkthrough are designed to be event handlers for button controls. The following table lists the controls required for the sample application and their required names to match the code examples.

| Control                                    | Name                     | Text property (as needed) |
|--------------------------------------------|--------------------------|---------------------------|
| <xref:System.Windows.Forms.Button>         | `buttonEncryptFile`      | Encrypt File              |
| <xref:System.Windows.Forms.Button>         | `buttonDecryptFile`      | Decrypt File              |
| <xref:System.Windows.Forms.Button>         | `buttonCreateAsmKeys`    | Create Keys               |
| <xref:System.Windows.Forms.Button>         | `buttonExportPublicKey`  | Export Public Key         |
| <xref:System.Windows.Forms.Button>         | `buttonImportPublicKey`  | Import Public Key         |
| <xref:System.Windows.Forms.Button>         | `buttonGetPrivateKey`    | Get Private Key           |
| <xref:System.Windows.Forms.Label>          | `label1`                 | Key not set               |
| <xref:System.Windows.Forms.OpenFileDialog> | `_encryptOpenFileDialog` |                           |
| <xref:System.Windows.Forms.OpenFileDialog> | `_decryptOpenFileDialog` |                           |

Double-click the buttons in the Visual Studio designer to create their event handlers.

## Declare global objects

Add the following code as part of the declaration of the class Form1. Edit the string variables for your environment and preferences.

[!code-csharp[CryptoWalkThru#1](../../../samples/snippets/csharp/VS_Snippets_CLR/CryptoWalkThru/cs/Form1.cs#1)]
[!code-vb[CryptoWalkThru#1](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CryptoWalkThru/vb/Form1.vb#1)]

## Create an asymmetric key

This task creates an asymmetric key that encrypts and decrypts the <xref:System.Security.Cryptography.Aes> key. This key was used to encrypt the content and it displays the key container name on the label control.

Add the following code as the `Click` event handler for the `Create Keys` button (`buttonCreateAsmKeys_Click`).

[!code-csharp[CryptoWalkThru#2](../../../samples/snippets/csharp/VS_Snippets_CLR/CryptoWalkThru/cs/Form1.cs#2)]
[!code-vb[CryptoWalkThru#2](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CryptoWalkThru/vb/Form1.vb#2)]

## Encrypt a file

This task involves two methods: the event handler method for the `Encrypt File` button (`buttonEncryptFile_Click`) and the `EncryptFile` method. The first method displays a dialog box for selecting a file and passes the file name to the second method, which performs the encryption.

The encrypted content, key, and IV are all saved to one <xref:System.IO.FileStream>, which is referred to as the encryption package.

The `EncryptFile` method does the following:

1. Creates a <xref:System.Security.Cryptography.Aes> symmetric algorithm to encrypt the content.
2. Creates an <xref:System.Security.Cryptography.RSACryptoServiceProvider> object to encrypt the <xref:System.Security.Cryptography.Aes> key.
3. Uses a <xref:System.Security.Cryptography.CryptoStream> object to read and encrypt the <xref:System.IO.FileStream> of the source file, in blocks of bytes, into a destination <xref:System.IO.FileStream> object for the encrypted file.
4. Determines the lengths of the encrypted key and IV, and creates byte arrays of their length values.
5. Writes the Key, IV, and their length values to the encrypted package.

The encryption package uses the following format:

- Key length, bytes 0 - 3
- IV length, bytes 4 - 7
- Encrypted key
- IV
- Cipher text

You can use the lengths of the key and IV to determine the starting points and lengths of all parts of the encryption package, which can then be used to decrypt the file.

Add the following code as the `Click` event handler for the `Encrypt File` button (`buttonEncryptFile_Click`).

[!code-csharp[CryptoWalkThru#3](../../../samples/snippets/csharp/VS_Snippets_CLR/CryptoWalkThru/cs/Form1.cs#3)]
[!code-vb[CryptoWalkThru#3](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CryptoWalkThru/vb/Form1.vb#3)]

Add the following `EncryptFile` method to the form.

[!code-csharp[CryptoWalkThru#5](../../../samples/snippets/csharp/VS_Snippets_CLR/CryptoWalkThru/cs/Form1.cs#5)]
[!code-vb[CryptoWalkThru#5](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CryptoWalkThru/vb/Form1.vb#5)]

## Decrypt a file

This task involves two methods, the event handler method for the `Decrypt File` button (`buttonDecryptFile_Click`), and the `DecryptFile` method. The first method displays a dialog box for selecting a file and passes its file name to the second method, which performs the decryption.

The `Decrypt` method does the following:

1. Creates an <xref:System.Security.Cryptography.Aes> symmetric algorithm to decrypt the content.
2. Reads the first eight bytes of the <xref:System.IO.FileStream> of the encrypted package into byte arrays to obtain the lengths of the encrypted key and the IV.
3. Extracts the key and IV from the encryption package into byte arrays.
4. Creates an <xref:System.Security.Cryptography.RSACryptoServiceProvider> object to decrypt the <xref:System.Security.Cryptography.Aes> key.
5. Uses a <xref:System.Security.Cryptography.CryptoStream> object to read and decrypt the cipher text section of the <xref:System.IO.FileStream> encryption package, in blocks of bytes, into the <xref:System.IO.FileStream> object for the decrypted file. When this is finished, the decryption is completed.

Add the following code as the `Click` event handler for the `Decrypt File` button.

[!code-csharp[CryptoWalkThru#4](../../../samples/snippets/csharp/VS_Snippets_CLR/CryptoWalkThru/cs/Form1.cs#4)]
[!code-vb[CryptoWalkThru#4](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CryptoWalkThru/vb/Form1.vb#4)]

Add the following `DecryptFile` method to the form.

[!code-csharp[CryptoWalkThru#6](../../../samples/snippets/csharp/VS_Snippets_CLR/CryptoWalkThru/cs/Form1.cs#6)]
[!code-vb[CryptoWalkThru#6](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CryptoWalkThru/vb/Form1.vb#6)]

## Export a public key

This task saves the key created by the `Create Keys` button to a file. It exports only the public parameters.

This task simulates the scenario of Alice giving Bob her public key so that he can encrypt files for her. He and others who have that public key will not be able to decrypt them because they do not have the full key pair with private parameters.

Add the following code as the `Click` event handler for the `Export Public Key` button (`buttonExportPublicKey_Click`).

[!code-csharp[CryptoWalkThru#8](../../../samples/snippets/csharp/VS_Snippets_CLR/CryptoWalkThru/cs/Form1.cs#8)]
[!code-vb[CryptoWalkThru#8](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CryptoWalkThru/vb/Form1.vb#8)]

## Import a public key

This task loads the key with only public parameters, as created by the `Export Public Key` button, and sets it as the key container name.

This task simulates the scenario of Bob loading Alice's key with only public parameters so he can encrypt files for her.

Add the following code as the `Click` event handler for the `Import Public Key` button (`buttonImportPublicKey_Click`).

[!code-csharp[CryptoWalkThru#9](../../../samples/snippets/csharp/VS_Snippets_CLR/CryptoWalkThru/cs/Form1.cs#9)]
[!code-vb[CryptoWalkThru#9](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CryptoWalkThru/vb/Form1.vb#9)]

## Get a private key

This task sets the key container name to the name of the key created by using the `Create Keys` button. The key container will contain the full key pair with private parameters.

This task simulates the scenario of Alice using her private key to decrypt files encrypted by Bob.

Add the following code as the `Click` event handler for the `Get Private Key` button (`buttonGetPrivateKey_Click`).

[!code-csharp[CryptoWalkThru#7](../../../samples/snippets/csharp/VS_Snippets_CLR/CryptoWalkThru/cs/Form1.cs#7)]
[!code-vb[CryptoWalkThru#7](../../../samples/snippets/visualbasic/VS_Snippets_CLR/CryptoWalkThru/vb/Form1.vb#7)]

## Test the application

After you have built the application, perform the following testing scenarios.

#### To create keys, encrypt, and decrypt

1. Click the `Create Keys` button. The label displays the key name and shows that it is a full key pair.
2. Click the `Export Public Key` button. Note that exporting the public key parameters does not change the current key.
3. Click the `Encrypt File` button and select a file.
4. Click the `Decrypt File` button and select the file just encrypted.
5. Examine the file just decrypted.
6. Close the application and restart it to test retrieving persisted key containers in the next scenario.

#### To encrypt using the public key

1. Click the `Import Public Key` button. The label displays the key name and shows that it is public only.
2. Click the `Encrypt File` button and select a file.
3. Click the `Decrypt File` button and select the file just encrypted. This will fail because you must have the private key to decrypt.

This scenario demonstrates having only the public key to encrypt a file for another person. Typically that person would give you only the public key and withhold the private key for decryption.

#### To decrypt using the private key

1. Click the `Get Private Key` button. The label displays the key name and shows whether it is the full key pair.
2. Click the `Decrypt File` button and select the file just encrypted. This will be successful because you have the full key pair to decrypt.

## See also

- [Cryptography Model](cryptography-model.md) - Describes how cryptography is implemented in the base class library.
- [Cryptographic Services](cryptographic-services.md)
- [Cross-Platform Cryptography](cross-platform-cryptography.md)
- [ASP.NET Core Data Protection](/aspnet/core/security/data-protection/introduction)
