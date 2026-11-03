---
title: "Breaking change: mono launch target not set for .NET Framework apps"
description: "Learn about the breaking change in .NET 11 where the .NET SDK no longer automatically sets mono as the launch target for .NET Framework applications on Linux."
ms.date: 02/03/2026
ai-usage: ai-assisted
---

# mono launch target not set for .NET Framework apps

The .NET SDK no longer automatically sets `mono` as the launch target for .NET Framework applications on Linux when using `dotnet run`.

## Version introduced

.NET 11 Preview 1

## Previous behavior

Previously, when you called `dotnet run` on a .NET Framework application on Linux, the SDK automatically set the `RunCommand` and `RunArguments` properties in the project file to use Mono as the runtime:

```xml
<RunCommand Condition="'$(RunCommand)' == ''">mono</RunCommand> 
<RunArguments Condition="'$(RunArguments)' == ''">&quot;$(TargetPath)&quot; $(StartArguments)</RunArguments> 
```

This allowed .NET Framework applications to be launched directly using `dotnet run` without additional configuration.

## New behavior

Starting in .NET 11, the SDK no longer automatically configures these properties. Running `dotnet run` on a .NET Framework application on Linux fails unless the `RunCommand` and `RunArguments` properties are explicitly set in the project file.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change was made because running .NET Framework applications on Linux using Mono is no longer officially supported. Mono ownership has transitioned, and the .NET SDK should not automatically configure launch targets for unsupported scenarios.

For more information, see [dotnet/sdk PR #52091](https://github.com/dotnet/sdk/pull/52091).

## Recommended action

If you need to continue running .NET Framework applications on Linux using Mono, you can manually configure the `RunCommand` and `RunArguments` properties in your project file.

## Affected APIs

None.
