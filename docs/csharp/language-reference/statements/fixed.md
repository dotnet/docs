---
title: "fixed statement - pin a moveable variable"
description: "Use the C# `fixed` statement to pin a moveable variable and declare a pointer to that variable. The address of a pinned variable doesn't change during execution of the statement."
ms.date: 11/22/2022
f1_keywords: 
  - "fixed_CSharpKeyword"
  - "fixed"
helpviewer_keywords: 
  - "fixed statement [C#]"
  - "fixed keyword [C#]"
---
# fixed statement - pin a variable for pointer operations

The `fixed` statement prevents the [garbage collector](../../../standard/garbage-collection/index.md) from relocating a moveable variable and declares a pointer to that variable. The address of a fixed, or pinned, variable doesn't change during execution of the statement. You can use the declared pointer only inside the corresponding `fixed` statement. The declared pointer is readonly and can't be modified:

:::code language="csharp" source="snippets/fixed/Program.cs" id="PinnedArray":::

> [!NOTE]
> You can use the `fixed` statement only in an [unsafe](../keywords/unsafe.md) context. The code that contains unsafe blocks must be compiled with the [**AllowUnsafeBlocks**](../compiler-options/language.md#allowunsafeblocks) compiler option.

You can initialize the declared pointer as follows:

- With an array, as the example at the beginning of this article shows. The initialized pointer contains the address of the first array element.
- With an address of a variable. Use the [address-of `&` operator](../operators/pointer-related-operators.md#address-of-operator-), as the following example shows:

  :::code language="csharp" source="snippets/fixed/Program.cs" id="PinnedVariable":::

  Object fields are another example of moveable variables that can be pinned.

  When the initialized pointer contains the address of an object field or an array element, the `fixed` statement guarantees that the garbage collector doesn't relocate or dispose of the containing object instance during the execution of the statement body.

- With the instance of the type that implements a method named `GetPinnableReference`. That method must return a `ref` variable of an [unmanaged type](../builtin-types/unmanaged-types.md). The .NET types <xref:System.Span%601?displayProperty=nameWithType> and <xref:System.ReadOnlySpan%601?displayProperty=nameWithType> make use of this pattern. You can pin span instances, as the following example shows:

  :::code language="csharp" source="snippets/fixed/Program.cs" id="PinnedSpan":::

  For more information, see the <xref:System.Span%601.GetPinnableReference?displayProperty=nameWithType> API reference.

- With a string, as the following example shows:

  :::code language="csharp" source="snippets/fixed/Program.cs" id="PinnedString":::

- With a [fixed-size buffer](../unsafe-code.md#fixed-size-buffers).

You can allocate memory on the stack, where it's not subject to garbage collection and therefore doesn't need to be pinned. To do that, use a [`stackalloc` expression](../operators/stackalloc.md).

You can also use the `fixed` keyword to declare a [fixed-size buffer](../unsafe-code.md#fixed-size-buffers).

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [The fixed statement](~/_csharpstandard/standard/unsafe-code.md#237-the-fixed-statement)
- [Fixed and moveable variables](~/_csharpstandard/standard/unsafe-code.md#234-fixed-and-moveable-variables)

## See also

- [Unsafe code, pointer types, and function pointers](../unsafe-code.md)
- [Pointer-related operators](../operators/pointer-related-operators.md)
- [unsafe](../keywords/unsafe.md)
