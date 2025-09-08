---
description: "Learn more about: <typeparamref> (Visual Basic)"
title: "<typeparamref>"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "typeparamref XML tag"
  - "<typeparamref> XML tag"
ms.assetid: 8979d53b-beb1-41b7-b41e-6bbea1c17a03
---
# \<typeparamref> (Visual Basic)

Formats a word as a type parameter.  
  
## Syntax  
  
```xml  
<typeparamref name="name"/>  
```  
  
## Parameters  

 `name`  
 The name of the type parameter to refer to. Enclose the name in double quotation marks (" ").  
  
## Remarks  

 The `<typeparamref>` tag gives you a way to indicate that a word is a type parameter. The XML file can be processed to format this type parameter in some distinct way, for example in italics.  
  
 Compile with [-doc](../../reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  

 This example uses the `<typeparamref>` tag to refer to the `T` type parameter.  
  
 [!code-vb[VbVbcnXmlDocComments#9](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#9)]  
  
## See also

- [XML Comment Tags](index.md)
