---
title: "XML CDATA Literal (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.XmlLiteralCdata"
helpviewer_keywords: 
  - "CDATA literal [Visual Basic]"
  - "XML CDATA literal [Visual Basic]"
  - "XML literals [Visual Basic], CDATA"
ms.assetid: 9eafb6a4-dd9d-4866-85e8-0654c65abc44
caps.latest.revision: 16
author: dotnet-bot
ms.author: dotnetcontent
---
# XML CDATA Literal (Visual Basic)
A literal representing an <xref:System.Xml.Linq.XCData> object.  
  
## Syntax  
  
```xml  
<![CDATA[content]]>  
```  
  
## Parts  
 `<![CDATA[`  
 Required. Denotes the start of the XML CDATA section.  
  
 `content`  
 Required. Text content to appear in the XML CDATA section.  
  
 `]]>`  
 Required. Denotes the end of the section.  
  
## Return Value  
 An <xref:System.Xml.Linq.XCData> object.  
  
## Remarks  
 XML CDATA sections contain raw text that should be included, but not parsed, with the XML that contains it. A XML CDATA section can contain any text. This includes reserved XML characters. The XML CDATA section ends with the sequence "]]>". This implies the following points:  
  
-   You cannot use an embedded expression in an XML CDATA literal because the embedded expression delimiters are valid XML CDATA content.  
  
-   XML CDATA sections cannot be nested, because `content` cannot contain the value "]]>".  
  
 You can assign an XML CDATA literal to a variable, or include it in an XML element literal.  
  
> [!NOTE]
>  An XML literal can span multiple lines but does not use line continuation characters. This enables you to copy content from an XML document and paste it directly into a [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] program.  
  
 The [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler converts the XML CDATA literal to a call to the <xref:System.Xml.Linq.XCData.%23ctor%2A> constructor.  
  
## Example  
 The following example creates a CDATA section that contains the text "Can contain literal \<XML> tags".  
  
 [!code-vb[VbXMLSamples#23](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/xml-cdata-literal_1.vb)]  
  
## See Also  
 <xref:System.Xml.Linq.XCData>  
 [XML Element Literal](../../../visual-basic/language-reference/xml-literals/xml-element-literal.md)  
 [XML Literals](../../../visual-basic/language-reference/xml-literals/index.md)  
 [Creating XML in Visual Basic](../../../visual-basic/programming-guide/language-features/xml/creating-xml.md)
