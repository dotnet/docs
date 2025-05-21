---
title: Intermediate materialization (C#)
description: Learn how the use of some standard query operators can cause materialization of collections in a query, and drastically alter the memory and performance profile of your application.
ms.date: 07/20/2015
ms.assetid: 7922d38f-5044-41cf-8e17-7173d6553a5e
ms.topic: how-to
---

# Intermediate materialization (C#)

If you're not careful you can, in some situations, drastically alter the memory and performance profile of your application by causing premature materialization of collections in your queries. Some standard query operators cause materialization of their source collection before yielding a single element. For example, <xref:System.Linq.Enumerable.OrderBy%2A?displayProperty=nameWithType> first iterates through its entire source collection, then sorts all items, and then finally yields the first item. This means that it's expensive to get the first item of an ordered collection; each item thereafter isn't expensive. This makes sense; it would be impossible for that query operator to do otherwise.

## Example: Add a method that calls `ToList`, causing materialization

This example alters the example in [Chain queries example (C#)](chain-queries-example.md): the `AppendString` method is changed to call <xref:System.Linq.Enumerable.ToList%2A> before iterating through the source, which causes materialization.

```csharp
public static class LocalExtensions
{
    public static IEnumerable<string>
      ConvertCollectionToUpperCase(this IEnumerable<string> source)
    {
        foreach (string str in source)
        {
            Console.WriteLine("ToUpper: source >{0}<", str);
            yield return str.ToUpper();
        }
    }

    public static IEnumerable<string>
      AppendString(this IEnumerable<string> source, string stringToAppend)
    {
        // the following statement materializes the source collection in a List<T>
        // before iterating through it
        foreach (string str in source.ToList())
        {
            Console.WriteLine("AppendString: source >{0}<", str);
            yield return str + stringToAppend;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        string[] stringArray = { "abc", "def", "ghi" };

        IEnumerable<string> q1 =
            from s in stringArray.ConvertCollectionToUpperCase()
            select s;

        IEnumerable<string> q2 =
            from s in q1.AppendString("!!!")
            select s;

        foreach (string str in q2)
        {
            Console.WriteLine("Main: str >{0}<", str);
            Console.WriteLine();
        }
    }
}
```

This example produces the following output:

```output
ToUpper: source >abc<
ToUpper: source >def<
ToUpper: source >ghi<
AppendString: source >ABC<
Main: str >ABC!!!<

AppendString: source >DEF<
Main: str >DEF!!!<

AppendString: source >GHI<
Main: str >GHI!!!<
```

In this example, you can see that the call to <xref:System.Linq.Enumerable.ToList%2A> causes `AppendString` to enumerate its entire source before yielding the first item. If the source were a large array, this would significantly alter the memory profile of the application.

Standard query operators can also be chained together as shown in the final article in this tutorial:

- [Chain standard query operators together (C#)](chain-standard-query-operators-together.md)

## See also

- [Deferred execution and lazy evaluation](deferred-execution-lazy-evaluation.md)
