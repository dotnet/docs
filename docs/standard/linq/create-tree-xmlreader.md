---
title: How to create a tree from an XmlReader - LINQ to XML
description: You can use an XmlReader in C# or Visual Basic to read XML and create an XML tree. You must properly position the XmlReader on an element node.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.topic: how-to
---

# How to create a tree from an XmlReader (LINQ to XML)

This article shows how to create an XML tree directly from an <xref:System.Xml.XmlReader> in C# or Visual Basic. To create an <xref:System.Xml.Linq.XElement> from an <xref:System.Xml.XmlReader>, you position the <xref:System.Xml.XmlReader> on an element node. The <xref:System.Xml.XmlReader> will skip comments and processing instructions, but if the <xref:System.Xml.XmlReader> is positioned on a text node, an error will be thrown. To avoid such errors, position the <xref:System.Xml.XmlReader> on an element before you create an XML tree from the <xref:System.Xml.XmlReader>.

## Example: Load XElement object from an XmlReader object

This example uses the XML document [Sample XML file: Books](sample-xml-file-books.md).

The following code creates a <xref:System.Xml.XmlReader> object, reads nodes until it finds the first element node, and loads the <xref:System.Xml.Linq.XElement> object.

```csharp
XmlReader r = XmlReader.Create("books.xml");
while (r.NodeType != XmlNodeType.Element)
    r.Read();
XElement e = XElement.Load(r);
Console.WriteLine(e);
```

```vb
Dim r As XmlReader = XmlReader.Create("books.xml")
Do While r.NodeType <> XmlNodeType.Element
    r.Read()
Loop
Dim e As XElement = XElement.Load(r)
Console.WriteLine(e)
```

This example produces the following output:

```xml
<Catalog>
   <Book id="bk101">
      <Author>Garghentini, Davide</Author>
      <Title>XML Developer's Guide</Title>
      <Genre>Computer</Genre>
      <Price>44.95</Price>
      <PublishDate>2000-10-01</PublishDate>
      <Description>An in-depth look at creating applications
      with XML.</Description>
   </Book>
   <Book id="bk102">
      <Author>Garcia, Debra</Author>
      <Title>Midnight Rain</Title>
      <Genre>Fantasy</Genre>
      <Price>5.95</Price>
      <PublishDate>2000-12-16</PublishDate>
      <Description>A former architect battles corporate zombies,
      an evil sorceress, and her own childhood to become queen
      of the world.</Description>
   </Book>
</Catalog>
```

## See also

- [Parse XML](parse-string.md)
