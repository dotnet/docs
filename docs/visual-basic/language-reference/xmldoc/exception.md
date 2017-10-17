---
title: "&lt;exception&gt; (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "<exception> XML tag"
  - "exception XML tag"
ms.assetid: c0517549-171e-4dae-ab88-a9c1700b6eee
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# &lt;exception&gt; (Visual Basic)
Specifies which exceptions can be thrown.  
  
## Syntax  
  
```xml  
<exception cref="member">description</exception>  
```  
  
#### Parameters  
 `member`  
 A reference to an exception that is available from the current compilation environment. The compiler checks that the given exception exists and translates `member` to the canonical element name in the output XML. `member` must appear within double quotation marks (" ").  
  
 `description`  
 A description.  
  
## Remarks  
 Use the `<exception>` tag to specify which exceptions can be thrown. This tag is applied to a method definition.  
  
 Compile with [/doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the `<exception>` tag to describe an exception that the `IntDivide` function can throw.  
  
 [!code-vb[VbVbcnXmlDocComments#3](../../../visual-basic/language-reference/xmldoc/codesnippet/VisualBasic/exception_1.vb)]  
  
## See Also  
 [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/recommended-xml-tags-for-documentation-comments.md)
