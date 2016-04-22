# Indexers

Author: [Bill Wagner](https://github.com/BillWagner)

*Indexers* are similar to properties. In many ways they indexers build
on the same language features as  [properties](properties.md). Indexers
enable *indexed* properties: properties that include one or more
arguments. Those arguments provide an index into some collection
of values.

# Indexer Syntax

You access an indexer using square brackets. You place the indexer
arguments inside the brackets:

```cs
var item = someObject["key"];
someObject["AnotherKey"] = item;
```

You declare indexers using the `this` keyword as the property name, and
placing the arguments within square brackets. This declaration would match
the usage shown in the previous paragraph:

```cs
public int this[string key]
{
    get { return storage.Find(key); }
    set { storage.SetAt(key, value); }
}
```

From this initial example, you can see the relationship between the syntax
for properties and for indexers. This analogy carries through most of the
syntax rules for indexers. Indexers can have any valid access modifiers
(public, protected internal, protected, internal, or private). They may
be sealed, virtual, or abstract. As with properties, you can specify
different access modifiers for the get and set accesssors in an indexer.
You may also specify read-only indexers (by omitting the set accessor),
or write-only indexers (by omitting the get accessor).

The one feature supported by properties that is not supported by indexers
is *auto implemented properties*. That's because the compiler cannot always
generate the correct storage for an indexer.

Indexers extend properties by enabling one or more arguments. The first
example used a single string as the argument. You can define multiple
indexers in a single class. However, different indexers must be
distinguished by their arguments. For example, you can have one
indexer that has a single integer argument, and another that has a single
string. You cannot create multiple indexers that each take a single
integer. Let's explore different scenarios where you might use one
or more indexers in a class definition. 

# Scenarios

You would define *indexers* in your class when that type models a
collection where you define the arguments to that collection. Your type
may have other responsibilities as well, which is why you created a
type rather than using one of the built-in collections.

## Arrays and Vectors

One of the most common scenarios for creating indexers is when your
type models an array, or a vector. Anytime your type models an ordered
list of data, you can create an indexer to model that. 

The advantage of creating your own indexer is that you can define
the storage for that collection to suit your needs. Imagine a
scenario where your type models historical data that is too large
to load into memory at once. This implementation models that. It reports
on how many data points exist, and retrieves pages of them when needed
from an indexer. Those pages are removed from memory when room is needed
for more recent requests.

<< sample >>

You can follow this design idiom to model any sort of collection where
there are good reasons not to load the entire set of data into an in-
memory collection.

## Dictionaries

The second most common scenario is when you need to model a dictionary
or a map. This scenario is when your type stores values based on key,
typically text keys. This example creates a dictionary that maps command
line arguments to [lamdba expressions](delegates-overview.md) that manage
those options. You can create a dictionary that can easily manage how
a command line is processed.

<< Example >>

<< Probably more text too >>

Notice again that the indexer need not map directly to a storage
collection. One of the major benefits of writing an indexer is to
create that abstraction.

## Multi-Dimensional Maps

You can create indexers that use multiple arguments. In addition,
those arguments are not limited by type.  

This class generates values for a Mandelbrot set. For more information
on the mathematics behind the set, read
[this article](https://en.wikipedia.org/wiki/Mandelbrot_set). Notice
that the indexer uses two doubles to define a point in the X, Y plane.
The get accessor computes the number of iterations until a point is
clearly not in the set. If the maximum iterations is reached, the point
is in the set, and MAX_INT is returned.

<< Example >>

As another example, consider a program that manages historical temperature
data. This indexer uses a city and a date to set or get the high and low 
temperatures for that location:

<< Exmaple >>

You are not limited by the types or number of the arguments. The only restriction
is that any indexer must have a unique set of arguments.

# Summing Up

You should create indexers anytime you have have a property-like element in your
class where that property represents not a single value, but rather a collection
of values where each individual item is identified by a set of arguments. Those
arguments can uniquely identify which item in the collection shoudl be referenced.
Indexers extend the concept of [properties](properties.md), where a member is treated
like a data item from outside the class, but like a method on the side. Indexers allow
arguments to find a single item in a property that represents a set of items.
