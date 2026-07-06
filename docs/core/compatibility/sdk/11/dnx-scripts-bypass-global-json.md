---
title: "Breaking change: dnx scripts bypass global.json SDK selection"
description: "Learn about the breaking change in .NET 11 where the dnx and dnx.cmd scripts no longer respect global.json for SDK selection."
ms.date: 07/05/2026
ai-usage: ai-assisted
---

# dnx scripts bypass global.json SDK selection

The `dnx` and `dnx.cmd` scripts no longer use the .NET muxer to select the SDK version. Instead, they find the newest installed SDK and invoke it directly, which bypasses any `global.json` file in the working directory.

## Version introduced

.NET 10 SDK 10.0.302, 10.0.400, and .NET 11 Preview 6

## Previous behavior

Previously, the `dnx` scripts invoked `dotnet dnx`, which relied on the .NET muxer to select the SDK version based on any `global.json` file in the working directory. If `global.json` pinned an SDK version that predated .NET 10, the scripts failed with the following error:

```output
Unrecognized command or argument 'execute'
```

Starting with .NET 10 SDK 10.0.302 (and later) and .NET 11 Preview 6, the `dnx` and `dnx.cmd` scripts use `dotnet --list-sdks` to identify the newest installed SDK. They then invoke `dotnet exec <sdk-path>/dotnet.dll dnx` directly, bypassing the .NET muxer and any `global.json` SDK pinning.
## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Some .NET CLI commands, including `dnx`, are considered version-independent features that should always run with the newest installed SDK. Relying on `global.json` meant that users who pinned an older SDK version to reduce risk from build-impacting changes also inadvertently broke `dnx`. In folders where a pre-.NET 10 SDK was pinned, the `dnx` command was unavailable, which caused confusing errors and, in some cases, timeouts in tools like Copilot CLI.

## Recommended action

To restore the previous behavior where the .NET muxer and `global.json` control SDK selection, run `dotnet dnx` explicitly instead of the `dnx` script.

## Affected APIs

None.
