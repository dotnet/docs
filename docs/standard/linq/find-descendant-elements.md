---
title: How to find descendant elements - LINQ to XML
description: This article shows how to use XPath and LINQ to XML query, in C# and Visual Basic, to find all descendant elements that have a specified name.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to find descendant elements (LINQ to XML)

This article shows how to use XPath and LINQ to XML query, in C# and Visual Basic, to find all descendant elements that have a specified name.

## Example Find descendant elements that have a specified name

 This example shows how to use LINQ to XML query and XPath to find all descendant elements named `Name` in XML document [Sample XML file: Multiple purchase orders](sample-xml-file-multiple-purchase-orders.md). The XPath expression is `//Name`.

```csharp
XDocument po = XDocument.Load("PurchaseOrders.xml");

// LINQ to XML query
IEnumerable<XElement> list1 = po.Root.Descendants("Name");

// XPath expression
IEnumerable<XElement> list2 = po.XPathSelectElements("//Name");

if (list1.Count() == list2.Count() &&
        list1.Intersect(list2).Count() == list1.Count())
    Console.WriteLine("Results are identical");
else
    Console.WriteLine("Results differ");
foreach (XElement el in list1)
    Console.WriteLine(el);
```

```vb
Dim po As XDocument = XDocument.Load("PurchaseOrders.xml")

' LINQ to XML query
Dim list1 As IEnumerable(Of XElement) = po...<Name>

' XPath expression
Dim list2 As IEnumerable(Of XElement) = po.XPathSelectElements("//Name")

If (list1.Count() = list2.Count() And _
        list1.Intersect(list2).Count() = list1.Count()) Then
    Console.WriteLine("Results are identical")
Else
    Console.WriteLine("Results differ")
End If
For Each el As XElement In list1
    Console.WriteLine(el)
Next
```

This example produces the following output:

```output
Results are identical
<Name>Ellen Adams</Name>
<Name>Tai Yee</Name>
<Name>Cristian Osorio</Name>
<Name>Cristian Osorio</Name>
<Name>Jessica Arnold</Name>
<Name>Jessica Arnold</Name>
```

## See also

- [LINQ to XML for XPath Users (Visual Basic)](./comparison-xpath-linq-xml.md)
