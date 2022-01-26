---
title: Sequences
description: Learn how to use F# sequences, when you have an ordered collection of data but don't necessarily expect to use all of the elements.
ms.date: 10/29/2021
---
# Sequences

A *sequence* is a logical series of elements all of one type. Sequences are particularly useful when you have a large, ordered collection of data but do not necessarily expect to use all of the elements. Individual sequence elements are computed only as required, so a sequence can provide better performance than a list in situations in which not all the elements are used. Sequences are represented by the `seq<'T>` type, which is an alias for <xref:System.Collections.Generic.IEnumerable%601>. Therefore, any .NET type that implements <xref:System.Collections.Generic.IEnumerable%601> interface can be used as a sequence. The [Seq module](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html) provides support for manipulations involving sequences.

## Sequence Expressions

A *sequence expression* is an expression that evaluates to a sequence. Sequence expressions can take a number of forms. The simplest form specifies a range. For example, `seq { 1 .. 5 }` creates a sequence that contains five elements, including the endpoints 1 and 5. You can also specify an increment (or decrement) between two double periods. For example, the following code creates the sequence of multiples of 10.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1502.fs)]

Sequence expressions are made up of F# expressions that produce values of the sequence. You can also generate values programmatically:

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1503.fs)]

The previous sample uses the `->` operator, which allows you to specify an expression whose value will become a part of the sequence. You can only use `->` if every part of the code that follows it returns a value.

Alternatively, you can specify the `do` keyword, with an optional `yield` that follows:

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1504.fs)]

The following code generates a list of coordinate pairs along with an index into an array that represents the grid. Note that the first `for` expression requires a `do` to be specified.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1505.fs)]

An `if` expression used in a sequence is a filter. For example, to generate a sequence of only prime numbers, assuming that you have a function `isprime` of type `int -> bool`, construct the sequence as follows.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1506.fs)]

As mentioned previously, `do` is required here because there is no `else` branch that goes with the `if`. If you try to use `->`, you'll get an error saying that not all branches return a value.

## The `yield!` keyword

Sometimes, you may wish to include a sequence of elements into another sequence. To include a sequence within another sequence, you'll need to use the `yield!` keyword:

```fsharp
// Repeats '1 2 3 4 5' ten times
seq {
    for _ in 1..10 do
        yield! seq { 1; 2; 3; 4; 5}
}
```

Another way of thinking of `yield!` is that it flattens an inner sequence and then includes that in the containing sequence.

When `yield!` is used in an expression, all other single values must use the `yield` keyword:

```fsharp
// Combine repeated values with their values
seq {
    for x in 1..10 do
        yield x
        yield! seq { for i in 1..x -> i}
}
```

The previous example will produce the value of `x` in addition to all values from `1` to `x` for each `x`.

## Examples

The first example uses a sequence expression that contains an iteration, a filter, and a yield to generate an array. This code prints a sequence of prime numbers between 1 and 100 to the console.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1507.fs)]

The following example creates a multiplication table that consists of tuples of three elements, each consisting of two factors and the product:

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1508.fs)]

The following example demonstrates the use of `yield!` to combine individual sequences into a single final sequence. In this case, the sequences for each subtree in a binary tree are concatenated in a recursive function to produce the final sequence.

[!code-fsharp[Main](~/samples/snippets/fsharp/lang-ref-1/snippet1509.fs)]

## Using Sequences

Sequences support many of the same functions as [lists](lists.md). Sequences also support operations such as grouping and counting by using key-generating functions. Sequences also support more diverse functions for extracting subsequences.

Many data types, such as lists, arrays, sets, and maps are implicitly sequences because they are enumerable collections. A function that takes a sequence as an argument works with any of the common F# data types, in addition to any .NET data type that implements `System.Collections.Generic.IEnumerable<'T>`. Contrast this to a function that takes a list as an argument, which can only take lists. The type `seq<'T>` is a type abbreviation for `IEnumerable<'T>`. This means that any type that implements the generic `System.Collections.Generic.IEnumerable<'T>`, which includes arrays, lists, sets, and maps in F#, and also most .NET collection types, is compatible with the `seq` type and can be used wherever a sequence is expected.

## Module Functions

The [Seq module](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html) in the [FSharp.Collections namespace](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections.html) contains functions for working with sequences. These functions work with lists, arrays, maps, and sets as well, because all of those types are enumerable, and therefore can be treated as sequences.

## Creating Sequences

You can create sequences by using sequence expressions, as described previously, or by using certain functions.

You can create an empty sequence by using [Seq.empty](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#empty), or you can create a sequence of just one specified element by using [Seq.singleton](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#singleton).

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet9.fs)]

You can use [Seq.init](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#init) to create a sequence for which the elements are created by using a function that you provide. You also provide a size for the sequence. This function is just like [List.init](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#init), except that the elements are not created until you iterate through the sequence. The following code illustrates the use of `Seq.init`.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet10.fs)]

The output is

```console
0 10 20 30 40
```

By using [Seq.ofArray](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#ofArray) and [Seq.ofList&#60;'T&#62; Function](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#ofList), you can create sequences from arrays and lists. However, you can also convert arrays and lists to sequences by using a cast operator. Both techniques are shown in the following code.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet11.fs)]

By using [Seq.cast](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#cast), you can create a sequence from a weakly typed collection, such as those defined in `System.Collections`. Such weakly typed collections have the element type `System.Object` and are enumerated by using the non-generic `System.Collections.Generic.IEnumerable&#96;1` type. The following code illustrates the use of `Seq.cast` to convert an `System.Collections.ArrayList` into a sequence.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet12.fs)]

You can define infinite sequences by using the [Seq.initInfinite](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#initInfinite) function. For such a sequence, you provide a function that generates each element from the index of the element. Infinite sequences are possible because of lazy evaluation; elements are created as needed by calling the function that you specify. The following code example produces an infinite sequence of floating point numbers, in this case the alternating series of reciprocals of squares of successive integers.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet13.fs)]

[Seq.unfold](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#unfold) generates a sequence from a computation function that takes a state and transforms it to produce each subsequent element in the sequence. The state is just a value that is used to compute each element, and can change as each element is computed. The second argument to `Seq.unfold` is the initial value that is used to start the sequence. `Seq.unfold` uses an option type for the state, which enables you to terminate the sequence by returning the `None` value. The following code shows two examples of sequences, `seq1` and `fib`, that are generated by an `unfold` operation. The first, `seq1`, is just a simple sequence with numbers up to 20. The second, `fib`, uses `unfold` to compute the Fibonacci sequence. Because each element in the Fibonacci sequence is the sum of the previous two Fibonacci numbers, the state value is a tuple that consists of the previous two numbers in the sequence. The initial value is `(1,1)`, the first two numbers in the sequence.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet14.fs)]

The output is as follows:

```console
The sequence seq1 contains numbers from 0 to 20.

0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20

The sequence fib contains Fibonacci numbers.

2 3 5 8 13 21 34 55 89 144 233 377 610 987 1597
```

The following code is an example that uses many of the sequence module functions described here to generate and compute the values of infinite sequences. The code might take a few minutes to run.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet15.fs)]

## Searching and Finding Elements

Sequences support functionality available with lists: [Seq.exists](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#exists), [Seq.exists2](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#exists), [Seq.find](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#find), [Seq.findIndex](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#findIndex), [Seq.pick](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#pick), [Seq.tryFind](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#tryFind), and [Seq.tryFindIndex](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#tryFindIndex). The versions of these functions that are available for sequences evaluate the sequence only up to the element that is being searched for. For examples, see [Lists](lists.md).

## Obtaining Subsequences

[Seq.filter](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#filter) and [Seq.choose](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#choose) are like the corresponding functions that are available for lists, except that the filtering and choosing does not occur until the sequence elements are evaluated.

[Seq.truncate](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#truncate) creates a sequence from another sequence, but limits the sequence to a specified number of elements. [Seq.take](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#take) creates a new sequence that contains only a specified number of elements from the start of a sequence. If there are fewer elements in the sequence than you specify to take, `Seq.take` throws a `System.InvalidOperationException`. The difference between `Seq.take` and `Seq.truncate` is that `Seq.truncate` does not produce an error if the number of elements is fewer than the number you specify.

The following code shows the behavior of and differences between `Seq.truncate` and `Seq.take`.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet16.fs)]

The output, before the error occurs, is as follows.

```console
1 4 9 16 25
1 4 9 16 25 36 49 64 81 100
1 4 9 16 25
1 4 9 16 25 36 49 64 81 100
```

By using [Seq.takeWhile](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#takeWhile), you can specify a predicate function (a Boolean function) and create a sequence from another sequence made up of those elements of the original sequence for which the predicate is `true`, but stop before the first element for which the predicate returns `false`. [Seq.skip](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#skip) returns a sequence that skips a specified number of the first elements of another sequence and returns the remaining elements. [Seq.skipWhile](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#skipWhile) returns a sequence that skips the first elements of another sequence as long as the predicate returns `true`, and then returns the remaining elements, starting with the first element for which the predicate returns `false`.

The following code example illustrates the behavior of and differences between `Seq.takeWhile`, `Seq.skip`, and `Seq.skipWhile`.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet17.fs)]

The output is as follows.

```console
1 4 9
36 49 64 81 100
16 25 36 49 64 81 100
```

## Transforming Sequences

[Seq.pairwise](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#pairwise) creates a new sequence in which successive elements of the input sequence are grouped into tuples.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet18.fs)]

[Seq.windowed](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#windowed) is like `Seq.pairwise`, except that instead of producing a sequence of tuples, it produces a sequence of arrays that contain copies of adjacent elements (a *window*) from the sequence. You specify the number of adjacent elements you want in each array.

The following code example demonstrates the use of `Seq.windowed`. In this case the number of elements in the window is 3. The example uses `printSeq`, which is defined in the previous code example.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet180.fs)]

The output is as follows.

Initial sequence:

```console
1.0 1.5 2.0 1.5 1.0 1.5

Windows of length 3:
[|1.0; 1.5; 2.0|] [|1.5; 2.0; 1.5|] [|2.0; 1.5; 1.0|] [|1.5; 1.0; 1.5|]

Moving average:
1.5 1.666666667 1.5 1.333333333
```

## Operations with Multiple Sequences

[Seq.zip](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#zip) and [Seq.zip3](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#zip3) take two or three sequences and produce a sequence of tuples. These functions are like the corresponding functions available for [lists](lists.md). There is no corresponding functionality to separate one sequence into two or more sequences. If you need this functionality for a sequence, convert the sequence to a list and use [List.unzip](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-listmodule.html#unzip).

## Sorting, Comparing, and Grouping

The sorting functions supported for lists also work with sequences. This includes [Seq.sort](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#sort) and [Seq.sortBy](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#sortBy). These functions iterate through the whole sequence.

You compare two sequences by using the [Seq.compareWith](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#compareWith) function. The function compares successive elements in turn, and stops when it encounters the first unequal pair. Any additional elements do not contribute to the comparison.

The following code shows the use of `Seq.compareWith`.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet19.fs)]

In the previous code, only the first element is computed and examined, and the result is -1.

[Seq.countBy](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#countBy) takes a function that generates a value called a *key* for each element. A key is generated for each element by calling this function on each element. `Seq.countBy` then returns a sequence that contains the key values, and a count of the number of elements that generated each value of the key.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet201.fs)]

The output is as follows.

```console
(1, 34) (2, 33) (0, 33)
```

The previous output shows that there were 34 elements of the original sequence that produced the key 1, 33 values that produced the key 2, and 33 values that produced the key 0.

You can group elements of a sequence by calling [Seq.groupBy](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#groupBy). `Seq.groupBy` takes a sequence and a function that generates a key from an element. The function is executed on each element of the sequence. `Seq.groupBy` returns a sequence of tuples, where the first element of each tuple is the key and the second is a sequence of elements that produce that key.

The following code example shows the use of `Seq.groupBy` to partition the sequence of numbers from 1 to 100 into three groups that have the distinct key values 0, 1, and 2.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet202.fs)]

The output is as follows.

```console
(1, seq [1; 4; 7; 10; ...]) (2, seq [2; 5; 8; 11; ...]) (0, seq [3; 6; 9; 12; ...])
```

You can create a sequence that eliminates duplicate elements by calling [Seq.distinct](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#distinct). Or you can use [Seq.distinctBy](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#distinctBy), which takes a key-generating function to be called on each element. The resulting sequence contains elements of the original sequence that have unique keys; later elements that produce a duplicate key to an earlier element are discarded.

The following code example illustrates the use of `Seq.distinct`. `Seq.distinct` is demonstrated by generating sequences that represent binary numbers, and then showing that the only distinct elements are 0 and 1.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet22.fs)]

The following code demonstrates `Seq.distinctBy` by starting with a sequence that contains negative and positive numbers and using the absolute value function as the key-generating function. The resulting sequence is missing all the positive numbers that correspond to the negative numbers in the sequence, because the negative numbers appear earlier in the sequence and therefore are selected instead of the positive numbers that have the same absolute value, or key.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet23.fs)]

## Readonly and Cached Sequences

[Seq.readonly](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#readonly) creates a read-only copy of a sequence. `Seq.readonly` is useful when you have a read-write collection, such as an array, and you do not want to modify the original collection. This function can be used to preserve data encapsulation. In the following code example, a type that contains an array is created. A property exposes the array, but instead of returning an array, it returns a sequence that is created from the array by using `Seq.readonly`.

[!code-fsharp[Main](~/samples/snippets/fsharp/fssequences/snippet24.fs)]

[Seq.cache](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#cache) creates a stored version of a sequence. Use `Seq.cache` to avoid reevaluation of a sequence, or when you have multiple threads that use a sequence, but you must make sure that each element is acted upon only one time. When you have a sequence that is being used by multiple threads, you can have one thread that enumerates and computes the values for the original sequence, and remaining threads can use the cached sequence.

## Performing Computations on Sequences

Simple arithmetic operations are like those of lists, such as [Seq.average](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#average), [Seq.sum](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#sum), [Seq.averageBy](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#averageBy), [Seq.sumBy](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#sumBy), and so on.

[Seq.fold](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#fold), [Seq.reduce](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#reduce), and [Seq.scan](https://fsharp.github.io/fsharp-core-docs/reference/fsharp-collections-seqmodule.html#scan) are like the corresponding functions that are available for lists. Sequences support a subset of the full variations of these functions that lists support. For more information and examples, see [Lists](lists.md).

## See also

- [F# Language Reference](index.md)
- [F# Types](fsharp-types.md)
