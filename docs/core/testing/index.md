---
title: Unit Testing in .NET Core
description: Unit Testing in .NET Core
keywords: .NET, .NET Core
author: ardalis
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: 815ac74c-4bd9-4a94-a87c-78288b27c0e2
---

# Unit Testing in .NET Core

.NET Core has been designed with testability in mind, so that creating unit tests for your applications is easier than ever before. This article briefly introduces unit tests (and how they differ from other kinds of tests). Linked resources demonstrates how to add a test project to your solution and then run unit tests using either the command line or Visual Studio.

## Getting Started with Testing
 
Having a suite of automated tests is one of the best ways to ensure a software application does what its authors intended it to do. There are many different kinds of tests for software applications, including integration tests, web tests, load tests, and many others. At the lowest level are unit tests, which test individual software components or methods. Unit tests should only test code within the developer’s control, and should not test infrastructure concerns, like databases, file systems, or network resources. Unit tests may be written using [Test Driven Development (TDD)](http://deviq.com/test-driven-development/), or they can be added to existing code to confirm its correctness. In either case, they should be small, well-named, and fast, since ideally you will want to be able to run hundreds of them before pushing your changes into the project’s shared code repository.

> [!NOTE]
> Developers often struggle with coming up with good names for their test classes and methods. As a starting point, the ASP.NET product team follows [these conventions](https://github.com/aspnet/Home/wiki/Engineering-guidelines#unit-tests-and-functional-tests).

When writing unit tests, be careful you don’t accidentally introduce dependencies on infrastructure. These tend to make tests slower and more brittle, and thus should be reserved for integration tests. You can avoid these hidden dependencies in your application code by following the [Explicit Dependencies Principle](http://deviq.com/explicit-dependencies-principle/) and using [Dependency Injection](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection) to request your dependencies from the framework. You can also keep your unit tests in a separate project from your integration tests, and ensure your unit test project doesn’t have references to or dependencies on infrastructure packages.

Learn more about unit testing in .NET Core projects:

* Try this [walkthrough creating unit tests with xUnit and the .NET CLI](unit-testing-with-dotnet-test.md). 
* The XUnit team has written a tutorial that shows
[how to use xUnit with .NET Core and Visual Studio](http://xunit.github.io/docs/getting-started-dotnet-core.html).
* If you prefer using MSTest, try the [walkthrough creating unit tests with MSTest and the .NET CLI](unit-testing-with-mstest.md).
* For a additional information and examples on how to use selective unit test filtering, see [Running selective unit tests](../testing/selective-unit-tests.md).
