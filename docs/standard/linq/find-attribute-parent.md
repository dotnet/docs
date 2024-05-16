---
title: How to find an attribute of the parent - LINQ to XML
description: "Learn how to navigate to an element and find an attribute of its parent. Two methods are shown: one uses XPathEvaluate, the other uses LINQ to XML query."
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to find an attribute of the parent (LINQ to XML)

This article shows how to use <xref:System.Xml.XPath.Extensions.XPathEvaluate%2A> to find an attribute of a parent element, and how to use LINQ to XML query to do the same thing.

## Example: Find the `Author` element, and then find the `id` attribute of its parent

This example first finds an `Author` element in XML document [Sample XML file: Books](sample-xml-file-books.md), and then finds the `id` attribute of its parent element.

The XPath expression is `../@id`.

```csharp
XDocument books = XDocument.Load("Books.xml");

XElement author =
    books
    .Root
    .Element("Book")
    .Element("Author");

// LINQ to XML query
XAttribute att1 =
    author
    .Parent
    .Attribute("id");

// XPath expression
XAttribute att2 = ((IEnumerable)author.XPathEvaluate("../@id")).Cast<XAttribute>().First();

if (att1 == att2)
    Console.WriteLine("Results are identical");
else
    Console.WriteLine("Results differ");
Console.WriteLine(att1);
```

```vb
Dim books As XDocument = XDocument.Load("Books.xml")
Dim author As XElement = books.Root.<Book>.<Author>.FirstOrDefault()

' LINQ to XML query
Dim att1 As XAttribute = author.Parent.Attribute("id")

' XPath expression
Dim att2 As XAttribute = DirectCast(author.XPathEvaluate("../@id"),  _
    IEnumerable).Cast(Of XAttribute)().First()

If att1 Is att2 Then
    Console.WriteLine("Results are identical")
Else
    Console.WriteLine("Results differ")
End If
Console.WriteLine(att1)
```

This example produces the following output:

```output
Results are identical
id="bk101"
```

## See also

- [LINQ to XML for XPath Users (Visual Basic)](./comparison-xpath-linq-xml.md)
