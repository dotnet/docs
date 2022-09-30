---
description: "file access modifier: Declare types whose scope is the file in which it's declared"
title: "file keyword - C# Reference"
ms.date: 09/15/2022
f1_keywords: 
  - "file_CSharpKeyword"
  - "file"
helpviewer_keywords: 
  - "file keyword [C#]"
---
# file (C# Reference)

Beginning with C# 11, the `file` contextual keyword is a type access modifier.

File-scoped access restricts a top-level type's scope and visibility to the file in which it's declared. The `file` accessor modifier will generally be applied to types written by a source generator. File scoped types provide source generators with a convenient way to avoid name collisions among generated types. The `file` access modifier declares a file-scoped type, as in this example:

```csharp
file class HiddenWidget
{
    // implementation
}
```

Any types nested within a file-based type are also only visible within the file in which it's declared. Other types in an assembly may use the same name as a file-scoped type. Because the file-scoped type is visible only in the file where it's declared, these types don't create a naming collision.

A file-scoped type can't be the return type or parameter type of any member that is more visible than `file` scope. A file-scoped type can't be a field member of a type that has greater visibility than `file` scope. However, a more visible type may implicitly implement a file-scoped interface type. The type can't [explicitly implement](../../programming-guide/interfaces/explicit-interface-implementation.md) a file scoped interface.

## Example

The following example shows a public type that uses a file-scoped type to provide a worker method. In addition, the public type implements a file-scoped interface implicitly:

:::code language="csharp" source="./snippets/FileScoped.cs" id="FileScopedType":::

In another source file, you can declare types that have the same names as the file-scoped types. The file-scoped types aren't visible:

:::code language="csharp" source="./snippets/Program.cs" id="ShadowsFileScopedType":::

## C# language specification  

For more information, see [Declared accessibility](~/_csharpstandard/standard/basic-concepts.md#752-declared-accessibility) in the [C# Language Specification](~/_csharpstandard/standard/README.md), and the [C# 11 - File local types](~/_csharplang/proposals/csharp-11.0/file-local-types.md) feature specification.

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [Access Modifiers](access-modifiers.md)
- [Accessibility Levels](accessibility-levels.md)
- [Modifiers](index.md)
- [public](public.md)
- [protected](protected.md)
- [internal](internal.md)
