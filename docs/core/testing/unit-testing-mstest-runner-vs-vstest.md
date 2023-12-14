---
title: MSTest runner and VSTest comparison
description: Learn the difference between MSTest runner and VSTest.
author: nohwnd
ms.author: jajares
ms.date: 12/13/2023
---

# MSTest runner and VSTest comparison

The MSTest runner is a lightweight and portable alternative to [VSTest](https://github.com/microsoft/vstest) for running tests in command line, in continuous integration (CI) pipelines, in Visual Studio Test Explorer, and in Visual Studio Code.

The article below describes the main differences between VSTest and MSTest runner.

## Executing tests

### Executing VSTest tests

VSTest ships with Visual Studio, .NET SDK and also as a standalone tool in `Microsoft.TestingPlatform` NuGet package. VSTest uses a runner executable to run tests, this runner is called `vstest.console.exe`, and can be used directly or through `dotnet test`.

### Executing MSTest runner tests

MSTest is embedded directly into your test project, and does not ship any additional executables. Running your project executable directly will run yours tests.

## Namespaces

### VSTest namespaces

VSTest is a collection of testing tools, that are also known as Test Platform. VSTest source code is placed in [microsoft/vstest](https://github.com/microsoft/vstest) repository. The code uses `Microsoft.TestPlatform.*` namespace.

VSTest is extensible and common types are placed in `Microsoft.TestPlatform.ObjectModel` library.

### MSTest runner namespaces

The MSTest runner is based on `Microsoft.Testing.Platform` library and additional libraries in `Microsoft.Testing.*` namespace. `Microsoft.Testing.Platform` code is placed in [microsoft/testfx](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.Testing.Platform) GitHub repository.

## Executables

### VSTest executables

VSTest ships multiple executables, the most known `vstest.console.exe`, `testhost.exe`, `datacollector.exe`.

### MSTest runner executables

MSTest is embedded directly into your test project, and does not ship any additional executables. The executable of your test project is used to host all the testing tools, and carry out all the tasks that are needed for running tests.
