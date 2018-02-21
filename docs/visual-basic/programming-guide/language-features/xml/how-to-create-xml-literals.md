---
title: "How to: Create XML Literals (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "XML literals [Visual Basic], creating"
ms.assetid: 573a6db5-b14d-4e42-b356-8cc7e2d77745
caps.latest.revision: 17
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Create XML Literals (Visual Basic)
You can create an XML document, fragment, or element directly in code by using an XML literal. The examples in this topic demonstrate how to create an XML element that has three child elements, and how to create an XML document.  
  
 You can also use the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] APIs to create [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] objects. For more information, see <xref:System.Xml.Linq.XElement>.  
  
### To create an XML element  
  
-   Create the XML inline by using the XML literal syntax, which is the same as the actual XML syntax.  
  
     [!code-vb[VbXMLSamples#5](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-create-xml-literals_1.vb)]  
  
     Run the code. The output of this code is:  
  
     `<contact>`  
  
     `<name>Patrick Hines</name>`  
  
     `<phone type="home">206-555-0144</phone>`  
  
     `<phone type="work">425-555-0145</phone>`  
  
     `</contact>`  
  
### To create an XML document  
  
-   Create the XML document inline. The following code creates an XML document that has literal syntax, an XML declaration, a processing instruction, a comment, and an element that contains another element.  
  
     [!code-vb[VbXMLSamples#30](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-create-xml-literals_2.vb)]  
  
     Run the code. The output of this code is:  
  
     `<?xml-stylesheet type="text/xsl" href="show_book.xsl"?>`  
  
     `<!-- Tests that the application works. -->`  
  
     `<books>`  
  
     `<book/>`  
  
     `</books>`  
  
## See Also  
 [XML](../../../../visual-basic/programming-guide/language-features/xml/index.md)  
 [Creating XML in Visual Basic](../../../../visual-basic/programming-guide/language-features/xml/creating-xml.md)  
 [XML Element Literal](../../../../visual-basic/language-reference/xml-literals/xml-element-literal.md)  
 [XML Document Literal](../../../../visual-basic/language-reference/xml-literals/xml-document-literal.md)
