---
title: "Breaking change: .NET 6 obsoletions with non-default diagnostic IDs"
titleSuffix: ""
description: Learn about the .NET 6 breaking change in core .NET libraries where some APIs have been marked as obsolete with a custom diagnostic ID.
ms.date: 05/18/2021
---
# API obsoletions with non-default diagnostic IDs (.NET 6)

Some APIs have been marked as obsolete, starting in .NET 6. This breaking change is specific to APIs that have been marked as obsolete *with a custom diagnostic ID*. Suppressing the default obsoletion diagnostic ID, which is [CS0618](../../../../csharp/language-reference/compiler-messages/cs0618.md) for the C# compiler, does not suppress the warnings that the compiler generates when these APIs are used.

## Change description

In previous .NET versions, these APIs can be used without any build warning. In .NET 6 and later versions, use of these APIS produces a compile-time warning or error with a custom diagnostic ID. The use of custom diagnostic IDs allows you to suppress the obsoletion warnings individually instead of blanket-suppressing all obsoletion warnings.

The following table lists the custom diagnostic IDs and their corresponding warning messages for obsoleted APIs.

| Diagnostic ID | Description | Severity |
| - | - |
| [SYSLIB0013](../../../../fundamentals/syslib-diagnostics/syslib0013.md) | <xref:System.Uri.EscapeUriString(System.String)?displayProperty=nameWithType> can corrupt the Uri string in some cases. Consider using <xref:System.Uri.EscapeDataString(System.String)?displayProperty=nameWithType> for query string components instead. | Warning |
| [SYSLIB0014](../../../../fundamentals/syslib-diagnostics/syslib0014.md) | <xref:System.Net.WebRequest>, <xref:System.Net.HttpWebRequest>, <xref:System.Net.ServicePoint>, and <xref:System.Net.WebClient> are obsolete. Use <xref:System.Net.Http.HttpClient> instead. | Error |
| [SYSLIB0015](../../../../fundamentals/syslib-diagnostics/syslib0015.md) | <xref:System.Runtime.CompilerServices.DisablePrivateReflectionAttribute> has no effect in .NET 6+. | Warning |
| [SYSLIB0016](../../../../fundamentals/syslib-diagnostics/syslib0016.md) | Use the <xref:System.Drawing.Graphics.GetContextInfo%2A?displayProperty=nameWithType> overloads that accept arguments for better performance and fewer allocations. | Warning |
| [SYSLIB0017](../../../../fundamentals/syslib-diagnostics/syslib0017.md) | Strong-name signing is not supported and throws <xref:System.PlatformNotSupportedException>. | Warning |
| [SYSLIB0018](../../../../fundamentals/syslib-diagnostics/syslib0018.md) | Reflection-only loading is not supported and throws <xref:System.PlatformNotSupportedException>. | Warning |
| [SYSLIB0019](../../../../fundamentals/syslib-diagnostics/syslib0019.md) | The <xref:System.Runtime.InteropServices.RuntimeEnvironment?displayProperty=nameWithType> members <xref:System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile>, <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(System.Guid,System.Guid)>, and <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsObject(System.Guid,System.Guid)> are no longer supported and throw <xref:System.PlatformNotSupportedException>. | Warning |
| [SYSLIB0020](../../../../fundamentals/syslib-diagnostics/syslib0020.md) | <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues?displayProperty=nameWithType> is obsolete. To ignore null values when serializing, set <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition> to <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull?displayProperty=nameWithType>. | Warning |
| [SYSLIB0021](../../../../fundamentals/syslib-diagnostics/syslib0021.md) | Derived cryptographic types are obsolete. Use the `Create` method on the base type instead. | Warning |
| [SYSLIB0022](../../../../fundamentals/syslib-diagnostics/syslib0022.md) | The <xref:System.Security.Cryptography.Rijndael> and <xref:System.Security.Cryptography.RijndaelManaged> types are obsolete. Use <xref:System.Security.Cryptography.Aes> instead. | Warning |
| [SYSLIB0023](../../../../fundamentals/syslib-diagnostics/syslib0023.md) | <xref:System.Security.Cryptography.RNGCryptoServiceProvider> is obsolete. To generate a random number, use one of the <xref:System.Security.Cryptography.RandomNumberGenerator> static methods instead. | Warning |
| [SYSLIB0024](../../../../fundamentals/syslib-diagnostics/syslib0024.md) | Creating and unloading [AppDomains](xref:System.AppDomain) is not supported and throws an exception. | Warning |

## Version introduced

.NET 6.0

## Recommended action

- Follow the specific guidance provided for the each diagnostic ID using the URL link provided on the warning.

- Warnings or errors for these obsoletions can't be suppressed using the standard diagnostic ID for obsolete types or members; use the custom `SYSLIBxxxx` diagnostic ID value instead.

## Affected APIs

### SYSLIB0013

- <xref:System.Uri.EscapeUriString(System.String)?displayProperty=fullName>

### SYSLIB0014

- <xref:System.Net.WebRequest?displayProperty=fullName>
- <xref:System.Net.HttpWebRequest?displayProperty=fullName>
- <xref:System.Net.ServicePoint?displayProperty=fullName>
- <xref:System.Net.WebClient?displayProperty=fullName>

### SYSLIB0015

- <xref:System.Runtime.CompilerServices.DisablePrivateReflectionAttribute?displayProperty=fullName>

### SYSLIB0016

- <xref:System.Drawing.Graphics.GetContextInfo?displayProperty=fullName>

### SYSLIB0017

- <xref:System.Reflection.AssemblyName.KeyPair?displayProperty=fullName>
- <xref:System.Reflection.StrongNameKeyPair?displayProperty=fullName>

### SYSLIB0018

- <xref:System.Reflection.Assembly.ReflectionOnlyLoad%2A?displayProperty=fullName>
- <xref:System.Reflection.Assembly.ReflectionOnlyLoadFrom(System.String)?displayProperty=fullName>
- <xref:System.Type.ReflectionOnlyGetType(System.String,System.Boolean,System.Boolean)?displayProperty=fullName>

### SYSLIB0019

- <xref:System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(System.Guid,System.Guid)?displayProperty=fullName>
- <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsObject(System.Guid,System.Guid)?displayProperty=fullName>

### SYSLIB0020

- <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues?displayProperty=fullName>

### SYSLIB0021

- <xref:System.Security.Cryptography.AesCryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.AesManaged?displayProperty=fullName>
- <xref:System.Security.Cryptography.DESCryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.MD5CryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.RC2CryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA1CryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA1Managed?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA256Managed?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA256CryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA384Managed?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA384CryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA512Managed?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA512CryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.TripleDESCryptoServiceProvider?displayProperty=fullName>

### SYSLIB0022

- <xref:System.Security.Cryptography.Rijndael?displayProperty=fullName>
- <xref:System.Security.Cryptography.RijndaelManaged?displayProperty=fullName>

### SYSLIB0023

- <xref:System.Security.Cryptography.RNGCryptoServiceProvider>

### SYSLIB0024

- <xref:System.AppDomain.CreateDomain(System.String)?displayProperty=fullName>
- <xref:System.AppDomain.Unload(System.AppDomain)?displayProperty=fullName>

## See also

- [API obsoletions with non-default diagnostic IDs (.NET 5)](../5.0/obsolete-apis-with-custom-diagnostics.md)
- [Obsolete features in .NET 5+](../../../../fundamentals/syslib-diagnostics/obsoletions-overview.md)
