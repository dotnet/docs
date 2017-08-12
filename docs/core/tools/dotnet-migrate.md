---
title: dotnet migrate command
description: The 'dotnet migrate' command migrates a project and all of its dependencies. 
keywords: dotnet migrate, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 0da07253-5ae1-42e9-9455-bffee9950952
---

# dotnet migrate

## Name

`dotnet migrate` - Migrates a Preview 2 .NET Core project to a .NET Core SDK 1.0 (MSBuild/*csproj*) project.

## Synopsis

`dotnet migrate [<SOLUTION_FILE|PROJECT_DIR>] [--format-report-file-json] [-h|--help] [-r|--report-file] [--skip-backup] [-s|--skip-project-references] [-t|--template-file] [-v|--sdk-package-version] [-x|--xproj-file]`

## Description

The `dotnet migrate` command migrates a valid Preview 2 *project.json*-based project to a valid .NET Core SDK 1.0 (MSBuild/*csproj*) project. 

By default, the command migrates the root project and any project references that the root project contains. This behavior is disabled using the `-s|--skip-project-references` option at runtime. 

Migration is performed on the following:

- A single project by specifying the *project.json* file to migrate.
- All of the directories specified in the *global.json* file by passing in a path to the *global.json* file.
- A *solution.sln* file, where it migrates the projects referenced in the solution.
- On all sub-directories of the given directory recursively.

The `dotnet migrate` command keeps the migrated *project.json* file in a *backup* directory, which it creates if the directory doesn't exist. This behavior is overriden using the `--skip-backup` option. 

By default, the migration operation outputs the state of the migration process to standard output (STDOUT). If you use the `-r|--report-file <REPORT_FILE>` option, the output is saved to the file specified. 

> [!NOTE]
> `dotnet  migrate` only migrates a Preview 2 *project.json*-based project to a .NET Core SDK 1.0 (MSBuild/*csproj*) project.
>
> You can't use the `dotnet migrate` command to migrate DNX or Preview 1 *project.json*-based projects directly to MSBuild/*csproj* projects. For a project built before Preview 2 *project-json*, you first need to manually migrate the project to a Preview 2 *project.json*-based project and then use the `dotnet migrate` command to migrate the project.
> 
> The `dotnet migrate` command only migrates a project to .NET Core SDK 1.0. To migrate from a Preview 2 *project.json*-based project to .NET Core SDK 2.0, use the `dotnet migrate` command to migrate the project to 1.0 and then manually migrate the project to 2.0.

## Arguments

`PROJECT_JSON/GLOBAL_JSON/SOLUTION_FILE/PROJECT_DIR`

The path to one of the following:

- A *project.json* file to migrate.
- A *global.json* file. It migrates the folders specified in *global.json*.
- A *\<solution_name>.sln* file. It migrates the projects referenced in the solution.
- A directory to migrate. It recursively searches for *project.json* files to migrate.

If omitted, `dotnet migrate` defaults the path to the current directory.

## Options

`--format-report-file-json <REPORT_FILE>`

Outputs the migration report file as JSON rather than user messages.

`-h|--help`

Shows help information.

`-r|--report-file <REPORT_FILE>`

Outputs the migration report to a file in addition to the console.

`--skip-backup`

Skips moving *project.json*, *global.json*, and the *xproj* project file to a *backup* directory after successful migration.

`-s|--skip-project-references [Debug|Release]`

Skip migrating project references. By default, project references are migrated recursively.

`-t|--template-file <TEMPLATE_FILE>`

Template *csproj* file to use for the migration. By default, the template used for the migration operation is the same template as the one created by the `dotnet new console` commmand. 

`-v|--sdk-package-version <VERSION>`

The version of the SDK package that's referenced in the migrated app. The default is the version of the SDK used by `dotnet new`.

`-x|--xproj-file <FILE>`

The path to the *xproj* file to use. Required when there's more than one *xproj* file in a project directory.

## Examples

Migrate a project in the current directory and all of its project-to-project dependencies:

`dotnet migrate`

Migrate all projects that the *global.json* file includes:

`dotnet migrate path/to/global.json`

Migrate only the current project and no project-to-project (P2P) dependencies with a specific SDK version:

`dotnet migrate -s -v 1.0.0-preview4`
