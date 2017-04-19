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
ms.assetid: ef8053b9-3864-46db-af65-ecde561effb1
---

Getting started with .NET Core Preview 3 tools
----------------------------------------------

This document will cover how to get started with the Preview 3 .NET Core tools. This version of the tooling has significant changes compared to the previous versions, mostly because of the move to [MSBuild](https://github.com/Microsoft/msbuild) as the build system and to csproj as the project file format. The Preview 3 tooling is the first release that completely removes support for project.json projects. 

## Installation
There are two main ways to get the Preview 3 tools:

1. Global installation
2. Local installation 

Our reccomendation, given the major change that happened, is to install Preview 3 bits locally using the process outlined in this section below. Installing globally will mean that the CLI will use the Preview 3 bits for all solutions that don't have an explicit version of the tools set using `global.json` file, as explained in the [section below](#switching-between-versions-using-global.json). 

In both cases, you can access the bits on our [Preview 3 download page](https://github.com/dotnet/core/blob/master/release-notes/preview3-download.md). 

### Global Installation
Global install is done via one of the native installers for the operating system you want, for example using the PKG on macOS or the MSI installer on Windows. Simply download the installer, run it and install. 

### Local Installation
Local installation is done using the zip/tarball files. These files can be downloaded and uncompressed to any location on disk. This way, the global tools are not impacted. The downside of this approach is that you will have to invoke the tools using a full path to the installation location. 

You can use aliases, however, to help you with this. Let's say that you've unpacked the Preview 3 tooling locally in the following locations:

* On Windows to **%HOME%\dotnetp3**
* On macOS/Linux to **$HOME/dotnetp3**

You can create an alias in PowerShell using the following command:

    new-alias dotnetp3 $env:HOME\dotnetp3\dotnet.exe

You can create an alias in bash/zsh using the following command:

    alias dotnetp3=$HOME/dotnetp3/dotnet

After this, you will be able to use `dotnetp3` as the command to invoke the Preview 3 tools. For example, invoking a build command would become `dotnetp3 build`. 

### Switching between versions using global.json
If you do install the Preview 3 tools globally, you need to make sure that you can still use Preview 2 tools on those projects that need it. You do this by using the `global.json` file and setting the `sdk` property to Preview 2 version. 

Here is a sample of an `global.json` file that sets the version to the latest Preview 2 version:

```json
{
    "sdk": {
        "version": "1.0.0-preview2-003131"
    }
}
```
> [!NOTE]
> Please note that you have to have the version of the CLI you are referncing installed. If not, the CLI will default to using the latest one you have on your machine. 

## Migrating the project
Once you have the tools installed you can migrate your project. To do this, you can use the [`dotnet migrate`](dotnet-migrate.md) command. By default, the command will migrate the given project and any project-to-project references. The project.json file will be moved into the `backup` folder that will be created in the current working directory. 

Currently, the migrate command supports only valid .NET Core 1.0 RTM project.json files. We plan to add support for pre-1.0 project.json files in the future. In the meantime, you can get `dotnet migrate` to work by simply updating your project.json to the .NET Core 1.0 RTM format. 

## Starting a new project
Of course, if you do not wish to migrate an existing project, you can start a new one. The familiar `dotnet new` command is still here in Preview 3, and its templates have been updated to produce valid csproj projects. All of the types are still available (web, lib, console and xunittest). 

## Running `dotnet restore`
Regardless of how you get started, either via migration of an existing project or starting a new one, please be sure to run `dotnet restore` before you run any other command. `dotnet restore` will bring in the targets that comprise the MSBuild-based tooling. Without those targets, you will get errors or incorrect behavior, depending on what command you use. 

## Further steps
From this point on, you can either get familiar with [csproj changes](csproj.md) that came about as the product of this work, learn how to [work with dependencies](dependencies.md) in Preview 3 tooling or get more information on the [layering of the tools](layering.md) that has changed with Preview 3.
