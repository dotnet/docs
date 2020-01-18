---
title: "<exception> - C# Programming Guide"
ms.date: 07/20/2015
f1_keywords: 
  - "exception"
  - "<exception>"
helpviewer_keywords: 
  - "<exception> C# XML tag"
  - "exception C# XML tag"
ms.assetid: dd73aac5-3c74-4fcf-9498-f11bff3a2f3c
---
# \<exception> (C# Programming Guide)
## Syntax  
  
```xml  
<exception cref="member">description</exception>  
```  
  
## Parameters  
 cref = " `member`"  
 A reference to an exception that is available from the current compilation environment. The compiler checks that the given exception exists and translates `member` to the canonical element name in the output XML. `member` must appear within double quotation marks (" ").  
  
 For more information on how to format `member` to reference a generic type, see [Processing the XML File](processing-the-xml-file.md).
  
 `description`  
 A description of the exception.  
  
## Remarks  
 The \<exception> tag lets you specify which exceptions can be thrown. This tag can be applied to definitions for methods, properties, events, and indexers.  
  
 Compile with [-doc](../../language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.  
  
 For more information about exception handling, see [Exceptions and Exception Handling](../exceptions/index.md).  
  
## Example  
 [!code-csharp[csProgGuideDocComments#4](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#4)]  
  
## See also

- [C# Programming Guide](../index.md)
- [Recommended Tags for Documentation Comments](recommended-tags-for-documentation-comments.md)
