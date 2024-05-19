---
title: SYSLIB0034 warning - CmsSigner(CspParameters) constructor is obsolete
description: Learn about the obsoletion of the CmsSigner(CspParameters) constructor that generates compile-time warning SYSLIB0034.
ms.date: 09/07/2021
f1_keywords:
  - syslib0034
---
# SYSLIB0034: CmsSigner(CspParameters) constructor is obsolete

The <xref:System.Security.Cryptography.Pkcs.CmsSigner.%23ctor(System.Security.Cryptography.CspParameters)> constructor is marked as obsolete, starting in .NET 6. Using this API in code generates warning `SYSLIB0034` at compile time.

## Workaround

Use an alternative constructor.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0034

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0034
```

To suppress all the `SYSLIB0034` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0034</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
