---
title: "How to: Access XML Child Elements (Visual Basic)"
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
  - "XML axis [Visual Basic], child"
  - "child axis property [Visual Basic]"
  - "XML child axis property [Visual Basic]"
  - "XML [Visual Basic], accessing"
ms.assetid: 6689eb36-c471-469f-a82d-099ab8197b25
caps.latest.revision: 18
author: dotnet-bot
ms.author: dotnetcontent
---
# How to: Access XML Child Elements (Visual Basic)
This example shows how to use a child axis property to access all XML child elements that have a specified name in an XML element. In particular, it uses the <xref:System.Xml.Linq.XElement.Value%2A> property to get the value of the first element in the collection that the `name` child axis property returns. The `name` child axis property gets all child elements named `phone` in the `contact` object. This example also uses the `phone` child axis property to access all child elements named `phone` that are contained in the `contact` object.  
  
## Example  
 [!code-vb[VbXMLSamples#10](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/how-to-access-xml-child-elements_1.vb)]  
  
## Compiling the Code  
 This example requires:  
  
-   A reference to the <xref:System.Xml.Linq> namespace.  
  
## See Also  
 <xref:System.Xml.Linq.XContainer.Elements%2A?displayProperty=nameWithType>  
 [XML Child Axis Property](../../../../visual-basic/language-reference/xml-axis/xml-child-axis-property.md)  
 [XML Value Property](../../../../visual-basic/language-reference/xml-axis/xml-value-property.md)  
 [Accessing XML in Visual Basic](../../../../visual-basic/programming-guide/language-features/xml/accessing-xml.md)  
 [XML](../../../../visual-basic/programming-guide/language-features/xml/index.md)
