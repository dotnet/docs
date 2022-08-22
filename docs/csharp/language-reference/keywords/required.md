---
description: "required modifier - C# Reference"
title: "required modifier - C# Reference"
ms.date: 07/20/2022
f1_keywords: 
  - "required_CSharpKeyword"
helpviewer_keywords: 
  - "required  keyword [C#]"
---
# required modifier (C# Reference)

The `required` modifier indicates that the *field* or *property* it's applied to must be initialized by all constructors or using an [object initializer](../../programming-guide/classes-and-structs/object-and-collection-initializers.md). Any expression that initializes a new instance of the type must initialize all *required members*. Constructors indicate that they initialize all required members by adding the [`SetsRequiredMembers`](../attributes/general.md#setsrequiredmembers-attribute) attribute in the constructor declaration. Code that uses a constructor without this attribute must use *object initializers* to initialize all `required` members. The `required` modifier is available beginning with C# 11.

The `required` modifier and the `SetsRequiredMembers` attribute enable developers to create types where properties or fields must be properly initialized, yet still allow initialization using either constructors or object initializers. Several rules ensure this behavior:

- The `required` modifier can be applied to *fields* and *properties* declared in `struct`, and `class` types, including `record` and `record struct` types. The `required` modifier can't be applied to members of an `interface`.
- Explicit interface implementations can't be marked as `required`. They can't be set in object initializers.
- Required members must be initialized, but they may be initialized to `null`. If the type is a non-nullable reference type, the compiler issues a warning if you initialize the member to `null`. The compiler issues an error if the member isn't initialized at all.
- Required members must be at least as visible as their containing type. For example, a `public` class can't contain a `required` field that's `protected`. Furthermore, required properties must have setters (`set` or `init` accessors) that are at least as visible as their containing types. Members that aren't accessible can't be set by code that creates an instance.
- Derived classes can't hide a `required` member declared in the base class. Hiding a required member prevents callers from using object initializers for it. Furthermore, derived types that override a required property must include the `required` modifier.  The derived type can't remove the `required` state. Derived types can add the `required` modifier when overriding a property.
- A type with any `required` members may not be used as a type argument when the type parameter includes the `new()` constraint. The compiler can't enforce that all required members are initialized in the generic code.
- A constructor that chains to another constructor annotated with the `SetsRequiredMembers` attribute, either `this()`, or `base()`, must also include the `SetsRequiredMembers` attribute. That ensures that callers can correctly use all appropriate constructors.
- Copy constructors generated for `record` types have the `SetsRequiredMembers` attribute applied if any of the members are `required`.
- The `required` modifier isn't allowed on the declaration for positional parameters on a record.

The following code shows a class hierarchy that uses the `required` modifier for the `FirstName` and `LastName` properties:

:::code language="csharp" source="./snippets/RequiredExample.cs" id="SnippetRequired":::
