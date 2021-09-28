---
title: Unit testing Visual Basic in .NET Core with dotnet test and xUnit
description: Learn unit test concepts in .NET Core through an interactive experience building a sample Visual Basic solution step-by-step using dotnet test and xUnit.
author: billwagner
ms.author: wiwagn
ms.date: 05/18/2020
---
# Unit testing Visual Basic .NET Core libraries using dotnet test and xUnit

This tutorial shows how to build a solution containing a unit test project and library project. To follow the tutorial using a pre-built solution, [view or download the sample code](https://github.com/dotnet/samples/tree/main/core/getting-started/unit-testing-using-dotnet-test/). For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#view-and-download-samples).

## Create the solution

In this section, a solution is created that contains the source and test projects. The completed solution has the following directory structure:

```
/unit-testing-using-dotnet-test
    unit-testing-using-dotnet-test.sln
    /PrimeService
        PrimeService.vb
        PrimeService.vbproj
    /PrimeService.Tests
        PrimeService_IsPrimeShould.vb
        PrimeServiceTests.vbproj
```

The following instructions provide the steps to create the test solution. See [Commands to create test solution](#create-test-cmd) for instructions to create the test solution in one step.

* Open a shell window.
* Run the following command:

  ```dotnetcli
  dotnet new sln -o unit-testing-using-dotnet-test
  ```

  The [`dotnet new sln`](../tools/dotnet-new.md) command creates a new solution in the *unit-testing-using-dotnet-test* directory.
* Change directory to the *unit-testing-using-dotnet-test* folder.
* Run the following command:

  ```dotnetcli
  dotnet new classlib -o PrimeService --lang VB
  ```

   The [`dotnet new classlib`](../tools/dotnet-new.md) command creates a new class library project  in the *PrimeService* folder. The new class library will contain the code to be tested.
* Rename *Class1.vb* to *PrimeService.vb*.
* Replace the code in *PrimeService.vb* with the following code:
  
  ```vb
  Imports System
  
  Namespace Prime.Services
      Public Class PrimeService
          Public Function IsPrime(candidate As Integer) As Boolean
              Throw New NotImplementedException("Not implemented.")
          End Function
      End Class
  End Namespace
  ```

* The preceding code:
  * Throws a <xref:System.NotImplementedException> with a message indicating it's not implemented.
  * Is updated later in the tutorial.

<!-- preceding code shows an english bias. Message makes no sense outside english -->

* In the *unit-testing-using-dotnet-test* directory, run the following command to add the class library project to the solution:

  ```dotnetcli
  dotnet sln add ./PrimeService/PrimeService.vbproj
  ```

* Create the *PrimeService.Tests* project by running the following command:

  ```dotnetcli
  dotnet new xunit -o PrimeService.Tests
  ```

* The preceding command:
  * Creates the *PrimeService.Tests* project in the *PrimeService.Tests* directory. The test project uses [xUnit](https://xunit.net/) as the test library.
  * Configures the test runner by adding the following `<PackageReference />`elements to the project file:
    * "Microsoft.NET.Test.Sdk"
    * "xunit"
    * "xunit.runner.visualstudio"

* Add the test project to the solution file by running the following command:

  ```dotnetcli
  dotnet sln add ./PrimeService.Tests/PrimeService.Tests.vbproj
  ```

* Add the `PrimeService` class library as a dependency to the *PrimeService.Tests* project:

  ```dotnetcli
  dotnet add ./PrimeService.Tests/PrimeService.Tests.vbproj reference ./PrimeService/PrimeService.vbproj  
  ```

<a name="create-test-cmd"></a>

### Commands to create the solution

This section summarizes all the commands in the previous section. Skip this section if you've completed the steps in the previous section.

The following commands create the test solution on a windows machine. For macOS and Unix, update the `ren` command to the OS version of `ren` to rename a file:

```dotnetcli
dotnet new sln -o unit-testing-using-dotnet-test
cd unit-testing-using-dotnet-test
dotnet new classlib -o PrimeService
ren .\PrimeService\Class1.vb PrimeService.vb
dotnet sln add ./PrimeService/PrimeService.vbproj
dotnet new xunit -o PrimeService.Tests
dotnet add ./PrimeService.Tests/PrimeService.Tests.vbproj reference ./PrimeService/PrimeService.vbproj
dotnet sln add ./PrimeService.Tests/PrimeService.Tests.vbproj
```

Follow the instructions for "Replace the code in *PrimeService.vb* with the following code" in the previous section.

## Create a test

A popular approach in test driven development (TDD) is to write a test before implementing the target code. This tutorial uses the TDD approach. The `IsPrime` method is callable, but not implemented. A test call to `IsPrime` fails. With TDD, a test is written that is known to fail. The target code is updated to make the test pass. You keep repeating this approach, writing a failing test and then updating the target code to pass.

Update the *PrimeService.Tests* project:

* Delete *PrimeService.Tests/UnitTest1.vb*.
* Create a *PrimeService.Tests/PrimeService_IsPrimeShould.vb*  file.
* Replace the code in *PrimeService_IsPrimeShould.vb* with the following code:

```vb
Imports Xunit

Namespace PrimeService.Tests
    Public Class PrimeService_IsPrimeShould
        Private ReadOnly _primeService As Prime.Services.PrimeService

        Public Sub New()
            _primeService = New Prime.Services.PrimeService()
        End Sub


        <Fact>
        Sub IsPrime_InputIs1_ReturnFalse()
            Dim result As Boolean = _primeService.IsPrime(1)

            Assert.False(result, "1 should not be prime")
        End Sub

    End Class
End Namespace
```

The `[Fact]` attribute declares a test method that's run by the test runner. From the *PrimeService.Tests* folder, run `dotnet test`. The [dotnet test](../tools/dotnet-test.md) command builds both projects and runs the tests. The xUnit test runner contains the program entry point to run the tests. `dotnet test` starts the test runner using the unit test project.

The test fails because `IsPrime` hasn't been implemented. Using the TDD approach, write only enough code so this test passes. Update `IsPrime` with the following code:

```vb
Public Function IsPrime(candidate As Integer) As Boolean
    If candidate = 1 Then
        Return False
    End If
    Throw New NotImplementedException("Not implemented.")
End Function
```

Run `dotnet test`. The test passes.

### Add more tests

Add prime number tests for 0 and -1. You could copy the preceding test and change the following code to use 0 and -1:

```vb
Dim result As Boolean = _primeService.IsPrime(1)

Assert.False(result, "1 should not be prime")
```

Copying test code when only a parameter changes results in code duplication and test bloat. The following xUnit attributes enable writing a suite of similar tests:

- `[Theory]` represents a suite of tests that execute the same code but have different input arguments.
- `[InlineData]` attribute specifies values for those inputs.

Rather than creating new tests, apply the preceding xUnit attributes to create a single theory. Replace the following code:

```vb
<Fact>
Sub IsPrime_InputIs1_ReturnFalse()
    Dim result As Boolean = _primeService.IsPrime(1)

    Assert.False(result, "1 should not be prime")
End Sub
```

with the following code:

```vb
<Theory>
<InlineData(-1)>
<InlineData(0)>
<InlineData(1)>
Sub IsPrime_ValuesLessThan2_ReturnFalse(ByVal value As Integer)
    Dim result As Boolean = _primeService.IsPrime(value)

    Assert.False(result, $"{value} should not be prime")
End Sub
```

In the preceding code, `[Theory]` and `[InlineData]` enable testing several values less than two. Two is the smallest prime number.

Run `dotnet test`, two of the tests fail. To make all of the tests pass, update the `IsPrime` method with the following code:

```vb
Public Function IsPrime(candidate As Integer) As Boolean
    If candidate < 2 Then
        Return False
    End If
    Throw New NotImplementedException("Not fully implemented.")
End Function
```

Following the TDD approach, add more failing tests, then update the target code. See the [finished version of the tests](https://github.com/dotnet/samples/blob/main/core/getting-started/unit-testing-vb-dotnet-test/PrimeService.Tests/PrimeService_IsPrimeShould.vb) and the [complete implementation of the library](https://github.com/dotnet/samples/blob/main/core/getting-started/unit-testing-vb-dotnet-test/PrimeService/PrimeService.vb).

The completed `IsPrime` method is not an efficient algorithm for testing primality.

### Additional resources

- [xUnit.net official site](https://xunit.net/)
- [Testing controller logic in ASP.NET Core](/aspnet/core/mvc/controllers/testing)
- [`dotnet add reference`](../tools/dotnet-add-reference.md)
