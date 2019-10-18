---
title: "<typeparam> (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "typeparam XML tag"
  - "<typeparam> XML tag"
ms.assetid: 1bb5ba78-f060-478c-905c-77a2e43639af
---
# \<typeparam> (Visual Basic)
Defines a type parameter name and description.  
  
## Syntax  
  
```xml  
<typeparam name="name">description</typeparam>  
```  
  
## Parameters  
 `name`  
 The name of the type parameter. Enclose the name in double quotation marks (" ").  
  
 `description`  
 A description of the type parameter.  
  
## Remarks  
 Use the `<typeparam>` tag in the comment for a generic type or generic member declaration to describe one of the type parameters.  
  
 Compile with [-doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the `<typeparam>` tag to describe the `id` parameter.  
  
 [!code-vb[VbVbcnXmlDocComments#8](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#8)]  
  
## See also

- [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/index.md)
