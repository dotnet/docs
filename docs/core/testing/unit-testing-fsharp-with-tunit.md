---
title: Unit testing F# in .NET with dotnet test and TUnit
description: Learn unit test concepts for F# in .NET through an interactive experience building a sample solution step-by-step using dotnet test and TUnit.
author: thomhurst
ms.author: wiwagn
ms.date: 11/03/2026
ai-usage: ai-assisted
dev_langs:
  - "fsharp"
---
# Unit testing F# libraries using dotnet test and TUnit

This tutorial takes you through an interactive experience building a sample solution step-by-step to learn unit testing concepts.

[!INCLUDE [testing an ASP.NET Core project from .NET Core](../../../includes/core-testing-note-aspnet.md)]

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) or later versions.
- A text editor or code editor of your choice.

TUnit is built entirely on [Microsoft.Testing.Platform (MTP)](microsoft-testing-platform-intro.md) and doesn't support VSTest. This tutorial uses the MTP mode of `dotnet test`, which requires the .NET 10 SDK.

## Create the source project

Open a shell window. Create a directory called *unit-testing-with-fsharp* to hold the solution.
Inside this new directory, run the following command to create a new solution file for the class library and the test project:

```dotnetcli
dotnet new sln
```

Next, create a *MathService* directory. The following outline shows the directory and file structure so far:

```txt
/unit-testing-with-fsharp
    unit-testing-with-fsharp.slnx
    /MathService
```

Make *MathService* the current directory and run the following command to create the source project:

```dotnetcli
dotnet new classlib -lang "F#"
```

Replace the contents of *Library.fs* with a failing implementation of the math service:

```fsharp
namespace MathService

module MyMath =
    let squaresOfOdds (xs: int seq) : int seq = raise (System.NotImplementedException("You haven't written a test yet!"))
```

Change the directory back to the *unit-testing-with-fsharp* directory. Run the following command to add the class library project to the solution:

```dotnetcli
dotnet sln add ./MathService/MathService.fsproj
```

## Create the test project

Next, create the *MathService.Tests* directory. The following outline shows the directory structure:

```txt
/unit-testing-with-fsharp
    unit-testing-with-fsharp.slnx
    /MathService
        Source Files
        MathService.fsproj
    /MathService.Tests
```

The TUnit project templates aren't included in the .NET SDK. Install them with the following command:

```dotnetcli
dotnet new install TUnit.Templates
```

Make the *MathService.Tests* directory the current directory and create a new project using the following command:

```dotnetcli
dotnet new TUnit -lang "F#"
```

> [!NOTE]
> Template short names are case-sensitive. Use `TUnit`, not `tunit`.

This command creates a test project that uses TUnit as the test framework. The generated *MathService.Tests.fsproj* file is an executable project that references the `TUnit` package, which includes the test framework, the assertion library, and the MTP test runner, and the `TUnit.Assertions.FSharp` package, which adds F# helpers for assertions.

The template also adds sample tests. This tutorial replaces them with its own tests in *Tests.fs*. Delete the *Data* directory and the *GlobalSetup.fs*, *Tests2.fs*, and *Tests3.fs* files. F# projects list their source files explicitly, so also replace the `ItemGroup` that contains the `Compile` items in *MathService.Tests.fsproj* with the following:

```xml
<ItemGroup>
  <Compile Include="Tests.fs" />
</ItemGroup>
```

Now, add the `MathService` class library as another dependency to the project. Use the [`dotnet reference add`](../tools/dotnet-reference-add.md) command:

```dotnetcli
dotnet reference add ../MathService/MathService.fsproj
```

The following outline shows the final solution layout:

```txt
/unit-testing-with-fsharp
    unit-testing-with-fsharp.slnx
    /MathService
        Source Files
        MathService.fsproj
    /MathService.Tests
        Test Source Files
        MathService.Tests.fsproj
```

Execute the following command in the *unit-testing-with-fsharp* directory:

```dotnetcli
dotnet sln add ./MathService.Tests/MathService.Tests.fsproj
```

## Configure the MTP mode of dotnet test

Because TUnit doesn't support VSTest, `dotnet test` must run in its MTP mode. In the *unit-testing-with-fsharp* directory, create a *global.json* file with the following content:

```json
{
    "test": {
        "runner": "Microsoft.Testing.Platform"
    }
}
```

For more information, see [MTP mode of dotnet test](unit-testing-with-dotnet-test.md#mtp-mode-of-dotnet-test).

## Create the first test

You write one failing test, make it pass, then repeat the process. Replace the contents of *Tests.fs* with the following code:

```fsharp
namespace MathService.Tests

open TUnit.Core
open TUnit.Assertions
open TUnit.Assertions.Extensions
open TUnit.Assertions.FSharp.TaskAssert
open MathService

type TestClass () =

    [<Test>]
    member this.TestMethodPassing() = taskAssert {
        do! Assert.That(true).IsTrue()
    }

    [<Test>]
    member this.FailEveryTime() = taskAssert {
        do! Assert.That(false).IsTrue()
    }
```

The `[<Test>]` attribute denotes a test method that is run by the test runner. TUnit discovers test methods that are members of a class; it doesn't discover functions that are declared with `let` in a module. TUnit assertions are asynchronous. The `taskAssert` computation expression from `TUnit.Assertions.FSharp` runs a test as a task and lets you await each assertion with `do!`.

From the *unit-testing-with-fsharp* directory, execute `dotnet test` to build the tests and the class library and then run the tests. The TUnit test project contains the program entry point to run your tests. `dotnet test` starts the test application using the unit test project you've created.

These two tests show the most basic passing and failing tests. `TestMethodPassing` passes, and `FailEveryTime` fails. Now, create a test for the `squaresOfOdds` method. The `squaresOfOdds` method returns a sequence of the squares of all odd integer values that are part of the input sequence. Rather than trying to write all of those functions at once, you can iteratively create tests that validate the functionality. To make each test pass, you create the necessary functionality for the method.

The simplest test you can write is to call `squaresOfOdds` with all even numbers, where the result should be an empty sequence of integers. Add the following test to the `TestClass` type:

```fsharp
[<Test>]
member this.TestEvenSequence() = taskAssert {
    let expected = Seq.empty<int>
    let actual = MyMath.squaresOfOdds [2; 4; 6; 8; 10]
    do! Assert.That<int>(actual).IsEquivalentTo(expected)
}
```

F# is stricter than C# when it resolves method overloads, so the test passes the item type to `Assert.That<int>` to select the assertions for a sequence of integers. `IsEquivalentTo` checks that both sequences contain the same items.

When you run the test, you see that your test fails. That's because you haven't created the implementation yet. Make this test pass by writing the simplest code in the *Library.fs* file in your MathService project that works:

```fsharp
let squaresOfOdds xs =
    Seq.empty<int>
```

In the *unit-testing-with-fsharp* directory, run `dotnet test` again. The `dotnet test` command runs a build for the `MathService` project and then for the `MathService.Tests` project. After building both projects, it runs your tests. Two tests pass now.

## Complete the requirements

Now that you've made one test pass, it's time to write more. The next simple case works with a sequence whose only odd number is `1`. The number 1 is easier because the square of 1 is 1. Here's that next test:

```fsharp
[<Test>]
member public this.TestOnesAndEvens() = taskAssert {
    let expected = [1; 1; 1; 1]
    let actual = MyMath.squaresOfOdds [2; 1; 4; 1; 6; 1; 8; 1; 10]
    do! Assert.That<int>(actual).IsEquivalentTo(expected)
}
```

Executing `dotnet test` fails the new test. You must update the `squaresOfOdds` method to handle this new test. You must filter all the even numbers out of the sequence to make this test pass. You can do that by writing a small filter function and using `Seq.filter`:

```fsharp
let private isOdd x = x % 2 <> 0

let squaresOfOdds xs =
    xs
    |> Seq.filter isOdd
```

There's one more step to go: square each of the odd numbers. Start by writing a new test:

```fsharp
[<Test>]
member public this.TestSquaresOfOdds() = taskAssert {
    let expected = [1; 9; 25; 49; 81]
    let actual = MyMath.squaresOfOdds [1; 2; 3; 4; 5; 6; 7; 8; 9; 10]
    do! Assert.That<int>(actual).IsEquivalentTo(expected)
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

You've built a small library and a set of unit tests for that library. You structured the solution so that adding new packages and tests is part of the normal workflow. You concentrated most of your time and effort on solving the goals of the application.

## See also

- [TUnit documentation](https://tunit.dev/)
- [F# assertions in TUnit](https://tunit.dev/docs/assertions/fsharp)
- [dotnet new](../tools/dotnet-new.md)
- [dotnet sln](../tools/dotnet-sln.md)
- [dotnet reference add](../tools/dotnet-reference-add.md)
- [dotnet test](../tools/dotnet-test.md)
