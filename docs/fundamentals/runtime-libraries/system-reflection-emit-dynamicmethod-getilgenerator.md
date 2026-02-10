---
title: System.Reflection.Emit.DynamicMethod.GetILGenerator methods
description: Learn about the System.Reflection.Emit.DynamicMethod.GetILGenerator methods.
ms.date: 02/10/2026
ai-usage: ai-assisted
---
# System.Reflection.Emit.DynamicMethod.GetILGenerator methods

[!INCLUDE [context](includes/context.md)]

## <xref:System.Reflection.Emit.DynamicMethod.GetILGenerator>

After a dynamic method has been completed, by calling the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate*> or <xref:System.Reflection.Emit.DynamicMethod.Invoke*> method, any further attempt to add MSIL is ignored. No exception is thrown.

> [!NOTE]
> There are restrictions on unverifiable code in dynamic methods, even in some full-trust scenarios. See the "Verification" section in Remarks for <xref:System.Reflection.Emit.DynamicMethod>.

### Examples

The following code example creates a dynamic method that takes two parameters. The example emits a simple function body that prints the first parameter to the console, and the example uses the second parameter as the return value of the method. The example completes the method by creating a delegate, invokes the delegate with different parameters, and finally invokes the dynamic method using the <xref:System.Reflection.Emit.DynamicMethod.Invoke*> method.

:::code language="csharp" source="./snippets/System.Reflection.Emit/DynamicMethod/.ctor/csharp/source1.cs" id="Snippet1":::
:::code language="vb" source="./snippets/System.Reflection.Emit/DynamicMethod/.ctor/vb/source1.vb" id="Snippet1":::

## <xref:System.Reflection.Emit.DynamicMethod.GetILGenerator(System.Int32)>

After a dynamic method has been completed, by calling the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate*> or <xref:System.Reflection.Emit.DynamicMethod.Invoke*> method, any further attempt to add MSIL is ignored. No exception is thrown.

> [!NOTE]
> There are restrictions on unverifiable code in dynamic methods, even in some full-trust scenarios. See the "Verification" section in Remarks for <xref:System.Reflection.Emit.DynamicMethod>.

### Examples

The following code example demonstrates this method overload. This code example is part of a larger example provided for the <xref:System.Reflection.Emit.DynamicMethod> class.

:::code language="csharp" source="./snippets/System.Reflection.Emit/DynamicMethod/Overview/csharp/source.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System.Reflection.Emit/DynamicMethod/Overview/vb/source.vb" id="Snippet2":::
