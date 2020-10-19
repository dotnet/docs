---
title: Testing in .NET
description: This article gives a brief overview of testing concepts, terminology, and tools for testing in .NET.
author: IEvangelist
ms.author: dapine
ms.date: 10/19/2020
---

# Testing in .NET

This article introduces the tools available for testing .NET applications.

## Test types

This article covers unit tests, integration tests, and load tests.

### Unit tests

A *unit test* is a test that exercises individual software components or methods, also known as "unit of work". Unit tests should only test code within the developer's control. They do not test infrastructure concerns. Infrastructure concerns include interacting with databases, file systems, and network resources.

For more information on creating unit tests, see [Testing tools](#testing-tools).

### Integration tests

An *integration test* differs from a unit test in that it exercises two or more software components' ability to function together, also known as their "integration." These tests operate on a broader spectrum of the system under test, whereas unit tests focus on individual components. Often, integration tests do include infrastructure concerns.

### Load tests

A *load test* aims to determine whether or not a system can handle a specified load, for example, the number of concurrent users using an application and the app's ability to handle interactions responsively. For more information on load testing of web applications, see [ASP.NET Core load/stress testing](/aspnet/core/test/load-tests).

## Test considerations

Keep in mind there are [best practices](unit-testing-best-practices.md) for writing tests. For example, [Test Driven Development (TDD)](https://deviq.com/test-driven-development) is when a unit test is written before the code it's meant to check. TDD is like creating an outline for a book before you write it. It is meant to help developers write simpler, more readable, and efficient code.

Try not to introduce dependencies on infrastructure when writing unit tests. These make the tests slow and brittle and should be reserved for integration tests. You can avoid these dependencies in your application by following the [Explicit Dependencies Principle](https://deviq.com/explicit-dependencies-principle) and using [Dependency Injection](../extensions/dependency-injection.md). You can also keep your unit tests in a separate project from your integration tests. This ensures your unit test project doesn't have references to or dependencies on infrastructure packages.

## Testing tools

.NET is a multi-language development platform, and you can write various test types for [C#](../../csharp/index.yml), [F#](../../fsharp/index.yml), and [Visual Basic](../../visual-basic/index.yml). For each of these languages, you can choose between several test frameworks.

### xUnit

[xUnit](https://xunit.net) is a free, open source, community-focused unit testing tool for .NET. Written by the original inventor of NUnit v2, xUnit.net is the latest technology for unit testing .NET apps. xUnit.net works with ReSharper, CodeRush, TestDriven.NET, and [Xamarin](/apps/xamarin). It is a project of the [.NET Foundation](https://dotnetfoundation.org) and operates under their code of conduct.

For more information, see the following resources:

* [Unit testing with C#](unit-testing-with-dotnet-test.md)
* [Unit testing with F#](unit-testing-fsharp-with-dotnet-test.md)
* [Unit testing with Visual Basic](unit-testing-visual-basic-with-dotnet-test.md).

### NUnit

[NUnit](https://nunit.org) is a unit-testing framework for all .NET languages. Initially ported from JUnit, the current production release has been rewritten with many new features and support for a wide range of .NET platforms. It is a project of the [.NET Foundation](https://dotnetfoundation.org).

You can create tests with NUnit using the .NET in [C#](unit-testing-with-nunit.md), [F#](unit-testing-fsharp-with-nunit.md), and [Visual Basic](unit-testing-visual-basic-with-nunit.md).

### MSTest

[MSTest](https://github.com/Microsoft/testfx-docs) is the Microsoft test framework for all .NET languages. It's extensible and works with both .NET CLI and Visual Studio. You can create tests with MSTest in [C#](unit-testing-with-mstest.md), [F#](unit-testing-fsharp-with-mstest.md), and [Visual Basic](unit-testing-visual-basic-with-mstest.md).

## See also

For more information, see the following articles:

- [Code coverage](https://github.com/Microsoft/vstest-docs/blob/master/docs/analyze.md#working-with-code-coverage)
- [How to use xUnit with .NET Core and Visual Studio](https://xunit.github.io/docs/getting-started-dotnet-core.html)
- [Including and excluding tests with Visual Studio](/visualstudio/test/live-unit-testing#include-and-exclude-test-projects-and-test-methods)
- [Integration tests in ASP.NET Core](/aspnet/core/test/integration-tests#test-app-prerequisites)
- [Live Unit Testing](/visualstudio/test/live-unit-testing)
- [Running selective unit tests](selective-unit-tests.md)
