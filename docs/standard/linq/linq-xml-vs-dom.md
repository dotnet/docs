---
title: LINQ to XML vs. DOM
description: There are key differences between LINQ to XML and DOM. LINQ to XML supports functional construction and XML literals, which better show the structure of the XML trees that they build.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 51c0e3d2-c047-4e6a-a423-d61a882400b7
ms.topic: article
---

# LINQ to XML vs. DOM

This article describes some key differences between LINQ to XML and the current predominant XML programming API, the W3C Document Object Model (DOM).

## New ways to construct XML trees

In the W3C DOM, you build an XML tree from the bottom up; that is, you create a document, you create elements, and then you add the elements to the document.

For example, the following example uses a typical way to create an XML tree using the Microsoft implementation of DOM, <xref:System.Xml.XmlDocument>.

```csharp
XmlDocument doc = new XmlDocument();
XmlElement name = doc.CreateElement("Name");
name.InnerText = "Patrick Hines";
XmlElement phone1 = doc.CreateElement("Phone");
phone1.SetAttribute("Type", "Home");
phone1.InnerText = "206-555-0144";
XmlElement phone2 = doc.CreateElement("Phone");
phone2.SetAttribute("Type", "Work");
phone2.InnerText = "425-555-0145";
XmlElement street1 = doc.CreateElement("Street1");
street1.InnerText = "123 Main St";
XmlElement city = doc.CreateElement("City");
city.InnerText = "Mercer Island";
XmlElement state = doc.CreateElement("State");
state.InnerText = "WA";
XmlElement postal = doc.CreateElement("Postal");
postal.InnerText = "68042";
XmlElement address = doc.CreateElement("Address");
address.AppendChild(street1);
address.AppendChild(city);
address.AppendChild(state);
address.AppendChild(postal);
XmlElement contact = doc.CreateElement("Contact");
contact.AppendChild(name);
contact.AppendChild(phone1);
contact.AppendChild(phone2);
contact.AppendChild(address);
XmlElement contacts = doc.CreateElement("Contacts");
contacts.AppendChild(contact);
doc.AppendChild(contacts);
```

```vb
Dim doc As XmlDocument = New XmlDocument()
Dim name As XmlElement = doc.CreateElement("Name")
name.InnerText = "Patrick Hines"
Dim phone1 As XmlElement = doc.CreateElement("Phone")
phone1.SetAttribute("Type", "Home")
phone1.InnerText = "206-555-0144"
Dim phone2 As XmlElement = doc.CreateElement("Phone")
phone2.SetAttribute("Type", "Work")
phone2.InnerText = "425-555-0145"
Dim street1 As XmlElement = doc.CreateElement("Street1")
street1.InnerText = "123 Main St"
Dim city As XmlElement = doc.CreateElement("City")
city.InnerText = "Mercer Island"
Dim state As XmlElement = doc.CreateElement("State")
state.InnerText = "WA"
Dim postal As XmlElement = doc.CreateElement("Postal")
postal.InnerText = "68042"
Dim address As XmlElement = doc.CreateElement("Address")
address.AppendChild(street1)
address.AppendChild(city)
address.AppendChild(state)
address.AppendChild(postal)
Dim contact As XmlElement = doc.CreateElement("Contact")
contact.AppendChild(name)
contact.AppendChild(phone1)
contact.AppendChild(phone2)
contact.AppendChild(address)
Dim contacts As XmlElement = doc.CreateElement("Contacts")
contacts.AppendChild(contact)
doc.AppendChild(contacts)
Console.WriteLine(doc.OuterXml)
```

This style of coding hides the structure of the XML tree. LINQ to XML also supports an alternative approach, *functional construction*, that better shows the structure. This approach can be done with the <xref:System.Xml.Linq.XElement> and <xref:System.Xml.Linq.XAttribute> constructors. In Visual Basic, it can also be done with XML literals. This example demonstrates construction of the same XML tree using functional construction:

```csharp
XElement contacts =
    new XElement("Contacts",
        new XElement("Contact",
            new XElement("Name", "Patrick Hines"),
            new XElement("Phone", "206-555-0144",
                new XAttribute("Type", "Home")),
            new XElement("phone", "425-555-0145",
                new XAttribute("Type", "Work")),
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
Dim contacts = _
    <Contacts>
        <Contact>
            <Name>Patrick Hines</Name>
            <Phone Type="Home">206-555-0144</Phone>
            <Phone Type="Work">425-555-0145</Phone>
            <Address>
                <Street1>123 Main St</Street1>
                <City>Mercer Island</City>
                <State>WA</State>
                <Postal>68042</Postal>
            </Address>
        </Contact>
    </Contacts>
```

Notice that indenting the code to construct the XML tree shows the structure of the underlying XML. The Visual Basic version uses XML literals.

For more information, see [XML trees](functional-construction.md).

## Work directly with XML elements

When you program with XML, your primary focus is usually on XML elements and perhaps on attributes. In LINQ to XML, you can work directly with XML elements and attributes. For example, you can do the following:

- Create XML elements without using a document object at all. This simplifies programming when you have to work with fragments of XML trees.
- Load `T:System.Xml.Linq.XElement` objects directly from an XML file.
- Serialize `T:System.Xml.Linq.XElement` objects to a file or a stream.

Compare this to the W3C DOM, in which the XML document is used as a logical container for the XML tree. In DOM, XML nodes, including elements and attributes, must be created in the context of an XML document. Here is a fragment of code to create a name element in DOM:

```csharp
XmlDocument doc = new XmlDocument();
XmlElement name = doc.CreateElement("Name");
name.InnerText = "Patrick Hines";
doc.AppendChild(name);
```

```vb
Dim doc As XmlDocument = New XmlDocument()
Dim name As XmlElement = doc.CreateElement("Name")
name.InnerText = "Patrick Hines"
doc.AppendChild(name)
```

If you want to use an element across multiple documents, you must import the nodes across documents. LINQ to XML avoids this layer of complexity.

When using LINQ to XML, you use the <xref:System.Xml.Linq.XDocument> class only if you want to add a comment or processing instruction at the root level of the document.

## Simplified handling of names and namespaces

Handling names, namespaces, and namespace prefixes is generally a complex part of XML programming. LINQ to XML simplifies names and namespaces by eliminating the requirement to deal with namespace prefixes. If you want to control namespace prefixes, you can. But if you decide to not explicitly control namespace prefixes, LINQ to XML will assign namespace prefixes during serialization if they're required, or will serialize using default namespaces if they're not. If default namespaces are used, there will be no namespace prefixes in the resulting document. For more information, see [Namespaces overview](namespaces-overview.md).

Another problem with the DOM is that it doesn't let you change the name of a node. Instead, you have to create a new node and copy all the child nodes to it, losing the original node identity. LINQ to XML avoids this problem by enabling you to set the <xref:System.Xml.Linq.XName> property on a node.

## Static method support for loading XML

LINQ to XML lets you load XML by using static methods, instead of instance methods. This simplifies loading and parsing. For more information, see [How to load XML from a file](load-xml-file.md).

## Removal of support for DTD constructs

LINQ to XML further simplifies XML programming by removing support for entities and entity references. The management of entities is complex, and is rarely used. Removing their support increases performance and simplifies the programming interface. When a LINQ to XML tree is populated, all DTD entities are expanded.

## Support for fragments

LINQ to XML doesn't provide an equivalent for the `XmlDocumentFragment` class. In many cases, however, the `XmlDocumentFragment` concept can be handled by the result of a query that's typed as <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XNode>, or <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement>.

## Support for XPathNavigator

LINQ to XML provides support for <xref:System.Xml.XPath.XPathNavigator> through extension methods in the <xref:System.Xml.XPath?displayProperty=nameWithType> namespace. For more information, see <xref:System.Xml.XPath.Extensions?displayProperty=nameWithType>.

## Support for white space and indentation

LINQ to XML handles white space more simply than the DOM.

A common scenario is to read indented XML, create an in-memory XML tree without any white space text nodes (that is, not preserving white space), do some operations on the XML, and then save the XML with indentation. When you serialize the XML with formatting, only significant white space in the XML tree is preserved. This is the default behavior for LINQ to XML.

Another common scenario is to read and modify XML that has already been intentionally indented. You might not want to change this indentation in any way. In LINQ to XML, you can do this by:

- Preserving white space when you load or parse the XML.
- Disabling formatting when you serialize the XML.

LINQ to XML stores white space as an <xref:System.Xml.Linq.XText> node, instead of having a specialized <xref:System.Xml.XmlNodeType.Whitespace> node type, as the DOM does.

## Support for annotations

LINQ to XML elements support an extensible set of annotations. This is useful for tracking miscellaneous information about an element, such as schema information, information about whether the element is bound to a UI, or any other kind of application-specific information. For more information, see [LINQ to XML annotations](linq-xml-annotations.md).

## Support for schema information

LINQ to XML provides support for XSD validation through extension methods in the <xref:System.Xml.Schema?displayProperty=nameWithType> namespace. You can validate that an XML tree complies with an XSD. You can populate the XML tree with the post-schema-validation infoset (PSVI). For more information, see [How to validate using XSD](validate-xsd.md) and <xref:System.Xml.Schema.Extensions>.

## See also

- [LINQ to XML overview](linq-xml-overview.md)
