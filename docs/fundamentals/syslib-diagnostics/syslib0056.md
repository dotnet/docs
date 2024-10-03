---
title: SYSLIB0056 warning - Assembly.LoadFrom that takes an AssemblyHashAlgorithm is obsolete
description: Learn about the obsoletion of the overload of Assembly.LoadFrom that takes an AssemblyHashAlgorithm that generates compile-time warning SYSLIB0056.
ms.date: 08/07/2024
f1_keywords:
  - SYSLIB0056
---
# SYSLIB0056: Assembly.LoadFrom that takes an AssemblyHashAlgorithm is obsolete

The overload of <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType> that takes an <xref:System.Configuration.Assemblies.AssemblyHashAlgorithm> is obsolete, starting in .NET 9. Calling it in code generates warning `SYSLIB0056` at compile time.

## Reason for obsoletion

<xref:System.Reflection.Assembly.LoadFrom(System.String,System.Byte[],System.Configuration.Assemblies.AssemblyHashAlgorithm)?displayProperty=nameWithType> unconditionally throws a <xref:System.NotSupportedException>. This is a poor development experience. The overload looks like a valid API until it's used, and it throws at run time. Marking it as obsolete gives the necessary design-time signal to not use it.

## Workaround

Use an overload of <xref:System.Reflection.Assembly.LoadFrom%2A?displayProperty=nameWithType> that doesn't take an <xref:System.Configuration.Assemblies.AssemblyHashAlgorithm>.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0056

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0056
```

To suppress all the `SYSLIB0056` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0056</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
