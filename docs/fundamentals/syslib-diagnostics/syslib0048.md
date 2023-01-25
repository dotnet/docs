---
title: SYSLIB0048 warning - RSA.EncryptValue and DecryptValue are obsolete
description: Learn about the obsoletion of the RSA.EncryptValue and RSA.DecryptValue methods that generates compile-time warning SYSLIB0048.
ms.date: 04/08/2022
---
# SYSLIB0048: RSA.EncryptValue and DecryptValue are obsolete

The following methods are obsolete, starting in .NET 8. Calling them in code generates warning `SYSLIB0048` at compile time.

- <xref:System.Security.Cryptography.RSA.EncryptValue(System.Byte[])?displayProperty=fullName>
- <xref:System.Security.Cryptography.RSA.DecryptValue(System.Byte[])?displayProperty=fullName>
- <xref:System.Security.Cryptography.RSACryptoServiceProvider.EncryptValue(System.Byte[])?displayProperty=fullName>
- <xref:System.Security.Cryptography.RSACryptoServiceProvider.DecryptValue(System.Byte[])?displayProperty=fullName>

## Workaround

Use <xref:System.Security.Cryptography.RSA.Encrypt%2A?displayProperty=nameWithType> and <xref:System.Security.Cryptography.RSA.Decrypt%2A?displayProperty=nameWithType> instead.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0048

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0048
```

To suppress all the `SYSLIB0048` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0048</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).

## See also

- [RSA.EncryptValue and RSA.DecryptValue are obsolete](../../core/compatibility/cryptography/8.0/rsa-encrypt-decrypt-value-obsolete.md)
