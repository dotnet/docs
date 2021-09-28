---
title: Valid content of XElement and XDocument objects - LINQ to XML
description: The XElement and XDocument constructors accept many argument types, including collections returned from queries. There are other constructors and functions for adding XML content.
ms.date: 07/20/2015
ms.assetid: 0d253586-2b97-459f-b1a7-f30f38f3ed9f
---

# Valid content of XElement and XDocument objects (LINQ to XML)

This article describes the valid arguments that can be passed to constructors, and methods that you use to add content to elements and documents.

## Valid types for the XElement constructor

Queries often evaluate to <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XElement> or <xref:System.Collections.Generic.IEnumerable%601> of <xref:System.Xml.Linq.XAttribute>. You can pass collections of <xref:System.Xml.Linq.XElement> or <xref:System.Xml.Linq.XAttribute> objects to the <xref:System.Xml.Linq.XElement> constructor. That's why it's convenient to pass the results of a query as content into methods and constructors that you use to populate XML trees.

When adding simple content, various types can be passed to this method, including::

- <xref:System.String>
- <xref:System.Double>
- <xref:System.Single>
- <xref:System.Decimal>
- <xref:System.Boolean>
- <xref:System.DateTime>
- <xref:System.TimeSpan>
- <xref:System.DateTimeOffset>
- Any type that implements `Object.ToString`.
- Any type that implements <xref:System.Collections.Generic.IEnumerable%601>.

When adding complex content, various types can be passed to this method, including:

- <xref:System.Xml.Linq.XObject>
- <xref:System.Xml.Linq.XNode>
- <xref:System.Xml.Linq.XAttribute>
- Any type that implements <xref:System.Collections.Generic.IEnumerable%601>

If an object implements <xref:System.Collections.Generic.IEnumerable%601>, the collection in the object is enumerated, and all items in the collection are added. If the collection contains <xref:System.Xml.Linq.XNode> or <xref:System.Xml.Linq.XAttribute> objects, each item in the collection is added separately. If the collection contains text (or objects that are converted to text), the text in the collection is concatenated and added as a single text node.

If content is `null`, nothing is added. When passing a collection, items in the collection can be `null`. A `null` item in the collection has no effect on the tree.

An added attribute must have a unique name within its containing element.

When adding <xref:System.Xml.Linq.XNode> or <xref:System.Xml.Linq.XAttribute> objects, if the new content has no parent, then the objects are simply attached to the XML tree. If the new content already is parented and is part of another XML tree, then the new content is cloned, and the newly cloned content is attached to the XML tree.

## Valid types for the XDocument constructor

Attributes and simple content can't be added to a document.

There aren't many scenarios that require you to create an <xref:System.Xml.Linq.XDocument>. Instead, you can usually create your XML trees with an <xref:System.Xml.Linq.XElement> root node. Unless you have a specific requirement to create a document (for example, because you have to create processing instructions and comments at the top level, or you have to support document types), it's often more convenient to use <xref:System.Xml.Linq.XElement> as your root node.

Valid types for the <xref:System.Xml.Linq.XDocument.%23ctor%2A> constructor include the following:

- Zero or one <xref:System.Xml.Linq.XDocumentType> objects. The document types must come before the element.
- Zero or one element.
- Zero or more comments.
- Zero or more processing instructions.
- Zero or more text nodes that contain only white space.

## Constructors and functions for adding content

The following methods allow you to add child content to an <xref:System.Xml.Linq.XElement> or an <xref:System.Xml.Linq.XDocument>:

|Method|Description|
|------------|-----------------|
|<xref:System.Xml.Linq.XElement.%23ctor%2A>|Constructs an <xref:System.Xml.Linq.XElement>.|
|<xref:System.Xml.Linq.XDocument.%23ctor%2A>|Constructs a <xref:System.Xml.Linq.XDocument>.|
|<xref:System.Xml.Linq.XContainer.Add%2A>|Adds to the end of the child content of the <xref:System.Xml.Linq.XElement> or <xref:System.Xml.Linq.XDocument>.|
|<xref:System.Xml.Linq.XNode.AddAfterSelf%2A>|Adds content after the <xref:System.Xml.Linq.XNode>.|
|<xref:System.Xml.Linq.XNode.AddBeforeSelf%2A>|Adds content before the <xref:System.Xml.Linq.XNode>.|
|<xref:System.Xml.Linq.XContainer.AddFirst%2A>|Adds content at the beginning of the child content of the <xref:System.Xml.Linq.XContainer>.|
|<xref:System.Xml.Linq.XElement.ReplaceAll%2A>|Replaces all content (child nodes and attributes) of an <xref:System.Xml.Linq.XElement>.|
|<xref:System.Xml.Linq.XElement.ReplaceAttributes%2A>|Replaces the attributes of an <xref:System.Xml.Linq.XElement>.|
|<xref:System.Xml.Linq.XContainer.ReplaceNodes%2A>|Replaces the children nodes with new content.|
|<xref:System.Xml.Linq.XNode.ReplaceWith%2A>|Replaces a node with new content.|

## See also

- [XML trees](functional-construction.md)
