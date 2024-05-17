---
title: System.Xml.XmlDocument class
description: Learn about the System.Xml.XmlDocument class.
ms.date: 12/31/2023
dev_langs:
  - CSharp
  - VB
---
# System.Xml.XmlDocument class

[!INCLUDE [context](includes/context.md)]

The <xref:System.Xml.XmlDocument> class is an in-memory representation of an XML document. It implements the W3C [XML Document Object Model (DOM)](../../standard/data/xml/xml-document-object-model-dom.md) Level 1 Core and the Core DOM Level 2.

*DOM* stands for *document object model*. To read more about it, see [XML Document Object Model (DOM)](../../standard/data/xml/xml-document-object-model-dom.md).

You can load XML into the DOM by using the <xref:System.Xml.XmlDocument> class, and then programmatically read, modify, and remove XML in the document.

If you want to pry open the <xref:System.Xml.XmlDocument> class and see how it's implemented, see the [Reference Source](https://referencesource.microsoft.com/#System.Xml/Xml/System/Xml/Dom/XmlDocument.cs#f82a4c1bd1f0ee12).

## Load XML into the document object model

Start with an XML document like this one that has a few books in a collection. It contains the basic things that you'd find in any XML document, including a namespace, elements that represent data, and attributes that describe the data.

```xml
<?xml version="1.0" encoding="utf-8"?>
<books xmlns="http://www.contoso.com/books">
  <book genre="novel" ISBN="1-861001-57-8" publicationdate="1823-01-28">
    <title>Pride And Prejudice</title>
    <price>24.95</price>
  </book>
  <book genre="novel" ISBN="1-861002-30-1" publicationdate="1985-01-01">
    <title>The Handmaid's Tale</title>
    <price>29.95</price>
  </book>
  <book genre="novel" ISBN="1-861001-45-3" publicationdate="1811-01-01">
    <title>Sense and Sensibility</title>
    <price>19.95</price>
  </book>
</books>
```

Next, load this data into the DOM so that you can work with it in memory. The most popular way to do this is refer to a file on your local computer or on a network.

This example loads XML from a file. If the file doesn't exist, it just generates some XML and loads that.

[!code-csharp[XMLProcessingApp#1](./snippets/System.Xml/XmlDocument/Overview/csharp/xmlhelpermethods.cs#1)]
[!code-vb[XMLProcessingApp#1](./snippets/System.Xml/XmlDocument/Overview/vb/WinForms/xmlhelpermethods.vb#1)]

For more information, see [Reading an XML Document into the DOM](../../standard/data/xml/reading-an-xml-document-into-the-dom.md).

## Validate it against a schema

Start with an XML schema like this one. This schema defines the data types in the XML and which attributes are required.

```xml
<?xml version="1.0" encoding="utf-8"?>
<xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema"
  attributeFormDefault="unqualified"
  elementFormDefault="qualified"
  targetNamespace="http://www.contoso.com/books">
  <xs:element name="books">
    <xs:complexType>
      <xs:sequence>
        <xs:element maxOccurs="unbounded" name="book">
          <xs:complexType>
            <xs:sequence>
              <xs:element name="title" type="xs:string" />
              <xs:element name="price" type="xs:decimal" />
            </xs:sequence>
            <xs:attribute name="genre" type="xs:string" use="required" />
            <xs:attribute name="ISBN" type="xs:string" use="required" />
            <xs:attribute name="publicationdate" type="xs:date" use="required" />
          </xs:complexType>
        </xs:element>
      </xs:sequence>
    </xs:complexType>
  </xs:element>
</xs:schema>
```

Create an <xref:System.Xml.XmlReader> object by using your schema, and then load that object into the DOM. Create an event handler that executes when code attempts to modify your XML file in ways that violate the rules of the schema.

These blocks of code show helper methods that do all of this.

[!code-csharp[XMLProcessingApp#2](./snippets/System.Xml/XmlDocument/Overview/csharp/xmlhelpermethods.cs#2)]
[!code-vb[XMLProcessingApp#2](./snippets/System.Xml/XmlDocument/Overview/vb/WinForms/xmlhelpermethods.vb#2)]

For more information, see [Validating an XML Document in the DOM](../../standard/data/xml/validating-an-xml-document-in-the-dom.md).

## Navigate the document tree

You can use properties to navigate around an XML document. But before you use any of them, let's quickly review a few terms. Your document is composed of nodes. Each node has a single *parent* node directly above it. The only node that does not have a parent node is the document root, as it is the top-level node. Most nodes can have *child* nodes, which are nodes directly below them. Nodes that are at the same level are *siblings*.

The following examples show you how to obtain the root node, jump to the first child node of the root node, access any of its child nodes, get back out to the parent node, and then navigate across sibling nodes.

**Start with the root node**

This example gets the root node and then uses that node to output the contents of the document to the console.

[!code-csharp[Classic WebData XmlDocument.DocumentElement Example#1](./snippets/System.Xml/XmlDocument/Overview/csharp/source.cs#1)]
[!code-vb[Classic WebData XmlDocument.DocumentElement Example#1](./snippets/System.Xml/XmlDocument/Overview/vb/Non-WinForms/source-element.vb#1)]

**Get child nodes**

This example jumps to the first child node of the root node and then iterates through the child nodes of that node if any exist.

[!code-csharp[Classic WebData XmlNode.HasChildNodes Example#1](./snippets/System.Xml/XmlDocument/Overview/csharp/source2.cs#1)]
[!code-vb[Classic WebData XmlNode.HasChildNodes Example#1](./snippets/System.Xml/XmlDocument/Overview/vb/Non-WinForms/source2.vb#1)]

**Get back to the parent node**

Use the <xref:System.Xml.XmlDocument.ParentNode> property.

**Refer to the last child node**

This example writes the price of a book to the console. The price node is the last child of a book node.

[!code-csharp[Classic WebData XmlNode.LastChild Example#1](./snippets/System.Xml/XmlDocument/Overview/csharp/source3.cs#1)]
[!code-vb[Classic WebData XmlNode.LastChild Example#1](./snippets/System.Xml/XmlDocument/Overview/vb/Non-WinForms/source-lastchild.vb#1)]

**Navigate forward across siblings**

This example moves forward from book to book. Book nodes are siblings to one another.

[!code-csharp[Classic WebData XmlNode.NextSibling Example#1](./snippets/System.Xml/XmlDocument/Overview/csharp/source4.cs#1)]
[!code-vb[Classic WebData XmlNode.NextSibling Example#1](./snippets/System.Xml/XmlDocument/Overview/vb/Non-WinForms/source-nextsibling.vb#1)]

**Navigate backwards across siblings**

This example moves backwards from book to book.

[!code-csharp[Classic WebData XmlNode.PreviousSibling Example#1](./snippets/System.Xml/XmlLinkedNode/csharp/PreviousSibling/source.cs#1)]
[!code-vb[Classic WebData XmlNode.PreviousSibling Example#1](./snippets/System.Xml/XmlDocument/Overview/vb/Non-WinForms/source5.vb#1)]

## Find nodes

The most popular way to find one or more nodes of data is to use an XPath query string, but there are also methods that don't require one.

**Get a single node**

This example locates a book by using the ISBN number.

[!code-csharp[XMLProcessingApp#3](./snippets/System.Xml/XmlDocument/Overview/csharp/xmlhelpermethods.cs#3)]
[!code-vb[XMLProcessingApp#3](./snippets/System.Xml/XmlDocument/Overview/vb/WinForms/xmlhelpermethods.vb#3)]

The string used in this example is an Xpath query. You can find more examples of them at [XPath examples](/previous-versions/dotnet/netframework-4.0/ms256086(v=vs.100)).

You can also use the <xref:System.Xml.XmlDocument.GetElementById%2A> to retrieve nodes. To use this approach, you'll have to define ID's in the document type definition declarations of your XML file.

After you get a node, you get the value of attributes or child nodes. This example does that with a book node.

[!code-csharp[XMLProcessingApp#4](./snippets/System.Xml/XmlDocument/Overview/csharp/xmlhelpermethods.cs#4)]
[!code-vb[XMLProcessingApp#4](./snippets/System.Xml/XmlDocument/Overview/vb/WinForms/xmlhelpermethods.vb#4)]

**Get a collection of nodes**

This example selects all books where the author's last name is **Austen**, and then changes the price of those books.

[!code-csharp[Classic WebData XmlNode.SelectNodes Example#1](./snippets/System.Xml/XmlDocument/Overview/csharp/source6.cs#1)]
[!code-vb[Classic WebData XmlNode.SelectNodes Example#1](./snippets/System.Xml/XmlDocument/Overview/vb/WinForms/source.vb#1)]

You can also get a collection of nodes by using the name of the node. For example, this example gets a collection of all book titles.

[!code-csharp[Classic WebData XmlDocument.GetElementsByTagName Example#1](./snippets/System.Xml/XmlDocument/Overview/csharp/source1.cs#1)]
[!code-vb[Classic WebData XmlDocument.GetElementsByTagName Example#1](./snippets/System.Xml/XmlDocument/Overview/vb/Non-WinForms/source-tag.vb#1)]

For more information, see [Select Nodes Using XPath Navigation](../../standard/data/xml/select-nodes-using-xpath-navigation.md).

## Edit nodes

This example edits a book node and its attributes.

[!code-csharp[XMLProcessingApp#7](./snippets/System.Xml/XmlDocument/Overview/csharp/xmlhelpermethods.cs#7)]
[!code-vb[XMLProcessingApp#7](./snippets/System.Xml/XmlDocument/Overview/vb/WinForms/xmlhelpermethods.vb#7)]

For more information, see [Modifying Nodes, Content, and Values in an XML Document](../../standard/data/xml/modifying-nodes-content-and-values-in-an-xml-document.md).

## Add nodes

To add a node, use the <xref:System.Xml.XmlDocument.CreateElement%2A> method or the <xref:System.Xml.XmlDocument.CreateNode%2A> method.

To add a data node such as a book, use the <xref:System.Xml.XmlDocument.CreateElement%2A> method.

For any other type of node such as a comment, whitespace node, or CDATA node, use the <xref:System.Xml.XmlDocument.CreateNode%2A> method.

This example creates a book node, adds attributes to that node, and then adds that node to the document.

[!code-csharp[XMLProcessingApp#5](./snippets/System.Xml/XmlDocument/Overview/csharp/xmlhelpermethods.cs#5)]
[!code-vb[XMLProcessingApp#5](./snippets/System.Xml/XmlDocument/Overview/vb/WinForms/xmlhelpermethods.vb#5)]

For more information, see [Inserting Nodes into an XML Document](../../standard/data/xml/inserting-nodes-into-an-xml-document.md).

## Remove nodes

To remove a node, use the <xref:System.Xml.XmlNode.RemoveChild%2A> method.

This example removes a book from the document and any whitespace that appears just before the book node.

[!code-csharp[XMLProcessingApp#6](./snippets/System.Xml/XmlDocument/Overview/csharp/xmlhelpermethods.cs#6)]
[!code-vb[XMLProcessingApp#6](./snippets/System.Xml/XmlDocument/Overview/vb/WinForms/xmlhelpermethods.vb#6)]

For more information, see [Removing Nodes, Content, and Values from an XML Document](../../standard/data/xml/removing-nodes-content-and-values-from-an-xml-document.md).

## Position nodes

You can choose where you want a node to appear in your document by using the <xref:System.Xml.XmlNode.InsertBefore%2A> and <xref:System.Xml.XmlNode.InsertAfter%2A> methods.

This example shows two helper methods. One of them moves a node higher in a list. The other one moves a node lower.

These methods could be used in an application that enables users to move books up and down in a list of books. When a user chooses a book and presses an up or down button, your code could call methods like these to position the corresponding book node before or after other book nodes.

[!code-csharp[XMLProcessingApp#8](./snippets/System.Xml/XmlDocument/Overview/csharp/xmlhelpermethods.cs#8)]
[!code-vb[XMLProcessingApp#8](./snippets/System.Xml/XmlDocument/Overview/vb/WinForms/xmlhelpermethods.vb#8)]
