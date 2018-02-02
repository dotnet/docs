---
title: "XML Comment Literal (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.XmlLiteralComment"
helpviewer_keywords: 
  - "comment literal [Visual Basic]"
  - "XML comments, adding [Visual Basic]"
  - "XML comment literal [Visual Basic]"
  - "XML literals [Visual Basic], comment"
ms.assetid: 634c1cee-5e01-48d0-88d7-2dd55e4a9e52
caps.latest.revision: 19
author: dotnet-bot
ms.author: dotnetcontent
---
# XML Comment Literal (Visual Basic)
A literal representing an <xref:System.Xml.Linq.XComment> object.  
  
## Syntax  
  
```xml  
<!-- content -->  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`<!--`|Required. Denotes the start of the XML comment.|  
|`content`|Required. Text to appear in the XML comment. Cannot contain a series of two hyphens (--) or end with a hyphen adjacent to the closing tag.|  
|`-->`|Required. Denotes the end of the XML comment.|  
  
## Return Value  
 An <xref:System.Xml.Linq.XComment> object.  
  
## Remarks  
 XML comment literals do not contain document content; they contain information about the document. The XML comment section ends with the sequence "-->". This implies the following points:  
  
-   You cannot use an embedded expression in an XML comment literal because the embedded expression delimiters are valid XML comment content.  
  
-   XML comment sections cannot be nested, because `content` cannot contain the value "-->".  
  
 You can assign an XML comment literal to a variable, or you can include it in an XML element literal.  
  
> [!NOTE]
>  An XML literal can span multiple lines without using line continuation characters. This feature enables you to copy content from an XML document and paste it directly into a [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] program.  
  
 The [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] compiler converts the XML comment literal to a call to the <xref:System.Xml.Linq.XComment.%23ctor%2A> constructor.  
  
## Example  
 The following example creates an XML comment that contains the text "This is a comment".  
  
 [!code-vb[VbXMLSamples#9](../../../visual-basic/language-reference/operators/codesnippet/VisualBasic/xml-comment-literal_1.vb)]  
  
## See Also  
 <xref:System.Xml.Linq.XComment>  
 [XML Element Literal](../../../visual-basic/language-reference/xml-literals/xml-element-literal.md)  
 [XML Literals](../../../visual-basic/language-reference/xml-literals/index.md)  
 [Creating XML in Visual Basic](../../../visual-basic/programming-guide/language-features/xml/creating-xml.md)
