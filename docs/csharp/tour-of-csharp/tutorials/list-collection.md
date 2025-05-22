---
title: Data collections - Introductory interactive tutorial
description: In this tutorial, you use your browser to learn about C# collections. You write C# code and see the results of compiling and running your code directly in the browser.
ms.date: 03/07/2025
---
# Learn to manage data collections using List\<T> in C\#

This introductory tutorial provides an introduction to the C# language and the basics of the  class.

This tutorial teaches you C# interactively, using your browser to write C# code and see the results of compiling and running your code. It contains a series of lessons that create, modify, and explore collections and arrays. You work primarily with the <xref:System.Collections.Generic.List%601> class.

## A basic list example

> [!TIP]
>
> When a code snippet block includes the "Run" button, that button opens the interactive window, or replaces the existing code in the interactive window. When the snippet doesn't include a "Run" button, you can copy the code and add it to the current interactive window.

Run the following code in the interactive window. Replace `<name>` with your name and select **Run**:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/ListCollection/Program.cs" id="BasicList":::

You created a list of strings, added three names to that list, and printed the names in all CAPS. You're using concepts that you learned in earlier tutorials to loop through the list.

The code to display names makes use of the [string interpolation](../../language-reference/tokens/interpolated.md) feature. When you precede a `string` with the `$` character, you can embed C# code in the string declaration. The actual string replaces that C# code with the value it generates. In this example, it replaces the `{name.ToUpper()}` with each name, converted to capital letters, because you called the <xref:System.String.ToUpper%2A?displayProperty=nameWithType> method.

Let's keep exploring.

## Modify list contents

The collection you created uses the <xref:System.Collections.Generic.List%601> type. This type stores sequences of elements. You specify the type of the elements between the angle brackets.

One important aspect of this <xref:System.Collections.Generic.List%601> type is that it can grow or shrink, enabling you to add or remove elements. You can see the results by modifying the contents after you displayed its contents. Add the following code after the code you already wrote (the loop that prints the contents):

:::code language="csharp" source="./snippets/ListCollection/Program.cs" id="ModifyList":::

You added two more names to the end of the list. You also removed one as well. The output from this block of code shows the initial contents, then prints a blank line and the new contents.

The <xref:System.Collections.Generic.List%601> enables you to reference individual items by **index** as well. You access items using the `[` and `]` tokens. Add the following code after what you already wrote and try it:

:::code language="csharp" source="./snippets/ListCollection/Program.cs" id="Indexers":::

You're not allowed to access past the end of the list. You can check how long the list is using the <xref:System.Collections.Generic.List%601.Count%2A> property. Add the following code:

:::code language="csharp" source="./snippets/ListCollection/Program.cs" id="Property":::

Select **Run** again to see the results. In C#, indices start at 0, so the largest valid index is one less than the number of items in the list.

## Search and sort lists

Our samples use relatively small lists, but your applications might often create lists with many more elements, sometimes numbering in the thousands. To find elements in these larger collections, you need to search the list for different items. The <xref:System.Collections.Generic.List%601.IndexOf%2A> method searches for an item and returns the index of the item. If the item isn't in the list, `IndexOf` returns `-1`. Try it to see how it works. Add the following code after what you wrote so far:

:::code language="csharp" source="./snippets/ListCollection/Program.cs" id="Search":::

You might not know if an item is in the list, so you should always check the index returned by <xref:System.Collections.Generic.List%601.IndexOf%2A>. If it's `-1`, the item wasn't found.

The items in your list can be sorted as well. The <xref:System.Collections.Generic.List%601.Sort%2A> method sorts all the items in the list in their normal order (alphabetically for strings). Add this code and run again:

:::code language="csharp" source="./snippets/ListCollection/Program.cs" id="Sort":::

## Lists of other types

You've been using the `string` type in lists so far. Let's make a <xref:System.Collections.Generic.List%601> using a different type. Let's build a set of numbers. Delete the code you wrote so far, and replace it with the following code:

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/ListCollection/Program.cs" id="CreateList":::

That creates a list of integers, and sets the first two integers to the value 1. The *Fibonacci Sequence*, a sequence of numbers, starts with two 1's. Each next Fibonacci number is found by taking the sum of the previous two numbers. Add this code:

:::code language="csharp" source="./snippets/ListCollection/Program.cs" id="Fibonacci":::

Press **Run** to see the results;

## Challenge

See if you can put together some of the concepts from this and earlier lessons. Expand on what you built so far with Fibonacci Numbers. Try to write the code to generate the first 20 numbers in the sequence. (As a hint, the 20th Fibonacci number is 6765.)

Did you come up with something like this?

<!-- markdownlint-disable MD033 -->
<details>
:::code language="csharp" interactive="try-dotnet-method" source="./snippets/ListCollection/Program.cs" id="Answer":::

With each iteration of the loop, you're taking the last two integers in the list, summing them, and adding that value to the list. The loop repeats until you added 20 items to the list.
</details>
<!-- markdownlint-disable MD033 -->

You completed the list interactive tutorial, the final introduction to C# interactive tutorial. You can visit the [.NET site](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro) to download the .NET SDK, create a project on your machine, and keep coding. The "Next steps" section brings you back to these tutorials. Or, you can continue with the [Explore object oriented programming with classes and objects](../../fundamentals/tutorials/classes.md) tutorial.

You can learn more about [.NET collections](../../../standard/collections/index.md) in the following articles:

- [Selecting a collection type](../../../standard/collections/selecting-a-collection-class.md)
- [Commonly used collection types](../../../standard/collections/commonly-used-collection-types.md)
- [When to use generic collections](../../../standard/collections/when-to-use-generic-collections.md)
