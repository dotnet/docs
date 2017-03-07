---
title: Getting started with .NET Core on macOS
description: Getting started with .NET Core on macOS, using Visual Studio Code
keywords: .NET, .NET Core
author: bleroy
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 8ad82148-dac8-4b31-9128-b0e9610f4d9b
---

# Getting started with .NET Core on macOS, using Visual Studio Code

> [!WARNING]
> This topic hasn't been updated to the latest version of the tooling yet.

This document provides a tour of the steps and workflow to create a .NET
Core Solution using [Visual Studio Code](http://code.visualstudio.com).
You'll learn how to create projects, create unit tests, use the debugging
tools, and incorporate third-party libraries via [NuGet](http://nuget.org).

This article uses Visual Studio Code on Mac OS. Where there are differences,
it points out the differences for the Windows platform.

## Prerequisites

Before starting, you'll need to install the [.NET Core SDK](https://www.microsoft.com/net/core),
currently in a preview release. The .NET Core SDK includes the latest release
of the .NET Core framework and runtime.

You'll also need to install [Visual Studio Code](http://code.visualstudio.com).
During the course of this article, you'll also install extensions
that will improve the .NET Core development experience.

You can find the links to all of these at the [.NET home page](http://dot.net).

## Getting Started

The source for this tutorial is available on
[GitHub](https://github.com/dotnet/docs/tree/master/samples/core/getting-started/golden).

Start Visual Studio Code. Press Ctrl + '\`' (the back-quote character) to open
an embedded terminal in VS Code. (Alternatively, you can use a separate
terminal window, if you prefer).

By the time we're done, you'll create three projects: a library project,
tests for that library project, and a console application that makes
use of the library. You'll follow a standard folder structure for
the three projects. Following this standard folder structure
means that the .NET Core SDK tools understand the relationship between
your production code projects and your test code projects. That makes
your development experience more productive.

Let's start by creating those folders. In the terminal, create a 'golden'
directory. Under that directory create `src` and `test`
directories. Under `src` create `app` and `library` directories. In `test`
create a `test-library` directory. You can do this either using the terminal
in VS code, or by clicking on the parent folder in VS Code and selecting the
"New Folder" icon.

In VS Code, open the 'golden' directory. This directory is the root of your solution.

Next, create a `global.json` file in the root directory for your solution.
The contents of `global.json` are:

```json
{
    "projects": [
        "src",
        "test"
    ]
}
```

At this point, your directory tree should look like this:


```
/golden
|__global.json
|__/src
   |__/app
   |__/library
|__/test
   |__/test-library
```

### Writing the library

Your next task is to create the library. In the terminal window
(either the embedded terminal in VS code, or another terminal),
cd to `golden/src/library` and type the command `dotnet new -t lib`.
This creates a library project, with two files: `project.json` and
`Library.cs`.

`project.json` contains the following information:

```json
{
  "version": "1.0.0-*",
  "buildOptions": {
    "debugType": "portable"
  },
  "dependencies": {},
  "frameworks": {
    "netstandard1.6": {
      "dependencies": {
        "NETStandard.Library": "1.6.0"
      }
    }
  }
}
```


This library project will make use of JSON representation of objects, so you'll want to
add a reference to the `Newtonsoft.Json` NuGet package. In`project.json`
add the latest pre-release version of the package as a dependency:

```json
"dependencies": {
    "Newtonsoft.Json": "9.0.1-beta1"
},
```

After you've finished adding those dependencies, you need to install those
packages into workspace. Run the `dotnet restore` command to updates all dependencies,
and write a `project.lock.json` file in the project directory. This
file contains the full dependency tree of all the dependencies in your
project. You don't need to read this file, it's used by tools in the .NET
Core SDK.

Now, let's update the C# code. Let's create a `Thing` class that contains
one public method. This method will return the sum of two numbers,
but will do so by converting that number to a JSON string, and then
deserializing it. Rename the file `Library.cs` to `Thing.cs`. Then, replace
the existing code (for the template-generated Class1) with the following:

```csharp
using static Newtonsoft.Json.JsonConvert;

namespace Library
{
    public class Thing
    {
        public int Get(int left, int right) =>
            DeserializeObject<int>($"{left + right}");
    }
}
```

This makes use of a number of modern C# features, such as 
static usings, expression-bodied members, and interpolated strings,
that you can learn
about in the [Learn C#](../../csharp/index.md) section.

Now that you've updated the code, you can build the library using
`dotnet build`.

You now have a built `library.dll` file under `golden/src/library/bin/Debug/netstandard1.6`.

### Writing the test project

Let's build a test project for this library that you've built. Cd into the `test/test-library`
directory. Run `dotnet new -t xunittest` to create a new test project. 

You'll need to add a dependency node for the library you wrote in the steps
above. Open `project.json` and update the dependencies section to the following
(including the `library` node, which is the last node below):

```json
"dependencies": {
  "System.Runtime.Serialization.Primitives": "4.1.1",
  "xunit": "2.1.0",
  "dotnet-test-xunit": "1.0.0-rc2-192208-24",
  "library": {
    "target": "project"
  }
}
```

The `library` node specifies that this dependency should resolve to a project
in the current workspace. Without explicitly specifying this, it's possible
that the test project would build against a NuGet package of the same name.

Now that the dependencies have been properly configured, let's create
the tests for your library. Open `Tests.cs` and
replace its contents with the following code:

```csharp
using Library;
using Xunit;

namespace TestApp
{
    public class LibraryTests
    {
        [Fact]
        public void TestThing() {
            Assert.Equal(42, new Thing().Get(19, 23));
        }
    }
}
```

Now, run `dotnet restore`, `dotnet build` and `dotnet test`.
The xUnit console test runner will run the one test, and report
that it is passing. 

### Writing the console app

In your terminal, cd to the `golden/src/app` directory. Run `dotnet new`
to create a new console application.

Your console application depends on the library you built and tested
in the previous steps. You need to indicate that by editing `project.json`
to add this dependency.  In the `dependencies` node, add the `library`
node as follows:

```json
"dependencies": {
  "library": {
    "target": "project"
  }
}
```

The `project` node is important here, as it was in the test library. It
indicates that this is a project in the current solution, and not a
NuGet package.

Run `dotnet restore` to restore all dependencies. Open `program.cs`
and replace the contents of the `Main` method with this line:

```csharp
WriteLine($"The answer is {new Thing().Get(19, 23)}");
```

You'll need to add a couple `using` directives to the top of the file:

```csharp
using static System.Console;
using Library;
```

Then, run `dotnet build`. That creates the assemblies, and you
can type `dotnet run` to run the executable.

### Debugging your application

You can debug your code in VS Code using the C# extension.
You install this extension by pressing `F1` to open the VS Code
palette. Type `ext install` to see the list of extensions. Select the C#
extension. (More details are available on the [Visual Studio
Code C# Extension documentation](https://github.com/OmniSharp/omnisharp-vscode/blob/master/debugger.md)
page.)

After you install the extension, VS Code will ask that you restart the application
to load the new extension. Once the extension is installed, you can open the
debugger tab (see figure).

![VS Code Debugger](./media/using-on-macos/vscodedebugger.png)


When you start the debugger, VS Code will instruct you to configure
the debugger. When you do, it creates a `.vscode` directory
with two files: `tasks.json` and `launch.json`. These two files control the debugger
configuration. In most projects, this directory is not included in source control.
It is included in the sample associated with this walk through so you can see
the edits you need to make.

Your solution contains multiple projects, so you'll want to modify each of these files
to perform the correct commands. First, open `tasks.json`. The default build task
runs `dotnet build` in the workspace source directory. Instead, you want to run it in
the `src/app` directory. You need to add a `options` node to set the current
working directory to that:

```json
"options": {
    "cwd": "${workspaceRoot}/src/app"
}
```

Next, you'll need to open `launch.json` and update the program path. You'll see a
node under "configurations" that describes the program. You'll see:

```json
"program": "${workspaceRoot}/bin/Debug/<target-framework>/<project-name.dll>",
```

You'll change this to:

```json
"program": "${workspaceRoot}/src/app/bin/Debug/netcoreapp1.0/app.dll",
```

If you are running on Windows, you'll need to update the Application's `project.json` 
(in the `src/app` directory) to
generate portable PDB files (this happens by default on Mac OSX and Linux).
Add the `debugType` node inside `buildOptions`. You'll need to add the `debugType` node
in `project.json` for both the `src/app` and `src/library` folders.

```json
  "buildOptions": {
    "debugType": "portable"
  },
```

Set a breakpoint at the `WriteLine` statement in `Main`. You do this
by pressing the `F9` key, or by clicking the mouse in the left margin
on the line you want the breakpoint. 
Open the debugger by pressing the debug
icon on the left of the VS Code screen (see figure). Then,
press the Play button to start the application under the debugger.

You should hit the breakpoint. Step into the `Get` method and make sure that you
have passed in the correct arguments. Make sure that the answer is actually 42.
