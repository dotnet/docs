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

Previously, you could set <xref:System.Security.Cryptography.AsnEncodedData.RawData?displayProperty=nameWithType> without any build warning. On derived types such as <xref:System.Security.Cryptography.X509Certificates.X509BasicConstraintsExtension>, the setter could silently desynchronize the cached decoded state from the new raw data.

## New behavior

In .NET 11 and later versions, setting <xref:System.Security.Cryptography.AsnEncodedData.RawData?displayProperty=nameWithType> produces a compile-time warning with a custom diagnostic ID. The use of a custom diagnostic ID lets you suppress the warning individually instead of suppressing all obsoletion warnings.

The following table lists the custom diagnostic ID and its corresponding warning message.

| Diagnostic ID | Description | Severity |
|---------------|-------------|----------|
| [SYSLIB0065](../../../../fundamentals/syslib-diagnostics/syslib0065.md) | The `set` accessor of <xref:System.Security.Cryptography.AsnEncodedData.RawData?displayProperty=nameWithType> is obsolete. Use the constructor of the appropriate type to decode data, or use <xref:System.Security.Cryptography.AsnEncodedData.CopyFrom(System.Security.Cryptography.AsnEncodedData)?displayProperty=nameWithType> for mutable scenarios. | Warning |

## Version introduced

.NET 11 Preview 6

## Type of breaking change

This obsoletion can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

Because <xref:System.Security.Cryptography.AsnEncodedData.RawData?displayProperty=nameWithType> isn't `virtual`, setting it on a derived instance can leave cached decoded values stale, and derived types can't react when the raw data changes.

## Recommended action

Use the constructor of the appropriate type to decode data. For mutable scenarios, use <xref:System.Security.Cryptography.AsnEncodedData.CopyFrom(System.Security.Cryptography.AsnEncodedData)?displayProperty=nameWithType>.

If you must keep the existing code, suppress the warning by using the custom `SYSLIB0065` diagnostic ID.

## Affected APIs

### SYSLIB0065

- `set` accessor of <xref:System.Security.Cryptography.AsnEncodedData.RawData?displayProperty=fullName>

## See also

- [SYSLIB0065: AsnEncodedData.RawData setter is obsolete](../../../../fundamentals/syslib-diagnostics/syslib0065.md)
- [API obsoletions with non-default diagnostic IDs (.NET 11)](../../core-libraries/11/obsolete-apis.md)
