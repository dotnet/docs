---
title: "if and switch statements - select a code path to execute"
description: "The `if` and `switch` statements provide branching logic in C#. You use `if, `else` and `switch` to choose the path your program follows."
ms.date: 11/22/2022
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
# Selection statements - `if`, `if-else`, and `switch`

The `if`, `if-else` and `switch` statements select statements to execute from many possible paths based on the value of an expression. The [`if` statement](#the-if-statement) executes a statement only if a provided Boolean expression evaluates to `true`. The [`if-else` statement](#the-if-statement) allows you to choose which of the two code paths to follow based on a Boolean expression. The [`switch` statement](#the-switch-statement) selects a statement list to execute based on a pattern match with an expression.

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
- A [constant pattern](../operators/patterns.md#constant-pattern): test if an expression result equals a constant.

> [!IMPORTANT]
> For information about the patterns supported by the `switch` statement, see [Patterns](../operators/patterns.md).

The preceding example also demonstrates the `default` case. The `default` case specifies statements to execute when a match expression doesn't match any other case pattern. If a match expression doesn't match any case pattern and there's no `default` case, control falls through a `switch` statement.

A `switch` statement executes the *statement list* in the first *switch section* whose *case pattern* matches a match expression and whose [case guard](#case-guards), if present, evaluates to `true`. A `switch` statement evaluates case patterns in text order from top to bottom. The compiler generates an error when a `switch` statement contains an unreachable case. That is a case that is already handled by an upper case or whose pattern is impossible to match.

> [!NOTE]
> The `default` case can appear in any place within a `switch` statement. Regardless of its position, the `default` case is evaluated only if all other case patterns aren't matched or the `goto default;` statement is executed in one of the switch sections.

You can specify multiple case patterns for one section of a `switch` statement, as the following example shows:

:::code language="csharp" source="snippets/selection-statements/SwitchStatement.cs" id="MultipleCases":::

Within a `switch` statement, control can't fall through from one switch section to the next. As the examples in this section show, typically you use the `break` statement at the end of each switch section to pass control out of a `switch` statement. You can also use the [return](jump-statements.md#the-return-statement) and [throw](exception-handling-statements.md#the-throw-statement) statements to pass control out of a `switch` statement. To imitate the fall-through behavior and pass control to other switch section, you can use the [`goto` statement](jump-statements.md#the-goto-statement).

> [!IMPORTANT]
> Missing `break` statement will throw exception, however **empty** case sections, like `case < 0:` in example above, **are** permitted to fall through. This deliberate design choice allows for concisely handling multiple cases that share the same or interdependent logic.

In an expression context, you can use the [`switch` expression](../operators/switch-expression.md) to evaluate a single expression from a list of candidate expressions based on a pattern match with an expression.<br>

> [!IMPORTANT]
> Differences between **switch expression** and **switch statement**:
> - **switch statement** is used to control the execution flow within a block of code.<br>
> - **switch expression** is typically used in contexts of value return and value assignment, often as a [expression-bodied members](../../programming-guide/statements-expressions-operators/expression-bodied-members.md). <br> 
> - a **switch expression** case section cannot be empty, a **switch statement** can.<br>


### Case guards

A case pattern may not be expressive enough to specify the condition for the execution of the switch section. In such a case, you can use a *case guard*. That is an additional condition that must be satisfied together with a matched pattern. A case guard must be a Boolean expression. You specify a case guard after the `when` keyword that follows a pattern, as the following example shows:

:::code language="csharp" source="snippets/selection-statements/SwitchStatement.cs" id="WithCaseGuard":::

The preceding example uses [positional patterns](../operators/patterns.md#positional-pattern) with nested [relational patterns](../operators/patterns.md#relational-patterns).

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [The `if` statement](~/_csharpstandard/standard/statements.md#1382-the-if-statement)
- [The `switch` statement](~/_csharpstandard/standard/statements.md#1383-the-switch-statement)

For more information about patterns, see the [Patterns and pattern matching](~/_csharpstandard/standard/patterns.md) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [Conditional operator `?:`](../operators/conditional-operator.md)
- [Logical operators](../operators/boolean-logical-operators.md)
- [Patterns](../operators/patterns.md)
- [`switch` expression](../operators/switch-expression.md)
- [Add missing cases to switch statement (style rule IDE0010)](../../../fundamentals/code-analysis/style-rules/ide0010.md)
