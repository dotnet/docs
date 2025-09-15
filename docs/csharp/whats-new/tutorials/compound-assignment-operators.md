---
title: Explore user defined instance compound assignment operators
description: "C# 14 enables user defined instance compound assignment operators. These operators can provide better performance by minimizing allocations or copy operations. Learn how to create these operators."
author: billwagner
ms.author: wiwagn
ms.service: dotnet-csharp
ms.topic: tutorial
ms.date: 09/15/2025
ai-usage: ai-assisted
#customer intent: As a C# developer, I want implement user defined instance compound assignment operators so that my algorithms are more efficient.
---
# Tutorial: Create compound assignment operators

C#14.0 adds *user defined compound assignment operators* that enable mutating a data structure in place, rather than creating a new instance. In previous versions of C#, the expression:

```csharp
a += b;
```

Was expanded to the following code:

```csharp
var tmp = a + b;
a = tmp;
```

Depending on the type of `a`, this expansion leads to excessive allocations to create new instances, or copying the values of several properties to set values on the copy. Adding a user defined operator for `+=` indicates a type can do a better job by updating the destination object in place.

C# supports the existing expansion, but it uses it only when a compound user defined operator isn't available.

In this tutorial, you:

> [!div class="checklist"]
> 
> * Install prerequisites
> * Analyze the starting sample
> * Implement compound assignment operators
> * Analyze completed sample

## Prerequisites

- The .NET 10 preview SDK. Download it from the [.NET download site](https://dotnet.microsoft.com/download/dotnet/10.0).
- Visual Studio 2026 (preview). Download it from the [Visual Studio insiders page](https://visualstudio.microsoft.com/insiders/).

## Analyze the starting sample

Run the starter application. You can get it from [the `dotnet/docs` GitHub repository](https://github.com/dotnet/docs/blob/main/docs/csharp/whats-new/tutorials/snippets/CompoundAssignment). The sample application simulates concert attendance tracking at a theater venue. The simulation models realistic arrival patterns throughout the evening, from early attendees to the main rush before showtime. This simulation demonstrates the object allocations when using traditional operators versus the efficiency gains possible with user-defined compound assignment operators.

The app tracks attendance through multiple theater gates (main floor and balcony sections) as concert-goers arrive. Each gate maintains a count of attendees using a `GateAttendance` record. Throughout the simulation, the code frequently updates these counts using increment (`++`) and addition (`+=`) operations. The following code shows a portion of that simulation:

:::code language="csharp" source="./snippets/CompoundAssignment/GateAttendanceTests.cs" id="Simulation":::

With traditional operators, each operation creates a new `GateAttendance` instance due to the immutable nature of records, leading to significant memory allocations.

When you run the simulation, you see detailed output showing:

- Gate-by-gate attendance numbers during different arrival periods.
- Total attendance tracking across all gates.
- A final comprehensive report with attendance statistics.

You can see a portion of the output:

```txt
Peak arrival time - all gates busy...

Peak rush period completed - all gates processed heavy traffic.

--- Gate Status After Main Rush (7:15 PM) ---
Main Floor Gates:
  Main-Floor-Gate-1: 145 attendees
  Main-Floor-Gate-2: 168 attendees
  Main-Floor-Gate-3: 149 attendees
  Main-Floor-Gate-4:  71 attendees
  Main Floor Subtotal: 533 attendees

Balcony Gates:
  Balcony-Gate-Left: 164 attendees
  Balcony-Gate-Right: 134 attendees
  Balcony Subtotal: 298 attendees

Total Current Attendance: 831 / 1000

--- Late Arrivals (7:15 PM - 7:30 PM) ---
Final patrons arriving before curtain...

Final arrivals processed - concert about to begin!
```

This realistic scenario provides an excellent test case for measuring the performance benefits of compound assignment operators, as the frequent count updates mirror common patterns in real applications where objects are repeatedly modified.

Examine the starter `GateAttendance` record class:

:::code language="csharp" source="./snippets/CompoundAssignment/GateAttendance.cs" id="GateAttendanceStarter":::

The `InitialImplementation.GateAttendance` record demonstrates the traditional approach to operator overloading in C#. Notice how both the increment operator (`++`) and addition operator (`+`) create entirely new instances of `GateAttendance` using the `with` expression. Each time you write `gate++` or `gate += partySize`, the operators allocate a new record instance with the updated `Count` value, then return that new instance. While this approach maintains immutability and thread safety, it comes at the cost of frequent memory allocations. In scenarios with many operations—like our concert simulation with hundreds of attendance updates—these allocations accumulate quickly, potentially impacting performance and increasing garbage collection pressure.

To see this allocation behavior in action, try running the [.NET Object Allocation tracking tool](~/visualstudio/profiling/dotnet-alloc-tool) in Visual Studio. When you profile the current implementation during the concert simulation, you discover that it allocates 134 `GateAttendance` objects to complete the relatively small simulation. Each operator call creates a new instance, demonstrating how quickly allocations can accumulate in real-world scenarios. This measurement provides a concrete baseline for comparing the performance improvements you achieve with compound assignment operators.

## Implement compound assignment operators

C# 14 introduces user-defined compound assignment operators that enable in-place mutations instead of creating new instances. These operators provide a more efficient alternative to the traditional pattern while maintaining the familiar compound assignment syntax.

Compound assignment operators use a new syntax that declares `void` return methods with the `operator` keyword. Add the following operators to the `GateAttendance` class:

```csharp
public void operator +=(int value) => this.property += value;
public void operator ++() => this.property++;
```

The key differences from traditional operators are:

- **Mutation**: They modify the current instance directly using `this`
- **No new instances**: Unlike traditional operators that return new objects, compound operators modify existing ones
- **Return type**: Compound assignment operators return `void`, not the type itself

When the compiler encounters compound assignment expressions like `a += b` or `++a`, it follows this resolution order:

1. **Check for compound assignment operator**: If the type defines a user-defined compound assignment operator (`+=`, `++`, etc.), use it directly
2. **Fallback to traditional expansion**: If no compound operator exists, expand to the traditional form (`a = a + b`)

This means you can implement both approaches simultaneously. The compound operators take precedence when available, but the traditional operators serve as fallbacks for scenarios where compound assignment isn't suitable.

Compound assignment operators provide several advantages:

- **Reduced allocations**: Modify objects in-place instead of creating new instances
- **Improved performance**: Eliminate temporary object creation and reduce garbage collection pressure  
- **Familiar syntax**: Use the same `+=`, `++` syntax developers already know
- **Backward compatibility**: Traditional operators continue to work as fallbacks

The new compound assignment operators are shown in the following code:

:::code language="csharp" source="./snippets/CompoundAssignment/GateAttendance.cs" id="CompoundAssignmentOperators":::

## Analyze finished sample

Now that you implemented the compound assignment operators, it's time to measure the performance improvement. To see the dramatic difference in memory allocations, run the [.NET Object Allocation tracking tool](/visualstudio/profiling/dotnet-alloc-tool) again on the updated code.

When you profile the application with the compound assignment operators enabled, you observe a remarkable reduction: only **10 `GateAttendance` objects** are allocated during the entire concert simulation, compared to the previous 134 allocations. This update represents a 92% reduction in object allocations!

The remaining 10 allocations come from the initial creation of the `GateAttendance` instances for each theater gate (four main floor gates + two balcony gates = six initial instances), plus a few more allocations from other parts of the simulation that don't use the compound operators.

This allocation reduction translates to real performance benefits:

- **Reduced memory pressure**: Less frequent garbage collection cycles
- **Better cache locality**: Fewer object creations mean less memory fragmentation  
- **Improved throughput**: CPU cycles saved from allocation and collection overhead
- **Scalability**: Benefits multiply in scenarios with higher operation volumes

The performance improvement becomes even more significant in production applications where similar patterns occur at much larger scales—imagine tracking millions of transactions, updating thousands of counters, or processing high-frequency data streams.

Try identifying other opportunities for compound assignment operators in the codebase. Look for patterns where you see traditional assignment operations like `gates.MainFloorGates[1] = gates.MainFloorGates[1] + 4` and consider whether they could benefit from compound assignment syntax. While some of these operations are already using `+=` in the simulation code, the principle applies to any scenario where you're repeatedly modifying objects rather than creating new instances.

As a final experiment, change the `GateAttendance` type from a `record class` to a `record struct`. It's a different optimization, and it works in this simulation because the struct has a small memory footprint. Copying a `GateAttendance` struct isn't an expensive operation. Even so, you see small improvements.

## Related content

- [What's new in C# 14](../csharp-14.md)
- [Operator overloading - define unary, arithmetic, equality, and comparison operators](../../language-reference/operators/operator-overloading.md)
- [Analyze memory usage by using the .NET Object Allocation tool - Visual Studio](/visualstudio/profiling/dotnet-alloc-tool)
