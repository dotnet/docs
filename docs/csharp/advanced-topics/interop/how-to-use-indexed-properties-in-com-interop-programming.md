---
title: "How to use indexed properties in COM interop programming"
description: Learn how indexed properties improve the way C# objects consume COM properties that have parameters.
ms.date: 02/15/2023
ms.topic: how-to
helpviewer_keywords: 
  - "indexed properties [C#]"
  - "Office programming [C#], indexed properties"
  - "properties [C#], indexed"
---
# How to use indexed properties in COM interop programming

Indexed properties work together with other features in C#, such as [named and optional arguments](../../programming-guide/classes-and-structs/named-and-optional-arguments.md), a new type ([dynamic](../../language-reference/builtin-types/reference-types.md)), and [embedded type information](../../../standard/assembly/embed-types-visual-studio.md), to enhance Microsoft Office programming.

[!INCLUDE[vsto_framework](../../includes/vsto-framework.md)]

In earlier versions of C#, methods are accessible as properties only if the `get` method has no parameters and the `set` method has one and only one value parameter. However, not all COM properties meet those restrictions. For example, the Excel <xref:Microsoft.Office.Interop.Excel.Range.Range%2A> property has a `get` accessor that requires a parameter for the name of the range. In the past, because you couldn't access the `Range` property directly, you had to use the `get_Range` method instead, as shown in the following example.

:::code language="csharp" source="snippets/IndexedProperties/Program.cs" id="Snippet1":::

Indexed properties enable you to write the following instead:

:::code language="csharp" source="snippets/IndexedProperties/Program.cs" id="Snippet2":::

The previous example also uses the [optional arguments](../../programming-guide/classes-and-structs/named-and-optional-arguments.md) feature, which enables you to omit `Type.Missing`.

Indexed properties enable you to write the following code.

:::code language="csharp" source="snippets/IndexedProperties/Program.cs" id="Snippet4":::

You can't create indexed properties of your own. The feature only supports consumption of existing indexed properties.
  
## Example

The following code shows a complete example. For more information about how to set up a project that accesses the Office API, see [How to access Office interop objects by using C# features](./how-to-access-office-interop-objects.md).

:::code language="csharp" source="snippets/IndexedProperties/Program.cs" id="Snippet5":::

## See also

- [Named and Optional Arguments](../../programming-guide/classes-and-structs/named-and-optional-arguments.md)
- [dynamic](../../language-reference/builtin-types/reference-types.md)
- [Using Type dynamic](using-type-dynamic.md)
