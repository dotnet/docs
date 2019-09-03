---
title: Unit testing Visual Basic in .NET Core with dotnet test and NUnit
description: Learn unit test concepts in .NET Core through an interactive experience building a sample Visual Basic solution step-by-step using NUnit.
author: rprouse
ms.date: 10/04/2018
ms.custom: "seodec18"
---
# Unit testing Visual Basic .NET Core libraries using dotnet test and NUnit

This tutorial takes you through an interactive experience building a sample solution step-by-step to learn unit testing concepts. If you prefer to follow the tutorial using a pre-built solution, [view or download the sample code](https://github.com/dotnet/samples/tree/master/core/getting-started/unit-testing-vb-nunit/) before you begin. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples).

## Prerequisites

- [.NET Core 2.1 SDK](https://www.microsoft.com/net/download) or later versions.
- A text editor or code editor of your choice.

## Creating the source project

Open a shell window. Create a directory called *unit-testing-vb-nunit* to hold the solution. Inside this new directory, run the following command to create a new solution file for the class library and the test project:

```console
dotnet new sln
```

Next, create a *PrimeService* directory. The following outline shows the file structure so far:

```console
/unit-testing-vb-nunit
    unit-testing-vb-nunit.sln
    /PrimeService
```

Make *PrimeService* the current directory and run the following command to create the source project:

```console
dotnet new classlib -lang VB
```

Rename *Class1.VB* to *PrimeService.VB*. You create a failing implementation of the `PrimeService` class:

```vb
Imports System

Namespace Prime.Services
    Public Class PrimeService
        Public Function IsPrime(candidate As Integer) As Boolean
            Throw New NotImplementedException("Please create a test first.")
        End Function
    End Class
End Namespace
```

Change the directory back to the *unit-testing-vb-using-mstest* directory. Run the following command to add the class library project to the solution:

```console
dotnet sln add .\PrimeService\PrimeService.vbproj
```

## Creating the test project

Next, create the *PrimeService.Tests* directory. The following outline shows the directory structure:

```console
/unit-testing-vb-nunit
    unit-testing-vb-nunit.sln
    /PrimeService
        Source Files
        PrimeService.vbproj
    /PrimeService.Tests
```

Make the *PrimeService.Tests* directory the current directory and create a new project using the following command:

```console
dotnet new nunit -lang VB
```

The [dotnet new](../tools/dotnet-new.md) command creates a test project that uses NUnit as the test library. The generated template configures the test runner in the *PrimeServiceTests.vbproj* file:

[!code-xml[Packages](~/samples/core/getting-started/unit-testing-vb-nunit/PrimeService.Tests/PrimeService.Tests.vbproj#Packages)]

The test project requires other packages to create and run unit tests. `dotnet new` in the previous step added NUnit and the NUnit test adapter. Now, add the `PrimeService` class library as another dependency to the project. Use the [`dotnet add reference`](../tools/dotnet-add-reference.md) command:

```console
dotnet add reference ../PrimeService/PrimeService.vbproj
```

You can see the entire file in the [samples repository](https://github.com/dotnet/samples/blob/master/core/getting-started/unit-testing-vb-nunit/PrimeService.Tests/PrimeService.Tests.vbproj) on GitHub.

You have the following final solution layout:

```console
/unit-testing-vb-nunit
    unit-testing-vb-nunit.sln
    /PrimeService
        Source Files
        PrimeService.vbproj
    /PrimeService.Tests
        Test Source Files
        PrimeService.Tests.vbproj
```

Execute the following command in the *unit-testing-vb-nunit* directory:

```console
dotnet sln add .\PrimeService.Tests\PrimeService.Tests.vbproj
```

## Creating the first test

You write one failing test, make it pass, then repeat the process. In the *PrimeService.Tests* directory, rename the *UnitTest1.vb* file to *PrimeService_IsPrimeShould.VB* and replace its entire contents with the following code:

```vb
Imports NUnit.Framework

Namespace PrimeService.Tests
    <TestFixture>
    Public Class PrimeService_IsPrimeShould
        Private _primeService As Prime.Services.PrimeService = New Prime.Services.PrimeService()

        <Test>
        Sub IsPrime_InputIs1_ReturnFalse()
            Dim result As Boolean = _primeService.IsPrime(1)

            Assert.False(result, "1 should not be prime")
        End Sub

    End Class
End Namespace
```

The `<TestFixture>` attribute indicates a class that contains tests. The `<Test>` attribute denotes a method that is run by the test runner. From the *unit-testing-vb-nunit*, execute [`dotnet test`](../tools/dotnet-test.md) to build the tests and the class library and then run the tests. The NUnit test runner contains the program entry point to run your tests. `dotnet test` starts the test runner using the unit test project you've created.

Your test fails. You haven't created the implementation yet. Make this test pass by writing the simplest code in the `PrimeService` class that works:

```vb
Public Function IsPrime(candidate As Integer) As Boolean
    If candidate = 1 Then
        Return False
    End If
    Throw New NotImplementedException("Please create a test first.")
End Function
```

In the *unit-testing-vb-nunit* directory, run `dotnet test` again. The `dotnet test` command runs a build for the `PrimeService` project and then for the `PrimeService.Tests` project. After building both projects, it runs this single test. It passes.

## Adding more features

Now that you've made one test pass, it's time to write more. There are a few other simple cases for prime numbers: 0, -1. You could add those cases as new tests with the `<Test>` attribute, but that quickly becomes tedious. There are other xUnit attributes that enable you to write a suite of similar tests.  A `<TestCase>` attribute represents a suite of tests that execute the same code but have different input arguments. You can use the `<TestCase>` attribute to specify values for those inputs.

Instead of creating new tests, apply these two attributes to create a series of tests that test several values less than two, which is the lowest prime number:

[!code-vb[Sample_TestCode](../../../samples/core/getting-started/unit-testing-vb-nunit/PrimeService.Tests/PrimeService_IsPrimeShould.vb?name=Sample_TestCode)]

Run `dotnet test`, and two of these tests fail. To make all of the tests pass, change the `if` clause at the beginning of the `Main` method in the *PrimeServices.cs* file:

```vb
if candidate < 2
```

Continue to iterate by adding more tests, more theories, and more code in the main library. You have the [finished version of the tests](https://github.com/dotnet/samples/blob/master/core/getting-started/unit-testing-vb-nunit/PrimeService.Tests/PrimeService_IsPrimeShould.vb) and the [complete implementation of the library](https://github.com/dotnet/samples/blob/master/core/getting-started/unit-testing-vb-nunit/PrimeService/PrimeService.vb).

You've built a small library and a set of unit tests for that library. You've structured the solution so that adding new packages and tests is part of the normal workflow. You've concentrated most of your time and effort on solving the goals of the application.
