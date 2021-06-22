---
description: "Learn more about: <inheritdoc> (C# Programming Guide)"
title: "<inheritdoc> - C# Programming Guide"
ms.date: 01/21/2020
f1_keywords: 
  - "inheritdoc"
  - "<inheritdoc>"
helpviewer_keywords: 
  - "<inheritdoc> C# XML tag"
  - "inheritdoc C# XML tag"
ms.assetid: 46d329b1-5b84-4537-9e17-73ca97313e4e
---
# \<inheritdoc> (C# Programming Guide)

## Syntax  
  
```xml  
<inheritdoc [cref=""] [path=""]/>
```  

## InheritDoc

Inherit XML comments from base classes, interfaces, and similar methods. This eliminates unwanted copying and pasting of duplicate XML comments and automatically keeps XML comments synchronized.

## Attributes

#### cref

Specify the member to inherit documentation from.  
Already defined tags on the current member are not overridden by the inherited ones.

#### path

The XPath expression query that will result in a node set to show.  
You can use this attribute to filter which tags to include or exclude from the inherited documentation.
  
## Remarks  

Add your XML comments in base classes or interfaces and let InheritDoc copy the comments to implementing classes.

Add your XML comments to your synchronous methods and let InheritDoc copy the comments to your asynchronous versions of the same methods.  

If you want to copy the comments from a specific member you can use the `cref` attribute to specify the member.
  
## Examples

[!code-csharp[csProgGuideDocComments#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#16)]  

[!code-csharp[csProgGuideDocComments#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#17)]  
[!code-csharp[csProgGuideDocComments#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#18)]  
[!code-csharp[csProgGuideDocComments#14](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#19)]  

## See also

- [C# Programming Guide](../index.md)
- [Recommended Tags for Documentation Comments](./recommended-tags-for-documentation-comments.md)
