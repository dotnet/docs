---
title: Branches and loops - Introduction to C# tutorial
description: In this tutorial about branches and loops, you write C# code to explore the language syntax that supports conditional branches and loops to execute statements repeatedly.
ms.date: 02/05/2021
---

# Learn conditional logic with branch and loop statements

This tutorial teaches you how to write code that examines variables and changes the execution path based on those variables. You write C# code and see the results of compiling and running it. The tutorial contains a series of lessons that explore branching and looping constructs in C#. These lessons teach you the fundamentals of the C# language.

## Prerequisites

The tutorial expects that you have a machine set up for local development. On Windows, Linux, or macOS, you can use the .NET CLI to create, build, and run applications. On Mac and Windows, you can use Visual Studio 2019. For setup instructions, see [Set up your local environment](local-environment.md).

## Make decisions using the `if` statement

Create a directory named *branches-tutorial*. Make that the current directory and run the following command:

```dotnetcli
dotnet new console -n BranchesAndLoops -o .
```

[!INCLUDE [csharp10-templates](../../../../includes/csharp10-templates.md)]

This command creates a new .NET console application in the current directory. Open *Program.cs* in your favorite editor, and replace the contents with the following code:

```csharp
using System;

int a = 5;
int b = 6;
if (a + b > 10)
    Console.WriteLine("The answer is greater than 10.");
```

Try this code by typing `dotnet run` in your console window. You should see the message "The answer is greater than 10." printed to your console. Modify the declaration of `b` so that the sum is less than 10:

```csharp
int b = 3;
```

Type `dotnet run` again. Because the answer is less than 10, nothing is printed. The **condition** you're testing is false. You don't have any code to execute because you've only written one of the possible branches for an `if` statement: the true branch.

> [!TIP]
> As you explore C# (or any programming language), you'll make mistakes when you write code. The compiler will find and report the errors. Look closely at the error output and the code that generated the error. The compiler error can usually help you find the problem.

This first sample shows the power of `if` and Boolean types. A *Boolean* is a variable that can have one of two values: `true` or `false`. C# defines a special type, `bool` for Boolean variables. The `if` statement checks the value of a `bool`. When the value is `true`, the statement following the `if` executes. Otherwise, it's skipped. This process of checking conditions and executing statements based on those conditions is powerful.

## Make if and else work together

To execute different code in both the true and false branches, you create an `else` branch that executes when the condition is false. Try an `else` branch. Add the last two lines in the code below (you should already have the first four):

```csharp
int a = 5;
int b = 3;
if (a + b > 10)
    Console.WriteLine("The answer is greater than 10");
else
    Console.WriteLine("The answer is not greater than 10");
```

The statement following the `else` keyword executes only when the condition being tested is `false`. Combining `if` and `else` with Boolean conditions provides all the power you need to handle both a `true` and a `false` condition.

> [!IMPORTANT]
> The indentation under the `if` and `else` statements is for human readers. The C# language doesn't treat indentation or white space as significant. The statement following the `if` or `else` keyword will be executed based on the condition. All the samples in this tutorial follow a common practice to indent lines based on the control flow of statements.

Because indentation isn't significant, you need to use `{` and `}` to indicate when you want more than one statement to be part of the block that executes conditionally. C# programmers typically use those braces on all `if` and `else` clauses. The following example is the same as the one you created. Modify your code above to match the following code:

```csharp
int a = 5;
int b = 3;
if (a + b > 10)
{
    Console.WriteLine("The answer is greater than 10");
}
else
{
    Console.WriteLine("The answer is not greater than 10");
}
```

> [!TIP]
> Through the rest of this tutorial, the code samples all include the braces, following accepted practices.

You can test more complicated conditions. Add the following code after the code you've written so far:

```csharp
int c = 4;
if ((a + b + c > 10) && (a == b))
{
    Console.WriteLine("The answer is greater than 10");
    Console.WriteLine("And the first number is equal to the second");
}
else
{
    Console.WriteLine("The answer is not greater than 10");
    Console.WriteLine("Or the first number is not equal to the second");
}
```

The `==` symbol tests for *equality*. Using `==` distinguishes the test for equality from assignment, which you saw in `a = 5`.

The `&&` represents "and". It means both conditions must be true to execute the statement in the true branch.  These examples also show that you can have multiple statements in each conditional branch, provided you enclose them in `{` and `}`. You can also use  `||` to represent "or". Add the following code after what you've written so far:

```csharp
if ((a + b + c > 10) || (a == b))
{
    Console.WriteLine("The answer is greater than 10");
    Console.WriteLine("Or the first number is equal to the second");
}
else
{
    Console.WriteLine("The answer is not greater than 10");
    Console.WriteLine("And the first number is not equal to the second");
}
```

Modify the values of `a`, `b`, and `c` and switch between `&&` and `||` to explore. You'll gain more understanding of how the `&&` and `||` operators work.

You've finished the first step. Before you start the next section, let's move the current code into a separate method. That makes it easier to start working with a new example. Put the existing code in a method called `ExploreIf()`. Call it from the top of your program. When you finished those changes, your code should look like the following:

```csharp
using System;

ExploreIf();

void ExploreIf()
{
    int a = 5;
    int b = 3;
    if (a + b > 10)
    {
        Console.WriteLine("The answer is greater than 10");
    }
    else
    {
        Console.WriteLine("The answer is not greater than 10");
    }

    int c = 4;
    if ((a + b + c > 10) && (a > b))
    {
        Console.WriteLine("The answer is greater than 10");
        Console.WriteLine("And the first number is greater than the second");
    }
    else
    {
        Console.WriteLine("The answer is not greater than 10");
        Console.WriteLine("Or the first number is not greater than the second");
    }

    if ((a + b + c > 10) || (a > b))
    {
        Console.WriteLine("The answer is greater than 10");
        Console.WriteLine("Or the first number is greater than the second");
    }
    else
    {
        Console.WriteLine("The answer is not greater than 10");
        Console.WriteLine("And the first number is not greater than the second");
    }
}
```

Comment out the call to `ExploreIf()`. It will make the output less cluttered as you work in this section:

```csharp
//ExploreIf();
```

The `//` starts a **comment** in C#. Comments are any text you want to keep in your source code but not execute as code. The compiler doesn't generate any executable code from comments.

## Use loops to repeat operations

In this section, you use **loops** to repeat statements. Add this code after the call to `ExploreIf`:

```csharp
int counter = 0;
while (counter < 10)
{
    Console.WriteLine($"Hello World! The counter is {counter}");
    counter++;
}
```

The `while` statement checks a condition and executes the statement or statement block following the `while`. It repeatedly checks the condition and executing those statements until the condition is false.

There's one other new operator in this example. The `++` after the `counter` variable is the **increment** operator. It adds 1 to the value of `counter` and stores that value in the `counter` variable.

> [!IMPORTANT]
> Make sure that the `while` loop condition changes to false as you execute the code. Otherwise, you create an **infinite loop** where your program never ends. That is not demonstrated in this sample, because you have to force your program to quit using **CTRL-C** or other means.

The `while` loop tests the condition before executing the code following the `while`. The `do` ... `while` loop executes the code first, and then checks the condition. The *do while* loop is shown in the following code:

```csharp
int counter = 0;
do
{
    Console.WriteLine($"Hello World! The counter is {counter}");
    counter++;
} while (counter < 10);
```

This `do` loop and the earlier `while` loop produce the same output.

## Work with the for loop

The **for** loop is commonly used in C#. Try this code:

```csharp
for (int index = 0; index < 10; index++)
{
    Console.WriteLine($"Hello World! The index is {index}");
}
```

The previous code does the same work as the `while` loop and the `do` loop you've already used. The `for` statement has three parts that control how it works.

The first part is the **for initializer**: `int index = 0;` declares that `index` is the loop variable, and sets its initial value to `0`.

The middle part is the **for condition**: `index < 10` declares that this `for` loop continues to execute as long as the value of counter is less than 10.

The final part is the **for iterator**: `index++` specifies how to modify the loop variable after executing the block following the `for` statement. Here, it specifies that `index` should be incremented by 1 each time the block executes.

Experiment yourself. Try each of the following variations:

- Change the initializer to start at a different value.
- Change the condition to stop at a different value.

When you're done, let's move on to write some code yourself to use what you've learned.

There's one other looping statement that isn't covered in this tutorial: the `foreach` statement. The `foreach` statement repeats its statement for every item in a sequence of items. It's most often used with *collections*, so it's covered in the next tutorial.

## Created nested loops

A `while`, `do`, or `for` loop can be nested inside another loop to create a matrix using the combination of each item in the outer loop with each item in the inner loop. Let's do that to build a set of alphanumeric pairs to represent rows and columns.

One `for` loop can generate the rows:

```csharp
for (int row = 1; row < 11; row++)
{
    Console.WriteLine($"The row is {row}");
}
```

Another loop can generate the columns:

```csharp
for (char column = 'a'; column < 'k'; column++)
{
    Console.WriteLine($"The column is {column}");
}
```

You can nest one loop inside the other to form pairs:

```csharp
for (int row = 1; row < 11; row++)
{
    for (char column = 'a'; column < 'k'; column++)
    {
        Console.WriteLine($"The cell is ({row}, {column})");
    }
}
```

You can see that the outer loop increments once for each full run of the inner loop. Reverse the row and column nesting, and see the changes for yourself. When you're done, place the code from this section in a method called `ExploreLoops()`.

## Combine branches and loops

Now that you've seen the `if` statement and the looping
constructs in the C# language, see if you can write C# code to
find the sum of all integers 1 through 20 that are divisible
by 3.  Here are a few hints:

- The `%` operator gives you the remainder of a division operation.
- The `if` statement gives you the condition to see if a number should be part of the sum.
- The `for` loop can help you repeat a series of steps for all the numbers 1 through 20.

Try it yourself. Then check how you did. You should get 63 for an answer. You can see one possible answer by
[viewing the completed code on GitHub](https://github.com/dotnet/samples/blob/main/csharp/branches-quickstart/Program.cs#L87-L95).

You've completed the "branches and loops" tutorial.

You can continue with
the [Arrays and collections](arrays-and-collections.md) tutorial in
your own development environment.

You can learn more about these concepts in these articles:

- [Selection statements](../../language-reference/statements/selection-statements.md)
- [Iteration statements](../../language-reference/statements/iteration-statements.md)
