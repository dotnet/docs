---
title: "Breaking change: Terminal logger is default"
description: Learn about a breaking change in the .NET 9 SDK where the terminal logger is used by default for interactive MSBuild invocations.
ms.date: 01/10/2024
ms.topic: concept-article
---
# Terminal logger is default

The terminal logger is now enabled by default for all "interactive" terminal sessions. The terminal logger formats the console output for builds differently to the console logger. For more information about the terminal logger, see ['dotnet build' options](../../../tools/dotnet-build.md#options), specifically the `--tl` option.

## Previous behavior

`dotnet build` and other build-related CLI commands used the 'minimal' verbosity MSBuild console logger by default for user-driven builds.

## New behavior

If the terminal supports various layout and colorization features, `dotnet build` and other build-related CLI commands use the terminal logger by default for user-triggered builds. If the command is part of a shell script or has had input or output redirected in any way, or if the terminal doesn't support some of the enhanced layout features that terminal logger has, then the terminal logger isn't used.

## Version introduced

.NET 9 Preview 1

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

The terminal logger output about the progress of a build is more information dense and actionable than the console logger output. The MSBuild team wants to encourage the use of terminal logger early in the .NET 9 release cycle so that there's time to gather feedback about the quality and functionality of the feature.

## Recommended action

If you need to revert to the console logger, you can disable the terminal logger can be disabled in the following ways:

- To disable terminal logger for a specific command, specify `--tl:off` on the command line or via an MSBuild response file.
- To disable terminal logger for all commands, set the `MSBUILDTERMINALLOGGER` environment variable to `off`.

## Affected APIs

N/A

## See also

- ['dotnet build' options](../../../tools/dotnet-build.md#options)
- [Terminal logger](../../../whats-new/dotnet-9/sdk.md#terminal-logger)
