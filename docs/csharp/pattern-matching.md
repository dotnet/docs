---
title: Pattern Matching - C# Guide
description: Learn about pattern matching expressions in C#
ms.date: 04/21/2021
ms.technology: csharp-fundamentals
---

# Pattern Matching

*Pattern matching* is a technique where you test an expression to determine if has certain characteristics. C# pattern matching provides provides more concise syntax for testing expressions and taking action when an expression matches. The [`is`](language-reference/keywords/is.md) expression now supports pattern matching to test an expression and conditionally declare a new variable to the result of that expression. The [`switch`](language-reference/operators/switch-expression.md) expression enables you perform actions based on the first matching pattern for an expression. These two expressions support a rich vocabulary of [*patterns*](language-reference/operators/patterns.md). You have a rich vocabulary to express your algorithms.

This article provides an overview of scenarios where you can use pattern matching to improve the readability and correctness of your code. For a full discussion of all the patterns you can apply, see the article on [patterns](language-reference/operators/patterns.md) in the language reference.

## Null checks

One of the most common scenarios for pattern matching is to ensure values aren't null. You can test and convert a nullable value type to its underlying type while testing for `null` using the following example:

```csharp
int? maybe = 12;

if (maybe is int number)
{
    Console.WriteLine($"The nullable int 'maybe' has the value {number}");
} else
{
   Console.WriteLine("The nullable int 'maybe' doesn't hold a value");
}
```

The preceding code is a [*declaration pattern*](language-reference/operators/patterns.md#declaration-and-type-patterns) to test the type of the variable, and assign it to a new variable. The language rules make this technique safer than many others. The variable `number` is only accessible and assigned in the true portion of the `if` clause. If you try to access it elsewhere, either in the `else` clause, or after the `if` block, the compiler issues an error. Secondly, because you're not using the `==` operator, this pattern works when a type has overridden the `==` operator. That makes it an ideal way to check null reference values, adding the the `not` pattern:

```csharp
string? message = "This is not the null string";

if (message is not null)
{
    Console.WriteLine(message);
}
```

The preceding example used a [*constant pattern*](language-reference/operators/patterns.md#constant-pattern) to compare the variable to `null`. The `not` is a [*logical pattern*]((language-reference/patterns.md#logical-patterns) that negates the match expression.

## Type tests

Another common use for pattern matching is to test a variable to see if it matches a given type. For example, the following code tests if a variable implements the <xref:System.IDisposable?displayProperty=nameWithType> interface. If it does, it calls the <xref:System.IDisposable.Dispose> method on that object:

```csharp
if (heldReference is IDisposable disposable)
{
   disposable.Dispose();
}
heldReference = null;
```

The same tests can be applied in a `switch` expression to test a variable against multiple different types. You can use that information to create better algorithms based on the specific runtime type.

## Compare discrete values

You can also test a variable to find a match on specific values. The following code shows one example where you test a value against all possible values declared in an enumeration:

```csharp
public enum Operation
{
    SystemTest,
    Start,
    Stop,
    Reset
}

public enum State
{
   Off,
   Ready,
   Running
}

public State PerformOperation(Operation command) => 
   command switch
   {
       Operation.SystemTest => RunDiagnostics(),
       Operation.Start => StartSystem(),
       Operation.Stop => StopSystem(),
       Operation.Reset => ResetToReady(),
       _ => throw new ArgumentException(nameof(command), "Invalid enum value for command"),
   };
```

The previous example demonstrates a method dispatch based on the value of an enumeration. The final `_` case is a [*discard pattern*](language-reference/operators/patterns.md#discard-pattern) that matches all values. It handles any error conditions where the value doesn't match one of the defined `enum` values. If you omit that switch arm, the compiler warns that you haven't handled all possible input values. At runtime, the `switch` expression throws an exception if the object being examined doesn't match any of the switch arms. You could use numeric constants as well as a set of enum values. You can also use this similar technique for constant string values that represent the commands:

```csharp
public enum Operation
{
    SystemTest,
    Start,
    Stop,
    Reset
}

public enum State
{
   Off,
   Ready,
   Running
}

public State PerformOperation(string command) => 
   command switch
   {
       "SystemTest" => RunDiagnostics(),
       "Start" => StartSystem(),
       "Stop" => StopSystem(),
       "Reset" => ResetToReady(),
       _ => throw new ArgumentException(nameof(command), "Invalid string value for command"),
   };
```

The preceding example shows the same algorithm, but using string values instead of an enum. You would use this scenario if you're application responds to text commands instead of a regular data format.

## Relational patterns

In addition to discrete values, you can use [*Relational patterns*](language-reference/operators/patterns.md#relational-patterns) to test how a value compares to constants. For example, the following code returns the state of water based on the temperature in Fahrenheit:

```csharp
string WaterState(int tempInFahrenheit) =>
    tempInFarhenheit switch
    {
        ( > 32 ) and ( < 212 ) => "liquid",
        < 32 => "solid",
        > 212 => "gas",
        // check for warnings.
        32 => "solid/liquid transition",
        212 => "liquid / gas transition",
    }
```

The preceding code also demonstrates the conjunctive `and` [*Logical pattern*](language-reference/operators/patterns#logical-patterns) to check that both relational patterns match. You can also use a disjunctive `or` pattern to check that either pattern matches. The two relational patterns are surround by parentheses, which you can use around any pattern for clarity.

## Multiple inputs

All the patterns you've seen so far have been checking one input. You can write patterns that examine multiple properties of an object. The following code examines the number of items and the value of an order to calculate a discounted price:

```csharp
public double CalculateDiscount(Order order) =>
order switch
{
    (Items: > 10, Cost: > 1000) => 0.10,
    (Items: > 5, Cost: > 500) => 0.05,
    (Cost: > 250) => 0.02,
    null => throw ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
    var o => 0,
}
```

The first two arms examine two properties of the `Order`. The third examines only the cost. The next checks against `null`, and the final matches any other value. If the `Order` type defines a suitable [`Deconstruct](deconstruct.md) method, you can omit the property names from the pattern and use deconstruction to examine properties:

```csharp
public double CalculateDiscount(Order order) =>
order switch
{
    ( > 10,  > 1000) => 0.10,
    ( > 5, > 500) => 0.05,
    ( > 250) => 0.02,
    null => throw ArgumentNullException(nameof(order), "Can't calculate discount on null order"),
    var o => 0,
}
```

The preceding code demonstrates the [*Positional pattern*](language-reference/operators/patterns.md#positional-pattern) where the properties are deconstructed for the expression. This article provided a tour of the kinds of code you can write with pattern matching in C#. The articles below show more examples of using patterns in scenarios, and the full vocabulary of patterns avaiable to use.

## See also

- [Exploration: Use pattern matching to build your class behavior for better code](whats-new/tutorials/patterns-objects.md)
- [Tutorial: Use pattern matching to build type-driven and data-driven algorithms](tutorials/pattern-matching.md)
- [Reference: Pattern matching](language-reference/operators/patterns.md)
