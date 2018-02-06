---
title: "&lt;see&gt; (Visual Basic)"
ms.custom: ""
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
helpviewer_keywords: 
  - "see XML tag"
  - "<see> XML tag"
ms.assetid: 7e18f60b-ef4a-4678-a797-5eb918635ca9
caps.latest.revision: 10
author: dotnet-bot
ms.author: dotnetcontent
---
# &lt;see&gt; (Visual Basic)
Specifies a link to another member.  
  
## Syntax  
  
```xml  
<see cref="member"/>  
```  
  
#### Parameters  
 `member`  
 A reference to a member or field that is available to be called from the current compilation environment. The compiler checks that the given code element exists and passes `member` to the element name in the output XML. `member` must appear within double quotation marks (" ").  
  
## Remarks  
 Use the `<see>` tag to specify a link from within text. Use [\<seealso>](../../../visual-basic/language-reference/xmldoc/seealso.md) to indicate text that you might want to appear in a "See Also" section.  
  
 Compile with [/doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the `<see>` tag in the `UpdateRecord` remarks section to refer to the `DoesRecordExist` method.  
  
 [!code-vb[VbVbcnXmlDocComments#6](../../../visual-basic/language-reference/xmldoc/codesnippet/VisualBasic/see_1.vb)]  
  
## See Also  
 [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/recommended-xml-tags-for-documentation-comments.md)
