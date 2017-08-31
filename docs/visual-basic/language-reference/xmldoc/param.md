---
title: "&lt;param&gt; (Visual Basic) | Microsoft Docs"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "VB"
helpviewer_keywords: 
  - "param XML tag"
  - "<param> XML tag"
ms.assetid: 4e32e86f-f6f3-4301-b7fc-2f321fb54368
caps.latest.revision: 14
author: "stevehoag"
ms.author: "shoag"
manager: "wpickett"
---
# &lt;param&gt; (Visual Basic)
[!INCLUDE[vs2017banner](../../../includes/vs2017banner.md)]

Defines a parameter name and description.  
  
## Syntax  
  
```  
<param name="name">description</param>  
```  
  
#### Parameters  
 `name`  
 The name of a method parameter. Enclose the name in double quotation marks (" ").  
  
 `description`  
 A description for the parameter.  
  
## Remarks  
 The `<param>` tag should be used in the comment for a method declaration to describe one of the parameters for the method.  
  
 The text for the `<param>` tag will appear in the following locations:  
  
-   Parameter Info of IntelliSense. For more information, see [Using IntelliSense](/visual-studio/ide/using-intellisense).  
  
-   Object Browser. For more information, see [Viewing the Structure of Code](/visual-studio/ide/viewing-the-structure-of-code).  
  
 Compile with [/doc](../../../visual-basic/reference/command-line-compiler/doc.md) to process documentation comments to a file.  
  
## Example  
 This example uses the `<param>` tag to describe the `id` parameter.  
  
 [!code-vb[VbVbcnXmlDocComments#6](../../../samples/snippets/visualbasic/VS_Snippets_VBCSharp/VbVbcnXmlDocComments/VB/Class1.vb#6)]  
  
## See Also  
 [XML Comment Tags](../../../visual-basic/language-reference/xmldoc/recommended-xml-tags-for-documentation-comments.md)