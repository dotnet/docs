---
title: SYSLIB0015 warning
description: Learn about the obsoletion of DisablePrivateReflectionAttribute that generates compile-time warning SYSLIB0015.
ms.date: 04/24/2021
---
# SYSLIB0015: DisablePrivateReflectionAttribute is obsolete

Starting in .NET 6, the <xref:System.Runtime.CompilerServices.DisablePrivateReflectionAttribute?displayProperty=nameWithType> type is marked as obsolete. This attribute has no effect in .NET Core 2.1 and later apps. Using it in code generates warning `SYSLIB0015` at compile time for .NET 6 and later apps.

For more information, see <https://github.com/dotnet/runtime/issues/11811>.

## Workarounds

None.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0015

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0015
```

To suppress all the `SYSLIB0015` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0015</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
