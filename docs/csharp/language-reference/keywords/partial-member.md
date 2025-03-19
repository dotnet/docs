---
description: "Partial members are members that can be declared in one partial type declaration and defined in a separate partial type declaration."
title: "Partial members"
ms.date: 03/13/2025
f1_keywords: 
  - "partialmethod_CSharpKeyword"
helpviewer_keywords: 
  - "partial methods [C#]"
---
# Partial member (C# Reference)

A partial member has one *declaring declaration* and often one *implementing declaration*. The *declaring declaration* doesn't include a body. The *implementing declaration* provides the body of the member. Partial members enable class designers to provide member hooks for tooling such as source generators to implement. Partial types and members provide a way for human developers to write part of a type while tools write other parts of the type. If the developer doesn't supply an optional implementing declaration, the compiler can remove the declaring declaration at compile time. The following conditions apply to partial members:

- Declarations must begin with the contextual keyword [partial](../../language-reference/keywords/partial-type.md).
- Signatures in both parts of the partial type must match.

The `partial` keyword isn't allowed on static constructors, finalizers, or overloaded operators. Before C# 14, `partial` wasn't allowed on instance constructors or event declarations. Before C# 13, `partial` wasn't allowed on properties or indexers.

A partial method isn't required to have an implementing declaration in the following cases:

- It doesn't have any accessibility modifiers (including the default [`private`](../../language-reference/keywords/private.md)).
- It returns [`void`](../../language-reference/builtin-types/void.md).
- It doesn't have any [`out`](method-parameters.md#out-parameter-modifier) parameters.
- It doesn't have any of the following modifiers [`virtual`](../../language-reference/keywords/virtual.md), [`override`](../../language-reference/keywords/override.md), [`sealed`](../../language-reference/keywords/sealed.md), [`new`](../../language-reference/keywords/new-modifier.md), or [`extern`](../../language-reference/keywords/extern.md).

The following example shows a partial method that conforms to the preceding restrictions:

:::code language="csharp" source="./snippets/PartialMembers.cs" id="OptionalPartialMethod":::

Any member that doesn't conform to all those restrictions (for example, `public virtual partial void` method), must provide an implementation.

Partial properties, indexers, and events can't use auto-implemented syntax for the implementing declaration. The defining declaration uses the same syntax. The implementing declaration must include at least one implemented accessor. That accessor can be a [field-backed property](./field.md). The implementing declaration for a partial event must define the `add` and `remove` handlers.

Partial members can also be useful in combination with source generators. For example a regex could be defined using the following pattern:

:::code language="csharp" source="./snippets/PartialMembers.cs" id="SourceGeneratorPartial":::

The preceding example shows a partial method that must have an implementing declaration. As part of a build, the [Regular expression source generator](../../../standard/base-types/regular-expression-source-generators.md) creates the implementing declaration.

The following example shows a declaring declaration and an implementing declaration for a class. Because the method's return type isn't `void` (it's `string`) and its access is `public`, the method must have an implementing declaration:

:::code language="csharp" source="./snippets/PartialMembers.cs" id="PartialMembersAll":::

The preceding example illustrates rules on how the two declarations are combined:

- *Signature matches*: In general, the signatures for the declaring and implementing declarations must match. This includes accessibility modifier on methods, properties, indexers, and individual accessors. It includes the parameter type and ref-kind modifiers on all parameters. The return type and any ref-kind modifier must match. Tuple member names must match. However, some rules are flexible:
  - The declaring and implementing declarations can have different [nullable](../compiler-options/language.md#nullable) annotations settings. Meaning that one can be *nullable oblivious* and the other *nullable enabled*.
  - Nullability differences that don't involve *oblivious nullability* generates a warning.
  - Default parameter values don't need to match. The compiler issues a warning if the implementing declaration of a method or indexer declares a default parameter value.
  - The compiler issues a warning when parameter names don't match. The emitted IL contains the declaring declaration's parameter names.
- *Documentation comments*: Documentation comments can be included from either declaration. If both the declaring and implementing declarations include documentation comments, the comments from the implementing declaration are included. In the preceding example, the documentation comments include:
  - For the `Capacity` property, the comments are taken from the implementing declaration. The implementing declaration comments are used when both declarations have `///` comments.
  - For the indexer, the comments are taken from the declaring declaration. The implementing declaration doesn't include any `///` comments.
  - For `TryGetAt`, the comments are taken from the implementing declaration. The declaring declaration doesn't include any `///` comments.
  - The generated XML has documentation comments for all `public` members.
- Most *Attribute declarations* are combined. However, all [caller info attributes](../attributes/caller-information.md) are defined with `AllowMultiple=false`. The compiler recognizes any caller info attribute on the declaring declaration. All caller info attributes on the implementing declaration are ignored. The compiler issues a warning if you add caller info attributes on  the implementing declaration.

## See also

- [partial type](partial-type.md)
