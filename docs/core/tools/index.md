---
title: .NET Core Command-Line Interface (CLI) Tools | Microsoft Docs
description: An overview of what the Command-Line Interface (CLI) is and its main features
keywords: CLI, CLI tools, .NET, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 10/06/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 7c5eee9f-d873-4224-8f5f-ed83df329a59
---

# .NET Core command-line interface tools

The .NET Core command-line interface (CLI) is a new foundational cross-platform toolchain for developing 
.NET Core applications. It is "foundational" because it is the primary layer on which other, 
higher-level tools, such as Integrated Development Environments (IDEs), editors and 
build orchestrators can build on. 

It is also cross-platform by default and has the same surface area on each of the supported platforms. This means that
when you learn how to use the tooling, you can use it the same way from any of the supported platforms. 

## Installation
As with any tooling, the first thing is to get the tools to your machine. Depending on your scenario, you can either 
use the native installers to install the CLI or use the installation shell script.

The native installers are primarily meant for developer's machines. The CLI is distributed using each supported platform's 
native install mechanism, for instance DEB packages on Ubuntu or MSI bundles on Windows. These installers will install 
and set up the environment as needed for the user to use the CLI immediately after the install. However, they also 
require administrative privileges on the machine. You can view the installation instructions on the
[.NET Core getting started page](https://aka.ms/dotnetcoregs).

Install scripts, on the other hand, do not require administrative privileges. However, they will also not install any 
prerequisites on the machine; you need to install all of the prerequisites manually. The scripts are meant mostly for 
setting up build servers or when you wish to install the tools without administrative privileges (do note the prerequisites 
caveat above). You can find more information on the [install script reference topic](dotnet-install-script.md). If you are 
interested in how to set up CLI on your continuous integration (CI) build server you can take a look at the 
[CLI with CI servers](using-ci-with-cli.md) topic. 

By default, the CLI will install in a side-by-side (SxS) manner. This means that multiple versions of the CLI tools 
can coexist at any given time on a single machine. How the correct version gets used is explained in more detail in 
the [driver](#driver) section. 

### What commands come in the box?
The following commands are installed by default:

* [new](dotnet-new.md)
* [migrate](dotnet-migrate.md)
* [restore](dotnet-restore.md)
* [run](dotnet-run.md)
* [build](dotnet-build.md)
* [test](dotnet-test.md)
* [publish](dotnet-publish.md)
* [pack](dotnet-pack.md)

There is also a way to import more commands on a per-project basis as well as to add your own commands. This is 
explained in greater detail in the [extensibility section](#extensibility). 

## Working with the CLI

Before we go into any more details, let's see how working with the CLI looks like from a 10,000-foot view. 
The following example utilizes several commands from the CLI standard install to initialize a new simple console application, 
restore the dependencies, build the application and then run it. 

```console
dotnet new
dotnet restore
dotnet build --output /stuff
dotnet /stuff/new.dll
```

As you can see in the previous example, there is a pattern in the way you use the CLI tools. Within that pattern, we can 
identify three main pieces of each command:

1. [The driver ("dotnet")](#driver)
2. [The command, or "verb"](#the-verb)
3. [Command arguments](#the-arguments)

### Driver
The driver is named [dotnet](dotnet.md). It is the first part of what you invoke. The driver has two responsibilities:

1. Running portable apps
2. Executing the verb

What it does depends on what is specified on the command line. In the first case, you would 
specify a portable app DLL that `dotnet` would run similar to this: `dotnet /path/to/your.dll`. 

In the second case, the driver attempts to invoke the specified command. This starts the CLI command execution 
process. First, the driver determines the version of the tooling that you want. You can specify the version in the 
[global.json](global-json.md) file using the `version` property. If that is not available, the driver finds the latest version
of the tools that is installed on disk and uses that version. Once the version is determined, it executes the 
command. 

### The "verb"
The verb is simply a command that performs an action. `dotnet build` builds your code. `dotnet publish` publishes 
your code. The verb is implemented as a console application that is named per convention: `dotnet-{verb}`. All of the 
logic is implemented in the console application that represents the verb. 

### The arguments
The arguments that you pass on the command-line are the arguments to the actual verb/command being invoked. 
For example, when you type `dotnet publish --output publishedapp`, the `--output` argument is passed to the 
`publish` command. 

## Types of application portability
CLI enables applications to be portable in two main ways:

1. Completely portable applications that can run anywhere .NET Core is installed
2. Self-contained deployments

You can learn more about both of these in the [.NET Core application deployment](../deploying/index.md) topic. 

## Migration from project.json
If you used Preview 2 tooling and project.json projects, you can consult the [dotnet migrate](dotnet-migrate.md) command docs
to get acquainted with the command and how to migrate your project. 

> [!NOTE]
> The `dotnet migrate` command currently does not migrate pre-preview 2 project.json files. 

## Extensibility
Of course, not every tool that you could use in your workflow will be part of the core CLI tools. However, .NET Core 
CLI has an extensibility model that allows you to specify additional tools for your projects. You can find out more 
in the [.NET Core CLI extensibility model](extensibility.md) topic.

## Summary
This was a short overview of the most important features of the CLI. You can find out more by using the reference and 
conceptual topics on this site. There are also other resources you can use:
* [dotnet/CLI](https://github.com/dotnet/cli/) GitHub repo
* [Getting started instructions](https://aka.ms/dotnetcoregs/)
