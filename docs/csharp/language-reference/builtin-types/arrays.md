---
title: "Arrays"
description: Store multiple variables of the same type in an array data structure in C#. Declare an array by specifying a type or specify Object to store any type.
ms.date: 08/22/2023
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

The following example creates single-dimensional, multidimensional, and jagged arrays:

[!code-csharp[csProgGuideArrays#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#1)]

An array has the following properties:

- An array can be [single-dimensional](#single-dimensional-arrays), [multidimensional](#multidimensional-arrays) or [jagged](#jagged-arrays).
- The number of dimensions and the length of each dimension are established when the array instance is created. These values can't be changed during the lifetime of the instance.
- The default values of numeric array elements are set to zero, and reference elements are set to `null`.
- A jagged array is an array of arrays, and therefore its elements are reference types and are initialized to `null`.
- Arrays are zero indexed: an array with `n` elements is indexed from `0` to `n-1`.
- Array elements can be of any type, including an array type.
- Array types are [reference types](../keywords/reference-types.md) derived from the abstract base type <xref:System.Array>. All arrays implement <xref:System.Collections.IList>, and <xref:System.Collections.IEnumerable>. You can use the [foreach](../statements/iteration-statements.md#the-foreach-statement) statement to iterate through an array. Single-dimensional arrays also implement <xref:System.Collections.Generic.IList%601> and <xref:System.Collections.Generic.IEnumerable%601>.

### Default value behaviour

- For value types, the array elements are initialized with the [default value](default-values.md), the 0-bit pattern; the elements will have the value `0`.
- All the reference types (including the [non-nullable](../../nullable-references.md#known-pitfalls)), have the values `null`.
- For nullable value types, `HasValue` is set to `false` and the elements would be set to `null`.

### Arrays as Objects

In C#, arrays are actually objects, and not just addressable regions of contiguous memory as in C and C++. <xref:System.Array> is the abstract base type of all array types. You can use the properties and other class members that <xref:System.Array> has. An example of this is using the <xref:System.Array.Length%2A> property to get the length of an array. The following code assigns the length of the `numbers` array, which is `5`, to a variable called `lengthOfNumbers`:

[!code-csharp[csProgGuideArrays#3](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#3)]

The <xref:System.Array> class provides many other useful methods and properties for sorting, searching, and copying arrays. The following example uses the <xref:System.Array.Rank%2A> property to display the number of dimensions of an array.

[!code-csharp[csProgGuideArrays#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#2)]

## Single-Dimensional Arrays

You create a single-dimensional array using the [new](../operators/new-operator.md) operator specifying the array element type and the number of elements. The following example declares an array of five integers:

:::code language="csharp" source="snippets/shared/SingleDimensionArrays.cs" id="IntDeclaration":::

This array contains the elements from `array[0]` to `array[4]`. The elements of the array are initialized to the [default value](default-values.md) of the element type, `0` for integers.

Arrays can store any element type you specify, such as the following example that declares an array of strings:

:::code language="csharp" source="snippets/shared/SingleDimensionArrays.cs" id="StringDeclaration":::

### Array Initialization

You can initialize the elements of an array when you declare the array. The length specifier isn't needed because it's inferred by the number of elements in the initialization list. For example:

:::code language="csharp" source="snippets/shared/SingleDimensionArrays.cs" id="IntInitialization":::

The following code shows a declaration of a string array where each array element is initialized by a name of a day:

:::code language="csharp" source="snippets/shared/SingleDimensionArrays.cs" id="StringInitialization":::
  
You can avoid the `new` expression and the array type when you initialize an array upon declaration, as shown in the following code. This is called an [implicitly typed array](#implicitly-typed-arrays):

:::code language="csharp" source="snippets/shared/SingleDimensionArrays.cs" id="ShorthandInitialization":::

You can declare an array variable without creating it, but you must use the `new` operator when you assign a new array to this variable. For example:

:::code language="csharp" source="snippets/shared/SingleDimensionArrays.cs" id="DeclareAllocate":::

### Value Type and Reference Type Arrays

Consider the following array declaration:  

:::code language="csharp" source="snippets/shared.SingleDimensionArrays.cs" id="FinalInstantiation":::

The result of this statement depends on whether `SomeType` is a value type or a reference type. If it's a value type, the statement creates an array of 10 elements, each of which has the type `SomeType`. If `SomeType` is a reference type, the statement creates an array of 10 elements, each of which is initialized to a null reference. In both instances, the elements are initialized to the default value for the element type. For more information about value types and reference types, see [Value types](../builtin-types/value-types.md) and [Reference types](../keywords/reference-types.md).

### Retrieving data from Array

You can retrieve the data of an array by using an index. For example:

:::code language="csharp" source="snippets/shared/RetrievingArrayElements.cs" id="RetrievingDataArray" interactive="try-dotnet-method":::

## Multidimensional Arrays

Arrays can have more than one dimension. For example, the following declaration creates a two-dimensional array of four rows and two columns.

[!code-csharp[csProgGuideArrays#11](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#11)]

The following declaration creates an array of three dimensions, 4, 2, and 3.

[!code-csharp[csProgGuideArrays#12](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#12)]

### Array Initialization

You can initialize the array upon declaration, as is shown in the following example.

[!code-csharp[csProgGuideArrays#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#13)]

You can also initialize the array without specifying the rank.

[!code-csharp[csProgGuideArrays#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#14)]

If you choose to declare an array variable without initialization, you must use the `new` operator to assign an array to the variable. The use of `new` is shown in the following example.

[!code-csharp[csProgGuideArrays#15](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#15)]

The following example assigns a value to a particular array element.

[!code-csharp[csProgGuideArrays#16](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#16)]

Similarly, the following example gets the value of a particular array element and assigns it to variable `elementValue`.

[!code-csharp[csProgGuideArrays#42](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#42)]

The following code example initializes the array elements to default values (except for jagged arrays).

[!code-csharp[csProgGuideArrays#17](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#17)]

## Jagged Arrays

A jagged array is an array whose elements are arrays, possibly of different sizes. A jagged array is sometimes called an "array of arrays." The following examples show how to declare, initialize, and access jagged arrays.

The following is a declaration of a single-dimensional array that has three elements, each of which is a single-dimensional array of integers:

[!code-csharp[csProgGuideArrays#19](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#19)]

Before you can use `jaggedArray`, its elements must be initialized. You can initialize the elements like this:

[!code-csharp[csProgGuideArrays#20](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#20)]

Each of the elements is a single-dimensional array of integers. The first element is an array of 5 integers, the second is an array of 4 integers, and the third is an array of 2 integers.

It is also possible to use initializers to fill the array elements with values, in which case you do not need the array size. For example:

[!code-csharp[csProgGuideArrays#21](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#21)]

You can also initialize the array upon declaration like this:

[!code-csharp[csProgGuideArrays#22](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#22)]

You can use the following shorthand form. Notice that you cannot omit the `new` operator from the elements initialization because there is no default initialization for the elements:

[!code-csharp[csProgGuideArrays#23](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#23)]

A jagged array is an array of arrays, and therefore its elements are reference types and are initialized to `null`.

You can access individual array elements like these examples:

[!code-csharp[csProgGuideArrays#24](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#24)]

It's possible to mix jagged and multidimensional arrays. The following is a declaration and initialization of a single-dimensional jagged array that contains three two-dimensional array elements of different sizes. For more information, see [Multidimensional Arrays](#multidimensional-arrays).

[!code-csharp[csProgGuideArrays#25](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#25)]

You can access individual elements as shown in this example, which displays the value of the element `[1,0]` of the first array (value `5`):

[!code-csharp[csProgGuideArrays#26](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#26)]

The method `Length` returns the number of arrays contained in the jagged array. For example, assuming you have declared the previous array, this line:

[!code-csharp[csProgGuideArrays#27](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#27)]

returns a value of 3.

This example builds an array whose elements are themselves arrays. Each one of the array elements has a different size.

[!code-csharp[csProgGuideArrays#18](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#18)]

## Using foreach with arrays

The [foreach](../../language-reference/statements/iteration-statements.md#the-foreach-statement) statement provides a simple, clean way to iterate through the elements of an array.

For single-dimensional arrays, the `foreach` statement processes elements in increasing index order, starting with index 0 and ending with index `Length - 1`:

[!code-csharp[csProgGuideArrays#28](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#28)]

For multi-dimensional arrays, elements are traversed such that the indices of the rightmost dimension are increased first, then the next left dimension, and so on to the left:

[!code-csharp[csProgGuideArrays#29](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#29)]

However, with multidimensional arrays, using a nested [for](../../language-reference/statements/iteration-statements.md#the-for-statement) loop gives you more control over the order in which to process the array elements.

## Passing arrays as arguments

Arrays can be passed as arguments to method parameters. Because arrays are reference types, the method can change the value of the elements.

### Passing single-dimensional arrays as arguments

You can pass an initialized single-dimensional array to a method. For example, the following statement sends an array to a print method.

[!code-csharp[csProgGuideArrays#34](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#34)]

The following code shows a partial implementation of the print method.

[!code-csharp[csProgGuideArrays#33](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#33)]

You can initialize and pass a new array in one step, as is shown in the following example.

[!code-csharp[CsProgGuideArrays#35](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#35)]

In the following example, an array of strings is initialized and passed as an argument to a `DisplayArray` method for strings. The method displays the elements of the array. Next, the `ChangeArray` method reverses the array elements, and then the `ChangeArrayElements` method modifies the first three elements of the array. After each method returns, the `DisplayArray` method shows that passing an array by value doesn't prevent changes to the array elements.

[!code-csharp[csProgGuideArrays#30](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/ArrayExample.cs)]

### Passing multidimensional arrays as arguments

You pass an initialized multidimensional array to a method in the same way that you pass a one-dimensional array.

[!code-csharp[csProgGuideArrays#41](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#41)]

The following code shows a partial declaration of a print method that accepts a two-dimensional array as its argument.

[!code-csharp[csProgGuideArrays#36](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#36)]

You can initialize and pass a new array in one step, as is shown in the following example:

[!code-csharp[csProgGuideArrays#32](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#32)]

In the following example, a two-dimensional array of integers is initialized and passed to the `Print2DArray` method. The method displays the elements of the array.

[!code-csharp[csProgGuideArrays#31](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideArrays/CS/Arrays.cs#31)]

## Implicitly Typed Arrays

You can create an implicitly-typed array in which the type of the array instance is inferred from the elements specified in the array initializer. The rules for any implicitly-typed variable also apply to implicitly-typed arrays. For more information, see [Implicitly Typed Local Variables](../../programming-guide/classes-and-structs/implicitly-typed-local-variables.md).

Implicitly-typed arrays are usually used in query expressions together with anonymous types and object and collection initializers.

The following examples show how to create an implicitly-typed array:

[!code-csharp[csProgGuideLINQ#37](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csRef30LangFeatures_2.cs#37)]

In the previous example, notice that with implicitly-typed arrays, no square brackets are used on the left side of the initialization statement. Note also that jagged arrays are initialized by using `new []` just like single-dimension arrays.

### Implicitly-typed Arrays in Object Initializers

When you create an anonymous type that contains an array, the array must be implicitly typed in the type's object initializer. In the following example, `contacts` is an implicitly-typed array of anonymous types, each of which contains an array named `PhoneNumbers`. Note that the `var` keyword is not used inside the object initializers.

[!code-csharp[csProgGuideLINQ#38](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideLINQ/CS/csRef30LangFeatures_2.cs#38)]
