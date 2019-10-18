---
title: "How to: Access XML Descendant Elements (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "XML descendent axis property [Visual Basic]"
  - "XML axis [Visual Basic], descendent"
  - "descendent axis property [Visual Basic]"
  - "XML [Visual Basic], accessing"
ms.assetid: aabfa258-4112-4e7e-bab9-403f96072ef7
---
# How to: Access XML Descendant Elements (Visual Basic)
This example shows how to use a descendant axis property to access all XML elements that have a specified name and that are contained under an XML element. In particular, it uses the `Value` property to get the value of the first element in the collection that the `name` descendant axis property returns. The `name` descendant axis property gets all elements named `name` that are contained in the `contacts` object. This example also uses the `phone` descendant axis property to access all descendants named `phone` that are contained in the `contacts` object.  
  
## Example  
 [!code-vb[VbXMLSamples#31](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbXMLSamples/VB/XMLSamples13.vb#31)]  
  
## Compiling the Code  
 This example requires:  
  
- A reference to the <xref:System.Xml.Linq> namespace.  
  
## See also

- <xref:System.Xml.Linq.XContainer.Descendants%2A?displayProperty=nameWithType>
- [XML Descendant Axis Property](../../../../visual-basic/language-reference/xml-axis/xml-descendant-axis-property.md)
- [XML Value Property](../../../../visual-basic/language-reference/xml-axis/xml-value-property.md)
- [Accessing XML in Visual Basic](../../../../visual-basic/programming-guide/language-features/xml/accessing-xml.md)
- [XML](../../../../visual-basic/programming-guide/language-features/xml/index.md)
