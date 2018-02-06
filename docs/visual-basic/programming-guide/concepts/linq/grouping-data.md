---
title: "Grouping Data (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
ms.assetid: 8f3a0871-6958-4aef-8f6f-493e189fd57d
caps.latest.revision: 3
author: dotnet-bot
ms.author: dotnetcontent
---
# Grouping Data (Visual Basic)
Grouping refers to the operation of putting data into groups so that the elements in each group share a common attribute.  
  
 The following illustration shows the results of grouping a sequence of characters. The key for each group is the character.  
  
 ![LINQ Grouping Operations](../../../../csharp/programming-guide/concepts/linq/media/linq_group.png "LINQ_Group")  
  
 The standard query operator methods that group data elements are listed in the following section.  
  
## Methods  
  
|Method Name|Description|Visual Basic Query Expression Syntax|More Information|  
|-----------------|-----------------|------------------------------------------|----------------------|  
|GroupBy|Groups elements that share a common attribute. Each group is represented by an <xref:System.Linq.IGrouping%602> object.|`Group … By … Into …`|<xref:System.Linq.Enumerable.GroupBy%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.GroupBy%2A?displayProperty=nameWithType>|  
|ToLookup|Inserts elements into a <xref:System.Linq.Lookup%602> (a one-to-many dictionary) based on a key selector function.|Not applicable.|<xref:System.Linq.Enumerable.ToLookup%2A?displayProperty=nameWithType>|  
  
## Query Expression Syntax Example  
 The following code example uses the `Group By` clause to group integers in a list according to whether they are even or odd.  
  
```vb  
Dim numbers As New System.Collections.Generic.List(Of Integer)(  
     New Integer() {35, 44, 200, 84, 3987, 4, 199, 329, 446, 208})  
  
Dim query = From number In numbers   
            Group By Remainder = (number Mod 2) Into Group  
  
Dim sb As New System.Text.StringBuilder()  
For Each group In query  
    sb.AppendLine(If(group.Remainder = 0, vbCrLf & "Even numbers:", vbCrLf & "Odd numbers:"))  
    For Each num In group.Group  
        sb.AppendLine(num)  
    Next  
Next  
  
' Display the results.  
MsgBox(sb.ToString())  
  
' This code produces the following output:  
  
' Odd numbers:  
' 35  
' 3987  
' 199  
' 329  
  
' Even numbers:  
' 44  
' 200  
' 84  
' 4  
' 446  
' 208  
```  
  
## See Also  
 <xref:System.Linq>  
 [Standard Query Operators Overview (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/standard-query-operators-overview.md)  
 [Group By Clause](../../../../visual-basic/language-reference/queries/group-by-clause.md)  
 [How to: Group Files by Extension (LINQ) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-group-files-by-extension-linq.md)  
 [How to: Split a File Into Many Files by Using Groups (LINQ) (Visual Basic)](../../../../visual-basic/programming-guide/concepts/linq/how-to-split-a-file-into-many-files-by-using-groups-linq.md)
