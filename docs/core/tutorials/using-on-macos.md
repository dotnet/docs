---
title: Getting started with .NET Core on macOS
description: This document provides the steps and workflow to create a .NET Core Solution using Visual Studio Code.
keywords: .NET, .NET Core, Mac, macOS, Visual Studio Code
author: bleroy
ms.author: mairaw
ms.date: 03/23/2017
ms.topic: get-started-article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 8ad82148-dac8-4b31-9128-b0e9610f4d9b
ms.workload: 
  - dotnetcore
---

# Getting started with .NET Core on macOS

This document provides the steps and workflow to create a .NET Core solution for macOS. Learn how to create projects, unit tests, use the debugging tools, and incorporate third-party libraries via [NuGet](https://www.nuget.org/).

> [!NOTE]
> This article uses [Visual Studio Code](http://code.visualstudio.com) on macOS.

## Prerequisites

Install the [.NET Core SDK](https://www.microsoft.com/net/core). The .NET Core SDK includes the latest release of the .NET Core framework and runtime.

Install [Visual Studio Code](http://code.visualstudio.com). During the course of this article, you also install Visual Studio Code extensions that improve the .NET Core development experience.

Install the Visual Studio Code C# extension by opening Visual Studio Code and pressing <kbd>F1</kbd> to open the Visual Studio Code palette. Type **ext install** to see the list of extensions. Select the C# extension. Restart Visual Studio Code to activate the extension. For more information, see the [Visual Studio Code C# Extension documentation](https://github.com/OmniSharp/omnisharp-vscode/blob/master/debugger.md).

## Getting started

In this tutorial, you create three projects: a library project, tests for that library project, and a console application that makes use of the library. You can [view or download the source](https://github.com/dotnet/samples/tree/master/core/getting-started/golden) for this topic at the dotnet/samples repository on GitHub. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples).

Start Visual Studio Code. Press <kbd>Ctrl</kbd>+<kbd>\`</kbd> (the backquote or backtick character) or select **View > Integrated Terminal** from the menu to open an embedded terminal in Visual Studio Code. You can still open an external shell with the Explorer **Open in Command Prompt** command (**Open in Terminal** on Mac or Linux) if you prefer to work outside of Visual Studio Code.

Begin by creating a solution file, which serves as a container for one or more .NET Core projects. In the terminal, create a *golden* folder and open the folder. This folder is the root of your solution. Run the [`dotnet new`](../tools/dotnet-new.md) command to create a new solution, *golden.sln*:

```console
dotnet new sln
```

From the *golden* folder, execute the following command to create a library project, which produces two files,*library.csproj* and *Class1.cs*, in the *library* folder:

```console
dotnet new classlib -o library
```

Execute the [`dotnet sln`](../tools/dotnet-sln.md) command to add the newly created *library.csproj* project to the solution:

```console
dotnet sln add library/library.csproj
```

The *library.csproj* file contains the following information:

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <TargetFramework>netstandard1.4</TargetFramework>
  </PropertyGroup>

</Project>
```

Our library methods serialize and deserialize objects in JSON format. To support JSON serialization and deserialization, add a reference to the `Newtonsoft.Json` NuGet package. The `dotnet add` command adds new items to a project. To add a reference to a NuGet package, use the [`dotnet add package`](../tools/dotnet-add-package.md) command and specify the name of the package:

```console
dotnet add library package Newtonsoft.Json
```

This adds `Newtonsoft.Json` and its dependencies to the library project. Alternatively, manually edit the *library.csproj* file and add the following node:

```xml
<ItemGroup>
  <PackageReference Include="Newtonsoft.Json" Version="10.0.1" />
</ItemGroup>
```

Execute [`dotnet restore`](../tools/dotnet-restore.md), ([see note](#dotnet-restore-note)) which restores dependencies and creates an *obj* folder inside *library* with three files in it, including a *project.assets.json* file:

```console
dotnet restore
```

In the *library* folder, rename the file *Class1.cs* to *Thing.cs*. Replace the code with the following:

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

The `Thing` class contains one public method, `Get`, which returns the sum of two numbers but does so by converting the sum into a string and then deserializing it into an integer. This makes use of a number of modern C# features, such as [`using static` directives](../../csharp/language-reference/keywords/using-static.md), [expression-bodied members](../../csharp/whats-new/csharp-7.md#more-expression-bodied-members), and [string interpolation](../../csharp/language-reference/tokens/interpolated.md).

Build the library with the [`dotnet build`](../tools/dotnet-build.md) command. This produces a *library.dll* file under *golden/library/bin/Debug/netstandard1.4*:

```console
dotnet build
```

## Create the test project

Build a test project for the library. From the *golden* folder, create a new test project:

```console
dotnet new xunit -o test-library
```

Add the test project to the solution:

```console
dotnet sln add test-library/test-library.csproj
```

Add a project reference the library you created in the previous section so that the compiler can find and use the library project. Use the [`dotnet add reference`](../tools/dotnet-add-reference.md) command:

```console
dotnet add test-library/test-library.csproj reference library/library.csproj
```

Alternatively, manually edit the *test-library.csproj* file and add the following node:

```xml
<ItemGroup>
  <ProjectReference Include="..\library\library.csproj" />
</ItemGroup>
```

Now that the dependencies have been properly configured, create the tests for your library. Open *UnitTest1.cs* and replace its contents with the following code:

```csharp
using Library;
using Xunit;

namespace TestApp
{
    public class LibraryTests
    {
        [Fact]
        public void TestThing() {
            Assert.NotEqual(42, new Thing().Get(19, 23));
        }
    }
}
```

Note that you assert the value 42 is not equal to 19+23 (or 42) when you first create the unit test (`Assert.NotEqual`), which will fail. An important step in building unit tests is to create the test to fail once first to confirm its logic.

From the *golden* folder, execute the following commands:

```console
dotnet restore 
dotnet test test-library/test-library.csproj
```

These commands will recursively find all projects to restore dependencies, build them, and activate the xUnit test runner to run the tests. The single test fails, as you expect.

Edit the *UnitTest1.cs* file and change the assertion from `Assert.NotEqual` to `Assert.Equal`. Execute the following command from the *golden* folder to re-run the test, which passes this time:

```console
dotnet test test-library/test-library.csproj
```

## Create the console app

The console app you create over the following steps takes a dependency on the library project you created earlier and calls its library method when it runs. Using this pattern of development, you see how to create reusable libraries for multiple projects.

Create a new console application from the *golden* folder:

```console
dotnet new console -o app
```

Add the console app project to the solution:

```console
dotnet sln add app/app.csproj
```

Create the dependency on the library by running the `dotnet add reference` command:

```console
dotnet add app/app.csproj reference library/library.csproj
```

Run `dotnet restore` ([see note](#dotnet-restore-note)) to restore the dependencies of the three projects in the solution. Open *Program.cs* and replace the contents of the `Main` method with the following line:

```csharp
WriteLine($"The answer is {new Thing().Get(19, 23)}");
```

Add two `using` directives to the top of the *Program.cs* file:

```csharp
using static System.Console;
using Library;
```

Execute the following `dotnet run` command to run the executable, where the `-p` option to `dotnet run` specifies the project for the main application. The app produces the string "The answer is 42".

```console
dotnet run -p app/app.csproj
```

## Debug the application

Set a breakpoint at the `WriteLine` statement in the `Main` method. Do this by either pressing the <kbd>F9</kbd> key when the cursor is over the `WriteLine` line or by clicking the mouse in the left margin on the line where you want to set the breakpoint. A red circle will appear in the margin next to the line of code. When the breakpoint is reached, code execution will stop *before* the breakpoint line is executed.

Open the debugger tab by selecting the Debug icon in the Visual Studio Code toolbar, selecting **View > Debug** from the menu bar, or using the keyboard shortcut <kbd>CTRL</kbd>+<kbd>SHIFT</kbd>+<kbd>D</kbd>:

![Visual Studio Code Debugger](./media/using-on-macos/vscodedebugger.png)

Press the Play button to start the application under the debugger. The app begins execution and runs to the breakpoint, where it stops. Step into the `Get` method and make sure that you have passed in the correct arguments. Confirm that the answer is 42.

<a name="dotnet-restore-note"></a>
[!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]