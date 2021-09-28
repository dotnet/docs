---
description: "Learn more about: Filtering Data (Visual Basic)"
title: "Filtering Data"
ms.date: 07/20/2015
ms.assetid: 7749519a-7edc-49fe-aef9-6a353864af6c
---
# Filtering Data (Visual Basic)

Filtering refers to the operation of restricting the result set to contain only those elements that satisfy a specified condition. It is also known as selection.

The following illustration shows the results of filtering a sequence of characters. The predicate for the filtering operation specifies that the character must be 'A'.

![Diagram that shows a LINQ filtering operation](./media/filtering-data/linq-filter-operation.png)

The standard query operator methods that perform selection are listed in the following section.

## Methods

|Method Name|Description|Visual Basic Query Expression Syntax|More Information|
|-----------------|-----------------|------------------------------------------|----------------------|
|OfType|Selects values, depending on their ability to be cast to a specified type.|Not applicable.|<xref:System.Linq.Enumerable.OfType%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.OfType%2A?displayProperty=nameWithType>|
|Where|Selects values that are based on a predicate function.|`Where`|<xref:System.Linq.Enumerable.Where%2A?displayProperty=nameWithType><br /><br /> <xref:System.Linq.Queryable.Where%2A?displayProperty=nameWithType>|

## Query Expression Syntax Example

The following example uses the `Where` to filter from an array those strings that have a specific length.

```vb
Dim words() As String = {"the", "quick", "brown", "fox", "jumps"}

Dim query = From word In words
            Where word.Length = 3
            Select word

Dim sb As New System.Text.StringBuilder()
For Each str As String In query
    sb.AppendLine(str)
Next

' Display the results.
MsgBox(sb.ToString())

' This code produces the following output:

' the
' fox
```

## See also

- <xref:System.Linq>
- [Standard Query Operators Overview (Visual Basic)](standard-query-operators-overview.md)
- [Where Clause](../../../language-reference/queries/where-clause.md)
- [How to: Filter Query Results](../../language-features/linq/how-to-filter-query-results-by-using-linq.md)
- [How to: Query An Assembly's Metadata with Reflection (LINQ) (Visual Basic)](how-to-query-an-assembly-s-metadata-with-reflection-linq.md)
- [How to: Query for Files with a Specified Attribute or Name (Visual Basic)](how-to-query-for-files-with-a-specified-attribute-or-name.md)
- [How to: Sort or Filter Text Data by Any Word or Field (LINQ) (Visual Basic)](how-to-sort-or-filter-text-data-by-any-word-or-field-linq.md)
