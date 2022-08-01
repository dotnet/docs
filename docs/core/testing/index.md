---
title: Testing in .NET
description: This article gives a brief overview of testing concepts, terminology, and tools for testing in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 08/01/2022
ms.custom: devdivchpfy22
---

# Testing in .NET

This article introduces the concept of testing and illustrates how different kinds of tests can be used to validate code. Various tools are available for testing .NET applications, such as the [.NET CLI](#net-cli) or [Integrated Development Environments (IDEs)](#ide).

## Test types

Automated tests are a great way to ensure that the application code does what its authors intend. This article covers unit tests, integration tests, and load tests.

### Unit tests

A *unit test* is a test that exercises individual software components or methods, also known as a "unit of work." Unit tests should only test code within the developer's control. They don't test infrastructure concerns. Infrastructure concerns include interacting with databases, file systems, and network resources.

For more information on creating unit tests, see [Testing tools](#testing-tools).

### Integration tests

An *integration test* differs from a unit test in that it exercises two or more software components' ability to function together, also known as their "integration." These tests operate on a broader spectrum of the system under test, whereas unit tests focus on individual components. Often, integration tests do include infrastructure concerns.

### Load tests

A *load test* aims to determine whether or not a system can handle a specified load. For example, the number of concurrent users using an application and the app's ability to handle interactions responsively. For more information on load testing of web applications, see [ASP.NET Core load/stress testing](/aspnet/core/test/load-tests).

## Test considerations

Keep in mind there are [best practices](unit-testing-best-practices.md) for writing tests. For example, [Test Driven Development (TDD)](https://deviq.com/test-driven-development) is when you write a unit test before the code it's meant to check. TDD is like creating an outline for a book before you write it. The unit test helps developers write simpler, readable, and efficient code.

## Testing tools

.NET is a multi-language development platform, and you can write various test types for [C#](../../csharp/index.yml), [F#](../../fsharp/index.yml), and [Visual Basic](../../visual-basic/index.yml). For each of these languages, you can choose between several test frameworks.

### xUnit

[xUnit](https://xunit.net) is a free, open-source, community-focused unit testing tool for .NET. The original inventor of NUnit v2 wrote xUnit.net. xUnit.net is the latest technology for unit testing .NET apps. It also works with ReSharper, CodeRush, TestDriven.NET, and [Xamarin](https://dotnet.microsoft.com/apps/xamarin). xUnit.net is a project of the [.NET Foundation](https://dotnetfoundation.org) and operates under its code of conduct.

For more information, see the following resources:

- [Unit testing with C#](unit-testing-with-dotnet-test.md)
- [Unit testing with F#](unit-testing-fsharp-with-dotnet-test.md)
- [Unit testing with Visual Basic](unit-testing-visual-basic-with-dotnet-test.md)

### NUnit

[NUnit](https://nunit.org) is a unit-testing framework for all .NET languages. Initially, NUnit was ported from JUnit, and the current production release has been rewritten with many new features and support for a wide range of .NET platforms. It's a project of the [.NET Foundation](https://dotnetfoundation.org).

For more information, see the following resources:

- [Unit testing with C#](unit-testing-with-nunit.md)
- [Unit testing with F#](unit-testing-fsharp-with-nunit.md)
- [Unit testing with Visual Basic](unit-testing-visual-basic-with-nunit.md)

### MSTest

[MSTest](https://github.com/Microsoft/testfx-docs) is the Microsoft test framework for all .NET languages. It's extensible and works with both .NET CLI and Visual Studio. For more information, see the following resources:

- [Unit testing with C#](unit-testing-with-mstest.md)
- [Unit testing with F#](unit-testing-fsharp-with-mstest.md)
- [Unit testing with Visual Basic](unit-testing-visual-basic-with-mstest.md)

### .NET CLI

You can run a solutions unit test from the [.NET CLI](../tools/index.md) with the [dotnet test](../tools/dotnet-test.md) command. The .NET CLI exposes most of the functionality that [Integrated Development Environments (IDEs)](#ide) make available through user interfaces. The .NET CLI is cross-platform and available to use as part of continuous integration and delivery pipelines. The .NET CLI is used with scripted processes to automate common tasks.

### IDE

Whether you're using Visual Studio, Visual Studio for Mac, or Visual Studio Code, there are graphical user interfaces for testing functionality. There are more features available to IDEs than the CLI, for example, [Live Unit Testing](/visualstudio/test/live-unit-testing). For more information, see [Including and excluding tests with Visual Studio](/visualstudio/test/live-unit-testing#include-and-exclude-test-projects-and-test-methods).

## See also

For more information, see the following articles:

- [Unit testing best practices with .NET](unit-testing-best-practices.md)
- [Integration tests in ASP.NET Core](/aspnet/core/test/integration-tests#test-app-prerequisites)
- [Running selective unit tests](selective-unit-tests.md)
- [Use code coverage for unit testing](unit-testing-code-coverage.md)
