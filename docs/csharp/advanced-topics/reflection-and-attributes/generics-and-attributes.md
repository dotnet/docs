---
title: "Generics and attributes"
description: Learn about applying attributes to generic types. See code examples and view more available resources.
ms.date: 03/15/2023
helpviewer_keywords: 
  - "generics [C#], attributes"
  - "attributes [C#], with generics"
---
# Generics and Attributes

Attributes can be applied to generic types in the same way as nongeneric types. However, you can apply attributes only on *open generic types* and *closed constructed generic types*, not on *partially constructed generic types*. An *open generic type* is one where none of the type arguments are specified, such as `Dictionary<TKey, TValue>` A *closed constructed generic type* specifies all type arguments, such as `Dictionary<string, object>`. A *partially constructed generic type* specifies some, but not all, type arguments. An example is `Dictionary<string, TValue>`. An *unbound generic type* is one where type arguments are omitted, such as `Dictionary<,>`.

The following examples use this custom attribute:

:::code language="csharp" source="./snippets/conceptual/GenericsAndAttributes.cs" id="CustomAttribute":::

An attribute can reference an unbound generic type:

:::code language="csharp" source="./snippets/conceptual/GenericsAndAttributes.cs" id="GenericClassAsAttribute":::

Specify multiple type parameters using the appropriate number of commas. In this example, `GenericClass2` has two type parameters:

:::code language="csharp" source="./snippets/conceptual/GenericsAndAttributes.cs" id="TypeParameters":::

An attribute can reference a closed constructed generic type:

:::code language="csharp" source="./snippets/conceptual/GenericsAndAttributes.cs" id="ClosedGeneric":::

An attribute that references a generic type parameter causes a compile-time error:

```csharp
[CustomAttribute(info = typeof(GenericClass3<int, T, string>))]  //Error CS0416
class ClassD<T> { }
```

Beginning with C# 11, a generic type can inherit from <xref:System.Attribute>:

:::code language="csharp" source="./snippets/conceptual/GenericsAndAttributes.cs" id="GenericAttribute":::

To obtain information about a generic type or type parameter at run time, you can use the methods of <xref:System.Reflection>. For more information, see [Generics and Reflection](./generics-and-reflection.md).

## See also

- [Generics](../../fundamentals/types/generics.md)
- [Attributes](../../../standard/attributes/index.md)
