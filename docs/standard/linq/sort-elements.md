---
title: How to sort elements - LINQ to XML
description: Learn how to write a query that sorts its results.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to sort elements (LINQ to XML)

You can sort your results when you query XML. This article provides two examples: the first sorts results for XML that *isn't* in a namespace, and the second does the same sort, but for XML that *is* in a namespace.

## Example: Write a query that sorts its results

This example shows how to write a query that sorts its results. It uses XML document [Sample XML file: Numerical data](sample-xml-file-numerical-data.md).

```csharp
XElement root = XElement.Load("Data.xml");
IEnumerable<decimal> prices =
    from el in root.Elements("Data")
    let price = (decimal)el.Element("Price")
    orderby price
    select price;
foreach (decimal el in prices)
    Console.WriteLine(el);
```

```vb
Dim root As XElement = XElement.Load("Data.xml")
Dim prices As IEnumerable(Of Decimal) = _
    From el In root.<Data> _
    Let price = Convert.ToDecimal(el.<Price>.Value) _
    Order By (price) _
    Select price
For Each el As Decimal In prices
    Console.WriteLine(el)
Next
```

This example produces the following output:

```output
0.99
4.95
6.99
24.50
29.00
66.00
89.99
```

## Example: Write a query in a namespace that sorts its results

The following example shows the same query for XML that's in a namespace. It uses XML document [Sample XML file: Numerical data in a namespace](sample-xml-file-numerical-data-namespace.md).

For more information, see [Namespaces overview](namespaces-overview.md).

```csharp
XElement root = XElement.Load("DataInNamespace.xml");
XNamespace aw = "http://www.adatum.com";
IEnumerable<decimal> prices =
    from el in root.Elements(aw + "Data")
    let price = (decimal)el.Element(aw + "Price")
    orderby price
    select price;
foreach (decimal el in prices)
    Console.WriteLine(el);
```

```vb
Imports <xmlns='http://www.adatum.com'>

Module Module1
    Sub Main()
        Dim root As XElement = XElement.Load("DataInNamespace.xml")
        Dim prices As IEnumerable(Of Decimal) = _
            From el In root.<Data> _
            Let price = Convert.ToDecimal(el.<Price>.Value) _
            Order By (price) _
            Select price
        For Each el As Decimal In prices
            Console.WriteLine(el)
        Next
    End Sub
End Module
```

This example produces the following output:

```output
0.99
4.95
6.99
24.50
29.00
66.00
89.99
```

## See also

- [Sorting Data (C#)](../../csharp/programming-guide/concepts/linq/sorting-data.md)
- [Sorting Data (Visual Basic)](../../visual-basic/programming-guide/concepts/linq/sorting-data.md)
- [Basic Queries (LINQ to XML) (Visual Basic)](./find-element-specific-attribute.md)
