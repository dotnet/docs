---
title: "Breaking change: .NET 7 obsoletions with non-default diagnostic IDs"
titleSuffix: ""
description: Learn about the .NET 7 breaking change in core .NET libraries where some APIs have been marked as obsolete with a custom diagnostic ID.
ms.date: 11/07/2022
---
# API obsoletions with non-default diagnostic IDs (.NET 7)

Some APIs have been marked as obsolete, starting in .NET 7. This breaking change is specific to APIs that have been marked as obsolete *with a custom diagnostic ID*. Suppressing the default obsoletion diagnostic ID, which is [CS0618](../../../../csharp/language-reference/compiler-messages/cs0618.md) for the C# compiler, does not suppress the warnings that the compiler generates when these APIs are used.

## Change description

In previous .NET versions, these APIs can be used without any build warning. In .NET 7 and later versions, use of these APIs produces a compile-time warning or error with a custom diagnostic ID. The use of custom diagnostic IDs allows you to suppress the obsoletion warnings individually instead of blanket-suppressing all obsoletion warnings.

The following table lists the custom diagnostic IDs and their corresponding warning messages for obsoleted APIs.

| Diagnostic ID | Description | Severity |
| - | - |
| [SYSLIB0036](../../../../fundamentals/syslib-diagnostics/syslib0036.md) | <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A?displayProperty=nameWithType> is obsolete and not supported. Use `RegexGeneratorAttribute` with the regular expression source generator instead. | Warning |
| [SYSLIB0037](../../../../fundamentals/syslib-diagnostics/syslib0037.md) | <xref:System.Reflection.AssemblyName> members <xref:System.Reflection.AssemblyName.HashAlgorithm>, <xref:System.Reflection.AssemblyName.ProcessorArchitecture>, and <xref:System.Reflection.AssemblyName.VersionCompatibility> are obsolete and not supported. | Warning |
| [SYSLIB0038](../../../../fundamentals/syslib-diagnostics/syslib0038.md) | <xref:System.Data.SerializationFormat.Binary?displayProperty=nameWithType> is obsolete and should not be used. | Warning |
| [SYSLIB0039](../../../../fundamentals/syslib-diagnostics/syslib0039.md) | TLS versions 1.0 and 1.1 have known vulnerabilities and are not recommended. Use a newer TLS version instead, or use <xref:System.Security.Authentication.SslProtocols.None?displayProperty=nameWithType> to defer to OS defaults. | Warning |
| [SYSLIB0040](../../../../fundamentals/syslib-diagnostics/syslib0040.md) | <xref:System.Net.Security.EncryptionPolicy.NoEncryption?displayProperty=nameWithType> and <xref:System.Net.Security.EncryptionPolicy.AllowNoEncryption?displayProperty=nameWithType> significantly reduce security and should not be used in production code. | Warning |
| [SYSLIB0041](../../../../fundamentals/syslib-diagnostics/syslib0041.md) | The default hash algorithm and iteration counts in <xref:System.Security.Cryptography.Rfc2898DeriveBytes> constructors are outdated and insecure. Use a constructor that accepts the hash algorithm and the number of iterations. | Warning |
| [SYSLIB0042](../../../../fundamentals/syslib-diagnostics/syslib0042.md) | `ToXmlString` and `FromXmlString` have no implementation for elliptic curve cryptography (ECC) types, and are obsolete. Use a standard import and export format such as `ExportSubjectPublicKeyInfo` or `ImportSubjectPublicKeyInfo` for public keys, and `ExportPkcs8PrivateKey` or `ImportPkcs8PrivateKey` for private keys. | Warning |
| [SYSLIB0043](../../../../fundamentals/syslib-diagnostics/syslib0043.md) | <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.ToByteArray?displayProperty=nameWithType> and the associated constructor do not have a consistent and interoperable implementation on all platforms. Use <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.ExportSubjectPublicKeyInfo?displayProperty=nameWithType> instead. | Warning |
| [SYSLIB0044](../../../../fundamentals/syslib-diagnostics/syslib0044.md) | <xref:System.Reflection.AssemblyName.CodeBase?displayProperty=nameWithType> and <xref:System.Reflection.AssemblyName.EscapedCodeBase?displayProperty=nameWithType> are obsolete. | Warning |
| [SYSLIB0045](../../../../fundamentals/syslib-diagnostics/syslib0045.md) | Cryptographic factory methods accepting an algorithm name are obsolete. Use the parameterless `Create` factory method on the algorithm type instead. | Warning |
| [SYSLIB0047](../../../../fundamentals/syslib-diagnostics/syslib0047.md) | <xref:System.Xml.XmlSecureResolver> is obsolete. Use `XmlResolver.ThrowingResolver` instead to forbid resolution of external XML resources. | Warning |

## Version introduced

.NET 7

## Type of breaking change

These obsoletions can affect [source compatibility](../../categories.md#source-compatibility).

## Recommended action

- Follow the specific guidance provided for the each diagnostic ID using the URL link provided on the warning.

- Warnings or errors for these obsoletions can't be suppressed using the standard diagnostic ID for obsolete types or members; use the custom `SYSLIBxxxx` diagnostic ID value instead.

## Affected APIs

### SYSLIB0036

- <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A?displayProperty=nameWithType>

### SYSLIB0037

- <xref:System.Reflection.AssemblyName.HashAlgorithm?displayProperty=nameWithType>
- <xref:System.Reflection.AssemblyName.ProcessorArchitecture?displayProperty=nameWithType>
- <xref:System.Reflection.AssemblyName.VersionCompatibility?displayProperty=nameWithType>

### SYSLIB0038

- <xref:System.Data.SerializationFormat.Binary?displayProperty=fullName>

### SYSLIB0039

- <xref:System.Security.Authentication.SslProtocols.Tls?displayProperty=fullName>
- <xref:System.Security.Authentication.SslProtocols.Tls11?displayProperty=fullName>

### SYSLIB0040

- <xref:System.Net.Security.EncryptionPolicy.AllowNoEncryption?displayProperty=fullName>
- <xref:System.Net.Security.EncryptionPolicy.NoEncryption?displayProperty=fullName>

### SYSLIB0041

- <xref:System.Security.Cryptography.Rfc2898DeriveBytes.%23ctor(System.String,System.Byte[])>
- <xref:System.Security.Cryptography.Rfc2898DeriveBytes.%23ctor(System.String,System.Int32)>
- <xref:System.Security.Cryptography.Rfc2898DeriveBytes.%23ctor(System.Byte[],System.Byte[],System.Int32)>
- <xref:System.Security.Cryptography.Rfc2898DeriveBytes.%23ctor(System.String,System.Byte[],System.Int32)>
- <xref:System.Security.Cryptography.Rfc2898DeriveBytes.%23ctor(System.String,System.Int32,System.Int32)>

### SYSLIB0042

- <xref:System.Security.Cryptography.ECDiffieHellmanCng.FromXmlString(System.String,System.Security.Cryptography.ECKeyXmlFormat)?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECDiffieHellmanCng.ToXmlString(System.Security.Cryptography.ECKeyXmlFormat)?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECDiffieHellmanCngPublicKey.FromXmlString(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECDiffieHellmanCngPublicKey.ToXmlString?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.ToXmlString?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECDsaCng.FromXmlString(System.String,System.Security.Cryptography.ECKeyXmlFormat)?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECDsaCng.ToXmlString(System.Security.Cryptography.ECKeyXmlFormat)?displayProperty=fullName>

### SYSLIB0043

- <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.ToByteArray?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.%23ctor(System.Byte[])>

### SYSLIB0045

- <xref:System.Security.Cryptography.Aes.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.AsymmetricAlgorithm.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.DES.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECDiffieHellman.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.ECDsa.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.HashAlgorithm.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.KeyedHashAlgorithm.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.RandomNumberGenerator.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.RC2.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.Rijndael.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.RSA.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA1.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA256.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA384.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA512.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.SymmetricAlgorithm.Create(System.String)?displayProperty=fullName>
- <xref:System.Security.Cryptography.TripleDES.Create(System.String)?displayProperty=fullName>

### SYSLIB0047

- <xref:System.Xml.XmlSecureResolver?displayProperty=fullName>

## See also

- [API obsoletions with non-default diagnostic IDs (.NET 6)](../6.0/obsolete-apis-with-custom-diagnostics.md)
- [API obsoletions with non-default diagnostic IDs (.NET 5)](../5.0/obsolete-apis-with-custom-diagnostics.md)
- [Obsolete features in .NET 5+](../../../../fundamentals/syslib-diagnostics/obsoletions-overview.md)
