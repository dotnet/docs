---
title: "XML documentation comments - C# programming guide"
description: Learn about XML documentation comments. You can create documentation for your code by including XML elements in special comment fields.
ms.date: 07/20/2015
ms.topic: conceptual
f1_keywords:
  - "cs.xml"
helpviewer_keywords:
  - "XML [C#], code comments"
  - "comments [C#], XML"
  - "documentation comments [C#]"
  - "C# source code files"
  - "C# language, XML code comments"
  - "XML documentation comments [C#]"
ms.assetid: 803b7f7b-7428-4725-b5db-9a6cff273199
---
# XML documentation comments (C# programming guide)

In C#, you can create documentation for your code by including XML elements in special comment fields (indicated by triple slashes) in the source code directly before the code block to which the comments refer, for example.

```csharp
/// <summary>
///  This class performs an important function.
/// </summary>
public class MyClass {}
```

When you compile with the [**DocumentationFile**](../../language-reference/compiler-options/output.md#documentationfile) option, the compiler will search for all XML tags in the source code and create an XML documentation file. To create the final documentation based on the compiler-generated file, you can create a custom tool or use a tool such as [DocFX](https://dotnet.github.io/docfx/) or [Sandcastle](https://github.com/EWSoftware/SHFB).

To refer to XML elements (for example, your function processes specific XML elements that you want to describe in an XML documentation comment), you can use the standard quoting mechanism (`<` and `>`).  To refer to generic identifiers in code reference (`cref`) elements, you can use either the escape characters (for example, `cref="List&lt;T&gt;"`) or braces (`cref="List{T}"`).  As a special case, the compiler parses the braces as angle brackets to make the documentation comment less cumbersome to author when referring to generic identifiers.

> [!NOTE]
> The XML documentation comments are not metadata; they are not included in the compiled assembly and therefore they are not accessible through reflection.

## In this section

- [Recommended tags for documentation comments](./recommended-tags-for-documentation-comments.md)

- [Processing the XML file](./processing-the-xml-file.md)

- [Delimiters for documentation tags](./delimiters-for-documentation-tags.md)

- [How to use the XML documentation features](./how-to-use-the-xml-documentation-features.md)

## Related sections

For more information, see:

- [**DocumentationFile** (Process Documentation Comments)](../../language-reference/compiler-options/output.md#documentationfile)

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Programming Guide](../index.md)
