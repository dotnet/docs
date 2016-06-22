---
title: Development using Visual Studio Code
description: Development using Visual Studio Code
keywords: .NET, .NET Core
author: BillWagner
manager: wpickett
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.technology: .net-core-technologies
ms.devlang: dotnet
ms.assetid: 8ad82148-dac8-4b31-9128-b0e9610f4d9b
---

# Development using Visual Studio Code

by [Bertrand Le Roy](https://github.com/bleroy),  [Phillip Carter](https://github.com/cartermp),
[Bill Wagner](https://github.com/billwagner)

Contributions by [Toni Solarin-Sodara](https://github.com/tsolarin)

This document provides a tour of the steps and workflow to create a .NET
Core Solution using [Visual Studio Code](http://code.visualstudio.com).
You'll learn how to create projects, create unit tests, use the debugging
tools, and incorporate third-party libraries via [NuGet](http://nuget.org).

This article uses Visual Studio Code on Mac OS. Where there are differences,
it points out the differences for the Windows platform.

Prerequisites
-------------

Before starting, you'll need to install the [.NET Core SDK](https://www.microsoft.com/net/core),
currently in a preview release. The .NET Core SDK includes the latest release
of the .NET Core framework and runtime.

You'll also need to install [Visual Studio Code](http://code.visualstudio.com).
During the course of this article, you'll also install extensions
that will improve the .NET Core development experience.

You can find the links to all of these at the [.NET home page](http://dot.net).

Getting Started
---------------

The source for this tutorial is available on
[GitHub](https://github.com/dotnet/core-docs/tree/master/samples/getting-started/golden).

Start Visual Studio Code. Press Ctrl + '`' (the back-quote character) to open
an embedded terminal in VS Code. (Alternatively, you can use a separate
terminal window, if you prefer).

By the time we're done, you'll create three projects: a library project,
tests for that library project, and a console application that makes
use of the library. You'll follow a standard folder structure for
the three projects. Following this standard folder structure
means that the .NET Core SDK tools understand the relationship between
your production code projects and your test code projects. That makes
your development exerience more productive.

Let's start by creating those folders. In the terminal, create a 'golden'
directory. Under that directory create `src` and `test`
directories. Under `src` create `app` and `library` directories. In `test`
create a `test-library` directory. You can do this either using the terminal
in VS code, or by clicking on the parent folder in VS Code and selecting the
"New Folder" icon.

In VS Code, open the 'golden' directory. This directory is the root of your solution.

Next, create a `global.json` file in the root directory for your solution.
The contents of `global.json` are:

```js
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
/test
   |__/test-library
```

### Writing the library

Your next task is to create the library. In the terminal window
(either the embedded terminal in VS code, or another terminal),
cd to `golden/src/library` and type the command `dotnet new`.

The `dotnet new` command creates a new application project. Because
you want a library project, you're going to make a few changes to
the generated `project.json` file.

First, remove the `buildOptions` node:

```js
"buildOptions" {
    "emitEntryPoint": true
}
```

Next, you'll need to update the dependencies section to create
a library assembly, rather than an application. You'll remove the
`Microsoft.NETCore.App` node:

```js
"dependencies": {
    "Microsoft.NETCore.App": {
        "type": "platform",
        "version": "1.0.0-rc2-300702"
    }
}
```
And replace it with a reference to the .NET Standard library:

```js
"dependencies": {
    "NETStandard.Library": {
        "version": "1.5.0-rc2-24027"
    }
}
```

You'll also need to update the frameworks section to use 
.NET Standards instead of `netcoreapp1.0`:

```js
"frameworks": {
    "netcoreapp1.0" : {
        "imports": "dnxcore50"
    }
}
```

becomes:

```js
"frameworks" : {
    "netstandard1.5": {
        "imports": "dnxcore50"
}
```

This library will make use of JSON representation of objects, so you'll want to
add a reference to the `Newtonsoft.Json` NuGet package. In`project.json`
add the latest pre-release version of the package as a dependency:

```js
"dependencies": {
    "NETStandard.Library": {
        "version": "1.5.0-rc2-24027"
    },
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
but  will do so by converting that number to a JSON string, and then
deserializing it. Rename the file `Program.cs` to `Thing.cs`. Then, replace
the existing code (for the template-generated Hello World) with the following:

```cs
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
static usings, expression bodied members, and interpolated strings,
that you can learn
about in the [Learn C#](/languages/csharp/index.md) section.

Now that you've updated the code, you can build the library using
`dotnet build`.

You now have a built `library.dll` file under `golden/src/library/bin/Debug/netstandard1.5`.

### Writing the test project

Let's build a test project for this library that you've build. Cd into the `test/test-library`
directory. Run `dotnet new` to create a new project. 

For the test project, you do want a console application project. However, the entry point
for the test project is in the test runner NuGet package. That means you do have some
changes to make to the `project.json` file.

You need to remove the `buildOptions` node from `project.json` so that the build process
does not emit the startup code:

```js
"buildOptions" {
    "emitEntryPoint": true
}
```

Next, you'll need to add three dependency nodes. These are the xUnit test library
project, the .NET core xUnit Test Runner, and the library you wrote in the steps
above. Open `project.json` and update the dependencies section to the following:

```js
"dependencies": {
    "Microsoft.NETCore.App": {
        "type": "platform",
        "version": "1.0.0-rc2-3002702"
    },
    "xunit": "2.1.0",
    "dotnet-test-xunit": "1.0.0-rc2-build10025",
    "library": {
        "target": "project",
        "version": "1.0.0.*"
    }
}
```

The `library` node specifies that this dependency should resolve to a project
in the current workspace. Without explicitly specifying this, it's possible
that the test project would build against a NuGet package of the same name.

If you try to build at this point, you'll find that the test library does
not build. That's because the `xunit` NuGet package was built to work
against a Portable Class Library profile. You need to update the `project.json`
file to include the portable profiles in the frameworks section:

```js
"frameworks": {
    "netcoreapp1.0": {
        "imports": [
            "dnxcore50",
            "portable-net45+win8"
        ]
    }
}
```

Finally, you need to add a `testrunner` node to `project.json` that
tells the .NET SDK that you are using the xUnit test runner. Place this
node between the `version` and the `dependencies` nodes in your `project.json`
file.

```js
"testRunner": "xunit",
```

Now that the dependencies have been properly configured, let's create
the tests for your library. Rename `Program.cs` to `LibraryTest.cs` and
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
to add this dependency.  In the `dependencies` node, add the `Library`
node below the `Microsoft.NetCore.App` node as follows:

```js
"dependencies": {
    "Microsoft.NetCore.App": {
        "type": "platform",
        "version": "1.0.0-rc2-3002702"
    },
    "library": {
        "target": "project",
        "version": "1.0.0-*"
    }
}
```

The `project` node is important here, as it was in the test library. It
indicates that this is a project in the current solution, and not a
NuGet package.

Run `dotnet restore` to restore all dependencies. Open `program.cs`
and replace the contents of the `Main` method with this line:

```cs
WriteLine($"The answer is {new Thing().Get(19, 23))}");
```

You'll need to add a couple using directives to the top of the file:

```cs
using static System.Console;
using Library;
```

Then, run `dotnet build`. That creates the assemblies, and you
can type `dotnet run` to run the executable.

### Debugging your application

You can debug your code in VS Code using the C# extension.
You install this extension by pressing `F1` to open the VS Code
palette. Type `ext install` to see the list of extensions. Select the `C#`
extension. (More details are availble on the [Visual Studio
Code C# Extension documentation](https://github.com/OmniSharp/omnisharp-vscode/blob/master/debugger.md)
page.)

After you install the extension, VS Code will ask that you restart the application
to include the new extension. When you relaunch, VS Code will create a `.vscode` directory
with two files: `tasks.json` and `launch.json`. These two files control the debugger
configuration. In most projects, this directory is not included in source control.
It is included in the sample associated with this walk through so you can see
the edit you need to make.

Your solution contains multiple projects, so you'll want to modify each of these files
to perform the correct commands. First, open `tasks.json`. The default build task
runs `dotnet build` in the workspace source directory. Instead, you want to run it in
the `src/app` directory. You need to add a `options` node to set the current
working directory to that:

```js
"options": {
    "cwd": "${workspaceRoot}/src/app"
}
```

Next, you'll need to open `launch.json` and update the program path. You'll see a
node under "configurations" that describes the program. You'll see:

```js
"program": "${workspaceRoot}/bin/Debug/<target-framework>/<project-name.dll>",
```

You'll change this to:

```js
"program": "${workspaceRoot}/src/app/bin/Debug/netcoreapp1.0/app.dll",
```

If you are running on Windows, you'll need to update the Application's `project.json` 
(in the `src/app` directory) to
generate portable PDB files (this happens by default on Mac OSX and Linux).
Add the `debugType` node under `buildOptions`:

```js
"debugType": "portable",
```

Set a breakpoint at the `WriteLine` statement in `Main`. You do this
by pressing the `F9` key, or by clicking the mouse in the left margin
on the line you want the breakpoint. 
Open the debugger by pressing the debug
icon on the left of the VS Code screen (see figure). Then,
press the Play button to start the application under the debugger.

![VS Code Debugger](/docs/images/vscodedebugger.png)

You should hit the breakpoint. Step into the `Get` method and make sure that you
have passed in the correct arguments. Make sure that the answer is actually 42.
