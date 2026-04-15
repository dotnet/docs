---
title: "Tutorial: Choose between tuples, records, structs, and classes"
description: "Learn when to use tuples, record classes, record structs, classes, and interfaces in C# by building a coffee shop example that highlights each type's strengths."
ms.date: 04/15/2026
ms.topic: tutorial
ai-usage: ai-assisted
---

# Tutorial: Choose between tuples, records, structs, and classes

> [!TIP]
> This article is part of the **Fundamentals** section, written for developers who know at least one programming language and are learning C#. If you're new to programming, start with [Get started](../../tour-of-csharp/index.yml). For a quick reference table, see [Choose which kind of type](../types/index.md#choose-which-kind-of-type).

C# gives you several ways to group data: tuples, record classes, record structs, classes, and interfaces. Picking the right one depends on whether you need naming, equality, mutability, or polymorphism. In this tutorial, you build a small coffee shop model that puts each type to work so you can see where each one shines.

In this tutorial, you:

> [!div class="checklist"]
>
> - Return multiple values from a method with a tuple.
> - Model immutable data with a record class.
> - Represent small value types with a record struct.
> - Manage mutable state and behavior with a class.
> - Define shared capabilities with an interface.

## Prerequisites

- Install the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later.

## Use a tuple for a temporary grouping

When a method needs to return two or three values and you don't want to declare a dedicated type, use a **tuple**. Named elements make the intent clear at the call site, and you can deconstruct the result into separate variables when that reads better.

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="TupleDemo":::

The `GetDailySummary` method returns an `(int TotalOrders, decimal Revenue)` tuple. The caller accesses each element by name or deconstructs both into local variables. No class or struct definition is needed.

**When to reach for a tuple:**

- A method returns two or three related values.
- The grouping is local—callers don't pass the result across many layers.
- Named elements are enough to convey meaning without a full type.

If you find yourself passing the same tuple shape across multiple methods, promote the tuple to a record or class. For more detail on tuple syntax and capabilities, see [Tuple types](../types/tuples.md).

## Use a record for immutable data

When two instances with the same data should be considered equal—and you rarely change the values after creation—use a **record class**. Records give you value-based equality, a readable `ToString()`, and the `with` expression for creating modified copies.

Start by declaring a positional record:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="MenuItem":::

The compiler generates a constructor, deconstructor, `Equals`, `GetHashCode`, and `ToString` from that single line. Use the record in your coffee shop:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="RecordClassDemo":::

Two `MenuItem` instances built from the same values are equal even though they're separate objects. The `with` expression creates a seasonal variant without mutating the original.

**When to reach for a record class:**

- Identity is defined by data, not by object reference.
- Instances are mostly immutable after creation.
- You want readable `ToString()` output and structural equality out of the box.

For a deeper walkthrough, see [Records](../types/records.md) and the [records tutorial](records.md).

## Use a record struct for small value types

A **record struct** combines value semantics with the convenience of records. Because structs are copied on assignment, each variable holds its own data—changes to one copy never affect another. Use a record struct when the data is small and copying is cheap.

Declare a record struct:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="Measurement":::

Then use the record struct:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="RecordStructDemo":::

Assigning `temp` to `copy` creates an independent value. The `with` expression produces a new value without touching the original—the same pattern as a record class, but with copy-on-assign behavior instead of copy-by-reference.

**When to reach for a record struct:**

- The data is small (a few primitive fields).
- You want value equality and `with` support.
- Copying is cheaper than heap allocation—common for measurements, coordinates, and similar lightweight data.

For more context, see [Records](../types/records.md) and [Structure types](../types/structs.md).

## Use a class when you need mutable state and behavior

Classes are reference types with identity. Two variables can point to the same object, and mutations through one variable are visible through the other. Reach for a class when an entity carries mutable state, exposes behavior, or needs to be tracked by reference.

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="Order":::

The `Order` class tracks items, computes a running total, and exposes a settable `Status`. This kind of mutation-heavy, behavior-rich type is a natural fit for a class.

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="ClassDemo":::

**When to reach for a class:**

- The object has mutable state that changes over its lifetime.
- Behavior (methods) is central to the type's purpose.
- Identity matters—two orders with the same items are still distinct orders.

For more detail, see [Classes, structs, and records](../types/classes.md).

## Use an interface to define shared capabilities

An **interface** declares a contract—a set of members that any implementing type must provide. Use an interface when unrelated types need to share a capability, or when you want to swap implementations at run time.

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="Interfaces":::

The `Checkout` method accepts any `IDiscountPolicy`, so you can introduce new policies without changing the checkout logic:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="InterfaceDemo":::

**When to reach for an interface:**

- Multiple unrelated types share a behavior (for example, discounting, serializing, or logging).
- You want to swap implementations at run time or in tests.
- You need polymorphic dispatch without a common base class.

For more detail, see [Interfaces](../types/interfaces.md).

## Quick decision guide

Use this table as a starting point when you aren't sure which type to pick:

| Question | Best fit |
|---|---|
| Returning a few values from one method? | Tuple |
| Immutable data where equality is by values? | Record class |
| Small, copyable value data with equality? | Record struct |
| Mutable state, behavior, or reference identity? | Class |
| Shared capability across unrelated types? | Interface |

If none of these fit neatly, consider combining types. For example, a class can implement an interface, and a record can be a struct. For the full comparison, see [Choose which kind of type](../types/index.md#choose-which-kind-of-type).

## See also

- [Tuple types](../types/tuples.md)
- [Records](../types/records.md)
- [Structure types](../types/structs.md)
- [Classes, structs, and records](../types/classes.md)
- [Interfaces](../types/interfaces.md)
- [Choose which kind of type](../types/index.md#choose-which-kind-of-type)
