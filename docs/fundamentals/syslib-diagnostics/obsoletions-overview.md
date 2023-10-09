---
title: Obsolete features in .NET 5+
titleSuffix: ""
description: Learn about APIs that are marked as obsolete in .NET 5 and later versions that produce SYSLIB compiler warnings.
ms.date: 06/08/2023
---

# Obsolete features in .NET 5+

Starting in .NET 5, some APIs that are newly marked as obsolete make use of two new properties on <xref:System.ObsoleteAttribute>.

- The <xref:System.ObsoleteAttribute.DiagnosticId?displayProperty=nameWithType> property tells the compiler to generate build warnings using a custom diagnostic ID. The custom ID allows for obsoletion warning to be suppressed specifically and separately from one another. In the case of the .NET 5+ obsoletions, the format for the custom diagnostic ID is `SYSLIB0XXX`.

- The <xref:System.ObsoleteAttribute.UrlFormat?displayProperty=nameWithType> property tells the compiler to include a URL link to learn more about the obsoletion.

If you encounter build warnings or errors due to usage of an obsolete API, follow the specific guidance provided for the diagnostic ID listed in the [Reference](#reference) section. Warnings or errors for these obsoletions *can't* be suppressed using the [standard diagnostic ID (CS0618)](../../csharp/language-reference/compiler-messages/cs0618.md) for obsolete types or members; use the custom `SYSLIB0XXX` diagnostic ID values instead. For more information, see [Suppress warnings](#suppress-warnings).

## Reference

The following table provides an index to the `SYSLIB0XXX` obsoletions in .NET 5+.

| Diagnostic ID | Warning or error | Description |
| - | - |
| [SYSLIB0001](syslib0001.md) | Warning | The UTF-7 encoding is insecure and should not be used. Consider using UTF-8 instead. |
| [SYSLIB0002](syslib0002.md) | Error | <xref:System.Security.Permissions.PrincipalPermissionAttribute> is not honored by the runtime and must not be used. |
| [SYSLIB0003](syslib0003.md) | Warning | Code access security (CAS) is not supported or honored by the runtime. |
| [SYSLIB0004](syslib0004.md) | Warning | The constrained execution region (CER) feature is not supported. |
| [SYSLIB0005](syslib0005.md) | Warning | The global assembly cache (GAC) is not supported. |
| [SYSLIB0006](syslib0006.md) | Warning | <xref:System.Threading.Thread.Abort?displayProperty=nameWithType> is not supported and throws <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0007](syslib0007.md) | Warning | The default implementation of this cryptography algorithm is not supported. |
| [SYSLIB0008](syslib0008.md) | Warning | The <xref:System.Runtime.CompilerServices.DebugInfoGenerator.CreatePdbGenerator> API is not supported and throws <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0009](syslib0009.md) | Warning | The <xref:System.Net.AuthenticationManager.Authenticate%2A?displayProperty=nameWithType> and <xref:System.Net.AuthenticationManager.PreAuthenticate%2A?displayProperty=nameWithType> methods are not supported and throw <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0010](syslib0010.md) | Warning | Some remoting APIs are not supported and throw <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0011](syslib0011.md) | Warning | <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> serialization is obsolete and should not be used. |
| [SYSLIB0012](syslib0012.md) | Warning | <xref:System.Reflection.Assembly.CodeBase?displayProperty=nameWithType> and <xref:System.Reflection.Assembly.EscapedCodeBase?displayProperty=nameWithType> are only included for .NET Framework compatibility. Use <xref:System.Reflection.Assembly.Location?displayProperty=nameWithType> instead. |
| [SYSLIB0013](syslib0013.md) | Warning | <xref:System.Uri.EscapeUriString(System.String)?displayProperty=nameWithType> can corrupt the Uri string in some cases. Consider using <xref:System.Uri.EscapeDataString(System.String)?displayProperty=nameWithType> for query string components instead. |
| [SYSLIB0014](syslib0014.md) | Warning | <xref:System.Net.WebRequest>, <xref:System.Net.HttpWebRequest>, <xref:System.Net.ServicePoint>, and <xref:System.Net.WebClient> are obsolete. Use <xref:System.Net.Http.HttpClient> instead. |
| [SYSLIB0015](syslib0015.md) | Warning | <xref:System.Runtime.CompilerServices.DisablePrivateReflectionAttribute> has no effect in .NET 6+. |
| [SYSLIB0016](syslib0016.md) | Warning | Use the <xref:System.Drawing.Graphics.GetContextInfo%2A?displayProperty=nameWithType> overloads that accept arguments for better performance and fewer allocations. |
| [SYSLIB0017](syslib0017.md) | Warning | Strong-name signing is not supported and throws <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0018](syslib0018.md) | Warning | Reflection-only loading is not supported and throws <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0019](syslib0019.md) | Warning | The <xref:System.Runtime.InteropServices.RuntimeEnvironment?displayProperty=nameWithType> members <xref:System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile>, <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(System.Guid,System.Guid)>, and <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsObject(System.Guid,System.Guid)> are no longer supported and throw <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0020](syslib0020.md) | Warning | <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues?displayProperty=nameWithType> is obsolete. To ignore null values when serializing, set <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition> to <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull?displayProperty=nameWithType>. |
| [SYSLIB0021](syslib0021.md) | Warning | Derived cryptographic types are obsolete. Use the `Create` method on the base type instead. |
| [SYSLIB0022](syslib0022.md) | Warning | The <xref:System.Security.Cryptography.Rijndael> and <xref:System.Security.Cryptography.RijndaelManaged> types are obsolete. Use <xref:System.Security.Cryptography.Aes> instead. |
| [SYSLIB0023](syslib0023.md) | Warning | <xref:System.Security.Cryptography.RNGCryptoServiceProvider> is obsolete. To generate a random number, use one of the <xref:System.Security.Cryptography.RandomNumberGenerator> static methods instead. |
| [SYSLIB0024](syslib0024.md) | Warning | Creating and unloading [AppDomains](xref:System.AppDomain) is not supported and throws an exception. |
| [SYSLIB0025](syslib0025.md) | Warning | <xref:System.Runtime.CompilerServices.SuppressIldasmAttribute> has no effect in .NET 6+. |
| [SYSLIB0026](syslib0026.md) | Warning | <xref:System.Security.Cryptography.X509Certificates.X509Certificate> and <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> are immutable. Use the appropriate constructor to create a new certificate. |
| [SYSLIB0027](syslib0027.md) | Warning | <xref:System.Security.Cryptography.X509Certificates.PublicKey.Key?displayProperty=nameWithType> is obsolete. Use the appropriate method to get the public key, such as <xref:System.Security.Cryptography.X509Certificates.PublicKey.GetRSAPublicKey>. |
| [SYSLIB0028](syslib0028.md) | Warning | <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.PrivateKey?displayProperty=nameWithType> is obsolete. Use the appropriate method to get the private key, such as <xref:System.Security.Cryptography.X509Certificates.RSACertificateExtensions.GetRSAPrivateKey(System.Security.Cryptography.X509Certificates.X509Certificate2)?displayProperty=nameWithType>, or use the <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.CopyWithPrivateKey(System.Security.Cryptography.ECDiffieHellman)?displayProperty=nameWithType> method to create a new instance with a private key. |
| [SYSLIB0029](syslib0029.md) | Warning | `ProduceLegacyHmacValues` is obsolete. Producing legacy HMAC values is no longer supported. |
| [SYSLIB0030](syslib0030.md) | Warning | `HMACSHA1` always uses the algorithm implementation provided by the platform. Use a constructor without the `useManagedSha1` parameter. |
| [SYSLIB0031](syslib0031.md) | Warning | <xref:System.Security.Cryptography.CryptoConfig.EncodeOID(System.String)?displayProperty=nameWithType> is obsolete. Use the ASN.1 functionality provided in <xref:System.Formats.Asn1?displayProperty=fullName>. |
| [SYSLIB0032](syslib0032.md) | Warning | Recovery from corrupted process state exceptions is not supported; <xref:System.Runtime.ExceptionServices.HandleProcessCorruptedStateExceptionsAttribute> is ignored. |
| [SYSLIB0033](syslib0033.md) | Warning | <xref:System.Security.Cryptography.Rfc2898DeriveBytes.CryptDeriveKey(System.String,System.String,System.Int32,System.Byte[])?displayProperty=nameWithType> is obsolete and is not supported. Use <xref:System.Security.Cryptography.PasswordDeriveBytes.CryptDeriveKey(System.String,System.String,System.Int32,System.Byte[])?displayProperty=nameWithType> instead. |
| [SYSLIB0034](syslib0034.md) | Warning | <xref:System.Security.Cryptography.Pkcs.CmsSigner.%23ctor(System.Security.Cryptography.CspParameters)> is obsolete. Use an alternative constructor instead. |
| [SYSLIB0035](syslib0035.md) | Warning | <xref:System.Security.Cryptography.Pkcs.SignerInfo.ComputeCounterSignature?displayProperty=nameWithType> is obsolete. Use the overload that accepts a <xref:System.Security.Cryptography.Pkcs.CmsSigner> instead. |
| [SYSLIB0036](syslib0036.md) | Warning | <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A?displayProperty=nameWithType> is obsolete and not supported. Use `RegexGeneratorAttribute` with the regular expression source generator instead. |
| [SYSLIB0037](syslib0037.md) | Warning | <xref:System.Reflection.AssemblyName> members <xref:System.Reflection.AssemblyName.HashAlgorithm>, <xref:System.Reflection.AssemblyName.ProcessorArchitecture>, and <xref:System.Reflection.AssemblyName.VersionCompatibility> are obsolete and not supported. |
| [SYSLIB0038](syslib0038.md) | Warning | <xref:System.Data.SerializationFormat.Binary?displayProperty=nameWithType> is obsolete and should not be used. |
| [SYSLIB0039](syslib0039.md) | Warning | TLS versions 1.0 and 1.1 have known vulnerabilities and are not recommended. Use a newer TLS version instead, or use <xref:System.Security.Authentication.SslProtocols.None?displayProperty=nameWithType> to defer to OS defaults. |
| [SYSLIB0040](syslib0040.md) | Warning | <xref:System.Net.Security.EncryptionPolicy.NoEncryption?displayProperty=nameWithType> and <xref:System.Net.Security.EncryptionPolicy.AllowNoEncryption?displayProperty=nameWithType> significantly reduce security and should not be used in production code. |
| [SYSLIB0041](syslib0041.md) | Warning | The default hash algorithm and iteration counts in <xref:System.Security.Cryptography.Rfc2898DeriveBytes> constructors are outdated and insecure. Use a constructor that accepts the hash algorithm and the number of iterations. |
| [SYSLIB0042](syslib0042.md) | Warning | `ToXmlString` and `FromXmlString` have no implementation for elliptic curve cryptography (ECC) types, and are obsolete. Use a standard import and export format such as `ExportSubjectPublicKeyInfo` or `ImportSubjectPublicKeyInfo` for public keys, and `ExportPkcs8PrivateKey` or `ImportPkcs8PrivateKey` for private keys. |
| [SYSLIB0043](syslib0043.md) | Warning | <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.ToByteArray?displayProperty=nameWithType> and the associated constructor do not have a consistent and interoperable implementation on all platforms. Use <xref:System.Security.Cryptography.ECDiffieHellmanPublicKey.ExportSubjectPublicKeyInfo?displayProperty=nameWithType> instead. |
| [SYSLIB0044](syslib0044.md) | Warning | <xref:System.Reflection.AssemblyName.CodeBase?displayProperty=nameWithType> and <xref:System.Reflection.AssemblyName.EscapedCodeBase?displayProperty=nameWithType> are obsolete. Using them for loading an assembly is not supported. |
| [SYSLIB0045](syslib0045.md) | Warning | Cryptographic factory methods accepting an algorithm name are obsolete. Use the parameterless `Create` factory method on the algorithm type instead. |
| [SYSLIB0046](syslib0046.md) | Warning | The <xref:System.Runtime.ControlledExecution.Run(System.Action,System.Threading.CancellationToken)?displayProperty=nameWithType> method might corrupt the process and should not be used in production code. |
| [SYSLIB0047](syslib0047.md) | Warning | <xref:System.Xml.XmlSecureResolver> is obsolete. Use `XmlResolver.ThrowingResolver` instead when attempting to forbid XML external entity resolution. |
| [SYSLIB0048](syslib0048.md) | Warning | <xref:System.Security.Cryptography.RSA.EncryptValue(System.Byte[])?displayProperty=nameWithType> and <xref:System.Security.Cryptography.RSA.DecryptValue(System.Byte[])?displayProperty=nameWithType> are obsolete. Use <xref:System.Security.Cryptography.RSA.Encrypt%2A?displayProperty=nameWithType> and <xref:System.Security.Cryptography.RSA.Decrypt%2A?displayProperty=nameWithType> instead. |
| [SYSLIB0049](../../../../fundamentals/syslib-diagnostics/syslib0049.md) | Warning | JsonSerializerOptions.AddContext is obsolete. To register a JsonSerializerContext, use either the TypeInfoResolver or TypeInfoResolverChain property. |
| [SYSLIB0050](syslib0050.md) | Warning | Formatter-based serialization is obsolete and should not be used. |
| [SYSLIB0051](syslib0051.md) | Warning | APIs that support obsolete formatter-based serialization are obsolete. They should not be called or extended by application code. |
| [SYSLIB0052](syslib0052.md) | Warning | APIs that support obsolete mechanisms for Regex extensibility are obsolete. |
| [SYSLIB0053](syslib0053.md) | Warning | <xref:System.Security.Cryptography.AesGcm> should indicate the required tag size for encryption and decryption. Use a constructor that accepts the tag size. |

## Suppress warnings

It's recommended that you use an available workaround whenever possible. However, if you cannot change your code, you can suppress warnings through a `#pragma` directive or a `<NoWarn>` project setting. If you must use the obsolete APIs and the `SYSLIB0XXX` diagnostic does not surface as an error, you can suppress the warning in code or in your project file.

To suppress the warnings in code:

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0001

// Code that uses obsolete API.
//...

// Re-enable the warning.
#pragma warning restore SYSLIB0001
```

To suppress the warnings in a project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   <TargetFramework>net6.0</TargetFramework>
   <!-- NoWarn below suppresses SYSLIB0001 project-wide -->
   <NoWarn>$(NoWarn);SYSLIB0001</NoWarn>
   <!-- To suppress multiple warnings, you can use multiple NoWarn elements -->
   <NoWarn>$(NoWarn);SYSLIB0002</NoWarn>
   <NoWarn>$(NoWarn);SYSLIB0003</NoWarn>
   <!-- Alternatively, you can suppress multiple warnings by using a semicolon-delimited list -->
   <NoWarn>$(NoWarn);SYSLIB0001;SYSLIB0002;SYSLIB0003</NoWarn>
  </PropertyGroup>
</Project>
```

> [!NOTE]
> Suppressing warnings in this way only disables the obsoletion warnings you specify. It doesn't disable any other warnings, including obsoletion warnings with different diagnostic IDs.

## See also

- [API obsoletions with non-default diagnostic IDs (.NET 5)](../../core/compatibility/core-libraries/5.0/obsolete-apis-with-custom-diagnostics.md)
- [API obsoletions with non-default diagnostic IDs (.NET 6)](../../core/compatibility/core-libraries/6.0/obsolete-apis-with-custom-diagnostics.md)
- [API obsoletions with non-default diagnostic IDs (.NET 7)](../../core/compatibility/core-libraries/7.0/obsolete-apis-with-custom-diagnostics.md)
- [API obsoletions with non-default diagnostic IDs (.NET 8)](../../core/compatibility/core-libraries/8.0/obsolete-apis-with-custom-diagnostics.md)
