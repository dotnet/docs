---
title: Unit testing C# code in .NET using dotnet test and TUnit
description: Learn unit test concepts in C# and .NET through an interactive experience building a sample solution step-by-step using dotnet test and TUnit.
author: thomhurst
ms.author: wiwagn
ms.date: 11/22/2025
ai-usage: ai-assisted
---
# Unit testing C# in .NET using dotnet test and TUnit

This tutorial shows how to build a solution containing a unit test project and source code project step-by-step.

[!INCLUDE [testing an ASP.NET Core project from .NET](../../../includes/core-testing-note-aspnet.md)]

## Prerequisites

TUnit is built entirely on [Microsoft.Testing.Platform](microsoft-testing-platform-intro.md) and does not support VSTest.

## Create the solution

In this section, a solution is created that contains the source and test projects. The completed solution has the following directory structure:

```txt
/unit-testing-using-dotnet-test
    unit-testing-using-dotnet-test.sln
    /PrimeService
        PrimeService.cs
        PrimeService.csproj
    /PrimeService.Tests
        PrimeService_IsPrimeShould.cs
        PrimeServiceTests.csproj
```

The following instructions provide the steps to create the test solution. See [Commands to create test solution](#commands-to-create-the-solution) for instructions to create the test solution in one step.

* Open a shell window.
* Run the following command:

  ```dotnetcli
  dotnet new sln -o unit-testing-using-dotnet-test
  ```

  The [`dotnet new sln`](../tools/dotnet-new.md) command creates a new solution in the *unit-testing-using-dotnet-test* directory.
* Change directory to the *unit-testing-using-dotnet-test* folder.
* Run the following command:

  ```dotnetcli
  dotnet new classlib -o PrimeService
  ```

   The [`dotnet new classlib`](../tools/dotnet-new.md) command creates a new class library project in the *PrimeService* folder. The new class library will contain the code to be tested.
* Rename *Class1.cs* to *PrimeService.cs*.
* Replace the code in *PrimeService.cs* with the following code:

  ```csharp
  using System;

  namespace Prime.Services
  {
      public class PrimeService
      {
          public bool IsPrime(int candidate)
          {
              throw new NotImplementedException("Not implemented.");
          }
      }
  }
  ```

  Currently this code throws a <xref:System.NotImplementedException>, but you'll implement the method later in the tutorial.

* In the *unit-testing-using-dotnet-test* directory, run the following command to add the class library project to the solution:

  ```dotnetcli
  dotnet sln add ./PrimeService/PrimeService.csproj
  ```

* Install the TUnit project template:

  ```dotnetcli
  dotnet new install TUnit.Templates
  ```

* Create the *PrimeService.Tests* project by running the following command:

  ```dotnetcli
  dotnet new tunit -o PrimeService.Tests
  ```

  The preceding command creates the *PrimeService.Tests* project in the *PrimeService.Tests* directory. The test project uses [TUnit](https://tunit.dev/) as the test library. TUnit uses source generation for test discovery. The template configures the test runner by adding the `TUnit` package to the project file.

* Add the test project to the solution file by running the following command:

  ```dotnetcli
  dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj
  ```

* Add the `PrimeService` class library as a dependency to the *PrimeService.Tests* project:

  ```dotnetcli
  dotnet add ./PrimeService.Tests/PrimeService.Tests.csproj reference ./PrimeService/PrimeService.csproj
  ```

<a name="create-test-cmd"></a>

### Commands to create the solution

This section summarizes all the commands in the previous section. Skip this section if you've completed the steps in the previous section.

The following commands create the test solution on a Windows machine. For macOS and Unix, update the `ren` command to the OS version of `ren` to rename a file:

```dotnetcli
dotnet new sln -o unit-testing-using-dotnet-test
cd unit-testing-using-dotnet-test
dotnet new classlib -o PrimeService
ren .\PrimeService\Class1.cs PrimeService.cs
dotnet sln add ./PrimeService/PrimeService.csproj
dotnet new install TUnit.Templates
dotnet new tunit -o PrimeService.Tests
dotnet add ./PrimeService.Tests/PrimeService.Tests.csproj reference ./PrimeService/PrimeService.csproj
dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj
```

Follow the instructions for "Replace the code in *PrimeService.cs* with the following code" in the previous section.

## Configure Microsoft.Testing.Platform mode

TUnit only supports Microsoft.Testing.Platform and doesn't support VSTest. To use `dotnet test` with TUnit, add the following configuration to your `global.json` file in the solution root:

> [!NOTE]
> This configuration requires .NET 10 SDK or later.

```json
{
    "test": {
        "runner": "Microsoft.Testing.Platform"
    }
}
```

This configuration enables the Microsoft.Testing.Platform mode of `dotnet test`. For more information, see [Testing with dotnet test](unit-testing-with-dotnet-test.md).

## Create a test

A popular approach in test driven development (TDD) is to write a (failing) test before implementing the target code. This tutorial uses the TDD approach. The `IsPrime` method is callable but not implemented. A test call to `IsPrime` fails. With TDD, you write a test that's known to fail. Then you update the target code to make the test pass. You keep repeating this approach, writing a failing test and then updating the target code to pass.

Update the *PrimeService.Tests* project:

* Delete *PrimeService.Tests/UnitTest1.cs*.
* Create a *PrimeService.Tests/PrimeService_IsPrimeShould.cs*  file.
* Replace the code in *PrimeService_IsPrimeShould.cs* with the following code:

  ```csharp
  using TUnit.Assertions;
  using TUnit.Assertions.Extensions;
  using Prime.Services;

  namespace Prime.UnitTests.Services;

  public class PrimeService_IsPrimeShould
  {
      [Test]
      public async Task IsPrime_InputIs1_ReturnFalse()
      {
          var primeService = new PrimeService();
          bool result = primeService.IsPrime(1);

          await Assert.That(result).IsFalse();
      }
  }
  ```

The `[Test]` attribute marks a method as a test that's run by the test runner. TUnit uses source generation to discover tests at compile time.

From the *PrimeService.Tests* folder, run `dotnet test`. The [dotnet test](../tools/dotnet-test.md) command builds both projects and runs the tests. The TUnit test runner uses Microsoft.Testing.Platform to execute the tests.

The test fails because `IsPrime` hasn't been implemented. Using the TDD approach, write only enough code so this test passes. Update `IsPrime` with the following code:

```csharp
public bool IsPrime(int candidate)
{
    if (candidate == 1)
    {
        return false;
    }
    throw new NotImplementedException("Not fully implemented.");
}
```

Run `dotnet test`. The test passes.

### Add more tests

Add prime number tests for 0 and -1. You *could* copy the test created in the preceding step and make copies of the following code to test 0 and -1. But don't do it, as there's a better way.

```csharp
var primeService = new PrimeService();
bool result = primeService.IsPrime(1);

await Assert.That(result).IsFalse();
```

Copying test code when only a parameter changes results in code duplication and test bloat. TUnit provides the `[Arguments]` attribute to specify different input values for the same test logic:

Rather than creating new tests, apply the `[Arguments]` attribute to create parameterized tests. Replace the following code...

```csharp
[Test]
public async Task IsPrime_InputIs1_ReturnFalse()
{
    var primeService = new PrimeService();
    bool result = primeService.IsPrime(1);

    await Assert.That(result).IsFalse();
}
```

...with the following code:

```csharp
[Test]
[Arguments(-1)]
[Arguments(0)]
[Arguments(1)]
public async Task IsPrime_ValuesLessThan2_ReturnFalse(int value)
{
    var primeService = new PrimeService();
    bool result = primeService.IsPrime(value);

    await Assert.That(result).IsFalse();
}
```

In the preceding code, `[Arguments]` enables testing several values less than two. Two is the smallest prime number. Each `[Arguments]` attribute generates a separate test case, and TUnit executes these tests in parallel by default.

Run `dotnet test`, and two of the tests fail. To make all of the tests pass, update the `IsPrime` method with the following code:

```csharp
public bool IsPrime(int candidate)
{
    if (candidate < 2)
    {
        return false;
    }
    throw new NotImplementedException("Not fully implemented.");
}
```

Following the TDD approach, add more failing tests, then update the target code.

The completed `IsPrime` method isn't an efficient algorithm for testing primality.

### Additional resources

* [TUnit official site](https://tunit.dev)
* [TUnit GitHub repository](https://github.com/thomhurst/TUnit)
* [Testing controller logic in ASP.NET Core](/aspnet/core/mvc/controllers/testing)
* [`dotnet reference add`](../tools/dotnet-reference-add.md)
