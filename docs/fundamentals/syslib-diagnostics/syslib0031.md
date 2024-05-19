---
title: SYSLIB0031 warning
description: Learn about the obsoletion of EncodeOID that generates compile-time warning SYSLIB0031.
ms.date: 07/16/2021
f1_keywords:
  - syslib0031
---
# SYSLIB0031: EncodeOID is obsolete

The <xref:System.Security.Cryptography.CryptoConfig.EncodeOID(System.String)?displayProperty=nameWithType> method is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0031` at compile time and throws a <xref:System.PlatformNotSupportedException> exception at run time.

## Workarounds

Use the ASN.1 functionality provided in <xref:System.Formats.Asn1?displayProperty=fullName>.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0031

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0031
```

To suppress all the `SYSLIB0031` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0031</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
