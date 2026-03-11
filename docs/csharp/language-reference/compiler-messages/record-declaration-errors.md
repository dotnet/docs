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

The C# compiler generates errors and warnings when you misuse [record types](../builtin-types/record.md). Record types provide built-in members that implement value-based equality. These diagnostics help you follow the rules for declaring and using record types.

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->
- [**CS8851**](#equality-members): *'Type' defines 'Equals' but not 'GetHashCode'*
- [**CS8858**](#equality-members): *The receiver type is not a valid record type and is not a struct type.*
- [**CS8859**](#reserved-member-names): *Members named 'Clone' are disallowed in records.*
- [**CS8860**](#reserved-member-names): *Types and aliases should not be named 'record'.*
- [**CS8864**](#record-inheritance): *Records may only inherit from object or another record.*
- [**CS8865**](#record-inheritance): *Only records may inherit from records.*
- [**CS8866**](#positional-members): *Record member must be a readable instance property or field of the type to match the positional parameter.*
- [**CS8870**](#synthesized-member-signatures): *Member cannot be sealed because containing record is not sealed.*
- [**CS8872**](#synthesized-member-signatures): *Member must allow overriding because the containing record is not sealed.*
- [**CS8873**](#synthesized-member-signatures): *Record member must be public.*
- [**CS8874**](#synthesized-member-signatures): *Record member must return type.*
- [**CS8875**](#synthesized-member-signatures): *Record member must be protected.*
- [**CS8877**](#synthesized-member-signatures): *Record member may not be static.*
- [**CS8879**](#synthesized-member-signatures): *Record member must be private.*
- [**CS8908**](#positional-members): *The type may not be used for a field of a record.*
- [**CS8913**](#positional-members): *The positional member found corresponding to this parameter is hidden.*

In addition, this article covers the following warning:

- [**CS8907**](#positional-members): *Parameter is unread. Did you forget to use it to initialize the property with that name?*

## Synthesized member signatures

- **CS8870**: *Member cannot be sealed because containing record is not sealed.*
- **CS8872**: *Member must allow overriding because the containing record is not sealed.*
- **CS8873**: *Record member must be public.*
- **CS8874**: *Record member must return type.*
- **CS8875**: *Record member must be protected.*
- **CS8877**: *Record member may not be static.*
- **CS8879**: *Record member must be private.*

When you explicitly declare a member that the compiler would otherwise synthesize for a [record type](../builtin-types/record.md), your declaration must match the expected signature, accessibility, and modifiers. For the complete rules, see the [feature specification for records](~/_csharplang/proposals/csharp-9.0/records.md).

To correct these errors, apply the following changes to your explicitly declared record members:

- Change the accessibility of the `Equals` method, `GetHashCode`, `ToString`, the deconstruct method, and the `EqualityContract` property or `op_Equality` and `op_Inequality` operators to `public`. The compiler requires these members to be publicly accessible so that value-based [equality](../builtin-types/record.md#value-equality) works correctly across all calling contexts (**CS8873**).
1-- Change the accessibility of the `PrintMembers` method to `protected` when you declare it in a non-sealed record class. The method must be `protected` because derived records override it to include their own properties in the [formatted output](../builtin-types/record.md#built-in-formatting-for-display) (**CS8875**).
- Change the accessibility of the `PrintMembers` method to `private` when you declare it in a sealed record class or a record struct. Because no derived type can exist, the method doesn't need to be accessible outside the type (**CS8879**).
- Remove the `static` modifier from any explicitly declared synthesized member. Synthesized members operate on specific record instances to implement behaviors like equality comparison, formatting, and copying, so they must be instance members (**CS8877**).
- Change the return type of the member to match the type the compiler expects. For example, the `EqualityContract` property must return `System.Type`, and the `Equals` method must return `bool`. The compiler relies on these exact return types to generate correct code for [equality](../builtin-types/record.md#equality-in-inheritance-hierarchies) and other synthesized behaviors (**CS8874**).
- Remove the `sealed` modifier from any explicitly declared synthesized member in a non-sealed record. Derived records must be able to override these members to provide their own value-based equality and formatting logic (**CS8870**).
- Declare explicitly provided synthesized members as `virtual` or `override` in a non-sealed record. The compiler requires these members to allow overriding so that derived records in the [inheritance hierarchy](../builtin-types/record.md#equality-in-inheritance-hierarchies) can customize their behavior (**CS8872**).

## Positional members

- **CS8866**: *Record member must be a readable instance property or field of the type to match the positional parameter.*
- **CS8907**: *Parameter is unread. Did you forget to use it to initialize the property with that name?*
- **CS8908**: *The type may not be used for a field of a record.*
- **CS8913**: *The positional member found corresponding to this parameter is hidden.*

When you declare a [positional record](../builtin-types/record.md#positional-syntax-for-property-and-field-definition), the compiler synthesizes properties that correspond to each positional parameter. These diagnostics indicate that your explicit declarations conflict with those synthesized properties. For the complete rules, see the [feature specification for records](~/_csharplang/proposals/csharp-9.0/records.md).

To correct these errors, apply the following changes to your positional record declarations:

- Change any explicitly declared member that corresponds to a positional parameter so that it's a readable instance property or field with the same type as the parameter. The compiler needs the member to be readable and type-compatible so that the synthesized `Deconstruct` method and [positional pattern matching](../../fundamentals/functional/pattern-matching.md) can access the value correctly (**CS8866**).
- Ensure that each positional parameter is used to initialize its corresponding property in the constructor body when you provide an explicit constructor. The compiler raises a warning when a parameter goes unused because it typically indicates a typo or a mismatch between the parameter name and the property name, which would leave the property uninitialized (**CS8907**).
- Change the type of a field declared in a record to a type that's valid in that context. Certain types, such as `Span<T>` or other `ref struct` types, can't be used as fields in a record because record types require all fields to be compatible with heap allocation and value-based equality (**CS8908**).
- Remove the `new` modifier from a member in a derived record that hides a positional member from the base record. When a positional member is hidden, the compiler can't match the positional parameter to its corresponding property, which breaks the synthesized `Deconstruct` method and positional [pattern matching](../../fundamentals/functional/pattern-matching.md) (**CS8913**).

## Equality members

- **CS8851**: *Type defines 'Equals' but not 'GetHashCode'*
- **CS8858**: *The receiver type is not a valid record type and is not a struct type.*

[Record types](../builtin-types/record.md) provide built-in [value-based equality](../builtin-types/record.md#value-equality). These diagnostics arise when your declarations conflict with the equality contract. For the complete rules on equality, see [equality comparisons](../../programming-guide/statements-expressions-operators/equality-comparisons.md).

To correct these errors, apply the following changes:

- Add a `GetHashCode` method whenever you define an `Equals` method. The [equality contract](../../programming-guide/statements-expressions-operators/equality-comparisons.md) requires that objects considered equal produce the same hash code, so the compiler enforces that these two methods are always defined together (**CS8851**).
- Change the receiver of a `with` expression so that it's a [record type](../builtin-types/record.md) or a [struct type](../builtin-types/struct.md). The `with` expression creates a modified copy by using the type's copy constructor, which is only available on record types and struct types (**CS8858**).

## Record inheritance

- **CS8864**: *Records may only inherit from object or another record*
- **CS8865**: *Only records may inherit from records.*

[Record class types](../builtin-types/record.md) follow specific [inheritance](../builtin-types/record.md#equality-in-inheritance-hierarchies) rules. For the complete rules, see the [feature specification for records](~/_csharplang/proposals/csharp-9.0/records.md).

To correct these errors, apply the following changes:

- Change the base type of a record class so that it inherits from `object` or from another record class. Record types rely on compiler-synthesized members for equality and copying that are only compatible with other record types, so the compiler doesn't allow a record to inherit from a non-record class (**CS8864**).
- Change a non-record class that inherits from a record class so that it's declared as a record class instead. Because record types synthesize equality, cloning, and other members that depend on a consistent inheritance chain, the compiler requires every type in the hierarchy to be a record class (**CS8865**). Record struct types can't participate in inheritance hierarchies beyond implementing interfaces.

## Reserved member names

- **CS8859**: *Members named 'Clone' are disallowed in records.*
- **CS8860**: *Types and aliases should not be named 'record'.*

The compiler reserves certain names for use with [record types](../builtin-types/record.md). For the complete rules, see the [feature specification for records](~/_csharplang/proposals/csharp-9.0/records.md).

To correct these errors, apply the following changes:

- Rename any member called `Clone` in a record type to a different name. The compiler uses `Clone` internally to implement the copy semantics for [`with` expressions](../operators/with-expression.md), so declaring your own `Clone` member conflicts with the synthesized implementation (**CS8859**).
- Rename any type or alias named `record` to a different name. Because `record` is a [contextual keyword](../keywords/index.md#contextual-keywords) used for declaring record types, naming a type or alias `record` creates ambiguity that can confuse both the compiler and developers reading the code (**CS8860**).
