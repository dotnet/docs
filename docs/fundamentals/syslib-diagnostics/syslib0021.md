---
title: SYSLIB0021 warning
description: Learn about the obsoletion of derived cryptographic types that generates compile-time warning SYSLIB0021.
ms.date: 05/18/2021
---
# SYSLIB0021: Derived cryptographic types are obsolete

The following derived cryptographic types are marked as obsolete, starting in .NET 6. Using them in code generates warning `SYSLIB0021` at compile time.

- <xref:System.Security.Cryptography.AesCryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.AesManaged?displayProperty=fullName>
- <xref:System.Security.Cryptography.DESCryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.MD5CryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.RC2CryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA1CryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA1Managed?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA256Managed?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA256CryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA384Managed?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA384CryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA512Managed?displayProperty=fullName>
- <xref:System.Security.Cryptography.SHA512CryptoServiceProvider?displayProperty=fullName>
- <xref:System.Security.Cryptography.TripleDESCryptoServiceProvider?displayProperty=fullName>

## Workarounds

Use the `Create` method on the base type instead. For example, use <xref:System.Security.Cryptography.TripleDES.Create%2A?displayProperty=nameWithType> instead of <xref:System.Security.Cryptography.TripleDESCryptoServiceProvider>.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0021

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0021
```

To suppress all the `SYSLIB0021` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0021</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
