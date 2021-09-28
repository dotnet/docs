---
description: "Learn more about: <c> (Visual Basic)"
title: "<c>"
ms.date: 07/20/2015
helpviewer_keywords: 
  - "c XML tag"
  - "<c> XML tag"
ms.assetid: 36ad5d1b-11f7-4012-8932-41962ac327d1
---
# \<c> (Visual Basic)

Indicates that text within a description is code.  
  
## Syntax  
  
```xml  
<c>text</c>  
```  
  
## Parameters  
  
|Parameter|Description|  
|---|---|  
|`text`|The text you would like to indicate as code.|  
  
## Remarks  

 The `<c>` tag gives you a way to indicate that text within a description should be marked as code. Use [\<code>](code.md) to indicate multiple lines as code.  
  
 Compile with [-doc](../../reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  

 This example uses the `<c>` tag in the summary section to indicate that `Counter` is code.  
  
 [!code-vb[VbVbcnXmlDocComments#1](~/samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#1)]  
  
## See also

- [XML Comment Tags](index.md)
