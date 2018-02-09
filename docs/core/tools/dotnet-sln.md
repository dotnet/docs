---
title: dotnet sln command - .NET Core CLI
description: The dotnet-sln command provides a convenient option to add, remove, and list projects in a solution file.
author: mairaw
ms.author: mairaw
ms.date: 08/14/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet sln

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet sln` - Modifies a .NET Core solution file.

## Synopsis

```
dotnet sln [<SOLUTION_NAME>] add <PROJECT> <PROJECT> ...
dotnet sln [<SOLUTION_NAME>] add <GLOBBING_PATTERN>
dotnet sln [<SOLUTION_NAME>] remove <PROJECT> <PROJECT> ...
dotnet sln [<SOLUTION_NAME>] remove <GLOBBING_PATTERN>
dotnet sln [<SOLUTION_NAME>] list
dotnet sln [-h|--help]
```

## Description

The `dotnet sln` command provides a convenient way to add, remove, and list projects in a solution file.

## Commands

`add <PROJECT> ...`

`add <GLOBBING_PATTERN>`

Adds a project or multiple projects to the solution file. [Globbing patterns](https://en.wikipedia.org/wiki/Glob_(programming)) are supported on Unix/Linux based terminals.

`remove <PROJECT> ...`

`remove <GLOBBING_PATTERN>`

Removes a project or multiple projects from the solution file. [Globbing patterns](https://en.wikipedia.org/wiki/Glob_(programming)) are supported on Unix/Linux based terminals.

`list`

Lists all projects in a solution file.

## Arguments

`SOLUTION_NAME`

Solution file to use. If not specified, the command searches the current directory for one. If there are multiple solution files in the directory, one must be specified.

## Options

`-h|--help`

Prints out a short help for the command.

## Examples

Add a C# project to a solution:

`dotnet sln todo.sln add todo-app/todo-app.csproj`

Remove a C# project from a solution:

`dotnet sln todo.sln remove todo-app/todo-app.csproj`

Add multiple C# projects to a solution:

`dotnet sln todo.sln add todo-app/todo-app.csproj back-end/back-end.csproj`

Remove multiple C# projects from a solution:

`dotnet sln todo.sln remove todo-app/todo-app.csproj back-end/back-end.csproj`

Add multiple C# projects to a solution using a globbing pattern:

`dotnet sln todo.sln add **/*.csproj`

Remove multiple C# projects from a solution using a globbing pattern:

`dotnet sln todo.sln remove **/*.csproj`
