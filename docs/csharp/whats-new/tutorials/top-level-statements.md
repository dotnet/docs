---
title: Top-level statements - C# tutorial
description: This tutorial shows how you can use top-level statements to experiment and prove concepts while exploring your ideas
ms.date: 08/19/2021
---
# Tutorial: Explore ideas using top-level statements to build code as you learn

In this tutorial, you'll learn how to:

> [!div class="checklist"]
>
> - Learn the rules governing your use of top-level statements.
> - Use top-level statements to explore algorithms.
> - Refactor explorations into reusable components.

## Prerequisites

You'll need to set up your machine to run .NET 6, which includes the C# 10 compiler. The C# 10 compiler is available starting with [Visual Studio 2022](https://visualstudio.microsoft.com/vs/preview/) or [.NET 6 SDK](https://dot.net/get-dotnet6).

This tutorial assumes you're familiar with C# and .NET, including either Visual Studio or the .NET CLI.

## Start exploring

Top-level statements enable you to avoid the extra ceremony required by placing your program's entry point in a static method in a class. The typical starting point for a new console application looks like the following code:

```csharp
using System;

namespace Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
```

The preceding code is the result of running the `dotnet new console` command and creating a new console application. Those 11 lines contain only one line of executable code. You can simplify that program with the new top-level statements feature. That enables you to remove all but two of the lines in this program:

```csharp
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
```

[!INCLUDE [csharp10-templates](../../../../includes/csharp10-templates.md)]

This feature simplifies what's needed to begin exploring new ideas. You can use top-level statements for scripting scenarios, or to explore. Once you've got the basics working, you can start refactoring the code and create methods, classes, or other assemblies for reusable components you've built. Top-level statements do enable quick experimentation and beginner tutorials. They also provide a smooth path from experimentation to full programs.

Top-level statements are executed in the order they appear in the file. Top-level statements can only be used in one source file in your application. The compiler generates an error if you use them in more than one file.

## Build a magic .NET answer machine

For this tutorial, let's build a console application that answers a "yes" or "no" question with a random answer. You'll build out the functionality step by step. You can focus on your task rather than ceremony needed for the structure of a typical program. Then, once you're happy with the functionality, you can refactor the application as you see fit.

A good starting point is to write the question back to the console. You can start by writing the following code:

```csharp
Console.WriteLine(args);
```

You don't declare an `args` variable. For the single source file that contains your top-level statements, the compiler recognizes `args` to mean the command-line arguments. The type of args is a `string[]`, as in all C# programs.

You can test your code by running the following `dotnet run` command:

```dotnetcli
dotnet run -- Should I use top level statements in all my programs?
```

The arguments after the `--` on the command line are passed to the program. You can see the type of the `args` variable, because that's what's printed to the console:

```console
System.String[]
```

To write the question to the console, you'll need to enumerate the arguments and separate them with a space. Replace the `WriteLine` call with the following code:

:::code language="csharp" source="snippets/top-level-statements/ProgramSnippets.cs" ID="EchoInput":::

Now, when you run the program, it will correctly display the question as a string of arguments.

## Respond with a random answer

After echoing the question, you can add the code to generate the random answer. Start by adding an array of possible answers:

:::code language="csharp" source="snippets/top-level-statements/ProgramSnippets.cs" ID="Answers":::

This array has ten answers that are affirmative, five that are non-committal, and five that are negative. Next, add the following code to generate and display a random answer from the array:

:::code language="csharp" source="snippets/top-level-statements/ProgramSnippets.cs" ID="GenerateAnswer":::

You can run the application again to see the results. You should see something like the following output:

```dotnetcli
dotnet run -- Should I use top level statements in all my programs?

Should I use top level statements in all my programs?
Better not tell you now.
```

This code answers the questions, but let's add one more feature. You'd like your question app to simulate thinking about the answer. You can do that by adding a bit of ASCII animation, and pausing while working.  Add the following code after the line that echoes the question:

:::code language="csharp" source="snippets/top-level-statements/UtilitiesPassOne.cs" ID="AnimationFirstPass":::

You'll also need to add a `using` statement to the top of the source file:

```csharp
using System.Threading.Tasks;
```

The `using` statements must be before any other statements in the file. Otherwise, it's a compiler error. You can run the program again and see the animation. That makes a better experience. Experiment with the length of the delay to match your taste.

The preceding code creates a set of spinning lines separated by a space. Adding the `await` keyword instructs the compiler to generate the program entry point as a method that has the `async` modifier, and returns a <xref:System.Threading.Tasks.Task?displayProperty=nameWithType>. This program doesn't return a value, so the program entry point returns a `Task`. If your program returns an integer value, you would add a return statement to the end of your top-level statements. That return statement would specify the integer value to return. If your top-level statements include an `await` expression, the return type becomes <xref:System.Threading.Tasks.Task%601?displayProperty=nameWithType>.

## Refactoring for the future

Your program should look like the following code:

```csharp
Console.WriteLine();
foreach(var s in args)
{
    Console.Write(s);
    Console.Write(' ');
}
Console.WriteLine();

for (int i = 0; i < 20; i++)
{
    Console.Write("| -");
    await Task.Delay(50);
    Console.Write("\b\b\b");
    Console.Write("/ \\");
    await Task.Delay(50);
    Console.Write("\b\b\b");
    Console.Write("- |");
    await Task.Delay(50);
    Console.Write("\b\b\b");
    Console.Write("\\ /");
    await Task.Delay(50);
    Console.Write("\b\b\b");
}
Console.WriteLine();

string[] answers =
{
    "It is certain.",       "Reply hazy, try again.",     "Don't count on it.",
    "It is decidedly so.",  "Ask again later.",           "My reply is no.",
    "Without a doubt.",     "Better not tell you now.",   "My sources say no.",
    "Yes – definitely.",    "Cannot predict now.",        "Outlook not so good.",
    "You may rely on it.",  "Concentrate and ask again.", "Very doubtful.",
    "As I see it, yes.",
    "Most likely.",
    "Outlook good.",
    "Yes.",
    "Signs point to yes.",
};

var index = new Random().Next(answers.Length - 1);
Console.WriteLine(answers[index]);
```

The preceding code is reasonable. It works. But it isn't reusable. Now that you have the application working, it's time to pull out reusable parts.

One candidate is the code that displays the waiting animation. That snippet can become a method:

You can start by creating a local function in your file. Replace the current animation with the following code:

```csharp
await ShowConsoleAnimation();

static async Task ShowConsoleAnimation()
{
    for (int i = 0; i < 20; i++)
    {
        Console.Write("| -");
        await Task.Delay(50);
        Console.Write("\b\b\b");
        Console.Write("/ \\");
        await Task.Delay(50);
        Console.Write("\b\b\b");
        Console.Write("- |");
        await Task.Delay(50);
        Console.Write("\b\b\b");
        Console.Write("\\ /");
        await Task.Delay(50);
        Console.Write("\b\b\b");
    }
    Console.WriteLine();
}
```

The preceding code creates a local function inside your main method. That's still not reusable. So, extract that code into a class. Create a new file named *utilities.cs* and add the following code:

:::code language="csharp" source="snippets/top-level-statements/UtilitiesPassOne.cs" ID="SnippetUtilities":::

A file that has top-level statements can also contain namespaces and types at the end of the file, after the top-level statements. But for this tutorial you put the animation method in a separate file to make it more readily reusable.

Finally, you can clean the animation code to remove some duplication:

:::code language="csharp" source="snippets/top-level-statements/Utilities.cs" ID="Animation":::

Now you have a complete application, and you've refactored the reusable parts for later use. You can call the new utility method from your top-level statements, as shown below in the finished version of the main program:

:::code language="csharp" source="snippets/top-level-statements/Program.cs":::

The preceding example adds the call to `Utilities.ShowConsoleAnimation`, and adds an additional `using` statement.

## Summary

Top-level statements make it easier to create simple programs for use to explore new algorithms. You can experiment with algorithms by trying different snippets of code. Once you've learned what works, you can refactor the code to be more maintainable.

Top-level statements simplify programs that are based on console applications. These include Azure functions, GitHub actions, and other small utilities. For more information, see [Top-level statements (C# Programming Guide)](../../fundamentals/program-structure/top-level-statements.md).
