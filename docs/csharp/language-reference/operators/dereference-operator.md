---
title: "-&gt; Operator - C# Reference"
ms.custom: seodec18

ms.date: 11/26/2018
f1_keywords: 
  - "->_CSharpKeyword"
helpviewer_keywords: 
  - "member access operator (->) [C#]"
  - "-> operator [C#]"
ms.assetid: e39ccdc1-f1ff-4a92-bf1d-ac2c8c11316a
---
# -&gt; Operator (C# Reference)

The pointer member access operator `->` combines pointer indirection and member access.

If `x` is a pointer of the type `T*` and `y` is an accessible member of `T`, an expression of the form

```csharp
x->y
```

is equivalent to

```csharp
(*x).y
```

The `->` operator requires [unsafe](../keywords/unsafe.md) context.

For more information, see [How to: access a member with a pointer](../../programming-guide/unsafe-code-pointers/how-to-access-a-member-with-a-pointer.md).

## Operator overloadability

The `->` operator cannot be overloaded.

## C# language specification

For more information, see the [Pointer member access](~/_csharplang/spec/unsafe-code.md#pointer-member-access) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Operators](index.md)
- [Pointer types](../../programming-guide/unsafe-code-pointers/pointer-types.md)
