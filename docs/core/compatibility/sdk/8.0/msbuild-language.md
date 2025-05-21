---
title: "Breaking change: MSBuild respects DOTNET_CLI_UI_LANGUAGE"
description: Learn about a breaking change in the .NET 8 SDK where MSBuild now respects the 'DOTNET_CLI_UI_LANGUAGE' environment variable.
ms.date: 06/07/2023
ms.topic: concept-article
---
# MSBuild respects DOTNET_CLI_UI_LANGUAGE

MSBuild now respects the `DOTNET_CLI_UI_LANGUAGE` environment variable and uses the language specified by `DOTNET_CLI_UI_LANGUAGE` for its command-line output. This change affects the output of the `msbuild.exe`, `dotnet build`, and `dotnet msbuild` commands.

## Previous behavior

Previously, MSBuild command-line output was always in the operating system (OS) language and used its own encoding, regardless of `DOTNET_CLI_UI_LANGUAGE`.

## New behavior

MSBuild uses the language specified by `DOTNET_CLI_UI_LANGUAGE` instead of the OS language for its command-line output.

On Windows, MSBuild output uses UTF-8 encoding now if `DOTNET_CLI_UI_LANGUAGE` is set and UTF-8 is supported.

## Version introduced

.NET 8 Preview 5

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

Previously, output from commands like `dotnet build` was a mixture of the `DOTNET_CLI_UI_LANGUAGE` language (for .NET SDK output) and the OS language (for MSBuild output). For example, the "Build succeeded/failed" output used the OS language. With this change, the language of .NET SDK and MSBuild output is consistent.

## Recommended action

If you want to keep the old behavior, unset `DOTNET_CLI_UI_LANGUAGE` by using the command `set DOTNET_CLI_UI_LANGUAGE=` (or a similar command for your shell to change environment variables).
