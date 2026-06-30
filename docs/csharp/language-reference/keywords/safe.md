---
description: "safe modifier - C# Reference"
title: "safe modifier"
ms.date: 06/17/2026
ai-usage: ai-assisted
f1_keywords:
  - "safe_CSharpKeyword"
  - "safe"
helpviewer_keywords:
  - "safe keyword [C#]"
---
# safe (C# Reference)

The `safe` contextual keyword attests that a declaration is sound in places where the [updated memory safety model](../unsafe-code.md#the-updated-memory-safety-model-preview) requires you to make the safety choice explicit. You apply `safe` as a modifier on a declaration that the compiler can't classify on its own, such as an `extern` member or a field in a struct with explicit layout. The `safe` modifier is the counterpart to [`unsafe`](unsafe.md): `safe` attests that callers need no `unsafe` context, while `unsafe` propagates the obligation to audit safety to the caller.

> [!IMPORTANT]
> The `safe` keyword is part of the updated memory safety model, a preview feature in C# 15 and .NET 11. The compiler in .NET 11 Preview 5 doesn't yet recognize the keyword. To follow the feature, set the [`LangVersion`](../compiler-options/language.md#langversion) compiler option to `preview`. For the full design, see the [memory safety feature specification](~/_csharplang/proposals/unsafe-evolution.md). The code in this article shows the proposed syntax and doesn't compile with the current preview compiler.

## Extern members

An `extern` member calls into native code, so the compiler can't classify its safety. Under the updated model, you mark every `extern` declaration, including a `LibraryImport` partial method, either `safe` or `unsafe`:

```csharp
// Preview: illustrates the updated model, which the current compiler doesn't enforce yet.
[LibraryImport("libc")]
internal static safe partial int getpid();

[LibraryImport("libc", StringMarshalling = StringMarshalling.Utf8)]
internal static unsafe partial nint strlen(byte* str);
```

`getpid` takes no parameters and returns a primitive, so the author attests that the call is safe, and callers use it without an `unsafe` context. `strlen` takes a raw pointer that the native code dereferences, so the declaration is `unsafe` and propagates the obligation to its callers. Omitting both modifiers is an error, which forces you to make the safety decision.

## Explicit-layout fields

In a struct with `[StructLayout(LayoutKind.Explicit)]`, fields can overlap in memory, so the compiler can't reason about whether a read through one field is sound. You mark every field of such a struct either `safe` or `unsafe`:

```csharp
// Preview
[StructLayout(LayoutKind.Explicit)]
internal struct Union
{
    [FieldOffset(0)]
    internal safe int AsInt;

    [FieldOffset(0)]
    internal safe float AsFloat;
}
```

A field that holds a native pointer, or whose type otherwise carries an invariant the type system can't express, is `unsafe`. A field whose type is fully described by the type system is `safe`. As with `extern` members, omitting both modifiers is an error.

## C# language specification

For more information, see [Unsafe code](~/_csharpstandard/standard/unsafe-code.md) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.

For the design of the updated memory safety model, see the [memory safety feature specification](~/_csharplang/proposals/unsafe-evolution.md).

## See also

- [C# keywords](index.md)
- [`unsafe` keyword](unsafe.md)
- [`extern` modifier](extern.md)
- [Unsafe code, pointer types, and function pointers](../unsafe-code.md)
