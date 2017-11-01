---
title: Quick Start - Branches and lops - C# Guide
description: In this quick start about branches and loops, you'll write C# code to explore the language syntax that supports conditional branches and loops to repeat statements.
author: billwagner
ms.author: wiwagn
ms.date: 10/31/2017
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.custom: mvc
---

# Branches and loops

This quick start teaches you about how to write code that examines variables and changes execution path based on those variables. You'll write C# and see the results of compiling and running your code. It contains a series of lessons that explore branching and looping constructs in C#. These lessons teach you the fundamentals of the C# language.

This quick start expects you to have a machine you can use for development. The .NET topic [Get Started in 10 minutes](https://www.microsoft.com/net/core) has instructions for setting up your local development environment on Mac, PC or Linux.

## Make decisions using the `if` statement

Create a directory named **branches-quickstart**. Make that the current directory and run `dotnet new console -n BranchesAndLoops -o .`.

Open **Program.cs** in your favorite editor, and replace the line `Console.Writeline("Hello World!");` with the following:

```csharp
int a = 5;
int b = 6;
if (a + b > 10)
    Console.WriteLine("The answer is greater than 10.");
```

Try this code by typing `dotnet run` in the your console window.

Modify the declaration of `b` so that the sum is less than 10: 

```csharp
int b = 3;
```

Type `dotnet run` again. Because the answer is less than 10, nothing is printed. The **condition** you're testing is false. You don't have any code to execute because you've only
written one of the possible branches for an `if` statement: the true branch.

> [!TIP]
> As you explore C# (or any programming language), you'll
> make mistakes when you write code. The **compiler** will
> find those errors and report them to you. When the output
> contains error messages, look closely at the example code,
> and the code in the interactive window to see what to fix.
> That exercise will help you learn the structure of C# code.     

This first sample shows the power of `if` and boolean types. A *boolean* is a variable that can have one of two values: `true` or `false`. C# defines a special type, `bool` for boolean variables. The `if` statement checks the value of a `bool`. When the value is `true`, the statement following the `if` executes. Otherwise, it is skipped. 

This process of checking conditions and executing statements based on those conditions is very powerful. Let's explore more


## Make if and else work together

To execute different code in both the true and false branches, you 
create an `else` branch that executes when the condition is false. Try this. Add the last two lines in the code below to your `Main` method (you should already have the first four):

```csharp
int a = 5;
int b = 3;
if (a + b > 10)
    Console.WriteLine("The answer is greater than 10");
else
    Console.WriteLine("The answer is not greater than 10");
```

The statement following the `else` keyword executes only when the condition being tested is `false`. Combining `if` and `else` with boolean conditions provides all the power you need.

> [!IMPORTANT]
> The indentation under the `if` and `else` statements is for human readers.
> The C# language doesn't treat indentation or whitespace as significant. 
> The statement following the `if` or `else` keyword will be executed based
> on the condition. All the samples in this quick start follow a common
> practice to indent lines based on execution.

Because indentation is not significant, you need to use `{` and `}` to
indicate when you want more than one statement to be part of the block
that executes conditionally. C# programmers typically use those braces
on all `if` and `else` clauses. The following example is the same as what you
just created. Modify your code above to match the following code:

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
> Through the rest of this quick start, the code samples all include the braces,
> following accepted practices.

You can test more complicated conditions. Add the following code in your `Main` method after the code you've written so far:

```csharp
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
```

The `&&` represents "and". It means both conditions must be true to execute
the statement in the true branch.  These examples also show that you can have multiple
statements in each conditional branch, provided you enclose them in `{` and `}`.

You can also use  `||` to represent "or". Add the following code after what you've written so far:

```csharp
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
```

You've finished the first step. Before you start the next section, let's move the current code into a separate method. That makes it easier to start working with a new example. Rename your `Main` method to `ExploreIf` and write a new `Main` method that calls `ExploreIf`. When you have finished, your code should look like this:

```csharp
using System;

namespace BranchesAndLoops
{
    class Program
    {
        static void ExploreIf()
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

        static void Main(string[] args)
        {
            ExploreIf();
        }
    }
}
```

## Use loops to repeat operations

Comment out the call to `ExploreIf()`. It will make the output less cluttered as you work in this section:

```csharp
//ExploreIf();
```

The `//` starts a **comment** in C#. Comments are any text you want to keep in your source code, but not execute as code. The compiler does not generate any executable code from comments.

Another important concept to create larger programs is **loops**. You'll
use loops to repeat statements that you want executed more than once. Try
this code in your `Main` method:

```csharp
int counter = 0;
while (counter < 10)
{
  Console.WriteLine($"Hello World! The counter is {counter}");
  counter++;
}
```

The `while` statement checks a condition and executes the statement
following the `while`. It will repeat checking the condition and
executing those statements until the condition is false.

There's one other new operator in this example. The `++` after
the `counter` variable is the **increment** operator. It adds 1
to the value of counter, and stores that value in the counter variable.

> [!IMPORTANT]
> Make sure that the `while` loop condition does switch to
> false as you execute the code. Otherwise, you create an
> **infinite loop** where your program never ends. Let's
> not demonstrate that, because you have to force your program to
> quit using **CTRL-C** or other means.

The `while` loop tests the condition before executing the code
following the `while`. The `do` ... `while` loop executes the 
code first, and then checks the condition. It looks like this:

```csharp
counter = 0;
do
{
  Console.WriteLine($"Hello World! The counter is {counter}");
  counter++;
} while (counter < 10);
```

This `do` loop and the earlier `while` loop work the same. 

Let's move on to one last loop statement.

## Work with the for loop

Another common loop statement that you'll see in C# code is the
`for` loop. Try this code in the interactive window:

```csharp
for(int index = 0; index < 10; index++)
{
  Console.WriteLine($"Hello World! The index is {index}");
} 
```

This does the same work as the `while` loop and the `do` loop you've
already used. The `for` statement has three parts that control
how it works. 

The first part is the **for initializer**: `for index = 0;` declares
that `index` is the loop variable, and sets its initial value to `0`.

The middle part is the **for condition**: `index < 10` declares that this
`for` loop continues to execute as long as the value of counter is less than 10.

The final part is the **for iterator**: `index++` specifies how to modify the loop
variable after executing the block following the `for` statement. Here, it specifies
that `index` should be incremented by 1 each time the block executes.

Experiment with these yourself. Try each of the following:

- Change the initializer to start at a different value.
- Change the condition to stop at a different value.

When you're done, let's move on to write some code yourself to
use what you've learned.

## Combine branches and loops

Now that you've seen the `if` statement and the looping
constructs in the C# language, see if you can write C# code to
find the sum of all integers 1 through 20 that are divisible
by 3.  Here are a few hints:

- The `%` operator gives you the remainder of a division operation.
- The `if` statement givesx you the condition to see if a number should be part of the sum.
- The `for` loop can help you repeat a series of steps for all the numbers 1 through 20.

Try it yourself. Then check how you did. You can see one possible answer by
[looking at the finished sample code on GitHub](https://github.com/dotnet/docs/tree/master/samples/csharp/branches-quickstart/Program.cs#L46-L54).

You've completed the "branches and loops" quick start.

You can continue with
the [Arrays and collections](arrays-and-collections.md) quick start in
your own development environment.

You can learn more about these concepts in these topics:

[If and else statement](../language-reference/keywords/if-else.md)   
[While statement](../language-reference/keywords/while.md)   
[Do statement](../language-reference/keywords/do.md)   
[For statement](../language-reference/keywords/for.md)   
