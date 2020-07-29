---
title: "<list> - C# programming guide"
description: Learn about the XML <list> tag. This tag is used to create tables and definition, bulleted, or numbered lists by using 'item' blocks.
ms.date: 07/20/2015
f1_keywords:
  - "list"
  - "<list>"
helpviewer_keywords:
  - "list C# XML tag"
  - "listheader C# XML tag"
  - "<listheader> C# XML tag"
  - "item C# XML tag"
  - "<item> C# XML tag"
  - "<list> C# XML tag"
ms.assetid: c9620b1b-c2e6-43f1-ab88-8ab47308ffec
---
# \<list> (C# programming guide)

## Syntax

```xml
<list type="bullet|number|table">
    <listheader>
        <term>term</term>
        <description>description</description>
    </listheader>
    <item>
        <term>term</term>
        <description>description</description>
    </item>
</list>
```

## Parameters

- `term`

  A term to define, which will be defined in `description`.

- `description`

  Either an item in a bullet or numbered list or the definition of a `term`.
  
## Remarks

The `<listheader>` block is used to define the heading row of either a table or definition list. When defining a table, you only need to supply an entry for term in the heading.

Each item in the list is specified with an `<item>` block. When creating a definition list, you will need to specify both `term` and `description`. However, for a table, bulleted list, or numbered list, you only need to supply an entry for `description`.

A list or table can have as many `<item>` blocks as needed.

Compile with [-doc](../../language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.

## Example

[!code-csharp[csProgGuideDocComments#6](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#6)]

## See also

- [C# programming guide](../index.md)
- [Recommended tags for documentation comments](./recommended-tags-for-documentation-comments.md)
