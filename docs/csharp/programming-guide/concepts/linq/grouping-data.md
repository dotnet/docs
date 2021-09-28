---
title: "Grouping Data (C#)"
description: Grouping puts data into groups of elements that share an attribute. Learn about the standard query operator methods in LINQ in C# that group data elements.
ms.date: 07/20/2015
ms.assetid: e414e9e4-343a-4e6e-858f-4a30c5e64492
---
# Grouping Data (C#)

Grouping refers to the operation of putting data into groups so that the elements in each group share a common attribute.  
  
 The following illustration shows the results of grouping a sequence of characters. The key for each group is the character.  
  
 ![Diagram that shows a LINQ Grouping operation.](./media/grouping-data/linq-group-operation.png)  
  
 The standard query operator methods that group data elements are listed in the following section.  
  
## Methods  
  
|Method Name|Description|C# Query Expression Syntax|More Information|  
|-----------------|-----------------|---------------------------------|----------------------|  
|GroupBy|Groups elements that share a common attribute. Each group is represented by an <xref:System.Linq.IGrouping%602> object.|`group … by`<br /><br /> -or-<br /><br /> `group … by … into …`|<xref:System.Linq.Enumerable.GroupBy%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.GroupBy%2A?displayProperty=nameWithType>|  
|ToLookup|Inserts elements into a <xref:System.Linq.Lookup%602> (a one-to-many dictionary) based on a key selector function.|Not applicable.|<xref:System.Linq.Enumerable.ToLookup%2A?displayProperty=nameWithType>|  
  
## Query Expression Syntax Example  

 The following code example uses the `group by` clause to group integers in a list according to whether they are even or odd.  
  
```csharp  
List<int> numbers = new List<int>() { 35, 44, 200, 84, 3987, 4, 199, 329, 446, 208 };  
  
IEnumerable<IGrouping<int, int>> query = from number in numbers  
                                         group number by number % 2;  
  
foreach (var group in query)  
{  
    Console.WriteLine(group.Key == 0 ? "\nEven numbers:" : "\nOdd numbers:");  
    foreach (int i in group)  
        Console.WriteLine(i);  
}  
  
/* This code produces the following output:  
  
    Odd numbers:  
    35  
    3987  
    199  
    329  
  
    Even numbers:  
    44  
    200  
    84  
    4  
    446  
    208  
*/  
```  
  
## See also

- <xref:System.Linq>
- [Standard Query Operators Overview (C#)](./standard-query-operators-overview.md)
- [group clause](../../../language-reference/keywords/group-clause.md)
- [Create a nested group](../../../linq/create-a-nested-group.md)
- [How to group files by extension (LINQ) (C#)](./how-to-group-files-by-extension-linq.md)
- [Group query results](../../../linq/group-query-results.md)
- [Perform a subquery on a grouping operation](../../../linq/perform-a-subquery-on-a-grouping-operation.md)
- [How to split a file into many files by using groups (LINQ) (C#)](./how-to-split-a-file-into-many-files-by-using-groups-linq.md)
