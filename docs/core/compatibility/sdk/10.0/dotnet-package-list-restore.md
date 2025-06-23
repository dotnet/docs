---
title: "Breaking change - dotnet package list command now performs restore by default"
description: "Learn about the breaking change in .NET 10 where the dotnet package list command now performs a restore before listing packages."
ms.date: 06/05/2025
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/46103
---

# dotnet package list command now performs restore by default

The `dotnet package list` command now automatically performs a restore operation before listing packages to ensure accurate and up-to-date results. This is a behavioral change from the previous implementation where the command did not require a restore step. Additionally, if the restore operation fails, an error message is logged.

## Version introduced

.NET 10 Preview 4

## Previous behavior

The `dotnet package list` command listed project packages without performing a restore. If a restore was needed, you had to run it manually before using the command.

## New behavior

The `dotnet package list` command now automatically performs a restore before listing packages. If the restore fails, the command doesn't list packages and instead logs an error message in both plain text and JSON formats, depending on the command usage.

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

This change ensures the `dotnet package list` command provides accurate and up-to-date package information.

## Recommended action

If this change causes issues in your workflow:

- Use the `--no-restore` option with `dotnet package list` if you want to bypass the implicit restore step.
- Make sure your project is ready for restore before running the `dotnet package list` command.
- Alternatively, run `dotnet restore` manually before using `dotnet package list` to decouple the restore step.

## Affected APIs

None.
