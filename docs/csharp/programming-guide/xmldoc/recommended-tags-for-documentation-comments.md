---
title: "Recommended tags for documentation comments - C# programming guide"
description: Learn about the recommended tags for documentation comments. See a list of recommended tags and view additional available resources.
ms.date: 01/21/2020
ms.topic: conceptual
helpviewer_keywords:
  - "XML [C#], tags"
  - "XML documentation [C#], tags"
ms.assetid: 6e98f7a9-38f4-4d74-b644-1ff1b23320fd
---
# Recommended tags for documentation comments (C# programming guide)

The C# compiler processes documentation comments in your code and formats them as XML in a file whose name you specify in the **/doc** command-line option. To create the final documentation based on the compiler-generated file, you can create a custom tool, or use a tool such as [DocFX](https://dotnet.github.io/docfx/) or [Sandcastle](https://github.com/EWSoftware/SHFB).

Tags are processed on code constructs such as types and type members.

> [!NOTE]
> Documentation comments cannot be applied to a namespace.

The compiler will process any tag that is valid XML. The following tags provide generally used functionality in user documentation.

## Tags

:::row:::
    :::column:::
        [\<c>](./code-inline.md)
    :::column-end:::
    :::column:::
        [\<para>](./para.md)
    :::column-end:::
    :::column:::
        [\<see>](./see.md)*
    :::column-end:::
    :::column:::
        [\<value>](./value.md)
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
        [\<code>](./code.md)
    :::column-end:::
    :::column:::
        [\<param>](./param.md)*
    :::column-end:::
    :::column:::
        [\<seealso>](./seealso.md)*
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
        [\<example>](./example.md)
    :::column-end:::
    :::column:::
        [\<paramref>](./paramref.md)
    :::column-end:::
    :::column:::
        [\<summary>](./summary.md)
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
        [\<exception>](./exception.md)*
    :::column-end:::
    :::column:::
        [\<permission>](./permission.md)*
    :::column-end:::
    :::column:::
        [\<typeparam>](./typeparam.md)*
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
        [\<include>](./include.md)*
    :::column-end:::
    :::column:::
        [\<remarks>](./remarks.md)
    :::column-end:::
    :::column:::
        [\<typeparamref>](./typeparamref.md)
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
        [\<list>](./list.md)
    :::column-end:::
    :::column:::
        [\<inheritdoc>](./inheritdoc.md)
    :::column-end:::
    :::column:::
       [\<returns>](./returns.md)
    :::column-end:::
:::row-end:::

(\* denotes that the compiler verifies syntax.)

If you want angle brackets to appear in the text of a documentation comment, use the HTML encoding of `<` and `>` which is `&lt;` and `&gt;` respectively. This encoding is shown in the following example.

```csharp
/// <summary>
/// This property always returns a value &lt; 1.
/// </summary>
```

## See also

- [C# programming guide](../index.md)
- [**DocumentationFile** (C# compiler options)](../../language-reference/compiler-options/output.md#documentationfile)
- [XML documentation comments](./index.md)
