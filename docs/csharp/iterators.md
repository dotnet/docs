---
title: Iterators
description: Learn how to use built-in C# iterators and how to create your own custom iterator methods.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 5cf36f45-f91a-4fca-a0b7-87f233e108e9
---

# Iterators

Almost every program you write will have some need to iterate
over a collection. You'll write code that examines every item in
a collection. 

You'll also create iterator methods which are methods that produces an
iterator for the elements of that class. These can be used for:

+ Performing an action on each item in a collection.
+ Enumerating a custom collection.
+ Extending [LINQ](linq/index.md) or other libraries.
+ Creating a data pipeline where data flows efficiently through iterator
methods.

The C# language provides
features for both these scenarios. This article provides an overview
of those features.

This tutorial has multiple steps. After each step, you can run the application and see the progress. You can also [view or download the completed sample](https://github.com/dotnet/samples/blob/master/csharp/iterators) for this topic. For download instructions, see [Samples and Tutorials](../samples-and-tutorials/index.md#viewing-and-downloading-samples).

## Iterating with foreach

Enumerating a collection is simple: The `foreach` keyword enumerates
a collection, executing the embedded statement once for each element
in the collection:
 
```csharp
foreach (var item in collection)
{
   Console.WriteLine(item.ToString());
}
```

That's all there is to it. To iterate over all the contents of a collection,
the `foreach` statement is all you need. The `foreach` statement isn't magic,
though. It relies on two generic interfaces defined in the .NET core library in order
to generate the code necessary to iterate a collection: `IEnumerable<T>` and
`IEnumerator<T>`. This mechanism is explained in more detail below.

Both of these interfaces also have non-generic counterparts: `IEnumerable` and 
`IEnumerator`. The [generic](programming-guide/generics/index.md) versions are preferred for modern code.

## Enumeration sources with iterator methods

Another great feature of the C# language enables you to build methods that create
a source for an enumeration. These are referred to as *iterator methods*. An iterator
method defines how to generate the objects in a sequence when requested. You
use the `yield return` contextual keywords to define an iterator method. 

You could write this method to produce the sequence of integers from 0 through 9:

```csharp
public IEnumerable<int> GetSingleDigitNumbers()
{
    yield return 0;
    yield return 1;
    yield return 2;
    yield return 3;
    yield return 4;
    yield return 5;
    yield return 6;
    yield return 7;
    yield return 8;
    yield return 9;
}
```

The code above shows distinct `yield return` statements to highlight the fact that
you can use multiple discrete `yield return` statements in an iterator method.
You can (and often do) use other language constructs to simplify the code of an
iterator method. The method definition below produces the exact same sequence
of numbers:

```csharp
public IEnumerable<int> GetSingleDigitNumbers()
{
    int index = 0;
    while (index++ < 10)
        yield return index;
}
```

You don't have to decide one or the other. You can have as many `yield return`
statements as necessary to meet the needs of your method:

```csharp
public IEnumerable<int> GetSingleDigitNumbers()
{
    int index = 0;
    while (index++ < 10)
        yield return index;
        
    yield return 50;
    
    index = 100;
    while (index++ < 110)
        yield return index;
}
```

That's the basic syntax. Let's consider a real world example where you would
write an iterator method. Imagine you're on an IoT project and the device
sensors generate a very large stream of data. To get a feel for the data, you
might write a method that samples every Nth data element. This small iterator
method does the trick:

```csharp
public static IEnumerable<T> Sample(this IEnumerable<T> sourceSequence, int interval)
{
    int index = 0;
    foreach (T item in sourceSequence)
    {
        if (index++ % interval == 0)
            yield return item;
    }
}
```

There is one important restriction on iterator methods: you can't have both a
`return` statement and a `yield return` statement in the same method. The following
will not compile:

```csharp
public IEnumerable<int> GetSingleDigitNumbers()
{
    int index = 0;
    while (index++ < 10)
        yield return index;
        
    yield return 50;
   
    // generates a compile time error: 
    var items = new int[] {100, 101, 102, 103, 104, 105, 106, 107, 108, 109 };
    return items;  
}
```

This restriction normally isn't a problem. You have a choice of either using
`yield return` throughout the method, or separating the original method into
multiple methods, some using `return`, and some using `yield return`.

You can modify the last method slightly to use `yield return` everywhere:

```csharp
public IEnumerable<int> GetSingleDigitNumbers()
{
    int index = 0;
    while (index++ < 10)
        yield return index;
        
    yield return 50;
   
    var items = new int[] {100, 101, 102, 103, 104, 105, 106, 107, 108, 109 };
    foreach (var item in items)
        yield return item;
}
```
 
Sometimes, the right answer is to split an iterator method into two different
methods. One that uses `return`, and a second that uses `yield return`. Consider
a situation where you might want to return an empty collection, or the first 5
odd numbers, based on a boolean argument. You could write that as these two
methods:

```csharp
public IEnumerable<int> GetSingleDigitOddNumbers(bool getCollection)
{
    if (getCollection == false)
        return new int[0];
    else
        return IteratorMethod();
}

private IEnumerable<int> IteratorMethod()
{
    int index = 0;
    while (index++ < 10)
        if (index % 2 == 1)
            yield return index;
}
```
 
Look at the methods above. The first uses the standard `return` statement to return
either an empty collection, or the iterator created by the second method. The second
method uses the `yield return` statement to create the requested sequence.

## Deeper Dive into `foreach`

The `foreach` statement expands into a standard idiom that uses the
`IEnumerable<T>` and `IEnumerator<T>` interfaces to iterate across all
elements of a collection. It also  minimizes errors developers make
by not properly managing resources. 

The compiler translates the `foreach` loop shown in the first
example into something similar to this construct:

```csharp
IEnumerator<int> enumerator = collection.GetEnumerator();
while (enumerator.MoveNext())
{
    var item = enumerator.Current;
    Console.WriteLine(item.ToString());
}
```

The construct above represents the code generated by the C# compiler as of
version 5 and above. Prior to version 5, the `item` variable had a different scope:

```csharp
// C# versions 1 through 4:
IEnumerator<int> enumerator = collection.GetEnumerator();
int item = default(int);
while (enumerator.MoveNext())
{
    item = enumerator.Current;
    Console.WriteLine(item.ToString());
}
```

This was changed because the earlier behavior could lead to subtle and hard
to diagnose bugs involving lambda expressions. See the section on
[lambda expressions](lambda-expressions.md) for more information. 

The exact code generated by the compiler is somewhat more complicated, and
handles situations where the object returned by `GetEnumerator()` implements
the `IDisposable` interface. The full expansion generates code more like this:

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
    } finally 
    {
        // dispose of enumerator.
    }
}
```

The manner in which the enumerator is disposed of depends on the characteristics of
the type of `enumerator`. In the general case, the `finally` clause expands to:

```csharp
finally 
{
   (enumerator as IDisposable)?.Dispose();
} 
```

However, if the type of `enumerator` is a sealed type and there is no implicit
conversion from the type of `enumerator` to `IDisposable`, the `finally` clause
expands to an empty block:
```csharp
finally 
{
} 
```

If there is an implicit conversion from the type of `enumerator` to `IDisposable`,
and `enumerator` is a non-nullable value type, the `finally` clause expands to:

```csharp
finally 
{
   ((IDisposable)enumerator).Dispose();
} 
```

Thankfully, you don't need to remember all these details. The `foreach` statement
handles all those nuances for you. The compiler will generate the correct code for
any of these constructs. 


