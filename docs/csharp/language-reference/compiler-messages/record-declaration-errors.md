---
title: Resolve errors and warnings related to record declarations
description: Learn how to diagnose and correct C# compiler errors and warnings when you declare record types, either record struct types or record class types.
f1_keywords:
  - "CS8851"
  - "CS8858"
  - "CS8859"
  - "CS8860"
  - "CS8864"
  - "CS8865"
  - "CS8866"
  - "CS8870"
  - "CS8872"
  - "CS8873"
  - "CS8874"
  - "CS8875"
  - "CS8877"
  - "CS8879"
  - "CS8907"
  - "CS8908"
  - "CS8913"
helpviewer_keywords:
  - "CS8851"
  - "CS8858"
  - "CS8859"
  - "CS8860"
  - "CS8864"
  - "CS8865"
  - "CS8866"
  - "CS8870"
  - "CS8872"
  - "CS8873"
  - "CS8874"
  - "CS8875"
  - "CS8877"
  - "CS8879"
  - "CS8907"
  - "CS8908"
  - "CS8913"
ms.date: 03/06/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for record declarations

The C# compiler generates errors and warnings when you misuse [record types](../builtin-types/record.md). Record types provide built in members that implement value-based equality. These diagnostics help you follow the rules for declaring and using record types.

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS8851**](#equality-members): *'{0}' defines 'Equals' but not 'GetHashCode'*
- [**CS8858**](#equality-members): *The receiver type '{0}' is not a valid record type and is not a struct type.*
- [**CS8859**](#reserved-member-names): *Members named 'Clone' are disallowed in records.*
- [**CS8860**](#reserved-member-names): *Types and aliases should not be named 'record'.*
- [**CS8864**](#record-inheritance): *Records may only inherit from object or another record*
- [**CS8865**](#record-inheritance): *Only records may inherit from records.*
- [**CS8866**](#positional-members): *Record member '{0}' must be a readable instance property or field of type '{1}' to match positional parameter '{2}'.*
- [**CS8870**](#synthesized-member-signatures): *'{0}' cannot be sealed because containing record is not sealed.*
- [**CS8872**](#synthesized-member-signatures): *'{0}' must allow overriding because the containing record is not sealed.*
- [**CS8873**](#synthesized-member-signatures): *Record member '{0}' must be public.*
- [**CS8874**](#synthesized-member-signatures): *Record member '{0}' must return '{1}'.*
- [**CS8875**](#synthesized-member-signatures): *Record member '{0}' must be protected.*
- [**CS8877**](#synthesized-member-signatures): *Record member '{0}' may not be static.*
- [**CS8879**](#synthesized-member-signatures): *Record member '{0}' must be private.*

In addition, the following warnings are covered in this article:

- [**CS8907**](#positional-members): *Parameter '{0}' is unread. Did you forget to use it to initialize the property with that name?*

The following errors are also covered:

- [**CS8908**](#positional-members): *The type '{0}' may not be used for a field of a record.*
- [**CS8913**](#positional-members): *The positional member found corresponding to this parameter is hidden.*

## Synthesized member signatures

- **CS8870**: *'{0}' cannot be sealed because containing record is not sealed.*
- **CS8872**: *'{0}' must allow overriding because the containing record is not sealed.*
- **CS8873**: *Record member '{0}' must be public.*
- **CS8874**: *Record member '{0}' must return '{1}'.*
- **CS8875**: *Record member '{0}' must be protected.*
- **CS8877**: *Record member '{0}' may not be static.*
- **CS8879**: *Record member '{0}' must be private.*

The compiler synthesizes several members for [record types](../builtin-types/record.md), including methods for value-based equality, a `PrintMembers` method, and a copy constructor. When you explicitly declare any of these members, your declaration must match the expected signature, accessibility, and modifiers. For more information, see the [C# language specification for records](~/_csharpstandard/standard/classes.md#1428-record-types).

Ensure that explicitly declared synthesized members use the correct accessibility modifier. The `Equals` method, `GetHashCode`, `ToString`, the deconstruct method, and the `EqualityContract` or `op_Equality` and `op_Inequality` operators must be `public` (**CS8873**). The `PrintMembers` method must be `protected` in a non-sealed record class, or `private` in a sealed record class or record struct (**CS8875**, **CS8879**). Members that replace synthesized members can't be `static` (**CS8877**). Synthesized members must return the expected type—for example, `EqualityContract` must return `System.Type`, and `Equals` must return `bool` (**CS8874**). In a non-sealed record, don't mark synthesized members as `sealed`, because derived records must be able to override them (**CS8870**). Similarly, synthesized members in a non-sealed record must allow overriding—declare them as `virtual` or `override` (**CS8872**).

## Positional members

- **CS8866**: *Record member '{0}' must be a readable instance property or field of type '{1}' to match positional parameter '{2}'.*
- **CS8907**: *Parameter '{0}' is unread. Did you forget to use it to initialize the property with that name?*
- **CS8908**: *The type '{0}' may not be used for a field of a record.*
- **CS8913**: *The positional member found corresponding to this parameter is hidden.*

[Positional records](../builtin-types/record.md#positional-syntax-for-property-definition) declare parameters in the record declaration. The compiler synthesizes properties that correspond to each positional parameter. These diagnostics indicate issues with those positional parameters and their corresponding members.

When you explicitly declare a member that corresponds to a positional parameter, that member must be a readable instance property or field of the same type as the parameter (**CS8866**). If a positional parameter doesn't initialize the corresponding property, the compiler generates a warning to help you catch potential mistakes (**CS8907**). The type used for a field in a record must be valid for that context (**CS8908**). If the member corresponding to a positional parameter is hidden (for example, by a `new` modifier in a derived record), the compiler reports an error because the positional member isn't accessible (**CS8913**).

## Equality members

- **CS8851**: *'{0}' defines 'Equals' but not 'GetHashCode'*
- **CS8858**: *The receiver type '{0}' is not a valid record type and is not a struct type.*

[Record types](../builtin-types/record.md) provide built-in value-based equality. These diagnostics arise when your declarations conflict with the equality contract. For more information, see [equality comparisons](../../programming-guide/statements-expressions-operators/equality-comparisons.md).

If you define an `Equals` method, you must also define `GetHashCode` to maintain the equality contract—objects that are equal must produce the same hash code (**CS8851**). The `with` expression requires the receiver to be a valid record type or a struct type. Using `with` on an unsupported type produces this error (**CS8858**).

## Record inheritance

- **CS8864**: *Records may only inherit from object or another record*
- **CS8865**: *Only records may inherit from records.*

[Record class types](../builtin-types/record.md) follow specific inheritance rules. A record class can only inherit from `object` or from another record class (**CS8864**). Conversely, only a record class can inherit from another record class—a regular class can't use a record class as its base type (**CS8865**). Record struct types can't participate in inheritance hierarchies beyond implementing interfaces.

## Reserved member names

- **CS8859**: *Members named 'Clone' are disallowed in records.*
- **CS8860**: *Types and aliases should not be named 'record'.*

The compiler reserves certain names for use with [record types](../builtin-types/record.md).

Don't declare a member named `Clone` in a record type. The compiler uses `Clone` internally to implement the copy semantics for `with` expressions (**CS8859**). The name `record` is a contextual keyword used for declaring record types. Naming a type or alias `record` creates ambiguity, so the compiler warns against it (**CS8860**).
