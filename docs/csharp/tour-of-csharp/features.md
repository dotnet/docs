---
title: A Tour of C# - Major language areas
description: New to C#? Learn the basics of the language. This article contains a survey of major language features.
ms.date: 08/23/2021
---
# Major language areas

## Arrays, collections, and LINQ

C# and .NET provide many different collection types. Arrays have syntax defined by the language. Generic collection types are listed in the <xref:System.Collections.Generic?displayProperty=fullName> namespace. Specialized collections include <xref:System.Span%601?displayProperty=nameWithType> for accessing continuous memory on the stack frame, and <xref:System.Memory%601?displayProperty=nameWithType> for accessing continuous memory on the managed heap. All collections, including arrays, <xref:System.Span%601>, and <xref:System.Memory%601> share a unifying principle for iteration. You use the <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> interface. This unifying principle means that any of the collection types can be used with LINQ queries or other algorithms. You write methods using <xref:System.Collections.Generic.IEnumerable%601> and those algorithms work with any collection.

### Arrays

An [***array***](../programming-guide/arrays/index.md) is a data structure that contains a number of variables that are accessed through computed indices. The variables contained in an array, also called the ***elements*** of the array, are all of the same type. This type is called the ***element type*** of the array.

Array types are reference types, and the declaration of an array variable simply sets aside space for a reference to an array instance. Actual array instances are created dynamically at run time using the `new` operator. The `new` operation specifies the ***length*** of the new array instance, which is then fixed for the lifetime of the instance. The indices of the elements of an array range from `0` to `Length - 1`. The `new` operator automatically initializes the elements of an array to their default value, which, for example, is zero for all numeric types and `null` for all reference types.

The following example creates an array of `int` elements, initializes the array, and prints the contents of the array.

:::code language="csharp" source="./snippets/shared/Features.cs" ID="ArraysSample":::

This example creates and operates on a ***single-dimensional array***. C# also supports ***multi-dimensional arrays***. The number of dimensions of an array type, also known as the ***rank*** of the array type, is one plus the number of commas between the square brackets of the array type. The following example allocates a single-dimensional, a two-dimensional, and a three-dimensional array, respectively.

:::code language="csharp" source="./snippets/shared/Features.cs" ID="DeclareArrays":::

The `a1` array contains 10 elements, the `a2` array contains 50 (10 × 5) elements, and the `a3` array contains 100 (10 × 5 × 2) elements.
The element type of an array can be any type, including an array type. An array with elements of an array type is sometimes called a ***jagged array*** because the lengths of the element arrays don't all have to be the same. The following example allocates an array of arrays of `int`:

:::code language="csharp" source="./snippets/shared/Features.cs" ID="ArrayOfArrays":::

The first line creates an array with three elements, each of type `int[]` and each with an initial value of `null`. The next lines then initialize the three elements with references to individual array instances of varying lengths.

The `new` operator permits the initial values of the array elements to be specified using an ***array initializer***, which is a list of expressions written between the delimiters `{` and `}`. The following example allocates and initializes an `int[]` with three elements.

:::code language="csharp" source="./snippets/shared/Features.cs" ID="InitializeArray":::

The length of the array is inferred from the number of expressions between `{` and `}`. Array initialization can be shortened further such that the array type doesn't have to be restated.

:::code language="csharp" source="./snippets/shared/Features.cs" ID="InitializeShortened":::

Both of the previous examples are equivalent to the following code:

:::code language="csharp" source="./snippets/shared/Features.cs" ID="InitializeGenerated":::

The `foreach` statement can be used to enumerate the elements of any collection. The following code enumerates the array from the preceding example:

:::code language="csharp" source="./snippets/shared/Features.cs" ID="EnumerateArray":::

The `foreach` statement uses the <xref:System.Collections.Generic.IEnumerable%601> interface, so can work with any collection.

## String interpolation

C# [***string interpolation***](../language-reference/tokens/interpolated.md) enables you to format strings by defining expressions whose results are placed in a format string. For example, the following example prints the temperature on a given day from a set of weather data:

:::code language="csharp" source="./snippets/shared/Features.cs" ID="StringInterpolation":::

An interpolated string is declared using the `$` token. String interpolation evaluates the expressions between `{` and `}`, then converts the result to a `string`, and replaces the text between the brackets with the string result of the expression. The `:` in the first expression, `{weatherData.Date:MM-DD-YYYY}` specifies the *format string*. In the preceding example, it specifies that the date should be printed in "MM-DD-YYYY" format.

## Pattern matching

The C# language provides [***pattern matching***](../fundamentals/functional/pattern-matching.md) expressions to query the state of an object and execute code based on that state. You can inspect types and the values of properties and fields to determine which action to take. The `switch` expression is the primary expression for pattern matching.

## Delegates and lambda expressions

A [***delegate type***](../delegates-overview.md) represents references to methods with a particular parameter list and return type. Delegates make it possible to treat methods as entities that can be assigned to variables and passed as parameters. Delegates are similar to the concept of function pointers found in some other languages. Unlike function pointers, delegates are object-oriented and type-safe.

The following example declares and uses a delegate type named `Function`.

:::code language="csharp" source="./snippets/shared/Features.cs" ID="DelegateExample":::

An instance of the `Function` delegate type can reference any method that takes a `double` argument and returns a `double` value. The `Apply` method applies a given `Function` to the elements of a `double[]`, returning a `double[]` with the results. In the `Main` method, `Apply` is used to apply three different functions to a `double[]`.

A delegate can reference either a static method (such as `Square` or `Math.Sin` in the previous example) or an instance method (such as `m.Multiply` in the previous example). A delegate that references an instance method also references a particular object, and when the instance method is invoked through the delegate, that object becomes `this` in the invocation.

Delegates can also be created using anonymous functions or lambda expressions, which are "inline methods" that are created when declared. Anonymous functions can see the local variables of the surrounding methods. The following example doesn't create a class:

:::code language="csharp" source="./snippets/shared/Features.cs" ID="UseDelegate":::

A delegate doesn't know or care about the class of the method it references. The referenced method must have the same parameters and return type as the delegate.

## async / await

C# supports asynchronous programs with two keywords: `async` and `await`. You add the `async` modifier to a method declaration to declare the method is asynchronous. The `await` operator tells the compiler to asynchronously await for a result to finish. Control is returned to the caller, and the method returns a structure that manages the state of the asynchronous work. The structure is typically a <xref:System.Threading.Tasks.Task%601?displayProperty=nameWithType>, but can be any type that supports the awaiter pattern. These features enable you to write code that reads as its synchronous counterpart, but executes asynchronously. For example, the following code downloads the home page for [Microsoft docs](/):

:::code language="csharp" source="./snippets/shared/Features.cs" ID="AsyncExample":::

This small sample shows the major features for asynchronous programming:

- The method declaration includes the `async` modifier.
- The body of the method `await`s the return of the `GetByteArrayAsync` method.
- The type specified in the `return` statement matches the type argument in the `Task<T>` declaration for the method. (A method that returns a `Task` would use `return` statements without any argument).

## Attributes

Types, members, and other entities in a C# program support modifiers that control certain aspects of their behavior. For example, the accessibility of a method is controlled using the `public`, `protected`, `internal`, and `private` modifiers. C# generalizes this capability such that user-defined types of declarative information can be attached to program entities and retrieved at run-time. Programs specify this declarative information by defining and using [***attributes***](../programming-guide/concepts/attributes/index.md).

The following example declares a `HelpAttribute` attribute that can be placed on program entities to provide links to their associated documentation.

:::code language="csharp" source="./snippets/shared/Features.cs" ID="DefineAttribute":::

All attribute classes derive from the <xref:System.Attribute> base class provided by the .NET library. Attributes can be applied by giving their name, along with any arguments, inside square brackets just before the associated declaration. If an attribute’s name ends in `Attribute`, that part of the name can be omitted when the attribute is referenced. For example, the `HelpAttribute` can be used as follows.

:::code language="csharp" source="./snippets/shared/Features.cs" ID="UseAttributes":::

This example attaches a `HelpAttribute` to the `Widget` class. It adds another `HelpAttribute` to the `Display` method in the class. The public constructors of an attribute class control the information that must be provided when the attribute is attached to a program entity. Additional information can be provided by referencing public read-write properties of the attribute class (such as the reference to the `Topic` property previously).

The metadata defined by attributes can be read and manipulated at run time using reflection. When a particular attribute is requested using this technique, the constructor for the attribute class is invoked with the information provided in the program source. The resulting attribute instance is returned. If additional information was provided through properties, those properties are set to the given values before the attribute instance is returned.

The following code sample demonstrates how to get the `HelpAttribute` instances associated to the `Widget` class and its `Display` method.

:::code language="csharp" source="./snippets/shared/Features.cs" ID="ReadAttributes":::

## Learn more

You can explore more about C# by trying one of our [tutorials](../fundamentals/tutorials/classes.md).

>[!div class="step-by-step"]
>[Previous](program-building-blocks.md)
