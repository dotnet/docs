---
description: "Learn more about: How to: sort an array in Visual Basic"
title: "How to: Sort An Array"
ms.date: 07/20/2015
f1_keywords: 
  - "Array.Sort"
helpviewer_keywords: 
  - "arrays [Visual Basic], sorting"
  - "examples [Visual Basic], arrays"
ms.assetid: 9289aeaa-9626-4698-94a7-1d1fd3702b87
---
# How to: sort an array in Visual Basic

This article shows an example of how to sort an array of strings in Visual Basic.

## Example

This example declares an array of `String` objects named `zooAnimals`, populates it, and then sorts it alphabetically:
  
```vb
Private Sub SortAnimals()
    Dim zooAnimals(2) As String
    zooAnimals(0) = "lion"
    zooAnimals(1) = "turtle"
    zooAnimals(2) = "ostrich"
    Array.Sort(zooAnimals)
End Sub
```

## Robust programming

The following conditions may cause an exception:

- Array is empty (<xref:System.ArgumentNullException> class).
- Array is multidimensional (<xref:System.RankException> class).
- One or more elements of the array don't implement the <xref:System.IComparable> interface (<xref:System.InvalidOperationException> class).

## See also

- <xref:System.Array.Sort%2A?displayProperty=nameWithType>
- [Arrays](index.md)
- [Troubleshooting Arrays](troubleshooting-arrays.md)
- [Collections](../../concepts/collections.md)
- [For Each...Next Statement](../../../language-reference/statements/for-each-next-statement.md)
