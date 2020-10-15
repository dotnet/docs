---
title: Testing in .NET Core and .NET Standard
description: This article gives a brief overview of testing for .NET Core and .NET Standard projects.
author: ardalis
ms.author: wiwagn
ms.date: 10/15/2020
---

# Testing in .NET Core and .NET Standard

.NET Core makes it easy to create tests. This article introduces the concept of testing and illustrates how different kinds of tests can be used to validate code. The linked resources near the bottom of the article show you how to add a test project to your solution. After you set up your test project, you will be able to run your tests using tools, such as the [.NET CLI](../tools/index.md) or Visual Studio.

.NET Core 2.0 and later supports [.NET Standard 2.0](../../standard/net-standard.md), and it is used to demonstrate unit tests in this article. You can use built-in .NET Core 2.0 and later unit test project templates for C#, F#, and Visual Basic as a starting point for your project.

## Test definitions

Having automated tests is a great way to ensure a software application does what its authors intend it to do. There are multiple types of tests for software applications. These include integration tests, load tests, and others. Below are some brief definitions for a few types of unit tests.

### Unit tests

A *unit test* is a test that exercises individual software components or methods, also known as "unit of work". Unit tests should only test code within the developer's control. They do not test infrastructure concerns. Infrastructure concerns include interacting with databases, file systems, and network resources.

For more information on creating unit tests, see [Testing tools](#testing-tools).

### Integration tests

An *integration test* differs from a unit test, in that it exercises two or more software components' ability to function together, also known as their "integration". These tests operate on a much more broad spectrum of the system under test, whereas unit tests hyper-focus on individual components.

### Load tests

A *load test* aims to determine whether or not a system can handle a specified load, for example, the number of concurrent users consuming an application and the app's ability to handle interactions responsively.

## Test methodologies

Also, keep in mind there are best practices for writing tests. For example, [Test Driven Development (TDD)](https://deviq.com/test-driven-development) is when a unit test is written before the code it's meant to check. TDD is like creating an outline for a book before you write it. It is meant to help developers write simpler, more readable, and efficient code.

> [!NOTE]
> The ASP.NET team follows [these conventions](https://github.com/dotnet/aspnetcore/wiki/Engineering-guidelines#unit-tests-and-functional-tests) to help developers come up with good names for test classes and methods.

Try not to introduce dependencies on infrastructure when writing unit tests. These make the tests slow and brittle and should be reserved for integration tests. You can avoid these dependencies in your application by following the [Explicit Dependencies Principle](https://deviq.com/explicit-dependencies-principle) and using [Dependency Injection](/aspnet/core/fundamentals/dependency-injection). You can also keep your unit tests in a separate project from your integration tests. This ensures your unit test project doesn't have references to or dependencies on infrastructure packages.

## Testing tools

.NET is a multi-language ecosystem, and you can write various test types for [C#](../../csharp/index.yml), [F#](../../fsharp/index.yml), and [Visual Basic](../../visual-basic/index.yml). For each of these languages, you can choose between several test frameworks.

### xUnit

[xUnit](https://xunit.net) is a free, open source, community-focused unit testing tool for the .NET. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing C#, F#, VB.NET, and other .NET languages. xUnit.net works with ReSharper, CodeRush, TestDriven.NET, and [Xamarin](/apps/xamarin). It is part of the [.NET Foundation](https://dotnetfoundation.org), and operates under their code of conduct.

You can create tests with xUnit using the .NET Core in [C#](unit-testing-with-dotnet-test.md), [F#](unit-testing-fsharp-with-dotnet-test.md), and [Visual Basic](unit-testing-visual-basic-with-dotnet-test.md).

### NUnit

[NUnit](https://nunit.org) is a unit-testing framework for all .NET languages. Initially ported from JUnit, the current production release has been rewritten with many new features and support for a wide range of .NET platforms. It is part of the [.NET Foundation](https://dotnetfoundation.org).

You can create tests with NUnit using the .NET Core in [C#](unit-testing-with-nunit.md), [F#](unit-testing-fsharp-with-nunit.md), and [Visual Basic](unit-testing-visual-basic-with-nunit.md).

### MSTest

[MSTest](https://github.com/Microsoft/testfx-docs) is the Microsoft test framework for all .NET languages, it's extensible and works with both .NET CLI and Visual Studio. You can create tests with MSTest using the .NET Core in [C#](unit-testing-with-mstest.md), [F#](unit-testing-fsharp-with-mstest.md), and [Visual Basic](unit-testing-visual-basic-with-mstest.md).

## See also

You can learn more in the following articles:

- [Live Unit Testing](/visualstudio/test/live-unit-testing)
- [Code coverage](https://github.com/Microsoft/vstest-docs/blob/master/docs/analyze.md#working-with-code-coverage)
- [Running selective unit tests](selective-unit-tests.md)
- [Including and excluding tests with Visual Studio](/visualstudio/test/live-unit-testing#include-and-exclude-test-projects-and-test-methods)
- [How to use xUnit with .NET Core and Visual Studio](https://xunit.github.io/docs/getting-started-dotnet-core.html)
- [Integration tests in ASP.NET Core](/aspnet/core/test/integration-tests#test-app-prerequisites)
