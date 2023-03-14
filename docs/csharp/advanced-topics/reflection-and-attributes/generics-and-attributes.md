---
title: "Generics and Attributes - C# Programming Guide"
description: Learn about applying attributes to generic types. See code examples and view additional available resources.
ms.date: 03/11/2022
helpviewer_keywords: 
  - "generics [C#], attributes"
  - "attributes [C#], with generics"
---
# Generics and Attributes (C# Programming Guide)

Attributes can be applied to generic types in the same way as non-generic types.

Custom attributes are only permitted to reference open generic types, which are generic types for which no type arguments are supplied, and closed constructed generic types, which supply arguments for all type parameters.

The following examples use this custom attribute:

:::code language="csharp" source="./snippets/GenericsAndAttributes.cs" id="CustomAttribute":::

An attribute can reference an open generic type:

:::code language="csharp" source="./snippets/GenericsAndAttributes.cs" id="GenericClassAsAttribute":::

Specify multiple type parameters using the appropriate number of commas. In this example, `GenericClass2` has two type parameters:

:::code language="csharp" source="./snippets/GenericsAndAttributes.cs" id="TypeParameters":::

An attribute can reference a closed constructed generic type:

:::code language="csharp" source="./snippets/GenericsAndAttributes.cs" id="ClosedGeneric":::

An attribute that references a generic type parameter will cause a compile-time error:

```csharp
[CustomAttribute(info = typeof(GenericClass3<int, T, string>))]  //Error CS0416
class ClassD<T> { }
```

Beginning with C# 11, a generic type can inherit from <xref:System.Attribute>:

:::code language="csharp" source="./snippets/GenericsAndAttributes.cs" id="GenericAttribute":::

To obtain information about a generic type or type parameter at run time, you can use the methods of <xref:System.Reflection>. For more information, see [Generics and Reflection](./generics-and-reflection.md).

## See also

- [Generics](../../fundamentals/types/generics.md)
- [Attributes](../../../standard/attributes/index.md)
