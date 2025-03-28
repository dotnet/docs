---
title: "Breaking change: .NET 10 obsoletions with custom IDs"
titleSuffix: ""
description: Learn about the APIs that have been marked as obsolete in .NET 10 with a custom diagnostic ID.
ms.date: 03/28/2025
ai-usage: ai-assisted
---
# API obsoletions with non-default diagnostic IDs (.NET 10)

Some APIs have been marked as obsolete, starting in .NET 10. This breaking change is specific to APIs that have been marked as obsolete *with a custom diagnostic ID*. Suppressing the default obsoletion diagnostic ID, which is [CS0618](../../../../csharp/language-reference/compiler-messages/cs0618.md) for the C# compiler, does not suppress the warnings that the compiler generates when these APIs are used.

## Change description

In previous .NET versions, these APIs can be used without any build warning. In .NET 10 and later versions, use of these APIs produces a compile-time warning or error with a custom diagnostic ID. The use of custom diagnostic IDs allows you to suppress the obsoletion warnings individually instead of blanket-suppressing all obsoletion warnings.

The following table lists the custom diagnostic IDs and their corresponding warning messages for obsoleted APIs.

| Diagnostic ID | Description | Severity |
|---------------|-------------|----------|
| [SYSLIB0058](../../../../fundamentals/syslib-diagnostics/syslib0058.md) | The `KeyExchangeAlgorithm`, `KeyExchangeStrength`, `CipherAlgorithm`, `CipherAlgorithmStrength`, `HashAlgorithm`, and `HashStrength` properties of <xref:System.Net.Security.SslStream> are obsolete. Use <xref:System.Net.Security.SslStream.NegotiatedCipherSuite> instead. | Warning |
| [SYSLIB0059](../../../../fundamentals/syslib-diagnostics/syslib0059.md) | <xref:Microsoft.Win32.SystemEvents.EventsThreadShutdown?displayProperty=nameWithType> callbacks aren't run before the process exits. Use <xref:System.AppDomain.ProcessExit?displayProperty=nameWithType> instead.  | Warning |
| [SYSLIB0060](../../../../fundamentals/syslib-diagnostics/syslib0060.md) | <xref:System.Security.Cryptography.Rfc2898DeriveBytes?displayProperty=nameWithType> constructors are obsolete. Use <xref:System.Security.Cryptography.Rfc2898DeriveBytes.Pbkdf2*?displayProperty=nameWithType> instead. | Warning |
| [SYSLIB0061](../../../../fundamentals/syslib-diagnostics/syslib0061.md) | <xref:System.Linq.Queryable.MaxBy%603?displayProperty=nameWithType> and <xref:System.Linq.Queryable.MinBy%603?displayProperty=nameWithType> taking an `IComparer<TSource>` are obsolete. Use the new ones that take an `IComparer<TKey>`. | Warning |

## Version introduced

.NET 10

## Type of breaking change

These obsoletions can affect [source compatibility](../../categories.md#source-compatibility).

## Recommended action

- Follow the specific guidance provided for the each diagnostic ID using the URL link provided on the warning.

- Warnings or errors for these obsoletions can't be suppressed using the standard diagnostic ID for obsolete types or members; use the custom `SYSLIBxxxx` diagnostic ID value instead.

## Affected APIs

### SYSLIB0058

- <xref:System.Net.Security.SslStream.KeyExchangeAlgorithm?displayProperty=fullName>
- <xref:System.Net.Security.SslStream.KeyExchangeStrength?displayProperty=fullName>
- <xref:System.Net.Security.SslStream.CipherAlgorithm?displayProperty=fullName>
- <xref:System.Net.Security.SslStream.CipherStrength?displayProperty=fullName>
- <xref:System.Net.Security.SslStream.HashAlgorithm?displayProperty=fullName>
- <xref:System.Net.Security.SslStream.HashStrength?displayProperty=fullName>
- <xref:System.Security.Authentication.ExchangeAlgorithmType?displayProperty=fullName>
- <xref:System.Security.Authentication.CipherAlgorithmType?displayProperty=fullName>
- <xref:System.Security.Authentication.HashAlgorithmType?displayProperty=fullName>

### SYSLIB0059

- <xref:Microsoft.Win32.SystemEvents.EventsThreadShutdown?displayProperty=fullName>

### SYSLIB0060

- <xref:System.Security.Cryptography.Rfc2898DeriveBytes?displayProperty=fullName>
- <xref:System.Security.Cryptography.Rfc2898DeriveBytes.Pbkdf2*?displayProperty=fullName>

### SYSLIB0061

- <xref:System.Linq.Queryable.MaxBy%603?displayProperty=fullName>
- <xref:System.Linq.Queryable.MinBy%603?displayProperty=fullName>

## See also

- [API obsoletions with non-default diagnostic IDs (.NET 9)](../9.0/obsolete-apis-with-custom-diagnostics.md)
- [API obsoletions with non-default diagnostic IDs (.NET 8)](../8.0/obsolete-apis-with-custom-diagnostics.md)
- [Obsolete features in .NET 5+](../../../../fundamentals/syslib-diagnostics/obsoletions-overview.md)
