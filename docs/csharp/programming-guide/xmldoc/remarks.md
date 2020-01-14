---
title: "<remarks> - C# Programming Guide"
ms.date: 07/20/2015
f1_keywords: 
  - "remarks"
  - "<remarks>"
helpviewer_keywords: 
  - "remarks C# XML tag"
  - "<remarks> C# XML tag"
ms.assetid: f8641391-31f3-4735-af7a-c502a5b6a251
---
# \<remarks> (C# Programming Guide)
## Syntax  
  
```xml  
<remarks>description</remarks>  
```  
  
## Parameters  
 `Description`  
 A description of the member.  
  
## Remarks  
 The \<remarks> tag is used to add information about a type, supplementing the information specified with [\<summary>](./summary.md). This information is displayed in the Object Browser window.  
  
 Compile with [-doc](../../language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.  
  
## Example  
 [!code-csharp[csProgGuideDocComments#9](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#9)]  
  
## See also

- [C# Programming Guide](../index.md)
- [Recommended Tags for Documentation Comments](./recommended-tags-for-documentation-comments.md)
