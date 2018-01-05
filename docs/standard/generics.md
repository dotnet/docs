---
title: Generic Types (Generics) Overview
description: Learn how generics act as code templates that allow you to define type-safe data structures without committing to an actual data type.
keywords: .NET, .NET Core
author: kuhlenh
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: a315b111-8e48-446c-ab19-acb6405894a7
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---

# Generic Types (Generics) Overview

We use generics all the time in C#, whether implicitly or explicitly. When you use LINQ in C#, did you ever notice that you are working with IEnumerable<T>? Or if you ever saw an online sample of a "generic repository" for talking to databases using Entity Framework, did you see that most methods return IQueryable<T>? You may have wondered what the **T** is in these examples and why is it in there?

First introduced to the .NET Framework 2.0, generics involved changes to both the C# language and the Common Language Runtime (CLR). **Generics** are essentially a "code template" that allows developers to define [type-safe](https://msdn.microsoft.com/library/hbzz1a9a.aspx) data structures without committing to an actual data type. For example, `List<T>` is a [Generic Collection](xref:System.Collections.Generic) that can be declared and used with any type: `List<int>`, `List<string>`, `List<Person>`, etc.

So, what’s the point? Why are generics useful? In order to understand this, we need to take a look at a specific class before and after adding generics. Let’s look at the `ArrayList`. In C# 1.0, the `ArrayList` elements were of type `object`. This meant that any element that was added was silently converted into an `object`; same thing happens on reading the elements from the list (this process is known as [boxing](../../docs/csharp/programming-guide/types/boxing-and-unboxing.md) and unboxing respectively). Boxing and unboxing have an impact of performance. More than that, however, there is no way to tell at compile time what is the actual type of the data in the list. This makes for some fragile code. Generics solve this problem by providing additional information the type of data each instance of list will contain. Put simply, you can only add integers to `List<int>` and only add Persons to `List<Person>`, etc.

Generics are also available at runtime, or **reified**. This means the runtime knows what type of data structure you are using and can store it in memory more efficiently.

Here is a small program that illustrates the efficiency of knowing the data structure type at runtime:

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

This program yields the following output:

```console
Generic Sort: System.Collections.Generic.List\`1[System.Int32] Time taken: 0.0789ms
Non-Generic Sort: System.Collections.ArrayList Time taken: 2.4324ms
```

The first thing you notice here is that sorting the generic list is significantly faster than for the non-generic list. You might also notice that the type for the generic list is distinct ([System.Int32]) whereas the type for the non-generic list is generalized. Because the runtime knows the generic `List<int>` is of type int, it can store the list elements in an underlying integer array in memory while the non-generic `ArrayList` has to cast each list element as an object as stored in an object array in memory. As shown through this example, the extra castings take up time and slow down the list sort.

The last useful thing about the runtime knowing the type of your generic is a better debugging experience. When you are debugging a generic in C#, you know what type each element is in your data structure. Without generics, you would have no idea what type each element was.

## Further reading and resources

*   [An Introduction to C# Generics](https://msdn.microsoft.com/library/ms379564.aspx)
*   [C# Programming Guide - Generics](../../docs/csharp/programming-guide/generics/index.md)
