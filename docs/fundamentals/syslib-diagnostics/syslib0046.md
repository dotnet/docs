---
title: SYSLIB0046 warning - ControlledExecution.Run should not be used
description: Learn about the obsoletion of ControlledExecution.Run that generates compile-time warning SYSLIB0046.
ms.date: 11/07/2022
---
# SYSLIB0046: ControlledExecution.Run should not be used

The <xref:System.Runtime.ControlledExecution.Run(System.Action,System.Threading.CancellationToken)?displayProperty=nameWithType> method might corrupt the process and should not be used in production code. This method runs code that can be aborted asynchronously. While this method is new for .NET 7, it's also marked as obsolete to discourage you from using it. For more information, see [Proposal for non-cooperative abortion of code execution](https://github.com/dotnet/runtime/discussions/66480).

## Workaround

N/A

## Suppress a warning

If you must use the obsolete APIs, you can suppress the warning in code or in your project file.

To suppress only a single violation, add preprocessor directives to your source file to disable and then re-enable the warning.

```csharp
// Disable the warning.
#pragma warning disable SYSLIB0046

// Code that uses obsolete API.
// ...

// Re-enable the warning.
#pragma warning restore SYSLIB0046
```

To suppress all the `SYSLIB0046` warnings in your project, add a `<NoWarn>` property to your project file.

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
   ...
   <NoWarn>$(NoWarn);SYSLIB0046</NoWarn>
  </PropertyGroup>
</Project>
```

For more information, see [Suppress warnings](obsoletions-overview.md#suppress-warnings).

## See also

- [Proposal for non-cooperative abortion of code execution](https://github.com/dotnet/runtime/discussions/66480)
