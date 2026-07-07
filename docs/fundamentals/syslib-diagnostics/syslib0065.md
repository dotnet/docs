---
title: SYSLIB0065 warning - AsnEncodedData.RawData setter is obsolete
description: Learn about the obsoletion of the AsnEncodedData.RawData property setter. Use of this setter generates compile-time warning SYSLIB0065.
ms.date: 07/05/2026
ai-usage: ai-assisted
f1_keywords:
  - SYSLIB0065
---

# SYSLIB0065: AsnEncodedData.RawData setter is obsolete

Starting in .NET 11, the `set` accessor of <xref:System.Security.Cryptography.AsnEncodedData.RawData?displayProperty=nameWithType> is obsolete. Setting this property in code generates warning `SYSLIB0065` at compile time.

## Reason for obsoletion

<xref:System.Security.Cryptography.AsnEncodedData> represents an ASN.1-encoded object. Many types derive from it, such as <xref:System.Security.Cryptography.X509Certificates.X509BasicConstraintsExtension>, and cache their decoded representation so that property access doesn't repeatedly decode the ASN.1.

Because `RawData` is not `virtual`, setting it on a derived instance causes a discrepancy between the cached decoded state and the new raw data. The derived type can't detect that the raw data changed, so it continues to return stale decoded values. For example:

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

## Workaround

To maintain coherency between the decoded state and the underlying data, use the constructor of the appropriate type to decode data. Treat instances as read-only—construct a new instance instead of reusing an existing one.

```csharp
// Instead of setting RawData, use the constructor.
X509BasicConstraintsExtension decoded = new(extension, extension.Critical);
```

If you need mutable behavior, use <xref:System.Security.Cryptography.AsnEncodedData.CopyFrom(System.Security.Cryptography.AsnEncodedData)?displayProperty=nameWithType>. The `CopyFrom` method is `virtual`, so derived types can invalidate their decoded state when the raw data changes.

## Suppress a warning

If you must use the obsolete setter, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0065

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0065
```

To suppress all `SYSLIB0065` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0065</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
