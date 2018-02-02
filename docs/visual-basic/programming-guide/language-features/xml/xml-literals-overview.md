---
title: "XML Literals Overview (Visual Basic)"
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
  - "XML literals [Visual Basic], about XML literals"
  - "declaring XML literals [Visual Basic]"
  - "LINQ to XML [Visual Basic], XML literals"
  - "literals [Visual Basic], XML"
ms.assetid: 37987c15-4ab8-471b-bd45-399816bfb57f
caps.latest.revision: 27
author: dotnet-bot
ms.author: dotnetcontent
---
# XML Literals Overview (Visual Basic)
An *XML literal* allows you to incorporate XML directly into your [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] code. The XML literal syntax represents [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] objects, and it is the similar to the XML 1.0 syntax. This makes it easier to create XML elements and documents programmatically because your code has the same structure as the final XML.  
  
 [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiles XML literals into [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] objects. [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] provides a simple object model for creating and manipulating XML, and this model integrates well with [!INCLUDE[vbteclinqext](~/includes/vbteclinqext-md.md)]. For more information, see <xref:System.Xml.Linq.XElement>.  
  
 You can embed a [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] expression in an XML literal. At run time, your application creates a [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] object for each literal, incorporating the values of the embedded expressions. This lets you specify dynamic content inside an XML literal. For more information, see [Embedded Expressions in XML](../../../../visual-basic/programming-guide/language-features/xml/embedded-expressions-in-xml.md).  
  
 For more information about the differences between the XML literal syntax and the XML 1.0 syntax, see [XML Literals and the XML 1.0 Specification](../../../../visual-basic/programming-guide/language-features/xml/xml-literals-and-the-xml-1-0-specification.md).  
  
## Simple Literals  
 You can create a [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] object in your [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] code by typing or pasting in valid XML. An XML element literal returns an <xref:System.Xml.Linq.XElement> object. For more information, see [XML Element Literal](../../../../visual-basic/language-reference/xml-literals/xml-element-literal.md) and [XML Literals and the XML 1.0 Specification](../../../../visual-basic/programming-guide/language-features/xml/xml-literals-and-the-xml-1-0-specification.md). The following example creates an XML element that has several child elements.  
  
 [!code-vb[VbXMLSamples#5](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/xml-literals-overview_1.vb)]  
  
 You can create an XML document by starting an XML literal with `<?xml version="1.0"?>`, as shown in the following example. An XML document literal returns an <xref:System.Xml.Linq.XDocument> object. For more information, see [XML Document Literal](../../../../visual-basic/language-reference/xml-literals/xml-document-literal.md).  
  
 [!code-vb[VbXMLSamples#6](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/xml-literals-overview_2.vb)]  
  
> [!NOTE]
>  The XML literal syntax in [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] is not identical to the syntax in the XML 1.0 specification. For more information, see [XML Literals and the XML 1.0 Specification](../../../../visual-basic/programming-guide/language-features/xml/xml-literals-and-the-xml-1-0-specification.md).  
  
## Line Continuation  
 An XML literal can span multiple lines without using line continuation characters (the space-underscore-enter sequence). This makes it easier to compare XML literals in code with XML documents.  
  
 The compiler treats line continuation characters as part of an XML literal. Therefore, you should use the space-underscore-enter sequence only when it belongs in the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] object.  
  
 However, you do need line continuation characters if you have a multiline expression in an embedded expression. For more information, see [Embedded Expressions in XML](../../../../visual-basic/programming-guide/language-features/xml/embedded-expressions-in-xml.md).  
  
## Embedding Queries in XML Literals  
 You can use a query in an embedded expression. When you do this, the elements returned by the query are added to the XML element. This lets you add dynamic content, such as the result of a user's query, to an XML literal.  
  
 For example, the following code uses an embedded query to create XML elements from the members of the `phoneNumbers2` array and then add those elements as children of `contact2`.  
  
 [!code-vb[VbXMLSamples#7](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/xml-literals-overview_3.vb)]  
  
## How the Compiler Creates Objects from XML Literals  
 The [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler translates XML literals into calls to the equivalent [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] constructors to build up the [!INCLUDE[sqltecxlinq](~/includes/sqltecxlinq-md.md)] object. For example, the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler will translate the following code example into a call to the <xref:System.Xml.Linq.XProcessingInstruction> constructor for the XML version instruction, calls to the <xref:System.Xml.Linq.XElement> constructor for the `<contact>`, `<name>`, and `<phone>` elements, and calls to the <xref:System.Xml.Linq.XAttribute> constructor for the `type` attribute. Specifically, given the attributes in the following sample, the [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler will call the <xref:System.Xml.Linq.XAttribute.%23ctor%28System.Xml.Linq.XName%2CSystem.Object%29> constructor twice. The first will pass the value `type` for the `name` parameter and the value `home` for the `value` parameter. The second will also pass the value `type` for the `name` parameter, but the value `work` for the `value` parameter.  
  
 [!code-vb[VbXMLSamples#6](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/xml-literals-overview_2.vb)]  
  
## See Also  
 <xref:System.Xml.Linq.XElement>  
 [Creating XML in Visual Basic](../../../../visual-basic/programming-guide/language-features/xml/creating-xml.md)  
 [Embedded Expressions in XML](../../../../visual-basic/programming-guide/language-features/xml/embedded-expressions-in-xml.md)  
 [XML Document Literal](../../../../visual-basic/language-reference/xml-literals/xml-document-literal.md)  
 [XML Element Literal](../../../../visual-basic/language-reference/xml-literals/xml-element-literal.md)  
 [XML Literals](../../../../visual-basic/language-reference/xml-literals/index.md)
