---
title: "<see> - C# Programming Guide"
ms.date: 07/20/2015
f1_keywords: 
  - "<see>"
  - "see"
helpviewer_keywords: 
  - "cref [C#], <see> tag"
  - "<see> C# XML tag"
  - "cross-references [C#]"
  - "see C# XML tag"
ms.assetid: 0200de01-7e2f-45c4-9094-829d61236383
---
# \<see> (C# Programming Guide)
## Syntax  
  
```xml  
<see cref="member"/>  
```  
  
## Parameters  
 cref = " `member`"  
 A reference to a member or field that is available to be called from the current compilation environment. The compiler checks that the given code element exists and passes `member` to the element name in the output XML. Place *member* within double quotation marks (" ").  
  
## Remarks  
 The \<see> tag lets you specify a link from within text. Use [\<seealso>](./seealso.md) to indicate that text should be placed in a See Also section. Use the [cref Attribute](./cref-attribute.md) to create internal hyperlinks to documentation pages for code elements.  
  
 Compile with [-doc](../../language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.  
  
 The following example shows a \<see> tag within a summary section.  
  
 [!code-csharp[csProgGuideDocComments#12](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#12)]  
  
## See also

- [C# Programming Guide](../index.md)
- [Recommended Tags for Documentation Comments](./recommended-tags-for-documentation-comments.md)
