---
title: Unit testing F# libraries in .NET Core using dotnet test and NUnit
description: Learn unit test concepts for F# in .NET Core through an interactive experience building a sample solution step-by-step using dotnet test and NUnit.
author: rprouse
ms.date: 12/01/2017
ms.topic: article
dev_langs:
 - "fsharp"
ms.prod: .net-core
---
# Unit testing F# libraries in .NET Core using dotnet test and NUnit

This tutorial takes you through an interactive experience building a sample solution step-by-step to learn unit testing concepts. If you prefer to follow the tutorial using a pre-built solution, [view or download the sample code](https://github.com/dotnet/samples/tree/master/core/getting-started/unit-testing-with-fsharp-nunit/) before you begin. For download instructions, see [Samples and Tutorials](../../samples-and-tutorials/index.md#viewing-and-downloading-samples).

## Creating the source project

Open a shell window. Create a directory called *unit-testing-with-fsharp* to hold the solution.
Inside this new directory, run [`dotnet new sln`](../tools/dotnet-new.md) to create a new solution. This
makes it easier to manage both the class library and the unit test project.
Inside the solution directory, create a *MathService* directory. The directory and file structure thus far is shown below:

```
/unit-testing-with-fsharp
    unit-testing-with-fsharp.sln
    /MathService
```

Make *MathService* the current directory and run [`dotnet new classlib -lang F#`](../tools/dotnet-new.md) to create the source project.  To use test-driven development (TDD), you'll create a failing implementation of the math service:

```fsharp
module MyMath =
    let squaresOfOdds xs = raise (System.NotImplementedException("You haven't written a test yet!"))
```

Change the directory back to the *unit-testing-with-fsharp* directory. Run [`dotnet sln add .\MathService\MathService.fsproj`](../tools/dotnet-sln.md)
to add the class library project to the solution.

## Install the NUnit project template

The NUnit test project templates need to be installed before creating a test project. This only needs to be done once on each developer machine where you'll create new NUnit projects. Run [`dotnet new -i NUnit3.DotNetNew.Template`](../tools/dotnet-new.md) to install the NUnit templates.

 ```
 dotnet new -i NUnit3.DotNetNew.Template
 ```

## Creating the test project

Next, create the *MathService.Tests* directory. The following outline shows the directory structure:

```
/unit-testing-with-fsharp
    unit-testing-with-fsharp.sln
    /MathService
        Source Files
        MathService.fsproj
    /MathService.Tests
```

Make the *MathService.Tests* directory the current directory and create a new project using [`dotnet new nunit -lang F#`](../tools/dotnet-new.md). This creates a test project that uses NUnit as the test framework. The generated template configures the test runner in the *MathServiceTests.fsproj*:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.NET.Test.Sdk" Version="15.5.0" />
  <PackageReference Include="NUnit" Version="3.9.0" />
  <PackageReference Include="NUnit3TestAdapter" Version="3.9.0" />
</ItemGroup>
```

The test project requires other packages to create and run unit tests. `dotnet new` in the previous step added NUnit and the NUnit test adapter. Now, add the `MathService` class library as another dependency to the project. Use the [`dotnet add reference`](../tools/dotnet-add-reference.md) command:

```
dotnet add reference ../MathService/MathService.fsproj
```

You can see the entire file in the [samples repository](https://github.com/dotnet/samples/blob/master/core/getting-started/unit-testing-with-fsharp/MathService.Tests/MathService.Tests.fsproj) on GitHub.

You have the following final solution layout:

```
/unit-testing-with-fsharp
    unit-testing-with-fsharp.sln
    /MathService
        Source Files
        MathService.fsproj
    /MathService.Tests
        Test Source Files
        MathServiceTests.fsproj
```

Execute [`dotnet sln add .\MathService.Tests\MathService.Tests.fsproj`](../tools/dotnet-sln.md) in the *unit-testing-with-fsharp* directory.

## Creating the first test

The TDD approach calls for writing one failing test, making it pass, then repeating the process. Open *Tests.fs* and add the following code:

```fsharp
namespace MathService.Tests

open System
open NUnit.Framework
open MathService

[<TestFixture>]
type TestClass () =

    [<Test>]
    member this.TestMethodPassing() =
        Assert.True(true)

    [<Test>]
     member this.FailEveryTime() = Assert.True(false)
```

The `[<TestFixture>]` attribute denotes a class that contains tests. The `[<Test>]` attribute denotes a test method that is run by the test runner. From the *unit-testing-with-fsharp* directory, execute [`dotnet test`](../tools/dotnet-test.md) to build the tests and the class library and then run the tests. The NUnit test runner contains the program entry point to run your tests. `dotnet test` starts the test runner using the unit test project you've created.

These two tests show the most basic passing and failing tests. `My test` passes, and `Fail every time` fails. Now, create a test for the `squaresOfOdds` method. The `squaresOfOdds` method returns a sequence of the squares of all odd integer values that are part of the input sequence. Rather than trying to write all of those functions at once, you can iteratively create tests that validate the functionality. Making each test pass means creating the necessary functionality for the method.

The simplest test we can write is to call `squaresOfOdds` with all even numbers, where the result should be an empty sequence of integers.  Here's that test:

```fsharp
[<Test>]
member this.TestEvenSequence() =
    let expected = Seq.empty<int>
    let actual = MyMath.squaresOfOdds [2; 4; 6; 8; 10]
    Assert.That(actual, Is.EqualTo(expected))
```

Notice that the `expected` sequence has been converted to a list. The NUnit framework relies on many standard .NET types. That dependency means that your public interface and expected results support <xref:System.Collections.ICollection> rather than <xref:System.Collections.IEnumerable>.

When you run the test, you see that your test fails. You haven't created the implementation yet. Make this test by writing the simplest code in the `Mathservice` class that works:

```csharp
let squaresOfOdds xs =
    Seq.empty<int>
```

In the *unit-testing-with-fsharp* directory, run `dotnet test` again. The `dotnet test` command runs a build for the `MathService` project and then for the `MathService.Tests` project. After building both projects, it runs this single test. It passes.

## Completing the requirements

Now that you've made one test pass, it's time to write more. The next simple case works with a sequence whose only odd number is `1`. The number 1 is easier because the square of 1 is 1. Here's that next test:

```fsharp
[<Test>]
member public this.TestOnesAndEvens() =
    let expected = [1; 1; 1; 1]
    let actual = MyMath.squaresOfOdds [2; 1; 4; 1; 6; 1; 8; 1; 10]
    Assert.That(actual, Is.EqualTo(expected))
```

Executing `dotnet test` fails the new test. You must update the `squaresOfOdds` method to handle this new test. You must filter all the even numbers out of the sequence to make this test pass. You can do that by writing a small filter function and using `Seq.filter`:

```fsharp
let private isOdd x = x % 2 <> 0

let squaresOfOdds xs =
    xs
    |> Seq.filter isOdd
```

Notice the call to `Seq.toList`. That creates a list, which implements the <xref:System.Collections.ICollection> interface.

There's one more step to go: square each of the odd numbers. Start by writing a new test:

```fsharp
[<Test>]
member public this.TestSquaresOfOdds() =
    let expected = [1; 9; 25; 49; 81]
    let actual = MyMath.squaresOfOdds [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
    Assert.That(actual, Is.EqualTo(expected))
```

You can fix the test by piping the filtered sequence through a map operation to compute the square of each odd number:

```fsharp
let private square x = x * x
let private isOdd x = x % 2 <> 0

let squaresOfOdds xs =
    xs
    |> Seq.filter isOdd
    |> Seq.map square
```

You've built a small library and a set of unit tests for that library. You've structured the solution so that adding new packages and tests is part of the normal workflow. You've concentrated most of your time and effort on solving the goals of the application.
