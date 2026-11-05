---
title: Unit testing C# with TUnit and .NET
description: Learn unit test concepts in C# and .NET through an interactive experience building a sample solution step-by-step using dotnet test and TUnit.
author: thomhurst
ms.author: wiwagn
ms.date: 11/03/2026
ai-usage: ai-assisted
---
# Unit testing C# with TUnit and .NET

This tutorial takes you through an interactive experience building a sample solution step-by-step to learn unit testing concepts.

[!INCLUDE [testing an ASP.NET Core project from .NET Core](../../../includes/core-testing-note-aspnet.md)]

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) or later versions.
- A text editor or code editor of your choice.

TUnit is built entirely on [Microsoft.Testing.Platform (MTP)](microsoft-testing-platform-intro.md) and doesn't support VSTest. This tutorial uses the MTP mode of `dotnet test`, which requires the .NET 10 SDK.

## Creating the source project

Open a shell window. Create a directory called *unit-testing-using-tunit* to hold the solution. Inside this new directory, run the following command to create a new solution file for the class library and the test project:

```dotnetcli
dotnet new sln
```

Next, create a *PrimeService* directory. The following outline shows the directory and file structure so far:

```console
/unit-testing-using-tunit
    unit-testing-using-tunit.slnx
    /PrimeService
```

Make *PrimeService* the current directory and run the following command to create the source project:

```dotnetcli
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
            throw new NotImplementedException("Please create a test first.");
        }
    }
}
```

Change the directory back to the *unit-testing-using-tunit* directory. Run the following command to add the class library project to the solution:

```dotnetcli
dotnet sln add PrimeService/PrimeService.csproj
```

## Creating the test project

Next, create the *PrimeService.Tests* directory. The following outline shows the directory structure:

```console
/unit-testing-using-tunit
    unit-testing-using-tunit.slnx
    /PrimeService
        Source Files
        PrimeService.csproj
    /PrimeService.Tests
```

The TUnit project templates aren't included in the .NET SDK. Install them with the following command:

```dotnetcli
dotnet new install TUnit.Templates
```

Change the directory to the *PrimeService.Tests* directory and create a new project using the following command:

```dotnetcli
dotnet new TUnit
```

> [!NOTE]
> Template short names are case-sensitive. Use `TUnit`, not `tunit`.

The [dotnet new](../tools/dotnet-new.md) command creates a test project that uses TUnit as the test library. The generated *PrimeService.Tests.csproj* file is an executable project that references the `TUnit` package (the version number might differ):

```xml
<PropertyGroup>
  <ImplicitUsings>enable</ImplicitUsings>
  <Nullable>enable</Nullable>
  <OutputType>Exe</OutputType>
  <TargetFramework>net10.0</TargetFramework>
</PropertyGroup>

<ItemGroup>
  <PackageReference Include="TUnit" Version="1.*" />
</ItemGroup>
```

The `TUnit` package includes the test framework, the assertion library, and the MTP test runner, so the project doesn't need any other test packages. The template also adds sample tests. Delete all the *.cs* files and the *Data* directory from the *PrimeService.Tests* directory, because this tutorial replaces them with its own tests.

Now, add the `PrimeService` class library as another dependency to the project. Use the [`dotnet reference add`](../tools/dotnet-reference-add.md) command:

```dotnetcli
dotnet reference add ../PrimeService/PrimeService.csproj
```

The following outline shows the final solution layout:

```console
/unit-testing-using-tunit
    unit-testing-using-tunit.slnx
    /PrimeService
        Source Files
        PrimeService.csproj
    /PrimeService.Tests
        Test Source Files
        PrimeService.Tests.csproj
```

Execute the following command in the *unit-testing-using-tunit* directory:

```dotnetcli
dotnet sln add ./PrimeService.Tests/PrimeService.Tests.csproj
```

## Configuring the MTP mode of dotnet test

Because TUnit doesn't support VSTest, `dotnet test` must run in its MTP mode. In the *unit-testing-using-tunit* directory, create a *global.json* file with the following content:

```json
{
    "test": {
        "runner": "Microsoft.Testing.Platform"
    }
}
```

For more information, see [MTP mode of dotnet test](unit-testing-with-dotnet-test.md#mtp-mode-of-dotnet-test).

## Creating the first test

You write one failing test, make it pass, and then repeat the process. In the *PrimeService.Tests* directory, create a *PrimeService_IsPrimeShould.cs* file with the following code:

```csharp
namespace Prime.UnitTests.Services
{
    using Prime.Services;

    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService = new();

        [Test]
        public async Task IsPrime_InputIs1_ReturnFalse()
        {
            var result = _primeService.IsPrime(1);

            await Assert.That(result).IsFalse();
        }
    }
}
```

The `[Test]` attribute indicates a method is a test method. TUnit doesn't need an attribute on the class. TUnit assertions are asynchronous, so the test method returns a `Task` and awaits `Assert.That`. The `TUnit` package adds global `using` directives for its namespaces, so the file doesn't need them.

> [!NOTE]
> The `using Prime.Services;` directive is inside the namespace on purpose. MTP generates the test application's entry point in the project's root namespace, `PrimeService.Tests`. That namespace hides the `PrimeService` class from a `using` directive at the top of the file, but not from one inside the namespace.

Save this file and execute the [`dotnet test`](../tools/dotnet-test.md) command to build the tests and the class library and run the tests. The TUnit test project contains the program entry point to run your tests. `dotnet test` starts the test application using the unit test project you created.

Your test fails. You didn't create the implementation yet. Make the test pass by writing the simplest code in the `PrimeService` class that works:

```csharp
public bool IsPrime(int candidate)
{
    if (candidate == 1)
    {
        return false;
    }
    throw new NotImplementedException("Please create a test first.");
}
```

In the *unit-testing-using-tunit* directory, run `dotnet test` again. The `dotnet test` command runs a build for the `PrimeService` project and then for the `PrimeService.Tests` project. After you build both projects, it runs this single test. It passes.

## Adding more features

Now that you made one test pass, it's time to write more. There are a few other simple cases for prime numbers: 0, -1. You could add new tests with the `[Test]` attribute, but that quickly becomes tedious. TUnit provides the `[Arguments]` attribute to create a suite of tests that execute the same code but have different input arguments.

Instead of creating new tests, apply this attribute to create a single data-driven test. Replace the `IsPrime_InputIs1_ReturnFalse` method with the following code. The data driven test is a method that tests several values less than two, which is the lowest prime number:

```csharp
[Test]
[Arguments(-1)]
[Arguments(0)]
[Arguments(1)]
public async Task IsPrime_ValuesLessThan2_ReturnFalse(int value)
{
    var result = _primeService.IsPrime(value);

    await Assert.That(result).IsFalse();
}
```

Run `dotnet test`, and two of these tests fail. To make all of the tests pass, change the `if` clause at the beginning of the `IsPrime` method in the *PrimeService.cs* file:

```csharp
if (candidate < 2)
```

Continue to iterate by adding more tests and code in the main library.

You built a small library and a set of unit tests for that library. You've also structured the solution so that adding new packages and tests is part of the standard workflow. You've concentrated most of your time and effort on solving the goals of the application.

## See also

- [TUnit documentation](https://tunit.dev/)
- [Run selected unit tests](selective-unit-tests.md?pivots=tunit)
- [Order unit tests](order-unit-tests.md?pivots=tunit)
- [dotnet reference add](../tools/dotnet-reference-add.md)
- [dotnet test](../tools/dotnet-test.md)
