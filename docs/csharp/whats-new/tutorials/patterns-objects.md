---
title: Use patterns in objects - C# tutorial
description: This tutorial teaches you techniques to use pattern matching in class members to create better models for object behavior
ms.date: 11/05/2020
---
# Use pattern matching to build your class behavior for better code

The pattern matching features in C# provide syntax to express your algorithms. You can use these techniques to implement the behavior in your classes. You can combine object-oriented class design with a data-oriented implementation to provide concise code while modeling real-world objects.

In this tutorial, you'll learn how to:

> [!div class="checklist"]
>
> - Express your object oriented classes using data patterns.
> - Implement those patterns using C#'s pattern matching features.
> - Leverage compiler diagnostics to validate your implementation.

## Prerequisites

You'll need to set up your machine to run .NET 5, including the C# 9 compiler. The C# 9 compiler is available starting with [Visual Studio 2019 version 16.8](https://visualstudio.microsoft.com/vs/) or the [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0).

## Build a simulation of a canal lock

In this tutorial, you'll build a C# class that simulates a [canal lock](https://en.wikipedia.org/wiki/Lock_(water_navigation)). Briefly, a canal lock is a device that raises and lowers boats as they travel between two stretches of water at different levels. A lock has two gates and some mechanism to change the water level.

In its normal operation, a boat enters one of the gates while the water level in the lock matches the water level on the side the boat enters. Once in the lock, the water level is changed to match the water level where the boat will leave the lock. Once the water level matches that side, the gate on the exit side opens. Safety measures make sure an operator can't create a dangerous situation in the canal. The water level can be changed only when both gates are closed. At most one gate can be open. To open a gate, the water level in the lock must match the water level outside the gate being opened.

You can build a C# class to model this behavior. A `CanalLock` class would support commands to open or close either gate. It would have other commands to raise or lower the water. The class should also support properties to read the current state of both gates and the water level. Your methods implement the safety measures.

## Define a class

You'll build a console application to test your `CanalLock` class. Create a new console project for .NET 5 using either Visual Studio or the .NET CLI. Then, add a new class and name it `CanalLock`. Next, design your public API, but leave the methods not implemented:

:::code language="csharp" source="snippets/pattern-objects/InterimSteps.cs" ID="APIDesign":::

The preceding code initializes the object so both gates are closed, and the water level is low. Next, write the following test code in your `Main` method to guide you as you create a first implementation of the class:

:::code language="csharp" source="snippets/pattern-objects/Program.cs" ID="HappyTests":::

Next, add a first implementation of each method in the `CanalLock` class. The following code implements the methods of the class without concern to the safety rules. You'll add safety tests later:

:::code language="csharp" source="snippets/pattern-objects/InterimSteps.cs" ID="FirstImplementation":::

The tests you've written so far pass. You've implemented the basics. Now, write a test for the first failure condition. At the end of the previous tests, both gates are closed, and the water level is set to low. Add a test to try opening the upper gate:

:::code language="csharp" source="snippets/pattern-objects/Program.cs" ID="HighGateSafetyTest":::

This test fails because the gate opens. As a first implementation, you could fix it with the following code:

:::code language="csharp" source="snippets/pattern-objects/InterimSteps.cs" ID="SecondImplementation":::

Your tests pass. But, as you add more tests, you'll add more and more `if` clauses and test different properties. Soon, these methods will get too complicated as you add more conditionals.

## Implement the commands with patterns

A better way is to use *patterns* to determine if the object is in a valid state to execute a command. You can express if a command is allowed as a function of three variables: the state of the gate, the level of the water, and the new setting:

| New setting | Gate state | Water Level | Result             |
| ----------- | ---------- | ----------- | ------------------ |
| Closed      | Closed     | High        | Closed             |
| Closed      | Closed     | Low         | Closed             |
| Closed      | Open       | High        | Open               |
| ~~Closed~~  | ~~Open~~   | ~~Low~~     | ~~Closed~~         |
| Open        | Closed     | High        | Open               |
| Open        | Closed     | Low         | Closed (Error)     |
| Open        | Open       | High        | Open               |
| ~~Open~~    | ~~Open~~   | ~~Low~~     | ~~Closed (Error)~~ |

The fourth and last rows in the table have strike through text because they're invalid. The code you're adding now should make sure the high water gate is never opened when the water is low.  Those states can be coded as a single switch expression (remember that `false` indicates "Closed"):

:::code language="csharp" source="snippets/pattern-objects/InterimSteps.cs" ID="ThirdImplementation":::

Try this version. Your tests pass, validating the code. The full table shows the possible combinations of inputs and results. That means you and other developers can quickly look at the table and see that you've covered all the possible inputs. Even easier, the compiler can help as well. After you add the previous code, you can see that the compiler generates a warning: *CS8524* indicates the switch expression doesn't cover all possible inputs. The reason for that warning is that one of the inputs is an `enum` type. The compiler interprets "all possible inputs" as all inputs from the underlying type, typically an `int`. This `switch` expression only checks the values declared in the `enum`. To remove the warning, you can add a catch-all discard pattern for the last arm of the expression. This condition throws an exception, because it indicates invalid input:

```csharp
_  => throw new InvalidOperationException("Invalid internal state"),
```

The preceding switch arm must be last in your `switch` expression because it matches all inputs. Experiment by moving it earlier in the order. That causes a compiler error *CS8510* for unreachable code in a pattern.  The natural structure of switch expressions enables the compiler to generate errors and warnings for possible mistakes. The compiler "safety net" makes it easier for you to create correct code in fewer iterations, and the freedom to combine switch arms with wildcards. The compiler will issue errors if your combination results in unreachable arms you didn't expect, and warnings if you remove an arm that's needed.

The first change is to combine all the arms where the command is to close the gate; that's always allowed. Add the following code as the first arm in your switch expression:

```csharp
(false, _, _) => false,
```

After you add the previous switch arm, you'll get four compiler errors, one on each of the arms where the command is `false`. Those arms are already covered by the newly added arm. You can safely remove those four lines. You intended this new switch arm to replace those conditions.

Next, you can simplify the four arms where the command is to open the gate. In both cases where the water level is high, the gate can be opened. (In one, it's already open.) One case where the water level is low throws an exception, and the other shouldn't happen. It should be safe to throw the same exception if the water lock is already in an invalid state. You can make the following simplifications for those arms:

```csharp
(true, _, WaterLevel.High) => true,
(true, false, WaterLevel.Low) => throw new InvalidOperationException("Cannot open high gate when the water is low"),
_ => throw new InvalidOperationException("Invalid internal state"),
```

Run your tests again, and they pass. Here's the final version of the `SetHighGate` method:

:::code language="csharp" source="snippets/pattern-objects/CanalLock.cs" ID="FinalImplementaton":::

## Implement patterns yourself

Now that you've seen the technique, fill in the `SetLowGate` and `SetWaterLevel` methods yourself.  Start by adding the following code to test invalid operations on those methods:

:::code language="csharp" source="snippets/pattern-objects/Program.cs" ID="FinalTestCode":::

Run your application again. You can see the new tests fail, and the canal lock gets into an invalid state. Try to implement the remaining methods yourself. The method to set the lower gate should be similar to the method to set the upper gate. The method that changes the water level has different checks, but should follow a similar structure. You may find it helpful to use the same process for the method that sets the water level. Start with all four inputs: The state of both gates, the current state of the water level, and the requested new water level. The switch expression should start with:

```csharp
CanalLockWaterLevel = (newLevel, CanalLockWaterLevel, LowWaterGateOpen, HighWaterGateOpen) switch
{
    // elided
};
```

You'll have 16 total switch arms to fill in. Then, test and simplify.

Did you make methods something like this?

:::code language="csharp" source="snippets/pattern-objects/CanalLock.cs" ID="FinalExercise":::

Your tests should pass, and the canal lock should operate safely.

## Summary

In this tutorial, you learned to use pattern matching to check the internal state of an object before applying any changes to that state. You can check combinations of properties. Once you've built tables for any of those transitions, you test your code, then simplify for readability and maintainability. These initial refactorings may suggest further refactorings that validate internal state or manage other API changes. This tutorial combined classes and objects with a more data-oriented, pattern-based approach to implement those classes.
