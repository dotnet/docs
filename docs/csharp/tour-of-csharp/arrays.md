---
title: C# Arrays | A tour of the C# language
description: Arrays are the most basic collection type in the C# langauge
keywords: .NET, csharp, array, collection
author: BillWagner
manager: wpickett
ms.date: 08/10/2016
ms.topic: article
ms.prod: visual-studio-dev-14
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: a440704c-9e88-4c75-97dd-bfe30ca0fb97
---

# Arrays

An ***array*** is a data structure that contains a number of variables that are accessed through computed indices. The variables contained in an array, also called the ***elements*** of the array, are all of the same type, and this type is called the ***element type*** of the array.

Array types are reference types, and the declaration of an array variable simply sets aside space for a reference to an array instance. Actual array instances are created dynamically at run-time using the new operator. The new operation specifies the ***length*** of the new array instance, which is then fixed for the lifetime of the instance. The indices of the elements of an array range from `0` to `Length - 1`. The `new` operator automatically initializes the elements of an array to their default value, which, for example, is zero for all numeric types and `null` for all reference types.

The following example creates an array of `int` elements, initializes the array, and prints out the contents of the array.

```csharp
using System;
class ArrayExample
{
	static void Main() 
	{
		int[] a = new int[10];
		for (int i = 0; i < a.Length; i++) 
		{
			a[i] = i * i;
		}
		for (int i = 0; i < a.Length; i++) 
		{
			Console.WriteLine($"a[{i}] = {a[i]}");
		}
	}
}
```

This example creates and operates on a ***single-dimensional array***. C# also supports ***multi-dimensional arrays***. The number of dimensions of an array type, also known as the ***rank*** of the array type, is one plus the number of commas written between the square brackets of the array type. The following example allocates a single-dimensional, a two-dimensional, and a three-dimensional array, respectively.

```csharp
int[] a1 = new int[10];
int[,] a2 = new int[10, 5];
int[,,] a3 = new int[10, 5, 2];
```

The `a1` array contains 10 elements, the `a2` array contains 50 (10 × 5) elements, and the `a3` array contains 100 (10 × 5 × 2) elements.
The element type of an array can be any type, including an array type. An array with elements of an array type is sometimes called a ***jagged array*** because the lengths of the element arrays do not all have to be the same. The following example allocates an array of arrays of int:

```csharp
int[][] a = new int[3][];
a[0] = new int[10];
a[1] = new int[5];
a[2] = new int[20];
```

The first line creates an array with three elements, each of type int[] and each with an initial value of null. The subsequent lines then initialize the three elements with references to individual array instances of varying lengths.

The new operator permits the initial values of the array elements to be specified using an ***array initializer***, which is a list of expressions written between the delimiters `{` and `}`. The following example allocates and initializes an `int[]` with three elements.

```csharp
int[] a = new int[] {1, 2, 3};
```

Note that the length of the array is inferred from the number of expressions between { and }. Local variable and field declarations can be shortened further such that the array type does not have to be restated.

```csharp
int[] a = {1, 2, 3};
```

Both of the previous examples are equivalent to the following:

```csharp
int[] t = new int[3];
t[0] = 1;
t[1] = 2;
t[2] = 3;
int[] a = t;
```

>[!div class="step-by-step"]
[Pre](structs.md)
[Next](interfaces.md)
