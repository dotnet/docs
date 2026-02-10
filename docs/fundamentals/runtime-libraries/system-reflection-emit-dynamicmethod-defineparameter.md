---
title: System.Reflection.Emit.DynamicMethod.DefineParameter method
description: Learn about the System.Reflection.Emit.DynamicMethod.DefineParameter method.
ms.date: 02/10/2026
ai-usage: ai-assisted
---
# System.Reflection.Emit.DynamicMethod.DefineParameter method

[!INCLUDE [context](includes/context.md)]

If `position` is 0, the <xref:System.Reflection.Emit.DynamicMethod.DefineParameter%2A> method refers to the return value. Setting parameter information has no effect on the return value.

If the dynamic method has already been completed, by calling the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate%2A> or <xref:System.Reflection.Emit.DynamicMethod.Invoke%2A> method, the <xref:System.Reflection.Emit.DynamicMethod.DefineParameter%2A> method has no effect. No exception is thrown.

## Examples

The following code example shows how to define parameter information for a dynamic method. This code example is part of a larger example provided for the <xref:System.Reflection.Emit.DynamicMethod> class.

:::code language="csharp" source="~/snippets/csharp/System.Reflection.Emit/DynamicMethod/Overview/source.cs" id="Snippet33":::
:::code language="vb" source="~/snippets/visualbasic/System.Reflection.Emit/DynamicMethod/Overview/source.vb" id="Snippet33":::
