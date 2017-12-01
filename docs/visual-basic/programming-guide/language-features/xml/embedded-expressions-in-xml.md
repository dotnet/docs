---
title: "Embedded Expressions in XML (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "vb.XmlEmbeddedExpression"
helpviewer_keywords: 
  - "embedded expressions [Visual Basic]"
  - "LINQ to XML [Visual Basic], embedded expressions"
  - "XML literals [Visual Basic], embedded expressions"
ms.assetid: bf2eb779-b751-4b7c-854f-9f2161482352
caps.latest.revision: 22
author: dotnet-bot
ms.author: dotnetcontent
---
# Embedded Expressions in XML (Visual Basic)
Embedded expressions enable you to create XML literals that contain expressions that are evaluated at run time. The syntax for an embedded expression is `<%=` `expression` `%>`, which is the same as the syntax used in [!INCLUDE[vstecasp](~/includes/vstecasp-md.md)].  
  
 For example, you can create an XML element literal, combining embedded expressions with literal text content.  
  
 [!code-vb[VbXMLSamples#27](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/embedded-expressions-in-xml_1.vb)]  
  
 If `isbnNumber` contains the integer 12345 and `modifiedDate` contains the date 3/5/2006, when this code executes, the value of `book` is:  
  
```xml  
<book category="fiction" isbn="12345">  
  <modifiedDate>3/5/2006</modifiedDate>  
</book>  
```  
  
## Embedded Expression Location and Validation  
 Embedded expressions can appear only at certain locations within XML literal expressions. The expression location controls which types the expression can return and how `Nothing` is handled. The following table describes the allowed locations and types of embedded expressions.  
  
|Location in literal|Type of expression|Handling of `Nothing`|  
|---|---|---|  
|XML element name|<xref:System.Xml.Linq.XName>|Error|  
|XML element content|`Object` or array of `Object`|Ignored|  
|XML element attribute name|<xref:System.Xml.Linq.XName>|Error, unless the attribute value is also `Nothing`|  
|XML element attribute value|`Object`|Attribute declaration ignored|  
|XML element attribute|<xref:System.Xml.Linq.XAttribute> or a collection of <xref:System.Xml.Linq.XAttribute>|Ignored|  
|XML document root element|<xref:System.Xml.Linq.XElement> or a collection of one <xref:System.Xml.Linq.XElement> object and an arbitrary number of <xref:System.Xml.Linq.XProcessingInstruction> and <xref:System.Xml.Linq.XComment> objects|Ignored|  
  
-   Example of an embedded expression in an XML element name:  
  
     [!code-vb[VbXMLSamples#32](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/embedded-expressions-in-xml_2.vb)]  
  
-   Example of an embedded expression in the content of an XML element:  
  
     [!code-vb[VbXMLSamples#33](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/embedded-expressions-in-xml_3.vb)]  
  
-   Example of an embedded expression in an XML element attribute name:  
  
     [!code-vb[VbXMLSamples#34](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/embedded-expressions-in-xml_4.vb)]  
  
-   Example of an embedded expression in an XML element attribute value:  
  
     [!code-vb[VbXMLSamples#35](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/embedded-expressions-in-xml_5.vb)]  
  
-   Example of an embedded expression in an XML element attribute:  
  
     [!code-vb[VbXMLSamples#36](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/embedded-expressions-in-xml_6.vb)]  
  
-   Example of an embedded expression in an XML document root element:  
  
     [!code-vb[VbXMLSamples#37](../../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/embedded-expressions-in-xml_7.vb)]  
  
 If you enable `Option Strict`, the compiler checks that the type of each embedded expression widens to the required type. The only exception is for the root element of an XML document, which is verified when the code runs. If you compile without `Option Strict`, you can embed expressions of type `Object` and their type is verified at run time.  
  
 In locations where content is optional, embedded expressions that contain `Nothing` are ignored. This means you do not have to check that element content, attribute values, and array elements are not `Nothing` before you use an XML literal. Required values, such as element and attribute names, cannot be `Nothing`.  
  
 For more information about using an embedded expression in a particular type of literal, see [XML Document Literal](../../../../visual-basic/language-reference/xml-literals/xml-document-literal.md), [XML Element Literal](../../../../visual-basic/language-reference/xml-literals/xml-element-literal.md).  
  
## Scoping Rules  
 The compiler converts each XML literal into a constructor call for the appropriate literal type. The literal content and embedded expressions in an XML literal are passed as arguments to the constructor. This means that all [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] programming elements available to an XML literal are also available to its embedded expressions.  
  
 Within an XML literal, you can access the XML namespace prefixes declared with the `Imports` statement. You can declare a new XML namespace prefix, or shadow an existing XML namespace prefix, in an element by using the `xmlns` attribute. The new namespace is available to the child nodes of that element, but not to XML literals in embedded expressions.  
  
> [!NOTE]
>  When you declare an XML namespace prefix by using the `xmlns` namespace attribute, the attribute value must be a constant string. In this regard, using the `xmlns` attribute is like using the `Imports` statement to declare an XML namespace. You cannot use an embedded expression to specify the XML namespace value.  
  
## See Also  
 [Creating XML in Visual Basic](../../../../visual-basic/programming-guide/language-features/xml/creating-xml.md)  
 [XML Document Literal](../../../../visual-basic/language-reference/xml-literals/xml-document-literal.md)  
 [XML Element Literal](../../../../visual-basic/language-reference/xml-literals/xml-element-literal.md)  
 [Option Strict Statement](../../../../visual-basic/language-reference/statements/option-strict-statement.md)  
 [Imports Statement (.NET Namespace and Type)](../../../../visual-basic/language-reference/statements/imports-statement-net-namespace-and-type.md)  
 [XML Literals Overview](../../../../visual-basic/programming-guide/language-features/xml/xml-literals-overview.md)
