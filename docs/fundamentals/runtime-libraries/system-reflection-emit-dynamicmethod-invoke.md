---
title: System.Reflection.Emit.DynamicMethod.Invoke method
description: Learn about the System.Reflection.Emit.DynamicMethod.Invoke method.
ms.date: 02/10/2026
ai-usage: ai-assisted
---
# System.Reflection.Emit.DynamicMethod.Invoke method

[!INCLUDE [context](includes/context.md)]

In addition to the listed exceptions, the calling code should be prepared to catch any exceptions thrown by the dynamic method.

Executing a dynamic method with a delegate created by the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate*> method is more efficient than executing it with the <xref:System.Reflection.Emit.DynamicMethod.Invoke*> method.

Calling the <xref:System.Reflection.Emit.DynamicMethod.Invoke*> method or the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate*> method completes the dynamic method. Any further attempt to alter the dynamic method, such as modifying parameter definitions or emitting more Microsoft intermediate language (MSIL), is ignored; no exception is thrown.

All dynamic methods are static, so the `obj` parameter is always ignored. To treat a dynamic method as if it were an instance method, use the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate(System.Type,System.Object)> overload that takes an object instance.

If the dynamic method has no parameters, the value of `parameters` should be `null`. Otherwise the number, type, and order of elements in the parameters array should be identical to the number, type, and order of parameters of the dynamic method.

> [!NOTE]
> This method overload is called by the <xref:System.Reflection.MethodBase.Invoke(System.Object,System.Object%5B%5D)> method overload inherited from the <xref:System.Reflection.MethodBase> class, so the preceding remarks apply to both overloads.

This method doesn't demand permissions directly, but invoking the dynamic method can result in security demands, depending on the method. For example, no demands are made for anonymously hosted dynamic methods that are created with the `restrictedSkipVisibility` parameter set to `false`. On the other hand, if you create a method with `restrictedSkipVisibility` set to `true` so it can access a hidden member of a target assembly, the method causes a demand for the permissions of the target assembly plus <xref:System.Security.Permissions.ReflectionPermission> with the <xref:System.Security.Permissions.ReflectionPermissionFlag.MemberAccess?displayProperty=nameWithType> flag.

## Examples

The following code example invokes a dynamic method with exact binding, using the US-English culture. This code example is part of a larger example provided for the <xref:System.Reflection.Emit.DynamicMethod> class.

:::code language="csharp" source="~/snippets/csharp/System.Reflection.Emit/DynamicMethod/Overview/source.cs" id="Snippet4":::
:::code language="vb" source="~/snippets/visualbasic/System.Reflection.Emit/DynamicMethod/Overview/source.vb" id="Snippet4":::
