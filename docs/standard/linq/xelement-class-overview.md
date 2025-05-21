---
title: XElement class overview
description: The XElement class represents XML elements. You can use it to create and change elements, add attributes and children, and to serialize.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 2b9f0cd8-a1d1-4037-accf-0f38a410fa11
ms.topic: concept-article
---

# XElement class overview

The <xref:System.Xml.Linq.XElement> class is one of the fundamental classes in LINQ to XML. It represents an XML element. The following list shows what you can use this class for:

- Create elements.
- Change the content of the element.
- Add, change, or delete child elements.
- Add attributes to an element.
- Serialize the contents of an element in text form.

You can also interoperate with other classes in <xref:System.Xml?displayProperty=nameWithType>, such as <xref:System.Xml.XmlReader>, <xref:System.Xml.XmlWriter>, and <xref:System.Xml.Xsl.XslCompiledTransform>.

This article describes the functionality provided by the <xref:System.Xml.Linq.XElement> class.

## Construct XML trees

You can construct XML trees in different ways, including the following:

- You can construct an XML tree in code. For more information, see [XML trees](functional-construction.md).
- You can parse XML from various sources, including a <xref:System.IO.TextReader>, text files, or a Web address (URL). For more information, see [Parse XML](parse-string.md).
- You can use an <xref:System.Xml.XmlReader> to populate the tree. For more information, see <xref:System.Xml.Linq.XNode.ReadFrom%2A>.
- If you have a module that can write content to an <xref:System.Xml.XmlWriter>, you can use the <xref:System.Xml.Linq.XContainer.CreateWriter%2A> method to create a writer, pass the writer to the module, and then use the content that's written to the <xref:System.Xml.XmlWriter> to populate the XML tree.

The following example creates a tree. The C# version uses nested element creations. You can use the same technique in Visual Basic, but this example uses XML literals.

```csharp
XElement contacts =
    new XElement("Contacts",
        new XElement("Contact",
            new XElement("Name", "Patrick Hines"),
            new XElement("Phone", "206-555-0144"),
            new XElement("Address",
                new XElement("Street1", "123 Main St"),
                new XElement("City", "Mercer Island"),
                new XElement("State", "WA"),
                new XElement("Postal", "68042")
            )
        )
    );
```

```vb
Dim contacts As XElement = _
    <Contacts>
        <Contact>
            <Name>Patrick Hines</Name>
            <Phone>206-555-0144</Phone>
            <Address>
                <Street1>123 Main St</Street1>
                <City>Mercer Island</City>
                <State>WA</State>
                <Postal>68042</Postal>
            </Address>
        </Contact>
    </Contacts>
```

You can also use a LINQ to XML query to populate an XML tree, as shown in the following example:

```csharp
XElement srcTree = new XElement("Root",
    new XElement("Element", 1),
    new XElement("Element", 2),
    new XElement("Element", 3),
    new XElement("Element", 4),
    new XElement("Element", 5)
);
XElement xmlTree = new XElement("Root",
    new XElement("Child", 1),
    new XElement("Child", 2),
    from el in srcTree.Elements()
    where (int)el > 2
    select el
);
Console.WriteLine(xmlTree);
```

```vb
Dim srcTree As XElement = _
    <Root>
        <Element>1</Element>
        <Element>2</Element>
        <Element>3</Element>
        <Element>4</Element>
        <Element>5</Element>
    </Root>
Dim xmlTree As XElement = _
    <Root>
        <Child>1</Child>
        <Child>2</Child>
        <%= From el In srcTree.Elements() _
            Where el.Value > 2 _
            Select el %>
    </Root>
Console.WriteLine(xmlTree)
```

This example produces the following output:

```xml
<Root>
  <Child>1</Child>
  <Child>2</Child>
  <Element>3</Element>
  <Element>4</Element>
  <Element>5</Element>
</Root>
```

## Serialize XML trees

You can serialize the XML tree to a <xref:System.IO.File>, a <xref:System.IO.TextWriter>, or an <xref:System.Xml.XmlWriter>.

For more information, see [Serialize XML trees](preserve-white-space-serializing.md).

## Retrieve XML data via axis methods

You can use axis methods to retrieve attributes, child elements, descendant elements, and ancestor elements. LINQ to XML queries operate on axis methods, and provide several flexible and powerful ways to navigate through and process an XML tree.

For more information, see [LINQ to XML axes overview](linq-xml-axes-overview.md).

## Query XML trees

You can write LINQ to XML queries that extract data from an XML tree.

For more information, see [Query XML trees overview](query-xml-trees-overview.md).

## Modify XML trees

You can modify an element in different ways, including changing its content or attributes. You can also remove an element from its parent.

For more information, see [Modify XML trees](in-memory-xml-tree-modification-vs-functional-construction.md).

## See also

- [LINQ to XML programming overview](functional-vs-procedural-programming.md)
