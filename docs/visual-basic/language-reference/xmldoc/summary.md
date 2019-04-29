---
title: "<summary> (Visual Basic)"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "<summary> XML tag"
  - "summary XML tag"
ms.assetid: 861c847d-dd94-478a-aa23-bf4899cdc848
---
# \<summary> (Visual Basic)
Specifies the summary of the member.  
  
## Syntax  
  
```xml  
<summary>description</summary>  
```  
  
## Parameters  
 `description`  
 A summary of the object.  
  
## Remarks  
 Use the `<summary>` tag to describe a type or a type member. Use [\<remarks>](../../../visual-basic/language-reference/xmldoc/remarks.md) to add supplemental information to a type description.  
  
 The text for the `<summary>` tag is the only source of information about the type in IntelliSense, and is also displayed in the Object Browser. For information about the Object Browser, see [Viewing the Structure of Code](/visualstudio/ide/viewing-the-structure-of-code).  
  
 Compile with [/doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the `<summary>` tag to describe the `ResetCounter` method and `Counter` property.  
  
 [!code-vb[VbVbcnXmlDocComments#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#1)]  
  
## See also

- [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/index.md)
