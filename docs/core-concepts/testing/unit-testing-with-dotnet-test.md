# Unit Testing in .NET Core using dotnet test

By [Steve Smith](http://ardalis.com) and [Bill Wagner](https://github.com/BillWagner)

[View or download sample code](https://github.com/dotnet/core-docs/tree/UnitTestingInCore/samples/unit-testing/using-dotnet-test)

# Creating the Projects

[Writing Libraries with Cross Platform Tools](/docs/core-concepts/libraries/libraries-with-cli.md#how-to-test-libraries-on-net-core)
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
/test
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

## Creating the source project

Then, in the `src` directory, create the `PrimeService` directory.
CD into that directory, and run `dotnet new` to create the source
project.


In RC2, `dotnet new` creates a console application project, so you'll want to
make a modification to `project.json` so that you build a class library
project. 

* note: You can track [this issue](https://github.com/dotnet/cli/issues/2052)
for other project types coming for the dotnet CLI, including class libraries.
Once this issue is addressed, you won't need to make these changes.

Simply remove the `buildOptions` node that instructs the compiler
to emit the program entry point:

```json
"buildOptions" : {
    "emitEntryPoint": true
}
```

You'll also want to remove `program.cs` and replace it with the class for the
`PrimeService`. To use TDD, you'll create a failing implementation of the
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

## Creating the test project

Next, cd into the 'test' directory, and create the `PrimeServices.Tests` directory.
CD into the `PrimeServices.Tests` directory and create a new project using `dotnet new`.
Once again, `dotnet new` creates a console application, and you'll need to modify
`project.json` to create a class library project by removing the `buildOptions` node.
 
```json
"buildOptions" : {
    "emitEntryPoint": true
}
```

* note: You can track [this issue](https://github.com/dotnet/cli/issues/2052)
for other project types coming for the dotnet CLI, including class libraries.
Once this issue is addressed, you won't need to make these changes.

The test project requires other packages to create and run unit tests.
You'll need to add xunit, the xunit runner, and the PrimeService
package as dependencies to the project:

```json
"dependencies": {
    "Microsoft.NetCore.App": {
        "type": "platform",
        "version": "1.0.0-rc2-3002702"
    },
    "xunit": "2.1.0",
    "dotnet-test-xunit": "1.0.0-rc2-build10015",
    "PrimeService": "1.0.0"
}
```

Notice that the `PrimeService` project does not include
any directory path information. Because you created the
project structure to match the expected organization of
`src` and `test`, and the `global.json` file indicates
that, the build system will find the correct location
for the project.

You'll also need to add a node to specify the test runner
at the root of `project.json`:

```json
{
  "version": "1.0.0-*",
  "testRunner": "xunit",
  // ...
}
```

Finally, you need to set the framework node to use
`netcoreapp1.0`, and include the required imports to
get xunit to work with RC2:

```json
  "frameworks": {
    "netcoreapp1.0": {
      "imports": [
        "dnxcore50",
        "portable-net45+win8" 
      ]
    }
  }
```

You can see the entire file in the [samples repository](https://github.com/dotnet/core-docs/blob/master/samples/unit-testing/using-dotnet-test/tests/PrimeService.Tests/project.json)
on GitHub.

After this initial structure is in place, you can write your first test.
After this initial setup, everything is configured and should run smoothly
as you add features and tests.

# Creating the first test

The TDD approach calls for writing one failing test, then making it pass,
then repeating the process. So, let's write that one failing test. Remove
`program.cs` from the `PrimeService.Tests` directory, and crate a new
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
tests from the Console.

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

## Adding More Features

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
    var result = false;

    Assert.False(result, $"{value} should not be prime");
}
```

Run `dotnet test` and you'll see the that two of these tests fail.
You can make them pass by changing the service. You need to change
the `if` clause at the beginning of the method:

```cs
if(candidate < 2)
```

Now, these tests all pass.

You continue to iterate by adding more tests, more theories,
and more code in the main library. You'll quickly end up
with the
[finished version of the tests](https://github.com/dotnet/core-docs/blob/master/samples/unit-testing/using-dotnet-test/tests/PrimeService.Tests/PrimeServie_IsPrimeShould.cs)
and the
[complete implementation of the library](https://github.com/dotnet/core-docs/blob/master/samples/unit-testing/using-dotnet-test/src/PrimeService/PrimeService.cs).

You've built a small library and a set of unit tests for that library.
You've structured this solution so that adding new packages and tests
will be seamless, and you can concentrate on the problem at hand. The 
tools will run automatically.
