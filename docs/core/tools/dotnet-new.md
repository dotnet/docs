---
title: dotnet-new command | Microsoft Docs
description: The dotnet-new command creates new .NET Core projects in the current directory.
keywords: dotnet-new, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 03/06/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: fcc3ed2e-9265-4d50-b59e-dc2e5c190b34
---
#dotnet-new

## Name
`dotnet-new` - Creates a new project, configuration file or solution based on the specified template.

## Synopsis
```
dotnet new <TEMPLATE> [-lang|--language] [-n|--name] [-o|--output] [-all|--show-all] [-h|--help] [Template arguments]
dotnet new <TEMPLATE> [-l|--list]
dotnet new [-all|--show-all]
dotnet new [-h|--help]
```

## Description
The `dotnet new` command provides a convenient way to initialize a valid .NET Core project and sample source code to try out the Command-line interface (CLI) toolset. 

When invoked, the command calls the [template engine](https://github.com/dotnet/templating) to create the artifacts on disk based on the specified template and options.

## Arguments

`<TEMPLATE>`

The template to instantiate when the command is invoked. Each template might have specific options you can pass. For more information, see [Template options](#template-options).

The command contains a default list of templates. Use `dotnet new -all` to see all.

The following table shows the templates that come pre-installed with the SDK. The default language for the template is shown inside brackets such as `[C#]`.

|Template description  | Template name  | Languages |
|----------------------|----------------|-----------|
| Console application  | console        | [C#], F#  |
| Class library        | classlib       | [C#], F#  |
| Unit test project    | mstest         | [C#], F#  |
| xUnit test project   | xunit          | [C#], F#  |
| ASP.NET Core empty   | web            | [C#]      |
| ASP.NET Core web app | mvc            | [C#], F#  |
| ASP.NET Core web api | webapi         | [C#]      |
| Nuget config         | nugetconfig    |           |
| Web config           | webconfig      |           |
| Solution file        | sln            |           |

## Options

`-h|--help`

Prints out help for the command. It can be invoked for the `dotnet new` command itself or for any template, such as `dotnet new mvc --help`.

`-l|--list`

Lists templates containing the specified name. If invoked for the `dotnet new` command itself, it lists the possible templates to be used on the given directory.
For example, if the directory already contains a project, it won't list all project templates.

`-lang|--language <C#|F#>`

The language of the template to create. Language accepted varies by template (see defaults in the [arguments](#arguments) section. 
Not valid for some templates.

`-n|--name <OUTPUT_NAME>`

The name for the output being created. If no name is specified, the name of the current directory is used.

`-o|--output <OUTPUT_DIRECTORY>`

Location to place the generated output.

`-all|--show-all`

Shows all templates for a specific type of project when running in the context of the `dotnet new` command alone. 
When running in the context of a specific template, such as, `dotnet new web -all`, `-all` is interpreted as a force creation flag. 
That might happen when the current directory already contains a project.

## Template options
Each project template may have additional options available. The core templates, for example, have the following.

**console, xunit, mstest, web, webapi **

`-f|--framework` - Specifies which framework to target. Values: netcoreapp1.0 or netcoreapp1.1 (Default: netcoreapp1.0)

**mvc**

`-f|--framework` - Specifies which framework to target. Values: netcoreapp1.0 or netcoreapp1.1 (Default: netcoreapp1.0)

`-au|--authentication` -  The type of authentication to use. Values: None or Individual (Default: None)

`-uld|--use-local-db` - Whether or not to use LocalDB instead of SQLite. Values: true or false (Default: false)

**classlib**

`-f|--framework` - Specifies which framework to target. Values: netcoreapp1.0, netcoreapp1.1 and netstandard1.0 - 1.6 (Default: netstandard1.4).

## Examples

Create a F# console application project in the current directory:

`dotnet new console -lang f#` 
   
Create a new ASP.NET Core C# MVC application project in the current directory with no authentication targeting .NET Core 1.0:  

`dotnet new mvc -au None -f netcoreapp1.0`
 
Create a new XUnit application targeting .NET Core 1.1:

`dotnet new xunit --Framework netcoreapp1.1`

List all templates available for MVC:

`dotnet new mvc -l`
