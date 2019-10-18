---
title: "<exception> (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "<exception> XML tag"
  - "exception XML tag"
ms.assetid: c0517549-171e-4dae-ab88-a9c1700b6eee
---
# \<exception> (Visual Basic)
Specifies which exceptions can be thrown.  
  
## Syntax  
  
```xml  
<exception cref="member">description</exception>  
```  
  
## Parameters  
 `member`  
 A reference to an exception that is available from the current compilation environment. The compiler checks that the given exception exists and translates `member` to the canonical element name in the output XML. `member` must appear within double quotation marks (" ").  
  
 `description`  
 A description.  
  
## Remarks  
 Use the `<exception>` tag to specify which exceptions can be thrown. This tag is applied to a method definition.  
  
 Compile with [-doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the `<exception>` tag to describe an exception that the `IntDivide` function can throw.  
  
 [!code-vb[VbVbcnXmlDocComments#3](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#3)]  
  
## See also

- [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/index.md)
