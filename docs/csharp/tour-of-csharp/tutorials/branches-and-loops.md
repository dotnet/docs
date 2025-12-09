---
title: Branches and loops - Introductory tutorial
description: In this tutorial about branches and loops, you write C# code to explore the language syntax that supports conditional branches and loops to execute statements repeatedly. You write C# code and see the results of compiling and running your code directly in the browser.
ms.date: 12/10/2025
---
# Tutorial: C# `if` statements and loops - conditional logic

This tutorial teaches you how to write C# code that examines variables and changes the execution path based on those variables. You write C# code and see the results of compiling and running it. The tutorial contains a series of lessons that explore branching and looping constructs in C#. These lessons teach you the fundamentals of the C# language.

In this tutorial, you:

> [!div class="checklist"]
> * Launch a GitHub Codespace with a C# development environment.
> * Explore `if` and `else` statements.
> * Use loops to repeat operations.
> * Work with nested loops.
> * Combine branches and loops.

To use codespaces, you need a GitHub account. If you don't already have one, you can create a free account at [GitHub.com](https://github.com).

## Prerequisites

You must have one of the following options:

- A GitHub account to use [GitHub Codespaces](https://github.com/codespaces).
- A computer with the following tools installed:
  - The [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
  - [Visual Studio Code](https://code.visualstudio.com/download).
  - The [C# DevKit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).

To use codespaces, you need a GitHub account. If you don't already have one, you can create a free account at [GitHub.com](https://github.com).

To start a GitHub Codespace with the tutorial environment, open a browser window to the [tutorial codespace](https://github.com/dotnet/tutorial-codespace) repository. Select the green *Code* button, and the *Codespaces* tab. Then select the `+` sign to create a new Codespace using this environment. If you completed other tutorials in this series, you can open that codespace instead of creating a new one.

1. When your codespace loads, create a new file in the *tutorials* folder named *branches-loops.cs*.
1. Open your new file.
1. Type or copy the following code into *branches-loops.cs*:

   :::code language="csharp" source="./snippets/BranchesAndLoops/branches-loops.cs" id="FirstIf":::

1. Try this code by typing the following command in the integrated terminal:

   ```dotnetcli
   cd tutorials
   dotnet branches-loops.cs
   ```

   You should see the message "The answer is greater than 10." printed to your console.

1. Modify the declaration of `b` so that the sum is less than 10:

   ```csharp
   int b = 3;
   ```

1. Type `dotnet branches-loops.cs` again in the terminal window.

   Because the answer is less than 10, nothing is printed. The **condition** you're testing is false. You don't have any code to execute because you only wrote one of the possible branches for an `if` statement: the true branch.

> [!TIP]
> As you explore C# (or any programming language), you might make mistakes when you write code. The compiler finds and reports the errors. Look closely at the error output and the code that generated the error. You can also ask Copilot to find differences or spot any mistakes. The compiler error can usually help you find the problem.

This first sample shows the power of `if` and Boolean types. A *Boolean* is a variable that can have one of two values: `true` or `false`. C# defines a special type, `bool` for Boolean variables. The `if` statement checks the value of a `bool`. When the value is `true`, the statement following the `if` executes. Otherwise, it's skipped. This process of checking conditions and executing statements based on those conditions is powerful. Let's explore more.

## Make if and else work together

To execute different code in both the true and false branches, you create an `else` branch that executes when the condition is false. Try an `else` branch.

1. Add the last two lines in the following code snippet (you should already have the first four):

   :::code language="csharp" source="./snippets/BranchesAndLoops/branches-loops.cs" id="IfAndElse":::

   The statement following the `else` keyword executes only when the condition being tested is `false`. Combining `if` and `else` with boolean conditions provides all the power you need to handle both a `true` and a `false` condition.

   > [!IMPORTANT]
   > The indentation under the `if` and `else` statements is for human readers. The C# language doesn't treat indentation or white space as significant. The statement following the `if` or `else` keyword executes based on the condition. All the samples in this tutorial follow a common practice to indent lines based on the control flow of statements.

   Because indentation isn't significant, you need to use `{` and `}` to indicate when you want more than one statement to be part of the block that executes conditionally. C# programmers typically use those braces on all `if` and `else` clauses.

1. The following example is the same as what you created. Modify your code above to match the following code:

   :::code language="csharp" source="./snippets/BranchesAndLoops/branches-loops.cs" id="IncludeBraces":::

   > [!TIP]
   > Through the rest of this tutorial, the code samples all include the braces, following accepted practices.

1. You can test more complicated conditions. Add the following code after the code you wrote so far:

   :::code language="csharp" source="./snippets/BranchesAndLoops/branches-loops.cs" id="ComplexConditions":::

   The `==` symbol tests for *equality*. Using `==` distinguishes the test for equality from assignment, which you saw in `a = 5`.

   The `&&` represents "and". It means both conditions must be true to execute the statement in the true branch. These examples also show that you can have multiple statements in each conditional branch, provided you enclose them in `{` and `}`.

1. You can also use  `||` to represent "or". Add the following code after what you wrote so far:

   :::code language="csharp" source="./snippets/BranchesAndLoops/branches-loops.cs" id="UseOr":::

1. Modify the values of `a`, `b`, and `c` and switch between `&&` and `||` to explore. You gain more understanding of how the `&&` and `||` operators work.

1. You finished the first step. Before you start the next section, let's move the current code into a separate method. That makes it easier to start working with a new example. Put the existing code in a method called `ExploreIf()`. Call it from the top of your program. When you finished those changes, your code should look like the following code:

   :::code language="csharp" source="./snippets/BranchesAndLoops/branches-loops.cs" id="Refactor":::

1. Comment out the call to `ExploreIf()`. It makes the output less cluttered as you work in this section:

   ```csharp
   //ExploreIf();
   ```

The `//` starts a **comment** in C#. Comments are any text you want to keep in your source code but not execute as code. The compiler doesn't generate any executable code from comments.

## Use loops to repeat operations

Another important concept for creating larger programs is **loops**. Use loops to repeat statements that you want to execute more than once.

1. Add this code after the call to `ExploreIf`:

   :::code language="csharp" source="./snippets/BranchesAndLoops/branches-loops.cs" id="WhileLoop":::

   The `while` statement checks a condition and executes the statement following the `while`. It repeats checking the condition and executing those statements until the condition is false.

   There's one other new operator in this example. The `++` after the `counter` variable is the **increment** operator. It adds 1 to the value of `counter` and stores that value in the `counter` variable.

   > [!IMPORTANT]
   > Make sure that the `while` loop condition changes to false as you execute the code. Otherwise, you create an **infinite loop** where your program never ends. That behavior isn't demonstrated in this sample, because you have to force your program to quit by using **CTRL-C** or other means.

   The `while` loop tests the condition before executing the code following the `while`.

1. The `do` ... `while` loop executes the code first, and then checks the condition. The *do while* loop is shown in the following code:

   :::code language="csharp" source="./snippets/BranchesAndLoops/branches-loops.cs" id="DoLoop":::

   This `do` loop and the earlier `while` loop produce the same output.

Let's move on to one last loop statement.

## Work with the for loop

Another common loop statement that you see in C# code is the `for` loop.

1. Try this code:

   :::code language="csharp" source="./snippets/BranchesAndLoops/branches-loops.cs" id="ForLoop":::

   The preceding `for` loop does the same work as the `while` loop and the `do` loop you already used. The `for` statement has three parts that control how it works:

   - The first part is the **for initializer**: `int counter = 0;` declares that `counter` is the loop variable, and sets its initial value to `0`.
   - The middle part is the **for condition**: `counter < 10` declares that this `for` loop continues to execute as long as the value of `counter` is less than 10.
   - The final part is the **for iterator**: `counter++` specifies how to modify the loop variable after executing the block following the `for` statement. Here, it specifies that `counter` increments by 1 each time the block executes.

1. Experiment with these conditions yourself. Try each of the following changes:

   - Change the initializer to start at a different value.
   - Change the condition to stop at a different value.

When you're done, move on to the next section to write some code yourself and use what you learned.

There's one other looping statement that isn't covered in this tutorial: the `foreach` statement. The `foreach` statement repeats its statement for every item in a sequence of items. You most often use it with *collections*. It's covered in the next tutorial.

## Created nested loops

You can nest a `while`, `do`, or `for` loop inside another loop to create a matrix by combining each item in the outer loop with each item in the inner loop. Let's build a set of alphanumeric pairs to represent rows and columns.

1. Add the following `for` loop that generates the rows:

   :::code language="csharp" source="./snippets/BranchesAndLoops/branches-loops.cs" id="Rows":::

1. Add another loop to generate the columns:

   :::code language="csharp" source="./snippets/BranchesAndLoops/branches-loops.cs" id="Columns":::

1. Finally, nest the columns loop inside the rows to form pairs:

   :::code language="csharp" source="./snippets/BranchesAndLoops/branches-loops.cs" id="Nested":::

   The outer loop increments once for each full run of the inner loop. Reverse the row and column nesting, and see the changes for yourself. When you're done, place the code from this section in a method called `ExploreLoops()`.

## Combine branches and loops

Now that you used the `if` statement and the looping constructs in the C# language, see if you can write C# code to find the sum of all integers 1 through 20 that are divisible by 3. Here are a few hints:

- The `%` operator gives you the remainder of a division operation.
- The `if` statement gives you the condition to see if a number should be part of the sum.
- The `for` loop can help you repeat a series of steps for all the numbers 1 through 20.

Try it yourself. Then check how you did. As a hint, you should get 63 for an answer.

Did you come up with something like this?

<!-- markdownlint-disable MD033 -->
<details>

:::code language="csharp" source="./snippets/BranchesAndLoops/branches-loops.cs" id="Challenge":::
</details>
<!-- markdownlint-enable MD033 -->

You completed the "branches and loops" tutorial. You can learn more about these concepts in these articles:

- [Selection statements](../../language-reference/statements/selection-statements.md)
- [Iteration statements](../../language-reference/statements/iteration-statements.md)

## Cleanup resources

GitHub automatically deletes your Codespace after 30 days of inactivity. If you plan to explore more tutorials in this series, you can leave your Codespace provisioned. If you're ready to visit the [.NET site](https://dotnet.microsoft.com/download/dotnet) to download the .NET SDK, you can delete your Codespace. To delete your Codespace, open a browser window and navigate to [your Codespaces](https://github.com/codespaces). You should see a list of your codespaces in the window. Select the three dots (`...`) in the entry for the learn tutorial codespace and select **delete**.

## Next step

> [!div class="nextstepaction"]
> [Learn about collections](list-collection.md)
