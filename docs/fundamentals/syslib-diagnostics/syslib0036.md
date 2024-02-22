---
title: SYSLIB0036 warning - Regex.CompileToAssembly is obsolete
description: Learn about the obsoletion of the Regex.CompileToAssembly method that generates compile-time warning SYSLIB0036.
ms.date: 01/13/2022
---
# SYSLIB0036: Regex.CompileToAssembly is obsolete

The <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A?displayProperty=nameWithType> method is marked as obsolete, starting in .NET 7. Using this API in code generates warning `SYSLIB0036` at compile time.

In .NET 5, .NET 6, and all versions of .NET Core, <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A?displayProperty=nameWithType> throws a <xref:System.PlatformNotSupportedException>. In .NET Framework, <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A?displayProperty=nameWithType> allows a regular expression instance to be compiled into an assembly.

## Workaround

Use the <xref:System.Text.RegularExpressions.GeneratedRegexAttribute> attribute, which invokes a regular expression source generator. At compile time, the source generator produces an API specific to a regular expression pattern and its options.

  ```csharp
  // This attribute causes the regular expression pattern to be compiled into your assembly,
  // which enables it to start up and run more quickly.
  [GeneratedRegex("abc|def", RegexOptions.IgnoreCase)]
  private static partial Regex MyRegex();
  
  // ...
  
  // Use the regular expression 
  if (MyRegex().IsMatch(text) { ... }
  ```

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0036

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0036
```

To suppress all the `SYSLIB0036` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0036</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
