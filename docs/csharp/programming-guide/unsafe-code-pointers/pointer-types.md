---
title: "Pointer types - C# Programming Guide"
ms.custom: seodec18
ms.date: 04/20/2018
helpviewer_keywords: 
  - "unsafe code [C#], pointers"
  - "pointers [C#]"
---
# Pointer types (C# Programming Guide)

In an unsafe context, a type may be a pointer type, a value type, or a reference type. A pointer type declaration takes one of the following forms:

``` csharp
type* identifier;
void* identifier; //allowed but not recommended
```

The type specified before the `*` in a pointer type is called the **referent type**. Only an [unmanaged type](../../language-reference/builtin-types/unmanaged-types.md) can be a referent type.

Pointer types do not inherit from [object](../../language-reference/keywords/object.md) and no conversions exist between pointer types and `object`. Also, boxing and unboxing do not support pointers. However, you can convert between different pointer types and between pointer types and integral types.

When you declare multiple pointers in the same declaration, the asterisk (*) is written together with the underlying type only; it is not used as a prefix to each pointer name. For example:

```csharp
int* p1, p2, p3;   // Ok
int *p1, *p2, *p3;   // Invalid in C#
```

A pointer cannot point to a reference or to a [struct](../../language-reference/keywords/struct.md) that contains references, because an object reference can be garbage collected even if a pointer is pointing to it. The garbage collector does not keep track of whether an object is being pointed to by any pointer types.

The value of the pointer variable of type `myType*` is the address of a variable of type `myType`. The following are examples of pointer type declarations:

|Example|Description|
|-------------|-----------------|
|`int* p`|`p` is a pointer to an integer.|
|`int** p`|`p` is a pointer to a pointer to an integer.|
|`int*[] p`|`p` is a single-dimensional array of pointers to integers.|
|`char* p`|`p` is a pointer to a char.|
|`void* p`|`p` is a pointer to an unknown type.|

The pointer indirection operator * can be used to access the contents at the location pointed to by the pointer variable. For example, consider the following declaration:

```csharp
int* myVariable;
```

The expression `*myVariable` denotes the `int` variable found at the address contained in `myVariable`.

There are several examples of pointers in the topics [fixed Statement](../../language-reference/keywords/fixed-statement.md) and [Pointer Conversions](../../programming-guide/unsafe-code-pointers/pointer-conversions.md). The following example uses the `unsafe` keyword and the `fixed` statement, and shows how to increment an interior pointer.  You can paste this code into the Main function of a console application to run it. These examples must be compiled with the [-unsafe](../../language-reference/compiler-options/unsafe-compiler-option.md) compiler option set.

[!code-csharp[Using pointer types](../../../../samples/snippets/csharp/keywords/FixedKeywordExamples.cs#5)]

You cannot apply the indirection operator to a pointer of type `void*`. However, you can use a cast to convert a void pointer to any other pointer type, and vice versa.

A pointer can be `null`. Applying the indirection operator to a null pointer causes an implementation-defined behavior.

Passing pointers between methods can cause undefined behavior. Consider a method that returns a pointer to a local variable through an `in`, `out`, or `ref` parameter or as the function result. If the pointer was set in a fixed block, the variable to which it points may no longer be fixed.

The following table lists the operators and statements that can operate on pointers in an unsafe context:

|Operator/Statement|Use|
|-------------------------|---------|
|`*`|Performs pointer indirection.|
|`->`|Accesses a member of a struct through a pointer.|
|`[]`|Indexes a pointer.|
|`&`|Obtains the address of a variable.|
|`++` and `--`|Increments and decrements pointers.|
|`+` and `-`|Performs pointer arithmetic.|
|`==`, `!=`, `<`, `>`, `<=`, and `>=`|Compares pointers.|
|[`stackalloc` operator](../../language-reference/operators/stackalloc.md)|Allocates memory on the stack.|
|[`fixed` statement](../../language-reference/keywords/fixed-statement.md)|Temporarily fixes a variable so that its address may be found.|

For more information about pointer related operators, see [Pointer related operators](../../language-reference/operators/pointer-related-operators.md).

## C# language specification

For more information, see the [Pointer types](~/_csharplang/spec/unsafe-code.md#pointer-types) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# Programming Guide](../index.md)
- [Unsafe Code and Pointers](index.md)
- [Pointer Conversions](pointer-conversions.md)
- [Types](../../language-reference/keywords/types.md)
- [unsafe](../../language-reference/keywords/unsafe.md)
