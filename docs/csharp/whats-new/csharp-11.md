---
title: What's new in C# 11 - C# Guide
description: Get an overview of the new features coming in C# 11.
ms.date: 05/11/2022
---
# What's new in C# 11

Beginning with the .NET 6.0.200 SDK or Visual Studio 2022 version 17.1, preview features in C# are available for you to try.

> [!IMPORTANT]
> These are currently preview features. You must [set `<LangVersion>` to `preview`](../language-reference/compiler-options/language.md#langversion) to enable these features. Any feature may change before its final release. These features may not all be released in C# 11. Some may remain in a preview phase for longer based on feedback on the feature.

The following features are available in Visual Studio 2022 version 17.3:

- [auto-default structs](#auto-default-struct)

The following features are available in Visual Studio 2022 version 17.2:

- [Raw string literals](#raw-string-literals).
- [Improved method group conversion to delegate](#improved-method-group-conversion-to-delegate)
- [Warning wave 7](../language-reference/compiler-messages/warning-waves.md#cs8981---the-type-name-only-contains-lower-cased-ascii-characters)

The following features are available in Visual Studio 2022 version 17.1:

- [Generic attributes](#generic-attributes).
- [static abstract members in interfaces](#static-abstract-members-in-interfaces).
- [Newlines in string interpolation expressions](#newlines-in-string-interpolations).
- [List patterns](#list-patterns).

You can download the latest [Visual Studio 2022](https://visualstudio.microsoft.com/vs/). You can also try all these features with the preview release of the .NET 7 SDK, which can be downloaded from the [all .NET downloads](https://dotnet.microsoft.com/download/dotnet) page.

## Generic attributes

You can declare a [generic class](../programming-guide/generics/generic-classes.md) whose base class is <xref:System.Attribute?displayProperty=fullName>. This provides a more convenient syntax for attributes that require a <xref:System.Type?displayProperty=nameWithType> parameter. Previously, you'd need to create an attribute that takes a `Type` as its constructor parameter:

```csharp
// Before C# 11:
public class TypeAttribute : Attribute
{
   public TypeAttribute(Type t) => ParamType = t;

   public Type ParamType { get; }
}
```

And to apply the attribute, you use the [`typeof`](../language-reference/operators/type-testing-and-cast.md#typeof-operator) operator:

```csharp
[TypeAttribute(typeof(string))]
public string Method() => default;
```

Using this new feature, you can create a generic attribute instead:

```csharp
// C# 11 feature:
public class GenericAttribute<T> : Attribute { }
```

Then, specify the type parameter to use the attribute:

```csharp
[GenericAttribute<string>()]
public string Method() => default;
```

You must supply all type parameters when you apply the attribute. In other words, the generic type must be [fully constructed](~/_csharpstandard/standard/types.md#84-constructed-types).

```csharp
public class GenericType<T>
{
   [GenericAttribute<T>()] // Not allowed! generic attributes must be fully constructed types.
   public string Method() => default;
}
```

The type arguments must satisfy the same restrictions as the [`typeof`](../language-reference/operators/type-testing-and-cast.md#typeof-operator) operator. Types that require metadata annotations aren't allowed. For example, the following types aren't allowed as the type parameter:

- `dynamic`
- `nint`, `nuint`
- `string?` (or any nullable reference type)
- `(int X, int Y)` (or any other tuple types using C# tuple syntax).

These types aren't directly represented in metadata. They include annotations that describe the type. In all cases, you can use the underlying type instead:

- `object` for `dynamic`.
- <xref:System.IntPtr> instead of `nint` or `unint`.
- `string` instead of `string?`.
- `ValueTuple<int, int>` instead of `(int X, int Y)`.

## Static abstract members in interfaces

> [!IMPORTANT]
> *static abstract members in interfaces* is a runtime preview feature. You must add the `<EnablePreviewFeatures>True</EnablePreviewFeatures>` in your project file. For more information about runtime preview features, see [Preview features](https://aka.ms/dotnet-warnings/preview-features). You can experiment with this feature, and the experimental libraries that use it. We will use feedback from the preview cycles to improve the feature before its general release.

You can add *static abstract members* in interfaces to define interfaces that include overloadable operators, other static members, and static properties. The primary scenario for this feature is to use mathematical operators in generic types. The .NET runtime team has included interfaces for mathematical operations in the [System.Runtime.Experimental](https://www.nuget.org/packages/System.Runtime.Experimental/) NuGet package. For example, you can implement the `System.IAdditionOperators<TSelf, TOther, TResult>` in a type that implements `operator +`. Other interfaces define other mathematical operations or well-defined values.

You can learn more and try the feature yourself in the tutorial [Explore static abstract interface members](./tutorials/static-abstract-interface-methods.md), or the [Preview features in .NET 6 – generic math](https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/) blog post.

## Newlines in string interpolations

The text inside the `{` and `}` characters for a string interpolation can now span multiple lines. The text between the `{` and `}` markers is parsed as C#. Any legal C#, including newlines, is allowed. This feature makes it easier to read string interpolations that use longer C# expressions, like pattern matching `switch` expressions, or LINQ queries.

You can learn more about the newlines feature in the [string interpolations](../language-reference/tokens/interpolated.md) article in the language reference.

## List patterns

*List patterns* extend pattern matching to match sequences of elements in a list or an array. For example, `sequence is [1, 2, 3]` is `true` when the `sequence` is an array or a list of three integers (1, 2, and 3). You can match elements using any pattern, including constant, type, property and relational patterns. The discard pattern (`_`) matches any single element, and the new *range pattern* (`..`) matches any sequence of zero or more elements.

You can learn more details about list patterns in the [pattern matching](../language-reference/operators/patterns.md#list-patterns) article in the language reference.

## Improved method group conversion to delegate

The C# standard on [Method group conversions](~/_csharpstandard/standard/conversions.md#108-method-group-conversions) now includes the following item:

> - The conversion is permitted (but not required) to use an existing delegate instance that already contains these references.

Previous versions of the standard prohibited the compiler from reusing the delegate object created for a method group conversion. The C# 11 compiler caches the delegate object created from a method group conversion and reuses that single delegate object. This feature is first available in Visual Studio 17.2 as a preview feature. It's first available in .NET 7 preview 2.

## Raw string literals

*Raw string literals* are a new format for string literals. Raw string literals can contain arbitrary text, including whitespace, new lines, embedded quotes, and other special characters without requiring escape sequences. A raw string literal starts with at least three double-quote (""") characters. It ends with the same number of double-quote characters. Typically, a raw string literal uses three double quotes on a single line to start the string, and three double quotes on a separate line to end the string. The newlines following the opening quote and preceding the closing quote are not included in the final content:

```csharp
string longMessage = """
    This is a long message.
    It has several lines.
        Some are indented
                more than others.
    Some should start at the first column.
    Some have "quoted text" in them.
    """;
```

Any whitespace to the left of the closing double quotes will be removed from the string literal. Raw string literals can be combined with string interpolation to include braces in the output text. Multiple `$` characters denote how many consecutive braces start and end the interpolation:

```csharp
var location = $$"""
   You are at {{{Longitude}}, {{Latitude}}}
   """;
```

The preceding example specifies that two braces starts and end an interpolation. The third repeated opening and closing brace are included in the output string.

You can learn more about raw string literals in the article on [strings in the programming guide](../programming-guide/strings/index.md), and the language reference articles on [string literals](../language-reference/builtin-types/reference-types.md#string-literals) and [interpolated strings](../language-reference/tokens/interpolated.md).

## Auto-default struct

The C# 11 compiler ensures that all fields of a `struct` type are initialized to their default value as part of executing a constructor. This change means any field or auto property not initialized by a constructor is automatically initialized by the compiler. Structs where the constructor doesn't definitely assign all fields now compile, and any fields not explicitly initialized are set to their default value. You can read more about how this change affects struct initialization in the article on [structs](../language-reference/builtin-types/struct.md#struct-initialization-and-default-values).
