---
description: "Learn more about: <seealso> (Visual Basic)"
title: "<seealso>"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "<seealso> XML tag"
  - "seealso XML tag"
ms.assetid: 36050c95-1af2-4284-b9b6-1a70691ed978
---
# \<seealso> (Visual Basic)

Specifies a link that appears in the See Also section.  
  
## Syntax  
  
```xml  
<seealso cref="member"/>  
```  
  
## Parameters  

 `member`  
 A reference to a member or field that is available to be called from the current compilation environment. The compiler checks that the given code element exists and passes `member` to the element name in the output XML. `member` must appear within double quotation marks (" ").  
  
## Remarks  

 Use the `<seealso>` tag to specify the text that you want to appear in a See Also section. Use [\<see>](see.md) to specify a link from within text.  
  
 Compile with [-doc](../../reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  

 This example uses the `<seealso>` tag in the `DoesRecordExist` remarks section to refer to the `UpdateRecord` method.  
  
 [!code-vb[VbVbcnXmlDocComments#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#6)]  
  
## See also

- [XML Comment Tags](index.md)
