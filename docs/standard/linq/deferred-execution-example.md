---
title: Deferred execution example - LINQ to XML
description: Learn how deferred execution and lazy evaluation affect the execution of your LINQ to XML queries.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 50f4fbac-81fe-4f26-aedf-506e21419b19
ms.topic: article
---

# Deferred execution example (LINQ to XML)

This article shows how deferred execution and lazy evaluation affect the execution of your LINQ to XML queries.

## Example: Use the `yield return` construct in an extension method to defer execution

The following example shows the order of execution when using an extension method that uses deferred execution. The example declares an array of three strings. It then iterates through the collection returned by `ConvertCollectionToUpperCase`.

```csharp
public static class LocalExtensions
{
    public static IEnumerable<string>
      ConvertCollectionToUpperCase(this IEnumerable<string> source)
    {
        foreach (string str in source)
        {
            Console.WriteLine("ToUpper: source {0}", str);
            yield return str.ToUpper();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string[] stringArray = { "abc", "def", "ghi" };

        var q = from str in stringArray.ConvertCollectionToUpperCase()
                select str;

        foreach (string str in q)
            Console.WriteLine("Main: str {0}", str);
    }
}
```

```vb
Imports System.Runtime.CompilerServices

Module Module1

    <Extension()>
    Private Iterator Function ConvertCollectionToUpperCase(
    ByVal source As IEnumerable(Of String)) _
    As IEnumerable(Of String)
        For Each str As String In source
            Console.WriteLine("ToUpper: source {0}", str)
            Yield str.ToUpper()
        Next
    End Function

    Sub Main()
        Dim stringArray = New String() {"abc", "def", "ghi"}

        Dim q = From str In stringArray.ConvertCollectionToUpperCase()
                Select str

        For Each Str As String In q
            Console.WriteLine("Main: str {0}", Str)
        Next
    End Sub

End Module
```

This example produces the following output:

```output
ToUpper: source abc
Main: str ABC
ToUpper: source def
Main: str DEF
ToUpper: source ghi
Main: str GHI
```

Notice that when iterating through the collection returned by `ConvertCollectionToUpperCase`, each item is retrieved from the source string array and converted to uppercase before the next item is retrieved from the source string array.

You can see that the entire array of strings isn't converted to uppercase before each item in the returned collection is processed in the `foreach` loop in `Main`.

## See also

- [Deferred execution and lazy evaluation](deferred-execution-lazy-evaluation.md)
- [Tutorial: Chain queries together (C#)](chain-queries-example.md)
