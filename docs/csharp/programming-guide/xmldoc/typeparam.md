---
title: "<typeparam> - C# programming guide"
description: Learn about the XML <typeparam> tag. This tag is used in the comment for a generic type or method declaration to describe a type parameter.
ms.date: 07/20/2015
f1_keywords:
  - "typeparam"
helpviewer_keywords:
  - "<typeparam> C# XML tag"
  - "typeparam C# XML tag"
ms.assetid: 9b99d400-e911-4e55-99c6-64367c96aa4f
---
# \<typeparam> (C# programming guide)

## Syntax

```xml
<typeparam name="name">description</typeparam>
```

## Parameters

- `name`

  The name of the type parameter. Enclose the name in double quotation marks (" ").

- `description`

  A description for the type parameter.

## Remarks

The `<typeparam>` tag should be used in the comment for a generic type or method declaration to describe a type parameter. Add a tag for each type parameter of the generic type or method.

For more information, see [Generics](../../fundamentals/types/generics.md).

The text for the `<typeparam>` tag will be displayed in IntelliSense, the [Object Browser Window](/visualstudio/ide/viewing-the-structure-of-code#BKMK_ObjectBrowser) code comment web report.

Compile with [**DocumentationFile**](../../language-reference/compiler-options/output.md#documentationfile) to process documentation comments to a file.

## Example

[!code-csharp[csProgGuideDocComments#13](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideDocComments/CS/DocComments.cs#13)]

## See also

- [C# reference](../../language-reference/index.md)
- [C# programming guide](../index.md)
- [Recommended tags for documentation comments](./recommended-tags-for-documentation-comments.md)
