---
title: Unit testing Visual Basic in .NET with dotnet test and TUnit
description: Learn unit test concepts in .NET through an interactive experience building a sample Visual Basic solution step-by-step using dotnet test and TUnit.
author: thomhurst
ms.author: wiwagn
ms.date: 11/03/2026
ai-usage: ai-assisted
---
# Unit testing Visual Basic .NET libraries using dotnet test and TUnit

This tutorial takes you through an interactive experience building a sample solution step-by-step to learn unit testing concepts.

[!INCLUDE [testing an ASP.NET Core project from .NET Core](../../../includes/core-testing-note-aspnet.md)]

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) or later versions.
- A text editor or code editor of your choice.

TUnit is built entirely on [Microsoft.Testing.Platform (MTP)](microsoft-testing-platform-intro.md) and doesn't support VSTest. This tutorial uses the MTP mode of `dotnet test`, which requires the .NET 10 SDK.

## Creating the source project

Open a shell window. Create a directory called *unit-testing-vb-tunit* to hold the solution. Inside this new directory, run the following command to create a new solution file for the class library and the test project:

```dotnetcli
dotnet new sln
```

Next, create a *PrimeService* directory. The following outline shows the file structure so far:

```console
/unit-testing-vb-tunit
    unit-testing-vb-tunit.slnx
    /PrimeService
```

Make *PrimeService* the current directory and run the following command to create the source project:

```dotnetcli
dotnet new classlib -lang VB
```

Rename *Class1.vb* to *PrimeService.vb*. You create a failing implementation of the `PrimeService` class:

```vb
Namespace Prime.Services
    Public Class PrimeService
        Public Function IsPrime(candidate As Integer) As Boolean
            Throw New NotImplementedException("Please create a test first.")
        End Function
    End Class
End Namespace
```

Change the directory back to the *unit-testing-vb-tunit* directory. Run the following command to add the class library project to the solution:

```dotnetcli
dotnet sln add ./PrimeService/PrimeService.vbproj
```

## Creating the test project

Next, create the *PrimeService.Tests* directory. The following outline shows the directory structure:

```console
/unit-testing-vb-tunit
    unit-testing-vb-tunit.slnx
    /PrimeService
        Source Files
        PrimeService.vbproj
    /PrimeService.Tests
```

The TUnit project templates aren't included in the .NET SDK. Install them with the following command:

```dotnetcli
dotnet new install TUnit.Templates
```

Make the *PrimeService.Tests* directory the current directory and create a new project using the following command:

```dotnetcli
dotnet new TUnit -lang VB
```

> [!NOTE]
> Template short names are case-sensitive. Use `TUnit`, not `tunit`.

The [dotnet new](../tools/dotnet-new.md) command creates a test project that uses TUnit as the test library. The generated *PrimeService.Tests.vbproj* file is an executable project that references the `TUnit` package, which includes the test framework, the assertion library, and the MTP test runner, so the project doesn't need any other test packages.

The template also adds sample tests. Delete all the *.vb* files and the *Data* directory from the *PrimeService.Tests* directory, because this tutorial replaces them with its own tests.

Now, add the `PrimeService` class library as another dependency to the project. Use the [`dotnet reference add`](../tools/dotnet-reference-add.md) command:

```dotnetcli
dotnet reference add ../PrimeService/PrimeService.vbproj
```

You have the following final solution layout:

```console
/unit-testing-vb-tunit
    unit-testing-vb-tunit.slnx
    /PrimeService
        Source Files
        PrimeService.vbproj
    /PrimeService.Tests
        Test Source Files
        PrimeService.Tests.vbproj
```

Execute the following command in the *unit-testing-vb-tunit* directory:

```dotnetcli
dotnet sln add ./PrimeService.Tests/PrimeService.Tests.vbproj
```

## Configuring the MTP mode of dotnet test

Because TUnit doesn't support VSTest, `dotnet test` must run in its MTP mode. In the *unit-testing-vb-tunit* directory, create a *global.json* file with the following content:

```json
{
    "test": {
        "runner": "Microsoft.Testing.Platform"
    }
}
```

For more information, see [MTP mode of dotnet test](unit-testing-with-dotnet-test.md#mtp-mode-of-dotnet-test).

## Creating the first test

You write one failing test, make it pass, then repeat the process. In the *PrimeService.Tests* directory, create a *PrimeService_IsPrimeShould.vb* file with the following code:

```vb
Imports TUnit.Assertions
Imports TUnit.Assertions.Extensions
Imports TUnit.Core

Namespace PrimeService.Tests
    Public Class PrimeService_IsPrimeShould
        Private ReadOnly _primeService As Prime.Services.PrimeService = New Prime.Services.PrimeService()

        <Test>
        Public Async Function IsPrime_InputIs1_ReturnFalse() As Task
            Dim result As Boolean = _primeService.IsPrime(1)

            Await Assert.That(result).IsFalse()
        End Function

    End Class
End Namespace
```

The `<Test>` attribute denotes a method that is run by the test runner. TUnit doesn't need an attribute on the class. TUnit assertions are asynchronous, so the test is an `Async Function` that returns a `Task` and awaits `Assert.That`.

Visual Basic places the code in each project under the project's root namespace, so the `PrimeService` class is in the `PrimeService.Prime.Services` namespace. The test refers to it as `Prime.Services.PrimeService` because, inside the test project's namespaces, the name `PrimeService` refers to a namespace rather than to the class.

From the *unit-testing-vb-tunit* directory, execute [`dotnet test`](../tools/dotnet-test.md) to build the tests and the class library and then run the tests. The TUnit test project contains the program entry point to run your tests. `dotnet test` starts the test application using the unit test project you've created.

Your test fails. You haven't created the implementation yet. Make this test pass by writing the simplest code in the `PrimeService` class that works:

```vb
Public Function IsPrime(candidate As Integer) As Boolean
    If candidate = 1 Then
        Return False
    End If
    Throw New NotImplementedException("Please create a test first.")
End Function
```

In the *unit-testing-vb-tunit* directory, run `dotnet test` again. The `dotnet test` command runs a build for the `PrimeService` project and then for the `PrimeService.Tests` project. After building both projects, it runs this single test. It passes.

## Adding more features

Now that you've made one test pass, it's time to write more. There are a few other simple cases for prime numbers: 0, -1. You could add those cases as new tests with the `<Test>` attribute, but that quickly becomes tedious. TUnit provides the `<Arguments>` attribute to create a suite of tests that execute the same code but have different input arguments.

Instead of creating new tests, apply this attribute to create a single data-driven test. Replace the `IsPrime_InputIs1_ReturnFalse` function with the following code, which tests several values less than two, the lowest prime number:

```vb
<Test>
<Arguments(-1)>
<Arguments(0)>
<Arguments(1)>
Public Async Function IsPrime_ValuesLessThan2_ReturnFalse(value As Integer) As Task
    Dim result As Boolean = _primeService.IsPrime(value)

    Await Assert.That(result).IsFalse()
End Function
```

Run `dotnet test`, and two of these tests fail. To make all of the tests pass, change the `If` clause at the beginning of the `IsPrime` method in the *PrimeService.vb* file:

```vb
If candidate < 2 Then
```

Continue to iterate by adding more tests and more code in the main library.

You've built a small library and a set of unit tests for that library. You've structured the solution so that adding new packages and tests is part of the normal workflow. You've concentrated most of your time and effort on solving the goals of the application.

## See also

- [TUnit documentation](https://tunit.dev/)
- [dotnet reference add](../tools/dotnet-reference-add.md)
- [dotnet test](../tools/dotnet-test.md)
