---
title: Microsoft.Testing.Platform and VSTest comparison
description: Learn the differences between Microsoft.Testing.Platform and VSTest, such as namespaces, NuGet packages, and executables.
author: nohwnd
ms.author: jajares
ms.date: 12/15/2023
---

# Microsoft.Testing.Platform and VSTest comparison

`Microsoft.Testing.Platform` is a lightweight and portable alternative to [VSTest](https://github.com/microsoft/vstest) for running tests in command line, in continuous integration (CI) pipelines, in Visual Studio Test Explorer, and in Visual Studio Code. In this article, you learn the key differences between Microsoft.Testing.Platform and VSTest.

## Differences in test execution

Tests are executed in different ways depending on the runner.

### Execute VSTest tests

VSTest ships with Visual Studio, the .NET SDK, and as a standalone tool in the [Microsoft.TestPlatform](https://www.nuget.org/packages/Microsoft.TestPlatform) NuGet package. VSTest uses a runner executable to run tests, called `vstest.console.exe`, which can be used directly or through `dotnet test`.

### Execute Microsoft.Testing.Platform tests

Microsoft.Testing.Platform is embedded directly into your test project and doesn't ship any extra executables. When you run your project executable, your tests run. For more information on running Microsoft.Testing.Platform tests, see [Microsoft.Testing.Platform overview: Run and debug tests](microsoft-testing-platform-intro.md#run-and-debug-tests).

## Namespaces and NuGet packages

To familiarize yourself with `Microsoft.Testing.Platform` and VSTest, it's helpful to understand the namespaces and NuGet packages that are used by each.

### VSTest namespaces

VSTest is a collection of testing tools that are also known as the _Test Platform_. The VSTest source code is open-source and available in the [microsoft/vstest](https://github.com/microsoft/vstest) GitHub repository. The code uses the `Microsoft.TestPlatform.*` namespace.

VSTest is extensible and common types are placed in [Microsoft.TestPlatform.ObjectModel](https://www.nuget.org/packages/Microsoft.TestPlatform.ObjectModel) NuGet package.

### Microsoft.Testing.Platform namespaces

Microsoft.Testing.Platform is based on [Microsoft.Testing.Platform](https://www.nuget.org/packages/Microsoft.Testing.Platform) NuGet package and other libraries in the `Microsoft.Testing.*` namespace. Like VSTest, the `Microsoft.Testing.Platform` is open-source and has a [microsoft/testfx](https://github.com/microsoft/testfx/tree/main/src/Platform/Microsoft.Testing.Platform) GitHub repository.

## Communication protocol

> [!NOTE]
> The Visual Studio Test Explorer supports the Microsoft.Testing.Platform protocol since 17.12 onward. If you run/debug your tests using earlier versions of Visual Studio, Test Explorer will use `vstest.console.exe` and the old protocol to run these tests.

Microsoft.Testing.Platform uses a JSON-RPC based protocol to communicate between Visual Studio and the test runner process. The protocol is documented in the [MSTest GitHub repository](https://github.com/microsoft/testfx/tree/main/docs/mstest-runner-protocol).

VSTest also uses a JSON based communication protocol, but it's not JSON-RPC based.

### Disabling the new protocol

To disable the use of the new protocol in Test Explorer, you can edit your project to add the following property: `<DisableTestingPlatformServerCapability>true</DisableTestingPlatformServerCapability>`.

You can also go to Preview Features options in Visual Studio and deselect the "Use testing platform server mode" option.

## Executables

VSTest ships multiple executables, notably `vstest.console.exe`, `testhost.exe`, and `datacollector.exe`. However, MSTest is embedded directly into your test project and doesn't ship any other executables. The executable your test project compiles to is used to host all the testing tools and carry out all the tasks needed to run tests.

## See also

- [Migration guide from VSTest to Microsoft.Testing.Platform](./migrating-vstest-microsoft-testing-platform.md)
