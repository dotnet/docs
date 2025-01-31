---
title: SYSLIB0058 warning - Certain SslStream properties are obsolete
description: Learn about the obsoletion of ExchangeAlgorithmType, CipherAlgorithmType, and HashAlgorithmType enums that generates compile-time warning SYSLIB0058.
ms.date: 01/01/2025
ai-usage: ai-assisted
f1_keywords:
  - SYSLIB0058
---
# SYSLIB0058: Certain SslStream properties are obsolete

The following properties of <xref:System.Net.Security.SslStream?displayProperty=fullName> are obsolete, starting in .NET 10:

- <xref:System.Net.Security.SslStream.KeyExchangeAlgorithm>
- <xref:System.Net.Security.SslStream.KeyExchangeStrength>
- <xref:System.Net.Security.SslStream.CipherAlgorithm>
- <xref:System.Net.Security.SslStream.CipherStrength>
- <xref:System.Net.Security.SslStream.HashAlgorithm>
- <xref:System.Net.Security.SslStream.HashStrength>

<xref:System.Security.Authentication.ExchangeAlgorithmType>, <xref:System.Security.Authentication.CipherAlgorithmType>, and <xref:System.Security.Authentication.HashAlgorithmType> enums are obsolete since they were only used by the <xref:System.Net.Security.SslStream> class.

## Reason for obsoletion

The obsoleted enum types were outdated and missing members for covering new algorithms. Since the same information is available via <xref:System.Net.Security.SslStream.NegotiatedCipherSuite?displayProperty=fullName>, the outdated properties were removed to clarify which one should be used for logging/auditing purposes.

## Workaround

Use <xref:System.Net.Security.SslStream.NegotiatedCipherSuite?displayProperty=fullName> instead.

## Suppress a warning

If you must use the obsolete API, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0058

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0058
```

To suppress all the `SYSLIB0058` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0058</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
