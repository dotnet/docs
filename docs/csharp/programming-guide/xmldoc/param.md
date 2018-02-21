---
title: "&lt;param&gt; (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "param"
  - "<param>"
helpviewer_keywords: 
  - "<param> C# XML tag"
  - "param C# XML tag"
ms.assetid: 46d329b1-5b84-4537-9e17-73ca97313e4e
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
---
# &lt;param&gt; (C# Programming Guide)
## Syntax  
  
```xml  
<param name="name">description</param>  
```  
  
#### Parameters  
 `name`  
 The name of a method parameter. Enclose the name in double quotation marks (" ").  
  
 `description`  
 A description for the parameter.  
  
## Remarks  
 The \<param> tag should be used in the comment for a method declaration to describe one of the parameters for the method. To document multiple parameters, use multiple \<param> tags.  
  
 The text for the \<param> tag will be displayed in IntelliSense, the Object Browser, and in the Code Comment Web Report.  
  
 Compile with [/doc](../../../csharp/language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.  
  
## Example  
 [!code-csharp[csProgGuideDocComments#1](../../../csharp/programming-guide/xmldoc/codesnippet/CSharp/param_1.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Recommended Tags for Documentation Comments](../../../csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments.md)
