---
title: SYSLIB0024 warning
description: Learn about the AppDomain-related obsoletions that generate compile-time warning SYSLIB0024.
ms.date: 05/18/2021
f1_keywords:
  - syslib0024
---
# SYSLIB0024: Creating and unloading AppDomains is not supported and throws an exception

The <xref:System.AppDomain.CreateDomain(System.String)?displayProperty=nameWithType> and <xref:System.AppDomain.Unload(System.AppDomain)?displayProperty=nameWithType> methods are marked as obsolete, starting in .NET 6. Using them in code generates warning `SYSLIB0024` at compile time and throws an exception at run time.

## Workarounds

None.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0024

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0024
```

To suppress all the `SYSLIB0024` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0024</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
