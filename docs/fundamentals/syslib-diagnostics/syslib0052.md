---
title: SYSLIB0052 warning - APIs that support obsolete mechanisms for Regex extensibility are obsolete
description: Learn about the obsoletion of APIs that support obsolete mechanisms for Regex extensibility that generates compile-time warning SYSLIB0052.
ms.date: 09/08/2023
---
# SYSLIB0052: APIs that support obsolete mechanisms for Regex extensibility are obsolete

The following <xref:System.Text.RegularExpressions.Regex> and <xref:System.Text.RegularExpressions.RegexRunner> APIs are obsolete, starting in .NET 8. Calling them in code generates warning `SYSLIB0052` at compile time. These APIs supported the now obsolete <xref:System.Text.RegularExpressions.Regex.CompileToAssembly%2A>.

- <xref:System.Text.RegularExpressions.Regex.InitializeReferences?displayProperty=nameWithType>
- <xref:System.Text.RegularExpressions.Regex.UseOptionC?displayProperty=nameWithType>
- <xref:System.Text.RegularExpressions.Regex.UseOptionR?displayProperty=nameWithType>
- <xref:System.Text.RegularExpressions.RegexRunner.CharInSet(System.Char,System.String,System.String)?displayProperty=nameWithType>
- <xref:System.Text.RegularExpressions.RegexRunner.Scan(System.Text.RegularExpressions.Regex,System.String,System.Int32,System.Int32,System.Int32,System.Int32,System.Boolean)?displayProperty=nameWithType>
- <xref:System.Text.RegularExpressions.RegexRunner.Scan(System.Text.RegularExpressions.Regex,System.String,System.Int32,System.Int32,System.Int32,System.Int32,System.Boolean,System.TimeSpan)?displayProperty=nameWithType>

## Workaround

N/A

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0052

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0052
```

To suppress all the `SYSLIB0052` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0052</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).
