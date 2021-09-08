---
description: "Learn more about: White Space in XML Literals (Visual Basic)"
title: "White Space in XML Literals"
ms.date: 07/20/2015
helpviewer_keywords:
  - "white space [XML in Visual Basic]"
  - "XML literals [Visual Basic], white space"
ms.assetid: dfe3a9ff-d69a-418e-a6b5-476f4ed84219
---
# White Space in XML Literals (Visual Basic)

The Visual Basic compiler incorporates only the significant white space characters from an XML literal when it creates a LINQ to XML object. The insignificant white space characters are not incorporated.

## Significant and Insignificant White Space

 White space characters in XML literals are significant in only three areas:

- When they are in an attribute value.

- When they are part of an element's text content and the text also contains other characters.

- When they are in an embedded expression for an element's text content.

 Otherwise, the compiler treats white space characters as insignificant and does not include then in the LINQ to XML object for the literal.

 To include insignificant white space in an XML literal, use an embedded expression that contains a string literal with the white space.

> [!NOTE]
> If the `xml:space` attribute appears in an XML element literal, the Visual Basic compiler includes the attribute in the <xref:System.Xml.Linq.XElement> object, but adding this attribute does not change how the compiler treats white space.

## Examples

 The following example contains two XML elements, outer and inner. Both elements contain white space in their text content. The white space in the outer element is insignificant because it contains only white space and an XML element. The white space in the inner element is significant because it contains white space and text.

 [!code-vb[VbXMLSamples#29](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbXMLSamples/VB/XMLSamples13.vb#29)]

 When run, this code displays the following text.

```xml
<outer>
  <inner>
                                          Inner text
                                      </inner>
</outer>
```

## See also

- [Creating XML in Visual Basic](creating-xml.md)
