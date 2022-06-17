---
title: SYSLIB0022 warning
description: Learn about the Rijndael and RijndaelManaged obsoletions that generate compile-time warning SYSLIB0022.
ms.date: 05/18/2021
---
# SYSLIB0022: The Rijndael and RijndaelManaged types are obsolete

The <xref:System.Security.Cryptography.Rijndael> and <xref:System.Security.Cryptography.RijndaelManaged> types are marked as obsolete, starting in .NET 6. Using them in code generates warning `SYSLIB0022` at compile time.

## Workarounds

Use <xref:System.Security.Cryptography.Aes?displayProperty=fullName> instead.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0022

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0022
```

To suppress all the `SYSLIB0022` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0022</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
