---
title: Unit testing in .NET Core using dotnet test and MSTes
description: Learn unit test concepts in .NET Core through an interactive experience building a sample visual basic solution step-by-step using MSTest.
author: billwagner
ms.author: wiwagn
ms.date: 09/01/2017
ms.topic: article
ms.prod: .net-core
---
# Unit testing Visual Basic .NET Core libraries using dotnet test and MStest

This tutorial takes you through an interactive experience building a sample solution step-by-step to learn unit testing concepts. If you prefer to follow the tutorial using a pre-built solution, [view or download the sample code](https://github.com/dotnet/docs/tree/master/samples/core/getting-started/unit-testing-using-mstest/) before you begin. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples).

## Creating the source project

Open a shell window. Create a directory called *unit-testing-using-dotnet-test* to hold the solution.
Inside this new directory, run [`dotnet new sln`](../tools/dotnet-new.md) to create a new solution. This
makes it easier to manage both the class library and the unit test project.
Inside the solution directory, create a *PrimeService* directory. The directory structure thus far is shown below:

```
/unit-testing-using-mstest
    unit-testing-using-mstest.sln
    /PrimeService
```

Make *PrimeService* the current directory and run [`dotnet new classlib -lang VB`](../tools/dotnet-new.md) to create the source project. Rename *Class1.VB* to *PrimeService.VB*. To use test-driven development (TDD), you'll create a failing implementation of the `PrimeService` class:

```vb
Imports System

Namespace Prime.Services
    Public Class PrimeService
        Public Function IsPrime(candidate As Integer) As Boolean
            Throw New NotImplementedException("Please create a test first")
        End Function
    End Class
End Namespace
```

## Creating the test project

Change the directory back to the *unit-testing-using-dotnet-test* directory. Run [`dotnet sln add .\PrimeService\PrimeService.vbproj`](../tools/dotnet-sln.md)
to add the class library project to the solution. Next, create the *PrimeService.Tests* directory. The following outline shows the directory structure:

```
/unit-testing-using-mstest
    unit-testing-using-mstest.sln
    /PrimeService
        Source Files
        PrimeService.vbproj
    /PrimeService.Tests
```

Make the *PrimeService.Tests* directory the current directory and create a new project using [`dotnet new mstest -lang VB`](../tools/dotnet-new.md). This creates a test project that uses xUnit as the test library. The generated template configures the test runner in the *PrimeServiceTests.vbproj*:

```xml
<ItemGroup>
<PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.3.0-preview-20170628-02" />
<PackageReference Include="MSTest.TestAdapter" Version="1.1.18" />
<PackageReference Include="MSTest.TestFramework" Version="1.1.18" />
</ItemGroup>
```

The test project requires other packages to create and run unit tests. `dotnet new` in the previous step added xUnit and the xUnit runner. Now, add the `PrimeService` class library as another dependency to the project. Use the [`dotnet add reference`](../tools/dotnet-add-reference.md) command:

```
dotnet add reference ../PrimeService/PrimeService.vbproj
```

Another option is to edit the *PrimeService.Tests.vbproj* file. Directly under the first `<ItemGroup>` node, add another `<ItemGroup>` node with a reference to the library project:

```xml
<ItemGroup>
  <ProjectReference Include="..\PrimeService\PrimeService.vbproj" />
</ItemGroup>
```

You can see the entire file in the [samples repository](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-vb-using-mstest/PrimeService.Tests/PrimeService.Tests.vbproj) on GitHub.

The following shows the final solution layout:

```
/unit-testing-using-mstest
    unit-testing-using-mstest.sln
    /PrimeService
        Source Files
        PrimeService.vbproj
    /PrimeService.Tests
        Test Source Files
        PrimeServiceTests.vbproj
```

## Creating the first test

Before building the library or the tests, execute [`dotnet sln add .\PrimeService.Tests\PrimeService.Tests.vbproj`](../tools/dotnet-restore.md) in the *unit-testing-vb-using-mstest* directory. 

The TDD approach calls for writing one failing test, making it pass, then repeating the process. Remove *UnitTest1.vb* from the *PrimeService.Tests* directory and create a new VB file named *PrimeService_IsPrimeShould.VB*. Add the following code:

```vb
Imports Microsoft.VisualStudio.TestTools.UnitTesting

Namespace PrimeService.Tests
    <TestClass>
    Public Class PrimeService_IsPrimeShould
        Private _primeService As Prime.Services.PrimeService = New Prime.Services.PrimeService()

        <TestMethod>
        Sub ReturnFalseGivenValueOf1()
            Dim result As Boolean = _primeService.IsPrime(1)

            Assert.False(result, "1 should not be prime")
        End Sub

    End Class
End Namespace
```

The `<TestClass>` attribute indicates a class that contains tests. The `<TestMethod>` attribute denotes a method as a single test. From the *unit-testing-vb-using-mstest*, execute [`dotnet test`](../tools/dotnet-test.md) to build the tests and the class library and then run the tests. The xUnit test runner contains the program entry point to run your tests. `dotnet test` starts the test runner using the unit test project you've created.

Your test fails. You haven't created the implementation yet. Make this test by writing the simplest code in the `PrimeService` class that works:

```vb
Public Function IsPrime(candidate As Integer) As Boolean
    If candidate = 1 Then
        Return False
    End If
    Throw New NotImplementedException("Please create a test first")
End Function
```

In the *unit-testing-using-dotnet-test* directory, run `dotnet test` again. The `dotnet test` command runs a build for the `PrimeService` project and then for the `PrimeService.Tests` project. After building both projects, it runs this single test. It passes.

## Adding more features

Now that you've made one test pass, it's time to write more. There are a few other simple cases for prime numbers: 0, -1. You could add those cases as new tests with the `<TestMethod>` attribute, but that quickly becomes tedious. There are other xUnit attributes that enable you to write a suite of similar tests.  A `<<DataTestMethod>>` attribute represents a suite of tests that execute the same code but have different input arguments. You can use the `<DataRow>` attribute to specify values for those inputs.

Instead of creating new tests, apply these two attributes to create a single theory. The theory is a method that tests several values less than two, which is the lowest prime number:

[!code-vb[Sample_TestCode](../../../samples/core/getting-started/unit-testing-vb-using-mstest/PrimeService.Tests/PrimeService_IsPrimeShould.vb?name=Sample_TestCode)]

Run `dotnet test`, and two of these tests fail. To make all of the tests pass, change the `if` clause at the beginning of the method:

```vb
if candidate < 2
```

Continue to iterate by adding more tests, more theories, and more code in the main library. You'll have the [finished version of the tests](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-vb-using-mstest/PrimeService.Tests/PrimeService_IsPrimeShould.vb) and the [complete implementation of the library](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-vb-using-mstest/PrimeService/PrimeService.vb).

You've built a small library and a set of unit tests for that library. You've structured the solution so that adding new packages and tests is seamless. You concentrate most of your time and effort on solving the goals of the application.
