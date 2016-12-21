---
title: .NET Core CLI extensibility model 
description: .NET Core CLI extensibility model 
keywords: CLI, extensibility, custom commands, .NET Core
author: blackdwarf
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 1bebd25a-120f-48d3-8c25-c89965afcbcd
---

# .NET Core CLI extensibility model 

## Overview
This document will cover the main ways how to extend the CLI tools and explain the scenarios that drive each of them. 
It will the outline how to consume the tools as well as provide short notes on how to build both types of tools. 

## How to extend CLI tools
The CLI tools can be extended in two main ways:

1. Via NuGet packages on a per-project basis
2. Via the system's PATH

The two extensibility mechanisms outlined above are not exclusive; you can use both or just one. Which one to pick 
depends largely on what is the goal you are trying to achieve with your extension.

## Per-project based extensibility
Per-project tools are [portable console applications](../deploying/index.md) that are distributed as NuGet packages. Tools are 
only available in the context of the project that references them and for which they are restored; invocation outside 
of the context of the project (for example, outside of the directory that contains the project) will fail as the command will 
not be able to be found.

These tools are perfect for build servers as well, since nothing outside of `project.json` is needed. The build process 
runs restore for the project it builds and tools will be available. Language projects, such as F#, are also in this 
category; after all, each project can only be written in one specific language. 

Finally, this extensibility model provides support for creation of tools that need access to the built output of the 
project. For instance, various Razor view tools in [ASP.NET](https://www.asp.net/) MVC applications fall into this 
category. 

### Consuming per-project tools
Consuming these tools requires you to add a `tools` node to your `project.json`. Inside the `tools` node, you reference
the package in which the tool resides. After running `dotnet restore`, the tool and its dependencies are restored. 

For tools that need to load the build output of the project for execution, there is usually another dependency which is 
listed under the regular dependencies in the project file. This means that tools that load project's code have two 
components: 

1. The "tools" main invoker
2. Any number of other tools that contain the logic to work with 

Why two things? Tools that need to load the build output of a project need to have unified dependency graph with the 
project they are working. By adding the dependency bit, we enable NuGet to resolve these dependencies as a unified 
graph. The invoker is there because it needs to reason about the location as well as the frameworks of the dependency 
tool. The invoker can accept all of the redirection arguments (`-c`, `-o`, `-b`) that the user specifies and finds the 
dependency tool; it can also implement any policies for cases where multiple dependency tools exist for multiple 
frameworks (that is, does it run all of them, just one, etc.) In general, logic can be shared between these two tools any way 
that is needed. 

Let's review an example of adding a simple tools-only tool to a simple project. Given an example command called 
`dotnet-api-search` that allows you to search through the NuGet packages for the specified 
API, here is a console application's `project.json` file that uses that tool:

```json
{
    "version": "1.0.0",
    "compilationOptions": {
        "emitEntryPoint": true
    },
    "dependencies": {
        "Microsoft.NETCore.App": {
            "type": "platform",
            "version": "1.0.0"
        }
    },
    "tools": {
        "dotnet-api-search": {
            "version": "1.0.0",
            "imports": ["dnxcore50"]
        }
    },
    "frameworks": {
        "netcoreapp1.0": {}
    }
}
```

The `tools` node is structured in a similar way as the `dependencies` node. It needs the package ID of the package 
containing the tool and its version at the very least. In the example above, we can see that there is another statement, 
the `imports` one. This influences the tool's restore process and specifies that the tool is also compatible, in 
addition to any targeted frameworks the tools has, with `dnxcore50` target. For more information you can 
consult the [project.json reference](project-json.md).

### Building tools
As mentioned, tools are just portable console applications. You would build one as you would build any console application. 
After you build it, you would use [`dotnet pack`](dotnet-pack.md) command to create a NuGet package (nupkg) that contains 
your code, information about its dependencies and so on. The package name can be whatever the author wants, but the 
application inside, the actual tool binary, has to conform to the convention of `dotnet-<command>` in order for `dotnet` 
to be able to invoke it. 

Since tools are portable applications, the user consuming the tool has to have the version of the .NET Core libraries 
that the tool was built against in order to run the tool. Any other dependency that the tool uses and that is not 
contained within the .NET Core libraries is restored and placed in the NuGet cache. The entire tool is, therefore, run 
using the assemblies from the .NET Core libraries as well as assemblies from the NuGet cache. 

These kind of tools have a dependency graph that is completely separate from the dependency graph of the project that 
uses them. The restore process will first restore the project's dependencies, and will then restore each of the tools and 
their dependencies. 

You can find richer examples and different combinations of this in the [.NET Core CLI repo](https://github.com/dotnet/cli/tree/rel/1.0.0-preview2/TestAssets/TestProjects). 
You can also see the [implementation of tools used](https://github.com/dotnet/cli/tree/rel/1.0.0-preview2/TestAssets/TestPackages) in the same repo. 

Building tools that load project's build outputs for execution is slightly different. As stated, for these kinds of 
tools there are two components:

1. A dispatcher tool that the user invokes
2. A framework-specific dependency that contains the logic on how to find the build outputs and what to do with it

A prime example of this are [Entity Framework (EF)](https://github.com/aspnet/EntityFramework) commands as well as the [`dotnet test`](dotnet-test.md) command. In both 
cases, there is a tool that is referenced in the `tools` node of the `project.json` and that is the main dispatcher. The 
user invokes this tool on the command line. The second piece of the puzzle is the dependency that is given in the 
project's main dependencies (either root ones or framework-specific ones). This package contains the actual logic of 
the tool. The package is a normal dependency, thus it will be restored as part of the restore process for the project. 

Unlike the previous kind of tools, these tool are actually part of the graph of the project that consumes them. This is 
because they need access to the project's code and potentially all of its dependencies. For instance, the EF tools need 
this because they need to scan the assemblies to find the code they need, such as migrations.  

Another reason why this two-pronged solution exists is to allow a cleaner invocation model. Most CLI commands that 
drop certain artifacts on disk (for example, `dotnet build`, `dotnet publish`) allow users to redirect the outputs to a different 
path using the `--output` argument or `--build-base-path` argument or `--configuration` argument. For EF tools, for 
example, to be able to find the build output of your project, you would have to provide the same arguments with the same 
values to *both* `dotnet` driver as well as the `ef` command. With the invocation model, the users pass any arguments to 
the dispatcher tool which can then use that to find the needed binary that contains the logic in the output directories. 

A good example of this approach can be found in the [.NET Core CLI repo](https://github.com/dotnet/cli):

* [Sample project.json file](https://github.com/dotnet/cli/blob/rel/1.0.0-preview2/TestAssets/DesktopTestProjects/AppWithDirectDependencyDesktopAndPortable/project.json)
* [Implementation of the dispatcher](https://github.com/dotnet/cli/tree/rel/1.0.0-preview2/TestAssets/TestPackages/dotnet-dependency-tool-invoker)
* [Implementation of the framework-specific dependency](https://github.com/dotnet/cli/tree/rel/1.0.0-preview2/TestAssets/TestPackages/dotnet-desktop-and-portable)


### PATH-based extensibility
PATH-based extensibility is usually used for development machines where you need a tool that conceptually covers more 
than a single project. The main drawback of this extensions mechanism is that it is tied to the machine where the 
tool exists. If you need it on another machine, you would have to deploy it.

This pattern of CLI toolset extensibility is very simple. As covered in the [.NET Core CLI overview](index.md), `dotnet` driver 
can run any command that is named after the `dotnet-<command>` convention. The default resolution logic will first 
probe several locations and will finally fall to the system PATH. If the requested command exists in the system PATH 
and is a binary that can be invoked, `dotnet` driver will invoke it. 

The binary can be pretty much anything that the operating system can execute. On Unix systems, this means anything that 
has the execute bit set via `chmod +x`. On Windows it means anything that Windows knows how to run. 

As an example, let's take a look at a very simple implementation of a `dotnet clean` command. We will use `bash` to 
implement this command. The command will simply delete the `bin/` and `obj/` directories in the current directory. If 
the `--lock` argument is passed to it, it will also delete `project.lock.json` file. The entirety of the command is 
given below. 

```bash
#!/bin/bash

# Delete the bin and obj dirs
rm -rf bin/ obj/

LOCK_FILE=$1
if [[ "$LOCK_FILE" = "--lock" ]]; then
    rm project.lock.json
fi


echo "Cleaning complete..."
```

On macOS, we can save this script as `dotnet-clean` and set its executable bit with `chmod +x dotnet-clean`. We can then 
create a symbolic link to it in `/usr/local/bin` using the command `ln -s dotnet-clean /usr/local/bin/`. This will make 
it possible to invoke the clean command using the `dotnet clean` syntax. You can test this by creating an app, running 
`dotnet build` on it and then running `dotnet clean`. 

## Conclusion
The .NET Core CLI tools allow two main extensibility points. The per-project tools are contained within the project's 
context, but they allow easy installation through restoration. PATH-based tools are good for general, cross-project 
tools that are usable on a single machine. 
