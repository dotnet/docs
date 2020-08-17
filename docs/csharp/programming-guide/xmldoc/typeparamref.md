---
title: "<typeparamref> - C# programming guide"
description: Learn about the XML <typeparamref> tag. This tag enables consumers of the documentation file to format the word in some distinct way, for example in italics.
ms.date: 07/20/2015
f1_keywords:
  - "typeparamref"
helpviewer_keywords:
  - "typeparamref C# XML tag"
  - "<typeparamref> C# XML tag"
ms.assetid: 6d8ffc58-12c5-4688-8db6-833a7ded5886
---
# \<typeparamref> (C# programming guide)

## Syntax

```xml
<typeparamref name="name"/>
```

## Parameters

- `name`

  The name of the type parameter. Enclose the name in double quotation marks (" ").

## Remarks

For more information on type parameters in generic types and methods, see [Generics](../generics/index.md).

Use this tag to enable consumers of the documentation file to format the word in some distinct way, for example in italics.

Compile with [-doc](../../language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.

## Example

[!code-csharp[csProgGuideDocComments#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#13)]

## See also

- [C# programming guide](../index.md)
- [Recommended tags for documentation comments](./recommended-tags-for-documentation-comments.md)
