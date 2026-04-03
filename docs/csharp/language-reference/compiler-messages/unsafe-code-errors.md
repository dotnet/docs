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
 - "CS7092"
 - "CS8372"
 - "CS8812"
 - "CS9049"
 - "CS9123"
 - "CS9360"
 - "CS9361"
 - "CS9362"
 - "CS9363"
 - "CS9364"
 - "CS9365"
 - "CS9366"
 - "CS9367"
 - "CS9368"
 - "CS9376"
 - "CS9377"
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
 - "CS7092"
 - "CS8372"
 - "CS8812"
 - "CS9049"
 - "CS9123"
 - "CS9360"
 - "CS9361"
 - "CS9362"
 - "CS9363"
 - "CS9364"
 - "CS9365"
 - "CS9366"
 - "CS9367"
 - "CS9368"
 - "CS9376"
 - "CS9377"
ms.date: 04/01/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings in unsafe code constructs

This article covers the following compiler diagnostics:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS0193**](#pointer-operations-and-dereferencing): *The \* or -> operator must be applied to a pointer*
- [**CS0196**](#pointer-operations-and-dereferencing): *A pointer must be indexed by only one value*
- [**CS0208**](#pointer-types-and-managed-types): *Cannot take the address of, get the size of, or declare a pointer to a managed type ('type')*
- [**CS0209**](#fixed-statement-usage): *The type of a local declared in a `fixed` statement must be a pointer type*
- [**CS0210**](#fixed-statement-usage): *You must provide an initializer in a `fixed` or `using` statement declaration*
- [**CS0211**](#fixed-statement-usage): *Cannot take the address of the given expression*
- [**CS0212**](#fixed-statement-usage): *You can only take the address of an unfixed expression inside of a `fixed` statement initializer*
- [**CS0213**](#fixed-statement-usage): *You cannot use the `fixed` statement to take the address of an already fixed expression*
- [**CS0214**](#unsafe-context-requirements): *Pointers and fixed-size buffers may only be used in an unsafe context*
- [**CS0227**](#unsafe-context-requirements): *Unsafe code may only appear if compiling with `/unsafe`*
- [**CS0233**](#pointer-types-and-managed-types): *'identifier' does not have a predefined size, therefore sizeof can only be used in an unsafe context*
- [**CS0242**](#pointer-operations-and-dereferencing): *The operation in question is undefined on void pointers*
- [**CS0244**](#unsafe-context-requirements): *Neither '`is`' nor '`as`' is valid on pointer types*
- [**CS0254**](#fixed-statement-usage): *The right hand side of a fixed statement assignment may not be a cast expression*
- [**CS0459**](#fixed-statement-usage): *Cannot take the address of a read-only local variable*
- [**CS0821**](#fixed-statement-usage): *Implicitly typed local variables cannot be fixed*
- [**CS1641**](#fixed-size-buffers): *A fixed size buffer field must have the array size specifier after the field name*
- [**CS1642**](#fixed-size-buffers): *Fixed size buffer fields may only be members of structs.*
- [**CS1656**](#fixed-statement-usage): *Cannot assign to 'variable' because it is a 'read-only variable type'*
- [**CS1663**](#fixed-size-buffers): *Fixed size buffer type must be one of the following: `bool`, `byte`, `short`, `int`, `long`, `char`, `sbyte`, `ushort`, `uint`, `ulong`, `float` or `double`*
- [**CS1665**](#fixed-size-buffers): *Fixed size buffers must have a length greater than zero*
- [**CS1666**](#fixed-size-buffers): *You cannot use fixed size buffers contained in unfixed expressions. Try using the fixed statement.*
- [**CS1708**](#fixed-size-buffers): *Fixed size buffers can only be accessed through locals or fields*
- [**CS1716**](#fixed-size-buffers): *Do not use '`System.Runtime.CompilerServices.FixedBuffer`' attribute. Use the 'fixed' field modifier instead.*
- [**CS1919**](#unsafe-context-requirements): *Unsafe type 'type name' cannot be used in object creation.*
- [**CS4004**](#unsafe-context-requirements): *Cannot `await` in an unsafe context*
- [**CS7092**](#fixed-size-buffers): *A fixed buffer may only have one dimension.*
- [**CS8372**](#fixed-size-buffers): *Do not use '`System.Runtime.CompilerServices.FixedBuffer`' attribute on a property*
- [**CS8812**](#function-pointers): *Cannot convert &method group 'method' to non-function pointer type 'type'.*
- [**CS9049**](#fixed-size-buffers): *A fixed field must not be a ref field.*
- [**CS9123**](#unsafe-context-requirements): *The '`&`' operator should not be used on parameters or local variables in async methods.*
- [**CS9360**](#unsafe-context-requirements): *This operation may only be used in an unsafe context*
- [**CS9361**](#unsafe-context-requirements): *`stackalloc` expression without an initializer inside `SkipLocalsInit` may only be used in an unsafe context*
- [**CS9362**](#unsafe-context-requirements): *'member' must be used in an unsafe context because it is marked as '`RequiresUnsafe`' or '`extern`'*
- [**CS9363**](#unsafe-context-requirements): *'member' must be used in an unsafe context because it has pointers in its signature*
- [**CS9364**](#unsafe-member-safety-contracts): *Unsafe member 'member' cannot override safe member 'member'*
- [**CS9365**](#unsafe-member-safety-contracts): *Unsafe member 'member' cannot implicitly implement safe member 'member'*
- [**CS9366**](#unsafe-member-safety-contracts): *Unsafe member 'member' cannot implement safe member 'member'*
- [**CS9367**](#unsafe-member-safety-contracts): *`RequiresUnsafeAttribute` cannot be applied to this symbol.*
- [**CS9368**](#unsafe-member-safety-contracts): *`RequiresUnsafeAttribute` is only valid under the updated memory safety rules.*
- [**CS9376**](#unsafe-context-requirements): *An unsafe context is required for constructor 'constructor' marked as '`RequiresUnsafe`' or '`extern`' to satisfy the '`new()`' constraint of type parameter 'type parameter' in 'generic type or method'*
- [**CS9377**](#unsafe-member-safety-contracts): *The '`unsafe`' modifier does not have any effect here under the current memory safety rules.*

## Pointer operations and dereferencing

- **CS0193**: *The `*` or `->` operator must be applied to a pointer*
- **CS0196**: *A pointer must be indexed by only one value*
- **CS0242**: *The operation in question is undefined on void pointers*

To use pointer operations correctly, follow the rules for dereferencing, indexing, and arithmetic operations. For more information, see [Pointer types](../unsafe-code.md#pointer-types) and [Function pointers](../unsafe-code.md#function-pointers).

- Apply the `*` or `->` operator only to data pointers (**CS0193**). Don't use these operators with nonpointer types or function pointers. Unlike in C/C++, you can't dereference function pointers in C#.
- Index pointers with only one value (**CS0196**). Multidimensional indexing isn't supported on pointers.
- Avoid operations that are undefined on void pointers (**CS0242**). For example, don't increment a void pointer because the compiler doesn't know the size of the data being pointed to.

## Pointer types and managed types

- **CS0208**: *Cannot take the address of, get the size of, or declare a pointer to a managed type ('type')*
- **CS0233**: *'identifier' does not have a predefined size, therefore sizeof can only be used in an unsafe context*

To work with pointers and the `sizeof` operator correctly, use unmanaged types and proper contexts. For more information, see [Unmanaged types](../builtin-types/unmanaged-types.md) and the [`sizeof` operator](../operators/sizeof.md).

- Use pointers only with unmanaged types (**CS0208**). Don't take the address of, get the size of, or declare pointers to managed types. Managed types include reference types and structs that contain reference type fields or properties.
- Use the [`sizeof`](../operators/sizeof.md) operator within an [`unsafe`](../keywords/unsafe.md) context when working with types whose size isn't a compile-time constant (**CS0233**).

## Fixed statement usage

- **CS0209**: *The type of a local declared in a fixed statement must be a pointer type*
- **CS0210**: *You must provide an initializer in a fixed or `using` statement declaration*
- **CS0211**: *Cannot take the address of the given expression*
- **CS0212**: *You can only take the address of an unfixed expression inside of a fixed statement initializer*
- **CS0213**: *You cannot use the fixed statement to take the address of an already fixed expression*
- **CS0254**: *The right hand side of a fixed statement assignment may not be a cast expression*
- **CS0459**: *Cannot take the address of a read-only local variable*
- **CS0821**: *Implicitly typed local variables cannot be fixed*
- **CS1656**: *Cannot assign to 'variable' because it is a 'read-only variable type'*

These errors occur when you use the [`fixed` statement](../statements/fixed.md) incorrectly. The `fixed` statement prevents the garbage collector from relocating a movable variable and declares a pointer to that variable. For more information, see [Unsafe code and pointers](../unsafe-code.md).

To use the `fixed` statement correctly:

- Declare the variable as a pointer type (**CS0209**).
- Provide an initializer in the `fixed` statement declaration (**CS0210**).
- Take the address only of valid expressions: fields, local variables, and pointer indirection (**CS0211**). Don't take the address of computed expressions like the sum of two variables.
- Use the address-of operator on unfixed expressions only within the `fixed` statement initializer (**CS0212**).
- Don't use a `fixed` statement on already-fixed expressions (**CS0213**). Local variables and parameters in an `unsafe` method are already fixed on the stack.
- Don't use cast expressions on the right side of a `fixed` statement assignment (**CS0254**).
- Don't take the address of read-only local variables (**CS0459**). Variables in `foreach` loops, `using` statements, and `fixed` statements are read-only. This error is no longer produced by current versions of the compiler.
- Use explicit types instead of `var` in `fixed` statements (**CS0821**).
- Don't assign to variables in read-only contexts like `foreach` loops, `using` statements, or `fixed` statements (**CS1656**).

## Unsafe context requirements

- **CS0214**: *Pointers and fixed size buffers may only be used in an unsafe context*
- **CS0227**: *Unsafe code may only appear if compiling with /unsafe*
- **CS0244**: *Neither '`is`' nor '`as`' is valid on pointer types*
- **CS1919**: *Unsafe type 'type name' cannot be used in object creation*
- **CS4004**: *Cannot `await` in an unsafe context*
- **CS9123**: *The '`&`' operator should not be used on parameters or local variables in async methods*
- **CS9360**: *This operation may only be used in an unsafe context*
- **CS9361**: *`stackalloc` expression without an initializer inside `SkipLocalsInit` may only be used in an unsafe context*
- **CS9362**: *'member' must be used in an unsafe context because it is marked as '`RequiresUnsafe`' or '`extern`'*
- **CS9363**: *'member' must be used in an unsafe context because it has pointers in its signature*
- **CS9376**: *An unsafe context is required for constructor 'constructor' marked as '`RequiresUnsafe`' or '`extern`' to satisfy the '`new()`' constraint of type parameter 'type parameter' in 'generic type or method'*

These diagnostics occur when you use unsafe code constructs without the required `unsafe` context, or when you attempt operations that aren't allowed with unsafe types. For more information, see [Unsafe code and pointers](../unsafe-code.md) and the [`unsafe` keyword](../keywords/unsafe.md).

- Mark methods, types, or code blocks that use pointers or fixed-size buffers with the `unsafe` keyword (**CS0214**). The compiler requires an explicit unsafe context for any code that works with pointer types or fixed-size buffer fields.
- Enable the [**AllowUnsafeBlocks**](../compiler-options/language.md#allowunsafeblocks) compiler option in your project settings (**CS0227**). Without this option, the compiler rejects all `unsafe` blocks even if the code is otherwise correct.
- Don't use the [`is`](../operators/type-testing-and-cast.md#the-is-operator) or [`as`](../operators/type-testing-and-cast.md#the-as-operator) operators with pointer types (**CS0244**). These type-testing operators aren't valid for pointers because pointers don't participate in the type hierarchy.
- Don't use the `new` operator to create pointer type instances (**CS1919**). To create objects in unmanaged memory, use interop to call native methods that return pointers.
- Keep unsafe code separate from async code (**CS4004**). The compiler doesn't allow `await` expressions inside an `unsafe` block because the runtime can't guarantee pointer validity across suspension points. Create separate methods for unsafe operations and call them from async methods.
- Don't use the address-of operator (`&`) on parameters or local variables in async methods (**CS9123**). The variable might not exist on the stack when the async operation resumes after a suspension point.
- Mark operations that involve unsafe constructs (such as pointer dereferencing, address-of, or `sizeof` on unmanaged types) with the `unsafe` keyword (**CS9360**). Under C# 15's updated memory safety rules, the compiler identifies individual operations that require an unsafe context.
- Use the `unsafe` keyword for `stackalloc` expressions without initializers when the `SkipLocalsInit` attribute is applied (**CS9361**). Without an initializer, the stack-allocated memory contains uninitialized data, which is an unsafe operation.
- Use an `unsafe` context when calling members marked with `RequiresUnsafe` or `extern` (**CS9362**), or members with pointers in their signatures (**CS9363**). The C# 15 compiler tracks unsafe member usage at the call site, not just at the declaration.
- Use an `unsafe` context when a `new()` constraint requires calling a constructor marked with `RequiresUnsafe` or `extern` (**CS9376**). The generic instantiation calls the constructor implicitly, so the calling context must be unsafe.

## Unsafe member safety contracts

- **CS9364**: *Unsafe member 'member' cannot override safe member 'member'*
- **CS9365**: *Unsafe member 'member' cannot implicitly implement safe member 'member'*
- **CS9366**: *Unsafe member 'member' cannot implement safe member 'member'*
- **CS9367**: *`RequiresUnsafeAttribute` cannot be applied to this symbol.*
- **CS9368**: *`RequiresUnsafeAttribute` is only valid under the updated memory safety rules.*
- **CS9377**: *The '`unsafe`' modifier does not have any effect here under the current memory safety rules.*

These diagnostics enforce the C# 15 safety contract rules for members marked as unsafe. The compiler ensures that unsafe members don't violate the safety expectations established by base classes and interfaces. For more information, see [Unsafe code and pointers](../unsafe-code.md) and the [`unsafe` keyword](../keywords/unsafe.md).

- Don't override a safe base member with an unsafe member (**CS9364**). An override must preserve the safety contract of the base member. If the base member is safe, the override must also be safe. Remove the `unsafe` modifier or `RequiresUnsafeAttribute` from the overriding member, or mark the base member as unsafe.
- Don't implicitly implement a safe interface member with an unsafe member (**CS9365**). When a type implicitly implements an interface member, callers through the interface expect a safe operation. Remove the unsafe designation from the implementing member, or use explicit interface implementation.
- Don't explicitly implement a safe interface member with an unsafe member (**CS9366**). Even with explicit implementation, the safety contract of the interface member must be preserved.
- Apply `RequiresUnsafeAttribute` only to supported symbol types (**CS9367**). This attribute can be applied to methods, properties, events, constructors, and types, but not all symbol kinds support it.
- Enable the updated memory safety rules to use `RequiresUnsafeAttribute` (**CS9368**). This attribute is part of C# 15's refined memory safety model and isn't recognized under legacy rules. Ensure your project targets a language version that supports the updated rules.
- Remove the `unsafe` modifier when it has no effect (**CS9377**). Under the current memory safety rules, certain contexts don't require or benefit from the `unsafe` modifier. The compiler warns when the modifier is meaningless so you can clean up unnecessary annotations.

## Fixed-size buffers

- **CS1641**: *A fixed size buffer field must have the array size specifier after the field name*
- **CS1642**: *Fixed size buffer fields may only be members of structs*
- **CS1663**: *Fixed size buffer type must be one of the following: `bool`, `byte`, `short`, `int`, `long`, `char`, `sbyte`, `ushort`, `uint`, `ulong`, `float` or `double`*
- **CS1665**: *Fixed size buffers must have a length greater than zero*
- **CS1666**: *You cannot use fixed size buffers contained in unfixed expressions. Try using the fixed statement*
- **CS1708**: *Fixed size buffers can only be accessed through locals or fields*
- **CS1716**: *Do not use '`System.Runtime.CompilerServices.FixedBuffer`' attribute. Use the 'fixed' field modifier instead*
- **CS7092**: *A fixed buffer may only have one dimension.*
- **CS8372**: *Do not use '`System.Runtime.CompilerServices.FixedBuffer`' attribute on a property*
- **CS9049**: *A fixed field must not be a ref field*

These errors occur when you work with fixed-size buffers. Fixed-size buffers are arrays embedded directly in structs and are primarily used for interop scenarios. For more information, see [Fixed-size buffers](../unsafe-code.md#fixed-size-buffers).

To declare and use fixed-size buffers correctly:

- Specify the array size after the field name using a positive integer constant (**CS1641**, **CS1665**).
- Declare fixed-size buffers only in structs, not in classes (**CS1642**). Use a regular array if you need the field in a class.
- Use one of the supported element types: `bool`, `byte`, `short`, `int`, `long`, `char`, `sbyte`, `ushort`, `uint`, `ulong`, `float`, or `double` (**CS1663**).
- Use a `fixed` statement to pin the containing struct before accessing the buffer (**CS1666**).
- Access fixed-size buffers only through locals or fields, not through intermediate expressions (**CS1708**).
- Use the `fixed` field modifier instead of the `System.Runtime.CompilerServices.FixedBuffer` attribute (**CS1716**). Don't apply this attribute to properties either (**CS8372**).
- Declare fixed buffers with only one dimension (**CS7092**). Multidimensional fixed buffers aren't supported.
- Don't declare fixed-size buffers as `ref` fields (**CS9049**). Fixed-size buffers must be value fields.

## Function pointers

- **CS8812**: *Cannot convert &method group 'method' to non-function pointer type 'type'.*

To get a function pointer, use the address-of operator with an explicit function pointer type cast. Don't use the [address-of operator `&`](../operators/pointer-related-operators.md#address-of-operator-) to assign method groups to `void*` or other non-function pointer types. For more information, see [Function pointers](../unsafe-code.md#function-pointers).
