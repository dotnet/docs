---
title: "<para> - C# programming guide"
description: Learn about the XML <para> tag. This tag lets you add structure to the text in another tag, such as <summary>, <remarks>, or <returns>.
ms.date: 07/20/2015
f1_keywords:
  - "<para>"
  - "para"
helpviewer_keywords:
  - "<para> C# XML tag"
  - "para C# XML tag"
ms.assetid: c74b8705-29df-40b1-bff5-237492b0e978
---
# \<para> (C# programming guide)

## Syntax

```xml
<para>content</para>
```

## Parameters

- `content`

  The text of the paragraph.

## Remarks

The `<para>` tag is for use inside a tag, such as [\<summary>](./summary.md), [\<remarks>](./remarks.md), or [\<returns>](./returns.md), and lets you add structure to the text.

Compile with [-doc](../../language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.

## Example

See [\<summary>](./summary.md) for an example of using `<para>`.

## See also

- [C# programming guide](../index.md)
- [Recommended tags for documentation comments](./recommended-tags-for-documentation-comments.md)
