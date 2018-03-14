---
title: "&lt;example&gt; (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "example XML tag"
  - "<example> XML tag"
ms.assetid: 90eeda1c-3fc4-427c-879c-5046d265a97c
caps.latest.revision: 9
author: dotnet-bot
ms.author: dotnetcontent
---
# &lt;example&gt; (Visual Basic)
Specifies an example for the member.  
  
## Syntax  
  
```xml  
<example>description</example>  
```  
  
#### Parameters  
 `description`  
 A description of the code sample.  
  
## Remarks  
 The `<example>` tag lets you specify an example of how to use a method or other library member. This commonly involves using the [\<code>](../../../visual-basic/language-reference/xmldoc/code.md) tag.  
  
 Compile with [/doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the `<example>` tag to include an example for using the `ID` field.  
  
 [!code-vb[VbVbcnXmlDocComments#2](../../../visual-basic/language-reference/xmldoc/codesnippet/VisualBasic/example_1.vb)]  
  
## See Also  
 [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/recommended-xml-tags-for-documentation-comments.md)
