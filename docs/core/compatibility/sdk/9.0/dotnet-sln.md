---
title: "'dotnet sln add' no longer allows invalid file names"
description: Learn about the breaking change in the .NET SDK where the CLI command 'dotnet sln add' adds support for .slnx solution files and no longer allows invalid file names.
ms.date: 12/10/2024
ai-usage: ai-assisted
ms.custom: https://github.com/dotnet/docs/issues/43882
---

# `dotnet sln add` no longer allows invalid file names

Starting in .NET SDK 9.0.2xx, the [`dotnet sln add`](../../../tools/dotnet-sln.md#add) CLI command includes support for *.slnx* solution files using the [vs-solutionpersistence](https://github.com/microsoft/vs-solutionpersistence) serializer. As a result, slight changes in behavior are expected.

## Version introduced

.NET SDK 9.0.2xx

## Previous behavior

Previously, projects and solution folders could have invalid Windows file names. They could also have invalid characters in their names. In addition, `dotnet sln add` failed if you attempted to add a nested project with the same name as an existing project.

## New behavior

Starting in .NET SDK 9.0.2xx, projects and solution folder names:

- Can't be a DOS word: `NUL`, `CON`, `AUX`, `PRN`, `COM?`, `LPT?`, or `CLOCK$` (where `?` is any number of digits).
- Must be 260 characters or less.
- Can't contain invalid characters, such as control characters or `?`, `:`, `\`, `/`, `*`, `"`, `"`, `<`, `>`, and `|`.

In addition, `dotnet sln add` now succeeds if you attempt to add a nested project with the same name as an existing project, which mimics the behavior for non-nested projects. Example: Adding `folder/project.csproj` and `parent/child/project.csproj` doesn't result in an error.

Exceptions contain the current strings, but wrap error messages from [vs-solutionpersistence](https://github.com/microsoft/vs-solutionpersistence).

## Type of breaking change

This change is a [behavioral change](../../categories.md#behavioral-change).

## Reason for change

These changes were introduced to transition to the new `vs-solutionpersistence` serializer.

## Recommended action

Review project and solution folders names to ensure they comply with the new naming restrictions.

## Affected APIs

N/A
