---
title: "&lt;c&gt; (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "c XML tag"
  - "<c> XML tag"
ms.assetid: 36ad5d1b-11f7-4012-8932-41962ac327d1
caps.latest.revision: 11
author: dotnet-bot
ms.author: dotnetcontent
---
# &lt;c&gt; (Visual Basic)
Indicates that text within a description is code.  
  
## Syntax  
  
```xml  
<c>text</c>  
```  
  
#### Parameters  
  
|Parameter|Description|  
|---|---|  
|`text`|The text you would like to indicate as code.|  
  
## Remarks  
 The `<c>` tag gives you a way to indicate that text within a description should be marked as code. Use [\<code>](../../../visual-basic/language-reference/xmldoc/code.md) to indicate multiple lines as code.  
  
 Compile with [/doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the `<c>` tag in the summary section to indicate that `Counter` is code.  
  
 [!code-vb[VbVbcnXmlDocComments#1](../../../visual-basic/language-reference/xmldoc/codesnippet/VisualBasic/c_1.vb)]  
  
## See Also  
 [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/recommended-xml-tags-for-documentation-comments.md)
