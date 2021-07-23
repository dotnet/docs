---
description: "switch (C# reference)"
title: C# switch statement
ms.date: 04/09/2019
f1_keywords:
  - "switch_CSharpKeyword"
  - "switch"
  - "case"
  - "case_CSharpKeyword"
  - "defaultcase_CSharpKeyword"
helpviewer_keywords:
  - "switch statement [C#]"
  - "switch keyword [C#]"
  - "case statement [C#]"
  - "default keyword [C#]"
ms.assetid: 44bae8b8-8841-4d85-826b-8a94277daecb
---
# switch (C# reference)

This article covers the `switch` statement. For information on the `switch` expression (introduced in C# 8.0), see the article on [`switch` expressions](../operators/switch-expression.md) in the [expressions and operators](../operators/index.md) section.

`switch` is a selection statement that chooses a single *switch section* to execute from a list of candidates based on a pattern match with the *match expression*.

[!code-csharp[switch#1](~/samples/snippets/csharp/language-reference/keywords/switch/switch1.cs#1)]

The `switch` statement is often used as an alternative to an [if-else](if-else.md) construct if a single expression is tested against three or more conditions. For example, the following `switch` statement determines whether a variable of type `Color` has one of three values:

[!code-csharp[switch#3](~/samples/snippets/csharp/language-reference/keywords/switch/switch3.cs#1)]

It's equivalent to the following example that uses an `if`-`else` construct.

[!code-csharp[switch#3a](~/samples/snippets/csharp/language-reference/keywords/switch/switch3a.cs#1)]

## The match expression

The match expression provides the value to match against the patterns in `case` labels. Its syntax is:

```csharp
   switch (expr)
```

In C# 6 and earlier, the match expression must be an expression that returns a value of the following types:

- a [char](../builtin-types/char.md).
- a [string](../builtin-types/reference-types.md).
- a [bool](../builtin-types/bool.md).
- an [integral](../builtin-types/integral-numeric-types.md) value, such as an `int` or a `long`.
- an [enum](../builtin-types/enum.md) value.

Starting with C# 7.0, the match expression can be any non-null expression.

## The switch section

A `switch` statement includes one or more switch sections. Each switch section contains one or more *case labels* (either a case or default label) followed by one or more statements. The `switch` statement may include at most one default label placed in any switch section. The following example shows a simple `switch` statement that has three switch sections, each containing two statements. The second switch section contains the `case 2:` and `case 3:` labels.

A `switch` statement can include any number of switch sections, and each section can have one or more case labels, as shown in the following example. However, no two case labels may contain the same expression.

[!code-csharp[switch#2](~/samples/snippets/csharp/language-reference/keywords/switch/switch2.cs#1)]

Only one switch section in a switch statement executes. C# doesn't allow execution to continue from one switch section to the next. Because of this, the following code generates a compiler error, CS0163: "Control cannot fall through from one case label (\<case label>) to another."

```csharp
switch (caseSwitch)
{
    // The following switch section causes an error.
    case 1:
        Console.WriteLine("Case 1...");
        // Add a break or other jump statement here.
    case 2:
        Console.WriteLine("... and/or Case 2");
        break;
}
```

This requirement is usually met by explicitly exiting the switch section by using a [break](break.md), [goto](goto.md), or [return](return.md) statement. However, the following code is also valid, because it ensures that program control can't fall through to the `default` switch section.

[!code-csharp[switch#4](~/samples/snippets/csharp/language-reference/keywords/switch/switch4.cs#1)]

Execution of the statement list in the switch section with a case label that matches the match expression begins with the first statement and proceeds through the statement list, typically until a jump statement, such as a `break`, `goto case`, `goto label`, `return`, or `throw`, is reached. At that point, control is transferred outside the `switch` statement or to another case label. A `goto` statement, if it's used, must transfer control to a constant label. This restriction is necessary, since attempting to transfer control to a non-constant label can have undesirable side-effects, such transferring control to an unintended location in code or creating an endless loop.

## Case labels

Each case label specifies a pattern to compare to the match expression (the `caseSwitch` variable in the previous examples). If they match, control is transferred to the switch section that contains the **first** matching case label. If no case label pattern matches the match expression, control is transferred to the section with the `default` case label, if there's one. If there's no `default` case, no statements in any switch section are executed, and control is transferred outside the `switch` statement.

For information on the `switch` statement and pattern matching, see the [Pattern matching with the `switch` statement](#pattern-matching-with-the-switch-statement) section.

Because C# 6 supports only the constant pattern and doesn't allow the repetition of constant values, case labels define mutually exclusive values, and only one pattern can match the match expression. As a result, the order in which `case` statements appear is unimportant.

In C# 7.0, however, because other patterns are supported, case labels need not define mutually exclusive values, and multiple patterns can match the match expression. Because only the statements in the first switch section that contains the matching pattern are executed, the order in which `case` statements appear is now important. If C# detects a switch section whose case statement or statements are equivalent to or are subsets of previous statements, it generates a compiler error, CS8120, "The switch case has already been handled by a previous case."

The following example illustrates a `switch` statement that uses a variety of non-mutually exclusive patterns. If you move the `case 0:` switch section so that it's no longer the first section in the `switch` statement, C# generates a compiler error because an integer whose value is zero is a subset of all integers, which is the pattern defined by the `case int val` statement.

[!code-csharp[switch#5](~/samples/snippets/csharp/language-reference/keywords/switch/switch5.cs#1)]

You can correct this issue and eliminate the compiler warning in one of two ways:

- By changing the order of the switch sections.

- By using a [when clause](#the-case-statement-and-the-when-clause) in the `case` label.

## The `default` case

The `default` case specifies the switch section to execute if the match expression doesn't match any other `case` label. If a `default` case is not present and the match expression doesn't match any other `case` label, program flow falls through the `switch` statement.

The `default` case can appear in any order in the `switch` statement. Regardless of its order in the source code, it's always evaluated last, after all `case` labels have been evaluated.

## Pattern matching with the `switch` statement

Each `case` statement defines a pattern that, if it matches the match expression, causes its  containing switch section to be executed. All versions of C# support the constant pattern. The remaining patterns are supported beginning with C# 7.0.

### Constant pattern

The constant pattern tests whether the match expression equals a specified constant. Its syntax is:

```csharp
   case constant:
```

where *constant* is the value to test for. *constant* can be any of the following constant expressions:

- A [bool](../builtin-types/bool.md) literal: either `true` or `false`.
- Any [integral](../builtin-types/integral-numeric-types.md) constant, such as an `int`, a `long`, or a `byte`.
- The name of a declared `const` variable.
- An enumeration constant.
- A [char](../builtin-types/char.md) literal.
- A [string](../builtin-types/reference-types.md) literal.

The constant expression is evaluated as follows:

- If *expr* and *constant* are integral types, the C# equality operator determines whether the expression returns `true` (that is, whether `expr == constant`).

- Otherwise, the value of the expression is determined by a call to the static [Object.Equals(expr, constant)](xref:System.Object.Equals(System.Object,System.Object)) method.

The following example uses the constant pattern to determine whether a particular date is a weekend, the first day of the work week, the last day of the work week, or the middle of the work week. It evaluates the <xref:System.DateTime.DayOfWeek?displayProperty=nameWithType> property of the current day against the members of the <xref:System.DayOfWeek> enumeration.

[!code-csharp[switch#7](~/samples/snippets/csharp/language-reference/keywords/switch/const-pattern.cs#1)]

The following example uses the constant pattern to handle user input in a console application that simulates an automatic coffee machine.

[!code-csharp[switch#6](~/samples/snippets/csharp/language-reference/keywords/switch/switch6.cs)]

### Type pattern

The type pattern enables concise type evaluation and conversion. When used with the `switch` statement to perform pattern matching, it tests whether an expression can be converted to a specified type and, if it can be, casts it to a variable of that type. Its syntax is:

```csharp
   case type varname
```

where *type* is the name of the type to which the result of *expr* is to be converted, and *varname* is the object to which the result of *expr* is converted if the match succeeds. The compile-time type of *expr* may be a generic type parameter, starting with C# 7.1.

The `case` expression is `true` if any of the following is true:

- *expr* is an instance of the same type as *type*.

- *expr* is an instance of a type that derives from *type*. In other words, the result of *expr* can be upcast to an instance of *type*.

- *expr* has a compile-time type that is a base class of *type*, and *expr* has a runtime type that is *type* or is derived from *type*. The *compile-time type* of a variable is the variable's type as defined in its type declaration. The *runtime type* of a variable is the type of the instance that is assigned to that variable.

- *expr* is an instance of a type that implements the *type* interface.

If the case expression is true, *varname* is definitely assigned and has local scope within the switch section only.

Note that `null` doesn't match a type. To match a `null`, you use the following `case` label:

```csharp
case null:
```

The following example uses the type pattern to provide information about various kinds of collection types.

[!code-csharp[type-pattern#1](~/samples/snippets/csharp/language-reference/keywords/switch/type-pattern.cs#1)]

Instead of `object`, you could make a generic method, using the type of the collection as the type parameter, as shown in the following code:

[!code-csharp[type-pattern#3](~/samples/snippets/csharp/language-reference/keywords/switch/type-pattern3.cs#1)]

The generic version is different than the first sample in two ways. First, you can't use the `null` case. You can't use any constant case because the compiler can't convert any arbitrary type `T` to any type other than `object`. What had been the `default` case now tests for a non-null `object`. That means the `default` case tests only for `null`.

Without pattern matching, this code might be written as follows. The use of type pattern matching produces more compact, readable code by eliminating the need to test whether the result of a conversion is a `null` or to perform repeated casts.

[!code-csharp[type-pattern2#1](~/samples/snippets/csharp/language-reference/keywords/switch/type-pattern2.cs#1)]

## The `case` statement and the `when` clause

Starting with C# 7.0, because case statements need not be mutually exclusive, you can add a `when` clause to specify an additional condition that must be satisfied for the case statement to evaluate to true. The `when` clause can be any expression that returns a Boolean value.

The following example defines a base `Shape` class, a `Rectangle` class that derives from `Shape`, and a `Square` class that derives from `Rectangle`. It uses the `when` clause to ensure that the `ShowShapeInfo` treats a `Rectangle` object that has been assigned equal lengths and widths as a `Square` even if it hasn't been instantiated as a `Square` object. The method doesn't attempt to display information either about an object that is `null` or a shape whose area is zero.

[!code-csharp[when-clause#1](~/samples/snippets/csharp/language-reference/keywords/switch/when-clause.cs#1)]

Note that the `when` clause in the example that attempts to test whether a `Shape` object is `null` doesn't execute. The correct type pattern to test for a `null` is `case null:`.

## C# language specification

For more information, see [The switch statement](~/_csharplang/spec/statements.md#the-switch-statement) in the [C# Language Specification](/dotnet/csharp/language-reference/language-specification/introduction). The language specification is the definitive source for C# syntax and usage.

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [if-else](if-else.md)
- [Pattern Matching](../../fundamentals/functional/pattern-matching.md)
