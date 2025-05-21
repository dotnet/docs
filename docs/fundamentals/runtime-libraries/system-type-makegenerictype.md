---
title: System.Type.MakeGenericType method
description: Learn about the System.Type.MakeGenericType method.
ms.date: 01/24/2024
dev_langs:
  - CSharp
  - FSharp
  - VB
ms.topic: article
---
# System.Type.MakeGenericType method

[!INCLUDE [context](includes/context.md)]

The <xref:System.Type.MakeGenericType%2A> method allows you to write code that assigns specific types to the type parameters of a generic type definition, thus creating a <xref:System.Type> object that represents a particular constructed type. You can use this <xref:System.Type> object to create run-time instances of the constructed type.

Types constructed with <xref:System.Type.MakeGenericType%2A> can be open, that is, some of their type arguments can be type parameters of enclosing generic methods or types. You might use such open constructed types when you emit dynamic assemblies. For example, consider the classes `Base` and `Derived` in the following code.

:::code language="csharp" source="./snippets/System/Type/MakeGenericType/csharp/remarks.cs" id="Snippet1":::
:::code language="fsharp" source="./snippets/System/Type/MakeGenericType/fsharp/remarks.fs" id="Snippet1":::
:::code language="vb" source="./snippets/System/Type/MakeGenericType/vb/remarks.vb" id="Snippet1":::

To generate `Derived` in a dynamic assembly, it is necessary to construct its base type. To do this, call the <xref:System.Type.MakeGenericType%2A> method on a <xref:System.Type> object representing the class `Base`, using the generic type arguments <xref:System.Int32> and the type parameter `V` from `Derived`. Because types and generic type parameters are both represented by <xref:System.Type> objects, an array containing both can be passed to the <xref:System.Type.MakeGenericType%2A> method.

> [!NOTE]
> A constructed type such as `Base<int, V>` is useful when emitting code, but you cannot call the <xref:System.Type.MakeGenericType%2A> method on this type because it is not a generic type definition. To create a closed constructed type that can be instantiated, first call the <xref:System.Type.GetGenericTypeDefinition%2A> method to get a <xref:System.Type> object representing the generic type definition and then call <xref:System.Type.MakeGenericType%2A> with the desired type arguments.

The <xref:System.Type> object returned by <xref:System.Type.MakeGenericType%2A> is the same as the <xref:System.Type> obtained by calling the <xref:System.Object.GetType%2A> method of the resulting constructed type, or the <xref:System.Object.GetType%2A> method of any constructed type that was created from the same generic type definition using the same type arguments.

> [!NOTE]
> An array of generic types is not itself a generic type. You cannot call <xref:System.Type.MakeGenericType%2A> on an array type such as `C<T>[]` (`Dim ac() As C(Of T)` in Visual Basic). To construct a closed generic type from `C<T>[]`, call <xref:System.Type.GetElementType%2A> to obtain the generic type definition `C<T>`; call <xref:System.Type.MakeGenericType%2A> on the generic type definition to create the constructed type; and finally call the <xref:System.Type.MakeArrayType%2A> method on the constructed type to create the array type. The same is true of pointer types and `ref` types (`ByRef` in Visual Basic).

For a list of the invariant conditions for terms used in generic reflection, see the <xref:System.Type.IsGenericType> property remarks.

## Nested types

If a generic type is defined using C#, C++, or Visual Basic, then its nested types are all generic. This is true even if the nested types have no type parameters of their own, because all three languages include the type parameters of enclosing types in the type parameter lists of nested types. Consider the following classes:

:::code language="csharp" source="./snippets/System/Type/MakeGenericType/csharp/remarks.cs" id="Snippet2":::
:::code language="vb" source="./snippets/System/Type/MakeGenericType/vb/remarks.vb" id="Snippet2":::

The type parameter list of the nested class `Inner` has two type parameters, `T` and `U`, the first of which is the type parameter of its enclosing class. Similarly, the type parameter list of the nested class `Innermost1` has three type parameters, `T`, `U`, and `V`, with `T` and `U` coming from its enclosing classes. The nested class `Innermost2` has two type parameters, `T` and `U`, which come from its enclosing classes.

If the parameter list of the enclosing type has more than one type parameter, all the type parameters in order are included in the type parameter list of the nested type.

To construct a generic type from the generic type definition for a nested type, call the <xref:System.Type.MakeGenericType%2A> method with the array formed by concatenating the type argument arrays of all the enclosing types, beginning with the outermost generic type, and ending with the type argument array of the nested type itself, if it has type parameters of its own. To create an instance of `Innermost1`, call the <xref:System.Type.MakeGenericType%2A> method with an array containing three types, to be assigned to T, U, and V. To create an instance of `Innermost2`, call the <xref:System.Type.MakeGenericType%2A> method with an array containing two types, to be assigned to T and U.

The languages propagate the type parameters of enclosing types in this fashion so you can use the type parameters of an enclosing type to define fields of nested types. Otherwise, the type parameters would not be in scope within the bodies of the nested types. It is possible to define nested types without propagating the type parameters of enclosing types, by emitting code in dynamic assemblies or by using the [Ilasm.exe (IL Assembler)](../../framework/tools/ilasm-exe-il-assembler.md). Consider the following code for the CIL assembler:

```msil
.class public Outer<T> {
    .class nested public Inner<U> {
        .class nested public Innermost {
        }
    }
}
```

In this example, it is not possible to define a field of type `T` or `U` in class `Innermost`, because those type parameters are not in scope. The following assembler code defines nested classes that behave the way they would if defined in C++, Visual Basic, and C#:

```msil
.class public Outer<T> {
    .class nested public Inner<T, U> {
        .class nested public Innermost<T, U, V> {
        }
    }
}
```

You can use the [Ildasm.exe (IL Disassembler)](../../framework/tools/ildasm-exe-il-disassembler.md) to examine nested classes defined in the high-level languages and observe this naming scheme.
