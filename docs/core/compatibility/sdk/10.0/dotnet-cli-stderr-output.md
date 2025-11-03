---
title: "Breaking change - dotnet CLI commands log non-command-relevant data to stderr"
description: "Learn about the breaking change in .NET 10 where some dotnet CLI commands log verbose and non-command-relevant data to stderr instead of stdout."
ms.date: 10/08/2025
ai-usage: ai-generated
ms.custom: https://dev.azure.com/msft-skilling/Content/_workitems/edit/494515
---

# dotnet CLI commands log non-command-relevant data to stderr

Starting in .NET 10, some `dotnet` CLI command output that isn't core to the command being invoked emits to `stderr` instead of `stdout`.

## Version introduced

.NET 10 RC 2

## Previous behavior

Previously, first-run messages for the `dotnet` CLI emitted to `stdout`.

## New behavior

Starting in .NET 10, first-run messages for the `dotnet` CLI emit to `stderr`. (In the future, more messages will undergo a similar change.)

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Information that's written to `stdout` that isn't directly related to the command being invoked inhibits the use of commands in scripting or noninteractive circumstances. When non-primary outputs like diagnostics, verbose messages, and incidental notifications are moved to `stderr`, `stdout` remains clean for parsing or other interpretation.

## Recommended action

For most non-PowerShell users, this change shouldn't require any action.

For PowerShell users, we recommend using at least PowerShell version 7.2, where redirecting to `stderr` doesn't set PowerShell's `$Error` variable and cause PowerShell to think the previous command failed execution.

## Affected APIs

None.
