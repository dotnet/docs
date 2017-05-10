---
title: Unit testing in .NET Core using dotnet test | Microsoft Docs
description: Unit Testing in .NET Core using dotnet test
keywords: .NET, .NET Core
author: ardalis
ms.author: wiwagn
ms.date: 03/21/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: bdcdb812-6f13-4f20-9e90-0c0977937142
---

# Unit testing in .NET Core using dotnet test

This tutorial takes you through an interactive experience building a sample solution step-by-step to learn unit testing concepts. If you prefer to follow the tutorial using a pre-built solution, [view or download the sample code](https://github.com/dotnet/docs/tree/master/samples/core/getting-started/unit-testing-using-dotnet-test/) before you begin. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples).

### Creating the source project

Open a shell window. Create a directory called *unit-testing-using-dotnet-test* to hold the solution. Inside this new directory, create a *PrimeService* directory. The directory structure thus far is shown below:

```
/unit-testing-using-dotnet-test
    /PrimeService
```

Make *PrimeService* the current directory and run [`dotnet new classlib`](../tools/dotnet-new.md) to create the source project. Rename *Class1.cs* to *PrimeService.cs*. To use test-driven development (TDD), you'll create a failing implementation of the `PrimeService` class:

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

### Creating the test project

Change the directory back to the *unit-testing-using-dotnet-test* directory and create the *PrimeService.Tests* directory. The directory structure is shown below:

```
/unit-testing-using-dotnet-test
    /PrimeService
        Source Files
        PrimeService.csproj
    /PrimeService.Tests
```

Make the *PrimeService.Tests* directory the current directory and create a new project using [`dotnet new xunit`](../tools/dotnet-new.md). This creates a test project that uses xUnit as the test library. The generated template configures the test runner in the *PrimeServiceTests.csproj*:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.0.0" />
  <PackageReference Include="xunit" Version="2.2.0" />
  <PackageReference Include="xunit.runner.visualstudio" Version="2.2.0" />
</ItemGroup>
```

The test project requires other packages to create and run unit tests. `dotnet new` in the previous step added xUnit and the xUnit runner. Now, add the `PrimeService` class library as another dependency to the project. Use the [`dotnet add reference`](../tools/dotnet-add-reference.md) command:

```
dotnet add reference ../PrimeService/PrimeService.csproj
```

Another option is to edit the *PrimeService.Tests.csproj* file. Directly under the first `<ItemGroup>` node, add another `<ItemGroup>` node with a reference to the library project:

```xml
<ItemGroup>
  <ProjectReference Include="..\PrimeService\PrimeService.csproj" />
</ItemGroup>
```

You can see the entire file in the [samples repository](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-using-dotnet-test/PrimeService.Tests/PrimeService.Tests.csproj) on GitHub.

The final solution layout is shown below:

```
/unit-testing-using-mstest
    /PrimeService
        Source Files
        PrimeService.csproj
    /PrimeService.Tests
        PrimeService
        PrimeServiceTests.csproj
```

## Creating the first test

Before building the library or the tests, execute [`dotnet restore`](../tools/dotnet-restore.md) in the *PrimeService.Tests* directory. This command restores all the necessary NuGet packages for each project.

The TDD approach calls for writing one failing test, making it pass, then repeating the process. Remove *UnitTest1.cs* from the *PrimeService.Tests* directory and create a new C# file named *PrimeService_IsPrimeShould.cs* with the following content:

```csharp
using Xunit;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;

        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [Fact]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _primeService.IsPrime(1);

            Assert.False(result, $"1 should not be prime");
        }
    }
}
```

The `[Fact]` attribute denotes a method as a single test. Execute [`dotnet test`](../tools/dotnet-test.md) to build the tests and the class library and then run the tests. The xUnit test runner contains the program entry point to run your tests. `dotnet test` starts the test runner and provides a command-line argument to the test runner indicating the assembly that contains your tests.

Your test fails. You haven't created the implementation yet. Write the simplest code in the `PrimeService` class to make this test pass:

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

In the *PrimeService.Tests* directory, run `dotnet test` again. The `dotnet test` command runs a build for the `PrimeService` project and then for the `PrimeService.Tests` project. After building both projects, it runs this single test. It passes.

### Adding more features

Now that you've made one test pass, it's time to write more. There are a few other simple cases for prime numbers: 0, -1. You could add those as new tests with the `[Fact]` attribute, but that quickly becomes tedious. There are other xUnit attributes that enable you to write a suite of similar tests.  A `[Theory]` attribute represents a suite of tests that execute the same code but have different input arguments. You can use the `[InlineData]` attribute to specify values for those inputs. 
 
Instead of creating new tests, leverage these two attributes to create a single theory that tests several values less than two, which is the lowest prime number:

[!code-csharp[Sample_TestCode](../../../samples/core/getting-started/unit-testing-using-dotnet-test/PrimeService.Tests/PrimeService_IsPrimeShould.cs?name=Sample_TestCode)]

Run `dotnet test`, and two of these tests fail. To make all of the tests pass, change the `if` clause at the beginning of the method:

```csharp
if (candidate < 2)
```

Continue to iterate by adding more tests, more theories, and more code in the main library. You'll end up with the [finished version of the tests](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-using-dotnet-test/PrimeService.Tests/PrimeService_IsPrimeShould.cs) and the [complete implementation of the library](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-using-dotnet-test/PrimeService/PrimeService.cs).

You've built a small library and a set of unit tests for that library. You've structured the solution so that adding new packages and tests is seamless, and you can concentrate most of your time and effort on solving the goals of the applicaiton.
