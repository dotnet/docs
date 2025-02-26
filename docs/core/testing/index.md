---
title: Testing in .NET
description: This article gives a brief overview of testing concepts, terminology, and tools for testing in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 12/15/2023
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

When running tests in .NET, there are two components involved. The test platform and the test framework.

### Test platforms

The test platform is the engine that runs the tests as well as acting as a communication channel with IDEs. For example, the IDE (e.g, Test Explorer) can send a discovery request to the test platform so that the IDE is able to show the tests you have. The test platform responds, in some way, back to the IDE with the tests it found. Similar communication happens for test execution.

In .NET, VSTest has been used for many years and was the only test platform in the ecosystem. Very early in 2024, we released the first stable version of a new test platform, called [Microsoft.Testing.Platform (MTP)](./unit-testing-platform-intro.md).

### Test frameworks

The test framework is built on top of the test platform. It defines the set of attributes and APIs that are available to you, as a test author, and is usually powered by a test adapter, which acts as a communication layer between the test framework and the test platform. The popular test frameworks as of today are MSTest, NUnit, TUnit, and xUnit.

#### MSTest

[MSTest](https://github.com/microsoft/testfx) is the Microsoft test framework for all .NET languages. It's extensible and works with .NET CLI, Visual Studio, Visual Studio Code, and Rider. It supports running with both VSTest and Microsoft.Testing.Platform.

For more information, see the following resources:

- [MSTest runner overview (running MSTest with Microsoft.Testing.Platform)](unit-testing-mstest-runner-intro.md)
- [Unit testing with C#](unit-testing-with-mstest.md)
- [Unit testing with F#](unit-testing-fsharp-with-mstest.md)
- [Unit testing with Visual Basic](unit-testing-visual-basic-with-mstest.md)

#### NUnit

[NUnit](https://nunit.org) is a unit-testing framework for all .NET languages. Initially, NUnit was ported from JUnit, and the current production release has been rewritten with many new features and support for a wide range of .NET platforms. It's a project of the [.NET Foundation](https://dotnetfoundation.org). It supports running with both VSTest and Microsoft.Testing.Platform.

For more information, see the following resources:

- [Unit testing with C#](unit-testing-with-nunit.md)
- [Unit testing with F#](unit-testing-fsharp-with-nunit.md)
- [Unit testing with Visual Basic](unit-testing-visual-basic-with-nunit.md)

#### TUnit

[TUnit](https://thomhurst.github.io/TUnit/) is entirely built on top of Microsoft.Testing.Platform and doesn't support VSTest. For more information, refer to TUnit documentation.

#### xUnit.net

[xUnit](https://xunit.net) is a free, open-source, community-focused unit testing tool for .NET. The original inventor of NUnit v2 wrote xUnit.net. xUnit.net is the latest technology for unit testing .NET apps. It also works with ReSharper, CodeRush, and TestDriven.NET. xUnit.net is a project of the [.NET Foundation](https://dotnetfoundation.org) and operates under its code of conduct. It also supports running with both VSTest and Microsoft.Testing.Platform

For more information, see the following resources:

- [Unit testing with C#](unit-testing-with-dotnet-test.md)
- [Unit testing with F#](unit-testing-fsharp-with-dotnet-test.md)
- [Unit testing with Visual Basic](unit-testing-visual-basic-with-dotnet-test.md)

## Running tests

### .NET CLI

You can run unit tests from all test projects in a solution using the [.NET CLI](../tools/index.md) with the [dotnet test](../tools/dotnet-test.md) command. The .NET CLI exposes most of the functionality that [Integrated Development Environments (IDEs)](#ide) make available through user interfaces. The .NET CLI is cross-platform and available to use as part of continuous integration and delivery pipelines. The .NET CLI is used with scripted processes to automate common tasks.

### IDE

Whether you're using Visual Studio, Visual Studio Code, or Rider, there are graphical user interfaces for testing functionality. There are more features available to IDEs than the CLI, for example, [Live Unit Testing](/visualstudio/test/live-unit-testing). For more information, see [Including and excluding tests with Visual Studio](/visualstudio/test/live-unit-testing#include-and-exclude-test-projects-and-test-methods).

## See also

For more information, see the following articles:

- [Unit testing best practices with .NET](unit-testing-best-practices.md)
- [Integration tests in ASP.NET Core](/aspnet/core/test/integration-tests#test-app-prerequisites)
- [Running selective unit tests](selective-unit-tests.md)
- [Use code coverage for unit testing](unit-testing-code-coverage.md)
