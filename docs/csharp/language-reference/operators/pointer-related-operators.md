---
title: "Pointer related operators - C# reference"
description: "Learn about C# operators that you can use when working with pointers."
ms.date: 05/20/2019
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
# Pointer related operators (C# reference)

You can use the following operators to work with pointers:

- Unary [`&` (address-of)](#address-of-operator-) operator: to get the address of a variable
- Unary [`*` (pointer indirection)](#pointer-indirection-operator-) operator: to obtain the variable pointed by a pointer
- The [`->` (member access)](#pointer-member-access-operator--) and [`[]` (element access)](#pointer-element-access-operator-) operators
- Arithmetic operators [`+`, `-`, `++`, and `--`](#pointer-arithmetic-operators)
- Comparison operators [`==`, `!=`, `<`, `>`, `<=`, and `>=`](#pointer-comparison-operators)

For information about pointer types, see [Pointer types](../../programming-guide/unsafe-code-pointers/pointer-types.md).

> [!NOTE]
> Any operation with pointers requires an [unsafe](../keywords/unsafe.md) context. The code that contains unsafe blocks must be compiled with the [`-unsafe`](../compiler-options/unsafe-compiler-option.md) compiler option.

## <a name="address-of-operator-"></a> Address-of operator &amp;

The unary `&` operator returns the address of its operand:

[!code-csharp[address of local](~/samples/csharp/language-reference/operators/PointerOperators.cs#AddressOf)]

The operand of the `&` operator must be a fixed variable. *Fixed* variables are variables that reside in storage locations that are unaffected by operation of the [garbage collector](../../../standard/garbage-collection/index.md). In the preceding example, the local variable `number` is a fixed variable, because it resides on the stack. Variables that reside in storage locations that can be affected by the garbage collector (for example, relocated) are called *movable* variables. Object fields and array elements are examples of movable variables. You can get the address of a movable variable if you "fix", or "pin", it with the [fixed](../keywords/fixed-statement.md) statement. The obtained address is valid only for the duration of the `fixed` statement block. The following example shows how to use the `fixed` statement and the `&` operator:

[!code-csharp[address of fixed](~/samples/csharp/language-reference/operators/PointerOperators.cs#AddressOfFixed)]

You can't get the address of a constant or a value.

For more information about fixed and movable variables, see the [Fixed and moveable variables](~/_csharplang/spec/unsafe-code.md#fixed-and-moveable-variables) section of the [C# language specification](~/_csharplang/spec/introduction.md).

The binary `&` operator computes the [logical AND](boolean-logical-operators.md#logical-and-operator-) of its Boolean operands or the [bitwise logical AND](bitwise-and-shift-operators.md#logical-and-operator-) of its integral operands.

## Pointer indirection operator *

The unary pointer indirection operator `*` obtains the variable to which its operand points. It's also known as the dereference operator. The operand of the `*` operator must be of a pointer type.

[!code-csharp[pointer indirection](~/samples/csharp/language-reference/operators/PointerOperators.cs#PointerIndirection)]

You cannot apply the `*` operator to an expression of type `void*`.

The binary `*` operator computes the [product](arithmetic-operators.md#multiplication-operator-) of its numeric operands.

## Pointer member access operator ->

The `->` operator combines [pointer indirection](#pointer-indirection-operator-) and [member access](member-access-operators.md#member-access-operator-). That is, if `x` is a pointer of type `T*` and `y` is an accessible member of `T`, an expression of the form

```csharp
x->y
```

is equivalent to

```csharp
(*x).y
```

The following example demonstrates the usage of the `->` operator:

[!code-csharp[pointer member access](~/samples/csharp/language-reference/operators/PointerOperators.cs#MemberAccess)]

You cannot apply the `->` operator to an expression of type `void*`.

## Pointer element access operator []

For an expression `p` of a pointer type, a pointer element access of the form `p[n]` is evaluated as `*(p + n)`, where `n` must be of a type implicitly convertible to `int`, `uint`, `long`, or `ulong`. For information about the behavior of the `+` operator with pointers, see the [Addition or subtraction of an integral value to or from a pointer](#addition-or-subtraction-of-an-integral-value-to-or-from-a-pointer) section.

The following example demonstrates how to access array elements with a pointer and the `[]` operator:

[!code-csharp[pointer element access](~/samples/csharp/language-reference/operators/PointerOperators.cs#ElementAccess)]

The example uses the [`stackalloc` operator](stackalloc.md) to allocate a block of memory on the stack.

> [!NOTE]
> The pointer element access operator doesn't check for out-of-bounds errors.

You cannot use `[]` for pointer element access with an expression of type `void*`.

You also can use the `[]` operator for [array element or indexer access](member-access-operators.md#indexer-operator-).

## Pointer arithmetic operators

You can perform the following arithmetic operations with pointers:

- Add or subtract an integral value to or from a pointer
- Subtract two pointers
- Increment or decrement a pointer

You cannot perform those operations with pointers of type `void*`.

For information about supported arithmetic operations with numeric types, see [Arithmetic operators](arithmetic-operators.md).

### Addition or subtraction of an integral value to or from a pointer

For a pointer `p` of type `T*` and an expression `n` of a type implicitly convertible to `int`, `uint`, `long`, or `ulong`, addition and subtraction are defined as follows:

- Both `p + n` and `n + p` expressions produce a pointer of type `T*` that results from adding `n * sizeof(T)` to the address given by `p`.
- The `p - n` expression produces a pointer of type `T*` that results from subtracting `n * sizeof(T)` from the address given by `p`.

The [`sizeof` operator](sizeof.md) obtains the size of a type in bytes.

The following example demonstrates the usage of the `+` operator with a pointer:

[!code-csharp[pointer addition](~/samples/csharp/language-reference/operators/PointerOperators.cs#AddNumber)]

### Pointer subtraction

For two pointers `p1` and `p2` of type `T*`, the expression `p1 - p2` produces the difference between the addresses given by `p1` and `p2` divided by `sizeof(T)`. The type of the result is `long`. That is, `p1 - p2` is computed as `((long)(p1) - (long)(p2)) / sizeof(T)`.

The following example demonstrates the pointer subtraction:

[!code-csharp[pointer subtraction](~/samples/csharp/language-reference/operators/PointerOperators.cs#SubtractPointers)]

### Pointer increment and decrement

The `++` increment operator [adds](#addition-or-subtraction-of-an-integral-value-to-or-from-a-pointer) 1 to its pointer operand. The `--` decrement operator [subtracts](#addition-or-subtraction-of-an-integral-value-to-or-from-a-pointer) 1 from its pointer operand.

Both operators are supported in two forms: postfix (`p++` and `p--`) and prefix (`++p` and `--p`). The result of `p++` and `p--` is the value of `p` *before* the operation. The result of `++p` and `--p` is the value of `p` *after* the operation.

The following example demonstrates the behavior of both postfix and prefix increment operators:

[!code-csharp[pointer increment](~/samples/csharp/language-reference/operators/PointerOperators.cs#Increment)]

## Pointer comparison operators

You can use the `==`, `!=`, `<`, `>`, `<=`, and `>=` operators to compare operands of any pointer type, including `void*`. Those operators compare the addresses given by the two operands as if they were unsigned integers.

For information about the behavior of those operators for operands of other types, see the [Equality operators](equality-operators.md) and [Comparison operators](comparison-operators.md) articles.

## Operator precedence

The following list orders pointer related operators starting from the highest precedence to the lowest:

- Postfix increment `x++` and decrement `x--` operators and the `->` and `[]` operators
- Prefix increment `++x` and decrement `--x` operators and the `&` and `*` operators
- Additive `+` and `-` operators
- Comparison `<`, `>`, `<=`, and `>=` operators
- Equality `==` and `!=` operators

Use parentheses, `()`, to change the order of evaluation imposed by operator precedence.

For the complete list of C# operators ordered by precedence level, see [C# operators](index.md).

## Operator overloadability

A user-defined type cannot overload the pointer related operators `&`, `*`, `->`, and `[]`.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [Fixed and moveable variables](~/_csharplang/spec/unsafe-code.md#fixed-and-moveable-variables)
- [The address-of operator](~/_csharplang/spec/unsafe-code.md#the-address-of-operator)
- [Pointer indirection](~/_csharplang/spec/unsafe-code.md#pointer-indirection)
- [Pointer member access](~/_csharplang/spec/unsafe-code.md#pointer-member-access)
- [Pointer element access](~/_csharplang/spec/unsafe-code.md#pointer-element-access)
- [Pointer arithmetic](~/_csharplang/spec/unsafe-code.md#pointer-arithmetic)
- [Pointer increment and decrement](~/_csharplang/spec/unsafe-code.md#pointer-increment-and-decrement)
- [Pointer comparison](~/_csharplang/spec/unsafe-code.md#pointer-comparison)

## See also

- [C# reference](../index.md)
- [C# operators](index.md)
- [Pointer types](../../programming-guide/unsafe-code-pointers/pointer-types.md)
- [unsafe keyword](../keywords/unsafe.md)
- [fixed keyword](../keywords/fixed-statement.md)
- [stackalloc operator](stackalloc.md)
- [sizeof operator](sizeof.md)
