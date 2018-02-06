---
title: Migrating from DNX to .NET Core CLI
description: Migrate from using DNX tooling to .NET Core CLI tooling.
keywords: .NET, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: c0d70120-78c8-4d26-bb3c-801f42fc2366
ms.workload: 
  - dotnetcore
---

# Migrating from DNX to .NET Core CLI (project.json)

## Overview
The RC1 release of .NET Core and ASP.NET Core 1.0 introduced DNX tooling. The RC2 release of .NET 
Core and ASP.NET Core 1.0 moved from DNX to the .NET Core CLI.

As a slight refresher, let's recap what DNX was about. DNX was a runtime and a toolset used to build .NET Core and, 
more specifically, ASP.NET Core 1.0 applications. It consisted of 3 main pieces:

1. DNVM - an install script for obtaining DNX
2. DNX (Dotnet Execution Runtime) - the runtime that executes your code
3. DNU (Dotnet Developer Utility) - tooling for managing dependencies, building and publishing your applications

With the introduction of the CLI, all of the above are now part of a single toolset. However, since DNX was available in RC1 
timeframe, you might have projects that were built using it that you would want to move off to the new CLI tooling. 

This migration guide will cover the essentials on how to migrate projects off of DNX and onto .NET Core CLI. If you are just 
starting a project on .NET Core from scratch, you can freely skip this document. 

## Main changes in the tooling
There are some general changes in the tooling that should be outlined first. 

### No more DNVM
DNVM, short for *DotNet Version Manager* was a bash/PowerShell script used to install a DNX on your machine. It helped
users get the DNX they need from the feed they specified (or default ones) as well as mark a certain DNX "active", which 
would put it on the $PATH for the given session. This would allow you to use the various tools.

DNVM was discontinued because its feature set was made redundant by changes coming in the .NET Core CLI tools.

The CLI tools come packaged in two main ways:

1. Native installers for a given platform
2. Install script for other situations (like CI servers)

Given this, the DNVM install features are not needed. But what about the runtime selection features? 

You reference a runtime in your `project.json` by adding a package of a certain version to your dependencies. With this change, 
your application will be able to use the new runtime bits. Getting these bits to your machine is the same as with the CLI: 
you install the runtime via one of the native installers it supports or via its install script. 

### Different commands
If you were using DNX, you used some commands from one of its three parts (DNX, DNU or DNVM). With the CLI, some of these
commands change, some are not available and some are the same but have slightly different semantics. 

The table below shows the mapping between the DNX/DNU commands and their CLI counterparts.


| DNX command                    	| CLI command    	| Description                                                                                                     	|
|--------------------------------	|----------------	|-----------------------------------------------------------------------------------------------------------------	|
| dnx run                        	| dotnet run     	| Run code from source.                                                                                           	|
| dnu build                      	| dotnet build   	| Build an IL binary of your code.                                                                                	|
| dnu pack                       	| dotnet pack    	| Package up a NuGet package of your code.                                                                        	|
| dnx \[command] (for example, "dnx web") 	| N/A\*          	| In DNX world, run a command as defined in the project.json.                                                     	|
| dnu install                    	| N/A\*          	| In the DNX world, install a package as a dependency.                                                            	|
| dnu restore                    	| dotnet restore 	| Restore dependencies specified in your project.json. ([see note](#dotnet-restore-note))                                                            	|
| dnu publish                    	| dotnet publish 	| Publish your application for deployment in one of the three forms (portable, portable with native and standalone). 	|
| dnu wrap                       	| N/A\*          	| In DNX world, wrap a project.json in csproj.                                                                    	|
| dnu commands                   	| N/A\*          	| In DNX world, manage the globally installed commands.                                                           	|

(\*) - these features are not supported in the CLI by design. 

## DNX features that are not supported
As the table above shows, there are features from the DNX world that we decided not to support in the CLI, at least for 
the time being. This section will go through the most important ones and outline the rationale behind not supporting 
them as well as workarounds if you do need them.

### Global commands
DNU came with a concept called "global commands". These were, essentially, console applications packaged up as NuGet 
packages with a shell script that would invoke the DNX you specified to run the application. 

The CLI does not support this concept. It does, however, support the concept of adding per-project commands that can be 
invoked using the familiar `dotnet <command>` syntax.

### Installing dependencies
As of v1, the .NET Core CLI tools don't have an `install` command for installing dependencies. In order to install a 
package from NuGet, you would need to add it as a dependency to your `project.json` file and then run `dotnet restore` ([see note](#dotnet-restore-note)). 

### Running your code
There are two main ways to run your code. One is from source, with `dotnet run`. Unlike `dnx run`, this will not do any 
in-memory compilation. It will actually invoke `dotnet build` to build your code and then run the built binary. 

Another way is using the `dotnet` itself to run your code. This is done by providing a path to your assembly:
`dotnet path/to/an/assembly.dll`. 

## Migrating your DNX project to .NET Core CLI
In addition to using new commands when working with your code, there are three major things left in migrating from DNX:

1. Migrate the `global.json` file if you have it to be able to use CLI.
2. Migrating the project file (`project.json`) itself to the CLI tooling.
3. Migrating off of any DNX APIs to their BCL counterparts. 

### Changing the global.json file
The `global.json` file acts like a solution file for both the RC1 and RC2 (or later) projects. In order for the CLI tools (as well 
as Visual Studio) to differentiate between RC1 and later versions, they use the `"sdk": { "version" }` property to make the distinction
which project is RC1 or later. If `global.json` doesn't have this node at all, it is assumed to be the latest. 

In order to update the `global.json` file, either remove the property or set it to the exact version of the 
tools that you wish to use, in this case **1.0.0-preview2-003121**:

```json
{
    "sdk": {
        "version": "1.0.0-preview2-003121"
    }
}
```

### Migrating the project file
The CLI and DNX both use the same basic project system based on `project.json` file. The syntax and the semantics of the 
project file are pretty much the same, with small differences based on the scenarios. There are also some changes to 
the schema which you can see in the [schema file](http://json.schemastore.org/project).

If you are building a console application, you need to add the following snippet to your project file:

```json
"buildOptions": {
    "emitEntryPoint": true
}
```

This instructs `dotnet build` to emit an entry point for your application, effectively making your code runnable. If 
you are building a class library, simply omit the above section. Of course, once you add the above snippet to your 
`project.json` file, you need to add a static entry point. With the move off DNX, the DI services it provided are no 
longer available and thus this needs to be a basic .NET entry point: `static void Main()`.

If you have a "commands" section in your `project.json`, you can remove it. Some of the commands that used to exist as 
DNU commands, such as Entity Framework CLI commands, are being ported to be 
per-project extensions to the CLI. If you built your own commands that you are using in your projects, you need to 
replace them with CLI extensions. In this case, the `commands` node in `project.json` needs to be replaced by the 
`tools` node and it needs to list the tools dependencies. 

After these things are done, you need to decide which type of portability you wish for you app. With .NET Core, we have 
invested into providing a spectrum of portability options that you can choose from. For instance, you may want to have 
a fully *portable* application or you may want to have a *self-contained* application. The portable application option is more 
like .NET Framework applications work: it needs a shared component to execute it on the target machine 
(.NET Core). The self-contained application doesn't require .NET Core to be installed on the target, but you have to 
produce one application for each OS you wish to support. These portability types and more are discussed in the
 [application portability type](../deploying/index.md) document. 

Once you make a call on what type of portability you want, you need to change your targeted framework(s). If you were 
writing applications for .NET Core, you were most likely using `dnxcore50` as  your targeted framework. With the CLI 
and the changes that the new [.NET Standard](../../standard/net-standard.md) 
brought, the framework needs to be one of the following:

1. `netcoreapp1.0` - if you are writing applications on .NET Core (including ASP.NET Core applications)
2. `netstandard1.6` - if you are writing class libraries for .NET Core

If you are using other `dnx` targets, like `dnx451` you will need to change those as well. `dnx451` should be changed to `net451`. 
Please refer to the [.NET Standard](../../standard/net-standard.md) topic 
for more information. 

Your `project.json` is now mostly ready. You need to go through your dependencies list and update the dependencies to 
their newer versions, especially if you are using ASP.NET Core dependencies. If you were using separate packages for BCL APIs, 
you can use the runtime package as explained in the [application portability type](../deploying/index.md) document. 

Once you are ready, you can try restoring with `dotnet restore` ([see note](#dotnet-restore-note)). Depending on the version of your dependencies, you may encounter errors if NuGet cannot resolve the dependencies for one of the 
targeted frameworks above. This is a "point-in-time" problem; as time progresses, more and more packages will include 
support for these frameworks. For now, if you run into this, you can use the `imports` statement within the `framework` 
node to specify to NuGet that it can restore the packages targeting the framework within the "imports" statement. 
The restoring errors you get in this case should provide enough information to tell you which frameworks you need to 
import. If you are slightly lost or new to this, in general, specifying `dnxcore50` and `portable-net45+win8` in the 
`imports` statement should do the trick. The JSON snippet below shows how this looks like:

```json
    "frameworks": {
        "netcoreapp1.0": { 
            "imports": ["dnxcore50", "portable-net45+win8"]
        }
    }
```

Running `dotnet build` will show any eventual build errors, though there shouldn't be too many of them. After your code is 
building and running properly, you can test it out with the runner. Execute `dotnet <path-to-your-assembly>` and see it run.

<a name="dotnet-restore-note"></a>
[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]