---
title: Getting started with .NET Core Preview 3 tooling
description: Preview 3 brings about changes to projects 
keywords: CLI, extensibility, custom commands, .NET Core
author: blackdwarf
manager: wpickett
ms.date: 11/12/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: ac8ff967-3649-4463-bd65-ebb0457bca28
---

What is new in .NET Core Tools Preview 3?
-----------------------------------------

This document will outline in high-level details what is new with the Preview 3 .NET Coore 
Tooling, also known as the "CLI". Where needed, it will point to other documents in this 
document set.

Use this document as an overview and a guide to check out what is new and as an 
index to the 

## Move to MSBuild and csproj
The main change in Prview 3 is the move from project.json to csproj as the project 
system and moving to MSBuild as the build engine for .NET Core. This is a result of an overall 
push that was announced [on the project.json future blog post](https://blogs.msdn.microsoft.com/dotnet/2016/05/23/changes-to-project-json/). 

It is important to note that Preview 3 tooling does not contain **any support** for 
project.json projects. You will not be able to build or run any project.json project with just 
Preview 3 tools. You still need to have Preview 2 tools installed in order to work with 
project.json projects. 

## `dotnet migrate` command
With the move to MSBuild and csproj, we have included a [dotnet migrate](dotnet-migrate.md) 
command that will allow you to migrate a valid .NET Core 1.0.0 project to csproj. 

## Advanced commands
Since this release [changes the layering](layering.md) of the .NET Core Tools, we have 
added a new category of commands called "advanced commands". These commands allow access to 
the underlying engines (for example to MSBuild) and most of its functionalities. They can 
also have different invocation patters and option formats. 

The current advanced commands in Preview 3 are:

* [dotnet msbuild](dotnet-msbuild.md)
* [dotnet nuget](dotnet-nuget-locals.md)
* dotnet vstest

## More resources

* [Changes to .NET Core tools layering](layering.md)
* [Getting started with Preview 3 tools](getting-started.md)
* [Additions to csproj format](csproj.md)
* [global.json reference](global.json.md)

