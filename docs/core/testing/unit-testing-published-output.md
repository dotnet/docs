---
title: Test published output with dotnet vstest
description: Learn how to run tests on published output with the dotnet vstest command.
author: kendrahavens
ms.author: kehavens
ms.date: 10/18/2017
ms.topic: article
ms.prod: .net-core
ms.workload: 
  - dotnetcore
---
# Test published output with dotnet vstest

You can run tests on already published output by using the `dotnet vstest` command. This will work on xUnit, MSTest, and NUnit tests. Simply locate the DLL file that was part of your published output and run:

```
dotnet vstest <MyPublishedTests>.dll
```

where `<MyPublishedTests>` is the name of your published test project.

## Example of running tests on a published DLL

```
dotnet new mstest -o MyProject.Tests
cd MyProject.Tests
dotnet publish -o out
dotnet vstest out/MyProject.Tests.dll
```

> [!NOTE]
> Note: If your app is targeting a framework other than `netcoreapp` you can still run the `dotnet vstest` command by passing in the targeted framework with a framework flag. For example, `dotnet vstest <MyPublishedTests>.dll  --Framework:".NETFramework,Version=v4.6"`. In Visual Studio 2017 Update 5 the desired framework is automatically detected.

## See also
 [Unit Testing with dotnet test and xUnit](unit-testing-with-dotnet-test.md)  
 [Unit Testing with dotnet test and MSTest](unit-testing-with-mstest.md)  
