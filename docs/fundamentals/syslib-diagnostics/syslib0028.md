---
title: SYSLIB0028 warning
description: Learn about the obsoletion of X509Certificate2.PrivateKey that generates compile-time warning SYSLIB0028.
ms.date: 07/16/2021
f1_keywords:
  - syslib0028
---
# SYSLIB0028: X509Certificate2.PrivateKey is obsolete

The <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.PrivateKey?displayProperty=nameWithType> property is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0028` at compile time.

## Workarounds

Use the appropriate method to get the private key, such as <xref:System.Security.Cryptography.X509Certificates.RSACertificateExtensions.GetRSAPrivateKey(System.Security.Cryptography.X509Certificates.X509Certificate2)?displayProperty=nameWithType>, or use the <xref:System.Security.Cryptography.X509Certificates.X509Certificate2.CopyWithPrivateKey(System.Security.Cryptography.ECDiffieHellman)?displayProperty=nameWithType> method to create a new instance with a private key.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0028

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0028
```

To suppress all the `SYSLIB0028` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0028</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
