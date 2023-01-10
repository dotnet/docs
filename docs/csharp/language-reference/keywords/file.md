---
description: "file modifier: Declare types whose scope is the file in which it's declared"
title: "file keyword - C# Reference"
ms.date: 09/15/2022
f1_keywords: 
  - "file_CSharpKeyword"
helpviewer_keywords: 
  - "file keyword [C#]"
---
# file (C# Reference)

Beginning with C# 11, the `file` contextual keyword is a type modifier.

The `file` modifier restricts a top-level type's scope and visibility to the file in which it's declared. The `file` modifier will generally be applied to types written by a source generator. File-local types provide source generators with a convenient way to avoid name collisions among generated types. The `file` modifier declares a file-local type, as in this example:

```csharp
file class HiddenWidget
{
    // implementation
}
```

Any types nested within a file-local type are also only visible within the file in which it's declared. Other types in an assembly may use the same name as a file-local type. Because the file-local type is visible only in the file where it's declared, these types don't create a naming collision.

A file-local type can't be the return type or parameter type of any member that is more visible than `file` scope. A file-local type can't be a field member of a type that has greater visibility than `file` scope. However, a more visible type may implicitly implement a file-local interface type. The type can also [explicitly implement](../../programming-guide/interfaces/explicit-interface-implementation.md) a file-local interface but explicit implementations can only be used within the `file` scope.

## Example

The following example shows a public type that uses a file-local type to provide a worker method. In addition, the public type implements a file-local interface implicitly:

:::code language="csharp" source="./snippets/FileScoped.cs" id="FileScopedType":::

In another source file, you can declare types that have the same names as the file-local types. The file-local types aren't visible:

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
