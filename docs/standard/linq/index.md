---
title: LINQ overview - .NET
description: Language-Integrated Query (LINQ) provides language-level querying capabilities, and a higher-order function API to C# and Visual Basic, that enable you to write expressive declarative code.
author: cartermp
ms.author: wiwagn
ms.date: 06/20/2016
dev_langs:
  - "csharp"
  - "vb"
---

# LINQ overview

Language-Integrated Query (LINQ) provides language-level querying capabilities, and a [higher-order function](https://en.wikipedia.org/wiki/Higher-order_function) API to C# and Visual Basic, that enable you to write expressive declarative code.

## Language-level query syntax

This is the language-level query syntax:

```csharp
var linqExperts = from p in programmers
                  where p.IsNewToLINQ
                  select new LINQExpert(p);
```

```vb
Dim linqExperts = From p in programmers
                  Where p.IsNewToLINQ
                  Select New LINQExpert(p)
```

This is the same example using the `IEnumerable<T>` API:

```csharp
var linqExperts = programmers.Where(p => p.IsNewToLINQ)
                             .Select(p => new LINQExpert(p));
```

```vb
Dim linqExperts = programmers.Where(Function(p) p.IsNewToLINQ).
                             Select(Function(p) New LINQExpert(p))
```

## LINQ is expressive

Imagine you have a list of pets, but want to convert it into a dictionary where you can access a pet directly by its `RFID` value.

This is traditional imperative code:

```csharp
var petLookup = new Dictionary<int, Pet>();

foreach (var pet in pets)
{
    petLookup.Add(pet.RFID, pet);
}
```

```vb
Dim petLookup = New Dictionary(Of Integer, Pet)()

For Each pet in pets
    petLookup.Add(pet.RFID, pet)
Next
```

The intention behind the code isn't to create a new `Dictionary<int, Pet>` and add to it via a loop, it's to convert an existing list into a dictionary! LINQ preserves the intention whereas the imperative code doesn't.

This is the equivalent LINQ expression:

```csharp
var petLookup = pets.ToDictionary(pet => pet.RFID);
```

```vb
Dim petLookup = pets.ToDictionary(Function(pet) pet.RFID)
```

The code using LINQ is valuable because it evens the playing field between intent and code when reasoning as a programmer. Another bonus is code brevity. Imagine reducing large portions of a codebase by 1/3 as done above. Sweet deal, right?

## LINQ providers simplify data access

For a significant chunk of software out in the wild, everything revolves around dealing with data from some source (Databases, JSON, XML, and so on). Often this involves learning a new API for each data source, which can be annoying. LINQ simplifies this by abstracting common elements of data access into a query syntax that looks the same no matter which data source you pick.

This finds all XML elements with a specific attribute value:

```csharp
public static IEnumerable<XElement> FindAllElementsWithAttribute(XElement documentRoot, string elementName,
                                           string attributeName, string value)
{
    return from el in documentRoot.Elements(elementName)
           where (string)el.Element(attributeName) == value
           select el;
}
```

```vb
Public Shared Function FindAllElementsWithAttribute(documentRoot As XElement, elementName As String,
                                           attributeName As String, value As String) As IEnumerable(Of XElement)
    Return From el In documentRoot.Elements(elementName)
           Where el.Element(attributeName).ToString() = value
           Select el
End Function
```

Writing code to manually traverse the XML document to do this task would be far more challenging.

Interacting with XML isn't the only thing you can do with LINQ Providers. [Linq to SQL](../../framework/data/adonet/sql/linq/index.md) is a fairly bare-bones Object-Relational Mapper (ORM) for an MSSQL Server Database. The [JSON.NET](https://www.newtonsoft.com/json/help/html/LINQtoJSON.htm) library provides efficient JSON Document traversal via LINQ. Furthermore, if there isn't a library that does what you need, you can also [write your own LINQ Provider](/previous-versions/visualstudio/visual-studio-2012/bb546158(v=vs.110))!

## Reasons to use the query syntax

Why use query syntax? This is a question that often comes up. After all, the following code:

```csharp
var filteredItems = myItems.Where(item => item.Foo);
```

```vb
Dim filteredItems = myItems.Where(Function(item) item.Foo)
```

is a lot more concise than this:

```csharp
var filteredItems = from item in myItems
                    where item.Foo
                    select item;
```

```vb
Dim filteredItems = From item In myItems
                    Where item.Foo
                    Select item
```

Isn't the API syntax just a more concise way to do the query syntax?

No. The query syntax allows for the use of the **let** clause, which allows you to introduce and bind a variable within the scope of the expression, using it in subsequent pieces of the expression. Reproducing the same code with only the API syntax can be done, but will most likely lead to code that's hard to read.

So this begs the question, **should you just use the query syntax?**

The answer to this question is **yes** if:

- Your existing codebase already uses the query syntax.
- You need to scope variables within your queries because of complexity.
- You prefer the query syntax and it won't distract from your codebase.

The answer to this question is **no** if...

- Your existing codebase already uses the API syntax
- You have no need to scope variables within your queries
- You prefer the API syntax and it won't distract from your codebase

## Essential LINQ

For a truly comprehensive list of LINQ samples, visit [101 LINQ Samples](/samples/dotnet/try-samples/101-linq-samples/).

The following examples are a quick demonstration of some of the essential pieces of LINQ. This is in no way comprehensive, as LINQ provides more functionality than what is showcased here.

### The bread and butter - `Where`, `Select`, and `Aggregate`

```csharp
// Filtering a list.
var germanShepherds = dogs.Where(dog => dog.Breed == DogBreed.GermanShepherd);

// Using the query syntax.
var queryGermanShepherds = from dog in dogs
                          where dog.Breed == DogBreed.GermanShepherd
                          select dog;

// Mapping a list from type A to type B.
var cats = dogs.Select(dog => dog.TurnIntoACat());

// Using the query syntax.
var queryCats = from dog in dogs
                select dog.TurnIntoACat();

// Summing the lengths of a set of strings.
int seed = 0;
int sumOfStrings = strings.Aggregate(seed, (s1, s2) => s1.Length + s2.Length);
```

```vb
' Filtering a list.
Dim germanShepherds = dogs.Where(Function(dog) dog.Breed = DogBreed.GermanShepherd)

' Using the query syntax.
Dim queryGermanShepherds = From dog In dogs
                          Where dog.Breed = DogBreed.GermanShepherd
                          Select dog

' Mapping a list from type A to type B.
Dim cats = dogs.Select(Function(dog) dog.TurnIntoACat())

' Using the query syntax.
Dim queryCats = From dog In dogs
                Select dog.TurnIntoACat()

' Summing the lengths of a set of strings.
Dim seed As Integer = 0
Dim sumOfStrings As Integer = strings.Aggregate(seed, Function(s1, s2) s1.Length + s2.Length)
```

### Flattening a list of lists

```csharp
// Transforms the list of kennels into a list of all their dogs.
var allDogsFromKennels = kennels.SelectMany(kennel => kennel.Dogs);
```

```vb
' Transforms the list of kennels into a list of all their dogs.
Dim allDogsFromKennels = kennels.SelectMany(Function(kennel) kennel.Dogs)
```

### Union between two sets (with custom comparator)

```csharp
public class DogHairLengthComparer : IEqualityComparer<Dog>
{
    public bool Equals(Dog a, Dog b)
    {
        if (a == null && b == null)
        {
            return true;
        }
        else if ((a == null && b != null) ||
                 (a != null && b == null))
        {
            return false;
        }
        else
        {
            return a.HairLengthType == b.HairLengthType;
        }
    }

    public int GetHashCode(Dog d)
    {
        // Default hashcode is enough here, as these are simple objects.
        return d.GetHashCode();
    }
}
...

// Gets all the short-haired dogs between two different kennels.
var allShortHairedDogs = kennel1.Dogs.Union(kennel2.Dogs, new DogHairLengthComparer());

```

```vb
Public Class DogHairLengthComparer
  Inherits IEqualityComparer(Of Dog)

  Public Function Equals(a As Dog,b As Dog) As Boolean
      If a Is Nothing AndAlso b Is Nothing Then
          Return True
      ElseIf (a Is Nothing AndAlso b IsNot Nothing) OrElse (a IsNot Nothing AndAlso b Is Nothing) Then
          Return False
      Else
          Return a.HairLengthType = b.HairLengthType
      End If
  End Function

  Public Function GetHashCode(d As Dog) As Integer
      ' Default hashcode is enough here, as these are simple objects.
      Return d.GetHashCode()
  End Function
End Class

...

' Gets all the short-haired dogs between two different kennels.
Dim allShortHairedDogs = kennel1.Dogs.Union(kennel2.Dogs, New DogHairLengthComparer())
```

### Intersection between two sets

```csharp
// Gets the volunteers who spend share time with two humane societies.
var volunteers = humaneSociety1.Volunteers.Intersect(humaneSociety2.Volunteers,
                                                     new VolunteerTimeComparer());
```

```vb
' Gets the volunteers who spend share time with two humane societies.
Dim volunteers = humaneSociety1.Volunteers.Intersect(humaneSociety2.Volunteers,
                                                     New VolunteerTimeComparer())
```

### Ordering

```csharp
// Get driving directions, ordering by if it's toll-free before estimated driving time.
var results = DirectionsProcessor.GetDirections(start, end)
              .OrderBy(direction => direction.HasNoTolls)
              .ThenBy(direction => direction.EstimatedTime);
```

```vb
' Get driving directions, ordering by if it's toll-free before estimated driving time.
Dim results = DirectionsProcessor.GetDirections(start, end).
                OrderBy(Function(direction) direction.HasNoTolls).
                ThenBy(Function(direction) direction.EstimatedTime)
```

### Equality of instance properties

Finally, a more advanced sample: determining if the values of the properties of two instances of the same type are equal (Borrowed and modified from [this StackOverflow post](https://stackoverflow.com/a/844855)):

```csharp
public static bool PublicInstancePropertiesEqual<T>(this T self, T to, params string[] ignore) where T : class
{
    if (self == null || to == null)
    {
        return self == to;
    }

    // Selects the properties which have unequal values into a sequence of those properties.
    var unequalProperties = from property in typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                            where !ignore.Contains(property.Name)
                            let selfValue = property.GetValue(self, null)
                            let toValue = property.GetValue(to, null)
                            where !Equals(selfValue, toValue)
                            select property;
    return !unequalProperties.Any();
}
```

```vb
<System.Runtime.CompilerServices.Extension()>
Public Function PublicInstancePropertiesEqual(Of T As Class)(self As T, [to] As T, ParamArray ignore As String()) As Boolean
    If self Is Nothing OrElse [to] Is Nothing Then
        Return self Is [to]
    End If

    ' Selects the properties which have unequal values into a sequence of those properties.
    Dim unequalProperties = From [property] In GetType(T).GetProperties(BindingFlags.Public Or BindingFlags.Instance)
                            Where Not ignore.Contains([property].Name)
                            Let selfValue = [property].GetValue(self, Nothing)
                            Let toValue = [property].GetValue([to], Nothing)
                            Where Not Equals(selfValue, toValue) Select [property]
    Return Not unequalProperties.Any()
End Function
```

## PLINQ

PLINQ, or Parallel LINQ, is a parallel execution engine for LINQ expressions. In other words, a regular LINQ expression can be trivially parallelized across any number of threads. This is accomplished via a call to `AsParallel()` preceding the expression.

Consider the following:

```csharp
public static string GetAllFacebookUserLikesMessage(IEnumerable<FacebookUser> facebookUsers)
{
    var seed = default(UInt64);

    Func<UInt64, UInt64, UInt64> threadAccumulator = (t1, t2) => t1 + t2;
    Func<UInt64, UInt64, UInt64> threadResultAccumulator = (t1, t2) => t1 + t2;
    Func<Uint64, string> resultSelector = total => $"Facebook has {total} likes!";

    return facebookUsers.AsParallel()
                        .Aggregate(seed, threadAccumulator, threadResultAccumulator, resultSelector);
}
```

```vb
Public Shared GetAllFacebookUserLikesMessage(facebookUsers As IEnumerable(Of FacebookUser)) As String
{
    Dim seed As UInt64 = 0

    Dim threadAccumulator As Func(Of UInt64, UInt64, UInt64) = Function(t1, t2) t1 + t2
    Dim threadResultAccumulator As Func(Of UInt64, UInt64, UInt64) = Function(t1, t2) t1 + t2
    Dim resultSelector As Func(Of Uint64, string) = Function(total) $"Facebook has {total} likes!"

    Return facebookUsers.AsParallel().
                        Aggregate(seed, threadAccumulator, threadResultAccumulator, resultSelector)
}
```

This code will partition `facebookUsers` across system threads as necessary, sum up the total likes on each thread in parallel, sum the results computed by each thread, and project that result into a nice string.

In diagram form:

![PLINQ diagram](media/index/plinq-diagram.png)

Parallelizable CPU-bound jobs that can be easily expressed via LINQ (in other words, are pure functions and have no side effects) are a great candidate for PLINQ. For jobs that _do_ have a side effect, consider using the [Task Parallel Library](../parallel-programming/task-parallel-library-tpl.md).

## More resources

* [101 LINQ Samples](/samples/dotnet/try-samples/101-linq-samples/)
* [Linqpad](https://www.linqpad.net/), a playground environment and Database querying engine for C#/F#/Visual Basic
* [EduLinq](https://codeblog.jonskeet.uk/2011/02/23/reimplementing-linq-to-objects-part-45-conclusion-and-list-of-posts/), an e-book for learning how LINQ-to-objects is implemented
