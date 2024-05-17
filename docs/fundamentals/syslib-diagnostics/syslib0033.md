---
title: SYSLIB0033 warning - Rfc2898DeriveBytes.CryptDeriveKey is obsolete
description: Learn about the obsoletion of Rfc2898DeriveBytes.CryptDeriveKey that generates compile-time warning SYSLIB0033.
ms.date: 09/07/2021
f1_keywords:
  - syslib0033
---
# SYSLIB0033: Rfc2898DeriveBytes.CryptDeriveKey is obsolete

The <xref:System.Security.Cryptography.Rfc2898DeriveBytes.CryptDeriveKey(System.String,System.String,System.Int32,System.Byte[])?displayProperty=nameWithType> method is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0033` at compile time.

## Workaround

Use <xref:System.Security.Cryptography.PasswordDeriveBytes.CryptDeriveKey(System.String,System.String,System.Int32,System.Byte[])?displayProperty=nameWithType> instead.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0033

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0033
```

To suppress all the `SYSLIB0033` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0033</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
