---
title: XDocument class overview
description: The LINQ to XML XDocument class contains the information necessary for a valid XML document. In many cases, you don't need the functionality of an XDocument object and can use an XElement object instead.
ms.date: 07/20/2015
dev_langs:
  - "csharp"
  - "vb"
ms.assetid: 63305603-ab54-49fc-84e4-f76eecc59549
---

# XDocument class overview

The <xref:System.Xml.Linq.XDocument> class contains the information necessary for a valid XML document, which includes an XML declaration, processing instructions, and comments.

You only have to create <xref:System.Xml.Linq.XDocument> objects if you require the specific functionality provided by the <xref:System.Xml.Linq.XDocument> class. In many circumstances, you can work directly with <xref:System.Xml.Linq.XElement>. Working directly with <xref:System.Xml.Linq.XElement> is a simpler programming model.

<xref:System.Xml.Linq.XDocument> derives from <xref:System.Xml.Linq.XContainer>, so it can contain child nodes. However, <xref:System.Xml.Linq.XDocument> objects can have only one child <xref:System.Xml.Linq.XElement> node. This reflects the XML standard that there can be only one root element in an XML document.

## Components of XDocument

An <xref:System.Xml.Linq.XDocument> can contain the following elements:

- One <xref:System.Xml.Linq.XDeclaration> object. <xref:System.Xml.Linq.XDeclaration> enables you to specify the pertinent parts of an XML declaration: the XML version, the encoding of the document, and whether the XML document is standalone.
- One <xref:System.Xml.Linq.XElement> object. This object is the root node of the XML document.
- Any number of <xref:System.Xml.Linq.XProcessingInstruction> objects. A processing instruction communicates information to an application that processes the XML.
- Any number of <xref:System.Xml.Linq.XComment> objects. The comments will be siblings to the root element. The <xref:System.Xml.Linq.XComment> object can't be the first argument in the list, because it's not valid for an XML document to start with a comment.
- One <xref:System.Xml.Linq.XDocumentType> for the DTD.

When you serialize an <xref:System.Xml.Linq.XDocument>, even if `XDocument.Declaration` is `null`, the output will have an XML declaration if the writer has `Writer.Settings.OmitXmlDeclaration` set to `false` (the default).

By default, LINQ to XML sets the version to "1.0", and sets the encoding to "utf-8".

## Use XElement without XDocument

As previously mentioned, the <xref:System.Xml.Linq.XElement> class is the main class in the LINQ to XML programming interface. In many cases, your application won't require that you create a document. By using the <xref:System.Xml.Linq.XElement> class, you can:

- Create an XML tree.
- Add other XML trees to it.
- Modify the XML tree.
- Save it.

## Use XDocument

To construct an <xref:System.Xml.Linq.XDocument>, use functional construction, just like you do to construct <xref:System.Xml.Linq.XElement> objects.

The following example creates an <xref:System.Xml.Linq.XDocument> object and its associated contained objects.

```csharp
XDocument d = new XDocument(
    new XComment("This is a comment."),
    new XProcessingInstruction("xml-stylesheet",
        "href='mystyle.css' title='Compact' type='text/css'"),
    new XElement("Pubs",
        new XElement("Book",
            new XElement("Title", "Artifacts of Roman Civilization"),
            new XElement("Author", "Moreno, Jordao")
        ),
        new XElement("Book",
            new XElement("Title", "Midieval Tools and Implements"),
            new XElement("Author", "Gazit, Inbar")
        )
    ),
    new XComment("This is another comment.")
);
d.Declaration = new XDeclaration("1.0", "utf-8", "true");
Console.WriteLine(d);

d.Save("test.xml");
```

```vb
Dim doc As XDocument = <?xml version="1.0" encoding="utf-8"?>
                       <!--This is a comment.-->
                       <?xml-stylesheet href='mystyle.css' title='Compact' type='text/css'?>
                       <Pubs>
                           <Book>
                               <Title>Artifacts of Roman Civilization</Title>
                               <Author>Moreno, Jordao</Author>
                           </Book>
                           <Book>
                               <Title>Midieval Tools and Implements</Title>
                               <Author>Gazit, Inbar</Author>
                           </Book>
                       </Pubs>
                       <!--This is another comment.-->
doc.Save("test.xml")
```

The example produces this output in test.xml:

```xml
<?xml version="1.0" encoding="utf-8"?>
<!--This is a comment.-->
<?xml-stylesheet href='mystyle.css' title='Compact' type='text/css'?>
<Pubs>
  <Book>
    <Title>Artifacts of Roman Civilization</Title>
    <Author>Moreno, Jordao</Author>
  </Book>
  <Book>
    <Title>Midieval Tools and Implements</Title>
    <Author>Gazit, Inbar</Author>
  </Book>
</Pubs>
<!--This is another comment.-->
```

## See also

- [LINQ to XML overview](linq-xml-overview.md)
