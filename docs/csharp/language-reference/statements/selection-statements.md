---
title: "Selection statements - C# reference"
description: "Learn about C# selection statements: if and switch."
ms.date: 08/09/2021
f1_keywords:
  - "if_CSharpKeyword"
  - "else_CSharpKeyword"
  - "switch_CSharpKeyword"
  - "case_CSharpKeyword"
  - "defaultcase_CSharpKeyword"
helpviewer_keywords:
  - "if statement [C#]"
  - "if keyword [C#]"
  - "else keyword [C#]"
  - "switch statement [C#]"
  - "switch keyword [C#]"
  - "case keyword [C#]"
  - "default keyword [C#]"
---
# Selection statements (C# reference)

The following statements select statements to execute from a number of possible statements based on the value of an expression:

- The [`if` statement](#the-if-statement): selects a statement to execute based on the value of a Boolean expression.
- The [`switch` statement](#the-switch-statement): selects a statement list to execute based on a pattern match with an expression.

## The `if` statement

An `if` statement can be any of the following two forms:

- An `if` statement with an `else` part selects one of the two statements to execute based on the value of a Boolean expression, as the following example shows:

  :::code language="csharp" interactive="try-dotnet-method" source="snippets/selection-statements/IfStatement.cs" id="IfElse":::

- An `if` statement without an `else` part executes its body only if a Boolean expression evaluates to `true`, as the following example shows:

  :::code language="csharp" interactive="try-dotnet-method" source="snippets/selection-statements/IfStatement.cs" id="OnlyIf":::

You can nest `if` statements to check multiple conditions, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/selection-statements/IfStatement.cs" id="NestedIf":::

In an expression context, you can use the [conditional operator `?:`](../operators/conditional-operator.md) to evaluate one of the two expressions based on the value of a Boolean expression.

## The `switch` statement

The `switch` statement selects a statement list to execute based on a pattern match with a match expression, as the following example shows:

:::code language="csharp" source="snippets/selection-statements/SwitchStatement.cs" id="Example":::

At the preceding example, the `switch` statement uses the following patterns:

- A [relational pattern](../operators/patterns.md#relational-patterns): to compare an expression result with a constant.
- A [constant pattern](../operators/patterns.md#constant-pattern): to test if an expression result equals a constant.

> [!IMPORTANT]
> For information about the patterns supported by the `switch` statement, see [Patterns](../operators/patterns.md).

The preceding example also demonstrates the `default` case. The `default` case specifies statements to execute when a match expression doesn't match any other case pattern. If a match expression doesn't match any case pattern and there is no `default` case, control falls through a `switch` statement.

A `switch` statement executes the *statement list* in the first *switch section* whose *case pattern* matches a match expression and whose [case guard](#case-guards), if present, evaluates to `true`. A `switch` statement evaluates case patterns in text order from top to bottom. The compiler generates an error when a `switch` statement contains an unreachable case. That is a case that is already handled by an upper case or whose pattern is impossible to match.

> [!NOTE]
> The `default` case can appear in any place within a `switch` statement. Regardless of its position, the `default` case is always evaluated last and only if all other case patterns aren't matched.

You can specify multiple case patterns for one section of a `switch` statement, as the following example shows:

:::code language="csharp" source="snippets/selection-statements/SwitchStatement.cs" id="MultipleCases":::

Within a `switch` statement, control cannot fall through from one switch section to the next. As the examples in this section show, typically you use the `break` statement at the end of each switch section to pass control out of a `switch` statement. You can also use the [return](jump-statements.md#the-return-statement) and [throw](../keywords/throw.md) statements to pass control out of a `switch` statement. To imitate the fall-through behavior and pass control to other switch section, you can use the [`goto` statement](jump-statements.md#the-goto-statement).

In an expression context, you can use the [`switch` expression](../operators/switch-expression.md) to evaluate a single expression from a list of candidate expressions based on a pattern match with an expression.

### Case guards

A case pattern may be not expressive enough to specify the condition for the execution of the switch section. In such a case, you can use a *case guard*. That is an additional condition that must be satisfied together with a matched pattern. A case guard must be a Boolean expression. You specify a case guard after the `when` keyword that follows a pattern, as the following example shows:

:::code language="csharp" source="snippets/selection-statements/SwitchStatement.cs" id="WithCaseGuard":::

The preceding example uses [positional patterns](../operators/patterns.md#positional-pattern) with nested [relational patterns](../operators/patterns.md#relational-patterns).

### Language version support

The `switch` statement supports pattern matching beginning with C# 7.0.

In C# 6 and earlier, you use the `switch` statement with the following limitations:

- A match expression must be of one of the following types: [char](../builtin-types/char.md), [string](../builtin-types/reference-types.md), [bool](../builtin-types/bool.md), an [integral numeric](../builtin-types/integral-numeric-types.md) type, or an [enum](../builtin-types/enum.md) type.
- Only constant expressions are allowed in `case` labels.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [The `if` statement](~/_csharplang/spec/statements.md#the-if-statement)
- [The `switch` statement](~/_csharplang/spec/statements.md#the-switch-statement)

For more information about features introduced in C# 7.0 and later, see the following feature proposal notes:

- [Switch statement (Pattern matching for C# 7.0)](~/_csharplang/proposals/csharp-7.0/pattern-matching.md#switch-statement)

## See also

- [C# reference](../index.md)
- [Conditional operator `?:`](../operators/conditional-operator.md)
- [Logical operators](../operators/boolean-logical-operators.md)
- [Patterns](../operators/patterns.md)
- [`switch` expression](../operators/switch-expression.md)
