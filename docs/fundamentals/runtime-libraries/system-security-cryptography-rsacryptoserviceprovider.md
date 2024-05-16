---
title: System.Security.Cryptography.RSACryptoServiceProvider class
description: Learn about the System.Security.Cryptography.RSACryptoServiceProvider class.
ms.date: 12/31/2023
---
# System.Security.Cryptography.RSACryptoServiceProvider class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Security.Cryptography.RSACryptoServiceProvider> class is the default implementation of <xref:System.Security.Cryptography.RSA>.

The <xref:System.Security.Cryptography.RSACryptoServiceProvider> supports key sizes from 384 bits to 16384 bits in increments of 8 bits if you have the Microsoft Enhanced Cryptographic Provider installed. It supports key sizes from 384 bits to 512 bits in increments of 8 bits if you have the Microsoft Base Cryptographic Provider installed.

Valid key sizes are dependent on the cryptographic service provider (CSP) that is used by the <xref:System.Security.Cryptography.RSACryptoServiceProvider> instance. Windows CSPs enable keys sizes of 384 to 16384 bits for Windows versions prior to Windows 8.1, and key sizes of 512 to 16384 bits for Windows 8.1. For more information, see [CryptGenKey](/windows/win32/api/wincrypt/nf-wincrypt-cryptgenkey) function in the Windows documentation.

## Interoperation with the Microsoft Cryptographic API (CAPI)

Unlike the RSA implementation in unmanaged CAPI, the <xref:System.Security.Cryptography.RSACryptoServiceProvider> class reverses the order of an encrypted array of bytes after encryption and before decryption. By default, data encrypted by the <xref:System.Security.Cryptography.RSACryptoServiceProvider> class cannot be decrypted by the CAPI `CryptDecrypt` function and data encrypted by the CAPI `CryptEncrypt` method cannot be decrypted by the <xref:System.Security.Cryptography.RSACryptoServiceProvider> class.

If you do not compensate for the reverse ordering when interoperating between APIs, the <xref:System.Security.Cryptography.RSACryptoServiceProvider> class throws a <xref:System.Security.Cryptography.CryptographicException>.

To interoperate with CAPI, you must manually reverse the order of encrypted bytes before the encrypted data interoperates with another API. You can easily reverse the order of a managed byte array by calling the <xref:System.Array.Reverse%2A?displayProperty=nameWithType> method.
