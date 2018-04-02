---
title: Getting started with .NET Core using the CLI
description: A step-by-step tutorial showing how to get started with .NET Core on Windows, Linux, or macOS using the .NET Core command-line interface (CLI).
keywords: .NET Core, CLI
author: cartermp
ms.author: mairaw
ms.date: 03/08/2017
ms.topic: get-started-article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 41632e63-d5c6-4427-a09e-51dc1116d45f
ms.workload: 
  - dotnetcore
---

# Getting started with .NET Core on Windows/Linux/macOS using the command line

This topic will show you how to start developing cross-platforms apps in your machine using the .NET Core CLI tools.

If you're unfamiliar with the .NET Core CLI toolset, read the [.NET Core SDK overview](../tools/index.md).

## Prerequisites

- [.NET Core SDK 1.0](https://www.microsoft.com/net/download/core).
- A text editor or code editor of your choice.

## Hello, Console App!

You can [view or download the sample code](https://github.com/dotnet/samples/tree/master/core/console-apps/HelloMsBuild) from the dotnet/samples GitHub repository. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples).

Open a command prompt and create a folder named *Hello*. Navigate to the folder you created and type the following:

```
$ dotnet new console
$ dotnet restore
$ dotnet run
```

Let's do a quick walkthrough:

1. `$ dotnet new console`

   [`dotnet new`](../tools/dotnet-new.md) creates an up-to-date `Hello.csproj` project file with the dependencies necessary to build a console app.  It also creates a `Program.cs`, a basic file containing the entry point for the application.
   
   `Hello.csproj`:

   [!code[Hello.csproj](../../../samples/core/console-apps/HelloMsBuild/Hello.csproj)]   

   The project file specifies everything that's needed to restore dependencies and build the program.

   * The `OutputType` tag specifies that we're building an executable, in other words a console application.
   * The `TargetFramework` tag specifies what .NET implementation we're targeting. In an advanced scenario, you can specify multiple target frameworks and build to all those in a single operation. In this tutorial, we'll stick to building only for .NET Core 1.0.

   `Program.cs`:

   [!code-csharp[Program.cs](../../../samples/core/console-apps/HelloMsBuild/Program.cs)]   

   The program starts by `using System`, which means "bring everything in the `System` namespace into scope for this file". The `System` namespace includes basic constructs such as `string`, or numeric types.

   We then define a namespace called `Hello`. You can change this to anything you want. A class named `Program` is defined within that namespace, with a `Main` method that takes an array of strings as its argument. This array contains the list of arguments passed in when the compiled program is called. As it is, this array is not used: all the program is doing is to write "Hello World!" to the console. Later, we'll make changes to the code that will make use of this argument.

   [!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]

2. `$ dotnet restore`

   [`dotnet restore`](../tools/dotnet-restore.md) calls into [NuGet](https://www.nuget.org/) (.NET package manager) to restore the tree of dependencies. NuGet analyzes the *Hello.csproj* file, downloads the dependencies stated in the file (or grabs them from a cache on your machine), and writes the *obj/project.assets.json* file.  The *project.assets.json* file is necessary to be able to compile and run.
   
   The *project.assets.json* file is a persisted and complete set of the graph of NuGet dependencies and other information describing an app.  This file is read by other tools, such as [`dotnet build`](../tools/dotnet-build.md) and [`dotnet run`](../tools/dotnet-run.md), enabling them to process the source code with a correct set of NuGet dependencies and binding resolutions.
   
3. `$ dotnet run`

   [`dotnet run`](../tools/dotnet-run.md) calls [`dotnet build`](../tools/dotnet-build.md) to ensure that the build targets have been built, and then calls `dotnet <assembly.dll>` to run the target application.
   
    ```
    $ dotnet run
    Hello World!
    ```

    Alternatively, you can also execute [`dotnet build`](../tools/dotnet-build.md) to compile the code without running the build console applications. This results in a compiled application as a DLL file that can be run with `dotnet bin\Debug\netcoreapp1.0\Hello.dll` on Windows (use `/` for non-Windows systems). You may also specify arguments to the application as you'll see later on the topic.

    ```
    $ dotnet bin\Debug\netcoreapp1.0\Hello.dll
    Hello World!
    ```

    As an advanced scenario, it's possible to build the application as a self-contained set of platform-specific files that can be deployed and run to a machine that doesn't necessarily have .NET Core installed. See [.NET Core Application Deployment](../deploying/index.md) for details.

### Augmenting the program

Let's change the program a bit. Fibonacci numbers are fun, so let's add that in addition to use the argument to greet the person running the app.

1. Replace the contents of your *Program.cs*  file with the following code:

   [!code-csharp[Fibonacci](../../../samples/core/console-apps/fibonacci-msbuild/Program.cs)]   

2. Execute [`dotnet build`](../tools/dotnet-build.md) to compile the changes.

3. Run the program passing a parameter to the app:

   ```
   $ dotnet run -- John
   Hello John!
   Fibonacci Numbers 1-15:
   1: 0
   2: 1
   3: 1
   4: 2
   5: 3
   6: 5
   7: 8
   8: 13
   9: 21
   10: 34
   11: 55
   12: 89
   13: 144
   14: 233
   15: 377
   ```

And that's it!  You can augment `Program.cs` any way you like.

## Working with multiple files

Single files are fine for simple one-off programs, but if you're building a more complex app, you're probably going to have multiple source files on your project
Let's build off of the previous Fibonacci example by caching some Fibonacci values and add some recursive features. 

1. Add a new file inside the *Hello* directory named *FibonacciGenerator.cs* with the following code:

   [!code-csharp[Fibonacci Generator](../../../samples/core/console-apps/FibonacciBetterMsBuild/FibonacciGenerator.cs)]   

2. Change the `Main` method in your *Program.cs* file to instantiate the new class and call its method as in the following example:

   [!code-csharp[New Program.cs](../../../samples/core/console-apps/FibonacciBetterMsBuild/Program.cs)]

3. Execute [`dotnet build`](../tools/dotnet-build.md) to compile the changes.

4. Run your app by executing [`dotnet run`](../tools/dotnet-run.md). The following shows the program output:

   ```
   0
   1
   1
   2
   3
   5
   8
   13
   21
   34
   55
   89
   144
   233
   377
   ```

And that's it! Now, you can start using the basic concepts learned here to create your own programs.

Note that the commands and steps shown in this tutorial to run your application are used during development time only. Once you're ready to deploy your app, you'll want to take a look at the different [deployment strategies](../deploying/index.md) for .NET Core apps and the [`dotnet publish`](../tools/dotnet-publish.md) command.

## See also

[Organizing and testing projects with the .NET Core CLI tools](testing-with-cli.md)
