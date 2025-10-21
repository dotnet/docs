---
title: Resolve errors and warnings related to using unsafe code
description: These compiler errors and warnings indicate errors when you work with `unsafe` code. Unsafe code must be enabled with the `unsafe` keyword. Unsafe code allows constructs that can introduce memory based errors. These warnings and errors explain common misuses.
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
ai-usage: ai-assisted
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
- [**CS0244**](#unsafe-context-restrictions): *Neither '`is`' nor '`as`' is valid on pointer types*
- [**CS0254**](#fixed-buffers): *The right hand side of a fixed statement assignment may not be a cast expression*
- [**CS0459**](#fixed-buffers): *Cannot take the address of a read-only local variable*
- [**CS0821**](#fixed-buffers): *Implicitly typed locals cannot be fixed*
- [**CS1641**](#fixed-size-buffers): *A fixed size buffer field must have the array size specifier after the field name*
- [**CS1642**](#fixed-size-buffers): *Fixed size buffer fields may only be members of structs.*
- [**CS1656**](#fixed-buffers): *Cannot assign to 'variable' because it is a 'read-only variable type'*
- [**CS1663**](#fixed-size-buffers): *Fixed size buffer type must be one of the following: `bool`, `byte`, `short`, `int`, `long`, `char`, `sbyte`, `ushort`, `uint`, `ulong`, `float` or `double`*
- [**CS1665**](#fixed-size-buffers): *Fixed size buffers must have a length greater than zero*
- [**CS1666**](#fixed-size-buffers): *You cannot use fixed size buffers contained in unfixed expressions. Try using the fixed statement.*
- [**CS1708**](#fixed-size-buffers): *Fixed size buffers can only be accessed through locals or fields*
- [**CS1716**](#fixed-size-buffers): *Do not use '`System.Runtime.CompilerServices.FixedBuffer`' attribute. Use the 'fixed' field modifier instead.*
- [**CS1919**](#unsafe-context-restrictions): *Unsafe type 'type name' cannot be used in object creation.*
- [**CS4004**](#unsafe-context-restrictions): *Cannot `await` in an unsafe context*
- [**CS8812**](#function-pointers): *Cannot convert `&Method` group to non-function pointer type.*
- [**CS9123**](#unsafe-context-restrictions): *The '`&`' operator should not be used on parameters or local variables in async methods.*

## Pointer operations and dereferencing

- **CS0193**: *The `*` or `->` operator must be applied to a data pointer*
- **CS0196**: *A pointer must be indexed by only one value*
- **CS0242**: *The operation in question is undefined on void pointers*

To use pointer operations correctly, follow the rules for dereferencing, indexing, and arithmetic operations. For more information, see [Pointer types](../unsafe-code.md#pointer-types) and [Function pointers](../unsafe-code.md#function-pointers).

- Apply the `*` or `->` operator only to data pointers (**CS0193**). Don't use these operators with nonpointer types or function pointers. Function pointers can't be dereferenced in C#, unlike in C/C++.
- Index pointers with only one value (**CS0196**). Multidimensional indexing isn't supported on pointers.
- Avoid operations that are undefined on void pointers (**CS0242**). For example, don't increment a void pointer because the compiler doesn't know the size of the data being pointed to.

## Pointer types and managed types

- **CS0208**: *Cannot take the address of, get the size of, or declare a pointer to a managed type ('type')*
- **CS0233**: *'identifier' does not have a predefined size, therefore sizeof can only be used in an unsafe context*

To work with pointers and the `sizeof` operator correctly, use unmanaged types and proper contexts. For more information, see [Unmanaged types](../builtin-types/unmanaged-types.md) and the [`sizeof` operator](../operators/sizeof.md).

- Use pointers only with unmanaged types (**CS0208**). Don't take the address of, get the size of, or declare pointers to managed types. Managed types include reference types and structs that contain reference type fields or properties.
- Use the [`sizeof`](../operators/sizeof.md) operator within an [`unsafe`](../keywords/unsafe.md) context when working with types whose size isn't a compile-time constant (**CS0233**).

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

To use the `fixed` statement correctly:

- Declare the variable as a pointer type (**CS0209**).
- Provide an initializer in the `fixed` statement declaration (**CS0210**).
- Take the address only of valid expressions: fields, local variables, and pointer indirection (**CS0211**). Don't take the address of computed expressions like the sum of two variables.
- Use the address-of operator on unfixed expressions only within the `fixed` statement initializer (**CS0212**).
- Don't use a `fixed` statement on already-fixed expressions (**CS0213**). Local variables and parameters in an `unsafe` method are already fixed on the stack.
- Don't use cast expressions on the right side of a `fixed` statement assignment (**CS0254**).
- Don't take the address of read-only local variables (**CS0459**). Variables in `foreach` loops, `using` statements, and `fixed` statements are read-only.
- Use explicit types instead of `var` in `fixed` statements (**CS0821**).
- Don't assign to variables in read-only contexts like `foreach` loops, `using` statements, or `fixed` statements (**CS1656**).

## Unsafe context restrictions

- **CS0214**: *Pointers and fixed size buffers may only be used in an unsafe context*
- **CS0227**: *Unsafe code may only appear if compiling with /unsafe*
- **CS0244**: *Neither 'is' nor 'as' is valid on pointer types*
- **CS1919**: *Unsafe type 'type name' cannot be used in object creation*
- **CS4004**: *Cannot await in an unsafe context*
- **CS9123**: *The '&' operator should not be used on parameters or local variables in async methods*

These errors occur when you use unsafe code constructs without proper unsafe context or when you attempt operations that aren't allowed in unsafe code. For more information, see [Unsafe Code and Pointers](../unsafe-code.md) and the [`unsafe` keyword](../keywords/unsafe.md).

To use unsafe code correctly:

- Mark methods, types, or code blocks that use pointers or fixed-size buffers with the `unsafe` keyword (**CS0214**).
- Enable the [**AllowUnsafeBlocks**](../compiler-options/language.md#allowunsafeblocks) compiler option in your project settings when using the `unsafe` keyword (**CS0227**).
- Don't use the [`is`](../operators/type-testing-and-cast.md#the-is-operator) or [`as`](../operators/type-testing-and-cast.md#the-as-operator) operators with pointer types (**CS0244**). These type-testing operators aren't valid for pointers.
- Don't use the `new` operator to create pointer type instances (**CS1919**). To create objects in unmanaged memory, use interop to call native methods that return pointers.
- Keep unsafe code separate from async code (**CS4004**). Create separate methods for unsafe operations and call them from async methods.
- Don't use the address-of operator (`&`) on parameters or local variables in async methods (**CS9123**). The variable may not exist when the async operation completes.

## Fixed-size buffers

- **CS1641**: *A fixed size buffer field must have the array size specifier after the field name*
- **CS1642**: *Fixed size buffer fields may only be members of structs*
- **CS1663**: *Fixed size buffer type must be one of the following: bool, byte, short, int, long, char, sbyte, ushort, uint, ulong, float or double*
- **CS1665**: *Fixed size buffers must have a length greater than zero*
- **CS1666**: *You cannot use fixed size buffers contained in unfixed expressions. Try using the fixed statement*
- **CS1708**: *Fixed size buffers can only be accessed through locals or fields*
- **CS1716**: *Do not use 'System.Runtime.CompilerServices.FixedBuffer' attribute. Use the 'fixed' field modifier instead*

These errors occur when you work with fixed-size buffers. Fixed-size buffers are arrays embedded directly in structs and are primarily used for interop scenarios. For more information, see [Fixed-size buffers](../../language-reference/unsafe-code.md#fixed-size-buffers).

To declare and use fixed-size buffers correctly:

- Specify the array size after the field name using a positive integer constant (**CS1641**, **CS1665**).
- Declare fixed-size buffers only in structs, not in classes (**CS1642**). Use a regular array if you need the field in a class.
- Use one of the supported element types: `bool`, `byte`, `short`, `int`, `long`, `char`, `sbyte`, `ushort`, `uint`, `ulong`, `float`, or `double` (**CS1663**).
- Use a `fixed` statement to pin the containing struct before accessing the buffer (**CS1666**).
- Access fixed-size buffers only through locals or fields, not through intermediate expressions (**CS1708**).
- Use the `fixed` field modifier instead of the `System.Runtime.CompilerServices.FixedBuffer` attribute (**CS1716**).

## Function pointers

- **CS8812**: *Cannot convert `&Method` group to non-function pointer type*

To obtain a function pointer, use the address-of operator with an explicit function pointer type cast. Don't use the [address-of operator `&`](../operators/pointer-related-operators.md#address-of-operator-) to assign method groups to `void*` or other non-function pointer types. For more information, see [Function pointers](../unsafe-code.md#function-pointers).
