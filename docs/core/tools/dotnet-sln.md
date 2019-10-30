---
title: dotnet sln command
description: The dotnet-sln command provides a convenient option to add, remove, and list projects in a solution file.
ms.date: 10/29/2019
---
# dotnet sln

**This article applies to: ✓** .NET Core 1.x SDK and later versions

<!-- todo: uncomment when all CLI commands are reviewed
[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]
-->

## Name

`dotnet sln` - Modifies a .NET Core solution file.

## Synopsis

```dotnetcli
dotnet sln [<SOLUTION_FILE>] [command] [-h|--help]
```

## Description

The `dotnet sln` command provides a convenient way to add, remove, and list projects in a solution file.

To use the `dotnet sln` command, the solution file must already exist. If you need to create one, use the [dotnet new](dotnet-new.md) command, like in the following example:

```dotnetcli
dotnet new sln
```

## Arguments

- **`SOLUTION_FILE`**

  The solution file to use. If not specified, the command searches the current directory for one. If there are multiple solution files in the directory, one must be specified.

## Options

- **`-h|--help`**

  Prints out a short help for the command.

## Commands

### `add`

Adds a project or multiple projects to the solution file.

#### Synopsis

```dotnetcli
dotnet sln [<SOLUTION_FILE>] add [--in-root] [-s|--solution-folder] <PROJECT_PATH>
dotnet sln add [-h|--help]
```

#### Arguments

- **`SOLUTION_FILE`**

  The solution file to use. If not specified, the command searches the current directory for one. If there are multiple solution files in the directory, one must be specified.

- **`PROJECT_PATH`**

  The path to the project to add to the solution. Add multiple projects by adding one after the other separated by spaces. Unix/Linux shell [globbing pattern](https://en.wikipedia.org/wiki/Glob_(programming)) expansions are processed correctly by the `dotnet sln` command.

#### Options

- **`-h|--help`**

  Prints out a short help for the command.

- **`--in-root`**

  Places the projects in the root of the solution, rather than creating a solution folder. Available since .NET Core 3.0 SDK.

- **`-s|--solution-folder`**

  The destination solution folder path to add the projects to. Available since .NET Core 3.0 SDK.

### `remove`

Removes a project or multiple projects from the solution file.

#### Synopsis

```dotnetcli
dotnet sln [<SOLUTION_FILE>] remove <PROJECT_PATH>
dotnet sln [<SOLUTION_FILE>] remove [-h|--help]
```

#### Arguments

- **`SOLUTION_FILE`**

  The solution file to use. If not specified, the command searches the current directory for one. If there are multiple solution files in the directory, one must be specified.

- **`PROJECT_PATH`**

  The path to the project to remove from the solution. Remove multiple projects by adding one after the other separated by spaces. Unix/Linux shell [globbing pattern](https://en.wikipedia.org/wiki/Glob_(programming)) expansions are processed correctly by the `dotnet sln` command.

#### Options

- **`-h|--help`**

  Prints out a short help for the command.

### `list`

Lists all projects in a solution file.

#### Synopsis

```dotnetcli
dotnet sln list [-h|--help]
```
  
#### Arguments

- **`SOLUTION_FILE`**

  The solution file to use. If not specified, the command searches the current directory for one. If there are multiple solution files in the directory, one must be specified.

#### Options

- **`-h|--help`**

  Prints out a short help for the command.

## Examples

Add a C# project to a solution:

```dotnetcli
dotnet sln todo.sln add todo-app/todo-app.csproj
```

Remove a C# project from a solution:

```dotnetcli
dotnet sln todo.sln remove todo-app/todo-app.csproj
```

Add multiple C# projects to a solution:

```dotnetcli
dotnet sln todo.sln add todo-app/todo-app.csproj back-end/back-end.csproj
```

Remove multiple C# projects from a solution:

```dotnetcli
dotnet sln todo.sln remove todo-app/todo-app.csproj back-end/back-end.csproj
```

Add multiple C# projects to a solution using a globbing pattern (Unix/Linux only):

```dotnetcli
dotnet sln todo.sln add **/*.csproj
```

Remove multiple C# projects from a solution using a globbing pattern (Unix/Linux only):

```dotnetcli
dotnet sln todo.sln remove **/*.csproj
```
