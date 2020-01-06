---
title: Unit testing in .NET Core and .NET Standard
description: This article gives a brief overview of unit testing for .NET Core and .NET Standard projects.
author: ardalis
ms.author: wiwagn
ms.date: 08/30/2017
---

# Unit testing in .NET Core and .NET Standard

.NET Core makes it easy to create unit tests. This article introduces unit tests and illustrates how they differ from other kinds of tests. The linked resources near the bottom of the page show you how to add a test project to your solution. After you set up your test project, you will be able to run your unit tests using the command line or Visual Studio.

If you're testing an **ASP.NET Core** project, see [Integration tests in ASP.NET Core](/aspnet/core/test/integration-tests#test-app-prerequisites).

.NET Core 2.0 and later supports [.NET Standard 2.0](../../standard/net-standard.md), and we will use its libraries to demonstrate unit tests.

You are able to use built-in .NET Core 2.0 and later unit test project templates for C#, F# and Visual Basic as a starting point for your personal project.

## What are unit tests?

Having automated tests is a great way to ensure a software application does what its authors intend it to do. There are multiple types of tests for software applications. These include integration tests, web tests, load tests, and others. **Unit tests** test individual software components and methods. Unit tests should only test code within the developer’s control. They should not test infrastructure concerns. Infrastructure concerns include databases, file systems, and network resources. 

Also, keep in mind there are best practices for writing tests. For example, [Test Driven Development (TDD)](https://deviq.com/test-driven-development/) is when a unit test is written before the code it is meant to check. TDD is like creating an outline for a book before we write it. It is meant to help developers write simpler, more readable, and efficient code. 

> [!NOTE]
> The ASP.NET team follows [these conventions](https://github.com/aspnet/Home/wiki/Engineering-guidelines#unit-tests-and-functional-tests) to help developers come up with good names for test classes and methods.

Try not to introduce dependencies on infrastructure when writing unit tests. These make the tests slow and brittle, and should be reserved for integration tests. You can avoid these dependencies in your application by following the [Explicit Dependencies Principle](https://deviq.com/explicit-dependencies-principle/) and using [Dependency Injection](/aspnet/core/fundamentals/dependency-injection). You can also keep your unit tests in a separate project from your integration tests. This ensures your unit test project doesn’t have references to or dependencies on infrastructure packages.

## Next steps

More information on unit testing in .NET Core projects:

.NET Core unit test projects are supported for:

- [C#](../../csharp/index.yml)
- [F#](../../fsharp/index.yml)
- [Visual Basic](../../visual-basic/index.yml) 

You can also choose between:

- [xUnit](https://xunit.github.io) 
- [NUnit](https://nunit.org)
- [MSTest](https://github.com/Microsoft/testfx-docs)

You can learn more in the following walkthroughs:

- Create unit tests using [*xUnit* and *C#* with the .NET Core CLI](unit-testing-with-dotnet-test.md).
- Create unit tests using [*NUnit* and *C#* with the .NET Core CLI](unit-testing-with-nunit.md).
- Create unit tests using [*MSTest* and *C#* with the .NET Core CLI](unit-testing-with-mstest.md).
- Create unit tests using [*xUnit* and *F#* with the .NET Core CLI](unit-testing-fsharp-with-dotnet-test.md).
- Create unit tests using [*NUnit* and *F#* with the .NET Core CLI](unit-testing-fsharp-with-nunit.md).
- Create unit tests using [*MSTest* and *F#* with the .NET Core CLI](unit-testing-fsharp-with-mstest.md).
- Create unit tests using [*xUnit* and *Visual Basic* with the .NET Core CLI](unit-testing-visual-basic-with-dotnet-test.md).
- Create unit tests using [*NUnit* and *Visual Basic* with the .NET Core CLI](unit-testing-visual-basic-with-nunit.md).
- Create unit tests using [*MSTest* and *Visual Basic* with the .NET Core CLI](unit-testing-visual-basic-with-mstest.md).

You can learn more in the following articles:

- Visual Studio Enterprise offers great testing tools for .NET Core. Check out [Live Unit Testing](/visualstudio/test/live-unit-testing) or [code coverage](https://github.com/Microsoft/vstest-docs/blob/master/docs/analyze.md#working-with-code-coverage) to learn more.
- For more information on how to run selective unit tests, see [Running selective unit tests](selective-unit-tests.md), or [including and excluding tests with Visual Studio](/visualstudio/test/live-unit-testing#include-and-exclude-test-projects-and-test-methods).
- [How to use xUnit with .NET Core and Visual Studio](https://xunit.github.io/docs/getting-started-dotnet-core.html).
