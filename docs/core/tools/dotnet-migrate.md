---
title: dotnet migrate command - .NET Core CLI
description: The dotnet migrate command migrates a project and all of its dependencies.
author: mairaw
ms.author: mairaw
ms.date: 08/14/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.workload: 
  - dotnetcore
---
# dotnet migrate

[!INCLUDE [topic-appliesto-net-core-all](../../../includes/topic-appliesto-net-core-all.md)]

## Name

`dotnet migrate` - Migrates a Preview 2 .NET Core project to a .NET Core SDK 1.0 project.

## Synopsis

`dotnet migrate [<SOLUTION_FILE|PROJECT_DIR>] [-t|--template-file] [-v|--sdk-package-version] [-x|--xproj-file] [-s|--skip-project-references] [-r|--report-file] [--format-report-file-json] [--skip-backup] [-h|--help]`

## Description

The `dotnet migrate` command migrates a valid Preview 2 *project.json*-based project to a valid .NET Core SDK 1.0 *csproj* project. 

By default, the command migrates the root project and any project references that the root project contains. This behavior is disabled using the `--skip-project-references` option at runtime. 

Migration is performed on the following:

* A single project by specifying the *project.json* file to migrate.
* All of the directories specified in the *global.json* file by passing in a path to the *global.json* file.
* A *solution.sln* file, where it migrates the projects referenced in the solution.
* On all sub-directories of the given directory recursively.

The `dotnet migrate` command keeps the migrated *project.json* file inside a `backup` directory, which it creates if the directory doesn't exist. This behavior is overridden using the `--skip-backup` option.

By default, the migration operation outputs the state of the migration process to standard output (STDOUT). If you use the `--report-file <REPORT_FILE>` option, the output is saved to the file specify. 

The `dotnet migrate` command only supports valid Preview 2 *project.json*-based projects. This means that you cannot use it to migrate DNX or Preview 1 *project.json*-based projects directly to MSBuild/csproj projects. You first need to manually migrate the project to a Preview 2 *project.json*-based project and then use the `dotnet migrate` command to migrate the project.

## Arguments

`PROJECT_JSON/GLOBAL_JSON/SOLUTION_FILE/PROJECT_DIR`

The path to one of the following:

* a *project.json* file to migrate.
* a *global.json* file, it will migrate the folders specified in *global.json*.
* a *solution.sln* file, it will migrate the projects referenced in the solution.
* a directory to migrate, it will recursively search for *project.json* files to migrate.

Defaults to current directory if nothing is specified.

## Options

`-h|--help`

Prints out a short help for the command.

`-t|--template-file <TEMPLATE_FILE>`

Template csproj file to use for migration. By default, the same template as the one dropped by `dotnet new console` is used.

`-v|--sdk-package-version <VERSION>`

The version of the sdk package that's referenced in the migrated app. The default is the version of the SDK in `dotnet new`.

`-x|--xproj-file <FILE>`

The path to the xproj file to use. Required when there is more than one xproj in a project directory.

`-s|--skip-project-references [Debug|Release]`

Skip migrating project references. By default, project references are migrated recursively.

`-r|--report-file <REPORT_FILE>`

Output migration report to a file in addition to the console.

`--format-report-file-json <REPORT_FILE>`

Output migration report file as JSON rather than user messages.

`--skip-backup`

Skip moving *project.json*, *global.json*, and *\*.xproj* to a `backup` directory after successful migration.

## Examples

Migrate a project in the current directory and all of its project-to-project dependencies:

`dotnet migrate`

Migrate all projects that *global.json* file includes:

`dotnet migrate path/to/global.json`

Migrate only the current project and no project-to-project (P2P) dependencies. Also, use a specific SDK version:

`dotnet migrate -s -v 1.0.0-preview4`
