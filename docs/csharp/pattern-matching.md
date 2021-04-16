---
title: Pattern Matching - C# Guide
description: Learn about pattern matching expressions in C#
ms.date: 04/10/2019
ms.technology: csharp-fundamentals
ms.assetid: 1e575c32-2e2b-4425-9dca-7d118f3ed15b
---

# Pattern Matching

*Pattern matching* is a technique where you test an expression to determine if has certain characteristics. C# pattern matching provides provides more concise syntax for testing expressions and taking action when an expression matches. The [`is`](language-reference/keywords/is.md) expression now supports pattern matching to test an expression and conditionally declare a new variable to the result of that expression. The [`switch`](language-reference/operators/switch-expression.md) expression enables you perform actions based on the first matching pattern for an expression. These two expressions support a rich vocabulary of [*patterns*](language-reference/operators/patterns.md). You have a rich vocabulary to express your algorithms.

This article provides an overview of techniques available using pattern matching.

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
        _ => "Unknown value"
    }
```

The preceding sample uses an enum for the Fujita scale for tornado strength to generate a description of what types of buildings are damaged. Each switch expression arm specifies a single value of the enum. The last entry catches any other value of the `abbreviation` expression. This is needed, because a variable of an `enum` type could hold any value of the underlying `int` type. If you omit this condition, the compiler warns you that not all possible input values are handled. Furthermore, if none of the switch arms match the input expression, the code throws an exception at runtime.

Matching single values works well for `enum` types or other known small sets of discrete values. You can also match on ranges of numeric values. The following method returns the value on the Fujita scale based on the observed wind speed:

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

scenarios:
- properties have values (nested tests)

## Patterns and deconstruction

Scenarios:
- tuples (pairs of values)
- records (some of the properties of a record)
- include var examples (assign values from a tuple. Swap things)

## Combining patterns

- and, or, not
- parenthesis

## See also

- [Exploration: Use pattern matching to build your class behavior for better code](whats-new/tutorials/patterns-objects.md)
- [Tutorial: Use pattern matching to build type-driven and data-driven algorithms](tutorials/pattern-matching.md)
- [Reference: Pattern matching](language-reference/operators/patterns.md)

============================================================ OLD

## `var` declarations in `case` expressions

The introduction of `var` as one of the match expressions introduces new
rules to the pattern match.

The first rule is that the `var` declaration
follows the normal type inference rules: The type is inferred to be the
static type of the switch expression. From that rule, the type always
matches.

The second rule is that a `var` declaration doesn't have the null check
that other type pattern expressions include. That means the variable
may be null, and a null check is necessary in that case.

Those two rules mean that in many instances, a `var` declaration
in a `case` expression matches the same conditions as a `default` expression.
Because any non-default case is preferred to the `default` case, the `default`
case will never execute.

> [!NOTE]
> The compiler does not emit a warning in those cases where a `default` case
> has been written but will never execute. This is consistent with current
> `switch` statement behavior where all possible cases have been listed.

The third rule introduces uses where a `var` case may be useful. Imagine
that you're doing a pattern match where the input is a string and you're
searching for known command values. You might write something like:

[!code-csharp[VarCaseExpression](../../samples/snippets/csharp/PatternMatching/Program.cs#VarCaseExpression "use a var case expression to filter white space")]

The `var` case matches `null`, the empty string, or any string that contains
only white space. Notice that the preceding code uses the `?.` operator to
ensure that it doesn't accidentally throw a <xref:System.NullReferenceException>. The `default` case handles any other string values that aren't understood by this command parser.

This is one example where you may want to consider
a `var` case expression that is distinct from a `default` expression.

