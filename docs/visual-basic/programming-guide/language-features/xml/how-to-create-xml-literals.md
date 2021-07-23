---
description: "Learn more about: How to: Create XML Literals (Visual Basic)"
title: "How to: Create XML Literals"
ms.date: 07/20/2015
helpviewer_keywords:
  - "XML literals [Visual Basic], creating"
ms.assetid: 573a6db5-b14d-4e42-b356-8cc7e2d77745
---
# How to: Create XML Literals (Visual Basic)

You can create an XML document, fragment, or element directly in code by using an XML literal. The examples in this topic demonstrate how to create an XML element that has three child elements, and how to create an XML document.

 You can also use the LINQ to XML APIs to create LINQ to XML objects. For more information, see <xref:System.Xml.Linq.XElement>.

### To create an XML element

- Create the XML inline by using the XML literal syntax, which is the same as the actual XML syntax.

     [!code-vb[VbXMLSamples#5](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbXMLSamples/VB/XMLSamples2.vb#5)]

     Run the code. The output of this code is:

     `<contact>`

     `<name>Patrick Hines</name>`

     `<phone type="home">206-555-0144</phone>`

     `<phone type="work">425-555-0145</phone>`

     `</contact>`

### To create an XML document

- Create the XML document inline. The following code creates an XML document that has literal syntax, an XML declaration, a processing instruction, a comment, and an element that contains another element.

     [!code-vb[VbXMLSamples#30](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbXMLSamples/VB/XMLSamples13.vb#30)]

     Run the code. The output of this code is:

     `<?xml-stylesheet type="text/xsl" href="show_book.xsl"?>`

     `<!-- Tests that the application works. -->`

     `<books>`

     `<book/>`

     `</books>`

## See also

- [XML](index.md)
- [Creating XML in Visual Basic](creating-xml.md)
- [XML Element Literal](../../../language-reference/xml-literals/xml-element-literal.md)
- [XML Document Literal](../../../language-reference/xml-literals/xml-document-literal.md)
