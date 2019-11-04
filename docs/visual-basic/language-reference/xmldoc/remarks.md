---
title: "<remarks> (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "<remarks> XML tag"
  - "remarks XML tag"
ms.assetid: c6241773-a7ed-41c9-9a8b-9722a0c606a9
---
# \<remarks> (Visual Basic)
Specifies a remarks section for the member.  
  
## Syntax  
  
```xml  
<remarks>description</remarks>  
```  
  
## Parameters  
 `description`  
 A description of the member.  
  
## Remarks  
 Use the `<remarks>` tag to add information about a type, supplementing the information specified with [\<summary>](../../../visual-basic/language-reference/xmldoc/summary.md).  
  
 This information appears in the Object Browser. For information about the Object Browser, see [Viewing the Structure of Code](/visualstudio/ide/viewing-the-structure-of-code).  
  
 Compile with [-doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the `<remarks>` tag to explain what the `UpdateRecord` method does.  
  
 [!code-vb[VbVbcnXmlDocComments#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#6)]  
  
## See also

- [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/index.md)
