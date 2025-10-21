---
title: Resolve errors and warnings related to using unsafe code
description: These compiler errors and warnings indicate errors when you work with `unsafe` code. Unsafe code requires special keywords before it's enabled. Unsafe code allows constructs that can introduce memory based errors. These warnings and errors explain common misues.
f1_keywords:
 - "CS0193"
 - "CS0196"
 - "CS0208"
 - "CS0209"
 - "CS0210"
 - "CS0211"
 - "CS0212"
 - "CS0213"
 - "CS0214"
 - "CS0227"
 - "CS0233"
 - "CS0242"
 - "CS0244"
 - "CS0254"
 - "CS0459"
 - "CS0821"
 - "CS1641"
 - "CS1642"
 - "CS1656"
 - "CS1663"
 - "CS1665"
 - "CS1666"
 - "CS1708"
 - "CS4004"
 - "CS1716"
 - "CS1919"
 - "CS8812"
 - "CS9123"
helpviewer_keywords:
 - "CS0193"
 - "CS0196"
 - "CS0208"
 - "CS0209"
 - "CS0210"
 - "CS0211"
 - "CS0212"
 - "CS0213"
 - "CS0214"
 - "CS0227"
 - "CS0233"
 - "CS0242"
 - "CS0244"
 - "CS0254"
 - "CS0459"
 - "CS0821"
 - "CS1641"
 - "CS1642"
 - "CS1656"
 - "CS1663"
 - "CS1665"
 - "CS1666"
 - "CS1708"
 - "CS1716"
 - "CS4004"
 - "CS1919"
 - "CS8812"
 - "CS9123"
ms.date: 10/21/2025
---
# Resolve errors and warnings in unsafe code constructs

This article covers the following compiler errors:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
 - [**CS0193**](#pointer-operations-and-dereferencing): *The \* or -> operator must be applied to a data pointer*
 - [**CS0196**](#pointer-operations-and-dereferencing): *A pointer must be indexed by only one value*
 - [**CS0208**](#pointer-types-and-managed-types): *Cannot take the address of, get the size of, or declare a pointer to a managed type ('type')*
 - [**CS0209**](#fixed-buffers): *The type of local declared in a fixed statement must be a pointer type*
 - [**CS0210**](#fixed-buffers): *You must provide an initializer in a fixed or `using` statement declaration*
 - [**CS0211**](#fixed-buffers): *Cannot take the address of the given expression*
 - [**CS0212**](#fixed-buffers): *You can only take the address of an unfixed expression inside of a fixed statement initializer*
 - [**CS0213**](#fixed-buffers): *You cannot use the fixed statement to take the address of an already fixed expression*
 - [**CS0214**](#unsafe-context-restrictions): *Pointers and fixed size buffers may only be used in an unsafe context*
 - [**CS0227**](#unsafe-context-restrictions): *Unsafe code may only appear if compiling with /unsafe*
 - [**CS0233**](#pointer-types-and-managed-types): *'identifier' does not have a predefined size, therefore sizeof can only be used in an unsafe context*
 - [**CS0242**](#pointer-operations-and-dereferencing): *The operation in question is undefined on void pointers*
 - [**CS0244**](#unsafe-context-restrictions): *Neither 'is' nor 'as' is valid on pointer types*
 - [**CS0254**](#fixed-buffers): *The right hand side of a fixed statement assignment may not be a cast expression*
 - [**CS0459**](#fixed-buffers): *Cannot take the address of a read-only local variable*
 - [**CS0821**](#fixed-buffers): *Implicitly typed locals cannot be fixed*
 - [**CS1641**](#fixed-size-buffers): *A fixed size buffer field must have the array size specifier after the field name*
 - [**CS1642**](#fixed-size-buffers): *Fixed size buffer fields may only be members of structs.*
 - [**CS1656**](#fixed-buffers): *Cannot assign to 'variable' because it is a 'read-only variable type'*
 - [**CS1663**](#fixed-size-buffers): *Fixed size buffer type must be one of the following: bool, byte, short, int, long, char, sbyte, ushort, uint, ulong, float or double*
 - [**CS1665**](#fixed-size-buffers): *Fixed size buffers must have a length greater than zero*
 - [**CS1666**](#fixed-size-buffers): *You cannot use fixed size buffers contained in unfixed expressions. Try using the fixed statement.*
 - [**CS1708**](#fixed-size-buffers): *Fixed size buffers can only be accessed through locals or fields*
 - [**CS1716**](#fixed-size-buffers): *Do not use 'System.Runtime.CompilerServices.FixedBuffer' attribute. Use the 'fixed' field modifier instead.*
 - [**CS1919**](#unsafe-context-requirements): *Unsafe type 'type name' cannot be used in object creation.*
 - [**CS4004**](#unsafe-context-requirements): *Cannot await in an unsafe context*
 - [**CS8812**](#function-pointers): *Cannot convert `&Method` group to non-function pointer type.*
 - [**CS9123**](#unsafe-context-requirements): *The '`&`' operator should not be used on parameters or local variables in async methods.

In addition, the following warnings are covered in this article:

## Pointer operations and dereferencing

- **CS0193**: *The \* or -> operator must be applied to a data pointer*
- **CS0196**: *A pointer must be indexed by only one value*
- **CS0242**: *The operation in question is undefined on void pointers*

These errors occur when you attempt invalid operations on pointers. Pointers in C# have specific rules about dereferencing, indexing, and arithmetic operations. For more information, see [Pointer types](../unsafe-code.md#pointer-types) and [Function pointers](../unsafe-code.md#function-pointers).

- **CS0193** occurs when you use the `*` or `->` operator with a nonpointer type or with a function pointer. Function pointers cannot be dereferenced in C#, unlike in C/C++.
- **CS0196** occurs when you attempt to index a pointer with multiple values. Pointers can only have a single index.
- **CS0242** occurs when you attempt operations that are undefined on void pointers. For example, incrementing a void pointer is not allowed because the compiler doesn't know the size of the data being pointed to.

## Pointer types and managed types

- **CS0208**: *Cannot take the address of, get the size of, or declare a pointer to a managed type ('type')*
- **CS0233**: *'identifier' does not have a predefined size, therefore sizeof can only be used in an unsafe context*

These errors occur when you work with pointers to managed types or use the `sizeof` operator incorrectly. For more information, see [Unmanaged types](../builtin-types/unmanaged-types.md) and the [`sizeof` operator](../operators/sizeof.md).

- **CS0208** occurs when you attempt to take the address of, get the size of, or declare a pointer to a managed type. Even when used with the [`unsafe`](../keywords/unsafe.md) keyword, these operations are not allowed on managed types. A managed type is any reference type or any struct that contains a reference type as a field or property.
- **CS0233** occurs when you use the [`sizeof`](../operators/sizeof.md) operator without an [`unsafe`](../keywords/unsafe.md) context on types whose size isn't a compile-time constant.

## Fixed buffers

- **CS0209**: *The type of local declared in a fixed statement must be a pointer type*
- **CS0210**: *You must provide an initializer in a fixed or `using` statement declaration*
- **CS0211**: *Cannot take the address of the given expression*
- **CS0212**: *You can only take the address of an unfixed expression inside of a fixed statement initializer*
- **CS0213**: *You cannot use the fixed statement to take the address of an already fixed expression*
- **CS0254**: *The right hand side of a fixed statement assignment may not be a cast expression*
- **CS0459**: *Cannot take the address of a read-only local variable*
- **CS0821**: *Implicitly typed locals cannot be fixed*
- **CS1656**: *Cannot assign to 'variable' because it is a 'read-only variable type'*

These errors occur when you use the [`fixed` statement](../statements/fixed.md) incorrectly. The `fixed` statement prevents the garbage collector from relocating a movable variable and declares a pointer to that variable. For more information, see [Unsafe Code and Pointers](../unsafe-code.md).

- **CS0209** occurs when the variable declared in a `fixed` statement isn't a pointer type.
- **CS0210** occurs when you don't provide an initializer in a `fixed` statement declaration. You must declare and initialize the variable in the `fixed` statement.
- **CS0211** occurs when you attempt to take the address of an expression that isn't valid for the address-of operator. You can take the address of fields, local variables, and pointer indirection, but not computed expressions like the sum of two variables.
- **CS0212** occurs when you attempt to take the address of an unfixed expression outside of a `fixed` statement initializer. The address-of operator can only be used on unfixed expressions within the initializer of a `fixed` statement.
- **CS0213** occurs when you attempt to use a `fixed` statement to take the address of an already-fixed expression. Local variables and parameters in an `unsafe` method are already fixed on the stack, so you don't need to (and cannot) fix them again.
- **CS0254** occurs when the right side of a `fixed` statement assignment uses a cast expression. The `fixed` statement doesn't allow casts in its initializer.
- **CS0459** occurs when you attempt to take the address of a read-only local variable. Variables in `foreach` loops, `using` statements, and `fixed` statements are read-only, and you cannot take their addresses.
- **CS0821** occurs when you attempt to use an implicitly typed local variable (declared with `var`) in a `fixed` statement. The `fixed` statement requires an explicit type.
- **CS1656** occurs when you attempt to assign to a variable in a read-only context, such as in a `foreach` loop, `using` statement, or `fixed` statement. Variables in these contexts are read-only and cannot be modified.

## Unsafe context restrictions

- **CS0214**: *Pointers and fixed size buffers may only be used in an unsafe context*
- **CS0227**: *Unsafe code may only appear if compiling with /unsafe*
- **CS0244**: *Neither 'is' nor 'as' is valid on pointer types*
- **CS1919**: *Unsafe type 'type name' cannot be used in object creation*
- **CS4004**: *Cannot await in an unsafe context*
- **CS9123**: *The '&' operator should not be used on parameters or local variables in async methods*

These errors occur when you use unsafe code constructs without proper unsafe context or when you attempt operations that aren't allowed in unsafe code. For more information, see [Unsafe Code and Pointers](../unsafe-code.md) and the [`unsafe` keyword](../keywords/unsafe.md).

- **CS0214** occurs when you use pointers or fixed-size buffers outside an `unsafe` context. Mark the method, type, or code block with the `unsafe` keyword.
- **CS0227** occurs when source code contains the `unsafe` keyword but the [**AllowUnsafeBlocks**](../compiler-options/language.md#allowunsafeblocks) compiler option isn't enabled. Enable unsafe code in your project settings.
- **CS0244** occurs when you use the [`is`](../operators/type-testing-and-cast.md#the-is-operator) or [`as`](../operators/type-testing-and-cast.md#the-as-operator) operators with pointer types. These type-testing operators aren't valid for pointers.
- **CS1919** occurs when you use the `new` operator to create an instance of a pointer type. The `new` operator creates objects only on the managed heap. To create objects in unmanaged memory, use interop to call native methods that return pointers.
- **CS4004** occurs when you use the `await` keyword in an `unsafe` context. Separate unsafe code from awaitable code by creating separate methods.
- **CS9123** is a warning that occurs when you use the address-of operator (`&`) on parameters or local variables in async methods. This can lead to issues because the variable may not exist when the async operation completes.

## Fixed-size buffers

- **CS1641**: *A fixed size buffer field must have the array size specifier after the field name*
- **CS1642**: *Fixed size buffer fields may only be members of structs*
- **CS1663**: *Fixed size buffer type must be one of the following: bool, byte, short, int, long, char, sbyte, ushort, uint, ulong, float or double*
- **CS1665**: *Fixed size buffers must have a length greater than zero*
- **CS1666**: *You cannot use fixed size buffers contained in unfixed expressions. Try using the fixed statement*
- **CS1708**: *Fixed size buffers can only be accessed through locals or fields*
- **CS1716**: *Do not use 'System.Runtime.CompilerServices.FixedBuffer' attribute. Use the 'fixed' field modifier instead*

These errors occur when you work with fixed-size buffers. Fixed-size buffers are arrays embedded directly in structs and are primarily used for interop scenarios. For more information, see [Fixed-size buffers](../../language-reference/unsafe-code.md#fixed-size-buffers).

- **CS1641** occurs when a fixed-size buffer declaration is missing the array size specifier. Unlike regular arrays, fixed-size buffers require a constant size specified at declaration.
- **CS1642** occurs when you declare a fixed-size buffer field in a `class`. Fixed-size buffers can only be members of structs. Change the `class` to a `struct` or use a regular array instead.
- **CS1663** occurs when the element type of a fixed-size buffer isn't one of the supported types: `bool`, `byte`, `short`, `int`, `long`, `char`, `sbyte`, `ushort`, `uint`, `ulong`, `float`, or `double`.
- **CS1665** occurs when a fixed-size buffer is declared with a length of zero or a negative number. Fixed-size buffers must have a positive length.
- **CS1666** occurs when you attempt to use a fixed-size buffer in an unfixed expression. You must use a `fixed` statement to pin the containing struct before accessing the buffer.
- **CS1708** occurs when you attempt to access a fixed-size buffer through an invalid expression. Fixed-size buffers can only be accessed through locals or fields.
- **CS1716** occurs when you use the `System.Runtime.CompilerServices.FixedBuffer` attribute directly. Use the `fixed` field modifier instead.

## Function pointers

- **CS8812**: *Cannot convert `&Method` group to non-function pointer type*

This error occurs when you attempt to convert a method group address to a non-function pointer type. The address of a method (for example, `&Method`) obtained using the [address-of operator `&`](../operators/pointer-related-operators.md#address-of-operator-) doesn't have an implicit type and cannot be assigned to a non-function pointer variable without an explicit cast. For more information, see [Function pointers](../unsafe-code.md#function-pointers).

The following sample generates CS8812:

```csharp
// CS8812.cs (6,22)

unsafe class C
{
    static void Method()
    {
        void* ptr1 = &Method;
    }
}
```

To correct this error, explicitly convert the expression to the required function pointer type:

```csharp
unsafe class C
{
    static void Method()
    {
        void* ptr1 = (delegate*<void>)&Method;
    }
}
```
