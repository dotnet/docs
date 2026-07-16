---
title: "Resolve errors and warnings related to readonly structs and members"
description: "This article helps you diagnose and correct compiler errors and warnings related to readonly structs and members"
f1_keywords:
  - "CS8340"
  - "CS8342"
  - "CS8656"
  - "CS8662"
helpviewer_keywords:
  - "CS8340"
  - "CS8342"
  - "CS8656"
  - "CS8662"
ms.date: 07/16/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings related to readonly structs and members

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->
- [**CS8340**](#readonly-struct-declaration-rules): *Instance fields of readonly structs must be readonly.*
- [**CS8342**](#readonly-struct-declaration-rules): *Field-like events are not allowed in readonly structs.*
- [**CS8656**](#readonly-struct-member-restrictions): *Call to non-readonly member 'member' from a 'readonly' member results in an implicit copy of 'type'.*
- [**CS8662**](#readonly-struct-member-restrictions): *Field-like event 'event' cannot be 'readonly'.*

A [`readonly struct`](../builtin-types/struct.md#readonly-struct) declaration promises that instance state doesn't mutate. A [`readonly` instance member](../builtin-types/struct.md#readonly-instance-members) promises that the member doesn't mutate the current instance. The diagnostics in this article cover both declarations and member bodies.

## Readonly struct declaration rules

- **CS8340**: *Instance fields of readonly structs must be readonly.*
- **CS8342**: *Field-like events are not allowed in readonly structs.*

Every instance field declared in a `readonly struct` must also be `readonly` (**CS8340**). Add the `readonly` modifier to each instance field, convert mutable fields to immutable state, or remove `readonly` from the struct declaration when instances must mutate.

Field-like events aren't allowed in a `readonly struct` (**CS8342**) because the compiler-generated backing field is mutable. Use a manually implemented event with explicit `add` and `remove` accessors, or remove `readonly` from the struct declaration.

## Readonly struct member restrictions

- **CS8656**: *Call to non-readonly member 'member' from a 'readonly' member results in an implicit copy of 'type'.*
- **CS8662**: *Field-like event 'event' cannot be 'readonly'.*

A `readonly` instance member of a struct can't mutate `this`. When a `readonly` member calls a non-`readonly` member, the compiler copies `this` before the call so the non-`readonly` member can't modify the original instance. Mark the called member `readonly` when it doesn't modify instance state, or call only members that are already `readonly` (**CS8656**). If the called member must mutate instance state, remove `readonly` from the caller.

Field-like events can't be marked `readonly` (**CS8662**). Remove the `readonly` modifier from the event, or implement the event manually with `add` and `remove` accessors that follow the readonly rules for the containing struct.

## Related diagnostics

For more information about auto-implemented properties in readonly structs, see [Compiler Errors on property declarations](property-declaration-errors.md) in C# compiler messages. That article includes **CS8341**, the third readonly struct declaration rule. For more information about readonly properties, indexers, and accessors, see [Compiler Errors on property declarations](property-declaration-errors.md) in C# compiler messages. For more information about readonly partial declarations, see [Compiler Errors on partial type and member declarations](partial-declarations.md) in C# compiler messages. For more information about readonly types and primary constructors, see [Resolve errors related to constructor declarations and module initializers](constructor-errors.md) in C# compiler messages.
