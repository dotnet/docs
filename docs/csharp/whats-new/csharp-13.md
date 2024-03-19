---
title: What's new in C# 13 - C# Guide
description: Get an overview of the new features in C# 13. Follow the release of new preview features as .NET 9 and C# 13 previews are released.
ms.date: 03/19/2024
---
# What's new in C# 13

C# 13 includes the following new features. You can try these features using the latest [Visual Studio 2022](https://visualstudio.microsoft.com/vs/preview/) version or the [.NET 9 preview SDK](https://dotnet.microsoft.com/download/dotnet).

- [New escape sequence - `\e`](#new-escape-sequence).
- [Method group natural type improvements](#method-group-natural-type)
- [Implicit indexer access in object initializers](#implicit-index-access)

C# 13 is supported on **.NET 9**. For more information, see [C# language versioning](../language-reference/configure-language-version.md).

You can download the latest .NET 9 preview SDK from the [.NET downloads page](https://dotnet.microsoft.com/download). You can also download [Visual Studio 2022 - preview](https://visualstudio.microsoft.com/vs/), which includes the .NET 9 preview SDK.

New features are added to the "What's new in C#" page when they are available in public preview releases. The [working set](https://github.com/dotnet/roslyn/blob/main/docs/Language%20Feature%20Status.md#working-set) section of the [roslyn feature status page](https://github.com/dotnet/roslyn/blob/main/docs/Language%20Feature%20Status.md) tracks when upcoming features are merged into the main branch.

[!INCLUDE [released-version-feedback](./includes/released-feedback.md)]

# New escape sequence

You can use `\e` as a [character literal](~/_csharpstandard/standard/lexical-structure.md#6455-character-literals) escape sequence for the `ESCAPE` character, Unicode `U+001B`. Previously, you used `\u001b` or `\x1b`. Using `\x1b` wasn't recommended because if the next characters following `1b` were valid hexadecimal digits, those characters became part of the escape sequence.

## Method group natural type

This feature makes small optimizations to overload resolution involving method groups. The previous behavior was for the compiler to construct the full set of candidate methods for a method group. If a natural type is needed, the natural type was determined from the full set of candidate methods.

The new behavior is to prune the set of candidate methods at each scope, removing those candidate methods that aren't applicable. Typically, these are generic methods with the wrong arity, or constraints that aren't satisfied. The process continues to the next outer scope only if no candidate methods have been found. This process more closely follows the general algorithm for overload resolution. If all candidate methods found at a given scope don't match, the method group doesn't have a natural type.

You can read the details of the changes in the [proposal specification](~/_csharplang/proposals/method-group-natural-type-improvements.md).

## Implicit index access

The implicit "from the end" index operator, `^`, is now allowed in an object initializer expression. For example, you can now initialize an array in an object initializer as shown in the following code:

```csharp
var v = new S() 
{ 
    buffer = 
    { 
        [^1] = 0,
        [^2] = 1,
        [^3] = 2,
        [^4] = 3,
        [^5] = 4,
        [^6] = 5,
        [^7] = 6,
        [^8] = 7,
        [^9] = 8,
        [^10] = 9
    } 
};
```

Before C# 13, the `^` operator can't be used in an object initializer. You'd need to index the elements from the front.

## See also

- [What's new in .NET 9](../../core/whats-new/dotnet-8/overview.md)
