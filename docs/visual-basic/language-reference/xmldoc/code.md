---
title: "<code> (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "code XML tag"
  - "<code> XML tag"
ms.assetid: 925e5342-be05-45f2-bf66-7398bbd6710e
---
# \<code> (Visual Basic)
Indicates that the text is multiple lines of code.  
  
## Syntax  
  
```xml  
<code>content</code>  
```  
  
## Parameters  
 `content`  
 The text to mark as code.  
  
## Remarks  
 Use the `<code>` tag to indicate multiple lines as code. Use [\<c>](../../../visual-basic/language-reference/xmldoc/c.md) to indicate that text within a description should be marked as code.  
  
 Compile with [-doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the \<code> tag to include example code for using the `ID` field.  
  
 [!code-vb[VbVbcnXmlDocComments#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#2)]  
  
## See also

- [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/index.md)
