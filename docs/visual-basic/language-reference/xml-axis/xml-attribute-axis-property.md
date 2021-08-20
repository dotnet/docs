---
description: "Learn more about: XML Attribute Axis Property (Visual Basic)"
title: "XML Attribute Axis Property"
ms.date: 07/20/2015
f1_keywords:
  - "vb.XmlPropertyAttributeAxis"
helpviewer_keywords:
  - "attribute axis property [Visual Basic]"
  - "Visual Basic code, accessing XML"
  - "XML attribute axis property [Visual Basic]"
  - "XML axis [Visual Basic], attribute"
  - "XML [Visual Basic], accessing"
ms.assetid: 7a4777e1-0618-4de9-9510-fb9ace2bf4db
---
# XML Attribute Axis Property (Visual Basic)

Provides access to the value of an attribute for an <xref:System.Xml.Linq.XElement> object or to the first element in a collection of <xref:System.Xml.Linq.XElement> objects.

## Syntax

```vb
object.@attribute
' -or-
object.@<attribute>
```

## Parts

 `object`
 Required. An <xref:System.Xml.Linq.XElement> object or a collection of <xref:System.Xml.Linq.XElement> objects.

 .@
 Required. Denotes the start of an attribute axis property.

 <
 Optional. Denotes the beginning of the name of the attribute when `attribute` is not a valid identifier in Visual Basic.

 `attribute`
 Required. Name of the attribute to access, of the form [`prefix`:]`name`.

|Part|Description|
|----------|-----------------|
|`prefix`|Optional. XML namespace prefix for the attribute. Must be a global XML namespace defined with an `Imports` statement.|
|`name`|Required. Local attribute name. See [Names of Declared XML Elements and Attributes](../../programming-guide/language-features/xml/names-of-declared-xml-elements-and-attributes.md).|

 \>
 Optional. Denotes the end of the name of the attribute when `attribute` is not a valid identifier in Visual Basic.

## Return Value

 A string that contains the value of `attribute`. If the attribute name does not exist, `Nothing` is returned.

## Remarks

 You can use an XML attribute axis property to access the value of an attribute by name from an <xref:System.Xml.Linq.XElement> object or from the first element in a collection of <xref:System.Xml.Linq.XElement> objects. You can retrieve an attribute value by name, or add a new attribute to an element by specifying a new name preceded by the @ identifier.

 When you refer to an XML attribute using the @ identifier, the attribute value is returned as a string and you do not need to explicitly specify the <xref:System.Xml.Linq.XAttribute.Value%2A> property.

 The naming rules for XML attributes differ from the naming rules for Visual Basic identifiers. To access an XML attribute that has a name that is not a valid Visual Basic identifier, enclose the name in angle brackets (\< and >).

## XML Namespaces

 The name in an attribute axis property can use only XML namespace prefixes declared globally by using the `Imports` statement. It cannot use XML namespace prefixes declared locally within XML element literals. For more information, see [Imports Statement (XML Namespace)](../statements/imports-statement-xml-namespace.md).

## Example 1

 The following example shows how to get the values of the XML attributes named `type` from a collection of XML elements that are named `phone`.

 [!code-vb[VbXMLSamples#12](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbXMLSamples/VB/XMLSamples5.vb#12)]

 This code displays the following text:

 `<phoneTypes>`

 `<type>home</type>`

 `<type>work</type>`

 `</phoneTypes>`

## Example 2

 The following example shows how to create attributes for an XML element both declaratively, as part of the XML, and dynamically by adding an attribute to an instance of an <xref:System.Xml.Linq.XElement> object. The `type` attribute is created declaratively and the `owner` attribute is created dynamically.

 [!code-vb[VbXMLSamples#44](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbXMLSamples/VB/XMLSamples5.vb#44)]

 This code displays the following text:

```xml
<phone type="home" owner="Harris, Phyllis">206-555-0144</phone>
```

## Example 3

 The following example uses the angle bracket syntax to get the value of the XML attribute named `number-type`, which is not a valid identifier in Visual Basic.

 [!code-vb[VbXMLSamples#13](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbXMLSamples/VB/XMLSamples5.vb#13)]

 This code displays the following text:

 `Phone type: work`

## Example 4

 The following example declares `ns` as an XML namespace prefix. It then uses the prefix of the namespace to create an XML literal and access the first child node with the qualified name "`ns:name`".

 [!code-vb[VbXMLSamples#14](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbXMLSamples/VB/XMLSamples6.vb#14)]

 This code displays the following text:

 `Phone type: home`

## See also

- <xref:System.Xml.Linq.XElement>
- [XML Axis Properties](index.md)
- [XML Literals](../xml-literals/index.md)
- [Creating XML in Visual Basic](../../programming-guide/language-features/xml/creating-xml.md)
- [Names of Declared XML Elements and Attributes](../../programming-guide/language-features/xml/names-of-declared-xml-elements-and-attributes.md)
