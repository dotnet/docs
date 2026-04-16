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

One of your first design decisions in any C# application is choosing which kind of type to create. Should a menu item be a `class` or a `record`? Should a quick calculation return a `tuple` or a named type? Each choice shapes how your code handles equality, mutability, and polymorphism—and the wrong pick leads to boilerplate, bugs, or both.

In this tutorial, you build a small coffee shop model—menu items, orders, sensor readings, and discount policies—that puts each type to work. Along the way, you learn to recognize the design pressures that point toward one type over another.

In this tutorial, you:

> [!div class="checklist"]
>
> - Recognize when a tuple is the right fit for returning multiple values.
> - Model immutable data with a record class and understand value-based equality.
> - Represent small, copyable data with a record struct.
> - Manage mutable state and behavior with a class.
> - Extend a class through inheritance to add or tighten rules.
> - Define shared capabilities across unrelated types with an interface.

## Prerequisites

- Install the [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later.

## Use a tuple for a temporary grouping

The coffee shop needs a method that returns both the total number of orders and the revenue for the day. You could define a class or struct for that, but two values from one method don't always justify a new type.

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="TupleDemo":::

`GetDailySummary` returns an `(int TotalOrders, decimal Revenue)` **tuple**. The caller accesses each element by name or deconstructs both into local variables—no class or struct definition needed.

A tuple works here because the grouping is local: one method produces it, and one caller consumes it. Named elements make the intent clear without the ceremony of a full type. If you find yourself passing the same tuple shape across multiple methods, that's a signal to promote it to a record or class—you'll see that evolution [later in this tutorial](#tuple--record-the-grouping-keeps-showing-up). For more detail on tuple syntax and capabilities, see [Tuple types](../types/tuples.md).

## Use a record for immutable data

Every coffee shop needs a menu. A menu item has a name, a price, and a nutritional note—and those values don't change once the item is listed. Two systems that both reference a "Latte at $4.50" should agree they're talking about the same thing, even if they created separate objects.

Declare a positional record:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="MenuItem":::

The compiler generates a constructor, deconstructor, `Equals`, `GetHashCode`, and `ToString` from that single line. Put the record to work:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="RecordClassDemo":::

Two `MenuItem` instances with the same data are equal even though they're separate objects—that's value-based equality at work. The `with` expression creates a seasonal variant without mutating the original.

A **record class** is the right fit when identity comes from data, not from object reference, and instances rarely change after creation. You get readable `ToString()` output, structural equality, and `with` support out of the box. For a deeper walkthrough, see [Records](../types/records.md) and the [records tutorial](records.md).

## Use a record struct for small value types

The coffee machine has a built-in thermometer that reports temperature readings. Each reading is tiny—a number and a unit—and gets copied into logs, alerts, and dashboards. You don't want a change in one copy to ripple through the others.

Declare a record struct:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="Measurement":::

Use the record struct:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="RecordStructDemo":::

Assigning `temp` to `copy` creates an independent value. The `with` expression produces a new value without touching the original—the same pattern as a record class, but with copy-on-assign behavior instead of copy-by-reference.

A **record struct** fits when the data is small (a few primitive fields) and copying is cheaper than heap allocation. You get value equality and `with` support just like a record class, with true value semantics underneath. Measurements, coordinates, and similar lightweight data are natural candidates. For more context, see [Records](../types/records.md) and [Structure types](../types/structs.md).

## Use a class when you need mutable state and behavior

When a customer walks up to the counter, the barista starts an order and adds items one at a time. The total grows, the status changes from "Pending" to "Ready," and two orders placed at the same time—even with identical items—are still distinct orders.

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="Order":::

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="ClassDemo":::

The `Order` class tracks items, computes a running total, and exposes a settable `Status`. A **class** is the right tool here because the object carries mutable state that changes over its lifetime, behavior (methods) is central to the type's purpose, and identity matters—two orders with the same items are still distinct orders. For more detail, see [Classes, structs, and records](../types/classes.md).

## Extend a class with inheritance

The coffee shop starts catering events. A catering order is still an order—it has items and a total—but it also tracks a guest count and requires manager approval before the kitchen marks it ready. Rather than duplicating `Order`'s logic, derive a specialized class.

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="CateringOrder":::

`CateringOrder` reuses `AddItem` and `Total` from the base class. The `Status` override tightens the contract—calling `Status = "Ready"` without prior approval throws an exception:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="InheritanceDemo":::

This single derived class illustrates three inheritance concepts:

- **Added state**: `MinimumGuests` and `ApprovedBy` exist only on the derived class.
- **Added behavior**: `Approve` is new—base `Order` doesn't know about approvals.
- **Overridden behavior**: the `Status` setter enforces a business rule that the base class doesn't have.

Inheritance fits when the new type *is a* specialized version of the base type and you need to reuse existing state and behavior while adding or tightening rules. A shared base class is more natural than an interface when the types share implementation, not just a contract.

## Use an interface to define shared capabilities

The coffee shop runs different promotions—happy hour, loyalty rewards, seasonal specials. The checkout process needs to apply whichever discount is active today, without knowing the specifics of each policy. You need a way to say "anything that can apply a discount" without tying checkout to a single class.

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="Interfaces":::

The `Checkout` method accepts any `IDiscountPolicy`, so you can introduce new policies without changing the checkout logic:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="InterfaceDemo":::

An **interface** declares a contract—a set of members that any implementing type must provide. The interface works here because the discount types are unrelated (they don't share a base class), yet checkout needs to treat them uniformly. Interfaces also make testing easy: swap in a stub policy without touching production code. For more detail, see [Interfaces](../types/interfaces.md).

## Evolve your type choices

None of these decisions are permanent—especially before you release a library where breaking changes become costly. As requirements grow, promote a simple type to a richer one. Here are three common evolutions.

### Tuple → record: the grouping keeps showing up

The `GetDailySummary` tuple works fine inside one method, but once you start passing it to reports, dashboards, and tests, a named type pays for itself. Promote the tuple to a record and add computed properties:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="DailySummary":::

Callers that previously destructured the tuple now get `ToString()` for free, value equality, and a natural place for derived data like `AverageTicket`:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="EvolveTupleToRecord":::

### Struct → class: you need inheritance

The shop's maintenance team asks for calibrated readings—a sensor value adjusted by an offset. The `Measurement` record struct is great for raw data, but structs don't support inheritance, so you can't derive a calibrated variant. Promote to a class hierarchy:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="SensorReading":::

`CalibratedReading` inherits from `SensorReading` and overrides `Display()` to include the offset. This pattern isn't possible with a struct or record struct:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="EvolveStructToClass":::

### Class → class + interface: you need polymorphism across types

The `Order` class works well on its own, but once `CateringOrder` exists, checkout, reporting, and printing all need to handle *any* order without caring which concrete type it is. Extract an interface with the members that callers actually depend on:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="IOrder":::

Both `Order` and `CateringOrder` already satisfy this contract. Now a single method handles either type:

:::code language="csharp" source="./snippets/choosing-types/Program.cs" id="EvolveClassToInterface":::

Extracting the interface doesn't change `Order` or `CateringOrder`—it just makes their shared shape explicit, which also makes testing easier.

## Quick decision guide

Use this table as a starting point when you aren't sure which type to pick:

| Question | Best fit |
|---|---|
| Returning a few values from one method? | Tuple |
| Immutable data where equality is by values? | Record class |
| Small, copyable value data with equality? | Record struct |
| Mutable state, behavior, or reference identity? | Class |
| Specialized version of an existing class? | Derived class |
| Shared capability across unrelated types? | Interface |

If none of these fit neatly, consider combining types. For example, a class can implement an interface, and a record can be a struct. For the full comparison, see [Choose which kind of type](../types/index.md#choose-which-kind-of-type).

## See also

- [Tuple types](../types/tuples.md)
- [Records](../types/records.md)
- [Structure types](../types/structs.md)
- [Classes, structs, and records](../types/classes.md)
- [Interfaces](../types/interfaces.md)
- [Choose which kind of type](../types/index.md#choose-which-kind-of-type)
