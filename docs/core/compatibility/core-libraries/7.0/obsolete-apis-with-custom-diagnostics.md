---
title: "Breaking change: .NET 7 obsoletions with non-default diagnostic IDs"
titleSuffix: ""
description: Learn about the .NET 7 breaking change in core .NET libraries where some APIs have been marked as obsolete with a custom diagnostic ID.
ms.date: 01/13/2022
---
# API obsoletions with non-default diagnostic IDs (.NET 7)

Some APIs have been marked as obsolete, starting in .NET 7. This breaking change is specific to APIs that have been marked as obsolete *with a custom diagnostic ID*. Suppressing the default obsoletion diagnostic ID, which is [CS0618](../../../../csharp/language-reference/compiler-messages/cs0618.md) for the C# compiler, does not suppress the warnings that the compiler generates when these APIs are used.

## Change description

In previous .NET versions, these APIs can be used without any build warning. In .NET 7 and later versions, use of these APIS produces a compile-time warning or error with a custom diagnostic ID. The use of custom diagnostic IDs allows you to suppress the obsoletion warnings individually instead of blanket-suppressing all obsoletion warnings.

The following table lists the custom diagnostic IDs and their corresponding warning messages for obsoleted APIs.

| Diagnostic ID | Description | Severity |
| - | - |
| [SYSLIB0036](../../../../fundamentals/syslib-diagnostics/syslib0036.md) | <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A?displayProperty=nameWithType> is obsolete and not supported. Use `RegexGeneratorAttribute` with the regular expression source generator instead. | Warning |

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

## See also

- [API obsoletions with non-default diagnostic IDs (.NET 6)](../6.0/obsolete-apis-with-custom-diagnostics.md)
- [API obsoletions with non-default diagnostic IDs (.NET 5)](../5.0/obsolete-apis-with-custom-diagnostics.md)
- [Obsolete features in .NET 5+](../../../../fundamentals/syslib-diagnostics/obsoletions-overview.md)
