---
title: Organizing and testing projects with the .NET Core command line
description: This tutorial explains how to organize and test .NET Core projects from the command line.
keywords: .NET, .NET Core, unit testing, .NET Core CLI, xUnit
author: cartermp
ms.author: mairaw
ms.date: 05/16/2017
ms.topic: article
ms.prod: .net-core
ms.technology: dotnet-cli
ms.devlang: dotnet
ms.assetid: 52ff1be3-d92e-4477-9c84-8c1771e87ab5
ms.workload: 
  - dotnetcore
---

# Organizing and testing projects with the .NET Core command line

This tutorial follows [Getting started with .NET Core on Windows/Linux/macOS using the command line](using-with-xplat-cli.md), taking you beyond the creation of a simple console app to develop advanced and well-organized applications. After showing you how to use folders to organize your code, this tutorial shows you how to extend a console application with the [xUnit](https://xunit.github.io/) testing framework.

## Using folders to organize code

If you want to introduce new types into a console app, you can do so by adding files containing the types to the app. For example if you add files containing `AccountInformation` and `MonthlyReportRecords` types to your project, the project file structure is flat and easy to navigate:

```
/MyProject
|__AccountInformation.cs
|__MonthlyReportRecords.cs
|__MyProject.csproj
|__Program.cs
```

However, this only works well when the size of your project is relatively small. Can you imagine what will happen if you add 20 types to the project? The project definitely wouldn't be easy to navigate and maintain with that many files littering the project's root directory.

To organize the project, create a new folder and name it *Models* to hold the type files. Place the type files into the *Models* folder:

```
/MyProject
|__/Models
   |__AccountInformation.cs
   |__MonthlyReportRecords.cs
|__MyProject.csproj
|__Program.cs
```

Projects that logically group files into folders are easy to navigate and maintain. In the next section, you create a more complex sample with folders and unit testing.

## Organizing and testing using the NewTypes Pets Sample

### Building the sample

For the following steps, you can either follow along using the [NewTypes Pets Sample](https://github.com/dotnet/samples/tree/master/core/console-apps/NewTypesMsBuild) or create your own files and folders. The types are logically organized into a folder structure that permits the addition of more types later, and tests are also logically placed in folders permitting the addition of more tests later.

The sample contains two types, `Dog` and `Cat`, and has them implement a common interface, `IPet`. For the `NewTypes` project, your goal is to organize the pet-related types into a *Pets* folder. If another set of types is added later, *WildAnimals* for example, they're placed in the *NewTypes* folder alongside the *Pets* folder. The *WildAnimals* folder may contain types for animals that aren't pets, such as `Squirrel` and `Rabbit` types. In this way as types are added, the project remains well organized. 

Create the following folder structure with file content indicated:

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
dotnet run
```

Obtain the following output:

```console
Woof!
Meow!
```

Optional exercise: You can add a new pet type, such as a `Bird`, by extending this project. Make the bird's `TalkToOwner` method give a `Tweet!` to the owner. Run the app again. The output will include `Tweet!`

### Testing the sample

The `NewTypes` project is in place, and you've organized it by keeping the pets-related types in a folder. Next, create your test project and start writing tests with the [xUnit](https://xunit.github.io/) test framework. Unit testing allows you to automatically check the bevahior of your pet types to confirm that they're operating properly.

Create a *test* folder with a *NewTypesTests* folder within it. At a command prompt from the *NewTypesTests* folder, execute `dotnet new xunit`. This produces two files: *NewTypesTests.csproj* and *UnitTest1.cs*.

The test project cannot currently test the types in `NewTypes` and requires a project reference to the `NewTypes` project. To add a project reference, use the [`dotnet add reference`](../tools/dotnet-add-reference.md) command:

```
dotnet add reference ../../src/NewTypes/NewTypes.csproj
```

You also have the option of manually adding the project reference by adding an `<ItemGroup>` node to the *NewTypesTests.csproj* file:

```xml
<ItemGroup>
  <ProjectReference Include="../../src/NewTypes/NewTypes.csproj" />
</ItemGroup>
```

*NewTypesTests.csproj*:

[!code-xml[NewTypesTests csproj](../../../samples/core/console-apps/NewTypesMsBuild/test/NewTypesTests/NewTypesTests.csproj)]

The *NewTypesTests.csproj* file contains the following:

* Package reference to `Microsoft.NET.Test.Sdk`, the .NET testing infrastructure
* Package reference to `xunit`, the xUnit testing framework
* Package reference to `xunit.runner.visualstudio`, the test runner
* Project reference to `NewTypes`, the code to test

Change the name of *UnitTest1.cs* to *PetTests.cs* and replace the code in the file with the following:

```csharp
using System;
using Xunit;
using Pets;

public class PetTests
{
	[Fact]
	public void DogTalkToOwnerReturnsWoof()
	{
		string expected = "Woof!";
		string actual = new Dog().TalkToOwner();
		
		Assert.NotEqual(expected, actual);
	}
	
	[Fact]
	public void CatTalkToOwnerReturnsMeow()
	{
		string expected = "Meow!";
		string actual = new Cat().TalkToOwner();
		
		Assert.NotEqual(expected, actual);
	}
}
```

Optional exercise: If you added a `Bird` type earlier that yields a `Tweet!` to the owner, add a test method to the *PetTests.cs* file, `BirdTalkToOwnerReturnsTweet`, to check that the `TalkToOwner` method works correctly for the `Bird` type.

> [!NOTE]
> Although you expect that the `expected` and `actual` values are equal, the initial assertions with the `Assert.NotEqual` checks specify that they are *not equal*. Always initially create your tests to fail once in order to check the logic of the tests. This is an important step in test-driven design (TDD) methodology. After you confirm the tests fail, you adjust the assertions to allow them to pass.

The following shows the complete project structure:

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

Start in the *test/NewTypesTests* directory. Restore the test project with the [`dotnet restore`](../tools/dotnet-restore.md) 
 command. Run the tests with the [`dotnet test`](../tools/dotnet-test.md) command. This command starts the test runner specified in the project file.

 [!INCLUDE[DotNet Restore Note](~/includes/dotnet-restore-note.md)]

 
As expected, testing fails, and the console displays the following output:
 
```
Test run for C:\NewTypesMsBuild\test\NewTypesTests\bin\Debug\netcoreapp1.1\NewTypesTests.dll(.NETCoreApp,Version=v1.1)
Microsoft (R) Test Execution Command Line Tool Version 15.0.0.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...
[xUnit.net 00:00:00.7271827]   Discovering: NewTypesTests
[xUnit.net 00:00:00.8258687]   Discovered:  NewTypesTests
[xUnit.net 00:00:00.8663545]   Starting:    NewTypesTests
[xUnit.net 00:00:01.0109236]     PetTests.CatTalkToOwnerReturnsMeow [FAIL]
[xUnit.net 00:00:01.0119107]       Assert.NotEqual() Failure
[xUnit.net 00:00:01.0120278]       Expected: Not "Meow!"
[xUnit.net 00:00:01.0120968]       Actual:   "Meow!"
[xUnit.net 00:00:01.0130500]       Stack Trace:
[xUnit.net 00:00:01.0141240]         C:\NewTypesMsBuild\test\NewTypesTests\PetTests.cs(22,0): at PetTests.CatTalkToOwnerReturnsMeow()
[xUnit.net 00:00:01.0272364]     PetTests.DogTalkToOwnerReturnsWoof [FAIL]
[xUnit.net 00:00:01.0273649]       Assert.NotEqual() Failure
[xUnit.net 00:00:01.0274166]       Expected: Not "Woof!"
[xUnit.net 00:00:01.0274690]       Actual:   "Woof!"
[xUnit.net 00:00:01.0275264]       Stack Trace:
[xUnit.net 00:00:01.0275960]         C:\NewTypesMsBuild\test\NewTypesTests\PetTests.cs(13,0): at PetTests.DogTalkToOwnerReturnsWoof()
[xUnit.net 00:00:01.0294509]   Finished:    NewTypesTests
Failed   PetTests.CatTalkToOwnerReturnsMeow
Error Message:
 Assert.NotEqual() Failure
Expected: Not "Meow!"
Actual:   "Meow!"
Stack Trace:
   at PetTests.CatTalkToOwnerReturnsMeow() in C:\NewTypesMsBuild\test\NewTypesTests\PetTests.cs:line 22
Failed   PetTests.DogTalkToOwnerReturnsWoof
Error Message:
 Assert.NotEqual() Failure
Expected: Not "Woof!"
Actual:   "Woof!"
Stack Trace:
   at PetTests.DogTalkToOwnerReturnsWoof() in C:\NewTypesMsBuild\test\NewTypesTests\PetTests.cs:line 13

Total tests: 2. Passed: 0. Failed: 2. Skipped: 0.
Test Run Failed.
Test execution time: 2.1371 Seconds
```

Change the assertions of your tests from `Assert.NotEqual` to `Assert.Equal`:

[!code-csharp[PetTests class](../../../samples/core/console-apps/NewTypesMsBuild/test/NewTypesTests/PetTests.cs)]

Re-run the tests with the `dotnet test` command and obtain the following output:

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
Test execution time: 1.6634 Seconds
```

Testing passes. The pet types' methods return the correct values when talking to the owner.

You've learned techniques for organizing and testing projects using xUnit. Go forward with these techniques applying them in your own projects. *Happy coding!*

