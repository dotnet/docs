---
title: "extension member declarations"
description: "Learn the syntax to declare extension members in C#. Extension members enable you to add functionality to types and interfaces in those instances where you don't have the source for the original type. Extensions are often paired with generic interfaces to implement a common set of functionality across all types that implement that interface."
ms.date: 04/08/2025
f1_keywords:
  - "extension_CSharpKeyword"
  - "extension"
---
# Extension declaration (C# Reference)

Beginning with C# 14, top level, non-generic `static class` declarations can use `extension` containers to declare *extension members*. Extension members are methods or properties and can appear to be instance or static members. Earlier versions of C# enable *extension methods* by adding `this` as a modifier to the first parameter of a static method declared in a top-level, non-generic static class.

The `extension` container specifies the type and receiver for extension members. You can declare methods and properties inside the `extension` declaration. The following example declares a single extension container that defines an instance extension method and an instance property.

:::code language="csharp" source="./snippets/extensions.cs" id="ExtensionMembers":::

The `extension` defines the receiver: `sequence`, which is the an `IEnumerable<int>`. The receiver type can be non-generic, an open generic, or a closed generic type. The name `sequence` is in scope in every instance member declared in that extension. The extension method and property both access `sequence`.

Any of the extension members can be accessed as though they were members of the receiver type:

:::code language="csharp" source="./snippets/extensions.cs" id="UseExtensionMethod":::

You can declare any number of members in a single container, as long as they share the same receiver. You can declare as many extension containers in a single class as well. Different extensions don't need to declare the same type or name of receiver. The extension parameter doesn't need to include the parameter name if the only members are static:

:::code language="csharp" source="./snippets/extensions.cs" id="StaticExtensions":::

Static extensions can be called as though they are static members of the receiver type:

:::code language="csharp" source="./snippets/extensions.cs" id="UseStaticExtensions":::

> [!IMPORTANT]
> An extension doesn't introduce a *scope* for member declarations. All members declared in a single class, even if in multiple extensions, must have unique signatures. The generated signature includes the receiver type in its name for static members and the receiver parameter for extension instance members.

The following example shows an extension method using the `this` modifier:

:::code language="csharp" source="./snippets/ExtensionMethods.cs" id="ExtensionMethod":::

The `Add` method can be called from any other method as though it was a member of the `IEnumerable<int>` interface:

:::code language="csharp" source="./snippets/ExtensionMethods.cs" id="UseExtensionMethod":::

Both forms of extension methods generate the same intermediate language (IL). Callers can't make a distinction between them. In fact, you can convert existing extension methods to the new member syntax without a breaking change. The formats are both binary and source compatible.

## See also

- [Extensions feature specification](~/_csharplang/proposals/extensions.md)

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]
