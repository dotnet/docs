---
title: "How to: Find an Attribute of the Parent (XPath-LINQ to XML) (C#)"
ms.date: 07/20/2015
ms.assetid: dbef9d89-a5c4-431f-80cc-7a2ebf323f86
---
# How to: Find an Attribute of the Parent (XPath-LINQ to XML) (C#)

This topic shows how to navigate to the parent element and find an attribute of it.

The XPath expression is:

`../@id`

## Example

This example first finds an `Author` element. It then finds the `id` attribute of the parent element.

This example uses the following XML document: [Sample XML File: Books (LINQ to XML)](./sample-xml-file-books-linq-to-xml.md).

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

This example produces the following output:

```output
Results are identical
id="bk101"
```
