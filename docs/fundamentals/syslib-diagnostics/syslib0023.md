---
title: SYSLIB0023 warning
description: Learn about the RNGCryptoServiceProvider obsoletion that generates compile-time warning SYSLIB0023.
ms.date: 05/18/2021
---
# SYSLIB0023: RNGCryptoServiceProvider is obsolete

<xref:System.Security.Cryptography.RNGCryptoServiceProvider> is marked as obsolete, starting in .NET 6. Using it in code generates warning `SYSLIB0023` at compile time.

## Workarounds

To generate a random number, use one of the <xref:System.Security.Cryptography.RandomNumberGenerator> methods instead, for example, <xref:System.Security.Cryptography.RandomNumberGenerator.GetInt32(System.Int32)?displayProperty=nameWithType>.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0023

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0023
```

To suppress all the `SYSLIB0023` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0023</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
