---
title: Unit testing C# with NUnit and .NET Core
description: Learn unit test concepts in C# and .NET Core through an interactive experience building a sample solution step-by-step using dotnet test and NUnit.
author: rprouse
ms.date: 08/31/2018
ms.custom: "seodec18"
---
# Unit testing C# with NUnit and .NET Core

This tutorial takes you through an interactive experience building a sample solution step-by-step to learn unit testing concepts. If you prefer to follow the tutorial using a pre-built solution, [view or download the sample code](https://github.com/dotnet/samples/blob/master/core/getting-started/unit-testing-using-nunit/) before you begin. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples).

## Prerequisites

- [.NET Core 2.1 SDK](https://www.microsoft.com/net/download) or later versions.
- A text editor or code editor of your choice.

## Creating the source project

Open a shell window. Create a directory called *unit-testing-using-nunit* to hold the solution. Inside this new directory, run the following command to create a new solution file for the class library and the test project:

```console
dotnet new sln
```
 
Next, create a *PrimeService* directory. The following outline shows the directory and file structure so far:

```
/unit-testing-using-nunit
    unit-testing-using-nunit.sln
    /PrimeService
```

Make *PrimeService* the current directory and run the following command to create the source project:

```console
dotnet new classlib
```

Rename *Class1.cs* to *PrimeService.cs*. You create a failing implementation of the `PrimeService` class:

```csharp
using System;

namespace Prime.Services
{
    public class PrimeService
    {
        public bool IsPrime(int candidate)
        {
            throw new NotImplementedException("Please create a test first");
        }
    }
}
```

Change the directory back to the *unit-testing-using-nunit* directory. Run the following command to add the class library project to the solution:

```console
dotnet sln add PrimeService/PrimeService.csproj
```

## Creating the test project

Next, create the *PrimeService.Tests* directory. The following outline shows the directory structure:

```
/unit-testing-using-nunit
    unit-testing-using-nunit.sln
    /PrimeService
        Source Files
        PrimeService.csproj
    /PrimeService.Tests
```

Make the *PrimeService.Tests* directory the current directory and create a new project using the following command:

```console
dotnet new nunit
```

The [dotnet new](../tools/dotnet-new.md) command creates a test project that uses NUnit as the test library. The generated template configures the test runner in the *PrimeService.Tests.csproj* file:

[!code-xml[Packages](~/samples/core/getting-started/unit-testing-using-nunit/PrimeService.Tests/PrimeService.Tests.csproj#Packages)]

The test project requires other packages to create and run unit tests. `dotnet new` in the previous step added the Microsoft test SDK, the NUnit test framework, and the NUnit test adapter. Now, add the `PrimeService` class library as another dependency to the project. Use the [`dotnet add reference`](../tools/dotnet-add-reference.md) command:

```console
dotnet add reference ../PrimeService/PrimeService.csproj
```

You can see the entire file in the [samples repository](https://github.com/dotnet/samples/blob/master/core/getting-started/unit-testing-using-nunit/PrimeService.Tests/PrimeService.Tests.csproj) on GitHub.

The following outline shows the final solution layout:

```
/unit-testing-using-nunit
    unit-testing-using-nunit.sln
    /PrimeService
        Source Files
        PrimeService.csproj
    /PrimeService.Tests
        Test Source Files
        PrimeService.Tests.csproj
```

Execute the following command in the *unit-testing-using-nunit* directory:

```console
dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj
```

## Creating the first test

You write one failing test, make it pass, then repeat the process. In the *PrimeService.Tests* directory, rename the *UnitTest1.cs* file to *PrimeService_IsPrimeShould.cs* and replace its entire contents with the following code:

```csharp
using NUnit.Framework;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    [TestFixture]
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [Test]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _primeService.IsPrime(1);

            Assert.IsFalse(result, "1 should not be prime");
        }
    }
}
```

The `[TestFixture]` attribute denotes a class that contains unit tests. The `[Test]` attribute indicates a method is a test method.

Save this file and execute [`dotnet test`](../tools/dotnet-test.md) to build the tests and the class library and then run the tests. The NUnit test runner contains the program entry point to run your tests. `dotnet test` starts the test runner using the unit test project you've created.

Your test fails. You haven't created the implementation yet. Make this test pass by writing the simplest code in the `PrimeService` class that works:

```csharp
public bool IsPrime(int candidate)
{
    if (candidate == 1)
    {
        return false;
    }
    throw new NotImplementedException("Please create a test first");
}
```

In the *unit-testing-using-nunit* directory, run `dotnet test` again. The `dotnet test` command runs a build for the `PrimeService` project and then for the `PrimeService.Tests` project. After building both projects, it runs this single test. It passes.

## Adding more features

Now that you've made one test pass, it's time to write more. There are a few other simple cases for prime numbers: 0, -1. You could add new tests with the `[Test]` attribute, but that quickly becomes tedious. There are other NUnit attributes that enable you to write a suite of similar tests.  A `[TestCase]` attribute is used to create a suite of tests that execute the same code but have different input arguments. You can use the `[TestCase]` attribute to specify values for those inputs.

Instead of creating new tests, apply this attribute to create a single data driven test. The data driven test is a method that tests several values less than two, which is the lowest prime number:

[!code-csharp[Sample_TestCode](../../../samples/core/getting-started/unit-testing-using-nunit/PrimeService.Tests/PrimeService_IsPrimeShould.cs?name=Sample_TestCode)]

Run `dotnet test`, and two of these tests fail. To make all of the tests pass, change the `if` clause at the beginning of the `Main` method in the *PrimeService.cs* file:

```csharp
if (candidate < 2)
```

Continue to iterate by adding more tests, more theories, and more code in the main library. You have the [finished version of the tests](https://github.com/dotnet/samples/blob/master/core/getting-started/unit-testing-using-nunit/PrimeService.Tests/PrimeService_IsPrimeShould.cs) and the [complete implementation of the library](https://github.com/dotnet/samples/blob/master/core/getting-started/unit-testing-using-nunit/PrimeService/PrimeService.cs).

You've built a small library and a set of unit tests for that library. You've structured the solution so that adding new packages and tests is part of the normal workflow. You've concentrated most of your time and effort on solving the goals of the application.
