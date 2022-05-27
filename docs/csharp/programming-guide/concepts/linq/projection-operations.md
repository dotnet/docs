---
title: "Projection operations (C#)"
description: Learn about projection operations. These operations transform an object into a new form that often consists only of properties that will be used later.
ms.date: 09/10/2021
ms.assetid: 98df573a-aad9-4b8c-9a71-844be2c4fb41
---

# Projection operations (C#)

Projection refers to the operation of transforming an object into a new form that often consists only of those properties that will be subsequently used. By using projection, you can construct a new type that is built from each object. You can project a property and perform a mathematical function on it. You can also project the original object without changing it.

The standard query operator methods that perform projection are listed in the following section.

## Methods

| Method names | Description | C# query expression syntax | More information |
|--|--|--|--|
| Select | Projects values that are based on a transform function. | `select` | <xref:System.Linq.Enumerable.Select%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.Select%2A?displayProperty=nameWithType> |
| SelectMany | Projects sequences of values that are based on a transform function and then flattens them into one sequence. | Use multiple `from` clauses | <xref:System.Linq.Enumerable.SelectMany%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.SelectMany%2A?displayProperty=nameWithType> |
| Zip | Produces a sequence of tuples with elements from 2-3 specified sequences. | Not applicable. | <xref:System.Linq.Enumerable.Zip%2A?displayProperty=nameWithType><br /><xref:System.Linq.Queryable.Zip%2A?displayProperty=nameWithType> |

## `Select`

The following example uses the `select` clause to project the first letter from each string in a list of strings.

```csharp
List<string> words = new() { "an", "apple", "a", "day" };

var query = from word in words
            select word.Substring(0, 1);

foreach (string s in query)
    Console.WriteLine(s);

/* This code produces the following output:

    a
    a
    a
    d
*/
```

## `SelectMany`

The following example uses multiple `from` clauses to project each word from each string in a list of strings.

```csharp
List<string> phrases = new() { "an apple a day", "the quick brown fox" };

var query = from phrase in phrases
            from word in phrase.Split(' ')
            select word;

foreach (string s in query)
    Console.WriteLine(s);

/* This code produces the following output:

    an
    apple
    a
    day
    the
    quick
    brown
    fox
*/
```

## `Zip`

There are several overloads for the `Zip` projection operator. All of the `Zip` methods work on sequences of two or more possibly heterogenous types. The first two overloads return tuples, with the corresponding positional type from the given sequences.

Consider the following collections:

:::code source="snippets/projection/Program.cs" id="NumbersAndLetters":::

To project these sequences together, use the <xref:System.Linq.Enumerable.Zip%60%602(System.Collections.Generic.IEnumerable{%60%600},System.Collections.Generic.IEnumerable{%60%601})?displayProperty=nameWithType> operator:

:::code source="snippets/projection/Program.ZipTuple.cs" id="ZipTuple":::

> [!IMPORTANT]
> The resulting sequence from a zip operation is never longer in length than the shortest sequence. The `numbers` and `letters` collections differ in length, and the resulting sequence omits the last element from the `numbers` collection, as it has nothing to zip with.

The second overload accepts a `third` sequence. Let's create another collection, namely `emoji`:

:::code source="snippets/projection/Program.cs" id="Emoji":::

To project these sequences together, use the <xref:System.Linq.Enumerable.Zip%60%603(System.Collections.Generic.IEnumerable{%60%600},System.Collections.Generic.IEnumerable{%60%601},System.Collections.Generic.IEnumerable{%60%602})?displayProperty=nameWithType> operator:

:::code source="snippets/projection/Program.ZipTriple.cs" id="ZipTriple":::

Much like the previous overload, the `Zip` method projects a tuple, but this time with three elements.

The third overload accepts a `Func<TFirst, TSecond, TResult>` argument that acts as a results selector. Given the two types from the sequences being zipped, you can project a new resulting sequence.

:::code source="snippets/projection/Program.ZipResult.cs" id="ZipResultSelector":::

With the preceding `Zip` overload, the specified function is applied to the corresponding elements `numbers` and `letter`, producing a sequence of the `string` results.

## `Select` versus `SelectMany`

The work of both `Select` and `SelectMany` is to produce a result value (or values) from source values. `Select` produces one result value for every source value. The overall result is therefore a collection that has the same number of elements as the source collection. In contrast, `SelectMany` produces a single overall result that contains concatenated sub-collections from each source value. The transform function that is passed as an argument to `SelectMany` must return an enumerable sequence of values for each source value. These enumerable sequences are then concatenated by `SelectMany` to create one large sequence.

The following two illustrations show the conceptual difference between the actions of these two methods. In each case, assume that the selector (transform) function selects the array of flowers from each source value.

This illustration depicts how `Select` returns a collection that has the same number of elements as the source collection.

![Graphic that shows the action of Select()](./media/projection-operations/select-action-graphic.png)

This illustration depicts how `SelectMany` concatenates the intermediate sequence of arrays into one final result value that contains each value from each intermediate array.

![Graphic showing the action of SelectMany().](./media/projection-operations/select-many-action-graphic.png)

### Code example

The following example compares the behavior of `Select` and `SelectMany`. The code creates a "bouquet" of flowers by taking the first two items from each list of flower names in the source collection. In this example, the "single value" that the transform function <xref:System.Linq.Enumerable.Select%60%602%28System.Collections.Generic.IEnumerable%7B%60%600%7D%2CSystem.Func%7B%60%600%2C%60%601%7D%29> uses is itself a collection of values. This requires the extra `foreach` loop in order to enumerate each string in each sub-sequence.

```csharp
class Bouquet
{
    public List<string> Flowers { get; set; }
}

static void SelectVsSelectMany()
{
    List<Bouquet> bouquets = new()
    {
        new Bouquet { Flowers = new List<string> { "sunflower", "daisy", "daffodil", "larkspur" }},
        new Bouquet { Flowers = new List<string> { "tulip", "rose", "orchid" }},
        new Bouquet { Flowers = new List<string> { "gladiolis", "lily", "snapdragon", "aster", "protea" }},
        new Bouquet { Flowers = new List<string> { "larkspur", "lilac", "iris", "dahlia" }}
    };

    IEnumerable<List<string>> query1 = bouquets.Select(bq => bq.Flowers);

    IEnumerable<string> query2 = bouquets.SelectMany(bq => bq.Flowers);

    Console.WriteLine("Results by using Select():");
    // Note the extra foreach loop here.
    foreach (IEnumerable<String> collection in query1)
        foreach (string item in collection)
            Console.WriteLine(item);

    Console.WriteLine("\nResults by using SelectMany():");
    foreach (string item in query2)
        Console.WriteLine(item);

    /* This code produces the following output:

       Results by using Select():
        sunflower
        daisy
        daffodil
        larkspur
        tulip
        rose
        orchid
        gladiolis
        lily
        snapdragon
        aster
        protea
        larkspur
        lilac
        iris
        dahlia

       Results by using SelectMany():
        sunflower
        daisy
        daffodil
        larkspur
        tulip
        rose
        orchid
        gladiolis
        lily
        snapdragon
        aster
        protea
        larkspur
        lilac
        iris
        dahlia
    */
}
```

## See also

- <xref:System.Linq>
- [Standard Query Operators Overview (C#)](./standard-query-operators-overview.md)
- [select clause](../../../language-reference/keywords/select-clause.md)
- [How to populate object collections from multiple sources (LINQ) (C#)](./how-to-populate-object-collections-from-multiple-sources-linq.md)
- [How to split a file into many files by using groups (LINQ) (C#)](./how-to-split-a-file-into-many-files-by-using-groups-linq.md)
