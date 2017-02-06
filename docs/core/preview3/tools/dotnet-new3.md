---
title: dotnet-new command | .NET Core
description: The dotnet-new command creates new .NET Core projects in the current directory.
keywords: dotnet-new, CLI, CLI command, .NET Core
author: spboyer
ms.author: spboyer
ms.date: 02/13/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: e3bd87dc-fe67-4eba-a2c2-5b5a36de804f
---

#dotnet-new

## Name
dotnet-new3 -- Creates a new .NET Core project in the current directory

## Synopsis
`dotnet new3 [arguments] [options]`

## Description
The `dotnet new3` command provides a convenient way to initialize a valid .NET Core project and sample source code to try out the Command Line Interface (CLI) toolset. 

This command is invoked in the context of a directory. When invoked, the command will scaffold out the resources and files according to the template and options passed into the command. 

After this, the project is ready to be compiled and/or edited further. 

## Arguments
template - The template to instansiate when the command is ivoked.

The command contains a default list of templates; use `dotnet new --help`. 

## Options

`-l|--list`         

List templates containing the specified name.

`-lang|--language`  

Specifies the language of the template to create

`-n|--name`         

The name for the output being created. If no name is specified, the name of the current directory is used.

`-o|--output`       

Location to place the generated output.

`-h|--help`         

Displays help for this command.

`-all|--show-all`   

Shows all templates for a specific type of project.

`-h|--help`

Prints out help for the command.

## Template options
Each project template may have additional options available. The core templates, for example, have the following.

**console, xunit, mstest**

`-F|--Framework` - Specifies which framework to target. Values: netcoreapp1.0 or netcoreapp1.1 (Default: netcoreapp1.0)

**web, webapi**

`-f|--framework` - Specifies which framework to target. Values: netcoreapp1.0 or netcoreapp1.1 (Default: netcoreapp1.0)
 
**mvc**

`-f|--framework` - Specifies which framework to target. Values: netcoreapp1.0 or netcoreapp1.1 (Default: netcoreapp1.0)

`-au|--authentication` -  The type of authentication to use. Values: None or Individual (Default: None)

`-uld|--use-local-db` - Whether or not to use LocalDB instead of SQLite. Values: true or false (Default: false)


## Examples

Create a F# console application project in the current directory:

`dotnet new console --lang f#` 
   
Create a new ASP.NET Core C# MVC application project in the current directory with no authentication targeting .NET Core 1.0:  

`dotnet new mvc --auth None --framework netcoreapp1.0`
 
Create a new XUnit application targeting .NET Core 1.1

`dotnet new xunit --Framework netcoreapp1.1`
