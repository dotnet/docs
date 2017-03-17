---
title: Unit Testing in .NET Core using dotnet test | Microsoft Docs
description: Unit Testing in .NET Core using dotnet test
keywords: .NET, .NET Core
author: ardalis
ms.author: wiwagn
ms.date: 003/14/2017
ms.topic: article
ms.prod: .net-core
ms.devlang: dotnet
ms.assetid: bdcdb812-6f13-4f20-9e90-0c0977937142
---

# Unit Testing in .NET Core using dotnet test

By [Steve Smith](http://ardalis.com) and [Bill Wagner](https://github.com/BillWagner)

[View or download sample code](https://github.com/dotnet/docs/tree/master/samples/core/getting-started/unit-testing-using-dotnet-test)

## Creating the Projects

[Writing Libraries with Cross Platform Tools](../tutorials/libraries.md)
has information on organizing multi-project solutions for both the
source and the tests. This article follows those conventions. The
final project structure will be something like this:

```
/unit-testing-using-dotnet-test
|__/PrimeService
   |__Source Files
   |__PrimeService.csproj
|__/PrimeService.Tests
   |__Test Files
   |__PrimeService.csproj
```

### Creating the source project

Start in the `unit-testing-using-dotnet-test` directory, create the `PrimeService` directory.
CD into that directory, and run `dotnet new classlib` to create the source
project.


Rename `Class1.cs` as `PrimeService.cs`. To use test-driven development (TDD), you'll create a failing implementation of the
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

Next, cd back into the 'unit-testing-using-dotnet-test' directory, and create the `PrimeServices.Tests` directory.
CD into the `PrimeService.Tests` directory and create a new project using
`dotnet new xunit`. `dotnet new xunit` creates a test project
that uses xUnit as the test library. 

The generated template configured the test runner
in the PrimeServiceTests.csproj:

```xml
  <ItemGroup>
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.0.0-preview-20170125-04" />
    <PackageReference Include="xunit" Version="2.2.0-beta5-build3474" />
    <PackageReference Include="xunit.runner.visualstudio" Version="2.2.0-beta5-build1225" />
  </ItemGroup>
```

The test project requires other packages to create and run unit tests.
`dotnet new` added xUnit, and the xUnit runner. You need to add the PrimeService
package as another dependency to the project. You can do that using the `dotnet`
CLI:

```
dotnet add reference ../PrimeService/PrimeService.csproj
```

Or, you can directly edit the `PrimeService.Tests.csproj` file.
Directly under the first
`<ItemGroup>` node, add another `<ItemGroup>` node with a reference to 
the library project:

```xml
  <ItemGroup>
    <ProjectReference Include="..\PrimeService\PrimeService.csproj" />
  </ItemGroup>
```

You can see the entire file in the
[samples repository](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-using-dotnet-test/PrimeService.Tests/PrimeService.Tests.csproj) 
on GitHub.

After this initial structure is in place, you can write your first test.
Once you verify that first unit test, everything is configured and should run smoothly
as you add features and tests.

## Creating the first test

Before building the library or the tests, you need to run `dotnet restore`
in both the `PrimeService` and `PrimeService.Tests` directories. This
command restores all the necessary NuGet packages for each project.

The TDD approach calls for writing one failing test, then making it pass,
then repeating the process. So, let's write that one failing test. Remove
`UnitTest1.cs` from the `PrimeService.Tests` directory, and create a new
C# file named `PrimeService_IsPrimeShould.cs` with the following content:

```cs
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

The `[Fact]` attribute denotes a method as a single test. 

Save this file, then run `dotnet build` to build the test project.
If you have not already built the `PrimeService` project, the
build system will detect that and build it because it is a
dependency of the test project.

Now, execute `dotnet test` to run the tests from the console.
The xUnit test runner has the program entry point to run your
tests from the Console. `dotnet test` starts the
test runner, and provides a command line argument to the
testrunner indicating the assembly that contains your tests.

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

### Adding More Features

Now, that you've made one test pass, it's time to write more.
There are a few other simple cases for prime numbers: 0, -1. You
could add those as new tests, with the `[Fact]` attribute, but that
quickly becomes tedious. There are other xUnit attributes that enable
you to write a suite of similar tests.  A `Theory` represents a suite
of tests that execute the same code, but have different input arguments.
You can use the `[InlineData]` attribute to specify values for those
inputs. 
 
 Instead of creating new tests, leverage these two attributes
 to create a single theory that tests some values less than 2,
 which is the lowest prime number:

[!code-csharp[Sample_TestCode](../../../samples/core/getting-started/unit-testing-using-dotnet-test/PrimeService.Tests/PrimeService_IsPrimeShould.cs#Sample_TestCode "First tests")]

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
[finished version of the tests](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-using-dotnet-test/PrimeService.Tests/PrimeService_IsPrimeShould.cs)
and the
[complete implementation of the library](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-using-dotnet-test/PrimeService/PrimeService.cs).

You've built a small library and a set of unit tests for that library.
You've structured this solution so that adding new packages and tests
will be seamless, and you can concentrate on the problem at hand. The 
tools will run automatically.
