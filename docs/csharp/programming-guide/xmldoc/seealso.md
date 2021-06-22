---
title: "<seealso> - C# programming guide"
description: Learn how to use the XML <seealso> tag. This tag lets you specify the text that you might want to appear in a 'See Also' section.
ms.date: 07/20/2015
f1_keywords:
  - "cref"
  - "<seealso>"
  - "seealso"
helpviewer_keywords:
  - "cref [C#], see also"
  - "seealso C# XML tag"
  - "cref [C#]"
  - "cross-references [C#], tags"
  - "<seealso> C# XML tag"
ms.assetid: 8e157f3f-f220-4fcf-9010-88905b080b18
---
# \<seealso> (C# programming guide)

## Syntax

```csharp
/// <seealso cref="member"/>
// or
/// <seealso href="link">Link Text</seealso>
```

## Parameters

- `cref="member"`

  A reference to a member or field that is available to be called from the current compilation environment. The compiler checks that the given code element exists and passes `member` to the element name in the output XML.`member` must appear within double quotation marks (" ").

  For information on how to create a cref reference to a generic type, see [cref attribute](./cref-attribute.md).

- `href="link"`

  A clickable link to a given URL. For example, `<seealso href="https://github.com">GitHub</seealso>` produces a clickable link with text :::no-loc text="GitHub"::: that links to `https://github.com`.

## Remarks

The `<seealso>` tag lets you specify the text that you might want to appear in a See Also section. Use [\<see>](./see.md) to specify a link from within text.

Compile with [**DocumentationFile**](../../language-reference/compiler-options/output.md#documentationfile) to process documentation comments to a file.

## Example

See [\<summary>](./summary.md) for an example of using \<seealso>.

## See also

- [C# programming guide](../index.md)
- [Recommended tags for documentation comments](./recommended-tags-for-documentation-comments.md)
