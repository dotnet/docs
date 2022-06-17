---
title: SYSLIB0005 warning
description: Learn about the obsoletion that generates compile-time warning SYSLIB0005.
ms.date: 10/20/2020
---
# SYSLIB0005: The global assembly cache (GAC) is not supported

.NET Core and .NET 5 and later versions eliminate the concept of the global assembly cache (GAC) that was present in .NET Framework. To help steer developers away from these APIs, some GAC-related APIs are marked as obsolete, starting in .NET 5. Using these APIs generates warning `SYSLIB0005` at compile time.

The following GAC-related APIs are marked obsolete:

- <xref:System.Reflection.Assembly.GlobalAssemblyCache?displayProperty=nameWithType>

  Libraries and apps should not use the <xref:System.Reflection.Assembly.GlobalAssemblyCache> API to make determinations about run-time behavior, as it always returns `false` in .NET Core and .NET 5+.

## Workarounds

If your application queries the <xref:System.Reflection.Assembly.GlobalAssemblyCache> property, consider removing the call. If you use the <xref:System.Reflection.Assembly.GlobalAssemblyCache> value to choose between an "assembly in the GAC"-flow vs. an "assembly not in the GAC"-flow at run time, reconsider whether the flow still makes sense for a .NET 5+ application.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0005

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0005
```

To suppress all the `SYSLIB0005` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0005</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).

## See also

- [Global assembly cache](../../framework/app-domains/gac.md)
