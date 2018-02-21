---
title: "&lt;value&gt; (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "<value>"
helpviewer_keywords: 
  - "<value> C# XML tag"
  - "value C# XML tag"
ms.assetid: 08dbadaf-9ab6-43d9-9493-98e43bed199a
caps.latest.revision: 12
author: "BillWagner"
ms.author: "wiwagn"
---
# &lt;value&gt; (C# Programming Guide)
## Syntax  
  
```xml  
<value>property-description</value>  
```  
  
#### Parameters  
 `property-description`  
 A description for the property.  
  
## Remarks  
 The \<value> tag lets you describe the value that a property represents. Note that when you add a property via code wizard in the Visual Studio .NET development environment, it will add a [\<summary>](../../../csharp/programming-guide/xmldoc/summary.md) tag for the new property. You should then manually add a \<value> tag to describe the value that the property represents.  
  
 Compile with [/doc](../../../csharp/language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.  
  
## Example  
 [!code-csharp[csProgGuideDocComments#14](../../../csharp/programming-guide/xmldoc/codesnippet/CSharp/value_1.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Recommended Tags for Documentation Comments](../../../csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments.md)
