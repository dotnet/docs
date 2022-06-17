---
title: SYSLIB0026 warning
description: Learn about the obsoletion of mutable X509 certificate APIs that generates compile-time warning SYSLIB0026.
ms.date: 06/21/2021
---
# SYSLIB0026: X509Certificate and X509Certificate2 are immutable

The following mutable x509 certificate APIs are marked as obsolete, starting in .NET 6. Using these APIs in code generates warning `SYSLIB0026` at compile time.

- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.%23ctor>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate.Import%2A?displayProperty=nameWithType>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.%23ctor>
- <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.Import%2A?displayProperty=nameWithType>

## Workarounds

Create a new instance of `X509Certificate` and `X509Certificate2` using a constructor overload that accepts the certificate as input. For example:

```csharp
// Change this:
cert.Import("/path/to/certificate.crt");

// To this:
cert.Dispose();
cert = new X509Certificate2("/path/to/certificate.crt");
```

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0026

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0026
```

To suppress all the `SYSLIB0026` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0026</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
