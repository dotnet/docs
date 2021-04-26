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

The preceding code is a [*declaration pattern*](language-reference/patterns.md#declaration-and-type-patterns) to test the type of the variable, and assign it to a new variable. The language rules make this technique safer than many others. The variable `number` is only accessible and assigned in the true portion of the `if` clause. If you try to access it elsewhere, either in the `else` clause, or after the `if` block, the compiler issues an error. Secondly, because you're not using the `==` operator, this pattern works when a type has overridden the `==` operator. That makes it an ideal way to check null reference values, adding the the `not` pattern:

```csharp
string? message = "This is not the null string";

if (message is not null)
{
    Console.WriteLine(message);
}
```

The preceding example used a [*constant pattern*](language-reference/patterns.md#constant-pattern) to compare the variable to `null`. The `not` is a [*logical pattern*]((language-reference/patterns.md#logical-patterns) that negates the match expression.

## Type tests

-- Use an idisposable test.

## Compare discrete values

-- enum

Enum value to Method....


-- string

Message text to method....

-- Number

Ranges to warning message.

## Ranges

-- temperature and water state.
```csharp
string WaterState(int tempInFahrenheit) =>
    tempInFarhenheit switch
    {
        > 32 and < 212 => "liquid",
        < 32 => "solid",
        > 212 => "gas",
        // check for warnings.
        32 => "solid/liquid transition",
        212 => "liquid / gas transition",
    }
```

## Multiple inputs

-- Customer discounts based on items, total price.

```csharp
public double CalculateDiscount(Order order) =>
order switch
{
    (>10, >1000) => 0.10,
    (>5, >500) => 0.05,
    (_, > 250) => 0.02,
    _ => 0,
}
```


=======================================

## Testing and declaring types

Let's start with a common scenario: testing if an expression matches a type and then using the expression as that type. Consider this method used in a reporting application to highlight missing integer values:

```csharp
public string OrMissing(int? numberReported)
{
    if (numberReported is int notMissing)
    {
        return notMissing.ToString();
    } else
    {
        return "MISSING";
    }
}
```

The preceding example shows how pattern matching helps you create correct code. The variable `notMissing` is only assigned in the `true` clause of the `if` statement. The compiler prevents you from accidentally using that variable anywhere else in the method. The variable `notMissing` is an `int`, not an `int?`. You can use its value without viewing checking against a `null` value.

The preceding example tests a nullable integer to see if it can be converted to an `int` type. That conversion succeeds when the `int?` has a value. In those cases, the method returns the string representation of that integer. Otherwise, it returns the string "MISSING" to indicate a missing value. You can follow this example when your code needs to test for a missing value.

Another use of type patterns is when a method may have a better implementation based on the runtime type. Consider the following example that returns the 10th element of a collection, if that collection has 10 elements. Otherwise, it returns the default value:

```csharp
public static T TenthElement<T>(IEnumerable<T> sequence)
{
    int index = 0;
    foreach(T item in sequence)
    {
        if (index++ == 10)
            return item;
    }
    return default;
}
```

This method works, but is inefficient when the sequence supports other interfaces. You could add a number of `if` statements to add those, but that becomes hard to read and maintain over time. Instead, use [*type patterns*](language-reference/operators/patterns.md#declaration-and-type-patterns) to test type runtime type of the sequence:

```csharp
public static T TenthElement<T>(IEnumerable<T> sequence)
{
    if (sequence is IList<T> list)
        return list.Count > 9 ? list[9] : default(T);
    int index = 0;
    foreach(T item in sequence)
    {
        if (index++ == 10)
            return item;
    }
    return default;
}
```

This version takes advantage of the additional functionality for `IList<T>` to avoid enumerating the elements. Let's add one more check to throw an exception when the input argument is `null`:

```csharp
public static T TenthElement<T>(IEnumerable<T> sequence)
{
    if (sequence is null)
        throw new ArgumentNullException("Source sequence can't be null", nameof(sequence));
    if (sequence is IList<T> list)
        return list.Count > 9 ? list[9] : default(T);
    int index = 0;
    foreach(T item in sequence)
    {
        if (index++ == 10)
            return item;
    }
    return default;
}
```

You can rewrite the same method using a switch expression with a couple modifications:

```csharp
public static T TenthElement<T>(IEnumerable<T> sequence)
{
    return sequence switch
    {
        null => throw new ArgumentNullException("Source sequence can't be null", nameof(sequence)),
        IList<T> list => list.Count > 9 ? list[9] : default(T),
        _ => sequence.Skip(9).FirstOrDefault(),
    }
}
```

The preceding version uses the [*discard pattern*](language-reference/operators/patterns.md#discard-pattern) to match any input, which matches any non-null `IEnumerable<T>`. It also checks the `null` first, but that's not strictly necessary. If the input `sequence` is null, it won't match any type. You could also write:

```csharp
public static T TenthElement<T>(IEnumerable<T> sequence)
{
    return sequence switch
    {
        IList<T> list => list.Count > 9 ? list[9] : default(T),
        IEnumerable<T> enumerable => enumerable.Skip(9).FirstOrDefault(),
        null => throw new ArgumentNullException("Source sequence can't be null", nameof(sequence)),
    }
}
```

## Testing values

You can test an expression for specific values as well. You'll find this a common pattern when working with `enum` values:

```csharp
public enum DamageIndicator
{
    
    SBO,
    FR12,
    MHSW,
    MHDW,
    ACT,
    M
}

public string DamageDescription(DamageIndicator abbreviation) =>
    abbreviation switch
    {
        FujitaScale.SBO => "Small barns, farm outbuildings",
        FujitaScale.FR12 => "One- or two-family residences",
        FujitaScale.MHSW => "Single-wide mobile home",
        FujitaScale.MHDW => "Double-wide mobile home",
        FujitaScale.ACT => "Apt, condo, townhouse (3 stories or less)",
        FujitaScale.M => "Motel",
        _ => "Unknown value",
    }
```

The preceding sample uses an enum for the Fujita scale for tornado strength to generate a description of what types of buildings are damaged. Each switch expression arm specifies a single value of the enum. The last entry catches any other value of the `abbreviation` expression. This is needed, because a variable of an `enum` type could hold any value of the underlying `int` type. If you omit this condition, the compiler warns you that not all possible input values are handled. Furthermore, if none of the switch arms match the input expression, the code throws an exception at runtime. Using the `_` is a *discard* pattern. The source variable isn't used or assigned to a variable in the switch arm. If you want to catch all additional inputs and use that value, you can use the `var` pattern, as shown in the following example:

```csharp
public string DamageDescription(DamageIndicator abbreviation) =>
    abbreviation switch
    {
        FujitaScale.SBO => "Small barns, farm outbuildings",
        FujitaScale.FR12 => "One- or two-family residences",
        FujitaScale.MHSW => "Single-wide mobile home",
        FujitaScale.MHDW => "Double-wide mobile home",
        FujitaScale.ACT => "Apt, condo, townhouse (3 stories or less)",
        FujitaScale.M => "Motel",
        var unknown => $"Unknown value: {unknown}",
    }
```

The preceding example shows the `var` pattern, which would also work on a `null` value for nullable value types or reference types. Matching single values works well for `enum` types or other known small sets of discrete values. You can also match on ranges of numeric values. The following method returns the value on the Fujita scale based on the observed wind speed:

```csharp
public int? EFScale(int windSpeed) =>
    windSpeed switch
    {
        < 65 => null,
        < 86 => 0,
        < 111 => 1,
        < 136 => 2,
        < 166 => 3,
        < 201 => 4,
        _ => 5,
    };
```

The preceding examples have compared types to values. You can also use the *properties* of a variable in a pattern. Find an example that has an Enum as a property. Use type and property in a couple ways.....

```csharp
// I can't think of anything here.
```

## Properties and deconstruction

In many cases, property patterns can be simplified using *positional* patterns. Positional patterns [deconstruct](deconstruct.md) the source expression into its component properties. You then use the combination of those properties for your pattern:

```csharp
// Something other than points and persons
```

The preceding example shows how you can combine deconstruction and patterns to test the characteristics of multiple properties of a variable. You can also use that same technique to build patterns from a set of variables constructed as a tuple:

```csharp
// A tuple variable.
```

These techniques can be used to unwind complicated logic using `if` and `else` clauses, converting them to a series of arms in a switch expression that uses each of the variables as a source.

## Combining patterns

These patterns can be combined using `and`, `or`, and `not` to create more sophisticated patterns. You can also surround any of the patterns with parentheses in order to clarify the order those individual patterns should be evaluated. The example that checked against windspeed could be rewritten to use multiple conditions as shown in the following example:

```csharp
public int? EFScale(int windSpeed) =>
    windSpeed switch
    {
        < 65 => null,
        ( >= 64) and ( < 86) => 0,
        ( >= 85) and ( < 111) => 1,
        ( >= 110) and ( < 136) => 2,
        ( >= 135) and ( < 166) => 3,
        ( >= 165) and ( < 201)  => 4,
        _ => 5,
    };
```

The preceding example showed how you can test multiple conditions in each of the switch arms. This enables you to build patterns that can test inputs against a variety of conditions. You have a rich palette of expressions to use. In many instances, pattern matching can provide more concise and understandable code to describe the conditions you test and the actions you take based on those tests. The more you learn about pattern matching, the more scenarios you'll find where it produces better code.

## See also

- [Exploration: Use pattern matching to build your class behavior for better code](whats-new/tutorials/patterns-objects.md)
- [Tutorial: Use pattern matching to build type-driven and data-driven algorithms](tutorials/pattern-matching.md)
- [Reference: Pattern matching](language-reference/operators/patterns.md)
