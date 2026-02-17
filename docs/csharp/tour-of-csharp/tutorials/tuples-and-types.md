---
title: Tuples and types - Introductory tutorial
description: This tutorial teaches you to create types in C#. You write C# code and see the results of compiling and running your code as you learn the structure of types.
ms.date: 02/06/2026
---
# Tutorial: Create types in C\#

This tutorial teaches you how to create types in C#. You write small amounts of code, then you compile and run that code. The tutorial contains a series of lessons that explore different kinds of types in C#. These lessons teach you the fundamentals of the C# language.

> [!TIP]
> **New to programming?** Work through each section in order - tuples, records, and then structs and classes. **Coming from another language?** If you already know classes and structs, focus on [tuples](#tuples) and [record types](#create-record-types), which might be new to you.

The preceding tutorials worked with text and numbers. Strings and numbers are *simple types*: They each store one single value. As your programs grow larger, you need to work with more sophisticated data structures. C# provides different kinds of types you can define when you need data structures with more fields, properties, or behavior. Let's start to explore those types.

In this tutorial, you:

> [!div class="checklist"]
>
> * Create and manipulate tuple types.
> * Create record types.
> * Learn about struct, class, and interface types.

## Prerequisites

You must have one of the following options:

- A GitHub account to use [GitHub Codespaces](https://github.com/codespaces). If you don't already have one, you can create a free account at [GitHub.com](https://github.com).
- A computer with the following tools installed:
  - The [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0).
  - [Visual Studio Code](https://code.visualstudio.com/download).
  - The [C# DevKit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit).

To use codespaces, you need a GitHub account. If you don't already have one, you can create a free account at [GitHub.com](https://github.com).

## Tuples

To start a GitHub Codespace with the tutorial environment, open a browser window to the [tutorial codespace](https://github.com/dotnet/tutorial-codespace) repository. Select the green *Code* button, and the *Codespaces* tab. Then select the `+` sign to create a new Codespace using this environment. If you completed other tutorials in this series, you can open that codespace instead of creating a new one.

1. When your codespace loads, create a new file in the *tutorials* folder named *tuples.cs*.
1. Open your new file.
1. Type or copy the following code into *tuples.cs*:

   :::code language="csharp" source="./snippets/TuplesAndTypes/tuples-types.cs" id="CreateTuple":::

1. Run your program by typing the following commands in the integrated terminal window:

   ```dotnetcli
   cd tutorials
   dotnet tuples.cs
   ```

   *Tuples* are an ordered sequence of values with a fixed length. Each element of a tuple has a type and an optional name.

   > [!TIP]
   > As you explore C# (or any programming language), you make mistakes when you write code. The **compiler** finds those errors and reports them to you. When the output contains error messages, look closely at the example code and your code to see what to fix. You can also ask Copilot to find differences or spot any mistakes. That exercise helps you learn the structure of C# code.

1. Add the following code after the previous code to modify a tuple member:

   :::code language="csharp" source="./snippets/TuplesAndTypes/tuples-types.cs" id="Modify":::

1. You can also create a new tuple that's a modified copy of the original using a `with` expression. Add the following code after the existing code and type `dotnet tuples.cs` in the terminal window to see the results:

   :::code language="csharp" source="./snippets/TuplesAndTypes/tuples-types.cs" id="Wither":::

   The tuple `pt2` contains the `X` value of `pt` (6), and `pt2.Y` is 10. Tuples are structural types. In other words, tuple types don't have names like `string` or `int`. A tuple type is defined by the number of members, referred to as *arity*, and the types of those members. The member names are for convenience. You can assign a tuple to a tuple with the same arity and types even if the members have different names.

1. You can add the following code after the code you already wrote:

   :::code language="csharp" source="./snippets/TuplesAndTypes/tuples-types.cs" id="NamedAssignment":::

1. Try it by typing `dotnet tuples.cs` in the terminal window. The variable `subscript` has two members, both of which are integers. Both `subscript` and `pt` represent instances of the same tuple type: a tuple containing two `int` members.

   Tuples are easy to create: You declare multiple members enclosed in parentheses. All the following declarations define different tuples with different arities and member types.

1. Add the following code to create new tuple types:

   :::code language="csharp" source="./snippets/TuplesAndTypes/tuples-types.cs" id="TupleTypes":::

1. Try this change by typing `dotnet tuples.cs` again in the terminal window.

While tuples are easy to create, they're limited in their capabilities. Tuple types don't have names, so you can't convey meaning to the set of values. Tuple types can't add behavior. C# has other kinds of types you can create when your type defines behavior.

> [!TIP]
> **Learn more:** Explore [tuples and other type choices](../../fundamentals/types/index.md) in C# Fundamentals.

## Create record types

Tuples work well when you want multiple values in the same structure. They're lightweight, and you can declare them as you use them. As your program grows, you might find that you use the same tuple type throughout your code. If your app works in the 2D graph space, the tuples that represent points might be common. When you find this pattern, declare a `record` type that stores those values and provides more capabilities.

1. Add the following code to declare and use a `record` type to represent a `Point`:

   :::code language="csharp" source="./snippets/TuplesAndTypes/tuples-types.cs" id="PointRecord":::

   Place the preceding code at the bottom of your source file. Type declarations like `record` declarations must follow executable statements in a file-based app.

1. Add the following code preceding the `record` declaration:

   :::code language="csharp" source="./snippets/TuplesAndTypes/tuples-types.cs" id="UsePointRecord":::

   The `record` declaration is a single line of code for the `Point` type that stores the values `X` and `Y` in readonly properties. You use the name `Point` wherever you use that type. Properly named types, like `Point`, provide information about how the type is used. The additional code shows how to use a `with` expression to create a new point that's a modified copy of the existing point. The line `pt4 = pt3 with { Y = 10 }` says "`pt4` has the same values as `pt3` except that `Y` is assigned to 10." You can add any number of properties to change in a single `with` expression.

   The preceding `record` declaration is a single line of code that ends in `;`. You can add behavior to a `record` type by declaring *members*. A record member can be a function or more data elements. The members of a type are in the type declaration, between `{` and  `}` characters.

1. Delete the `;` and add the following lines of code after the `record` declaration:

   :::code language="csharp" source="./snippets/TuplesAndTypes/tuples-types.cs" id="AddSlopeMethod":::

1. Add the following code before the `record` declaration, after the line containing the `with` expression:

   :::code language="csharp" source="./snippets/TuplesAndTypes/tuples-types.cs" id="UseSlope":::

1. Type `dotnet tuples.cs` in the terminal window to run this version.

   You added formality to the *tuple* representing an `X` and `Y` value. You made it a `record` that defined a named type and included a member to calculate the slope. A `record` type is a shorthand for a `record class`: A `class` type that includes extra behavior.

1. You can modify the `Point` type to make it a `record struct` as well:

   :::code language="csharp" source="./snippets/TuplesAndTypes/tuples-types.cs" id="RecordStructPoint":::

   A `record struct` is a `struct` type that includes the extra behavior added to all `record` types.

1. Try this version by typing `dotnet tuples.cs` in the terminal window.

## Struct, class, and interface types

All concrete named types in C# are either `class` or `struct` types, including `record` types. A `class` is a *reference type*. A `struct` is a *value type*. Variables of a value type store the contents of the instance inline in memory. In other words, a `record struct Point` stores two integers: `X` and `Y`. Variables of a reference type store a reference, or pointer, to the storage for the instance. In other words, a `record class Point` stores a reference to a block of memory that holds the values for `X` and `Y`.

In practice, that difference means value types are copied when assigned, but a copy of a class instance is a copy of the *reference*. That copied reference refers to the same instance of a point, with the same storage for `X` and `Y`.

The `record` modifier instructs the compiler to write several members for you. You can learn more in the article on [record types](../../fundamentals/types/records.md) in the fundamentals section.

When you declare a `record` type, you declare that your type should use a default set of behaviors for equality comparisons, assignment, and copying instances of that type. Records are the best choice when storing related data is the primary responsibility of your type. As you add more behaviors, consider using `struct` or `class` types, without the `record` modifier.

Use `struct` types for value types when you need more sophisticated behavior, but the primary responsibility is storing values. Use `class` types to use object-oriented idioms like encapsulation, inheritance, and polymorphism.

You can also define `interface` types to declare behavioral contracts that different types must implement. Both `struct` and `class` types can implement interfaces.

You typically use all these types in larger programs and libraries. Once you install the SDK, you can explore those types using tutorials on [classes](../../fundamentals/tutorials/classes.md) in the fundamentals section.

You completed the "Create types in C#" tutorial.

## Cleanup resources

GitHub automatically deletes your Codespace after 30 days of inactivity. If you plan to explore more tutorials in this series, you can leave your Codespace provisioned. If you're ready to visit the [.NET site](https://dotnet.microsoft.com/download/dotnet) to download the .NET SDK, you can delete your Codespace. To delete your Codespace, open a browser window and navigate to [your Codespaces](https://github.com/codespaces). You should see a list of your codespaces in the window. Select the three dots (`...`) in the entry for the learn tutorial codespace and select **delete**.

## Next steps

Continue to the next tutorial in this series:

> [!div class="nextstepaction"]
> [Branches and loops](branches-and-loops.md)

Or explore related topics in C# Fundamentals:

- [The C# type system](../../fundamentals/types/index.md) — Dive deeper into the types you used in this tutorial.
- [Record types](../../fundamentals/types/records.md) — Learn more about records and when to use them.
- [Classes](../../fundamentals/types/classes.md) — Explore object-oriented programming in C#.
- [What you can build with C#](../what-you-can-build.md) — See the kinds of apps you can create with what you're learning.
