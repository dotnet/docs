---
title: ".NET 7 breaking change: XmlSecureResolver is obsolete"
description: Learn about the .NET 7 breaking change in XML/XSLT where XmlSecureResolver was obsoleted and XmlSecureResolver.GetEntity unconditionally throws a run-time exception.
ms.date: 09/08/2022
ms.topic: article
---
# XmlSecureResolver is obsolete

The method <xref:System.Xml.XmlSecureResolver.GetEntity(System.Uri,System.String,System.Type)?displayProperty=fullName> unconditionally throws an <xref:System.Xml.XmlException> at run time. If your application utilizes <xref:System.Xml.XmlSecureResolver> and you attempt to resolve an XML resource through it, resolution will fail with an exception.

Additionally, the entire <xref:System.Xml.XmlSecureResolver?displayProperty=fullName> type is obsolete. All references to this type will result in a [SYSLIB0047](../../../../fundamentals/syslib-diagnostics/syslib0047.md) warning at build time. If you've enabled warnings as errors, this will cause a build break if your application references <xref:System.Xml.XmlSecureResolver>.

```csharp
using System.Xml;

// Compiler warning SYSLIB0047: XmlSecureResolver type is obsolete.
XmlResolver resolver = new XmlSecureResolver(
    resolver: new XmlUrlResolver(),
    securityUrl: "https://www.example.com/");

// Call to XmlSecureResolver.GetEntity below throws XmlException at run time.
object entity = resolver.GetEntity(
    absoluteUri: new Uri("https://www.example.com/some-entity"),
    role: null,
    ofObjectToReturn: null);
```

## Previous behavior

In .NET Framework, <xref:System.Xml.XmlSecureResolver.GetEntity(System.Uri,System.String,System.Type)?displayProperty=nameWithType> constructs a Code Access Security (CAS) sandbox to restrict the external XML resource resolution process. If policy is violated, a <xref:System.Security.SecurityException> is thrown.

In .NET Core 3.1, and .NET 6, <xref:System.Xml.XmlSecureResolver.GetEntity(System.Uri,System.String,System.Type)?displayProperty=nameWithType> doesn't restrict external XML resource resolution at all. External resource resolution is allowed to proceed with no limitations.

## New behavior

Starting in .NET 7, <xref:System.Xml.XmlSecureResolver.GetEntity(System.Uri,System.String,System.Type)?displayProperty=nameWithType> unconditionally throws an <xref:System.Xml.XmlException>. It does not construct a CAS sandbox and does not attempt to resolve the external resource.

## Version introduced

.NET 7

## Type of breaking change

This change can affect [source compatibility](../../categories.md#source-compatibility) and [binary compatibility](../../categories.md#binary-compatibility).

## Reason for change

This change improves the security of the .NET ecosystem. This obsoletion moves the behavior of <xref:System.Xml.XmlSecureResolver> from fail-dangerous (always perform resolution) to fail-safe (never perform resolution) when running on .NET 7 or later.

## Recommended action

Consider instead using the newly introduced static property <xref:System.Xml.XmlResolver.ThrowingResolver?displayProperty=nameWithType>. This property provides an <xref:System.Xml.XmlResolver> instance that forbids external resource resolution.

```csharp
using System.Xml;

// BAD: Do not use XmlSecureResolver.
// XmlResolver resolver = new XmlSecureResolver(
//     resolver: new XmlUrlResolver(),
//     securityUrl: "https://www.example.com/");

// GOOD: Use XmlResolver.ThrowingResolver instead.
XmlResolver resolver = XmlResolver.ThrowingResolver;
```

## Affected APIs

- <xref:System.Xml.XmlSecureResolver?displayProperty=fullName>
- <xref:System.Xml.XmlSecureResolver.GetEntity(System.Uri,System.String,System.Type)?displayProperty=fullName>
