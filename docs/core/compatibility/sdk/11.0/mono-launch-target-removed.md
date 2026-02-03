---
title: "Breaking change: .NET SDK no longer sets mono launch target for .NET Framework apps"
description: "Learn about the breaking change in .NET 11 Preview 1 where the .NET SDK no longer automatically sets mono as the launch target for .NET Framework applications on Linux."
ms.date: 01/12/2026
ai-usage: ai-assisted
---

# .NET SDK no longer sets mono launch target for .NET Framework apps

The .NET SDK no longer automatically sets `mono` as the launch target for .NET Framework applications on Linux when using `dotnet run`.

## Version introduced

.NET 11 Preview 1

## Previous behavior

Previously, when running `dotnet run` on a .NET Framework application on Linux, the SDK automatically set the `RunCommand` and `RunArguments` properties to use Mono as the runtime:

```xml
<RunCommand Condition="'$(RunCommand)' == ''">mono</RunCommand> 
<RunArguments Condition="'$(RunArguments)' == ''">&quot;$(TargetPath)&quot; $(StartArguments)</RunArguments> 
```

This allowed .NET Framework applications to be launched directly using `dotnet run` without additional configuration.

## New behavior

Starting in .NET 11, the SDK no longer automatically configures these properties. Running `dotnet run` on a .NET Framework application on Linux will fail unless the `RunCommand` and `RunArguments` properties are explicitly set in the project file.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made because running .NET Framework applications on Linux using Mono is no longer officially supported. Mono ownership was transitioned last year, and the .NET SDK should not automatically configure launch targets for unsupported scenarios.

For more information, see [dotnet/sdk PR #52091](https://github.com/dotnet/sdk/pull/52091).

## Recommended action

If you need to continue running .NET Framework applications on Linux using Mono, you can manually configure the `RunCommand` and `RunArguments` properties in your project file:

```xml
<PropertyGroup>
  <RunCommand>mono</RunCommand>
  <RunArguments>"$(TargetPath)" $(StartArguments)</RunArguments>
</PropertyGroup>
```

However, note that this is an unsupported scenario. Consider migrating your application to modern .NET (such as .NET 8 or later) for full Linux support.

## Affected APIs

None.
