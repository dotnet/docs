---
title: Use MSTest with .NET Core | Microsoft Docs
description: How to use MSTest with .NET Core
keywords: MSTest, .NET, .NET Core
author: ncarandini
ms.author: wiwagn
ms.date: 02/10/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: ed447641-3e85-4e50-b7ed-004630048a3e
---

# Unit testing with MSTest and .NET Core

## Creating the projects

[Writing Libraries with Cross Platform Tools](../tutorials/libraries.md)
has information on organizing multi-project solutions for both the
source and the tests. This article follows those conventions. The
final project structure will be something like this:

```
/unit-testing-using-mstest
|__/PrimeService
   |__Source Files
   |__PrimeService.csproj
|__/PrimeService.Tests
   |__Test Files
   |__PrimeService.csproj
```

### Creating the source project

Open a shell window. 
Start in the *unit-testing-using-mstest* directory, create the *PrimeService* directory.
Make *PrimeService* the current directory, and run `dotnet new classlib` to create the source
project.

Rename *Class1.cs* as *PrimeService.cs*. To use test-driven development (TDD), you'll create a failing implementation of the
`PrimeService` class:

```cs
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

Next, change directory back into the *unit-testing-using-mstest* directory, and create the *PrimeServices.Tests* directory.
Make the *PrimeService.Tests* directory the current directory and create a new project using
`dotnet new mstest`. This creates a test project
that uses MStest as the test library. 

The generated template configured the test runner
in the *PrimeServiceTests.csproj* file:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.0.0-preview-20170123-02" />
  <PackageReference Include="MSTest.TestAdapter" Version="1.1.10-rc2" />
  <PackageReference Include="MSTest.TestFramework" Version="1.0.8-rc2" />
</ItemGroup>
```

The test project requires other packages to create and run unit tests.
`dotnet new` added the MSTest SDK, the MSTest test framework and the MSTest runner. You need to add the PrimeService
package as another dependency to the project. You can do that using the `dotnet`
CLI:

```
dotnet add reference ../PrimeService/PrimeService.csproj
```

Or, you can manually edit the *PrimeService.Tests.csproj* file.
Directly under the first
`<ItemGroup>` node, add another `<ItemGroup>` node with a reference to 
the library project:

```xml
  <ItemGroup>
    <ProjectReference Include="..\PrimeService\PrimeService.csproj" />
  </ItemGroup>
```

You can see the entire file in the
[samples repository](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-using-mstest/PrimeService.Tests/PrimeService.Tests.csproj) 
on GitHub.

After this initial structure is in place, you can write your first test.
Once you verify that first unit test, everything is configured and should run smoothly
as you add features and tests.

## Creating the first test

Before building the library or the tests, you need to run `dotnet restore`
in both the *PrimeService* and *PrimeService.Tests* directories. This
command restores all the necessary NuGet packages for each project.

The TDD approach calls for writing one failing test, then making it pass,
then repeating the process. So, let's write that one failing test. Remove
*UnitTest1.cs* from the *PrimeService.Tests* directory, and create a new
C# file named *PrimeService_IsPrimeShould.cs* with the following content:

```cs
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prime.Services;

namespace Prime.UnitTests.Services
{
    [TestClass]
    public class PrimeService_IsPrimeShould
    {
        private readonly PrimeService _primeService;
        public PrimeService_IsPrimeShould()
        {
            _primeService = new PrimeService();
        }

        [TestMethod]
        public void ReturnFalseGivenValueOf1()
        {
            var result = _primeService.IsPrime(1);

            Assert.IsFalse(result, $"1 should not be prime");
        }
    }
}
```

The `[TestClass]` attributes denotes a class that contains
unit tests. The `[TestMethod]` attribute denotes a method as a single test. 

Save this file, then run `dotnet build` to build the test project.
If you have not already built the `PrimeService` project, the
build system will detect that and build it because it is a
dependency of the test project.

Now, execute `dotnet test` to run the tests from the console.
The MSTest test runner has the program entry point to run your
tests from the Console. `dotnet test` starts the
test runner, and provides a command-line argument to the
test runner indicating the assembly that contains your tests.

Your test fails. You haven't created the implementation yet.
Write the simplest code to make this one test pass:

```cs
public bool IsPrime(int candidate) 
{
    if(candidate == 1) 
    { 
        return false;
    } 
    throw new NotImplementedException("Please create a test first");
} 
```

In the *PrimeService.Tests* directory, run `dotnet test` again. The 
`dotnet test` command will first run a build for the Prime.Services
project, and then for PrimeService.Tests project. After building both
projects, it will run this single test. It passes.

## Adding more features

Now, that you've made one test pass, it's time to write more.
There are a few other simple cases for prime numbers: 0, -1. You
could add those as new tests, with the `[TestMethod]` attribute, but that
quickly becomes tedious. There are other MSTest attributes that enable
you to write a suite of similar tests.  A `DataTestMethod` represents a suite
of tests that execute the same code, but have different input arguments.
You can use the `[DataRow]` attribute to specify values for those
inputs. 
 
 Instead of creating new tests, leverage these two attributes
 to create a single data test method that tests some values less than 2,
 which is the lowest prime number:

[!code-csharp[Sample_TestCode](../../../samples/core/getting-started/unit-testing-using-mstest/PrimeService.Tests/PrimeService_IsPrimeShould.cs#Sample_TestCode "First tests")]

Run `dotnet test` and you'll see that two of these tests fail.
You can make them pass by changing the service. You need to change
the `if` clause at the beginning of the method:

```cs
if(candidate < 2)
```

Now, these tests all pass.

You continue to iterate by adding more tests, more theories,
and more code in the main library. You'll quickly end up
with the
[finished version of the tests](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-using-mstest/PrimeService.Tests/PrimeService_IsPrimeShould.cs)
and the
[complete implementation of the library](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-using-mstest/PrimeService/PrimeService.cs).

You've built a small library and a set of unit tests for that library.
You've structured this solution so that adding new packages and tests
will be seamless, and you can concentrate on the problem at hand. The 
tools will run automatically.