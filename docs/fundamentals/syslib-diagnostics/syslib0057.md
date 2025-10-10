---
title: SYSLIB0057 warning - X509Certificate2 and X509Certificate constructors for binary and file content are obsolete
description: Learn about the obsoletion of some X509Certificate2 and X509Certificate constructors that generates compile-time warning SYSLIB0057.
ms.date: 08/01/2024
f1_keywords:
  - SYSLIB0057
---
# SYSLIB0057: X509Certificate2 and X509Certificate constructors for binary and file content are obsolete

The constructors on <xref:System.Security.Cryptography.X509Certificates.X509Certificate> and <xref:System.Security.Cryptography.X509Certificates.X509Certificate2> that accept content as a `byte[]`, `ReadOnlySpan<byte>`, or a `string` file path are obsolete, starting in .NET 9. The <xref:System.Security.Cryptography.X509Certificates.X509Certificate2Collection.Import%2A> methods on X509Certificate2Collection are also obsolete. Calling them in code generates warning `SYSLIB0057` at compile time.

## Reason for obsoletion

The affected APIs supported loading certificates in multiple formats. For example, `new X509Certificate2(data)` loaded a certificate from a `byte[]` called `data`. `data` could be one of any supported format, including X.509, PKCS7, or PKCS12/PFX.

While this method was easy to use, it created issues where user-supplied data was passed with a different format than intended. This might allow loading PKCS12 where only X.509 content was intended to be loaded. Or it might create interoperability issues from handling the data in different ways.

## Workaround

Use a different API to load certificate content, depending on the intended content type.

A new class called <xref:System.Security.Cryptography.X509Certificates.X509CertificateLoader>can be used to load X.509 or PKCS12 content:

- If you're loading X.509 content, use `X509CertificateLoader.LoadCertificate` or `X509CertificateLoader.LoadCertificateFromFile`.
- If you're loading PKCS12 content, use `X509CertificateLoader.LoadPkcs12`, `X509CertificateLoader.LoadPkcs12FromFile`, `X509CertificateLoader.LoadPkcs12Collection`, or `X509CertificateLoader.LoadPkcs12CollectionFromFile`.
- If you're loading PKCS7 content, use <xref:System.Security.Cryptography.Pkcs.SignedCms > from the System.Security.Cryptography.Pkcs package to inspect certificates in PKCS7 content.
- If you're uncertain about the content type you're loading, use <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.GetCertContentType%2A> to determine the content type and call the appropriate API.

The [Microsoft.Bcl.Cryptography package](https://www.nuget.org/packages/Microsoft.Bcl.Cryptography/) supplies `X509CertificateLoader` for .NET Framework and .NET Standard.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0057

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0057
```

To suppress all the `SYSLIB0057` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0057</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
