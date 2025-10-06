---
title: "Breaking change - dotnet CLI commands log non-command-relevant data to stderr"
description: "Learn about the breaking change in .NET 10 RC 2 where some dotnet CLI commands log verbose and non-command-relevant data to stderr instead of stdout."
ms.date: 01/24/2025
ai-usage: ai-assisted
ms.custom: https://dev.azure.com/msft-skilling/Content/_workitems/edit/494515
---

# dotnet CLI commands log non-command-relevant data to stderr

Starting in .NET 10 RC 2, some `dotnet` CLI command output that isn't core to the command being invoked emits to `stderr` instead of `stdout`. At the time of this writing, the only change is the first-run message output, but this set will grow over time.

## Version introduced

.NET 10 RC 2

## Previous behavior

First-run messages for the `dotnet` CLI emitted to `stdout`.

```bash
dotnet build > output.txt
# First-run messages were included in output.txt
```

## New behavior

First-run messages for the `dotnet` CLI emit to `stderr`.

```bash
dotnet build > output.txt
# First-run messages are not included in output.txt
# They appear on the console instead
```

## Type of breaking change

This is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Writing information to `stdout` that isn't directly related to the command being invoked inhibits the use of commands in scripting or noninteractive circumstances. Moving to `stderr` emission for non-primary outputs like diagnostics, verbose messages, or incidental notifications means that `stdout` remains clean for parsing or other interpretation.

## Recommended action

For most non-PowerShell users, this change shouldn't require any action. For PowerShell users, we recommend:

- Using at least PowerShell version 7.2, where redirecting to `stderr` doesn't set PowerShell's `$Error` variable and cause PowerShell to think the previous command failed execution.

If you need to capture or suppress first-run messages, you can:

- Set the `DOTNET_NOLOGO` environment variable to `true` to disable the first-run message entirely.
- Redirect `stderr` separately from `stdout` in your scripts.

```bash
# Example: Redirect stderr to a separate file
dotnet build > output.txt 2> errors.txt

# Example: Discard stderr
dotnet build > output.txt 2>/dev/null
```

## Affected APIs

None.
