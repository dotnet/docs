---
title: Branches and loops - Introductory tutorial
description: In this tutorial about branches and loops, you write C# code to explore the language syntax that supports conditional branches and loops to execute statements repeatedly. You write C# code and see the results of compiling and running your code directly in the browser.
ms.date: 03/06/2025
---
# C# `if` statements and loops - conditional logic tutorial

This tutorial teaches you how to write C# code that examines variables and changes the execution path based on those variables. You write C# code and see the results of compiling and running it. The tutorial contains a series of lessons that explore branching and looping constructs in C#. These lessons teach you the fundamentals of the C# language.

> [!TIP]
>
> When a code snippet block includes the "Run" button, that button opens the interactive window, or replaces the existing code in the interactive window. When the snippet doesn't include a "Run" button, you can copy the code and add it to the current interactive window.

Run the following code in the interactive window. Select **Run**:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/BranchesAndLoops/Program.cs" id="FirstIf":::

Modify the declaration of `b` so that the sum is less than 10:

```csharp
int b = 3;
```

Select the **Run** button again. Because the answer is less than 10, nothing is printed. The **condition** you're testing is false. You don't have any code to execute because you only wrote one of the possible branches for an `if` statement: the true branch.

> [!TIP]
>
> As you explore C# (or any programming language), you make mistakes when you write code. The **compiler** finds those errors and report them to you. When the output contains error messages, look closely at the example code, and the code in the interactive window to see what to fix. That exercise helps you learn the structure of C# code.

This first sample shows the power of `if` and boolean types. A *boolean* is a variable that can have one of two values: `true` or `false`. C# defines a special type, `bool` for boolean variables. The `if` statement checks the value of a `bool`. When the value is `true`, the statement following the `if` executes. Otherwise, it's skipped.

This process of checking conditions and executing statements based on those conditions is powerful. Let's explore more.

## Make if and else work together

To execute different code in both the true and false branches, you create an `else` branch that executes when the condition is false. Try the following code:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/BranchesAndLoops/Program.cs" id="IfAndElse":::

The statement following the `else` keyword executes only when the condition being tested is `false`. Combining `if` and `else` with boolean conditions provides all the power you need.

> [!IMPORTANT]
>
> The indentation under the `if` and `else` statements is for human readers. The C# language doesn't treat indentation or white space as significant. The statement following the `if` or `else` keyword executes based on the condition. All the samples in this tutorial follow a common practice to indent lines based on the control flow of statements.

Because indentation isn't significant, you need to use `{` and `}` to indicate when you want more than one statement to be part of the block that executes conditionally. C# programmers typically use those braces on all `if` and `else` clauses. The following example is the same as what you created. Try it.

:::code language="csharp" source="./snippets/BranchesAndLoops/Program.cs" id="IncludeBraces":::

> [!TIP]
>
> Through the rest of this tutorial, the code samples all include the braces, following accepted practices.

You can test more complicated conditions:

:::code language="csharp" source="./snippets/BranchesAndLoops/Program.cs" id="ComplexConditions":::

The `==` symbol tests for *equality*. Using `==` distinguishes the test for equality from assignment, which you saw in `a = 5`.

The `&&` represents "and". It means both conditions must be true to execute the statement in the true branch. These examples also show that you can have multiple statements in each conditional branch, provided you enclose them in `{` and `}`.

You can also use  `||` to represent "or":

:::code language="csharp" source="./snippets/BranchesAndLoops/Program.cs" id="UseOr":::

Modify the values of `a`, `b`, and `c` and switch between `&&` and `||` to explore. You gain more understanding of how the `&&` and `||` operators work.

## Use loops to repeat operations

Another important concept to create larger programs is **loops**. You use loops to repeat statements that you want executed more than once. Try this code in the interactive window:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/BranchesAndLoops/Program.cs" id="WhileLoop":::

The `while` statement checks a condition and executes the statement following the `while`. It repeats checking the condition and executing those statements until the condition is false.

There's one other new operator in this example. The `++` after the `counter` variable is the **increment** operator. It adds 1 to the value of counter, and stores that value in the counter variable.

> [!IMPORTANT]
>
> Make sure that the `while` loop condition does switch to false as you execute the code. Otherwise, you create an **infinite loop** where your program never ends. Let's
> not demonstrate that, because the engine that runs your code times out and you see no output from your program.

The `while` loop tests the condition before executing the code following the `while`. The `do` ... `while` loop executes the code first, and then checks the condition. It looks like this:

:::code language="csharp" source="./snippets/BranchesAndLoops/Program.cs" id="DoLoop":::

This `do` loop and the earlier `while` loop work the same.

Let's move on to one last loop statement.

## Work with the for loop

Another common loop statement that you see in C# code is the `for` loop. Try this code in the interactive window:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/BranchesAndLoops/Program.cs" id="ForLoop":::

The preceding `for` loop does the same work as the `while` loop and the `do` loop you already used. The `for` statement has three parts that control how it works:

- The first part is the **for initializer**: `int counter = 0;` declares that `counter` is the loop variable, and sets its initial value to `0`.
- The middle part is the **for condition**: `counter < 10` declares that this `for` loop continues to execute as long as the value of counter is less than 10.
- The final part is the **for iterator**: `counter++` specifies how to modify the loop variable after executing the block following the `for` statement. Here, it specifies that `counter` increments by 1 each time the block executes.

Experiment with these conditions yourself. Try each of the following changes:

- Change the initializer to start at a different value.
- Change the condition to stop at a different value.

When you're done, let's move on to write some code yourself to use what you learned.

There's one other looping statement that isn't covered in this tutorial: the `foreach` statement. The `foreach` statement repeats its statement for every item in a sequence of items. It's most often used with *collections*. It's covered in the next tutorial.

## Created nested loops

A `while`, `do`, or `for` loop can be nested inside another loop to create a matrix using the combination of each item in the outer loop with each item in the inner loop. Let's do that to build a set of alphanumeric pairs to represent rows and columns.

One `for` loop can generate the rows:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/BranchesAndLoops/Program.cs" id="Rows":::

Another loop can generate the columns:

:::code language="csharp" source="./snippets/BranchesAndLoops/Program.cs" id="Columns":::

You can nest one loop inside the other to form pairs:

:::code language="csharp" source="./snippets/BranchesAndLoops/Program.cs" id="Nested":::

You can see that the outer loop increments once for each full run of the inner loop. Reverse the row and column nesting, and see the changes for yourself.

## Combine branches and loops

Now that you saw the `if` statement and the looping constructs in the C# language, see if you can write C# code to find the sum of all integers 1 through 20 that are divisible by 3. Here are a few hints:

- The `%` operator gives you the remainder of a division operation.
- The `if` statement gives you the condition to see if a number should be part of the sum.
- The `for` loop can help you repeat a series of steps for all the numbers 1 through 20.

Try it yourself. Then check how you did. As a hint, you should get 63 for an answer.

Did you come up with something like this?

<!-- markdownlint-disable MD033 -->
<details>
:::code language="csharp" interactive="try-dotnet-method" source="./snippets/BranchesAndLoops/Program.cs" id="Challenge":::
</details>
<!-- markdownlint-enable MD033 -->

You completed the "branches and loops" interactive tutorial. You can select the **list collection** link to start the next interactive tutorial, or you can visit the [.NET site](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro) to download the .NET SDK, create a project on your machine, and keep coding. The "Next steps" section brings you back to these tutorials.

You can learn more about these concepts in these articles:

- [Selection statements](../../language-reference/statements/selection-statements.md)
- [Iteration statements](../../language-reference/statements/iteration-statements.md)
