---
title: Generic types (generics) overview
description: Learn how generics act as code templates that allow you to define type-safe data structures without committing to an actual data type.
author: kuhlenh
ms.author: wiwagn
ms.date: 10/09/2018
---
# Generic types overview

Developers use generics all the time in .NET, whether implicitly or explicitly. When you use LINQ in .NET, did you ever notice that you're working with <xref:System.Collections.Generic.IEnumerable%601>? Or if you ever saw an online sample of a "generic repository" for talking to databases using Entity Framework, did you see that most methods return IQueryable<T>? You may have wondered what the **T** is in these examples and why it's in there.

First introduced in the .NET Framework 2.0, **generics** are essentially a "code template" that allows developers to define [type-safe](https://docs.microsoft.com/previous-versions/dotnet/netframework-4.0/hbzz1a9a(v=vs.100)) data structures without committing to an actual data type. For example, <xref:System.Collections.Generic.List%601> is a [generic collection](xref:System.Collections.Generic) that can be declared and used with any type, such as `List<int>`, `List<string>`, or `List<Person>`.

To understand why generics are useful, let's take a look at a specific class before and after adding generics: <xref:System.Collections.ArrayList>. In .NET Framework 1.0, the `ArrayList` elements were of type <xref:System.Object>. This meant that any element added was silently converted into an `Object`. The same would happen when reading the elements from the list. This process is known as [boxing and unboxing](../csharp/programming-guide/types/boxing-and-unboxing.md), and it impacts performance. More than that, however, there's no way to determine the type of data in the list at compile time. This makes for some fragile code. Generics solve this problem by defining the type of data each instance of list will contain. For example, you can only add integers to `List<int>` and only add Persons to `List<Person>`.

Generics are also available at runtime. This means the runtime knows what type of data structure you're using and can store it in memory more efficiently.

The following example is a small program that illustrates the efficiency of knowing the data structure type at runtime:

```csharp
  using System;
  using System.Collections;
  using System.Collections.Generic;
  using System.Diagnostics;

  namespace GenericsExample {
    class Program {
      static void Main(string[] args) {
        //generic list
        List<int> ListGeneric = new List<int> { 5, 9, 1, 4 };
        //non-generic list
        ArrayList ListNonGeneric = new ArrayList { 5, 9, 1, 4 };
        // timer for generic list sort
        Stopwatch s = Stopwatch.StartNew();
        ListGeneric.Sort();
        s.Stop();
        Console.WriteLine($"Generic Sort: {ListGeneric}  \n Time taken: {s.Elapsed.TotalMilliseconds}ms");

        //timer for non-generic list sort
        Stopwatch s2 = Stopwatch.StartNew();
        ListNonGeneric.Sort();
        s2.Stop();
        Console.WriteLine($"Non-Generic Sort: {ListNonGeneric}  \n Time taken: {s2.Elapsed.TotalMilliseconds}ms");
        Console.ReadLine();
      }
    }
  }
```

This program produces output similar to the following:

```console
Generic Sort: System.Collections.Generic.List`1[System.Int32]
 Time taken: 0.0034ms
Non-Generic Sort: System.Collections.ArrayList
 Time taken: 0.2592ms
```

The first thing you can notice here is that sorting the generic list is significantly faster than sorting the non-generic list. You might also notice that the type for the generic list is distinct ([System.Int32]), whereas the type for the non-generic list is generalized. Because the runtime knows the generic `List<int>` is of type <xref:System.Int32>, it can store the list elements in an underlying integer array in memory while the non-generic `ArrayList` has to cast each list element to an object. As this example shows, the extra casts take up time and slow down the list sort.

An additional advantage of the runtime knowing the type of your generic is a better debugging experience. When you're debugging a generic in C#, you know what type each element is in your data structure. Without generics, you would have no idea what type each element was.

## See also

- [An Introduction to C# Generics](https://msdn.microsoft.com/library/ms379564.aspx)
- [C# Programming Guide - Generics](../../docs/csharp/programming-guide/generics/index.md)
