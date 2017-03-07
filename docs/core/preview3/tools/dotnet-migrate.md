---
title: dotnet-migrate command | Microsoft Docs
description: The dotnet-migrate command migrates a project and all of its dependencies. 
keywords: dotnet-migrate, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 0da07253-5ae1-42e9-9455-bffee9950952
---
#dotnet-migrate

## Name

`dotnet-migrate` - Migrates a Preview 2 .NET Core project to .NET Core SDK 1.0.0 project

## Synopsis

```
dotnet migrate [-t|--template-file] [-v|--sdk-package-version] [-x|--xproj-file] [-s|--skip-project-references] [-r|--report-file] [--format-report-file-json] [--skip-backup] [<arguments>]
dotnet migrate [-h|--help]
```

## Description

The `dotnet migrate` command will migrate a valid Preview 2 `project.json` based project to a valid SDK 1.0.0 `csproj` project. 
By default, the command will migrate the root project and any project references that the root project contains. This behavior 
can be disabled using the `--skip-project-references` option at runtime. 

Migration can be done on either:

* A single project by specifying the `project.json` file to migrate
* All of the directories specified in the `global.json` file by passing in a path to the `global.json` file
* On all sub-directories of the given directory recursively 

The migrate command will keep the migrated `project.json` file inside a `backup` directory which it will create if it doesn't 
exist. This can be overriden using the `--skip-backup` option. 

By default, the migration operation will output the state of the migration process to standard output (STDOUT). If you use the 
`--report-file` option, that output will also be saved to a file that you specify. 

As of the release of .NET Core SDK 1.0.0, the `dotnet migrate` command only supports valid Preview 2 `project.json` files. This means that you cannot use it to migrate old DNX or Preview 1 `project.json` files directly to csproj; you first need to migrate them to Preview 2 project.json files and then to csproj files. In the future, we will add support for Preview 1 projects. 

## Options

`-h|--help`

Prints out a short help for the command.  

`-t|--template-file <TEMPLATE_FILE>`

Template csproj file to use for migration. By default, the same template as the one dropped by `dotnet new console` will be used. 

`-v|--sdk-package-version <VERSION>`

The version of the sdk package that will be referenced in the migrated app. The default is the version of the sdk in dotnet new.

`-x|--xproj-file <FILE>`

The path to the xproj file to use. Required when there is more than one xproj in a project directory.

`-s|--skip-project-references [Debug|Release]`

Skip migrating project references. By default, project references are migrated recursively.

`-r|--report-file <REPORT_FILE>`

Output migration report to a file in addition to the console.

`--format-report-file-json <REPORT_FILE>`

Output migration report file as json rather than user messages.

`--skip-backup`

Skip moving project.json, global.json, and \*.xproj to a `backup` directory after successful migration.

## Examples

Migrate a project in the current directory and all of its project to project dependencies:

`dotnet migrate`

Migrate all projects that `global.json` file points to:

`dotnet migrate path/to/global.json`

Migrate only the current project and no project to project dependencies and use a specific SDK version:

`dotnet migrate -s -v 1.0.0-preview4`
