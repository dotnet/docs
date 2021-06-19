---
title: Obsolete features in .NET 5+
titleSuffix: ""
description: Learn about APIs that are marked as obsolete in .NET 5 and later versions that produce SYSLIB compiler warnings.
ms.date: 04/23/2021
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
| [SYSLIB0001][0001] | Warning | The UTF-7 encoding is insecure and should not be used. Consider using UTF-8 instead. |
| [SYSLIB0002][0002] | Error | <xref:System.Security.Permissions.PrincipalPermissionAttribute> is not honored by the runtime and must not be used. |
| [SYSLIB0003][0003] | Warning | Code access security (CAS) is not supported or honored by the runtime. |
| [SYSLIB0004][0004] | Warning | The constrained execution region (CER) feature is not supported. |
| [SYSLIB0005][0005] | Warning | The global assembly cache (GAC) is not supported. |
| [SYSLIB0006][0006] | Warning | <xref:System.Threading.Thread.Abort?displayProperty=nameWithType> is not supported and throws <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0007][0007] | Warning | The default implementation of this cryptography algorithm is not supported. |
| [SYSLIB0008][0008] | Warning | The <xref:System.Runtime.CompilerServices.DebugInfoGenerator.CreatePdbGenerator> API is not supported and throws <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0009][0009] | Warning | The <xref:System.Net.AuthenticationManager.Authenticate%2A?displayProperty=nameWithType> and <xref:System.Net.AuthenticationManager.PreAuthenticate%2A?displayProperty=nameWithType> methods are not supported and throw <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0010][0010] | Warning | Some remoting APIs are not supported and throw <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0011][0011] | Warning | <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> serialization is obsolete and should not be used. |
| [SYSLIB0012][0012] | Warning | <xref:System.Reflection.Assembly.CodeBase?displayProperty=nameWithType> and <xref:System.Reflection.Assembly.EscapedCodeBase?displayProperty=nameWithType> are only included for .NET Framework compatibility. Use <xref:System.Reflection.Assembly.Location?displayProperty=nameWithType> instead. |
| [SYSLIB0013][0013] | Warning | <xref:System.Uri.EscapeUriString(System.String)?displayProperty=nameWithType> can corrupt the Uri string in some cases. Consider using <xref:System.Uri.EscapeDataString(System.String)?displayProperty=nameWithType> for query string components instead. |
| [SYSLIB0014][0014] | Error | <xref:System.Net.WebRequest>, <xref:System.Net.HttpWebRequest>, <xref:System.Net.ServicePoint>, and <xref:System.Net.WebClient> are obsolete. Use <xref:System.Net.Http.HttpClient> instead. |
| [SYSLIB0015][0015] | Warning | <xref:System.Runtime.CompilerServices.DisablePrivateReflectionAttribute> has no effect in .NET 6+. |
| [SYSLIB0016][0016] | Warning | Use the <xref:System.Drawing.Graphics.GetContextInfo%2A?displayProperty=nameWithType> overloads that accept arguments for better performance and fewer allocations. |
| [SYSLIB0017][0017] | Warning | Strong-name signing is not supported and throws <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0018][0018] | Warning | Reflection-only loading is not supported and throws <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0019][0019] | Warning | The <xref:System.Runtime.InteropServices.RuntimeEnvironment?displayProperty=nameWithType> members <xref:System.Runtime.InteropServices.RuntimeEnvironment.SystemConfigurationFile>, <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsIntPtr(System.Guid,System.Guid)>, and <xref:System.Runtime.InteropServices.RuntimeEnvironment.GetRuntimeInterfaceAsObject(System.Guid,System.Guid)> are no longer supported and throw <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0020][0020] | Warning | <xref:System.Text.Json.JsonSerializerOptions.IgnoreNullValues?displayProperty=nameWithType> is obsolete. To ignore null values when serializing, set <xref:System.Text.Json.JsonSerializerOptions.DefaultIgnoreCondition> to <xref:System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull?displayProperty=nameWithType>. |
| [SYSLIB0021][0021] | Warning | Derived cryptographic types are obsolete. Use the `Create` method on the base type instead. |
| [SYSLIB0022][0022] | Warning | The <xref:System.Security.Cryptography.Rijndael> and <xref:System.Security.Cryptography.RijndaelManaged> types are obsolete. Use <xref:System.Security.Cryptography.Aes> instead. |
| [SYSLIB0023][0023] | Warning | <xref:System.Security.Cryptography.RNGCryptoServiceProvider> is obsolete. To generate a random number, use one of the <xref:System.Security.Cryptography.RandomNumberGenerator> static methods instead. |
| [SYSLIB0024][0024] | Warning | Creating and unloading [AppDomains](xref:System.AppDomain) is not supported and throws an exception. |

<!-- Include adds ## Suppress warnings (H2 heading) -->
[!INCLUDE [suppress-syslib-warning](includes/suppress-syslib-warning.md)]

[0001]: syslib0001.md
[0002]: syslib0002.md
[0003]: syslib0003.md
[0004]: syslib0004.md
[0005]: syslib0005.md
[0006]: syslib0006.md
[0007]: syslib0007.md
[0008]: syslib0008.md
[0009]: syslib0009.md
[0010]: syslib0010.md
[0011]: syslib0011.md
[0012]: syslib0012.md
[0013]: syslib0013.md
[0014]: syslib0014.md
[0015]: syslib0015.md
[0016]: syslib0016.md
[0017]: syslib0017.md
[0018]: syslib0018.md
[0019]: syslib0019.md
[0020]: syslib0020.md
[0021]: syslib0021.md
[0022]: syslib0022.md
[0023]: syslib0023.md
[0024]: syslib0024.md
