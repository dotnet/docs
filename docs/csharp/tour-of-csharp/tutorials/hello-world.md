---
title: Hello World - Introductory tutorial
description: In this tutorial, you create your first C# apps. You write C# code and learn basic structure and types in C#.
ms.date: 02/06/2026
# customer intent: As an aspiring developer, I want to learn C#.
---
# Tutorial: Explore the C# language

This tutorial teaches you C#. You write your first C# program and see the results of compiling and running your code. It contains a series of lessons that begin with a "Hello World" program. These lessons teach you the fundamentals of the C# language.

> [!TIP]
> **New to programming?** Start here - this tutorial assumes no prior experience. **Coming from another language?** You might prefer to skim the code samples and jump ahead to [Numbers in C#](numbers-in-csharp.md) or [Branches and loops](branches-and-loops.md).

In this tutorial, you:

> [!div class="checklist"]
>
> * Launch a GitHub Codespace with a C# development environment.
> * Create your first C# app.
> * Create and use variables to store text data.
> * Use .NET APIs with text data.

## Prerequisites

You must have one of the following options:

- A GitHub account to use [GitHub Codespaces](https://github.com/codespaces). If you don't already have one, you can create a free account at [GitHub.com](https://github.com).
- A computer with the following tools installed:
  - The [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
  - [Visual Studio Code](https://code.visualstudio.com/download).
  - The [C# DevKit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).

## Open Codespaces

To start a GitHub Codespace with the tutorial environment, open a browser window to the [tutorial codespace](https://github.com/dotnet/tutorial-codespace) repository. Select the green *Code* button, and the *Codespaces* tab. Then select the `+` sign to create a new Codespace using this environment.

## Run your first program

1. When your codespace loads, create a new file in the *tutorials* folder named *hello-world.cs*.
1. Open your new file.
1. Type or copy the following code into *hello-world.cs*:

   :::code language="csharp" source="./snippets/HelloWorld/hello-world.cs" id="HelloWorld":::

1. In the integrated terminal window, make the *tutorials* folder the current folder, and run your program:

   ```dotnetcli
   cd tutorials
   dotnet hello-world.cs
   ```

You ran your first C# program. It's a simple program that prints the message "Hello World!" It uses the <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> method to print that message. `Console` is a type that represents the console window. `WriteLine` is a method of the `Console` type that prints a line of text to that text console.

Let's move on and explore more. The rest of this lesson explores working with the `string` type, which represents text in C#. Like the `Console` type, the `string` type has methods. The `string` methods work with text.

## Declare and use variables

Your first program prints the `string` "Hello World!" on the screen.

> [!TIP]
>
> As you explore C# (or any programming language), you make mistakes when you write code. The **compiler** finds those errors and reports them to you. When the output contains error messages, look closely at the example code and the code in your `.cs` file to see what to fix. That exercise helps you learn the structure of C# code. You can also ask Copilot to find differences or spot mistakes.

Your first program is limited to printing one message. You can write more useful programs by using *variables*. A *variable* is a symbol you can use to run the same code with different values. Let's try it!

1. Start with the following code:

   :::code language="csharp" source="./snippets/HelloWorld/hello-world.cs" id="Variables":::

   The first line declares a variable, `aFriend`, and assigns it a value, "Bill". The second line prints the name.

1. You can assign different values to any variable you declare. You can change the name to one of your friends. Add these two lines following the code you already added. Make sure you keep the declaration of the `aFriend` variable and its initial assignment.

   > [!IMPORTANT]
   > Don't delete the declaration of `aFriend`.

1. Add the following code at the end of the preceding code:

   :::code language="csharp" source="./snippets/HelloWorld/hello-world.cs" id="Assignment":::

   Notice that the same line of code prints two different messages, based on the value stored in the `aFriend` variable. You might notice that the word "Hello" is missing in the last two messages. Let's fix that now.

1. Modify the lines that print the message to the following code:

   :::code language="csharp" source="./snippets/HelloWorld/hello-world.cs" id="ConcatMessage":::

1. Run the app again by using `dotnet hello-world.cs` to see the results.

   You've been using `+` to build strings from **variables** and **constant** strings. There's a better way. You can place a variable between `{` and `}` characters to tell C# to replace that text with the value of the variable. This process is called [String interpolation](../../language-reference/tokens/interpolated.md).

1. If you add a `$` before the opening quote of the string, you can then include variables, like `aFriend`, inside the string between curly braces. Give it a try:

   :::code language="csharp" source="./snippets/HelloWorld/hello-world.cs" id="Interpolation":::

1. Run the app again by using `dotnet hello-world.cs` to see the results. Instead of "Hello {aFriend}", the message should be "Hello Maira".

## Work with strings

Your last edit was your first look at what you can do with strings. Let's explore more.

You're not limited to a single variable between the curly braces.

1. Try the following code at the bottom of your app:

   :::code language="csharp" source="./snippets/HelloWorld/hello-world.cs" id="WorkWithStrings":::

   Strings are more than a collection of letters. You can find the length of a string by using `Length`. `Length` is a **property** of a string and it returns the number of characters in that string.

1. Add the following code at the bottom of your app:

   :::code language="csharp" source="./snippets/HelloWorld/hello-world.cs" id="Properties":::

> [!TIP]
>
> Now is a good time to explore on your own. You learned that `Console.WriteLine()` writes text to the screen. You learned how to declare variables and concatenate strings together. Experiment in your code. Your editor has a feature called *IntelliSense* that makes suggestions for what you can do. Type a `.` after the `d` in `firstFriend`. You see a list of suggestions for properties and methods you can use.

You've been using a *method*, <xref:System.Console.WriteLine%2A?displayProperty=nameWithType>, to print messages. A *method* is a block of code that implements some action. It has a name, so you can access it.

> [!TIP]
> **Learn more:** Explore [strings](../../programming-guide/strings/index.md) in depth, or read about [methods and program structure](../../fundamentals/program-structure/index.md) in the C# Fundamentals section.

## Remove whitespace from strings

Suppose your strings have leading or trailing spaces that you don't want to display. You want to **trim** the spaces from the strings.
The <xref:System.String.Trim%2A> method and related methods <xref:System.String.TrimStart%2A> and <xref:System.String.TrimEnd%2A> perform this task. Use these methods to remove leading and trailing spaces.

1. Try the following code:

   :::code language="csharp" source="./snippets/HelloWorld/hello-world.cs" id="Trim":::

The square brackets `[` and `]` help you visualize what the `Trim`, `TrimStart`, and `TrimEnd` methods do. The brackets show where whitespace starts and ends.

This sample reinforces a couple of important concepts for working with strings. The methods that manipulate strings return new string objects rather than making modifications in place. You can see that each call to any of the `Trim` methods returns a new string but doesn't change the original message.

## Search and replace text in strings

You can use other methods to work with a string. For example, you might use a search and replace command in an editor or word processor. The <xref:System.String.Replace%2A> method does something similar in a string. It searches for a substring and replaces it with different text. The <xref:System.String.Replace%2A> method takes two **parameters**. These parameters are the strings between the parentheses. The first string is the text to search for. The second string is the text to replace it with. Try it for yourself.

1. Add this code. Type it in to see the hints as you start typing `.Re` after the `sayHello` variable:

   :::code language="csharp" source="./snippets/HelloWorld/hello-world.cs" id="Replace":::

   Two other useful methods make a string all caps or all lowercase. Try the following code.

1. Type it in to see how **IntelliSense** provides hints as you start to type `To`:

   :::code language="csharp" source="./snippets/HelloWorld/hello-world.cs" id="UpperLower":::

   The other part of a *search and replace* operation is to find text in a string. You can use the  <xref:System.String.Contains%2A> method for searching. It tells you if a string contains a substring inside it.

1. Try the following code to explore <xref:System.String.Contains%2A>:

   :::code language="csharp" source="./snippets/HelloWorld/hello-world.cs" id="SearchStrings":::

   The <xref:System.String.Contains%2A> method returns a *boolean* value that tells you if the string you were searching for was found. A *boolean* stores either a `true` or a `false` value. When displayed as text output, they're capitalized: `True` and `False`, respectively. You learn more about *boolean* values in a later lesson.

## Challenge

Two similar methods, <xref:System.String.StartsWith%2A> and <xref:System.String.EndsWith%2A>, also search for substrings in a string. These methods find a substring at the beginning or the end of the string. Try to modify the previous sample to use <xref:System.String.StartsWith%2A> and <xref:System.String.EndsWith%2A> instead of <xref:System.String.Contains%2A>. Search for "You" or "goodbye" at the beginning of a string. Search for "hello" or "goodbye" at the end of a string.

> [!NOTE]
>
> Watch your punctuation when you test for the text at the end of the string. If the string ends with a period, you must check for a string that ends with a period.

You should get `true` for starting with "You" and ending with "hello" and `false` for starting with or ending with "goodbye".

Did you come up with something like the following code (expand to see the answer):

<!-- markdownlint-disable MD033 -->
<details>

:::code language="csharp" source="./snippets/HelloWorld/hello-world.cs" id="Challenge":::
</details>
<!-- markdownlint-enable MD033 -->

For further reading on the `string` type:

- [C# programming guide article on strings](../../programming-guide/strings/index.md).
- [How to tips on working with strings](../../how-to/index.md#working-with-strings).

## Cleanup resources

GitHub automatically deletes your Codespace after 30 days of inactivity. If you plan to explore more tutorials in this series, you can leave your Codespace provisioned. If you're ready to visit the [.NET site](https://dotnet.microsoft.com/download/dotnet) to download the .NET SDK, you can delete your Codespace. To delete your Codespace, open a browser window and navigate to [your Codespaces](https://github.com/codespaces). You should see a list of your codespaces in the window. Select the three dots (`...`) in the entry for the learn tutorial codespace and select "delete".

## Next steps

Continue to the next tutorial in this series, or explore related topics in C# Fundamentals:

> [!div class="nextstepaction"]
> [Explore numbers in C#](numbers-in-csharp.md)

- [Strings](../../programming-guide/strings/index.md) — Learn more about the `string` type you used in this tutorial.
- [Methods and program structure](../../fundamentals/program-structure/index.md) — Understand how C# programs are organized.
- [File-based programs](../../fundamentals/tutorials/file-based-programs.md) — Learn about the `dotnet run` command you used to run your code.
