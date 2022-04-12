---
title: SYSLIB0043 warning - ECDiffieHellmanPublicKey.ToByteArray is obsolete
description: Learn about the obsoletion of ECDiffieHellmanPublicKey.ToByteArray() and the associated constructor that generates compile-time warning SYSLIB0042.
ms.date: 04/08/2022
---
# SYSLIB0043: ECDiffieHellmanPublicKey.ToByteArray is obsolete

The following methods are obsolete, starting in .NET 7. Using them in code generates warning `SYSLIB0043` at compile time.

- <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.ToByteArray?displayProperty=nameWithType>
- <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.%23ctor(System.Byte[])> (constructor)

The <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.ToByteArray?displayProperty=nameWithType> method does not have an implied file format. Also, for the built-in implementations, it throws <xref:System.PlatformNotSupportedException> on all non-Windows operating systems. Since <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey> also has a standard format export (via the <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.ExportSubjectPublicKeyInfo> method), the older member has been obsoleted.

## Workaround

If you're exporting the public key value, use the <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.ExportSubjectPublicKeyInfo> method instead.

For new derived types (or existing derived types that don't currently call the <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.%23ctor(System.Byte[])> constructor), don't call the protected <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.%23ctor(System.Byte[])> constructor, and either override <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.ToByteArray> to throw an exception, or accept the default behavior of returning an empty array.

For existing derived types that already call the protected <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.%23ctor(System.Byte[])> constructor, continue calling the constructor and suppress the `SYSLIB0043` warning.

[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]
