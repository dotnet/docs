---
title: dotnet new command (.NET Core SDK 2.0 Preview 2) | Microsoft Docs
description: The 'dotnet new' command creates new .NET Core projects in the current directory.
keywords: dotnet new, CLI, CLI command, .NET Core
author: guardrex
ms.author: mairaw
ms.date: 06/11/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: fcc3ed2e-9265-4d50-b59e-dc2e5c190b34
---

# dotnet new (.NET Core SDK 2.0 Preview 2)

[!INCLUDE [core-preview-warning](~/includes/core-preview-warning.md)]

## Name

`dotnet new` - Creates a new project, configuration file, or solution based on the specified template.

## Synopsis

```
dotnet new <TEMPLATE> [--force] [-h|--help] [-i|--install] [-lang|--language] [-n|--name] [-o|--output] [--type] [-u|--uninstall] [Template options]
dotnet new <TEMPLATE> [-l|--list]
dotnet new [-all|--show-all]
dotnet new [-h|--help]
```

## Description

The `dotnet new` command initializes a .NET Core project. The command calls the [template engine](https://github.com/dotnet/templating) to create the artifacts on disk based on the specified template and options.

## Arguments

`TEMPLATE`

The template to use when the command is invoked. Each template might have specific options that you can provide to the command. For more information, see [Template options](#template-options).

The command contains a default list of templates. Use `dotnet new -all` to obtain a list of the available templates. The following table shows the templates that come pre-installed with the SDK. The default language for the template is shown in brackets.

| Template                                     | Name        | Languages    | Tags                |
| -------------------------------------------- | ----------- | ------------ | ------------------- |
| Console Application                          | console     | [C#], F#, VB | Common/Console      |
| Class library                                | classlib    | [C#], F#, VB | Common/Library      |
| Unit Test Project                            | mstest      | [C#], F#, VB | Test/MSTest         |
| xUnit Test Project                           | xunit       | [C#], F#, VB | Test/xUnit          |
| ASP.NET Core Empty                           | web         | [C#]         | Web/Empty           |
| ASP.NET Core Web App (Model-View-Controller) | mvc         | [C#], F#     | Web/MVC             |
| ASP.NET Core Web App (Razor Pages)           | razor       | [C#]         | Web/MVC/Razor Pages |
| ASP.NET Core with Angular                    | angular     | [C#]         | Web/MVC/SPA         |
| ASP.NET Core with React.js                   | react       | [C#]         | Web/MVC/SPA         |
| ASP.NET Core with React.js and Redux         | reactredux  | [C#]         | Web/MVC/SPA         |
| ASP.NET Core Web API                         | webapi      | [C#]         | Web/WebAPI          |
| Nuget Config                                 | nugetconfig |              | Config              |
| Web Config                                   | webconfig   |              | Config              |
| Solution File                                | sln         |              | Solution            |
| Razor Page                                   | page        |              | Web/ASP.NET         |
| MVC ViewImports                              | viewimports |              | Web/ASP.NET         |
| MVC ViewStart                                | viewstart   |              | Web/ASP.NET         |

## Options

`-all|--show-all`

Shows all templates for a specific type of project when running in the context of the `dotnet new` command alone. When running in the context of a specific template, such as `dotnet new web -all`, `-all` is interpreted as a force creation flag. This is required when the output directory already contains a project.

`--force`

Forces content generation even if changes existing files.

`-h|--help`

Shows help information. Invoke for the `dotnet new` command itself or for any template, such as `dotnet new mvc --help`, which shows template-specific options.

`-i|--install <PATH|NUGET_ID>`

Installs a source or template pack from the `PATH` or `NUGET_ID` provided. For information on creating custom templates, see [Create custom templates for dotnet new](custom-templates.md).

`-l|--list`

Lists templates containing the specified name. If invoked for the `dotnet new` command, it lists the possible templates available for the given directory. For example if the directory already contains a project, it doesn't list all project templates.

`-lang|--language <C#|F#|VB>`

The language of the template to create. The language accepted varies by template, and this option isn't valid for some templates. See the *Languages* column in the [Arguments](#arguments) section.

`-n|--name <OUTPUT_NAME>`

The name for the created output. If no name is specified, the name of the current directory is used.

`-o|--output <OUTPUT_DIRECTORY>`

Location to place the generated output. The default is the current directory.

`--type`

Filters templates based on available types. Predifined values are `project`, `item`, or `other`.

`-u|--uninstall <PATH|NUGET_ID>`

Uninstalls a source or template pack at the `PATH` or `NUGET_ID` provided.

## Template options

Each project template may have additional options. The core templates have the following options:

**console, xunit, mstest, web, webapi**

`-f|--framework <FRAMEWORK>`

Specifies the [framework](../../standard/frameworks.md) to target. If omitted, the framework defaults to `netcoreapp2.0`.

**mvc**

`-f|--framework <FRAMEWORK>`

Specifies the [framework](../../standard/frameworks.md) to target. If omitted, the framework defaults to `netcoreapp2.0`.

`-au|--auth <None|Individual>`

The type of authentication to use. If the option is omitted, the default is `None`.

`-uld|--use-local-db <true|false>`

Specifies whether or not to use LocalDB instead of SQLite. If this option is omitted, the default value is `false`.

**classlib**

`-f|--framework`

Specifies the [framework](../../standard/frameworks.md) to target. If this option is omitted, the default value is `netstandard1.4`.

## Examples

Create an F# console app project in the current directory:

`dotnet new console -lang F#` 
   
Create a new ASP.NET Core C# MVC app project in the current directory with no authentication targeting .NET Core 2.0:  

`dotnet new mvc -au None -f netcoreapp2.0`
 
Create a new xUnit app targeting .NET Core 1.1:

`dotnet new xunit --framework netcoreapp1.1`

List all templates available for MVC:

`dotnet new mvc -l`

## See also

[Create custom templates for dotnet new](custom-templates.md)   
[dotnet/dotnet-template-samples GitHub repo](https://github.com/dotnet/dotnet-template-samples)   
[Available templates for dotnet new](https://github.com/dotnet/templating/wiki/Available-templates-for-dotnet-new)
