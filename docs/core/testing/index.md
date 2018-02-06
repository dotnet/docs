---
title: Unit Testing in .NET Core
description: Unit testing has never been easier. See how to use unit testing in .NET Core and .NET Standard projects.
keywords: .NET, .NET Core, .NET Standard, unit testing
author: ardalis
ms.author: wiwagn
ms.date: 08/30/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 815ac74c-4bd9-4a94-a87c-78288b27c0e2
ms.workload: 
  - dotnetcore
---

# Unit Testing in .NET Core and .NET Standard

.NET Core has been designed with testability in mind, so that creating unit tests for your applications is easier than ever before. This article briefly introduces unit tests (and how they differ from other kinds of tests). Linked resources demonstrate how to add a test project to your solution and then run unit tests using either the command line or Visual Studio.

.NET Core 2.0 supports [.NET Standard 2.0](../../standard/net-standard.md). The libraries used to demonstrate unit testing in this section rely on .NET Standard and will work in other project types as well.

Beginning with .NET Core 2.0, there are unit test project templates for Visual Basic and F# as well as C#.

## Getting Started with Testing

Having a suite of automated tests is one of the best ways to ensure a software application does what its authors intended it to do. There are different kinds of tests for software applications, including integration tests, web tests, load tests, and others. Unit tests that test individual software components or methods are the lowest level tests. Unit tests should only test code within the developer’s control, and should not test infrastructure concerns, like databases, file systems, or network resources. Unit tests may be written using [Test Driven Development (TDD)](http://deviq.com/test-driven-development/), or they can be added to existing code to confirm its correctness. In either case, they should be small, well-named, and fast, since ideally you want to be able to run hundreds of them before pushing your changes into the project’s shared code repository.

> [!NOTE]
> Developers often struggle with coming up with good names for their test classes and methods. As a starting point, the ASP.NET product team follows [these conventions](https://github.com/aspnet/Home/wiki/Engineering-guidelines#unit-tests-and-functional-tests).

When writing unit tests, be careful you don’t accidentally introduce dependencies on infrastructure. These tend to make tests slower and more brittle, and thus should be reserved for integration tests. You can avoid these hidden dependencies in your application code by following the [Explicit Dependencies Principle](http://deviq.com/explicit-dependencies-principle/) and using [Dependency Injection](/aspnet/core/fundamentals/dependency-injection) to request your dependencies from the framework. You can also keep your unit tests in a separate project from your integration tests, and ensure your unit test project doesn’t have references to or dependencies on infrastructure packages.

Learn more about unit testing in .NET Core projects:

Unit Test projects for .NET Core are supported for [C#](../../csharp/index.md), [F#](../../fsharp/index.md) and [Visual Basic](../../visual-basic/index.md). You can also choose between [xUnit](http://xunit.github.io), [NUnit](http://nunit.org) and [MSTest](https://github.com/Microsoft/vstest-docs).

You can read about those combinations in these walkthroughs:

* Create unit tests using [*XUnit* and *C#* with the .NET Core CLI](unit-testing-with-dotnet-test.md).
* Create unit tests using [*NUnit* and *C#* with the .NET Core CLI](unit-testing-with-nunit.md).
* Create unit tests using [*MSTest* and *C#* with the .NET Core CLI](unit-testing-with-mstest.md).
* Create unit tests using [*XUnit* and *F#* with the .NET Core CLI](unit-testing-fsharp-with-dotnet-test.md).
* Create unit tests using [*NUnit* and *F#* with the .NET Core CLI](unit-testing-fsharp-with-nunit.md).
* Create unit tests using [*MSTest* and *F#* with the .NET Core CLI](unit-testing-fsharp-with-mstest.md).
* Create unit tests using [*XUnit* and *Visual Basic* with the .NET Core CLI](unit-testing-visual-basic-with-dotnet-test.md).
* Create unit tests using [*NUnit* and *Visual Basic* with the .NET Core CLI](unit-testing-visual-basic-with-nunit.md).
* Create unit tests using [*MSTest* and *Visual Basic* with the .NET Core CLI](unit-testing-visual-basic-with-mstest.md).

You can choose different languages for your class libraries and your unit test libraries. You can learn how by mixing and matching the walkthroughs referenced above.

* Visual Studio Enterprise offers great testing tools for .NET Core. Check out [Live Unit Testing](/visualstudio/test/live-unit-testing) or [code coverage](https://github.com/Microsoft/vstest-docs/blob/master/docs/analyze.md#working-with-code-coverage) to learn more.
* For additional information and examples on how to use selective unit test filtering, see [Running selective unit tests](selective-unit-tests.md), or [including and excluding tests with Visual Studio](/visualstudio/test/live-unit-testing#including-and-excluding-test-projects-and-test-methods).
* The XUnit team has written a tutorial that shows
[how to use xUnit with .NET Core and Visual Studio](http://xunit.github.io/docs/getting-started-dotnet-core.html).
