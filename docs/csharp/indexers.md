---
title: Indexers
description: Learn about C# indexers and how they implement indexed properties, which are properties referenced using one or more arguments.
keywords: .NET, .NET Core
author: BillWagner
ms.author: wiwagn
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: devlang-csharp
ms.devlang: csharp
ms.assetid: 0e9496da-e766-45a9-b92b-91820d4a350e
---

# Indexers

*Indexers* are similar to properties. In many ways indexers build
on the same language features as [properties](properties.md). Indexers
enable *indexed* properties: properties referenced using one or more
arguments. Those arguments provide an index into some collection
of values.

## Indexer Syntax

You access an indexer through a variable name and square brackets . You place the indexer
arguments inside the brackets:

```csharp
var item = someObject["key"];
someObject["AnotherKey"] = item;
```

You declare indexers using the `this` keyword as the property name, and
declaring the arguments within square brackets. This declaration would match
the usage shown in the previous paragraph:

```csharp
public int this[string key]
{
    get { return storage.Find(key); }
    set { storage.SetAt(key, value); }
}
```

From this initial example, you can see the relationship between the syntax
for properties and for indexers. This analogy carries through most of the
syntax rules for indexers. Indexers can have any valid access modifiers
(public, protected internal, protected, internal, private or private protected). They may
be sealed, virtual, or abstract. As with properties, you can specify
different access modifiers for the get and set accesssors in an indexer.
You may also specify read-only indexers (by omitting the set accessor),
or write-only indexers (by omitting the get accessor).

You can apply almost everything you learn from working with properties
to indexers. The only exception to that rule is
*auto implemented properties*. The compiler cannot always
generate the correct storage for an indexer.

The presence of arguments to reference an item in a set of items distinguishes
indexers from properties. You may define multiple indexers on a type, as long
as the argument lists for each indexer is unique. Let's explore different
scenarios where you might use one or more indexers in a class definition. 

## Scenarios

You would define *indexers* in your type when its API models some
collection where you define the arguments to that collection. Your indexers
may or may not map directly to the collection types that are part of the .NET
core framework. Your type
may have other responsibilities in addition to modeling a collection.
Indexers enable you to provide the API that matches your type's abstraction
without exposing the inner details of how the values for that abstraction
are stored or computed.

Let's walk through some of the common scenarios for using *indexers*. You can access the [sample folder for indexers](https://github.com/dotnet/samples/tree/master/csharp/indexers). For download instructions, see [Samples and Tutorials](../samples-and-tutorials/index.md#viewing-and-downloading-samples).

### Arrays and Vectors

One of the most common scenarios for creating indexers is when your
type models an array, or a vector. You can create an indexer to model
an ordered list of data. 

The advantage of creating your own indexer is that you can define
the storage for that collection to suit your needs. Imagine a
scenario where your type models historical data that is too large
to load into memory at once. You need to load and unload sections
of the collection based on usage. The example following models
this behavior. It reports on how many data points exist. It creates
pages to hold sections of the data on demand. It removes pages
from memory to make room for pages needed by more recent requests.

```csharp
public class DataSamples
{
    private class Page
    {
        private readonly List<Measurements> pageData = new List<Measurements>();
        private readonly int startingIndex;
        private readonly int length;
        private bool dirty;
        private DateTime lastAccess;

        public Page(int startingIndex, int length)
        {
            this.startingIndex = startingIndex;
            this.length = length;
            lastAccess = DateTime.Now;

            // This stays as random stuff:
            var generator = new Random();
            for(int i=0; i < length; i++)
            {
                var m = new Measurements
                {
                    HiTemp = generator.Next(50, 95),
                    LoTemp = generator.Next(12, 49),
                    AirPressure = 28.0 + generator.NextDouble() * 4
                };
                pageData.Add(m);
            }
        }
        public bool HasItem(int index) =>
            ((index >= startingIndex) &&
            (index < startingIndex + length));

        public Measurements this[int index]
        {
            get
            {
                lastAccess = DateTime.Now;
                return pageData[index - startingIndex];
            }
            set
            {
                pageData[index - startingIndex] = value;
                dirty = true;
                lastAccess = DateTime.Now;
            }
        }

        public bool Dirty => dirty;
        public DateTime LastAccess => lastAccess;
    }

    private readonly int totalSize;
    private readonly List<Page> pagesInMemory = new List<Page>();

    public DataSamples(int totalSize)
    {
        this.totalSize = totalSize;
    }

    public Measurements this[int index]
    {
        get
        {
            if (index < 0)
                throw new IndexOutOfRangeException("Cannot index less than 0");
            if (index >= totalSize)
                throw new IndexOutOfRangeException("Cannot index past the end of storage");

            var page = updateCachedPagesForAccess(index);
            return page[index];
        }
        set
        {
            if (index < 0)
                throw new IndexOutOfRangeException("Cannot index less than 0");
            if (index >= totalSize)
                throw new IndexOutOfRangeException("Cannot index past the end of storage");
            var page = updateCachedPagesForAccess(index);

            page[index] = value;
        }
    }

    private Page updateCachedPagesForAccess(int index)
    {
        foreach (var p in pagesInMemory)
        {
            if (p.HasItem(index))
            {
                return p;
            }
        }
        var startingIndex = (index / 1000) * 1000;
        var newPage = new Page(startingIndex, 1000);
        addPageToCache(newPage);
        return newPage;
    }

    private void addPageToCache(Page p)
    {
        if (pagesInMemory.Count > 4)
        {
            // remove oldest non-dirty page:
            var oldest = pagesInMemory
                .Where(page => !page.Dirty)
                .OrderBy(page => page.LastAccess)
                .FirstOrDefault();
            // Note that this may keep more than 5 pages in memory
            // if too much is dirty
            if (oldest != null)
                pagesInMemory.Remove(oldest);
        }
        pagesInMemory.Add(p);
    }
}
```

You can follow this design idiom to model any sort of collection where
there are good reasons not to load the entire set of data into an in-
memory collection. Notice that the `Page` class is a private nested
class that is not part of the public interface. Those details are hidden
from any users of this class.

### Dictionaries

Another common scenario is when you need to model a dictionary
or a map. This scenario is when your type stores values based on key,
typically text keys. This example creates a dictionary that maps command
line arguments to [lamdba expressions](delegates-overview.md) that manage
those options. The following example shows two classes: an `ArgsActions`
class that maps a command line option to an `Action` delegate, and an
`ArgsProcessor` that uses the `ArgsActions` to execute each `Action` when
it encounters that option.

```csharp
public class ArgsProcessor
{
    private readonly ArgsActions actions;

    public ArgsProcessor(ArgsActions actions)
    {
        this.actions = actions;
    }

    public void Process(string[] args)
    {
        foreach(var arg in args)
        {
            actions[arg]?.Invoke();
        }
    }

}
public class ArgsActions
{
    readonly private Dictionary<string, Action> argsActions = new Dictionary<string, Action>();

    public Action this[string s]
    {
        get
        {
            Action action;
            Action defaultAction = () => {} ;
            return argsActions.TryGetValue(s, out action) ? action : defaultAction;
        }
    }

    public void SetOption(string s, Action a)
    {
        argsActions[s] = a;
    }
}
```

In this example, the `ArgsAction` collection maps closely to the underlying collection.
The `get` determines if a given option has been configured. If so, it returns
the `Action` associated with that option. If not, it returns an `Action` that 
does nothing. The public accessor does not include a `set` accessor. Rather,
the design using a public method for setting options.

### Multi-Dimensional Maps

You can create indexers that use multiple arguments. In addition,
those arguments are not constrained to be the same type. Let's look at
two examples.   

The first example shows a class that generates values for a Mandelbrot
set. For more information on the mathematics behind the set, read
[this article](https://en.wikipedia.org/wiki/Mandelbrot_set). 
The indexer uses two doubles to define a point in the X, Y plane.
The get accessor computes the number of iterations until a point is
determined to be not in the set. If the maximum iterations is reached, the point
is in the set, and the class's maxIterations value is returned. (The computer
generated images popularized for the Mandelbrot set define colors for the
number of iterations necessary to determine that a point is outside the set.

```csharp
public class Mandelbrot
{
    readonly private int maxIterations;

    public Mandelbrot(int maxIterations)
    {
        this.maxIterations = maxIterations;
    }

    public int this [double x, double y]
    {
        get
        {
            var iterations = 0;
            var x0 = x;
            var y0 = y;

            while ((x*x + y * y < 4) &&
                (iterations < maxIterations))
            {
                var newX = x * x - y * y + x0;
                y = 2 * x * y + y0;
                x = newX;
                iterations++;
            }
            return iterations;
        }
    }
}
```

The Mandelbrot Set defines values at every (x,y) coordinate for real number values.
That defines a dictionary that could contain an infinite number of values. Therefore,
there is no storage behind the set. Instead, this class computes the value for each
point when code calls the `get` accessor. There's no underlying storage used.

Let's examine one last use of indexers, where the indexer takes multiple arguments
of different types. Consider a program that manages historical temperature
data. This indexer uses a city and a date to set or get the high and low 
temperatures for that location:

```csharp
using DateMeasurements = 
    System.Collections.Generic.Dictionary<System.DateTime, IndexersSamples.Common.Measurements>;
using CityDataMeasurements = 
    System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<System.DateTime, IndexersSamples.Common.Measurements>>;

public class HistoricalWeatherData
{
    readonly CityDataMeasurements storage = new CityDataMeasurements();

    public Measurements this[string city, DateTime date]
    {
        get
        {
            var cityData = default(DateMeasurements);

            if (!storage.TryGetValue(city, out cityData))
                throw new ArgumentOutOfRangeException(nameof(city), "City not found");

            // strip out any time portion:
            var index = date.Date;
            var measure = default(Measurements);
            if (cityData.TryGetValue(index, out measure))
                return measure;
            throw new ArgumentOutOfRangeException(nameof(date), "Date not found");
        }
        set
        {
            var cityData = default(DateMeasurements);

            if (!storage.TryGetValue(city, out cityData))
            {
                cityData = new DateMeasurements();
                storage.Add(city, cityData);
            }

            // Strip out any time portion:
            var index = date.Date;
            cityData[index] = value;
        }
    }
}
```

This example creates an indexer that maps weather data on two different
arguments: a city (represented by a `string`) and a date (represented by
a `DateTime`). The internal storage uses two `Dictionary` classes to represent
the two-dimensional dictionary. The public API no longer represents the
underlying storage. Rather, the language features of indexers enables you
to create a public interface that represents your abstraction, even though
the underlying storage must use different core collection types.

There are two parts of this code that may be unfamiliar
to some developers. These two `using` statements:

```csharp
using DateMeasurements = System.Collections.Generic.Dictionary<System.DateTime, IndexersSamples.Common.Measurements>;
using CityDataMeasurements = System.Collections.Generic.Dictionary<string, System.Collections.Generic.Dictionary<System.DateTime, IndexersSamples.Common.Measurements>>;
```

create an *alias* for a constructed generic type. Those statements enable the
code later to use the more descriptive `DateMeasurements` and `CityDateMeasurements`
names instead of the generic construction of `Dictionary<DateTime, Measurements>`
and `Dictionary<string, Dictionary<DateTime, Measurements> >`. 
This construct does require using the fully qualified type names on the right
side of the `=` sign.

The second technique is to strip off the time portions of any `DateTime` object
used to index into the collections. The .NET framework does not include a Date only type.
Developers use the `DateTime` type, but use the `Date` property to ensure that any
`DateTime` object from that day are equal.

## Summing Up

You should create indexers anytime you have a property-like element in your
class where that property represents not a single value, but rather a collection
of values where each individual item is identified by a set of arguments. Those
arguments can uniquely identify which item in the collection should be referenced.
Indexers extend the concept of [properties](properties.md), where a member is treated
like a data item from outside the class, but like a method on the side. Indexers allow
arguments to find a single item in a property that represents a set of items.
