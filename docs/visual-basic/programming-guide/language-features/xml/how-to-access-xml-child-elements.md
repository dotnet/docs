---
description: "Learn more about: How to: Access XML Child Elements (Visual Basic)"
title: "How to: Access XML Child Elements"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "XML axis [Visual Basic], child"
  - "child axis property [Visual Basic]"
  - "XML child axis property [Visual Basic]"
  - "XML [Visual Basic], accessing"
ms.assetid: 6689eb36-c471-469f-a82d-099ab8197b25
ms.topic: how-to
---
# How to: Access XML Child Elements (Visual Basic)

This example shows how to use a child axis property to access all XML child elements that have a specified name in an XML element. In particular, it uses the <xref:System.Xml.Linq.XElement.Value%2A> property to get the value of the first element in the collection that the `name` child axis property returns. The `name` child axis property gets all child elements named `phone` in the `contact` object. This example also uses the `phone` child axis property to access all child elements named `phone` that are contained in the `contact` object.  
  
## Example  

 [!code-vb[VbXMLSamples#10](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbXMLSamples/VB/XMLSamples4.vb#10)]  
  
## Compile the code  

 This example requires:  
  
- A reference to the <xref:System.Xml.Linq> namespace.  
  
## See also

- <xref:System.Xml.Linq.XContainer.Elements%2A?displayProperty=nameWithType>
- [XML Child Axis Property](../../../language-reference/xml-axis/xml-child-axis-property.md)
- [XML Value Property](../../../language-reference/xml-axis/xml-value-property.md)
- [Accessing XML in Visual Basic](accessing-xml.md)
- [XML](index.md)
