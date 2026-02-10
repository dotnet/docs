---
title: System.Reflection.Emit.DynamicMethod.DefineParameter method
description: Learn about the System.Reflection.Emit.DynamicMethod.DefineParameter method.
ms.date: 02/10/2026
ai-usage: ai-assisted
---
# System.Reflection.Emit.DynamicMethod.DefineParameter method

[!INCLUDE [context](includes/context.md)]

If `position` is 0, the <xref:System.Reflection.Emit.DynamicMethod.DefineParameter*> method refers to the return value. Setting parameter information has no effect on the return value.

If the dynamic method has already been completed, by calling the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate*> or <xref:System.Reflection.Emit.DynamicMethod.Invoke*> method, the <xref:System.Reflection.Emit.DynamicMethod.DefineParameter*> method has no effect. No exception is thrown.

## Examples

The following code example shows how to define parameter information for a dynamic method. This code example is part of a larger example provided for the <xref:System.Reflection.Emit.DynamicMethod> class.

:::code language="csharp" source="./snippets/System.Reflection.Emit/DynamicMethod/Overview/csharp/source.cs" id="Snippet33":::
:::code language="vb" source="./snippets/System.Reflection.Emit/DynamicMethod/Overview/vb/source.vb" id="Snippet33":::
