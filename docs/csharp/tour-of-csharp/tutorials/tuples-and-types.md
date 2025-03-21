---
title: Tuples and types - Introductory interactive tutorial
description: In this tutorial about creating types, you use your browser to learn C# interactively. You're going to write C# code and see the results of compiling and running your code directly in the browser.
ms.date: 04/03/2025
---
# Create types in C\#

This tutorial teaches you about creating types in C#. You write small amounts of code, then you compile and run that code. The tutorial contains a series of lessons that explore different kinds of types in C#. These lessons teach you the fundamentals of the C# language.

> [!TIP]
>
> When a code snippet block includes the "Run" button, that button opens the interactive window, or replaces the existing code in the interactive window. When the snippet doesn't include a "Run" button, you can copy the code and add it to the current interactive window.

The preceding tutorials worked with text and numbers. Strings and Numbers are *simple types*: They each store one single value. As your programs grow larger, you need to work with more sophisticated data structures. C# provides different kinds of types you can define when you need data structures with more fields, properties, or behavior. Let's start to explore those types.

## Tuples

*Tuples* are an ordered sequence of values with a fixed length. Each element of a tuple has a type and an optional name. The following code declares a tuple that represents a 2D point:

```csharp
var pt = (X: 1, Y: 2);

var slope = (double)pt.Y / (double)pt.X;
Console.WriteLine($"A line from the origin to the point {pt} has a slope of {slope}");
```

> [!TIP]
>
> As you explore C# (or any programming language), you make mistakes when you write code. The **compiler** finds those errors and report them to you. When the output contains error messages, look closely at the example code, and the code in the interactive window to see what to fix. That exercise helps you learn the structure of C# code.

Tuples are structural types. In other words, different tuple types don't have names like `string` or `int`. A tuple type is defined by the number of members, referred to as *arity* and the types of those members. The member names are for convenience. You can assign a tuple to a tuple with the same shape even if the members have different names:

```csharp
var subscript(A, B) = pt;
```

The variable `subscript` has two members, but of which are integers. Both `subscript` and `pt` represent instances of the same tuple type: a tuple containing 2 `int` members. You can reassign any member of a tuple:

```csharp
pt.X = pt.X + 5;
```

You can also create a new tuple that's a modified copy of the original using a `with` expression:

```csharp
var pt2 = pt with { Y = 10 };
```

The tuple `pt2` contains the `X` value of `pt` (6), and `pt2.Y` is 10.

Tuples are easy to create: You declare multiple members enclosed in parentheses. All the following declare different tuples of different arites and member types:

```csharp
var namedData = (Name= "Morning observation", Temp = 17, Wind = 4);
var person = (FirstName = "", LastName = "");
var order = (Product = "guitar picks", style = "triangle", quantity = 500, UnitPrice = 0.10m);
```

Tuples are easy to create, but they are limited in their capabilities. Tuple types don't have names, so you can convey meaning to the set of values. Tuple types can't add behavior. For that, C# has other kinds of types you can create.

## Create record types

Tuples are great for those times when you want multiple values in the same structure. They're lightweight, and can be declared as they are used. As your program goes, you might find that you use the same tuple type throughout your code. If your app does work in the 2D graph space, the tuples that represent points might be common. Once you find that, you can declare a `record` type that stores those values and provides more capabilities:

```csharp
public record Point(int X, int Y);
```

The preceding single line of code declares a named *record* type that stores the values `X` and `Y` in readonly properties. You use the name `Point` wherever you use that type. Using a named type makes it clear how the type is used. Unlike tuples, you can't change the value of a property in a record, but you can still make a new copy using a `with` expression:

```csharp
Point pt = new Point {X = 1, Y = 1};
var pt2 = pt with { Y = 10 };
```

Record types can include behavior as well as data. In C#, any type declaration starts with `{` and ends with `}`. Replace the record declaration you made with the following:

```csharp
public record Point(int X, int Y)
{
    public double Slope() => (double) Y / (double) X;
}
```

You can call it like the following:

```csharp
double slope = pt.Slope();
Console.WriteLine($"The slope of {pt} is {slope}");
```

You've added a bit of formality to the *tuple* representing an `X` and `Y` value. You made it a `record` that defined a named type, and included a member to calculate the slope. A `record` type is a shorthand for a `record class`: A `class` type where some types are generated by the compiler. You can modify the `Point` type to make it a `record struct` as well:

```csharp
public record struct Point(int X, int Y)
{
    public double Slope() => (double) Y / (double) X;
}
```

All named types in C# are either `class` or `struct` types. A `class` is a *reference type*. A `struct` is a *value type*. Variables of a value type store the contents of the the instance inline in memory. In other words, a `record struct Point` stores two integers: `X` and `Y`. Variables of a reference type store a reference, or pointer, to the storage for the instance. In other words, a `record class Point` stores a reference to a block of memory that holds the values for `X` and `Y`.

In practice, that means value types are copied when assigned, but a copy of a class instance is a copy of the *reference*. That copied reference refers to the same instance of `X` and `Y`.

The `record` modifier instructs the compiler to write several members for you. You can learn much more in the article on [record types](../../fundamentals/types/records.md) in the fundamentals section.

## Struct, class, and interface types

When you declare a `record` type, you declare that your type should use a default set of behavior for equality comparisons, assignment and copying instances of that type. Records are the best choice when storing related data is the primary responsibility of your type. As you add more behavior, consider using `struct` or `class` types, without the `record` modifier.

You use `struct` types for value types when more sophisticated behavior is needed, but the primary responsibility is storing values. You use `class` types to use object oriented idioms like encapsulation, inheritance, and polymorphism.

You can also define `interface` types to declare behavioral contracts that different types must implement. Both `struct` and `class` types can implement interfaces.

You'll typically use all these types in larger programs and libraries. Once you install the .NET SDK, you can explore those types using tutorials on [classes](../../fundamentals/tutorials/classes.md) in the fundamentals section.

You completed the "Create types in C#" interactive tutorial. You can select the **Branches and Loops** link to start the next interactive tutorial, or you can visit the [.NET site](https://dotnet.microsoft.com/learn/dotnet/hello-world-tutorial/intro) to download the .NET SDK, create a project on your machine, and keep coding. The "Next steps" section brings you back to these tutorials.

You can learn more about types in C# in the following articles:

- [Types in C#](../../fundamentals/types/index.md)
- [Records](../../fundamentals/types/records.md)
- [Classes](../../fundamentals/types/classes.md)
