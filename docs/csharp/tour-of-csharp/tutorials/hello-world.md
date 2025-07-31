---
title: Hello World - Introductory interactive tutorial
description: In this tutorial, you use your browser to learn C# interactively. You write C# code and see the results of compiling and running your code directly in the browser.
ms.date: 03/05/2025
---
# Introduction to C# - interactive tutorial

This tutorial teaches you C# interactively, using your browser to write C# and see the results of compiling and running your code. It contains a series of lessons that begin with a "Hello World" program. These lessons teach you the fundamentals of the C# language.

> [!TIP]
>
> When a code snippet block includes the "Run" button, that button opens the interactive window, or replaces the existing code in the interactive window. When the snippet doesn't include a "Run" button, you can copy the code and add it to the current interactive window.

## Run your first program

Run the following code in the interactive window.

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/HelloWorld/Program.cs" id="HelloWorld":::

Congratulations! You ran your first C# program. It's a simple program that prints the message "Hello World!" It used the <xref:System.Console.WriteLine%2A?displayProperty=nameWithType> method to print that message. `Console` is a type that represents the console window. `WriteLine` is a method of the `Console` type that prints a line of text to that text console.

Let's move on and explore more. The rest of this lesson explores working with the `string` type, which represents text in C#. Like the `Console` type, the `string` type has methods. The `string` methods work with text.

## Declare and use variables

Your first program printed the `string` "Hello World!" on the screen.

> [!TIP]
>
> As you explore C# (or any programming language), you make mistakes when you write code. The **compiler** finds those errors and report them to you. When the output contains error messages, look closely at the example code, and the code in the interactive window to see what to fix. That exercise helps you learn the structure of C# code.

Your first program is limited to printing one message. You can write more useful programs by using *variables*. A *variable* is a symbol you can use to run the same code with different values. Let's try it! Start with the following code:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/HelloWorld/Program.cs" id="Variables":::

The first line declares a variable, `aFriend`, and assigns it a value, "Bill". The second line prints the name.

You can assign different values to any variable you declare. You can change the name to one of your friends. Add these two lines in the preceding interactive window following the code you already added. Make sure you keep the declaration of the `aFriend` variable and its initial assignment.

> [!IMPORTANT]
> Don't delete the declaration of `aFriend`. Add the following code at the end of the preceding interactive window:

:::code language="csharp" source="./snippets/HelloWorld/Program.cs" id="Assignment":::

Notice that the same line of code prints two different messages, based on the value stored in the `aFriend` variable.

You might notice that the word "Hello" was missing in the last two messages. Let's fix that now. Modify the lines that print the message to the following code:

:::code language="csharp" source="./snippets/HelloWorld/Program.cs" id="ConcatMessage":::

Select **Run** again to see the results.

You've been using `+` to build strings from **variables** and **constant** strings. There's a better way. You can place a variable between `{` and `}` characters to tell C# to replace that text with the value of the variable.

This process is called [String interpolation](../../language-reference/tokens/interpolated.md).

If you add a `$` before the opening quote of the string, you can then include variables, like `aFriend`, inside the string between curly braces. Give it a try:

Select **Run** again to see the results. Instead of "Hello {aFriend}", the message should be "Hello Maira".

:::code language="csharp" source="./snippets/HelloWorld/Program.cs" id="Interpolation":::

## Work with strings

Your last edit was our first look at what you can do with strings. Let's explore more.

You're not limited to a single variable between the curly braces. Try the following code:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/HelloWorld/Program.cs" id="WorkWithStrings":::

Strings are more than a collection of letters. You can find the length of a string using `Length`. `Length` is a **property** of a string and it returns the number of characters in that string. Add the following code at the bottom of the interactive window:

:::code language="csharp" source="./snippets/HelloWorld/Program.cs" id="Properties":::

> [!TIP]
>
> Now is a good time to explore on your own. You learned that `Console.WriteLine()` writes text to the screen. You learned how to declare variables and concatenate strings together. Experiment in the interactive window. The window has a feature called *IntelliSense* that makes suggestions for what you can do. Type a `.` after the `d` in `firstFriend`. You see a list of suggestions for properties and methods you can use.

You've been using a *method*, <xref:System.Console.WriteLine%2A?displayProperty=nameWithType>, to print messages. A *method* is a block of code that implements some action. It has a name, so you can access it.

## Trim

Suppose your strings have leading or trailing spaces that you don't want to display. You want to **trim** the spaces from the strings.
The <xref:System.String.Trim%2A> method and related methods <xref:System.String.TrimStart%2A> and <xref:System.String.TrimEnd%2A> do that work. You can just use those methods to remove leading and trailing spaces. Try the following code:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/HelloWorld/Program.cs" id="Trim":::

The square brackets `[` and `]` help visualize what the `Trim`, `TrimStart,` and, `TrimEnd` methods do. The brackets show where whitespace starts and ends.

This sample reinforces a couple of important concepts for working with strings. The methods that manipulate strings return new string objects rather than making modifications in place. You can see that each call to any of the `Trim` methods returns a new string but doesn't change the original message.

## Replace

There are other methods available to work with a string. For example, you probably used a search and replace command in an editor or word processor before. The <xref:System.String.Replace%2A> method does something similar in a string. It searches for a substring and replaces it with different text. The <xref:System.String.Replace%2A> method takes two **parameters**. These parameters are the strings between the parentheses. The first string is the text to search for. The second string is the text to replace it with. Try it for yourself. Add this code. Type it in to see the hints as you start typing `.Re` after the `sayHello` variable:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/HelloWorld/Program.cs" id="Replace":::

Two other useful methods make a string ALL CAPS or all lower case. Try the following code. Type it in to see how **IntelliSense** provides hints as you start to type `To`:

:::code language="csharp" source="./snippets/HelloWorld/Program.cs" id="UpperLower":::

## Search strings

The other part of a *search and replace* operation is to find text in a string. You can use the  <xref:System.String.Contains%2A> method for searching. It tells you if a string contains a substring inside it. Try the following code to explore <xref:System.String.Contains%2A>:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/HelloWorld/Program.cs" id="SearchStrings":::

The <xref:System.String.Contains%2A> method returns a *boolean* value which tells you if the string you were searching for was found. A *boolean* stores either a `true` or a `false` value. When displayed as text output, they're capitalized: `True` and `False`, respectively. You learn more about *boolean* values in a later lesson.

## Challenge

There are two similar methods, <xref:System.String.StartsWith%2A> and <xref:System.String.EndsWith%2A> that also search for substrings in a string. These methods find a substring at the beginning or the end of the string. Try to modify the previous sample to use <xref:System.String.StartsWith%2A> and <xref:System.String.EndsWith%2A> instead of <xref:System.String.Contains%2A>. Search for "You" or "goodbye" at the beginning of a string. Search for "hello" or "goodbye" at the end of a string.

> [!NOTE]
>
> Watch your punctuation when you test for the text at the end of the string. If the string ends with a period, you must check for a string that ends with a period.

You should get `true` for starting with "You" and ending with "hello" and `false` for starting with or ending with "goodbye".

Did you come up with something like the following (expand to see the answer):

<!-- markdownlint-disable MD033 -->
<details>

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/HelloWorld/Program.cs" id="Challenge":::
</details>
<!-- markdownlint-enable MD033 -->

You completed the "Hello C#" introduction to C# tutorial. You can select the **Numbers in C#** tutorial to start the next interactive tutorial, or you can visit the [.NET site](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro) to download the .NET SDK, create a project on your machine, and keep coding. The "Next steps" section brings you back to these tutorials.

For further reading on the `string` type:

- [C# programming guide article on strings](../../programming-guide/strings/index.md).
- [How to tips on working with strings](../../how-to/index.md#working-with-strings).
