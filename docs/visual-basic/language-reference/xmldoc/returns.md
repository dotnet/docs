---
title: "<returns>"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "returns XML tag"
  - "<returns> XML tag"
ms.assetid: a03a6469-d907-425d-882f-083187950e7e
---
# \<returns> (Visual Basic)
Specifies the return value of the property or function.  
  
## Syntax  
  
```xml  
<returns>description</returns>  
```  
  
## Parameters  
 `description`  
 A description of the return value.  
  
## Remarks  
 Use the `<returns>` tag in the comment for a method declaration to describe the return value.  
  
 Compile with [-doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the `<returns>` tag to explain what the `DoesRecordExist` function returns.  
  
 [!code-vb[VbVbcnXmlDocComments#6](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#6)]  
  
## See also

- [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/index.md)
