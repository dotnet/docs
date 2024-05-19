---
title: SYSLIB0037 warning - AssemblyName members HashAlgorithm, ProcessorArchitecture, and VersionCompatibility are obsolete
description: Learn about the obsoletion of some AssemblyName properties that generates compile-time warning SYSLIB0037.
ms.date: 01/13/2022
f1_keywords:
  - syslib0037
---
# SYSLIB0037: AssemblyName members HashAlgorithm, ProcessorArchitecture, and VersionCompatibility are obsolete

The following <xref:System.Reflection.AssemblyName?displayProperty=fullName> properties are marked as obsolete, starting in .NET 7. Using these APIs in code generates warning `SYSLIB0037` at compile time.

- <xref:System.Reflection.AssemblyName.HashAlgorithm>
- <xref:System.Reflection.AssemblyName.ProcessorArchitecture>
- <xref:System.Reflection.AssemblyName.VersionCompatibility>

These properties are not a proper part of an <xref:System.Reflection.AssemblyName> instance. They don't roundtrip through <xref:System.Reflection.AssemblyName> string representation, and they are ignored by the assembly loader in .NET Core.

## Workaround

Don't use these members in scenarios where it was expected for the values to be round-tripped through the string representation of the <xref:System.Reflection.AssemblyName>.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0037

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0037
```

To suppress all the `SYSLIB0037` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0037</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
