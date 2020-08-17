---
title: "<c> - C# programming guide"
description: Learn about the XML <c> tag. This tag marks single-line text in a description as code, while <code> indicates multiple lines.
ms.date: 07/20/2015
f1_keywords:
  - "c"
  - "<c>"
helpviewer_keywords:
  - "text, marking as code [C#]"
  - "code, marking text as [C#]"
  - "c C# XML tag"
  - "<c> C# XML tag"
ms.assetid: aad5b16e-a29e-445e-bd0d-eea0b138d7b2
---
# \<c> (C# programming guide)

## Syntax

```xml
<c>text</c>
```

## Parameters

- `text`

  The text you would like to indicate as code.

## Remarks

The `<c>` tag gives you a way to indicate that text within a description should be marked as code. Use [\<code>](./code.md) to indicate multiple lines as code.

Compile with [-doc](../../language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.

## Example

[!code-csharp[csProgGuideDocComments#2](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#2)]
  
## See also

- [C# programming guide](../index.md)
- [Recommended tags for documentation comments](./recommended-tags-for-documentation-comments.md)
