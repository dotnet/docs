---
title: "<see> - C# programming guide"
description: Learn about the XML <see> tag. This tag lets you specify a link from within text, for example by using a cref attribute.
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
# \<see> (C# programming guide)

## Syntax

```csharp
/// <see cref="member"/>
// or
/// <see href="link">Link Text</see>
// or
/// <see langword="keyword"/>
```

## Parameters

- `cref="member"`

  A reference to a member or field that is available to be called from the current compilation environment. The compiler checks that the given code element exists and passes `member` to the element name in the output XML. Place *member* within double quotation marks (" ").

- `href="link"`

  A clickable link to a given URL. For example, `<see href="https://github.com">GitHub</see>` produces a clickable link with text :::no-loc text="GitHub"::: that links to `https://github.com`.

- `langword="keyword"`

  A language keyword, such as `true`.

## Remarks

The `<see>` tag lets you specify a link from within text. Use [\<seealso>](./seealso.md) to indicate that text should be placed in a See Also section. Use the [cref Attribute](./cref-attribute.md) to create internal hyperlinks to documentation pages for code elements. Also, ``href`` is a valid Attribute that will function as a hyperlink.

Compile with [**DocumentationFile**](../../language-reference/compiler-options/output.md#documentationfile) to process documentation comments to a file.

The following example shows a `<see>` tag within a summary section.

[!code-csharp[csProgGuideDocComments#12](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#12)]

## See also

- [C# programming guide](../index.md)
- [Recommended tags for documentation comments](./recommended-tags-for-documentation-comments.md)
