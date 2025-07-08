---
title: SYSLIB0017 warning
description: Learn about the obsoletion of strong-name signing-related APIS that generates compile-time warning SYSLIB0017.
ms.date: 04/24/2021
f1_keywords:
  - syslib0017
---
# SYSLIB0017: Strong-name signing is not supported and throws PlatformNotSupportedException

The following APIS are marked as obsolete, starting in .NET 6. Using them in code generates warning `SYSLIB0017` at compile time. These APIs throw a <xref:System.PlatformNotSupportedException> at run time.

- <xref:System.Reflection.AssemblyName.KeyPair?displayProperty=nameWithType>
- <xref:System.Reflection.StrongNameKeyPair>

For more information, see <https://github.com/dotnet/runtime/issues/50529>.

## Workarounds

None.

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0017

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0017
```

To suppress all the `SYSLIB0017` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0017</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
