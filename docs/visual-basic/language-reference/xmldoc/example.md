---
description: "Learn more about: <example> (Visual Basic)"
title: "<example>"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "example XML tag"
  - "<example> XML tag"
ms.assetid: 90eeda1c-3fc4-427c-879c-5046d265a97c
---
# \<example> (Visual Basic)

Specifies an example for the member.  
  
## Syntax  
  
```xml  
<example>description</example>  
```  
  
## Parameters  

 `description`  
 A description of the code sample.  
  
## Remarks  

 The `<example>` tag lets you specify an example of how to use a method or other library member. This commonly involves using the [\<code>](code.md) tag.  
  
 Compile with [-doc](../../reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  

 This example uses the `<example>` tag to include an example for using the `ID` field.  
  
 [!code-vb[VbVbcnXmlDocComments#2](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#2)]  
  
## See also

- [XML Comment Tags](index.md)
