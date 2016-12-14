---
title: Comparisons and Sorts Within Collections
description: Comparisons and Sorts Within Collections
keywords: .NET, .NET Core
author: mairaw
ms.author: mairaw
ms.date: 06/20/2016
ms.topic: article
ms.prod: .net
ms.technology: dotnet-standard
ms.devlang: dotnet
ms.assetid: c7b7c005-628d-427a-91ad-af0c3958c00e
---

# Comparisons and Sorts Within Collections

The [System.Collections](https://docs.microsoft.com/dotnet/core/api/System.Collections) classes perform comparisons in almost all the processes involved in managing collections, whether searching for the element to remove or returning the value of a key-and-value pair.

Collections typically utilize an equality comparer and/or an ordering comparer. Two constructs are used for comparisons. 

## Checking for equality

Methods such as `Contains`, `IndexOf`, `LastIndexOf`, and `Remove` use an equality comparer for the collection elements. If the collection is generic, items are compared for equality according to the following guidelines:

*   If type T implements the [IEquatable&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.IEquatable-1) generic interface, then the equality comparer is the `Equals` method of that interface.

*   If type T does not implement `IEquatable<T>`, `Object.Equals` is used.

In addition, some constructor overloads for dictionary collections accept an [IEqualityComparer&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IEqualityComparer-1) implementation, which is used to compare keys for equality.

## Determining sort order

Methods such as `BinarySearch` and `Sort` use an ordering comparer for the collection elements. The comparisons can be between elements of the collection, or between an element and a specified value. For comparing objects, there is the concept of a default comparer and an explicit comparer. 

The default comparer relies on at least one of the objects being compared to implement the `IComparable` interface. It is a good practice to implement `IComparable` on all classes are used as values in a list collection or as keys in a dictionary collection. For a generic collection, equality comparison is determined according to the following:

*   If type T implements the [System.IComparable&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.IComparable-1) generic interface, then the default comparer is the `CompareTo(T)` method of that interface.

*   If type T implements the non-generic [System.IComparable](https://docs.microsoft.com/dotnet/core/api/System.IComparable) interface, then the default comparer is the `CompareTo`(Object) method of that interface.

*   If type T doesn’t implement either interface, then there is no default comparer, and a comparer or comparison delegate must be provided explicitly.

To provide explicit comparisons, some methods accept an `IComparer` implementation as a parameter. For example, the `List<T>.Sort` method accepts an [System.Collections.Generic.IComparer&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IComparer-1) implementation. 

## Equality and sort example

The following code demonstrates an implementation of [IEquatable&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.IEquatable-1) and [IComparable&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.IComparable-1) on a simple business object. In addition, when the object is stored in a list and sorted, you will see that calling the `Sort()` method results in the use of the default comparer for the 'Part' type, and the `Sort(Comparison<T>)` method implemented by using an anonymous method.

C#

```csharp
using System;
using System.Collections.Generic;
// Simple business object. A PartId is used to identify the type of part 
// but the part name can change. 
public class Part : IEquatable<Part> , IComparable<Part>
{
    public string PartName { get; set; }

    public int PartId { get; set; }

    public override string ToString()
    {
        return "ID: " + PartId + "   Name: " + PartName;
    }
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        Part objAsPart = obj as Part;
        if (objAsPart == null) return false;
        else return Equals(objAsPart);
    }
    public int SortByNameAscending(string name1, string name2)
    {

        return name1.CompareTo(name2);
    }

    // Default comparer for Part type.
    public int CompareTo(Part comparePart)
    {
          // A null value means that this object is greater.
        if (comparePart == null)
            return 1;

        else
            return this.PartId.CompareTo(comparePart.PartId);
    }
    public override int GetHashCode()
    {
        return PartId;
    }
    public bool Equals(Part other)
    {
        if (other == null) return false;
        return (this.PartId.Equals(other.PartId));
    }
    // Should also override == and != operators.

}
public class Example
{
    public static void Main()
    {
        // Create a list of parts.
        List<Part> parts = new List<Part>();

        // Add parts to the list.
        parts.Add(new Part() { PartName = "regular seat", PartId = 1434 });
        parts.Add(new Part() { PartName= "crank arm", PartId = 1234 });
        parts.Add(new Part() { PartName = "shift lever", PartId = 1634 }); ;
        // Name intentionally left null.
        parts.Add(new Part() {  PartId = 1334 });
        parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
        parts.Add(new Part() { PartName = "cassette", PartId = 1534 });


        // Write out the parts in the list. This will call the overridden 
        // ToString method in the Part class.
        Console.WriteLine("\nBefore sort:");
        foreach (Part aPart in parts)
        {
            Console.WriteLine(aPart);
        }


        // Call Sort on the list. This will use the 
        // default comparer, which is the Compare method 
        // implemented on Part.
        parts.Sort();


        Console.WriteLine("\nAfter sort by part number:");
        foreach (Part aPart in parts)
        {
            Console.WriteLine(aPart);
        }

        // This shows calling the Sort(Comparison(T) overload using 
        // an anonymous method for the Comparison delegate. 
        // This method treats null as the lesser of two values.
        parts.Sort(delegate(Part x, Part y)
        {
            if (x.PartName == null && y.PartName == null) return 0;
            else if (x.PartName == null) return -1;
            else if (y.PartName == null) return 1;
            else return x.PartName.CompareTo(y.PartName);
        });

        Console.WriteLine("\nAfter sort by name:");
        foreach (Part aPart in parts)
        {
            Console.WriteLine(aPart);
        }

        /*

            Before sort:
		ID: 1434   Name: regular seat
		ID: 1234   Name: crank arm
		ID: 1634   Name: shift lever
		ID: 1334   Name:
		ID: 1444   Name: banana seat
		ID: 1534   Name: cassette

	    After sort by part number:
		ID: 1234   Name: crank arm
		ID: 1334   Name:
		ID: 1434   Name: regular seat
		ID: 1444   Name: banana seat
		ID: 1534   Name: cassette
		ID: 1634   Name: shift lever

	    After sort by name:
		ID: 1334   Name:
		ID: 1444   Name: banana seat
		ID: 1534   Name: cassette
		ID: 1234   Name: crank arm
		ID: 1434   Name: regular seat
		ID: 1634   Name: shift lever

         */

    }
}
```

## See Also

[IComparer](https://docs.microsoft.com/dotnet/core/api/System.Collections.IComparer)

[IEquatable&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.IEquatable-1)

[IComparer&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.Collections.Generic.IComparer-1)

[IComparable](https://docs.microsoft.com/dotnet/core/api/System.IComparable)

[IComparable&lt;T&gt;](https://docs.microsoft.com/dotnet/core/api/System.IComparable-1)
