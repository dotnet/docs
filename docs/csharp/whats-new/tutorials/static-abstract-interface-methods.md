---
title: Explore static abstract members in interfaces - preview
description: This advanced tutorial demonstrates scenarios for operators and other static members in interfaces. You can explore the preview feature to learn and provide feedback before general release.
ms.date: 12/11/2021
ms.technology: csharp-advanced-concepts
---
# Tutorial: Explore C# 10 preview feature - static abstract members in interfaces

C# 10 and .NET 6 include a preview version of *static abstract members in interfaces*. This feature enables you to define interfaces that include [overloaded operators](../../language-reference/operators/operator-overloading.md), or other static members. Once you've defined interfaces with static members, you can use those interfaces as [constraints](../../programming-guide/generics/constraints-on-type-parameters.md) to create generic types that use operators or other static methods. Even if you don't create interfaces with overloaded operators, you'll likely benefit from this feature and the generic math classes enabled by the language update.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
>
> * Define interfaces with static members.
> * Use experimental interfaces to define classes that implement interfaces with operators defined.
> * Create generic algorithms that rely on static interface methods.

## Prerequisites

You’ll need to set up your machine to run .NET 6, which supports C# 10. The C# 10 compiler is available starting with [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) or the [.NET 6 SDK](https://dotnet.microsoft.com/download).

> [!IMPORTANT]
> *static abstract members in interfaces* is a preview feature. You must Add the `<EnablePreviewFeatures>True</EnablePreviewFeatures>` in your project file. See [Preview features](https://aka.ms/dotnet-warnings/preview-features) for more information. You can experiment with this feature, and the experimental libraries that use it. We will use feedback from the preview cycles to improve the feature, including possibly making changes, before its general release.

## Static abstract interface methods

Let's start with an example. The following method returns the midpoint of two `double` numbers:

```csharp
public static double MidPoint(double left, double right) =>
    (left + right) / (2.0);
```

The same logic would work for any numeric type: `int`, `short`, `long`, `float` `decimal`, or any type that represents a number. You need to have a way to use the `+` operator, `/` operator, and define a value for `2`. You can use the `System.INumber` interface in the `System.Runtime.Experimental` NuGet package to write the preceding method as the following generic method:

:::code language="csharp" source="./snippets/staticinterfaces/Utilities.cs" id="MidPoint":::

Any type that implements the `INumber` interface must include a definition for `operator +`, and `operator /`. The denominator is defined by `(T.One + T.One)` to create the value `2` for any numeric type. The readonly properties `Zero` and `One` are also implemented by every type that implements `INumber`. Using that property rather than `2` forces the denominator to be the same type as the two parameters. Note that this implementation has the potential for overflow if `left` and `right` are both large enough values. There are alternative algorithms that can avoid this potential issue.

You define static abstract members in an interface using familiar syntax: You add the `static` and `abstract` modifiers to any static member that doesn't provide an implementation. The following example defines an `IGetNext<T>` interface that can be applied to any type that overrides `operator ++`:

:::code language="csharp" source="./snippets/staticinterfaces/GetNext.cs":::

The constraint that the type argument, `T` implements `IGetNext<T>` ensures that the signature for the operator includes the containing type, or its type argument. Many operators enforce that its parameters must match the type, or be the type parameter constrained to implement the containing type. Without this constraint, the `++` operator couldn't be defined in the `IGetNext<T>` interface.

You can create a structure that creates a string of 'A' characters where each increment adds another character to the string using the following code:

:::code language="csharp" source="./snippets/staticinterfaces/RepeatSequence.cs":::

More generally, you can build any algorithm where you might want to define `++` to mean "produce the next value of this type". Using this interface produces clear code and results:

:::code language="csharp" source="./snippets/staticinterfaces/Program.cs" id="TestRepeat":::

The preceding example produces the following output:

```powershell
A
AA
AAA
AAAA
AAAAA
AAAAAA
AAAAAAA
AAAAAAAA
AAAAAAAAA
AAAAAAAAAA
```

This small example demonstrates the motivation for this feature. You can use natural syntax for operators, constant values, and other static operations. You can explore these techniques when you create multiple types that rely on static members, including overloaded operators. Define the interfaces that match your types' capabilities and then declare those types' support for the new interface.

## Generic math and experimental features

The motivating scenario for allowing static methods, including operators, in interfaces is to support *generic math* algorithms. The [System.Runtime.Experimental](https://www.nuget.org/packages/System.Runtime.Experimental/) NuGet package contains interface definitions for many arithmetic operators, and derived interfaces that combine many arithmetic operators in an `INumber<T>` interface. Let's apply those types to build a `Point<T>` record that can use any numeric type for `T`. The point can be moved by some `XOffset` and `YOffset` using the `+` operator.

Start by creating a new Console application, either by using `dotnet new` or Visual Studio. Next, add the `System.Runtime.Experimental` NuGet package to your project. You'll need to enable preview features to use the types in this package. Enabling preview features also sets the C# language version to "preview", which enables C# 10 preview features. Add the following element to your *csproj* file inside a `<PropertyGroup>` element:

```xml
<EnablePreviewFeatures>true</EnablePreviewFeatures>
```

> [!NOTE]
> This element cannot be set using the Visual Studio UI. You need to edit the project file directly.

The public interface for the `Translation<T>` and `Point<T>` should look like the following code:

```csharp
// Note: Not complete. This won't compile yet.
public record Translation<T>(T XOffset, T YOffset);

public record Point<T>(T X, T Y)
{
    public static Point<T> operator +(Point<T> left, Translation<T> right);
}
```

You use the `record` type for both the `Translation<T>` and `Point<T>` types: Both store two values, and they represent data storage rather than sophisticated behavior. The implementation of `operator +` would look like the following code:

```csharp
public static Point<T> operator +(Point<T> left, Translation<T> right) =>
    left with { X = left.X + right.XOffset, Y = left.Y + right.YOffset };
```

For the previous code to compile, you'll need to declare that `T` supports the `IAdditionOperators<TSelf, TOther, TResult>` interface. That interface includes the `operator +` static method. It declares three type parameters: One for the left operand, one for the right operand, and one for the result. Some types implement `+` for different operand and result types. Add a declaration that the type argument, `T` implements `IAdditionOperators<T, T, T>`:

```csharp
public record Point<T>(T X, T Y) where T : IAdditionOperators<T, T, T>
```

After adding that constraint, your `Point<T>` class can use the `+` for its addition operator. Add the same constraint on the `Translation<T>` declaration:

```csharp
public record Translation<T>(T XOffset, T YOffset) where T : IAdditionOperators<T, T, T>;
```

The `IAdditionOperators<T, T, T>` constraint prevents a developer using your class from creating a `Translation` using a type that doesn't meet the constraint for the addition to a point. You've added the necessary constraints to the type parameter for `Translation<T>` and `Point<T>` so this code works. You can test by adding code like the following above the declarations of `Translation` and `Point` in your *Program.cs* file:

:::code language="csharp" source="./snippets/staticinterfaces/Program.cs" id="TestAddition":::

You can make this code more reusable by declaring that these types implement the appropriate arithmetic interfaces. The first change to make is to declare that `Point<T, T>` implements the `IAdditionOperators<Point<T>, Translation<T>, Point<T>>` interface. The `Point` type makes use of different types for operands and the result. The `Point` type already implements an `operator +` with that signature, so adding the interface to the declaration is all you need:

```csharp
public record Point<T>(T X, T Y) : IAdditionOperators<Point<T>, Translation<T>, Point<T>>
    where T : IAdditionOperators<T, T, T>
```

Finally, when you're performing addition, it's useful to have a property that defines the additive identity value for that type. There's a new experimental interface for that feature: `IAdditiveIdentity<TSelf, TResult>`. A translation of `{0, 0}` is the additive identity: The resulting point is the same as the left operand. The `IAdditiveIdentity<TSelf, TResult>` interface defines one readonly property: `AdditiveIdentity`, that returns the identity value. The `Translation<T>` needs a few changes to implement this interface:

:::code language="csharp" source="./snippets/staticinterfaces/Translation.cs":::

There are a few changes here, so let's walk through them one by one. First, you declare that the `Translation` type implements the `IAdditiveIdentity` interface:

```csharp
public record Translation<T>(T XOffset, T YOffset) : IAdditiveIdentity<Translation<T>, Translation<T>> 
```

You next might try implementing the interface member as shown in the following code:

```csharp
public static Translation<T> AdditiveIdentity =>
    new Translation<T>(XOffset: 0, YOffset: 0);
```

The preceding code won't compile, because `0` depends on the type. The answer: Use `IAdditiveIdentity<T>.AdditiveIdentity` for `0`. That change means that your constraints must now include that `T` implements `IAdditiveIdentity<T>`. That results in the following implementation:

```csharp
public static Translation<T> AdditiveIdentity =>
    new Translation<T>(XOffset: T.AdditiveIdentity, YOffset: T.AdditiveIdentity);
```

Now that you've added that constraint on `Translation<T>`, you need to add the same constraint to `Point<T>`:

:::code language="csharp" source="./snippets/staticinterfaces/Point.cs":::

This sample has given you a look at how the interfaces for generic math compose. You learned how to:

> [!div class="checklist"]
>
> * Write a method that relied on the `INumber<T>` interface so that method could be used with any numeric type.
> * Build a type that relies on the addition interfaces to implement a type that only supports one mathematical operation.
>   That type declares its support for those same interfaces so it can be composed in other ways. The algorithms are written using the most natural syntax of mathematical operators.

Experiment with these features and register feedback while they're still in preview. You can use the *Send Feedback* menu item in Visual Studio, or create a new [issue](https://github.com/dotnet/roslyn/issues/new/choose) in the roslyn repository on GitHub.  Build generic algorithms that work with any numeric type. Build algorithms using these interfaces where the type argument may only implement a subset of number-like capabilities. Even if you don't build new interfaces that use these capabilities, but you can experiment with using them in your algorithms.
