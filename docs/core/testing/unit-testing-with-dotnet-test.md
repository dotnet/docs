---
title: Unit Testing in .NET Core using dotnet test
description: Unit Testing in .NET Core using dotnet test
keywords: .NET, .NET Core
author: ardalis
ms.author: wiwagn
ms.date: 06/20/2016
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
|__global.json
|__/src
   |__/PrimeService
      |__Source Files
      |__project.json
|__/test
   |__/PrimeService.Tests
      |__Test Files
      |__project.json
```

In the root directory, you'll need to create a `global.json` that
contains the names of your `src` and `test` directories:

```json
{
    "projects": [
        "src",
        "test"
    ]
}
```

### Creating the source project

Then, in the `src` directory, create the `PrimeService` directory.
CD into that directory, and run `dotnet new -t lib` to create the source
project.


Rename `Library.cs` as `PrimeService.cs`. To use test-driven development (TDD), you'll create a failing implementation of the
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

Next, cd into the 'test' directory, and create the `PrimeServices.Tests` directory.
CD into the `PrimeServices.Tests` directory and create a new project using
`dotnet new -t xunittest`. `dotnet new -t xunittest` creates a test project
that uses xunit as the test library. 

The generated template configured the test runner
at the root of `project.json`:

```json
{
  "version": "1.0.0-*",
  "testRunner": "xunit",
  // ...
}
```

The template also sets the framework node to use
`netcoreapp1.0`, and include the required imports to
get xUnit.net to work with .NET Core RTM:

```json
  "frameworks": {
    "netcoreapp1.0": {
      "imports": [
        "dotnet54",
        "portable-net45+win8" 
      ]
    }
  }
```

The test project requires other packages to create and run unit tests.
`dotnet new` added xunit, and the xunit runner. You need to add the PrimeService
package as another dependency to the project:

```json
"dependencies": {
  "Microsoft.NETCore.App": {
    "type":"platform",
    "version": "1.0.0"
  },
  "xunit":"2.1.0",
  "dotnet-test-xunit": "1.0.0-rc2-192208-24",
  "PrimeService": {
    "target": "project"
  }
}
```

Notice that the `PrimeService` project does not include
any directory path information. Because you created the
project structure to match the expected organization of
`src` and `test`, and the `global.json` file indicates
that, the build system will find the correct location
for the project. You add the `"target": "project"` element
to inform NuGet that it should look in project directories,
not in the NuGet feed. Without this key, you might download
a package with the same name as your internal library.

You can see the entire file in the
[samples repository](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-using-dotnet-test/test/PrimeService.Tests/project.json) 
on GitHub.

After this initial structure is in place, you can write your first test.
Once you verify that first unit test, everything is configured and should run smoothly
as you add features and tests.

## Creating the first test

The TDD approach calls for writing one failing test, then making it pass,
then repeating the process. So, let's write that one failing test. Remove
`program.cs` from the `PrimeService.Tests` directory, and create a new
C# file with the following content:

```cs
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
The xunit test runner has the program entry point to run your
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
quickly becomes tedious. There are other xunit attributes that enable
you to write a suite of similar tests.  A `Theory` represents a suite
of tests that execute the same code, but have different input arguments.
You can use the `[InlineData]` attribute to specify values for those
inputs. 
 
 Instead of creating new tests, leverage these two attributes
 to create a single theory that tests some values less than 2,
 which is the lowest prime number:

```cs
[Theory]
[InlineData(-1)]
[InlineData(0)]
[InlineData(1)]
public void ReturnFalseGivenValuesLessThan2(int value)
{
    var result = _primeService.IsPrime(value);

    Assert.False(result, $"{value} should not be prime");
}
```

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
[finished version of the tests](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-using-dotnet-test/test/PrimeService.Tests/PrimeServie_IsPrimeShould.cs)
and the
[complete implementation of the library](https://github.com/dotnet/docs/blob/master/samples/core/getting-started/unit-testing-using-dotnet-test/src/PrimeService/PrimeService.cs).

You've built a small library and a set of unit tests for that library.
You've structured this solution so that adding new packages and tests
will be seamless, and you can concentrate on the problem at hand. The 
tools will run automatically.
   
   > [!TIP]
   > On Windows platform you can use MSTest. Find out more in the [Using MSTest on Windows document](./using-mstest-on-windows.md).
