---
title: "<permission> - C# programming guide"
ms.date: 07/20/2015
f1_keywords:
  - "permission"
  - "<permission>"
helpviewer_keywords:
  - "<permission> C# XML tag"
  - "permission C# XML tag"
ms.assetid: 769e93fe-8404-443f-bf99-577aa42b6a49
---
# \<permission> (C# programming guide)

## Syntax

```xml
<permission cref="member">description</permission>
```

## Parameters

- cref = " `member`"

  A reference to a member or field that is available to be called from the current compilation environment. The compiler checks that the given code element exists and translates `member` to the canonical element name in the output XML. *member* must appear within double quotation marks (" ").

  For information on how to create a cref reference to a generic type, see [cref attribute](./cref-attribute.md).

- `description`

  A description of the access to the member.

## Remarks

The \<permission> tag lets you document the access of a member. The <xref:System.Security.PermissionSet> class lets you specify access to a member.

Compile with [-doc](../../language-reference/compiler-options/doc-compiler-option.md) to process documentation comments to a file.

## Example

[!code-csharp[csProgGuideDocComments#8](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#8)]

## See also

- [C# programming guide](../index.md)
- [Recommended tags for documentation comments](./recommended-tags-for-documentation-comments.md)
