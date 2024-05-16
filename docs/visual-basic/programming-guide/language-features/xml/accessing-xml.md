---
description: "Learn more about: Accessing XML in Visual Basic"
title: "Accessing XML"
ms.date: 07/20/2015
helpviewer_keywords:
  - "LINQ to XML [Visual Basic], accessing XML"
  - "Visual Basic code, XML"
  - "accessing XML [Visual Basic], axis properties"
  - "XML [Visual Basic], axis properties"
  - "XML [Visual Basic], accessing"
ms.assetid: c47f88b2-3cbc-4bb1-b4b9-be60f71ffc6a
---
# Accessing XML in Visual Basic

Visual Basic provides XML axis properties for accessing and navigating LINQ to XML structures. These properties use a special syntax to enable you to access elements and attributes by specifying the XML names.

 The following table lists the language features that enable you to access XML elements and attributes in Visual Basic.

### XML axis properties

|Property description|Example|Description|
|--------------------------|-------------|-----------------|
|*child axis*|`contact.<phone>`|Gets all `phone` elements that are child elements of the `contact` element.|
|*attribute axis*|`phone.@type`|Gets the `type` attribute of the `phone` element.|
|*descendant axis*|`contacts...<name>`|Gets all `name` elements of the `contacts` element, regardless of how deep in the hierarchy they occur.|
|*extension indexer*|`contacts...<name>(0)`|Gets the first `name` element from the sequence.|
|*value*|`contacts...<name>.Value`|Gets the string representation of the first object in the sequence, or `Nothing` if the sequence is empty.|

## In this section

 [How to: Access XML Descendant Elements](how-to-access-xml-descendant-elements.md)\
 Shows how to use a descendant axis property to access all XML elements that have a specified name and that are contained under a specified XML element.

 [How to: Access XML Child Elements](how-to-access-xml-child-elements.md)\
 Shows how to use a child axis property to access all XML child elements that have a specified name in an XML element.

 [How to: Access XML Attributes](how-to-access-xml-attributes.md)\
 Shows how to use an attribute axis property to access all XML attributes that have a specified name in an XML element.

 [How to: Declare and Use XML Namespace Prefixes](how-to-declare-and-use-xml-namespace-prefixes.md)\
 Shows how to declare an XML namespace prefix and use it to create and access XML elements.

## Related sections

 [XML Axis Properties](../../../language-reference/xml-axis/index.md)\
 Provides links to sections describing the various XML access properties.

 [Overview of LINQ to XML in Visual Basic](overview-of-linq-to-xml.md)\
 Provides an introduction to using LINQ to XML in Visual Basic.

 [Creating XML in Visual Basic](creating-xml.md)\
 Provides an introduction to using XML literals in Visual Basic.

 [Manipulating XML in Visual Basic](manipulating-xml.md)\
 Provides links to sections about loading and modifying XML in Visual Basic.

 [XML](index.md)
 Provides links to sections describing how to use LINQ to XML in Visual Basic.
