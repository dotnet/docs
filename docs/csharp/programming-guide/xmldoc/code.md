---
title: "<code> - C# programming guide"
description: Learn about the XML <code> tag. This tag is used to indicate multiple lines of code, while <c> marks single-line text in a description as code.
ms.date: 07/20/2015
f1_keywords:
  - "code"
  - "<code>"
helpviewer_keywords:
  - "code XML tag"
  - "<code> C# XML tag"
ms.assetid: f235e3bc-a709-43cf-8a9f-bd57cabdf6da
---
# \<code> (C# programming guide)

## Syntax

```xml
<code>content</code>
```

## Parameters

- `content`

  The text you want marked as code.

## Remarks

The `<code>` tag is used to indicate multiple lines of code. Use [\<c>](./code-inline.md) to indicate that single-line text within a description should be marked as code.

Compile with [-doc](../../language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.

## Example

See the [\<example>](./example.md) article for an example of how to use the `<code>` tag.

## See also

- [C# programming guide](../index.md)
- [Recommended tags for documentation comments](./recommended-tags-for-documentation-comments.md)
