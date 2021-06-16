---
title: How to retrieve a collection of attributes - LINQ to XML
description: Learn how to use the XElement.Attributes method to retrieve the attributes of an element.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to retrieve a collection of attributes (LINQ to XML)

This article shows the use of the <xref:System.Xml.Linq.XElement.Attributes%2A> method to retrieve the attributes of an element.

## Example: Iterate through the attributes of an element

The following example shows how to iterate through the collection of attributes of an element.

```csharp
XElement val = new XElement("Value",
    new XAttribute("ID", "1243"),
    new XAttribute("Type", "int"),
    new XAttribute("ConvertableTo", "double"),
    "100");
IEnumerable<XAttribute> listOfAttributes =
    from att in val.Attributes()
    select att;
foreach (XAttribute a in listOfAttributes)
    Console.WriteLine(a);
```

```vb
Dim val = _
    <Value ID="1243" Type="int" ConvertableTo="double">100</Value>
Dim listOfAttributes As IEnumerable(Of XAttribute) = _
    From att In val.Attributes() _
    Select att
For Each att As XAttribute In listOfAttributes
    Console.WriteLine(att)
Next
```

This example produces the following output:

```output
ID="1243"
Type="int"
ConvertableTo="double"
```

## See also

- [LINQ to XML axes overview](linq-xml-axes-overview.md)
