---
title: System.Reflection.Emit.DynamicMethod.CreateDelegate methods
description: Learn about the System.Reflection.Emit.DynamicMethod.CreateDelegate methods.
ms.date: 02/10/2026
ai-usage: ai-assisted
---
# System.Reflection.Emit.DynamicMethod.CreateDelegate methods

[!INCLUDE [context](includes/context.md)]

## <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate(System.Type)>

Calling the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate%2A> method or the <xref:System.Reflection.Emit.DynamicMethod.Invoke%2A> method completes the dynamic method. Any further attempt to alter the dynamic method, such as modifying parameter definitions or emitting more Microsoft intermediate language (MSIL), is ignored; no exception is thrown.

To create a method body for a dynamic method when you have your own MSIL generator, call the <xref:System.Reflection.Emit.DynamicMethod.GetDynamicILInfo%2A> method to obtain a <xref:System.Reflection.Emit.DynamicILInfo> object. If you don't have your own MSIL generator, call the <xref:System.Reflection.Emit.DynamicMethod.GetILGenerator%2A> method to obtain an <xref:System.Reflection.Emit.ILGenerator> object that can be used to generate the method body.

### Examples

The following code example creates a dynamic method that takes two parameters. The example emits a simple function body that prints the first parameter to the console, and the example uses the second parameter as the return value of the method. The example completes the method by creating a delegate, invokes the delegate with different parameters, and finally invokes the dynamic method using the <xref:System.Reflection.Emit.DynamicMethod.Invoke%2A> method.

:::code language="csharp" source="~/snippets/csharp/System.Reflection.Emit/DynamicMethod/.ctor/source1.cs" id="Snippet1":::
:::code language="vb" source="~/snippets/visualbasic/System.Reflection.Emit/DynamicMethod/.ctor/source1.vb" id="Snippet1":::

## <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate(System.Type,System.Object)>

This method overload creates a delegate bound to a particular object. Such a delegate is said to be closed over its first argument. Although the method is static, it acts as if it were an instance method; the instance is `target`.

This method overload requires `target` to be of the same type as the first parameter of the dynamic method, or to be assignable to that type (for example, a derived class). The signature of `delegateType` has all the parameters of the dynamic method except the first. For example, if the dynamic method has the parameters <xref:System.String>, <xref:System.Int32>, and <xref:System.Byte>, then `delegateType` has the parameters <xref:System.Int32> and <xref:System.Byte>; `target` is of type <xref:System.String>.

Calling the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate%2A> method or the <xref:System.Reflection.Emit.DynamicMethod.Invoke%2A> method completes the dynamic method. Any further attempt to alter the dynamic method, such as modifying parameter definitions or emitting more Microsoft intermediate language (MSIL), is ignored; no exception is thrown.

To create a method body for a dynamic method when you have your own MSIL generator, call the <xref:System.Reflection.Emit.DynamicMethod.GetDynamicILInfo%2A> method to obtain a <xref:System.Reflection.Emit.DynamicILInfo> object. If you don't have your own MSIL generator, call the <xref:System.Reflection.Emit.DynamicMethod.GetILGenerator%2A> method to obtain an <xref:System.Reflection.Emit.ILGenerator> object that can be used to generate the method body.

### Examples

The following code example creates a delegate that binds a <xref:System.Reflection.Emit.DynamicMethod> to an instance of a type, so that the method acts on the same instance each time it's invoked.

The code example defines a class named `Example` with a private field, a class named `DerivedFromExample` that derives from the first class, a delegate type named `UseLikeStatic` that returns <xref:System.Int32> and has parameters of type `Example` and <xref:System.Int32>, and a delegate type named `UseLikeInstance` that returns <xref:System.Int32> and has one parameter of type <xref:System.Int32>.

The example code then creates a <xref:System.Reflection.Emit.DynamicMethod> that changes the private field of an instance of `Example` and returns the previous value.

> [!NOTE]
> In general, changing the internal fields of classes isn't good object-oriented coding practice.

The example code creates an instance of `Example` and then creates two delegates. The first is of type `UseLikeStatic`, which has the same parameters as the dynamic method. The second is of type `UseLikeInstance`, which lacks the first parameter (of type `Example`). This delegate is created using the <xref:System.Reflection.Emit.DynamicMethod.CreateDelegate%28System.Type%2CSystem.Object%29> method overload; the second parameter of that method overload is an instance of `Example`, in this case the instance just created, which is bound to the newly created delegate. Whenever that delegate is invoked, the dynamic method acts on the bound instance of `Example`.

> [!NOTE]
> This is an example of the relaxed rules for delegate binding introduced in .NET Framework 2.0, along with new overloads of the <xref:System.Delegate.CreateDelegate%2A?displayProperty=nameWithType> method. For more information, see the <xref:System.Delegate> class.

The `UseLikeStatic` delegate is invoked, passing in the instance of `Example` that's bound to the `UseLikeInstance` delegate. Then the `UseLikeInstance` delegate is invoked, so that both delegates act on the same instance of `Example`. The changes in the values of the internal field are displayed after each call. Finally, a `UseLikeInstance` delegate is bound to an instance of `DerivedFromExample`, and the delegate calls are repeated.

:::code language="csharp" source="~/snippets/csharp/System.Reflection.Emit/DynamicMethod/.ctor/source.cs" id="Snippet1":::
:::code language="vb" source="~/snippets/visualbasic/System.Reflection.Emit/DynamicMethod/.ctor/source.vb" id="Snippet1":::
