---
title: dotnet-new command | .NET Core
description: The dotnet-new command creates new .NET Core projects in the current directory.
keywords: dotnet-new, CLI, CLI command, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 10/12/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 263c3d05-3a47-46a6-8023-3ca16b488410
---

#dotnet-new

## Name
`dotnet-new` - Creates a new .NET Core project in the current directory.

## Synopsis
`dotnet new [--help] [--type] [--lang]`

## Description
The `dotnet new` command provides a convenient way to initialize a valid .NET Core project and sample source code to try out the Command Line Interface (CLI) toolset. 

This command is invoked in the context of a directory. When invoked, the command will result in two main artifacts being dropped to the current directory: 

1. A `Program.cs` (or `Program.fs`) file that contains a sample "Hello World" program.
2. A valid `project.json` file.

After this, the project is ready to be compiled and/or edited further. 

## Options

`-h|--help`

Prints out a short help for the command.  

`-l|--lang <C#|F#>`

Language of the project. Defaults to `C#`. Other valid values are `csharp`, `fsharp`, `cs` and `fs`.

`-t|--type`

Type of the project. Valid values for C# are `console`, `web`, `lib` and `xunittest` and for F# only `console` is valid. 

## Examples

Create a C# console application project in the current directory:

`dotnet new` or `dotnet new --lang c#` 
   
Create an F# console application project in the current directory:

`dotnet new --lang f#`
  
Create a new ASP.NET Core C# application project in the current directory:

`dotnet new -t web`