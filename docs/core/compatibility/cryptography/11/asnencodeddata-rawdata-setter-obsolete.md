---
title: "Breaking change: AsnEncodedData.RawData setter is obsolete"
description: "Learn about the breaking change in .NET 11 where the AsnEncodedData.RawData property setter is marked obsolete."
ms.date: 07/05/2026
ai-usage: ai-assisted
---

# AsnEncodedData.RawData setter is obsolete

Starting in .NET 11 Preview 6, the `set` accessor of <xref:System.Security.Cryptography.AsnEncodedData.RawData?displayProperty=nameWithType> is marked obsolete. Using the setter generates compiler warning `SYSLIB0065`.

## Version introduced

.NET 11 Preview 6

## Previous behavior

Previously, you could set the <xref:System.Security.Cryptography.AsnEncodedData.RawData?displayProperty=nameWithType> property without a compilation warning. For example:

```csharp
X509BasicConstraintsExtension decoded = new();
decoded.RawData = extension.RawData;
Console.WriteLine(decoded.CertificateAuthority); // Unexpectedly prints False
```

## New behavior

Starting in .NET 11, setting the <xref:System.Security.Cryptography.AsnEncodedData.RawData?displayProperty=nameWithType> property generates compiler warning `SYSLIB0065`.

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility).

## Reason for change

<xref:System.Security.Cryptography.AsnEncodedData> represents an ASN.1-encoded object. Many types derive from it, such as <xref:System.Security.Cryptography.X509Certificates.X509BasicConstraintsExtension>, and these derived types accept the ASN.1 encoding as constructor arguments and decode it. The decoded representation is cached so that property access doesn't repeatedly decode the ASN.1.

Because `RawData` has a setter and is not `virtual`, setting it on a derived instance causes a discrepancy between the decoded state and the underlying data. The derived type can't detect that the raw data changed, so it continues to return stale decoded values. For example:

```csharp
X509BasicConstraintsExtension extension = new(
    certificateAuthority: true,
    hasPathLengthConstraint: true,
    pathLengthConstraint: 3,
    critical: true);

X509BasicConstraintsExtension decoded = new();
decoded.RawData = extension.RawData;
Console.WriteLine(decoded.CertificateAuthority);      // Unexpectedly prints False
Console.WriteLine(decoded.HasPathLengthConstraint);   // Unexpectedly prints False
Console.WriteLine(decoded.PathLengthConstraint);      // Unexpectedly prints 0
```

## Recommended action

To maintain coherency between the decoded state and the underlying data, use the constructor of the appropriate type to decode data. Treat instances as read-only—construct a new instance instead of reusing an existing one.

```csharp
// Instead of setting RawData, construct a new instance.
X509BasicConstraintsExtension decoded = new(extension, extension.Critical);
```

If you need mutable behavior, use <xref:System.Security.Cryptography.AsnEncodedData.CopyFrom(System.Security.Cryptography.AsnEncodedData)?displayProperty=nameWithType>. The `CopyFrom` method is `virtual`, so derived types can invalidate their decoded state when the raw data changes.

To suppress the `SYSLIB0065` warning if you need to keep using the setter, add a suppression in code:

```csharp
#pragma warning disable SYSLIB0065
decoded.RawData = extension.RawData;
#pragma warning restore SYSLIB0065
```

For more information, see [SYSLIB0065](../../../../fundamentals/syslib-diagnostics/syslib0065.md).

## Affected APIs

- `set` accessor of <xref:System.Security.Cryptography.AsnEncodedData.RawData?displayProperty=fullName>
