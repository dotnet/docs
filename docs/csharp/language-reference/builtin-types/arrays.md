---
title: "Arrays"
description: Store multiple variables of the same type in an array data structure in C#. Declare an array by specifying a type or specify Object to store any type.
ms.date: 08/24/2023
helpviewer_keywords:
  - "arrays [C#]"
  - "C# language, arrays"
  - "single-dimensional arrays [C#]"
  - "arrays [C#], single-dimensional"
  - "arrays [C#], multidimensional"
  - "multidimensional arrays [C#]"
  - "jagged arrays [C#]"
  - "arrays [C#], jagged"
  - "arrays [C#], foreach"
  - "foreach statement [C#], using with arrays"
  - "arrays [C#], passing as arguments"
  - "arrays [C#], implicitly-typed"
  - "implicitly-typed arrays [C#]"
  - "C# language, implicitly typed arrays"
---
# Arrays

You can store multiple variables of the same type in an array data structure. You declare an array by specifying the type of its elements. If you want the array to store elements of any type, you can specify `object` as its type. In the unified type system of C#, all types, predefined and user-defined, reference types and value types, inherit directly or indirectly from <xref:System.Object>.

```csharp
type[] arrayName;
```

An array has the following properties:

- An array can be [single-dimensional](#single-dimensional-arrays), [multidimensional](#multidimensional-arrays), or [jagged](#jagged-arrays).
- The number of dimensions are set when an array variable is declared. The length of each dimension is established when the array instance is created. These values can't be changed during the lifetime of the instance.
- A jagged array is an array of arrays, and each member array has the default value of `null`.
- Arrays are zero indexed: an array with `n` elements is indexed from `0` to `n-1`.
- Array elements can be of any type, including an array type.
- Array types are [reference types](../keywords/reference-types.md) derived from the abstract base type <xref:System.Array>. All arrays implement <xref:System.Collections.IList> and <xref:System.Collections.IEnumerable>. You can use the [foreach](../statements/iteration-statements.md#the-foreach-statement) statement to iterate through an array. Single-dimensional arrays also implement <xref:System.Collections.Generic.IList%601> and <xref:System.Collections.Generic.IEnumerable%601>.

The elements of an array can be initialized to known values when the array is created. Beginning with C# 12, all of the collection types can be initialized using a [Collection expression](../operators/collection-expressions.md). Elements that aren't initialized are set to the [default value](default-values.md). The default value is the 0-bit pattern. All reference types (including [non-nullable](../../nullable-references.md#known-pitfalls) types), have the values `null`. All value types have the 0-bit patterns. That means the <xref:System.Nullable%601.HasValue?displayProperty=nameWithType> property is `false` and the <xref:System.Nullable%601.Value?displayProperty=nameWithType> property is undefined. In the .NET implementation, the `Value` property throws an exception.

The following example creates single-dimensional, multidimensional, and jagged arrays:

:::code language="csharp" source="./snippets/shared/Arrays.cs" id="DeclareArrays":::

## Single-dimensional arrays

A *single-dimensional array* is a sequence of like elements. You access an element via its *index*. The *index* is its ordinal position in the sequence. The first element in the array is at index `0`. You create a single-dimensional array using the [new](../operators/new-operator.md) operator specifying the array element type and the number of elements. The following example declares and initializes single-dimensional arrays:

:::code language="csharp" source="snippets/shared/Arrays.cs" id="SingleDimensionalArrayDeclaration":::

The first declaration declares an uninitialized array of five integers, from `array[0]` to `array[4]`. The elements of the array are initialized to the [default value](default-values.md) of the element type, `0` for integers. The second declaration declares an array of strings and initializes all seven values of that array. A [foreach statement](../statements/iteration-statements.md#the-foreach-statement) iterates the elements of the `weekday` array and prints all the values. For single-dimensional arrays, the `foreach` statement processes elements in increasing index order, starting with index 0 and ending with index `Length - 1`.

### Pass single-dimensional arrays as arguments

You can pass an initialized single-dimensional array to a method. In the following example, an array of strings is initialized and passed as an argument to a `DisplayArray` method for strings. The method displays the elements of the array. Next, the `ChangeArray` method reverses the array elements, and then the `ChangeArrayElements` method modifies the first three elements of the array. After each method returns, the `DisplayArray` method shows that passing an array by value doesn't prevent changes to the array elements.

:::code language="csharp" source="./snippets/shared/ArrayExample.cs":::

## Multidimensional arrays

Arrays can have more than one dimension. For example, the following declarations create four arrays: two have two dimensions, two have three dimensions. The first two declarations declare the length of each dimension, but don't initialize the values of the array. The second two declarations use an initializer to set the values of each element in the multidimensional array.

:::code language="csharp" source="./snippets/shared/Arrays.cs" id="MultiDimensionalArrayDeclaration":::

For multi-dimensional arrays, elements are traversed such that the indices of the rightmost dimension are incremented first, then the next left dimension, and so on, to the leftmost index. The following example enumerates both a 2D and a 3D array:

:::code language="csharp" source="./snippets/shared/Arrays.cs" id="ForeachMultiDimension":::

In a 2D array, you can think of the left index as the *row* and the right index as the *column*.

However, with multidimensional arrays, using a nested [for](../statements/iteration-statements.md#the-for-statement) loop gives you more control over the order in which to process the array elements:

:::code language="csharp" source="./snippets/shared/Arrays.cs" id="ForMultiDimension":::

### Pass multidimensional arrays as arguments

You pass an initialized multidimensional array to a method in the same way that you pass a one-dimensional array. The following code shows a partial declaration of a print method that accepts a two-dimensional array as its argument. You can initialize and pass a new array in one step, as is shown in the following example. In the following example, a two-dimensional array of integers is initialized and passed to the `Print2DArray` method. The method displays the elements of the array.

:::code language="csharp" source="./snippets/shared/Arrays.cs" id="MultiDimensionParameter":::

## Jagged arrays

A jagged array is an array whose elements are arrays, possibly of different sizes. A jagged array is sometimes called an "array of arrays." Its elements are reference types and are initialized to `null`. The following examples show how to declare, initialize, and access jagged arrays. The first example, `jaggedArray`, is declared in one statement. Each contained array is created in subsequent statements. The second example, `jaggedArray2` is declared and initialized in one statement. It's possible to mix jagged and multidimensional arrays. The final example, `jaggedArray3`, is a declaration and initialization of a single-dimensional jagged array that contains three two-dimensional array elements of different sizes.

:::code language="csharp" source="./snippets/shared/Arrays.cs" id="JaggedArrayDeclaration":::

A jagged array's elements must be initialized before you can use them. Each of the elements is itself an array. It's also possible to use initializers to fill the array elements with values. When you use initializers, you don't need the array size.

This example builds an array whose elements are themselves arrays. Each one of the array elements has a different size.

:::code language="csharp" source="./snippets/shared/Arrays.cs" id="TrulyJagged":::

## Implicitly typed arrays

You can create an implicitly typed array in which the type of the array instance is inferred from the elements specified in the array initializer. The rules for any implicitly typed variable also apply to implicitly typed arrays. For more information, see [Implicitly Typed Local Variables](../../programming-guide/classes-and-structs/implicitly-typed-local-variables.md).

The following examples show how to create an implicitly typed array:

:::code language="csharp" source="./snippets/shared/Arrays.cs" id="LINQAndArrays":::

In the previous example, notice that with implicitly typed arrays, no square brackets are used on the left side of the initialization statement. Also, jagged arrays are initialized by using `new []` just like single-dimensional arrays.

When you create an anonymous type that contains an array, the array must be implicitly typed in the type's object initializer. In the following example, `contacts` is an implicitly typed array of anonymous types, each of which contains an array named `PhoneNumbers`. The `var` keyword isn't used inside the object initializers.

:::code language="csharp" source="./snippets/shared/Arrays.cs" id="LINQInit":::
