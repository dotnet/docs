---
title: Test Published Output with dotnet vstest
description: Learn how to run tests on published output with the dotnet vstest command.
keywords: MSTest, .NET, .NET Core, xUnit, test, published, output, test after publishing, run tests on dll
author: kehavens
ms.author: kehavens
ms.date: 10/18/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 3965e4ca-75b8-4969-b3af-ca993c397a15
---

# Test Published Output with dotnet vstest

You can run tests on already published output by using the `dotnet vstest` command. This will work on both xUnit and MSTest tests. Simply locate the DLL file that was part of your published output and run:
```
dotnet vstest <MyPublishedTests>.dll
```
where `<MyPublishedTests>` is the name of your published test project.

### Example of Running Tests on a published DLL

```
dotnet new mstest -o MyProject.Tests
cd MyProject.Tests
dotnet publish -o out
dotnet vstest out/MyProject.Tests.dll
```

