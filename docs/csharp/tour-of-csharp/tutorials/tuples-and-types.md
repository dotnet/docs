---
title: Tuples and types - Introductory interactive tutorial
description: In this tutorial about creating types, you use your browser to learn C# interactively. You're going to write C# code and see the results of compiling and running your code directly in the browser.
ms.date: 04/03/2025
---
# Create types in C\#

This tutorial teaches you about creating types in C#. You write small amounts of code, then you compile and run that code. The tutorial contains a series of lessons that explore different kinds of types in C#. These lessons teach you the fundamentals of the C# language.

> [!TIP]
> When a code snippet block includes the "Run" button, that button opens the interactive window, or replaces the existing code in the interactive window. When the snippet doesn't include a "Run" button, you can copy the code and add it to the current interactive window.

The preceding tutorials worked with text and numbers. Strings and Numbers are *simple types*: They each store one single value. As your programs grow larger, you need to work with more sophisticated data structures. C# provides different kinds of types you can define when you need data structures with more fields, properties, or behavior. Let's start to explore those types.

## Tuples

*Tuples* are an ordered sequence of values with a fixed length. Each element of a tuple has a type and an optional name. The following code declares a tuple that represents a 2D point. Select the "Run" button to paste the following code into the interactive window and run it.

:::code language="csharp" interactive="try-dotnet-method" source="./snippets/TuplesAndTypes/Program.cs" id="CreateTuple":::

> [!TIP]
> As you explore C# (or any programming language), you make mistakes when you write code. The **compiler** finds those errors and reports them to you. When the output contains error messages, look closely at the example code and the code in the interactive window to see what to fix. That exercise helps you learn the structure of C# code.

You can reassign any member of a tuple. Add the following code in the interactive window after the existing code. Press "Run" again to see the results.

:::code language="csharp" source="./snippets/TuplesAndTypes/Program.cs" id="Modify":::

You can also create a new tuple that's a modified copy of the original using a `with` expression. Add the following code after the code already in the interactive window and press "Run" to see the results:

:::code language="csharp" source="./snippets/TuplesAndTypes/Program.cs" id="Wither":::

The tuple `pt2` contains the `X` value of `pt` (6), and `pt2.Y` is 10.

Tuples are structural types. In other words, tuple types don't have names like `string` or `int`. A tuple type is defined by the number of members, referred to as *arity*, and the types of those members. The member names are for convenience. You can assign a tuple to a tuple with the same arity and types even if the members have different names. You can add the following code after the code you already wrote in the interactive window and try it:

:::code language="csharp" source="./snippets/TuplesAndTypes/Program.cs" id="NamedAssignment":::

The variable `subscript` has two members, both of which are integers. Both `subscript` and `pt` represent instances of the same tuple type: a tuple containing 2 `int` members.

Tuples are easy to create: You declare multiple members enclosed in parentheses. All the following declare different tuples of different arities and member types. Add the following code to create new tuple types:

:::code language="csharp" source="./snippets/TuplesAndTypes/Program.cs" id="TupleTypes":::

Tuples are easy to create, but they're limited in their capabilities. Tuple types don't have names, so you can't convey meaning to the set of values. Tuple types can't add behavior. C# has other kinds of types you can create when your type defines behavior.

## Create record types

Tuples are great for those times when you want multiple values in the same structure. They're lightweight, and can be declared as they're used. As your program goes, you might find that you use the same tuple type throughout your code. If your app does work in the 2D graph space, the tuples that represent points might be common. Once you find that, you can declare a `record` type that stores those values and provides more capabilities. The following code sample uses a `Main` method to represent the entry point for the program. That way, you can declare a `record` type preceding the entry point in the code. Press the "Run" button on the following code to replace your existing sample with the following code.

> [!WARNING]
> Don't copy and paste. The interactive window must be reset to run the following sample. If you make a mistake, the window hangs, and you need to refresh the page to continue.

The following code declares and uses a `record` type to represent a `Point`, and then uses that `Point` structure in the `Main` method:

:::code language="csharp" interactive="try-dotnet-class" source="./snippets/TuplesAndTypes/PointEvolution.cs" id="PointVersion2":::

The `record` declaration is a single line of code for the `Point` type that stores the values `X` and `Y` in readonly properties. You use the name `Point` wherever you use that type. Properly named types, like `Point`, provide information about how the type is used. The `Main` method shows how to use a `with` expression to create a new point that's a modified copy of the existing point. The line `pt2 = pt with { Y = 10 }` says "`pt2` has the same values as `pt` except that `Y` is assigned to 10." You can add any number of properties to change in a single `with` expression.

The preceding `record` declaration is a single line of code that ends in `;`, like all C# statements. You can add behavior to a `record` type by declaring *members*. A record member can be a function, or more data elements. The members of a type are in the type declaration, between `{` and  `}` characters. Replace the record declaration you made with the following code:

:::code language="csharp" source="./snippets/TuplesAndTypes/PointStruct.cs" id="PointVersion3":::

Then, add the following code to the `Main` method after the line containing the `with` expression:

:::code language="csharp" source="./snippets/TuplesAndTypes/PointStruct.cs" id="UseSlope":::

You added formality to the *tuple* representing an `X` and `Y` value. You made it a `record` that defined a named type, and included a member to calculate the slope. A `record` type is a shorthand for a `record class`: A `class` type that includes extra behavior. You can modify the `Point` type to make it a `record struct` as well:

:::code language="csharp" source="./snippets/TuplesAndTypes/PointStruct.cs" id="RecordStruct":::

A `record struct` is a `struct` type that includes the extra behavior added to all `record` types.

## Struct, class, and interface types

All named types in C# are either `class` or `struct` types. A `class` is a *reference type*. A `struct` is a *value type*. Variables of a value type store the contents of the instance inline in memory. In other words, a `record struct Point` stores two integers: `X` and `Y`. Variables of a reference type store a reference, or pointer, to the storage for the instance. In other words, a `record class Point` stores a reference to a block of memory that holds the values for `X` and `Y`.

In practice, that means value types are copied when assigned, but a copy of a class instance is a copy of the *reference*. That copied reference refers to the same instance of a point, with the same storage for `X` and `Y`.

The `record` modifier instructs the compiler to write several members for you. You can learn more in the article on [record types](../../fundamentals/types/records.md) in the fundamentals section.

When you declare a `record` type, you declare that your type should use a default set of behaviors for equality comparisons, assignment, and copying instances of that type. Records are the best choice when storing related data is the primary responsibility of your type. As you add more behaviors, consider using `struct` or `class` types, without the `record` modifier.

You use `struct` types for value types when more sophisticated behavior is needed, but the primary responsibility is storing values. You use `class` types to use object oriented idioms like encapsulation, inheritance, and polymorphism.

You can also define `interface` types to declare behavioral contracts that different types must implement. Both `struct` and `class` types can implement interfaces.

You typically use all these types in larger programs and libraries. Once you install the .NET SDK, you can explore those types using tutorials on [classes](../../fundamentals/tutorials/classes.md) in the fundamentals section.

You completed the "Create types in C#" interactive tutorial. You can select the **Branches and Loops** link to start the next interactive tutorial, or you can visit the [.NET site](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro) to download the .NET SDK, create a project on your machine, and keep coding. The "Next steps" section brings you back to these tutorials.

You can learn more about types in C# in the following articles:

- [Types in C#](../../fundamentals/types/index.md)
- [Records](../../fundamentals/types/records.md)
- [Classes](../../fundamentals/types/classes.md)
