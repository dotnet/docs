---
title: What's new in C# 11 - C# Guide
description: Get an overview of the new features coming in C# 11.
ms.date: 03/04/2022
---
# What's new in C# 11

Beginning with the .NET 6.0.200 SDK or Visual Studio 2022 version 17.1, preview features in C# are available for you to try.

> [!IMPORTANT]
> These are currently preview features. You must [set `<LangVersion>` to `preview`](../language-reference/compiler-options/language.md#langversion) to enable these features. Any feature may change before its final release. These features may not all be released in C# 11. Some may remain in a preview phase for longer based on feedback on the feature.

The following features are available in the 6.0.200 version of the .NET SDK. They are available in Visual Studio 2022 version 17.1.

- [Generic attributes](#generic-attributes).
- [static abstract members in interfaces](#static-abstract-members-in-interfaces).

You can download the latest .NET 6 SDK from the [.NET downloads page](https://dotnet.microsoft.com/download). You can also download [Visual Studio 2022](https://visualstudio.microsoft.com/vs/), which includes the .NET 6 SDK.

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
// C# 11 feature:
[TypeAttribute(typeof(string))]
public string Method() => default;
```

Using this new feature, you can create a generic attribute instead:

```csharp
public class GenericAttribute<T> : Attribute { }
```

Then, specify the type parameter to use the attribute:

```csharp
[GenericAttribute<string>()]
public string Method() => default;
```

You must supply all type parameters when you apply the attribute. In other words, the generic type must [fully constructed](~/_csharpstandard/standard/types.md#84-constructed-types).

```csharp
public class GenericType<T>
{
   [GenericAttribute<T>()] // Not allowed! generic attributes must be fully constructed types.
   public string Method() => default;
}
```

The type arguments must satisfy the same restrictions as the [`typeof`](../language-reference/operators/type-testing-and-cast.md#typeof-operator) operator. Types that require metadata annotations aren't allowed. Examples include the following:

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
> *static abstract members in interfaces* is a runtime preview feature. You must add the `<EnablePreviewFeatures>True</EnablePreviewFeatures>` in your project file. See [Preview features](https://aka.ms/dotnet-warnings/preview-features) for more information. You can experiment with this feature, and the experimental libraries that use it. We will use feedback from the preview cycles to improve the feature before its general release.

You can add *static abstract members* in interfaces to define interfaces that include overloadable operators, other static members, and static properties. The primary scenario for this feature is to use mathematical operators in generic types. The .NET runtime team has included interfaces for mathematical operations in the [System.Runtime.Experimental](https://www.nuget.org/packages/System.Runtime.Experimental/) NuGet package. For example, you can implement the `System.IAdditionOperators<TSelf, TOther, TResult>` in a type that implements `operator +`. Other interfaces define other mathematical operations or well-defined values.

You can learn more and try the feature yourself in the tutorial [Explore static abstract interface members](./tutorials/static-abstract-interface-methods.md), or the [Preview features in .NET 6 – generic math](https://devblogs.microsoft.com/dotnet/preview-features-in-net-6-generic-math/) blog post.
