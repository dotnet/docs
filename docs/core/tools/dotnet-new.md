---
title: dotnet new command - .NET Core CLI
description: The dotnet new command creates new .NET Core projects based on the specified template.
keywords: dotnet-new, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 08/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: fcc3ed2e-9265-4d50-b59e-dc2e5c190b34
---
# dotnet new

## Name

`dotnet new` - Creates a new project, configuration file, or solution based on the specified template.

## Synopsis

# [.NET Core 2.x](#tab/netcore2x)
```
dotnet new <TEMPLATE> [--force] [-i|--install] [-lang|--language] [-n|--name] [-o|--output] [-u|--uninstall] [Template options]
dotnet new <TEMPLATE> [-l|--list]
dotnet new [-h|--help]
```
# [.NET Core 1.x](#tab/netcore1x)
```
dotnet new <TEMPLATE> [-lang|--language] [-n|--name] [-o|--output] [-all|--show-all] [-h|--help] [Template options]
dotnet new <TEMPLATE> [-l|--list]
dotnet new [-all|--show-all]
dotnet new [-h|--help]
```
---

## Description

The `dotnet new` command provides a convenient way to initialize a valid .NET Core project. 

The command calls the [template engine](https://github.com/dotnet/templating) to create the artifacts on disk based on the specified template and options.

## Arguments

`TEMPLATE`

The template to instantiate when the command is invoked. Each template might have specific options you can pass. For more information, see [Template options](#template-options).

The command contains a default list of templates. Use `dotnet new -all` to obtain a list of the available templates. The following table shows the templates that come pre-installed with the SDK. The default language for the template is shown inside the brackets.

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

`-all|--show-all`

Shows all templates for a specific type of project when running in the context of the `dotnet new` command alone. When running in the context of a specific template, such as `dotnet new web -all`, `-all` is interpreted as a force creation flag. This is required when the output directory already contains a project. This option is only available in .NET Core 1.x SDK.

`--force`

Forces content to be generated even if it would change existing files. This is required when the output directory already contains a project. This option is available starting with .NET Core SDK 2.0.

`-h|--help`

Prints out help for the command. It can be invoked for the `dotnet new` command itself or for any template, such as `dotnet new mvc --help`.

`-i|--install <PATH|NUGET_ID>`

Installs a source or template pack from the `PATH` or `NUGET_ID` provided. For information on creating custom templates, see [Custom templates for dotnet new](custom-templates.md). This option is available starting with .NET Core SDK 2.0.

`-l|--list`

Lists templates containing the specified name. If invoked for the `dotnet new` command, it lists the possible templates available for the given directory. For example if the directory already contains a project, it doesn't list all project templates.

`-lang|--language {C#|F#}`

The language of the template to create. The language accepted varies by the template (see defaults in the [arguments](#arguments) section). Not valid for some templates.

`-n|--name <OUTPUT_NAME>`

The name for the created output. If no name is specified, the name of the current directory is used.

`-o|--output <OUTPUT_DIRECTORY>`

Location to place the generated output. The default is the current directory.

`-u|--uninstall <PATH|NUGET_ID>`

Uninstalls a source or template pack at the `PATH` or `NUGET_ID` provided. This option is available starting with .NET Core SDK 2.0.

## Template options

Each project template may have additional options available. The core templates have the following options:

**console, xunit, mstest, web, webapi**

`-f|--framework` - Specifies the [framework](../../standard/frameworks.md) to target. Values: `netcoreapp1.0` or `netcoreapp1.1` (Default: `netcoreapp1.0`)

**mvc**

`-f|--framework` - Specifies the [framework](../../standard/frameworks.md) to target. Values: `netcoreapp1.0` or `netcoreapp1.1` (`Default: netcoreapp1.0`)

`-au|--auth` - The type of authentication to use. Values: `None` or `Individual` (Default: `None`)

`-uld|--use-local-db` - Specifies whether or not to use LocalDB instead of SQLite. Values: `true` or `false` (Default: `false`)

**classlib**

`-f|--framework` - Specifies the [framework](../../standard/frameworks.md) to target. Values: `netcoreapp1.0`, `netcoreapp1.1`, or `netstandard1.0` to `netstandard1.6` (Default: `netstandard1.4`)

## Examples

Create an F# console application project in the current directory:

`dotnet new console -lang f#` 
   
Create a new ASP.NET Core C# MVC application project in the current directory with no authentication targeting .NET Core 1.0:  

`dotnet new mvc -au None -f netcoreapp1.0`
 
Create a new xUnit application targeting .NET Core 2.0:

`dotnet new xunit --framework netcoreapp2.0`

List all templates available for MVC:

`dotnet new mvc -l`

## See also

[Custom templates for dotnet new](custom-templates.md)  
[Create a custom template for dotnet new](~/docs/core/tutorials/create-custom-template.md)  
[dotnet/dotnet-template-samples GitHub repo](https://github.com/dotnet/dotnet-template-samples)  
[Available templates for dotnet new](https://github.com/dotnet/templating/wiki/Available-templates-for-dotnet-new)
