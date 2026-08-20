---
title: "Breaking change: .NET 11 obsoletions in cryptography"
titleSuffix: ""
description: Learn about the cryptography APIs that have been marked as obsolete in .NET 11.
ms.date: 07/06/2026
ai-usage: ai-assisted
---
# Cryptography obsoletions (.NET 11)

Some cryptography APIs are marked as obsolete, starting in .NET 11.

For obsoletions in other core .NET library areas, see [API obsoletions with non-default diagnostic IDs (.NET 11)](../../core-libraries/11/obsolete-apis.md).

## Previous behavior

Previously, you could use these APIs without any compile-time warnings about obsoletion.

## New behavior

In .NET 11 and later versions, using these APIs produces a compile-time diagnostic.

The following table lists the custom diagnostic IDs and their corresponding warning messages.

| Diagnostic ID | Description | Severity |
|---------------|-------------|----------|
| [SYSLIB0065](../../../../fundamentals/syslib-diagnostics/syslib0065.md) | The `set` accessor of <xref:System.Security.Cryptography.AsnEncodedData.RawData?displayProperty=nameWithType> is obsolete. Use the constructor of the appropriate type to decode data, or use <xref:System.Security.Cryptography.AsnEncodedData.CopyFrom(System.Security.Cryptography.AsnEncodedData)?displayProperty=nameWithType> for mutable scenarios. | Warning |

## Version introduced

.NET 11 Preview 6

## Type of breaking change

These obsoletions can affect [source compatibility](../../categories.md#source-compatibility).

## Recommended action

If you must keep use the obsolete APIs, suppress the warning by using the custom diagnostic ID.

## Affected APIs

### SYSLIB0065

- `set` accessor of <xref:System.Security.Cryptography.AsnEncodedData.RawData?displayProperty=fullName>

## See also

- [SYSLIB0065: AsnEncodedData.RawData setter is obsolete](../../../../fundamentals/syslib-diagnostics/syslib0065.md)
- [API obsoletions with non-default diagnostic IDs (.NET 11)](../../core-libraries/11/obsolete-apis.md)
