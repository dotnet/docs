---
title: "Encrypting and Decrypting Strings in Visual Basic"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "encryption [Visual Basic], strings"
  - "strings [Visual Basic], encrypting"
  - "decryption [Visual Basic], strings"
  - "strings [Visual Basic], decrypting"
ms.assetid: 1f51e40a-2f88-43e2-a83e-28a0b5c0d6fd
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# Walkthrough: Encrypting and Decrypting Strings in Visual Basic
This walkthrough shows you how to use the <xref:System.Security.Cryptography.DESCryptoServiceProvider> class to encrypt and decrypt strings using the cryptographic service provider (CSP) version of the Triple Data Encryption Standard (<xref:System.Security.Cryptography.TripleDES>) algorithm. The first step is to create a simple wrapper class that encapsulates the 3DES algorithm and stores the encrypted data as a base-64 encoded string. Then, that wrapper is used to securely store private user data in a publicly accessible text file.  
  
 You can use encryption to protect user secrets (for example, passwords) and to make credentials unreadable by unauthorized users. This can protect an authorized user's identity from being stolen, which protects the user's assets and provides non-repudiation. Encryption can also protect a user's data from being accessed by unauthorized users.  
  
 For more information, see [Cryptographic Services](../../../../standard/security/cryptographic-services.md).  
  
> [!IMPORTANT]
>  The Rijndael (now referred to as Advanced Encryption Standard [AES]) and Triple Data Encryption Standard (3DES) algorithms provide greater security than DES because they are more computationally intensive. For more information, see <xref:System.Security.Cryptography.DES> and <xref:System.Security.Cryptography.Rijndael>.  
  
### To create the encryption wrapper  
  
1.  Create the `Simple3Des` class to encapsulate the encryption and decryption methods.  
  
     [!code-vb[VbVbalrStrings#38](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/walkthrough-encrypting-and-decrypting-strings_1.vb)]  
  
2.  Add an import of the cryptography namespace to the start of the file that contains the `Simple3Des` class.  
  
     [!code-vb[VbVbalrStrings#77](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/walkthrough-encrypting-and-decrypting-strings_2.vb)]  
  
3.  In the `Simple3Des` class, add a private field to store the 3DES cryptographic service provider.  
  
     [!code-vb[VbVbalrStrings#39](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/walkthrough-encrypting-and-decrypting-strings_3.vb)]  
  
4.  Add a private method that creates a byte array of a specified length from the hash of the specified key.  
  
     [!code-vb[VbVbalrStrings#41](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/walkthrough-encrypting-and-decrypting-strings_4.vb)]  
  
5.  Add a constructor to initialize the 3DES cryptographic service provider.  
  
     The `key` parameter controls the `EncryptData` and `DecryptData` methods.  
  
     [!code-vb[VbVbalrStrings#40](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/walkthrough-encrypting-and-decrypting-strings_5.vb)]  
  
6.  Add a public method that encrypts a string.  
  
     [!code-vb[VbVbalrStrings#42](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/walkthrough-encrypting-and-decrypting-strings_6.vb)]  
  
7.  Add a public method that decrypts a string.  
  
     [!code-vb[VbVbalrStrings#43](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/walkthrough-encrypting-and-decrypting-strings_7.vb)]  
  
     The wrapper class can now be used to protect user assets. In this example, it is used to securely store private user data in a publicly accessible text file.  
  
### To test the encryption wrapper  
  
1.  In a separate class, add a method that uses the wrapper's `EncryptData` method to encrypt a string and write it to the user's My Documents folder.  
  
     [!code-vb[VbVbalrStrings#78](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/walkthrough-encrypting-and-decrypting-strings_8.vb)]  
  
2.  Add a method that reads the encrypted string from the user's My Documents folder and decrypts the string with the wrapper's `DecryptData` method.  
  
     [!code-vb[VbVbalrStrings#79](../../../../visual-basic/language-reference/functions/codesnippet/VisualBasic/walkthrough-encrypting-and-decrypting-strings_9.vb)]  
  
3.  Add user interface code to call the `TestEncoding` and `TestDecoding` methods.  
  
4.  Run the application.  
  
     When you test the application, notice that it will not decrypt the data if you provide the wrong password.  
  
## See Also  
 <xref:System.Security.Cryptography>  
 <xref:System.Security.Cryptography.DESCryptoServiceProvider>  
 <xref:System.Security.Cryptography.DES>  
 <xref:System.Security.Cryptography.TripleDES>  
 <xref:System.Security.Cryptography.Rijndael>  
 [Cryptographic Services](../../../../standard/security/cryptographic-services.md)
