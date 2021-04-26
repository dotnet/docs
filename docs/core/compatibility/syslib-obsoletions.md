---
title: Obsolete features in .NET 5+
description: Learn about APIs that are marked as obsolete in .NET 5 and later versions that produce SYSLIB compiler warnings.
ms.date: 10/20/2020
---
# Obsolete features in .NET 5

Starting in .NET 5, some APIs that are newly marked as obsolete make use of two new properties on <xref:System.ObsoleteAttribute>.

- The <xref:System.ObsoleteAttribute.DiagnosticId?displayProperty=nameWithType> property tells the compiler to generate build warnings using a custom diagnostic ID. The custom ID allows for obsoletion warning to be suppressed specifically and separately from one another. In the case of the .NET 5+ obsoletions, the format for the custom diagnostic ID is `SYSLIBxxxx`.

- The <xref:System.ObsoleteAttribute.UrlFormat?displayProperty=nameWithType> property tells the compiler to include a URL link to learn more about the obsoletion.

If you encounter build warnings or errors due to usage of an obsolete API, follow the specific guidance provided for the diagnostic ID listed in the [Reference](#reference) section. Warnings or errors for these obsoletions *can't* be suppressed using the [standard diagnostic ID (CS0618)](../../csharp/language-reference/compiler-messages/cs0618.md) for obsolete types or members; use the custom `SYSLIBxxxx` diagnostic ID values instead. For more information, see [Suppress warnings](#suppress-warnings).

## Reference

The following table provides an index to the `SYSLIBxxxx` obsoletions in .NET 5+.

| Diagnostic ID | Description |
| - | - |
| [SYSLIB0001](syslib-warnings/syslib0001.md) | The UTF-7 encoding is insecure and should not be used. Consider using UTF-8 instead. |
| [SYSLIB0002](syslib-warnings/syslib0002.md) | <xref:System.Security.Permissions.PrincipalPermissionAttribute> is not honored by the runtime and must not be used. |
| [SYSLIB0003](syslib-warnings/syslib0003.md) | Code access security (CAS) is not supported or honored by the runtime. |
| [SYSLIB0004](syslib-warnings/syslib0004.md) | The constrained execution region (CER) feature is not supported. |
| [SYSLIB0005](syslib-warnings/syslib0005.md) | The global assembly cache (GAC) is not supported. |
| [SYSLIB0006](syslib-warnings/syslib0006.md) | <xref:System.Threading.Thread.Abort?displayProperty=nameWithType> is not supported and throws <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0007](syslib-warnings/syslib0007.md) | The default implementation of this cryptography algorithm is not supported. |
| [SYSLIB0008](syslib-warnings/syslib0008.md) | The <xref:System.Runtime.CompilerServices.DebugInfoGenerator.CreatePdbGenerator> API is not supported and throws <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0009](syslib-warnings/syslib0009.md) | The <xref:System.Net.AuthenticationManager.Authenticate%2A?displayProperty=nameWithType> and <xref:System.Net.AuthenticationManager.PreAuthenticate%2A?displayProperty=nameWithType> methods are not supported and throw <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0010](syslib-warnings/syslib0010.md) | Some remoting APIs are not supported and throw <xref:System.PlatformNotSupportedException>. |
| [SYSLIB0011](syslib-warnings/syslib0011.md) | <xref:System.Runtime.Serialization.Formatters.Binary.BinaryFormatter> serialization is obsolete and should not be used. |
| [SYSLIB0012](syslib-warnings/syslib0012.md) | <xref:System.Reflection.Assembly.CodeBase?displayProperty=nameWithType> and <xref:System.Reflection.Assembly.EscapedCodeBase?displayProperty=nameWithType> are only included for .NET Framework compatibility. Use <xref:System.Reflection.Assembly.Location?displayProperty=nameWithType> instead. |

## Suppress warnings

If you must use the obsolete APIs and the `SYSLIBxxxx` diagnostic does not surface as an error, you can suppress the warning in code or in your project file.

In code:

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0001
// Code that uses obsolete API.
...
// Re-enable the warning.
#pragma warning restore SYSLIB0001
```

Project file:

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   <TargetFramework>net5.0</TargetFramework>
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
