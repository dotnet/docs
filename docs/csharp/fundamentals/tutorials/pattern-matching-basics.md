---
title: "Tutorial: Pattern matching basics"
description: Build a canal-lock simulation that uses pattern matching to model safe object behavior.
ms.date: 09/29/2026
ms.topic: tutorial
ai-usage: ai-assisted
---

# Tutorial: Pattern matching basics

> [!TIP]
> **New to developing software?** Start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. They introduce classes, methods, and control flow.
>
> **Experienced in another language?** This tutorial shows how C# patterns can express object behavior clearly when rules depend on the current state of an object.

In this tutorial, you build a console app that models the rules for a canal lock.

A canal lock raises or lowers boats between two stretches of water at different heights. It has two gates and a chamber whose water level changes between a low setting and a high setting. The lock can operate safely only when the water level and gate positions stay in valid combinations.

In this tutorial, you learn how to:

> [!div class="checklist"]
>
> - Express object behavior by matching on state.
> - Implement those rules with C# pattern matching.
> - Use compiler diagnostics to validate your implementation.

## Prerequisites

[!INCLUDE [Prerequisites](../../../../includes/prerequisites-basic-winget.md)]

## Build a simulation of a canal lock

A canal lock raises and lowers boats between waterways at different levels. In this tutorial, the simulated lock has a lower gate, an upper gate, and water that can be either low or high.

In normal operation, a boat enters when the water level inside the lock matches the level on the entry side. Once the boat is inside, both gates close. The water level changes to match the exit side, and then the exit gate opens. To keep the model safe, the water level can change only when both gates are closed, and a gate can open only when the water level matches that side.

You can model those rules with a `CanalLock` class. It exposes commands to open or close either gate and to raise or lower the water. It also exposes properties that report the current state of the lock.

## Define the class

Create a console project, then add a class named `CanalLock`. Start by designing the public API and leaving the methods unimplemented:

:::code language="csharp" source="./snippets/pattern-matching-objects/InterimSteps.cs" ID="APIDesign":::

The preceding code initializes the lock with both gates closed and the water level low. Next, add the following code to `Main` to guide your first implementation:

:::code language="csharp" source="./snippets/pattern-matching-objects/Program.cs" ID="HappyTests":::

Now add a first implementation that changes each state value without enforcing the safety rules:

:::code language="csharp" source="./snippets/pattern-matching-objects/InterimSteps.cs" ID="FirstImplementation":::

These first checks pass. You have the mechanics working. Next, add a test for the first failure condition. At the end of the previous sequence, both gates are closed and the water level is low. Try to open the upper gate:

:::code language="csharp" source="./snippets/pattern-matching-objects/Program.cs" ID="HighGateSafetyTest":::

That test fails because the upper gate opens when it should not. A first fix could look like this:

:::code language="csharp" source="./snippets/pattern-matching-objects/InterimSteps.cs" ID="SecondImplementation":::

Your tests pass again. But as you add more conditions, more `if` statements accumulate. The code gets harder to scan because each rule is separated from the others.

## Implement the commands with patterns

A clearer option is to use *patterns* to describe the valid combinations directly. In the next step, each switch expression uses one tuple as the *pattern input*. C# evaluates that tuple once, and each switch arm tests the current gate state, the water level, and the requested new setting.

For the upper gate, those combinations can be summarized like this:

| New setting | Gate state | Water level | Result |
| --- | --- | --- | --- |
| Closed | Closed | High | Closed |
| Closed | Closed | Low | Closed |
| Closed | Open | High | Closed |
| ~~Closed~~ | ~~Open~~ | ~~Low~~ | ~~Closed~~ |
| Open | Closed | High | Open |
| Open | Closed | Low | Closed (error) |
| Open | Open | High | Open |
| ~~Open~~ | ~~Open~~ | ~~Low~~ | ~~Closed (error)~~ |

The struck-through rows represent invalid internal states. The switch expression can encode the valid transitions directly. `false` still means the gate is closed:

:::code language="csharp" source="./snippets/pattern-matching-objects/InterimSteps.cs" ID="ThirdImplementation":::

Try this version. Your tests pass. The compiler also warns that the switch expression isn't *exhaustive* — it doesn't cover every possible value — because `WaterLevel` is an enum, and C# allows any value of the enum's underlying numeric type to be cast to that enum, even one without a named member. Add a final arm with the discard pattern (`_`) to handle those impossible internal states:

```csharp
_ => throw new InvalidOperationException("Invalid internal state"),
```

That arm must be last because the discard pattern matches every remaining input.

You can then simplify the earlier arms. Closing the gate is always allowed, so one arm can replace the four separate closed cases:

```csharp
(false, _, _) => false,
```

You can also combine the valid open cases and preserve the one safety error:

```csharp
(true, _, WaterLevel.High) => true,
(true, false, WaterLevel.Low) => throw new InvalidOperationException("Cannot open high gate when the water is low"),
_ => throw new InvalidOperationException("Invalid internal state"),
```

Run the program again. The tests still pass. Here is the final `SetHighGate` implementation:

:::code language="csharp" source="./snippets/pattern-matching-objects/CanalLock.cs" ID="FinalImplementation":::

## Implement the remaining rules

Now apply the same idea to `SetLowGate` and `SetWaterLevel`. Start by adding tests that expose invalid operations:

:::code language="csharp" source="./snippets/pattern-matching-objects/Program.cs" ID="FinalTestCode":::

Run the app again. These tests fail, and the canal lock reaches invalid states. Implement the remaining methods by matching on the full state. `SetLowGate` is similar to `SetHighGate`. `SetWaterLevel` uses the current water level plus both gate positions:

```csharp
CanalLockWaterLevel = (newLevel, CanalLockWaterLevel, LowWaterGateOpen, HighWaterGateOpen) switch
{
    // arms go here
};
```

You have 16 combinations to consider. Start with the full table, write the switch arms, run the tests, and then simplify repeated outcomes.

Did you end up with methods similar to these?

:::code language="csharp" source="./snippets/pattern-matching-objects/CanalLock.cs" ID="FinalExercise":::

Your tests should now pass, and the canal lock should enforce its safety rules.

## Summary

In this tutorial, you used pattern matching to express how an object can change from one valid state to another. Patterns kept the allowed transitions together so you could compare them more easily than with a long series of branching statements. This approach works well when behavior depends on the combined shape of several state values.
