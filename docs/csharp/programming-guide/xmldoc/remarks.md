---
title: "&lt;remarks&gt; (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "remarks"
  - "<remarks>"
helpviewer_keywords: 
  - "remarks C# XML tag"
  - "<remarks> C# XML tag"
ms.assetid: f8641391-31f3-4735-af7a-c502a5b6a251
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
---
# &lt;remarks&gt; (C# Programming Guide)
## Syntax  
  
```xml  
<remarks>description</remarks>  
```  
  
#### Parameters  
 `Description`  
 A description of the member.  
  
## Remarks  
 The \<remarks> tag is used to add information about a type, supplementing the information specified with [\<summary>](../../../csharp/programming-guide/xmldoc/summary.md). This information is displayed in the Object Browser window.  
  
 Compile with [/doc](../../../csharp/language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.  
  
## Example  
 [!code-csharp[csProgGuideDocComments#9](../../../csharp/programming-guide/xmldoc/codesnippet/CSharp/remarks_1.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Recommended Tags for Documentation Comments](../../../csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments.md)
