---
title: "Pointer related operators - access memory and dereference memory locations"
description: "Learn about C# operators that you can use when working with pointers. You use these operators to access memory, index memory locations and dereference the storage at a memory location"
ms.date: 01/20/2026
author: pkulikov
f1_keywords: 
  - "->_CSharpKeyword"
helpviewer_keywords: 
  - "pointer related operators [C#]"
  - "address-of operator [C#]"
  - "& operator [C#]"
  - "pointer indirection operator [C#]"
  - "dereference operator [C#]"
  - "* operator [C#]"
  - "pointer member access operator [C#]"
  - "-> operator [C#]"
  - "pointer element access [C#]"
  - "[] operator [C#]"
  - "pointer arithmetic [C#]"
  - "pointer increment [C#]"
  - "pointer decrement [C#]"
  - "pointer comparison [C#]"
---
# Pointer related operators - take the address of variables, dereference storage locations, and access memory locations

The pointer operators enable you to take the address of a variable (`&`), dereference a pointer (`*`), compare pointer values, and add or subtract pointers and integers.

[!INCLUDE[csharp-version-note](../includes/initial-version.md)]

Use the following operators to work with pointers:

- Unary [`&` (address-of)](#address-of-operator-) operator: to get the address of a variable
- Unary [`*` (pointer indirection)](#pointer-indirection-operator-) operator: to get the variable pointed to by a pointer
- The [`->` (member access)](#pointer-member-access-operator--) and [`[]` (element access)](#pointer-element-access-operator-) operators
- Arithmetic operators [`+`, `-`, `++`, and `--`](#pointer-arithmetic-operators)
- Comparison operators [`==`, `!=`, `<`, `>`, `<=`, and `>=`](#pointer-comparison-operators)

For information about pointer types, see [Pointer types](../unsafe-code.md#pointer-types).

> [!NOTE]
> Any operation with pointers requires an [unsafe](../keywords/unsafe.md) context. You must compile the code that contains unsafe blocks with the [**AllowUnsafeBlocks**](../compiler-options/language.md#allowunsafeblocks) compiler option.

## <a name="address-of-operator-"></a> Address-of operator &amp;

The unary `&` operator returns the address of its operand:

:::code language="csharp" source="snippets/shared/PointerOperators.cs" id="AddressOf":::

The operand of the `&` operator must be a fixed variable. *Fixed* variables are variables that reside in storage locations the [garbage collector](../../../standard/garbage-collection/index.md) doesn't affect. In the preceding example, the local variable `number` is a fixed variable because it resides on the stack. Variables that reside in storage locations the garbage collector can affect (for example, relocate) are called *movable* variables. Object fields and array elements are examples of movable variables. You can get the address of a movable variable if you "fix", or "pin", it by using a [`fixed` statement](../statements/fixed.md). The obtained address is valid only inside the block of a `fixed` statement. The following example shows how to use a `fixed` statement and the `&` operator:

:::code language="csharp" source="snippets/shared/PointerOperators.cs" id="AddressOfFixed":::

You can't get the address of a constant or a value.

For more information about fixed and movable variables, see the [Fixed and moveable variables](~/_csharpstandard/standard/unsafe-code.md#244-fixed-and-moveable-variables) section of the [C# language specification](~/_csharpstandard/standard/README.md).

The binary `&` operator computes the [logical AND](boolean-logical-operators.md#logical-and-operator-) of its Boolean operands or the [bitwise logical AND](bitwise-and-shift-operators.md#logical-and-operator-) of its integral operands.

## Pointer indirection operator *

The unary pointer indirection operator `*` accesses the variable to which its operand points. It's also known as the dereference operator. The operand of the `*` operator must be of a pointer type.

:::code language="csharp" source="snippets/shared/PointerOperators.cs" id="PointerIndirection":::

You can't apply the `*` operator to an expression of type `void*`.

The binary `*` operator computes the [product](arithmetic-operators.md#multiplication-operator-) of its numeric operands.

## Pointer member access operator `->`

The `->` operator combines [pointer indirection](#pointer-indirection-operator-) and [member access](member-access-operators.md#member-access-expression-). If `x` is a pointer of type `T*` and `y` is an accessible member of type `T`, an expression of the form

```csharp
x->y
```

is equivalent to

```csharp
(*x).y
```

The following example demonstrates the usage of the `->` operator:

:::code language="csharp" source="snippets/shared/PointerOperators.cs" id="MemberAccess":::

You can't use the `->` operator on an expression of type `void*`.

## Pointer element access operator `[]`

For an expression `p` of a pointer type, a pointer element access of the form `p[n]` is evaluated as `*(p + n)`. The value `n` must be of a type implicitly convertible to `int`, `uint`, `long`, or `ulong`. For information about the behavior of the `+` operator with pointers, see the [Addition or subtraction of an integral value to or from a pointer](#adding-or-subtracting-an-integral-value-to-or-from-a-pointer) section.

The following example demonstrates how to access array elements by using a pointer and the `[]` operator:

:::code language="csharp" source="snippets/shared/PointerOperators.cs" id="ElementAccess":::

In the preceding example, a [`stackalloc` expression](stackalloc.md) allocates a block of memory on the stack.

> [!NOTE]
> The pointer element access operator doesn't check for out-of-bounds errors.

You can't use `[]` for pointer element access with an expression of type `void*`.

You can also use the `[]` operator for [array element or indexer access](member-access-operators.md#indexer-operator-).

## Pointer arithmetic operators

You can perform the following arithmetic operations with pointers:

- Add or subtract an integral value to or from a pointer
- Subtract two pointers
- Increment or decrement a pointer

You can't perform those operations with pointers of type `void*`.

For information about supported arithmetic operations by using numeric types, see [Arithmetic operators](arithmetic-operators.md).

### Add or subtract an integral value to or from a pointer

For a pointer `p` of type `T*` and an expression `n` of a type implicitly convertible to `int`, `uint`, `long`, or `ulong`, addition and subtraction work as follows:

- Both `p + n` and `n + p` give you a pointer of type `T*`. You get this pointer by adding `n * sizeof(T)` to the address that `p` points to.
- The `p - n` expression gives you a pointer of type `T*`. You get this pointer by subtracting `n * sizeof(T)` from the address that `p` points to.

The [`sizeof` operator](sizeof.md) gets the size of a type in bytes.

The following example shows how to use the `+` operator with a pointer:

:::code language="csharp" source="snippets/shared/PointerOperators.cs" id="AddNumber":::

### Pointer subtraction

For two pointers `p1` and `p2` of type `T*`, the expression `p1 - p2` gives you the difference between the addresses that `p1` and `p2` point to, divided by `sizeof(T)`. The result is of type `long`. In other words, `p1 - p2` is calculated as `((long)(p1) - (long)(p2)) / sizeof(T)`.

The following example shows pointer subtraction:

:::code language="csharp" source="snippets/shared/PointerOperators.cs" id="SubtractPointers":::

### Pointer increment and decrement

The `++` increment operator [adds](#adding-or-subtracting-an-integral-value-to-or-from-a-pointer) 1 to its pointer operand. The `--` decrement operator [subtracts](#adding-or-subtracting-an-integral-value-to-or-from-a-pointer) 1 from its pointer operand.

Both operators support two forms: postfix (`p++` and `p--`) and prefix (`++p` and `--p`). The result of `p++` and `p--` is the value of `p` *before* the operation. The result of `++p` and `--p` is the value of `p` *after* the operation.

The following example demonstrates the behavior of both postfix and prefix increment operators:

:::code language="csharp" source="snippets/shared/PointerOperators.cs" id="Increment":::

## Pointer comparison operators

You can use the `==`, `!=`, `<`, `>`, `<=`, and `>=` operators to compare operands of any pointer type, including `void*`. These operators compare the addresses given by the two operands as if they're unsigned integers.

For information about the behavior of those operators for operands of other types, see the [Equality operators](equality-operators.md) and [Comparison operators](comparison-operators.md) articles.

## Operator precedence

The following list orders pointer related operators starting from the highest precedence to the lowest:

- Postfix increment `x++` and decrement `x--` operators and the `->` and `[]` operators
- Prefix increment `++x` and decrement `--x` operators and the `&` and `*` operators
- Additive `+` and `-` operators
- Comparison `<`, `>`, `<=`, and `>=` operators
- Equality `==` and `!=` operators

Use parentheses, `()`, to change the order of evaluation imposed by operator precedence.

For the complete list of C# operators ordered by precedence level, see the [Operator precedence](index.md#operator-precedence) section of the [C# operators](index.md) article.

## Operator overloadability

You can't overload the pointer-related operators `&`, `*`, `->`, and `[]` in a user-defined type.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [Fixed and moveable variables](~/_csharpstandard/standard/unsafe-code.md#244-fixed-and-moveable-variables)
- [The address-of operator](~/_csharpstandard/standard/unsafe-code.md#2465-the-address-of-operator)
- [Pointer indirection](~/_csharpstandard/standard/unsafe-code.md#2462-pointer-indirection)
- [Pointer member access](~/_csharpstandard/standard/unsafe-code.md#2463-pointer-member-access)
- [Pointer element access](~/_csharpstandard/standard/unsafe-code.md#2464-pointer-element-access)
- [Pointer arithmetic](~/_csharpstandard/standard/unsafe-code.md#2467-pointer-arithmetic)
- [Pointer increment and decrement](~/_csharpstandard/standard/unsafe-code.md#2466-pointer-increment-and-decrement)
- [Pointer comparison](~/_csharpstandard/standard/unsafe-code.md#2468-pointer-comparison)

## See also

- [C# operators and expressions](index.md)
- [Unsafe code, pointer types, and function pointers](../unsafe-code.md)
- [unsafe keyword](../keywords/unsafe.md)
- [fixed statement](../statements/fixed.md)
- [stackalloc expression](stackalloc.md)
- [sizeof operator](sizeof.md)
