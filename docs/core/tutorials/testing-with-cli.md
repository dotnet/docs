---
title: Organizing and testing projects with the .NET Core command line | Microsoft Docs
description: This tutorial explains how to organize and test .NET Core projects from the command line.
keywords: .NET, .NET Core, testing, CLI
author: cartermp
ms.author: mairaw
ms.date: 03/20/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 52ff1be3-d92e-4477-9c84-8c1771e87ab5
---

# Organizing and testing projects with the .NET Core command line

This tutorial follows [Getting started with .NET Core on Windows/Linux/macOS using the command line](using-with-xplat-cli.md) taking you beyond the simple "Hello World!" app to pave the way for the development of advanced and well-organized applications. After showing you how to use folders to organize your code, this tutorial shows you how to extend the [NewTypes Pets Sample](https://github.com/dotnet/docs/tree/master/samples/core/console-apps/NewTypesMsBuild) using the [xUnit](https://xunit.github.io/) test framework.

## Using folders to organize code

If you want to introduce new types into a console app, you can do so by adding files containing the types to the app. You just need to ensure that the types share a common namespace with the app or that the types' namespaces are specified in the *Program.cs* file with `using` statements. For example if you add files containing `AccountInformation` and `MonthlyReportRecords` types to your project, the project file structure is flat and easy to navigate:

```
/MyProject
|__AccountInformation.cs
|__MonthlyReportRecords.cs
|__MyProject.csproj
|__Program.cs
```

However, this only works well when the size of your project is relatively small. Can you imagine what will happen if 20 types were added in this way? The project definitely wouldn't be easy to navigate with that many files littering the project's root directory. When you're building a larger app with many data types and multiple layers, you should organize the project using folders, which will make the project easier to navigate and maintain.

To organize the project structure shown above, create a new folder under the root of the project, `/Model`, to hold the types.

```
/NewTypes
|__/Model
|__Program.cs
|__NewTypes.csproj
```

Place the types into the `/Model` folder:

```
/NewTypes
|__/Model
   |__AccountInformation.cs
   |__MonthlyReportRecords.cs
|__Program.cs
|__NewTypes.csproj
```

You organize type files into folders using a logical structure for the app. Consume the types across the app by using a common namespace or with different namespaces and exposing the types with `using` statements.

## Organizing and testing using the NewTypes Pets Sample

### Building the sample

For the following steps, you can either follow along using the [NewTypes Pets Sample](https://github.com/dotnet/docs/tree/master/samples/core/console-apps/NewTypesMsBuild) or create your own files and folders. This example creates two new types, `Dog` and `Cat`, and has them implement a common interface, `IPet`.

Folder Structure:

```
/NewTypes
|__/Pets
   |__Dog.cs
   |__Cat.cs
   |__IPet.cs
|__Program.cs
|__NewTypes.csproj
```

*IPet.cs*:

[!code-csharp[IPet interface](../../../samples/core/console-apps/NewTypesMsBuild/src/NewTypes/Pets/IPet.cs)]

*Dog.cs*:

[!code-csharp[Dog class](../../../samples/core/console-apps/NewTypesMsBuild/src/NewTypes/Pets/Dog.cs)]

*Cat.cs*:

[!code-csharp[Cat class](../../../samples/core/console-apps/NewTypesMsBuild/src/NewTypes/Pets/Cat.cs)]

*Program.cs*:

[!code-csharp[Main](../../../samples/core/console-apps/NewTypesMsBuild/src/NewTypes/Program.cs)]

*NewTypes.csproj*:

[!code-xml[NewTypes csproj](../../../samples/core/console-apps/NewTypesMsBuild/src/NewTypes/NewTypes.csproj)]

Execute the following commands:

```console
dotnet restore
dotnet run
```

Obtain the following output:

```console
Woof!
Meow!
```

You can add a new pet type, such as a `Bird`, extending this project. Make the bird's `TalkToOwner` property give a `Tweet!` to the owner.

### Testing the sample

Now that the project is in place, create your test project and start writing tests with the [xUnit](https://xunit.github.io/) test framework. The complete project structure is shown below:

```
/NewTypes
|__/src
   |__/NewTypes
      |__/Pets
         |__Dog.cs
         |__Cat.cs
         |__IPet.cs
      |__Program.cs
      |__NewTypes.csproj
|__/test
   |__NewTypesTests
      |__PetTests.cs
      |__NewTypesTests.csproj
```

Create the *NewTypesTests.csproj* file with the following:

* A reference to `Microsoft.NET.Test.Sdk`, the .NET testing infrastructure
* A reference to `xunit`, the xUnit testing framework
* A reference to `xunit.runner.visualstudio`, the test runner
* A project reference to `NewTypes`, the code to test

Create the project by executing `dotnet new xunit` at a command prompt in the *NewTypesTests* directory, then add a project reference to the `NewTypes` project.

*NewTypesTests.csproj*:

[!code-xml[NewTypesTests csproj](../../../samples/core/console-apps/NewTypesMsBuild/test/NewTypesTests/NewTypesTests.csproj)]

Add an xUnit test class, *PetTests.cs*:

[!code-csharp[PetTests class](../../../samples/core/console-apps/NewTypesMsBuild/test/NewTypesTests/PetTests.cs)]
   
Run the tests with the [`dotnet test`](../tools/dotnet-test.md) command. This command starts the test runner specified in the project file. Start in the `test/NewTypesTests` directory and execute the following commands:
 
```console
dotnet restore
dotnet test
```
 
Testing passes and the console displays the following output:
 
```
Microsoft (R) Test Execution Command Line Tool Version 15.0.0.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
[xUnit.net 00:00:01.3882374]   Discovering: NewTypesTests
[xUnit.net 00:00:01.4767970]   Discovered:  NewTypesTests
[xUnit.net 00:00:01.5157667]   Starting:    NewTypesTests
[xUnit.net 00:00:01.6408870]   Finished:    NewTypesTests

Total tests: 2. Passed: 2. Failed: 0. Skipped: 0.
Test Run Successful.
Test execution time: 2.9309 Seconds
```
