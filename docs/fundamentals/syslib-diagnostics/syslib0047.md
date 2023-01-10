---
title: SYSLIB0047 warning - XmlSecureResolver is obsolete
description: Learn about the obsoletion of XmlSecureResolver that generates compile-time warning SYSLIB0047.
ms.date: 04/08/2022
---
# SYSLIB0047: XmlSecureResolver is obsolete

The <xref:System.Xml.XmlSecureResolver?displayProperty=fullName> type is obsolete, starting in .NET 7. Using it in code generates warning `SYSLIB0047` at compile time.

## Workaround

Consider using the static property `XmlResolver.ThrowingResolver` instead. This property provides an <xref:System.Xml.XmlResolver> instance that forbids resolution of external XML resources.

```csharp
using System.Xml;

XmlResolver resolver = XmlResolver.ThrowingResolver;
```

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0047

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0047
```

To suppress all the `SYSLIB0047` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0047</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).

## See also

- [XmlSecureResolver is obsolete](../../core/compatibility/xml/7.0/xmlsecureresolver-obsolete.md)
