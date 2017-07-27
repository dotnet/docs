---
title: Lists (F#)
description: Learn about F# lists, an ordered, immutable series of elements of the same type.
keywords: visual f#, f#, functional programming
author: cartermp
ms.author: phcart
ms.date: 05/16/2016
ms.topic: language-reference
ms.prod: .net
ms.technology: devlang-fsharp
ms.devlang: fsharp
ms.assetid: a1a6075f-064d-4aee-8222-2b59ff16cc12 
---

# Lists

> [!NOTE]
The API reference links in this article will take you to MSDN.  The docs.microsoft.com API reference is not complete.

A list in F# is an ordered, immutable series of elements of the same type. To perform basic operations on lists, use the functions in the [List module](https://msdn.microsoft.com/library/a2264ba3-2d45-40dd-9040-4f7aa2ad9788).


## Creating and Initializing Lists
You can define a list by explicitly listing out the elements, separated by semicolons and enclosed in square brackets, as shown in the following line of code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet1301.fs)]

You can also put line breaks between elements, in which case the semicolons are optional. The latter syntax can result in more readable code when the element initialization expressions are longer, or when you want to include a comment for each element.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet13011.fs)]

Normally, all list elements must be the same type. An exception is that a list in which the elements are specified to be a base type can have elements that are derived types. Thus the following is acceptable, because both `Button` and `CheckBox` derive from `Control`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet13012.fs)]

You can also define list elements by using a range indicated by integers separated by the range operator (`..`), as shown in the following code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet1302.fs)]

An empty list is specified by a pair of square brackets with nothing in between them.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet1304.fs)]

You can also use a sequence expression to create a list. See [Sequence Expressions](sequences.md#sequence-expressions) for more information. For example, the following code creates a list of squares of integers from 1 to 10.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet1303.fs)]

## Operators for Working with Lists
You can attach elements to a list by using the `::` (cons) operator. If `list1` is `[2; 3; 4]`, the following code creates `list2` as `[100; 2; 3; 4]`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet1305.fs)]

You can concatenate lists that have compatible types by using the `@` operator, as in the following code. If `list1` is `[2; 3; 4]` and `list2` is `[100; 2; 3; 4 ]`, this code creates `list3` as `[2; 3; 4; 100; 2; 3; 4]`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet1306.fs)]

Functions for performing operations on lists are available in the [List module](https://msdn.microsoft.com/library/a2264ba3-2d45-40dd-9040-4f7aa2ad9788).

Because lists in F# are immutable, any modifying operations generate new lists instead of modifying existing lists.

Lists in F# are implemented as singly linked lists, which means that operations that access only the head of the list are O(1), and element access is O(*n*).


## Properties
The list type supports the following properties:

|Property|Type|Description|
|--------|----|-----------|
|[Head](https://msdn.microsoft.com/library/5f9414fd-6bdb-470a-8b72-40016db30740)|`'T`|The first element.|
|[Empty](https://msdn.microsoft.com/library/44406ecb-1918-4d32-b32a-ca1f69840386)|`'T list`|A static property that returns an empty list of the appropriate type.|
|[IsEmpty](https://msdn.microsoft.com/library/3ba087b2-2fc2-406d-b10a-cff6a19322da)|`bool`|`true` if the list has no elements.|
|[Item](https://msdn.microsoft.com/library/bdb2553a-0e54-4ff8-baed-ab1aac8f5dae)|`'T`|The element at the specified index (zero-based).|
|[Length](https://msdn.microsoft.com/library/25f715c8-9daa-4c4d-a6c7-26772f9dab4d)|`int`|The number of elements.|
|[Tail](https://msdn.microsoft.com/library/2a6f8eb9-dc32-41aa-8b62-2baffaface91)|`'T list`|The list without the first element.|
Following are some examples of using these properties.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet1307.fs)]
    
## Using Lists
Programming with lists enables you to perform complex operations with a small amount of code. This section describes common operations on lists that are important to functional programming.


### Recursion with Lists
Lists are uniquely suited to recursive programming techniques. Consider an operation that must be performed on every element of a list. You can do this recursively by operating on the head of the list and then passing the tail of the list, which is a smaller list that consists of the original list without the first element, back again to the next level of recursion.

To write such a recursive function, you use the cons operator (`::`) in pattern matching, which enables you to separate the head of a list from the tail.

The following code example shows how to use pattern matching to implement a recursive function that performs operations on a list.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet13071.fs)]

The previous code works well for small lists, but for larger lists, it could overflow the stack. The following code improves on this code by using an accumulator argument, a standard technique for working with recursive functions. The use of the accumulator argument makes the function tail recursive, which saves stack space.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet13072.fs)]

The function `RemoveAllMultiples` is a recursive function that takes two lists. The first list contains the numbers whose multiples will be removed, and the second list is the list from which to remove the numbers. The code in the following example uses this recursive function to eliminate all the non-prime numbers from a list, leaving a list of prime numbers as the result.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lang-ref-1/snippet1308.fs)]

The output is as follows:

```
Primes Up To 100:
[2; 3; 5; 7; 11; 13; 17; 19; 23; 29; 31; 37; 41; 43; 47; 53; 59; 61; 67; 71; 73; 79; 83; 89; 97]
```

## Module Functions
The [List module](https://msdn.microsoft.com/library/a2264ba3-2d45-40dd-9040-4f7aa2ad9788) provides functions that access the elements of a list. The head element is the fastest and easiest to access. Use the property [Head](https://msdn.microsoft.com/library/5f9414fd-6bdb-470a-8b72-40016db30740) or the module function [List.head](https://msdn.microsoft.com/library/22514cc5-0511-498b-a2cc-837b688a6da2). You can access the tail of a list by using the [Tail](https://msdn.microsoft.com/library/2a6f8eb9-dc32-41aa-8b62-2baffaface91) property or the [List.tail](https://msdn.microsoft.com/library/da0a0638-4420-4571-84b6-d09ae601f601) function. To find an element by index, use the [List.nth](https://msdn.microsoft.com/library/1f717d57-89be-4007-a971-9cf5a28d83b1) function. `List.nth` traverses the list. Therefore, it is O(*n*). If your code uses `List.nth` frequently, you might want to consider using an array instead of a list. Element access in arrays is O(1).


### Boolean Operations on Lists
The [List.isEmpty](https://msdn.microsoft.com/library/a7941d44-9e92-427c-b806-c378f4558107) function determines whether a list has any elements.

The [List.exists](https://msdn.microsoft.com/library/15a3ebd5-98f0-44c0-8220-7dedec3e68a8) function applies a Boolean test to elements of a list and returns `true` if any element satisfies the test. [List.exists2](https://msdn.microsoft.com/library/7532b39e-3f4f-4534-a60b-d7721dc6fa7e) is similar but operates on successive pairs of elements in two lists.

The following code demonstrates the use of `List.exists`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet1.fs)]

The output is as follows:

```
For list [0; 1; 2; 3], contains zero is true
```

The following example demonstrates the use of `List.exists2`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet2.fs)]

The output is as follows:

```
Lists [1; 2; 3; 4; 5] and [5; 4; 3; 2; 1] have at least one equal element at the same position.
```

You can use [List.forall](https://msdn.microsoft.com/library/e11a5233-d612-40ac-833b-d5cf496900b7) if you want to test whether all the elements of a list meet a condition.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet3.fs)]

The output is as follows:

```
true
false
```

Similarly, [List.forall2](https://msdn.microsoft.com/library/bb611f02-8277-48f5-9af3-6194ae27d07e) determines whether all elements in the corresponding positions in two lists satisfy a Boolean expression that involves each pair of elements.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet4.fs)]

The output is as follows:

```
true
false
```

### Sort Operations on Lists
The [List.sort](https://msdn.microsoft.com/library/17f1030e-aa7e-41dd-94ea-72cb6c04fd3d), [List.sortBy](https://msdn.microsoft.com/library/955bfc5f-ad9c-4f2d-a7ab-91e43eb21359), and [List.sortWith](https://msdn.microsoft.com/library/1d806a54-9166-4198-906d-15101f7916c7) functions sort lists. The sorting function determines which of these three functions to use. `List.sort` uses default generic comparison. Generic comparison uses global operators based on the generic compare function to compare values. It works efficiently with a wide variety of element types, such as simple numeric types, tuples, records, discriminated unions, lists, arrays, and any type that implements `System.IComparable`. For types that implement `System.IComparable`, generic comparison uses the `System.IComparable.CompareTo()` function. Generic comparison also works with strings, but uses a culture-independent sorting order. Generic comparison should not be used on unsupported types, such as function types. Also, the performance of the default generic comparison is best for small structured types; for larger structured types that need to be compared and sorted frequently, consider implementing `System.IComparable` and providing an efficient implementation of the `System.IComparable.CompareTo()` method.

`List.sortBy` takes a function that returns a value that is used as the sort criterion, and `List.sortWith` takes a comparison function as an argument. These latter two functions are useful when you are working with types that do not support comparison, or when the comparison requires more complex comparison semantics, as in the case of culture-aware strings.

The following example demonstrates the use of `List.sort`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet5.fs)]

The output is as follows:

```
[-2; 1; 4; 5; 8]
```

The following example demonstrates the use of `List.sortBy`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet6.fs)]

The output is as follows:

```
[1; -2; 4; 5; 8]
```

The next example demonstrates the use of `List.sortWith`. In this example, the custom comparison function `compareWidgets` is used to first compare one field of a custom type, and then another when the values of the first field are equal.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet7.fs)]

The output is as follows:

```
[{ID = 92;
Rev = 1;}; {ID = 92;
Rev = 1;}; {ID = 100;
Rev = 2;}; {ID = 100;
Rev = 5;}; {ID = 110;
Rev = 1;}]
```

### Search Operations on Lists
Numerous search operations are supported for lists. The simplest, [List.find](https://msdn.microsoft.com/library/0594593e-9c75-44c1-8f5a-a37b2e561c06), enables you to find the first element that matches a given condition.

The following code example demonstrates the use of `List.find` to find the first number that is divisible by 5 in a list.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet8.fs)]

The result is 5.

If the elements must be transformed first, call [List.pick](https://msdn.microsoft.com/library/0430b515-7fe4-49a1-a616-d2286d8b08b2), which takes a function that returns an option, and looks for the first option value that is `Some(x)`. Instead of returning the element, `List.pick` returns the result `x`. If no matching element is found, `List.pick` throws `System.Collections.Generic.KeyNotFoundException`. The following code shows the use of `List.pick`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet9.fs)]

The output is as follows:

```
"b"
```

Another group of search operations, [List.tryFind](https://msdn.microsoft.com/library/37f4532e-9fd0-4802-8bbd-e1aa2380287d) and related functions, return an option value. The `List.tryFind` function returns the first element of a list that satisfies a condition if such an element exists, but the option value `None` if not. The variation [List.tryFindIndex](https://msdn.microsoft.com/library/5e31968c-c3d3-43d2-859a-0526825895ec) returns the index of the element, if one is found, rather than the element itself. These functions are illustrated in the following code.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet10.fs)]

The output is as follows:

```
The first even value is 22.
The first even value is at position 8.
```

### Arithmetic Operations on Lists
Common arithmetic operations such as sum and average are built into the [List module](https://msdn.microsoft.com/library/a2264ba3-2d45-40dd-9040-4f7aa2ad9788). To work with [List.sum](https://msdn.microsoft.com/library/54d47fe3-5ecf-4883-beb5-e915342a17f9), the list element type must support the `+` operator and have a zero value. All built-in arithmetic types satisfy these conditions. To work with [List.average](https://msdn.microsoft.com/library/2b9a627b-106d-4548-8c4c-ab5058b8f8e1), the element type must support division without a remainder, which excludes integral types but allows for floating point types. The [List.sumBy](https://msdn.microsoft.com/library/b7623389-0fe1-4762-9c67-51079903ab7d) and [List.averageBy](https://msdn.microsoft.com/library/936cc9ec-62af-464d-8726-7999c2f48403) functions take a function as a parameter, and this function's results are used to calculate the values for the sum or average.

The following code demonstrates the use of `List.sum`, `List.sumBy`, and `List.average`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet11.fs)]

The output is `1.000000`.

The following code shows the use of `List.averageBy`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet12.fs)]

The output is `5.5`.


### Lists and Tuples
Lists that contain tuples can be manipulated by zip and unzip functions. These functions combine two lists of single values into one list of tuples or separate one list of tuples into two lists of single values. The simplest [List.zip](https://msdn.microsoft.com/library/3028d790-8f48-4c94-bf08-b058bec3689c) function takes two lists of single elements and produces a single list of tuple pairs. Another version, [List.zip3](https://msdn.microsoft.com/library/003cc28e-0de3-4d99-89ed-cb19028e3c5b), takes three lists of single elements and produces a single list of tuples that have three elements. The following code example demonstrates the use of `List.zip`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet13.fs)]

The output is as follows:

```
[(1, -1); (2, -2); (3; -3)]
```

The following code example demonstrates the use of `List.zip3`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet14.fs)]

The output is as follows:

```
[(1, -1, 0); (2, -2, 0); (3, -3, 0)]
```

The corresponding unzip versions, [List.unzip](https://msdn.microsoft.com/library/639db80c-41b5-45bb-a6b4-1eaa04d61d21) and [List.unzip3](https://msdn.microsoft.com/library/43078c77-32ec-4342-85b3-c31ccf984db4), take lists of tuples and return lists in a tuple, where the first list contains all the elements that were first in each tuple, and the second list contains the second element of each tuple, and so on.

The following code example demonstrates the use of [List.unzip](https://msdn.microsoft.com/library/639db80c-41b5-45bb-a6b4-1eaa04d61d21).

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet15.fs)]

The output is as follows:

```
([1; 3], [2; 4])
[1; 3] [2; 4]
```

The following code example demonstrates the use of [List.unzip3](https://msdn.microsoft.com/library/43078c77-32ec-4342-85b3-c31ccf984db4).

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet16.fs)]

The output is as follows:

```
([1; 4], [2; 5], [3; 6])
```

### Operating on List Elements
F# supports a variety of operations on list elements. The simplest is [List.iter](https://msdn.microsoft.com/library/f778d075-81a9-4994-af60-cddcc53a201f), which enables you to call a function on every element of a list. Variations include [List.iter2](https://msdn.microsoft.com/library/ea3b7761-916c-4016-9bd8-651124c98b40), which enables you to perform an operation on elements of two lists, [List.iteri](https://msdn.microsoft.com/library/6dd21ae6-5c00-41cd-8306-821e513d8f60), which is like `List.iter` except that the index of each element is passed as an argument to the function that is called for each element, and [List.iteri2](https://msdn.microsoft.com/library/9658d740-9be5-4bf7-b663-c8ab2b3e196c), which is a combination of the functionality of `List.iter2` and `List.iteri`. The following code example illustrates these functions.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet17.fs)]

The output is as follows:

```
List.iter: element is 1
List.iter: element is 2
List.iter: element is 3
List.iteri: element 0 is 1
List.iteri: element 1 is 2
List.iteri: element 2 is 3
List.iter2: elements are 1 4
List.iter2: elements are 2 5
List.iter2: elements are 3 6
List.iteri2: element 0 of list1 is 1; element 0 of list2 is 4
List.iteri2: element 1 of list1 is 2; element 1 of list2 is 5
List.iteri2: element 2 of list1 is 3; element 2 of list2 is 6
```

Another frequently used function that transforms list elements is [List.map](https://msdn.microsoft.com/library/c6b49c99-d4f3-4ba3-b1d0-85a312683dc6), which enables you to apply a function to each element of a list and put all the results into a new list. [List.map2](https://msdn.microsoft.com/library/5f48cce7-6eaf-4e54-8996-2b04d3c31e57) and [List.map3](https://msdn.microsoft.com/library/dd9fb190-6980-4537-be96-5645a64908f8) are variations that take multiple lists. You can also use [List.mapi](https://msdn.microsoft.com/library/284b9234-3d26-409b-b328-ac79638d9e14) and [List.mapi2](https://msdn.microsoft.com/library/680643af-233c-40a3-82f2-43d5af27ec49), if, in addition to the element, the function needs to be passed the index of each element. The only difference between `List.mapi2` and `List.mapi` is that `List.mapi2` works with two lists. The following example illustrates [List.map](https://msdn.microsoft.com/library/c6b49c99-d4f3-4ba3-b1d0-85a312683dc6).

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet18.fs)]

The output is as follows:

```
[2; 3; 4]
```

The following example shows the use of `List.map2`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet19.fs)]

The output is as follows:

```
[5; 7; 9]
```

The following example shows the use of `List.map3`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet20.fs)]

The output is as follows:

```
[7; 10; 13]
```

The following example shows the use of `List.mapi`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet21.fs)]

The output is as follows:

```
[1; 3; 5]
```

The following example shows the use of `List.mapi2`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet22.fs)]

The output is as follows:

```
[0; 7; 18]
```

[List.collect](https://msdn.microsoft.com/library/cd08bbc7-a3b9-40ab-8c20-4e85ec84664f) is like `List.map`, except that each element produces a list and all these lists are concatenated into a final list. In the following code, each element of the list generates three numbers. These are all collected into one list.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet23.fs)]

The output is as follows:

```
[1; 2; 3; 2; 4; 6; 3; 6; 9]
```

You can also use [List.filter](https://msdn.microsoft.com/library/11a8c926-547b-44dd-bbae-98d44f3dd248), which takes a Boolean condition and produces a new list that consists only of elements that satisfy the given condition.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet24.fs)]

The resulting list is `[2; 4; 6]`.

A combination of map and filter, [List.choose](https://msdn.microsoft.com/library/2e21d3fb-ce35-4824-8a57-c4404616093d) enables you to transform and select elements at the same time. `List.choose` applies a function that returns an option to each element of a list, and returns a new list of the results for elements when the function returns the option value `Some`.

The following code demonstrates the use of `List.choose` to select capitalized words out of a list of words.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet25.fs)]

The output is as follows:

```
["Rome's"; "Bob's"]
```

### Operating on Multiple Lists
Lists can be joined together. To join two lists into one, use [List.append](https://msdn.microsoft.com/library/2954da80-3f4a-4a4b-9371-794645c03426). To join more than two lists, use [List.concat](https://msdn.microsoft.com/library/c5afd433-8764-4ea8-a6a8-937fb4d77c4c).

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet26.fs)]
    
### Fold and Scan Operations
Some list operations involve interdependencies between all of the list elements. The fold and scan operations are like `List.iter` and `List.map` in that you invoke a function on each element, but these operations provide an additional parameter called the *accumulator* that carries information through the computation.

Use `List.fold` to perform a calculation on a list.

The following code example demonstrates the use of [List.fold](https://msdn.microsoft.com/library/c272779e-bae7-4983-8d7f-16b345bb33a0) to perform various operations.

The list is traversed; the accumulator `acc` is a value that is passed along as the calculation proceeds. The first argument takes the accumulator and the list element, and returns the interim result of the calculation for that list element. The second argument is the initial value of the accumulator.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet27.fs)]

The versions of these functions that have a digit in the function name operate on more than one list. For example, [List.fold2](https://msdn.microsoft.com/library/6cfcd043-a65d-4423-805a-2ab234cb5343) performs computations on two lists.

The following example demonstrates the use of `List.fold2`.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet28.fs)]

`List.fold` and [List.scan](https://msdn.microsoft.com/library/21f636db-885c-4a72-970e-e3841f33a1b8) differ in that `List.fold` returns the final value of the extra parameter, but `List.scan` returns the list of the intermediate values (along with the final value) of the extra parameter.

Each of these functions includes a reverse variation, for example, [List.foldBack](https://msdn.microsoft.com/library/b9a58e66-efe1-445f-a90c-ac9ffb9d40c7), which differs in the order in which the list is traversed and the order of the arguments. Also, `List.fold` and `List.foldBack` have variations, [List.fold2](https://msdn.microsoft.com/library/6cfcd043-a65d-4423-805a-2ab234cb5343) and [List.foldBack2](https://msdn.microsoft.com/library/56371d3e-5271-4183-9e8c-15a02eda9aa2), that take two lists of equal length. The function that executes on each element can use corresponding elements of both lists to perform some action. The element types of the two lists can be different, as in the following example, in which one list contains transaction amounts for a bank account, and the other list contains the type of transaction: deposit or withdrawal.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet29.fs)]

For a calculation like summation, `List.fold` and `List.foldBack` have the same effect because the result does not depend on the order of traversal. In the following example, `List.foldBack` is used to add the elements in a list.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet30.fs)]

The following example returns to the bank account example. This time a new transaction type is added: an interest calculation. The ending balance now depends on the order of transactions.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet34.fs)]

The function [List.reduce](https://msdn.microsoft.com/library/048e1f95-691b-49cb-bb99-fb85f68f3d8b) is somewhat like `List.fold` and `List.scan`, except that instead of passing around a separate accumulator, `List.reduce` takes a function that takes two arguments of the element type instead of just one, and one of those arguments acts as the accumulator, meaning that it stores the intermediate result of the computation. `List.reduce` starts by operating on the first two list elements, and then uses the result of the operation along with the next element. Because there is not a separate accumulator that has its own type, `List.reduce` can be used in place of `List.fold` only when the accumulator and the element type have the same type. The following code demonstrates the use of `List.reduce`. `List.reduce` throws an exception if the list provided has no elements.

In the following code, the first call to the lambda expression is given the arguments 2 and 4, and returns 6, and the next call is given the arguments 6 and 10, so the result is 16.

[!code-fsharp[Main](../../../samples/snippets/fsharp/lists/snippet33.fs)]
    
### Converting Between Lists and Other Collection Types
The `List` module provides functions for converting to and from both sequences and arrays. To convert to or from a sequence, use [List.toSeq](https://msdn.microsoft.com/library/7024be4b-ee70-43cc-8d0a-e6564a4ff7c0) or [List.ofSeq](https://msdn.microsoft.com/library/74ab9289-4a59-4433-92eb-3f662d7f7db0). To convert to or from an array, use [List.toArray](https://msdn.microsoft.com/library/ac87dd82-a0cd-40b3-b1fa-dd3168134547) or [List.ofArray](https://msdn.microsoft.com/library/f4bddc26-8c8f-4307-a6d7-a49dceb97032).


### Additional Operations
For information about additional operations on lists, see the library reference topic [Collections.List Module](https://msdn.microsoft.com/visualfsharpdocs/conceptual/collections.list-module-%5bfsharp%5d).


## See Also
[F# Language Reference](index.md)

[F# Types](fsharp-types.md)

[Sequences](sequences.md)

[Arrays](arrays.md)

[Options](options.md)
