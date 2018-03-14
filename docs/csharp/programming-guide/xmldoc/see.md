---
title: "&lt;see&gt; (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "<see>"
  - "see"
helpviewer_keywords: 
  - "cref [C#], <see> tag"
  - "<see> C# XML tag"
  - "cross-references [C#]"
  - "see C# XML tag"
ms.assetid: 0200de01-7e2f-45c4-9094-829d61236383
caps.latest.revision: 19
author: "BillWagner"
ms.author: "wiwagn"
---
# &lt;see&gt; (C# Programming Guide)
## Syntax  
  
```xml  
<see cref="member"/>  
```  
  
#### Parameters  
 cref = " `member`"  
 A reference to a member or field that is available to be called from the current compilation environment. The compiler checks that the given code element exists and passes `member` to the element name in the output XML.Place *member* within double quotation marks (" ").  
  
## Remarks  
 The \<see> tag lets you specify a link from within text. Use [\<seealso>](../../../csharp/programming-guide/xmldoc/seealso.md) to indicate that text should be placed in a See Also section. Use the [cref Attribute](../../../csharp/programming-guide/xmldoc/cref-attribute.md) to create internal hyperlinks to documentation pages for code elements.  
  
 Compile with [-doc](../../../csharp/language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.  
  
 The following example shows a \<see> tag within a summary section.  
  
 [!code-csharp[csProgGuideDocComments#12](../../../csharp/programming-guide/xmldoc/codesnippet/CSharp/see_1.cs)]  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Recommended Tags for Documentation Comments](../../../csharp/programming-guide/xmldoc/recommended-tags-for-documentation-comments.md)
