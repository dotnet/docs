---
description: "Learn more about: XML Descendant Axis Property (Visual Basic)"
title: "XML Descendant Axis Property"
ms.date: 07/20/2015
f1_keywords:
  - "vb.XmlPropertyDescendantsAxis"
helpviewer_keywords:
  - "Visual Basic code, accessing XML"
  - "XML descendant axis property [Visual Basic]"
  - "descendant axis property [Visual Basic]"
  - "XML axis [Visual Basic], descendant"
  - "XML [Visual Basic], accessing"
ms.assetid: a178f85b-5d54-438f-8479-40b62af6fe76
---

# XML Descendant Axis Property (Visual Basic)

Provides access to the descendants of the following: an <xref:System.Xml.Linq.XElement> object, an <xref:System.Xml.Linq.XDocument> object, a collection of <xref:System.Xml.Linq.XElement> objects, or a collection of <xref:System.Xml.Linq.XDocument> objects.

## Syntax

```vb
object...<descendant>
```

## Parts

`object`
Required. An <xref:System.Xml.Linq.XElement> object, an <xref:System.Xml.Linq.XDocument> object, a collection of <xref:System.Xml.Linq.XElement> objects, or a collection of <xref:System.Xml.Linq.XDocument> objects.

`...<`
Required. Denotes the start of a descendant axis property.

`descendant`
Required. Name of the descendant nodes to access, of the form [`prefix:]name`.

|Part|Description|
|----------|-----------------|
|`prefix`|Optional. XML namespace prefix for the descendant node. Must be a global XML namespace that is defined by using an `Imports` statement.|
|`name`|Required. Local name of the descendant node. See [Names of Declared XML Elements and Attributes](../../programming-guide/language-features/xml/names-of-declared-xml-elements-and-attributes.md).|

`>`
Required. Denotes the end of a descendant axis property.

## Return Value

A collection of <xref:System.Xml.Linq.XElement> objects.

## Remarks

You can use an XML descendant axis property to access descendant nodes by name from an <xref:System.Xml.Linq.XElement> or <xref:System.Xml.Linq.XDocument> object, or from a collection of <xref:System.Xml.Linq.XElement> or <xref:System.Xml.Linq.XDocument> objects. Use the XML `Value` property to access the value of the first descendant node in the returned collection. For more information, see [XML Value Property](xml-value-property.md).

The Visual Basic compiler converts descendant axis properties into calls to the <xref:System.Xml.Linq.XContainer.Descendants%2A> method.

## XML Namespaces

The name in a descendant axis property can use only XML namespaces declared globally with the `Imports` statement. It cannot use XML namespaces declared locally within XML element literals. For more information, see [Imports Statement (XML Namespace)](../statements/imports-statement-xml-namespace.md).

## Example 1

The following example shows how to access the value of the first descendant node named `name` and the values of all descendant nodes named `phone` from the `contacts` object.

[!code-vb[VbXMLSamples#25](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbXMLSamples/VB/XMLSamples11.vb#25)]

This code displays the following text:

`Name: Patrick Hines`

`Home Phone = 206-555-0144`

## Example 2

The following example declares `ns` as an XML namespace prefix. It then uses the prefix of the namespace to create an XML literal and access the value of the first child node with the qualified name `ns:name`.

[!code-vb[VbXMLSamples#26](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbXMLSamples/VB/XMLSamples12.vb#26)]

This code displays the following text:

`Name: Patrick Hines`

## See also

- <xref:System.Xml.Linq.XElement>
- [XML Axis Properties](index.md)
- [XML Literals](../xml-literals/index.md)
- [Creating XML in Visual Basic](../../programming-guide/language-features/xml/creating-xml.md)
- [Names of Declared XML Elements and Attributes](../../programming-guide/language-features/xml/names-of-declared-xml-elements-and-attributes.md)
