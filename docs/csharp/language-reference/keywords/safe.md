---
description: "safe modifier - C# Reference"
title: "safe modifier"
ms.date: 10/19/2026
ai-usage: ai-assisted
f1_keywords:
  - "safe_CSharpKeyword"
  - "safe"
helpviewer_keywords:
  - "safe keyword [C#]"
---
# safe (C# Reference)

The `safe` contextual keyword marks a declaration as not requiring an `unsafe` context at its use site under the [updated memory safety model](../unsafe-code.md#the-updated-memory-safety-model-preview). The `safe` modifier is the counterpart to [`unsafe`](unsafe.md): `safe` attests that callers need no `unsafe` context, while `unsafe` propagates the obligation to audit safety to the caller.

> [!IMPORTANT]
> The `safe` keyword is part of the updated memory safety model, a preview feature in C# 15 and .NET 11. Set [`LangVersion`](../compiler-options/language.md#langversion) to `preview` to enable the syntax. To also enforce the updated rules, including explicit `safe` or `unsafe` choices and requires-unsafe caller obligations, enable the `updated-memory-safety-rules` compiler feature. For activation details, see [Enable the updated memory safety rules](../compiler-options/language.md#enable-the-updated-memory-safety-rules). For the full design, see the [memory safety feature specification](~/_csharplang/proposals/unsafe-evolution.md).

## Permitted and required declarations

You can apply `safe` to declarations that permit a requires-unsafe modifier, including methods, constructors, properties, and fields. For ordinary declarations, the modifier can make the intended contract explicit, including in source-generated code. It isn't limited to `extern` members and layout fields.

Certain declarations require an explicit choice of `safe` or `unsafe` when the updated rules are enabled. The following sections describe `extern` members and explicit or extended layout fields.

Unlike `unsafe`, `safe` doesn't establish a lexical context. It doesn't make unsafe operations in a member body safe or cancel an enclosing unsafe context. You can't combine the `safe` and `unsafe` modifiers on the same declaration; doing so produces CS9388.

## Extern members

An `extern` member calls into native code, so the compiler can't classify its safety. Under the updated model, you mark every `extern` declaration, including a `LibraryImport` partial method, either `safe` or `unsafe`:

```csharp
// Syntax requires LangVersion preview; enforcement requires the updated-memory-safety-rules compiler feature.
[LibraryImport("libc")]
internal static safe partial int getpid();

[LibraryImport("libc", StringMarshalling = StringMarshalling.Utf8)]
internal static unsafe partial nint strlen(byte* str);
```

`getpid` takes no parameters and returns a primitive, so the author attests that the call is safe, and callers use it without an `unsafe` context. `strlen` takes a raw pointer that the native code dereferences, so the declaration is `unsafe` and propagates the obligation to its callers. With the updated rules enabled, omitting both modifiers is an error.

## Explicit or extended layout fields

In a type with `[StructLayout(LayoutKind.Explicit)]` or `[ExtendedLayout]`, the compiler can't classify every instance field's safety on its own. You mark every such field either `safe` or `unsafe`:

```csharp
// Syntax requires LangVersion preview; enforcement requires the updated-memory-safety-rules compiler feature.
[StructLayout(LayoutKind.Explicit)]
internal struct Union
{
    [FieldOffset(0)]
    internal safe int AsInt;

    [FieldOffset(0)]
    internal safe float AsFloat;
}
```

A field that holds a native pointer, or whose type otherwise carries an invariant the type system can't express, is `unsafe`. A field whose type is fully described by the type system is `safe`. The same rule applies to explicit-layout fields and extended-layout fields. As with `extern` members, omitting both modifiers is an error when the updated rules are enabled.

## C# language specification

For more information, see [Unsafe code](~/_csharpstandard/standard/unsafe-code.md) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.

For the design of the updated memory safety model, see the [memory safety feature specification](~/_csharplang/proposals/unsafe-evolution.md).

## See also

- [C# keywords](index.md)
- [`unsafe` keyword](unsafe.md)
- [`extern` modifier](extern.md)
- [Unsafe code, pointer types, and function pointers](../unsafe-code.md)
