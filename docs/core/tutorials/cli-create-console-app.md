---
title: Get started with .NET Core using the CLI
description: A step-by-step tutorial showing how to get started with .NET Core on Windows, Linux, or macOS using the .NET Core CLI.
author: thraka
ms.author: adegeo
ms.date: 12/05/2019
ms.technology: dotnet-cli
ms.custom: "updateeachrelease"
---
# Get started with .NET Core using the .NET Core CLI

This article will show you how to start developing .NET Core apps that work on Windows, Linux, and macOS using the .NET Core CLI.

If you're unfamiliar with the .NET Core CLI, see the [.NET Core CLI overview](../tools/index.md).

## Prerequisites

- [.NET Core SDK 3.1](https://dotnet.microsoft.com/download) or later versions.
- A text editor or code editor of your choice.

## Hello, Console App!

You can [view or download the sample code](https://github.com/dotnet/samples/tree/master/core/console-apps/HelloMsBuild) from the dotnet/samples GitHub repository. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples).

Open a command prompt and create a folder named *Hello*. Navigate to the folder you created and type the following.

```dotnetcli
dotnet new console
dotnet run
```

Let's do a quick walkthrough:

01. `dotnet new console`

    [dotnet new](../tools/dotnet-new.md) creates an up-to-date *Hello.csproj* project file with the dependencies necessary to build a console app. It also creates a *Program.cs*, a basic file containing the entry point for the application.
    
    *Hello.csproj*:
    
    [!code-xml[Hello.csproj](~/samples/core/console-apps/HelloMsBuild/Hello.csproj)]
    
    The project file specifies everything that's needed to restore dependencies and build the program.
    
    - The `<OutputType>` element specifies that we're building an executable, in other words a console application.
    - The `<TargetFramework>` element specifies what .NET implementation we're targeting. In an advanced scenario, you can specify multiple target frameworks and build to all those in a single operation. In this tutorial, we'll stick to building only for .NET Core 3.1.
    
    *Program.cs*:
    
    [!code-csharp[Program.cs](~/samples/core/console-apps/HelloMsBuild/Program.cs)]
    
    The program starts by `using System`, which means "bring everything in the `System` namespace into scope for this file". The `System` namespace includes the `Console` class.
    
    We then define a namespace called `Hello`. You can change this to anything you want. A class named `Program` is defined within that namespace, with a `Main` method that takes an array of strings named `args`. This array contains the list of arguments passed in when the program is run. As it is, this array is not used and the program simply writes the text "Hello World!" to the console. Later, we'll make changes to the code that will make use of this argument.
    
    `dotnet new` calls [dotnet restore](../tools/dotnet-restore.md) implicitly. `dotnet restore` calls into [NuGet](https://www.nuget.org/) (.NET package manager) to restore the tree of dependencies. NuGet analyzes the *Hello.csproj* file, downloads the dependencies defined in the file (or grabs them from a cache on your machine), and writes the *obj/project.assets.json* file, which is necessary to compile and run the sample.

02. `dotnet run`

    [dotnet run](../tools/dotnet-run.md) calls [dotnet build](../tools/dotnet-build.md) to ensure that the build targets have been built, and then calls `dotnet <assembly.dll>` to run the target application.
    
    ```dotnetcli
    dotnet run
    ```

    You get the following output.

    ```console
    Hello World!
    ```
    
    Alternatively, you can also run `dotnet build` to compile the code without running the build console applications. This results in a compiled application, as a DLL file, based on the name of the project. In this case, the file created is named *Hello.dll*. This app can be run with `dotnet bin\Debug\netcoreapp3.1\Hello.dll` on Windows (use `/` for non-Windows systems).
    
    ```dotnetcli
    dotnet bin\Debug\netcoreapp3.1\Hello.dll
    ```

    You get the following output.

    ```console
    Hello World!
    ```
    
    When the app is compiled, an operating system-specific executable was created along with the `Hello.dll`. On Windows, this would be `Hello.exe`; on Linux or macOS, this would be `hello`. With the example above, the file is named with `Hello.exe` or `Hello`. You can run that executable directly.

    ```console
    .\bin\Debug\netcoreapp3.1\Hello.exe

    Hello World!
    ```

## Modify the program

Let's change the program a bit. Fibonacci numbers are fun, so let's add that and also to use the argument to greet the person running the app.

01. Replace the contents of your *Program.cs*  file with the following code:

    [!code-csharp[Fibonacci](~/samples/core/console-apps/fibonacci-msbuild/Program.cs)]

02. Run [dotnet build](../tools/dotnet-build.md) to compile the changes.

03. Run the program passing a parameter to the app. When you use the `dotnet` command to run an app, add `--` to the end. Anything to the right of `--` will be passed as a parameter to the app. In the following example, the value `John` is passed to the app.

    ```dotnetcli
    dotnet run -- John
    ```

    You get the following output.

    ```console
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

And that's it! You can modify *Program.cs* any way you like.

## Working with multiple files

Single files are fine for simple one-off programs, but if you're building a more complex app, you're probably going to have multiple code files on your project. Let's build off of the previous Fibonacci example by caching some Fibonacci values and add some recursive features.

01. Add a new file inside the *Hello* directory named *FibonacciGenerator.cs* with the following code:

    [!code-csharp[Fibonacci Generator](~/samples/core/console-apps/FibonacciBetterMsBuild/FibonacciGenerator.cs)]

02. Change the `Main` method in your *Program.cs* file to instantiate the new class and call its method as in the following example:

    [!code-csharp[New Program.cs](~/samples/core/console-apps/FibonacciBetterMsBuild/Program.cs)]

03. Run [dotnet build](../tools/dotnet-build.md) to compile the changes.

04. Run your app by executing [dotnet run](../tools/dotnet-run.md).

    ```dotnetcli
    dotnet run
    ```

    You get the following output.

    ```console
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

## Publish your app

Once you're ready to distribute your app, use the [dotnet publish](../tools/dotnet-publish.md) command to generate the _publish_ folder at _bin\\debug\\netcoreapp3.1\\publish\\_ (use `/` for non-Windows systems). You can distribute the contents of the _publish_ folder to other platforms as long as they've already installed the dotnet runtime.

```dotnetcli
dotnet publish
```

You get output similar to the following.

```console
Microsoft (R) Build Engine version 16.4.0+e901037fe for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 20 ms for C:\Code\Temp\Hello\Hello.csproj.
  Hello -> C:\Code\Temp\Hello\bin\Debug\netcoreapp3.1\Hello.dll
  Hello -> C:\Code\Temp\Hello\bin\Debug\netcoreapp3.1\publish\
```

The output above may differ based on your current folder and operating system, but the output should be similar.

You can run your published app with the [dotnet](../tools/dotnet.md) command:

```dotnetcli
dotnet bin\Debug\netcoreapp3.1\publish\Hello.dll
```

You get the following output.

```console
Hello World!
```

As mentioned at the start of this article, an operating system-specific executable was created along with the `Hello.dll`. On Windows, this would be `Hello.exe`; on Linux or macOS, this would be `hello`. With the example above, the file is named with `Hello.exe` or `Hello`. You can run this published executable directly.

```console
.\bin\Debug\netcoreapp3.1\publish\Hello.exe

Hello World!
```

## Conclusion

And that's it! Now, you can start using the basic concepts learned here to create your own programs.

## See also

- [Organizing and testing projects with the .NET Core CLI](testing-with-cli.md)
- [Publish .NET Core apps with the .NET Core CLI](../deploying/deploy-with-cli.md)
- [.NET Core application deployment](../deploying/index.md)
