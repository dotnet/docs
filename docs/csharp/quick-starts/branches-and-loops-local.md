---
title: Branches and loops tutorial - C# local quickstarts
description: In this quickstart about branches and loops, you write C# code to explore the language syntax that supports conditional branches and loops to execute statements repeatedly.
author: billwagner
ms.author: wiwagn
ms.date: 10/31/2017
ms.topic: get-started-article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.custom: mvc
---
# Branches and loops

This quickstart teaches you how to write code that examines variables and changes the execution path based on those variables. You write C# code and see the results of compiling and running it. The quickstart contains a series of lessons that explore branching and looping constructs in C#. These lessons teach you the fundamentals of the C# language.

This quickstart expects you to have a machine you can use for development. The .NET topic [Get Started in 10 minutes](https://www.microsoft.com/net/core) has instructions for setting up your local development environment on Mac, PC or Linux. A quick overview of the commands you'll use is in the [introduction to the local quickstarts](local-environment.md) with links to more details.

## Make decisions using the `if` statement

Create a directory named **branches-quickstart**. Make that the current directory and run `dotnet new console -n BranchesAndLoops -o .`. This command creates a new .NET Core console application in the current directory.

Open **Program.cs** in your favorite editor, and replace the line `Console.Writeline("Hello World!");` with the following code:

```csharp
int a = 5;
int b = 6;
if (a + b > 10)
    Console.WriteLine("The answer is greater than 10.");
```

Try this code by typing `dotnet run` in the your console window. You should see the message "The answer is greater than 10." printed to your console.

Modify the declaration of `b` so that the sum is less than 10: 

```csharp
int b = 3;
```

Type `dotnet run` again. Because the answer is less than 10, nothing is printed. The **condition** you're testing is false. You don't have any code to execute because you've only
written one of the possible branches for an `if` statement: the true branch.

> [!TIP]
> As you explore C# (or any programming language), you'll
> make mistakes when you write code. The compiler will
> find and report the errors. Look closely at the error 
> output and the code that generated the error. The compler
> error can usually help you find the problem.

This first sample shows the power of `if` and Boolean types. A *Boolean* is a variable that can have one of two values: `true` or `false`. C# defines a special type, `bool` for Boolean variables. The `if` statement checks the value of a `bool`. When the value is `true`, the statement following the `if` executes. Otherwise, it is skipped.

This process of checking conditions and executing statements based on those conditions is very powerful.

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

The statement following the `else` keyword executes only when the condition being tested is `false`. Combining `if` and `else` with Boolean conditions provides all the power you need to handle both a `true` and a `false` condition.

> [!IMPORTANT]
> The indentation under the `if` and `else` statements is for human readers.
> The C# language doesn't treat indentation or white space as significant. 
> The statement following the `if` or `else` keyword will be executed based
> on the condition. All the samples in this quickstart follow a common
> practice to indent lines based on the control flow of statements.

Because indentation is not significant, you need to use `{` and `}` to
indicate when you want more than one statement to be part of the block
that executes conditionally. C# programmers typically use those braces
on all `if` and `else` clauses. The following example is the same as the one you
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
> Through the rest of this quickstart, the code samples all include the braces,
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

Comment out the call to `ExploreIf()`. It will make the output less cluttered as you work in this section:

```csharp
//ExploreIf();
```

The `//` starts a **comment** in C#. Comments are any text you want to keep in your source code but not execute as code. The compiler does not generate any executable code from comments.

## Use loops to repeat operations

In this section you use **loops** to repeat statements. Try
this code in your `Main` method:

```csharp
int counter = 0;
while (counter < 10)
{
    Console.WriteLine($"Hello World! The counter is {counter}");
    counter++;
}
```

The `while` statement checks a condition and executes the statement or statement block
following the `while`. It repeatedly checks the condition and
executing those statements until the condition is false.

There's one other new operator in this example. The `++` after
the `counter` variable is the **increment** operator. It adds 1
to the value of `counter` and stores that value in the `counter` variable.

> [!IMPORTANT]
> Make sure that the `while` loop condition changes to
> false as you execute the code. Otherwise, you create an
> **infinite loop** where your program never ends. That is 
> not demonstrated in this sample, because you have to force your program to
> quit using **CTRL-C** or other means.

The `while` loop tests the condition before executing the code
following the `while`. The `do` ... `while` loop executes the 
code first, and then checks the condition. The do while loop is shown in the following code:

```csharp
counter = 0;
do
{
    Console.WriteLine($"Hello World! The counter is {counter}");
    counter++;
} while (counter < 10);
```

This `do` loop and the earlier `while` loop produce the same output.

## Work with the for loop

The **for** loop is commonly used in C#. Try this code in your Main() method:

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
- The `if` statement gives you the condition to see if a number should be part of the sum.
- The `for` loop can help you repeat a series of steps for all the numbers 1 through 20.

Try it yourself. Then check how you did. You should get 63 for an answer. You can see one possible answer by
[viewing the completed code on GitHub](https://github.com/dotnet/samples/tree/master/csharp/branches-quickstart/Program.cs#L46-L54).

You've completed the "branches and loops" quickstart.

You can continue with
the [String interpolation](interpolated-strings-local.md) quickstart in
your own development environment.

You can learn more about these concepts in these topics:

[If and else statement](../language-reference/keywords/if-else.md)  
[While statement](../language-reference/keywords/while.md)  
[Do statement](../language-reference/keywords/do.md)  
[For statement](../language-reference/keywords/for.md)  
