---
title: Iterators
description: Learn how to use built-in C# iterators and how to create your own custom iterator methods.
ms.date: 11/09/2021
---

# Iterators

Almost every program you write will have some need to iterate over a collection. You'll write code that examines every item in a collection.

You'll also create iterator methods, which are methods that produce an *iterator* for the elements of that class. An *iterator* is an object that traverses a container, particularly lists. Iterators can be used for:

- Performing an action on each item in a collection.
- Enumerating a custom collection.
- Extending [LINQ](linq/index.md) or other libraries.
- Creating a data pipeline where data flows efficiently through iterator methods.

The C# language provides features for both generating and consuming sequences. These sequences can be produced and consumed synchronously or asynchronously. This article provides an overview of those features.

## Iterating with foreach

Enumerating a collection is simple: The `foreach` keyword enumerates a collection, executing the embedded statement once for each element in the collection:

:::code language="csharp" source="./snippets/iterators/Program.cs" ID="ForeachExample":::

That's all. To iterate over all the contents of a collection, the `foreach` statement is all you need. The `foreach` statement isn't magic, though. It relies on two generic interfaces defined in the .NET core library to generate the code necessary to iterate a collection: `IEnumerable<T>` and `IEnumerator<T>`. This mechanism is explained in more detail below.

Both of these interfaces also have non-generic counterparts: `IEnumerable` and `IEnumerator`. The [generic](fundamentals/types/generics.md) versions are preferred for modern code.

When a sequence is generated asynchronously, you can use the `await foreach` statement to asynchronously consume the sequence:

:::code language="csharp" source="./snippets/iterators/Program.cs" ID="AwaitForeachExample":::

When a sequence is an <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType>, you use `foreach`. When a sequence is an <xref:System.Collections.Generic.IAsyncEnumerable%601?displayProperty=nameWithType>, you use `await foreach`. In the latter case, the sequence is generated asynchronously.

## Enumeration sources with iterator methods

Another great feature of the C# language enables you to build methods that create a source for an enumeration. These methods are referred to as *iterator methods*. An iterator method defines how to generate the objects in a sequence when requested. You use the `yield return` contextual keywords to define an iterator method.

You could write this method to produce the sequence of integers from 0 through 9:

:::code language="csharp" source="./snippets/iterators/Generators.cs" ID="GetNumbers":::

The code above shows distinct `yield return` statements to highlight the fact that you can use multiple discrete `yield return` statements in an iterator method. You can (and often do) use other language constructs to simplify the code of an iterator method. The method definition below produces the exact same sequence of numbers:

:::code language="csharp" source="./snippets/iterators/Generators.cs" ID="GetNumbersLoop":::

You don't have to decide one or the other. You can have as many `yield return` statements as necessary to meet the needs of your method:

:::code language="csharp" source="./snippets/iterators/Generators.cs" ID="GetMultipleLoops":::

All of these preceding examples would have an asynchronous counterpart. In each case, you'd replace the return type of `IEnumerable<T>` with an `IAsyncEnumerable<T>`. For example, the previous example would have the following asynchronous version:

:::code language="csharp" source="./snippets/iterators/Generators.cs" ID="GetMultipleAsyncLoops":::

That's the syntax for both synchronous and asynchronous iterators. Let's consider a real world example. Imagine you're on an IoT project and the device sensors generate a very large stream of data. To get a feel for the data, you might write a method that samples every Nth data element. This small iterator method does the trick:

:::code language="csharp" source="./snippets/iterators/Generators.cs" ID="SampleSequence":::

If reading from the IoT device produces an asynchronous sequence, you'd modify the method as the following method shows:

:::code language="csharp" source="./snippets/iterators/Generators.cs" ID="SampleSequenceAsync":::

There's one important restriction on iterator methods: you can't have both a `return` statement and a `yield return` statement in the same method. The following code won't compile:

```csharp
public IEnumerable<int> GetSingleDigitNumbers()
{
    int index = 0;
    while (index < 10)
        yield return index++;

    yield return 50;

    // generates a compile time error:
    var items = new int[] {100, 101, 102, 103, 104, 105, 106, 107, 108, 109 };
    return items;
}
```

This restriction normally isn't a problem. You have a choice of either using `yield return` throughout the method, or separating the original method into multiple methods, some using `return`, and some using `yield return`.

You can modify the last method slightly to use `yield return` everywhere:

:::code language="csharp" source="./snippets/iterators/Generators.cs" ID="SequenceAndCollection":::

Sometimes, the right answer is to split an iterator method into two different methods. One that uses `return`, and a second that uses `yield return`. Consider a situation where you might want to return an empty collection, or the first five odd numbers, based on a boolean argument. You could write that as these two methods:

:::code language="csharp" source="./snippets/iterators/Generators.cs" ID="ReturnAndYieldReturn":::

Look at the methods above. The first uses the standard `return` statement to return either an empty collection, or the iterator created by the second method. The second method uses the `yield return` statement to create the requested sequence.

## Deeper dive into `foreach`

The `foreach` statement expands into a standard idiom that uses the `IEnumerable<T>` and `IEnumerator<T>` interfaces to iterate across all elements of a collection. It also minimizes errors developers make by not properly managing resources.

The compiler translates the `foreach` loop shown in the first example into something similar to this construct:

:::code language="csharp" source="./snippets/iterators/Program.cs" ID="InsideForeach":::

The exact code generated by the compiler is more complicated, and handles situations where the object returned by `GetEnumerator()` implements the `IDisposable` interface. The full expansion generates code more like this:

```csharp
{
    var enumerator = collection.GetEnumerator();
    try
    {
        while (enumerator.MoveNext())
        {
            var item = enumerator.Current;
            Console.WriteLine(item.ToString());
        }
    }
    finally
    {
        // dispose of enumerator.
    }
}
```

The compiler translates the first asynchronous sample into something similar to this construct:

```csharp
{
    var enumerator = collection.GetAsyncEnumerator();
    try
    {
        while (await enumerator.MoveNextAsync())
        {
            var item = enumerator.Current;
            Console.WriteLine(item.ToString());
        }
    }
    finally
    {
        // dispose of async enumerator.
    }
}
```

The manner in which the enumerator is disposed of depends on the characteristics of the type of `enumerator`. In the general synchronous case, the `finally` clause expands to:

```csharp
finally
{
   (enumerator as IDisposable)?.Dispose();
}
```

The general asynchronous case expands to:

```csharp
finally
{
    if (enumerator is IAsyncDisposable asyncDisposable)
        await asyncDisposable.DisposeAsync();
}
```

However, if the type of `enumerator` is a sealed type and there's no implicit conversion from the type of `enumerator` to `IDisposable` or `IAsyncDisposable`, the `finally` clause expands to an empty block:

```csharp
finally
{
}
```

If there's an implicit conversion from the type of `enumerator` to `IDisposable`, and `enumerator` is a non-nullable value type, the `finally` clause expands to:

```csharp
finally
{
   ((IDisposable)enumerator).Dispose();
}
```

Thankfully, you don't need to remember all these details. The `foreach` statement handles all those nuances for you. The compiler will generate the correct code for any of these constructs.
