---
description: "fixed Statement - C# Reference"
title: "fixed Statement - C# Reference"
ms.date: 05/10/2018
f1_keywords: 
  - "fixed_CSharpKeyword"
  - "fixed"
helpviewer_keywords: 
  - "fixed keyword [C#]"
---
# fixed Statement (C# Reference)

The `fixed` statement prevents the garbage collector from relocating a movable variable. The `fixed` statement is only permitted in an [unsafe](unsafe.md) context. You can also use the `fixed` keyword to create [fixed size buffers](../unsafe-code.md#fixed-size-buffers).

The `fixed` statement sets a pointer to a managed variable and "pins" that variable during the execution of the statement. Pointers to movable managed variables are useful only in a `fixed` context. Without a `fixed` context, garbage collection could relocate the variables unpredictably. The C# compiler only lets you assign a pointer to a managed variable in a `fixed` statement.

[!code-csharp[Accessing fixed memory](snippets/FixedKeywordExamples.cs#1)]

You can initialize a pointer by using an array, a string, a fixed-size buffer, or the address of a variable. The following example illustrates the use of variable addresses, arrays, and strings:

[!code-csharp[Initializing fixed size buffers](snippets/FixedKeywordExamples.cs#2)]

Starting with C# 7.3, the `fixed` statement operates on additional types beyond arrays, strings, fixed size buffers, or unmanaged variables. Any type that implements a method named `GetPinnableReference` can be pinned. The `GetPinnableReference` must return a `ref` variable of an [unmanaged type](../builtin-types/unmanaged-types.md). The .NET types <xref:System.Span%601?displayProperty=nameWithType> and <xref:System.ReadOnlySpan%601?displayProperty=nameWithType> introduced in .NET Core 2.0 make use of this pattern and can be pinned. This is shown in the following example:

[!code-csharp[Accessing fixed memory](snippets/FixedKeywordExamples.cs#FixedSpan)]

If you are creating types that should participate in this pattern, see <xref:System.Span%601.GetPinnableReference?displayProperty=nameWithType> for an example of implementing the pattern.

Multiple pointers can be initialized in one statement if they are all the same type:

```csharp
fixed (byte* ps = srcarray, pd = dstarray) {...}
```

To initialize pointers of different types, simply nest `fixed` statements, as shown in the following example.

[!code-csharp[Initializing multiple pointers](snippets/FixedKeywordExamples.cs#3)]

After the code in the statement is executed, any pinned variables are unpinned and subject to garbage collection. Therefore, do not point to those variables outside the `fixed` statement. The variables declared in the `fixed` statement are scoped to that statement, making this easier:

```csharp
fixed (byte* ps = srcarray, pd = dstarray)
{
   ...
}
// ps and pd are no longer in scope here.
```

Pointers initialized in `fixed` statements are readonly variables. If you want to modify the pointer value, you must declare a second pointer variable, and modify that. The variable declared in the `fixed` statement cannot be modified:

```csharp
fixed (byte* ps = srcarray, pd = dstarray)
{
    byte* pSourceCopy = ps;
    pSourceCopy++; // point to the next element.
    ps++; // invalid: cannot modify ps, as it is declared in the fixed statement.
}
```

You can allocate memory on the stack, where it is not subject to garbage collection and therefore does not need to be pinned. To do that, use a [`stackalloc` expression](../operators/stackalloc.md).

## C# language specification

For more information, see [The fixed statement](~/_csharplang/spec/unsafe-code.md#the-fixed-statement) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [unsafe](unsafe.md)
- [Pointer types](../unsafe-code.md#pointer-types)
- [Fixed Size Buffers](../unsafe-code.md#fixed-size-buffers)
