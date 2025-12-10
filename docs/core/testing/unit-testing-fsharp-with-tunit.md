---
title: Unit testing F# in .NET Core with dotnet test and TUnit
description: Learn unit test concepts for F# in .NET Core through an interactive experience building a sample solution step-by-step using dotnet test and TUnit.
author: thomhurst
ms.author: wiwagn
ms.date: 11/22/2025
ai-usage: ai-assisted
---
# Unit testing F# libraries in .NET Core using dotnet test and TUnit

This tutorial takes you through an interactive experience building a sample solution step-by-step to learn unit testing concepts.

[!INCLUDE [testing an ASP.NET Core project from .NET Core](../../../includes/core-testing-note-aspnet.md)]

## Prerequisites

TUnit is built entirely on [Microsoft.Testing.Platform](microsoft-testing-platform-intro.md) and does not support VSTest.

## Creating the source project

Open a shell window. Create a directory called *unit-testing-with-fsharp* to hold the solution.
Inside this new directory, run `dotnet new sln` to create a new solution. This
makes it easier to manage both the class library and the unit test project.
Inside the solution directory, create a *MathService* directory. The directory and file structure thus far is shown below:

```
/unit-testing-with-fsharp
    unit-testing-with-fsharp.sln
    /MathService
```

Make *MathService* the current directory, and run `dotnet new classlib -lang "F#"` to create the source project. You'll create a failing implementation of the math service:

```fsharp
module MyMath =
    let squaresOfOdds xs = raise (System.NotImplementedException("You haven't written a test yet!"))
```

Change the directory back to the *unit-testing-with-fsharp* directory. Run `dotnet sln add .\MathService\MathService.fsproj` to add the class library project to the solution.

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

Install the TUnit project template:

```dotnetcli
dotnet new install TUnit.Templates
```

Make the *MathService.Tests* directory the current directory and create a new project using `dotnet new tunit -lang "F#"`. This creates a test project that uses TUnit as the test library. The generated template configures the test runner by adding the `TUnit` package to the *MathServiceTests.fsproj* file.

The test project requires other packages to create and run unit tests. `dotnet new` in the previous step added TUnit. Now, add the `MathService` class library as another dependency to the project. Use the `dotnet reference add` command:

```dotnetcli
dotnet reference add ../MathService/MathService.fsproj
```

> [!TIP]
> If you're using .NET 9 SDK or earlier, use the "verb first" form (`dotnet add reference`) instead. The "noun first" form was introduced in .NET 10.

You can see the entire file in the [samples repository](https://github.com/dotnet/samples/blob/main/core/getting-started/unit-testing-with-fsharp/MathService.Tests/MathService.Tests.fsproj) on GitHub.

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

Execute `dotnet sln add .\MathService.Tests\MathService.Tests.fsproj` in the *unit-testing-with-fsharp* directory.

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

## Creating the first test

You write one failing test, make it pass, then repeat the process. Open *Tests.fs* and add the following code:

```fsharp
open TUnit.Assertions
open TUnit.Assertions.Extensions
open TUnit.Core

[<Test>]
let ``My test`` () =
    task {
        do! Assert.That(true).IsTrue()
    }

[<Test>]
let ``Fail every time`` () =
    task {
        do! Assert.That(false).IsTrue()
    }
```

The `[<Test>]` attribute marks a method as a test that's run by the test runner.

From the *unit-testing-with-fsharp* directory, execute `dotnet test` to build the tests and the class library and then run the tests. The TUnit test runner uses Microsoft.Testing.Platform to execute the tests.

These two tests show the most basic passing and failing tests. `My test` passes, and `Fail every time` fails. Now, create a test for the `squaresOfOdds` method. The `squaresOfOdds` method returns a sequence of the squares of all odd integer values that are part of the input sequence. Rather than trying to write all of those functions at once, you can iteratively create tests that validate the functionality. Making each test pass means creating the necessary functionality for the method.

The simplest test we can write is to call `squaresOfOdds` with all even numbers, where the result should be an empty sequence of integers.  Here's that test:

```fsharp
[<Test>]
let ``Sequence of Evens returns empty collection`` () =
    task {
        let expected = Seq.empty<int>
        let actual = MyMath.squaresOfOdds [2; 4; 6; 8; 10]
        do! Assert.That(actual).IsEquivalentTo(expected)
    }
```

Your test fails. You haven't created the implementation yet. Make this test pass by writing the simplest code in the `MathService` class that works:

```fsharp
let squaresOfOdds xs =
    Seq.empty<int>
```

In the *unit-testing-with-fsharp* directory, run `dotnet test` again. The `dotnet test` command runs a build for the `MathService` project and then for the `MathService.Tests` project. After building both projects, it runs this single test. It passes.

## Completing the requirements

Now that you've made one test pass, it's time to write more. The next simple case works with a sequence whose only odd number is `1`. The number 1 is easier because the square of 1 is 1. Here's that next test:

```fsharp
[<Test>]
let ``Sequences of Ones and Evens returns Ones`` () =
    task {
        let expected = [1; 1; 1; 1]
        let actual = MyMath.squaresOfOdds [2; 1; 4; 1; 6; 1; 8; 1; 10]
        do! Assert.That(actual).IsEquivalentTo(expected)
    }
```

Executing `dotnet test` runs your tests and shows you that the new test fails. Now, update the `squaresOfOdds` method to handle this new test. You filter all the even numbers out of the sequence to make this test pass. You can do that by writing a small filter function and using `Seq.filter`:

```fsharp
let private isOdd x = x % 2 <> 0

let squaresOfOdds xs =
    xs
    |> Seq.filter isOdd
```

There's one more step to go: square each of the odd numbers. Start by writing a new test:

```fsharp
[<Test>]
let ``SquaresOfOdds works`` () =
    task {
        let expected = [1; 9; 25; 49; 81]
        let actual = MyMath.squaresOfOdds [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
        do! Assert.That(actual).IsEquivalentTo(expected)
    }
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

## See also

- [TUnit official site](https://tunit.dev)
- [TUnit GitHub repository](https://github.com/thomhurst/TUnit)
- [dotnet new](../tools/dotnet-new.md)
- [dotnet sln](../tools/dotnet-sln.md)
- [dotnet reference add](../tools/dotnet-reference-add.md)
- [dotnet test](../tools/dotnet-test.md)
