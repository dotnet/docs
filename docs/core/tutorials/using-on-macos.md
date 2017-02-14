---
title: Getting started with .NET Core on macOS
description: Getting started with .NET Core on macOS, using Visual Studio Code
keywords: .NET, .NET Core
author: bleroy
ms.author: mairaw
ms.date: 02/08/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 8ad82148-dac8-4b31-9128-b0e9610f4d9b
---

# Getting started with .NET Core on macOS, using Visual Studio Code

This document provides a tour of the steps and workflow to create a .NET
Core Solution using [Visual Studio Code](http://code.visualstudio.com).
You'll learn how to create projects, create unit tests, use the debugging
tools, and incorporate third-party libraries via [NuGet](http://nuget.org).

This article uses Visual Studio Code on Mac OS. Where there are differences,
it points out the differences for the Windows platform.

## Prerequisites

Before starting, you'll need to install the [.NET Core SDK](https://www.microsoft.com/net/core),
currently in RC4 pre-release. The .NET Core SDK includes the latest release
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
use of the library. 

Let's start by creating those folders. In the terminal, create a 'golden'
directory. In VS Code, open the *golden* directory. This directory is the root of your solution. Run the `dotnet new` command to create a new solution:

```
dotnet new sln
```

This command creates a *golden.sln* file for the entire solution.

Your next task is to create the library. In the terminal window
(either the embedded terminal in VS code, or another terminal),
cd to *golden/* and type the command:

```
dotnet new classlib library
```

This creates a library project, with two files: *library.csproj* and
*Class1.cs* in the *library* directory. You want that library project
included in your solution. Run the `dotnet sln` command to add the newly
created `library.csproj` project to the solution:

```
dotnet sln add library/library.csproj
```

Let's examine the project that you've created. The *library.csproj* file 
contains the following information:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard1.4</TargetFramework>
  </PropertyGroup>

</Project>
```

This library project will make use of JSON representation of objects, so you'll want to
add a reference to the `Newtonsoft.Json` NuGet package. The `dotnet add` command
adds new items to a project. To add a reference to a NuGet package, you use the 
`package` command and specify the name of the package. 

```
dotnet add library package Newtonsoft.Json
```

This adds `Newtonsoft.Json` and its dependencies to the Library
project. Alternatively, you could manually edit the *library.csproj*
file and add the following node:

```xml
<ItemGroup>
  <PackageReference Include="Newtonsoft.Json">
    <Version>9.0.1</Version>
  </PackageReference>
</ItemGroup>
```

After you've finished adding those dependencies, you need to install those
packages into workspace. Run the `dotnet restore` command to updates all dependencies,
and write a *obj/project.assets.json* file under the project directory. This
file contains the full dependency tree of all the dependencies in your
project. You don't need to read this file, it's used by tools in the .NET
Core SDK.

Now, let's update the C# code. Let's create a `Thing` class that contains
one public method. This method will return the sum of two numbers,
but will do so by converting that number to a JSON string, and then
deserializing it. Rename the file *Class1.cs* to *Thing.cs*. Then, replace
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

You now have a built *library.dll* file under *golden/library/bin/Debug/netstandard1.4*.

### Writing the test project

Let's build a test project for this library that you've build. Change to the *golden*
directory. Run `dotnet new xunit -o test-library` to create a new test project. 
You'll want to add this project to the solution as well by running
`dotnet sln add test-library/test-library.csproj`.

You'll need to add a dependency node for the library you wrote in the steps
above. The `dotnet add reference` command does that:

```
dotnet add test-library/test-library.csproj reference library/library.csproj
```

Or, you can manually edit the test-library.csproj file and add the
following node:

```xml
<ItemGroup>
  <ProjectReference Include="..\library\library.csproj" />
</ItemGroup>
```

The `library` node specifies that this dependency should resolve to a project
in the current workspace. Without explicitly specifying this, it's possible
that the test project would build against a NuGet package of the same name.

Now that the dependencies have been properly configured, let's create
the tests for your library. Open `UnitTest1.cs` and
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

Now, run `dotnet restore` and `dotnet build`. These commands will
recursively find all projects to restore dependencies and build them.
Finally, run `dotnet test test-library/test-library.csproj` to
run the tests.
The xUnit console test runner will run the one test, and report
that it is passing. 

### Writing the console app

In your terminal run `dotnet new console -o app`
to create a new console application. This proejct is also
part of the solution, so run `dotnet sln add app/app.csproj`
to add the project to the solution.

Your console application depends on the library you built and tested
in the previous steps. You need to indicate that by running `dotnet add reference`
again:

```
dotnet add app/app.csproj reference library/library.csproj
```

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
can type `dotnet run -p app/app.csproj` to run the executable.
The `-p` argument to `dotnet run` specifies the project for the
main application.

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

Set a breakpoint at the `WriteLine` statement in `Main`. You do this
by pressing the `F9` key, or by clicking the mouse in the left margin
on the line you want the breakpoint. 
Open the debugger by pressing the debug
icon on the left of the VS Code screen (see figure). Then,
press the Play button to start the application under the debugger.

You should hit the breakpoint. Step into the `Get` method and make sure that you
have passed in the correct arguments. Make sure that the answer is actually 42.
