---
title: SYSLIB0027 warning
description: Learn about the obsoletion of PublicKey.Key that generates compile-time warning SYSLIB0027.
ms.date: 07/16/2021
---
# SYSLIB0027: PublicKey.Key is obsolete

The <xref:System.Security.Cryptography.X509Certificates.PublicKey.Key?displayProperty=nameWithType> property is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0027` at compile time.

## Workarounds

Use the appropriate method to get the public key, such as <xref:System.Security.Cryptography.X509Certificates.PublicKey.GetRSAPublicKey>.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0027

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0027
```

To suppress all the `SYSLIB0027` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0027</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
