---
title: "Converting Data Types (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 9b0cf1ab-de48-4c6e-9f00-05b40fade46e
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Converting Data Types (Visual Basic)
Conversion methods change the type of input objects.  
  
 Conversion operations in LINQ queries are useful in a variety of applications. Following are some examples:  
  
-   The <xref:System.Linq.Enumerable.AsEnumerable%2A?displayProperty=nameWithType> method can be used to hide a type's custom implementation of a standard query operator.  
  
-   The <xref:System.Linq.Enumerable.OfType%2A?displayProperty=nameWithType> method can be used to enable non-parameterized collections for LINQ querying.  
  
-   The <xref:System.Linq.Enumerable.ToArray%2A?displayProperty=nameWithType>, <xref:System.Linq.Enumerable.ToDictionary%2A?displayProperty=nameWithType>, <xref:System.Linq.Enumerable.ToList%2A?displayProperty=nameWithType>, and <xref:System.Linq.Enumerable.ToLookup%2A?displayProperty=nameWithType> methods can be used to force immediate query execution instead of deferring it until the query is enumerated.  
  
## Methods  
 The following table lists the standard query operator methods that perform data-type conversions.  
  
 The conversion methods in this table whose names start with "As" change the static type of the source collection but do not enumerate it. The methods whose names start with "To" enumerate the source collection and put the items into the corresponding collection type.  
  
|Method Name|Description|Visual Basic Query Expression Syntax|More Information|  
|-----------------|-----------------|------------------------------------------|----------------------|  
|AsEnumerable|Returns the input typed as <xref:System.Collections.Generic.IEnumerable%601>.|Not applicable.|<xref:System.Linq.Enumerable.AsEnumerable%2A?displayProperty=nameWithType>|  
|AsQueryable|Converts a (generic) <xref:System.Collections.IEnumerable> to a (generic) <xref:System.Linq.IQueryable>.|Not applicable.|<xref:System.Linq.Queryable.AsQueryable%2A?displayProperty=nameWithType>|  
|Cast|Casts the elements of a collection to a specified type.|`From … As …`|<xref:System.Linq.Enumerable.Cast%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Cast%2A?displayProperty=nameWithType>|  
|OfType|Filters values, depending on their ability to be cast to a specified type.|Not applicable.|<xref:System.Linq.Enumerable.OfType%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.OfType%2A?displayProperty=nameWithType>|  
|ToArray|Converts a collection to an array. This method forces query execution.|Not applicable.|<xref:System.Linq.Enumerable.ToArray%2A?displayProperty=nameWithType>|  
|ToDictionary|Puts elements into a <xref:System.Collections.Generic.Dictionary%602> based on a key selector function. This method forces query execution.|Not applicable.|<xref:System.Linq.Enumerable.ToDictionary%2A?displayProperty=nameWithType>|  
|ToList|Converts a collection to a <xref:System.Collections.Generic.List%601>. This method forces query execution.|Not applicable.|<xref:System.Linq.Enumerable.ToList%2A?displayProperty=nameWithType>|  
|ToLookup|Puts elements into a <xref:System.Linq.Lookup%602> (a one-to-many dictionary) based on a key selector function. This method forces query execution.|Not applicable.|<xref:System.Linq.Enumerable.ToLookup%2A?displayProperty=nameWithType>|  
  
## Query Expression Syntax Example  
 The following code example uses the `From As` clause to cast a type to a subtype before accessing a member that is available only on the subtype.  
  
```vb  
Class Plant  
    Public Property Name As String  
End Class  
  
Class CarnivorousPlant  
    Inherits Plant  
    Public Property TrapType As String  
End Class  
  
Sub Cast()  
  
    Dim plants() As Plant = {   
        New CarnivorousPlant With {.Name = "Venus Fly Trap", .TrapType = "Snap Trap"},   
        New CarnivorousPlant With {.Name = "Pitcher Plant", .TrapType = "Pitfall Trap"},   
        New CarnivorousPlant With {.Name = "Sundew", .TrapType = "Flypaper Trap"},   
        New CarnivorousPlant With {.Name = "Waterwheel Plant", .TrapType = "Snap Trap"}}  
  
    Dim query = From plant As CarnivorousPlant In plants   
                Where plant.TrapType = "Snap Trap"   
                Select plant  
  
    Dim sb As New System.Text.StringBuilder()  
    For Each plant In query  
        sb.AppendLine(plant.Name)  
    Next  
  
    ' Display the results.  
    MsgBox(sb.ToString())  
  
    ' This code produces the following output:  
  
    ' Venus Fly Trap  
    ' Waterwheel Plant  
  
End Sub  
```  
  
## See Also  
 <xref:System.Linq>  
 [Standard Query Operators Overview (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/standard-query-operators-overview.md)  
 [From Clause](../../../../visual-basic/language-reference/queries/from-clause.md)  
 [How to: Query an ArrayList with LINQ (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-query-an-arraylist-with-linq.md)
