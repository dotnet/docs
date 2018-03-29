---
title: Collections tutorial - C# local quickstarts
description: Learn C# by exploring the List collection in this tutorial.
author: billwagner
ms.author: wiwagn
ms.date: 10/13/2017
ms.topic: get-started-article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.custom: mvc
---
# C# Quickstart: Collections

This quickstart provides an introduction to the C# language and the basics of the <xref:System.Collections.Generic.List%601>
class.

This quickstart expects you to have a machine you can use for development. The .NET topic [Get Started in 10 minutes](https://www.microsoft.com/net/core) has instructions for setting up your local development environment on Mac, PC or Linux. A quick overview of the commands you'll use is in the [introduction to the local quickstarts](local-environment.md) with links to more details.

## A basic list example

Create a directory named **list-quickstart**. Make that the current directory and run `dotnet new console`.

> [!NOTE]
> If you just completed [Get started with .NET in 10 minutes](https://www.microsoft.com/net), you can keep using the myApp application that you just created.

Open **Program.cs** in your favorite editor, and replace the existing code with the following:

```csharp
using System;
using System.Collections.Generic;

namespace list_quickstart
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string> { "<name>", "Ana", "Felipe" };
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
        }
    }
}
```

Replace `<name>` with your name. Save **Program.cs**. Type `dotnet run` in your console window to try it.

You've just created a list of strings, added three names to that list, and printed out the names in all CAPS. You're using concepts that you've learned in earlier quickstarts to loop through the list.

The code to display names makes use of the [string interpolation](../language-reference/tokens/interpolated.md) feature.  When you precede a `string` with the `$` character, you can embed C# code in the string declaration. The actual string replaces that C# code with the value it generates. In this example, it replaces the `{name.ToUpper()}` with each name, converted to capital letters, because you called the <xref:System.String.ToUpper%2A> method.

Let's keep exploring.

## Modify list contents

The collection you created uses the <xref:System.Collections.Generic.List%601> type. This type stores sequences of elements. You specify the type of the elements between the angle brackets.

One important aspect of this <xref:System.Collections.Generic.List%601> type is that it can grow or shrink, enabling you to add or remove elements. Add this code before the closing `}` in the `Main` method:

```csharp
Console.WriteLine();
names.Add("Maria");
names.Add("Bill");
names.Remove("Ana");
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}
```

You've added two more names to the end of the list. You've also removed one as well. Save the file, and type `dotnet run` to try it.

The <xref:System.Collections.Generic.List%601> enables you to reference individual items by **index** as well. You place the index between `[` and `]` tokens following the list name. C# uses 0 for the first index. Add this code directly below the code you just added and try it:

```csharp
Console.WriteLine($"My name is {names[0]}");
Console.WriteLine($"I've added {names[2]} and {names[3]} to the list");
```

You cannot access an index beyond the end of the list. Remember that indices start at 0, so the largest valid index is one less than the number of items in the list. You can check how long the list is using the <xref:System.Collections.Generic.List%601.Count%2A> property. Add the following code at the end of the Main method:

```csharp
Console.WriteLine($"The list has {names.Count} people in it");
 ```

Save the file, and type `dotnet run` again to see the results.

## Search and sort lists

Our samples use relatively small lists, but your applications may often create lists with many more elements, sometimes numbering in the thousands. To find elements in these larger collections, you need to search the list for different items. The <xref:System.Collections.Generic.List%601.IndexOf%2A> method searches for an item and returns the index of the item. Add this code to the bottom of your `Main` method:

```csharp
var index = names.IndexOf("Felipe");
if (index == -1)
{
    Console.WriteLine($"When an item is not found, IndexOf returns {index}");
} else
{
    Console.WriteLine($"The name {names[index]} is at index {index}");
}

index = names.IndexOf("Not Found");
if (index == -1)
{
    Console.WriteLine($"When an item is not found, IndexOf returns {index}");
} else
{
    Console.WriteLine($"The name {names[index]} is at index {index}");

}
```

The items in your list can be sorted as well. The <xref:System.Collections.Generic.List%601.Sort%2A> method sorts all the items in the list in their normal order (alphabetically in the case of strings). Add this code to the bottom of our `Main` method:

```csharp
names.Sort();
foreach (var name in names)
{
    Console.WriteLine($"Hello {name.ToUpper()}!");
}
```

Save the file and type `dotnet run` to try this latest version.

Before you start the next section, let's move the current code into a separate method. That makes it easier to start working with a new example. Rename your `Main` method to `WorkingWithStrings` and write a new `Main` method that calls `WorkingWithStrings`. When you have finished, your code should look like this:

```csharp
using System;
using System.Collections.Generic;

namespace list_quickstart
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkingWithStrings();
        }

        public static void WorkingWithStrings()
        {
            var names = new List<string> { "<name>", "Ana", "Felipe" };
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }

            Console.WriteLine();
            names.Add("Maria");
            names.Add("Bill");
            names.Remove("Ana");
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }

            Console.WriteLine($"My name is {names[0]}");
            Console.WriteLine($"I've added {names[2]} and {names[3]} to the list");

            Console.WriteLine($"The list has {names.Count} people in it");

            var index = names.IndexOf("Felipe");
            Console.WriteLine($"The name {names[index]} is at index {index}");

            var notFound = names.IndexOf("Not Found");
            Console.WriteLine($"When an item is not found, IndexOf returns {notFound}");

            names.Sort();
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }
        }
    }
}
```

## Lists of other types

You've been using the `string` type in lists so far. Let's make a <xref:System.Collections.Generic.List%601> using a different type. Let's build a set of numbers.

Add the following to the bottom of your new `Main` method:

```csharp
var fibonacciNumbers = new List<int> {1, 1};
```

That creates a list of integers, and sets the first two integers to the value 1. These are the first two values of a *Fibonacci Sequence*, a sequence of numbers. Each next Fibonacci number is found by taking the sum of the previous two numbers. Add this code:

```csharp
var previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
var previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

fibonacciNumbers.Add(previous + previous2);

foreach(var item in fibonacciNumbers)
    Console.WriteLine(item);
```

Save the file and type `dotnet run` to see the results.

> [!TIP]
> To concentrate on just this section, you can comment out the code that calls `WorkingWithStrings();`. Just put two `/` characters in front of the call like this:  `// WorkingWithStrings();`.

## Challenge

See if you can put together some of the concepts from this and earlier lessons. Expand on what you've built so far with Fibonacci Numbers. Try to write the code to generate the first 20 numbers in the sequence. (As a hint, the 20th Fibonacci number is 6765.)

## Complete challenge

You can see an example solution by [looking at the finished sample code on GitHub](https://github.com/dotnet/samples/tree/master/csharp/list-quickstart/Program.cs#L13-L23)

With each iteration of the loop, you're taking the last two integers in the list, summing them, and adding that value to the list. The loop repeats until you've added 20 items to the list.

Congratulations, you've completed the list quickstart. You can continue with
the [Introduction to classes](introduction-to-classes.md) quickstart in
your own development environment.

You can learn more about working with the `List` type in the
[.NET Guide](../../standard/index.md) topic on [collections](../../standard/collections/index.md). You'll also learn about many other collection types.