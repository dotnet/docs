---
title: "Selection statements in C#"
description: Use if, else, and switch statements to choose which code runs based on a condition, including pattern-based case labels and when clauses.
ms.date: 07/09/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Selection statements

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. For the complete syntax, see [selection statements](../../language-reference/statements/selection-statements.md) in the language reference.
>
> **Coming from another language?** C++, Java, and JavaScript all share C's heritage, so `if`, `else`, and `switch` read the same in C#. The one difference worth noting: C# forbids fall-through between nonempty `switch` cases, and each `case` label can test a *pattern* rather than only a constant. If you're coming from Python, C#'s `if`/`else if`/`else` maps to `if`/`elif`/`else`, and C#'s pattern-based `switch` is closest to Python's `match` statement.

Selection statements choose which block of code runs based on a condition. C# provides two: `if` (with an optional `else`) for branching on a Boolean value, and `switch` for comparing one value against several cases. A *Boolean expression* is any expression that evaluates to `true` or `false`, such as the comparison `temperature >= 25`.

## Branch with `if` and `else`

An `if` statement runs its block only when its Boolean expression is `true`. Add an `else` block to supply the code that runs when the condition is `false`:

:::code language="csharp" source="./snippets/selection-statements/Program.cs" id="IfElse":::

The body of an `if` or `else` is a single *statement*, which is one complete instruction that C# runs, such as an assignment or a method call. A *block statement* groups zero or more statements between braces (`{ }`) and counts as a single statement itself. That's why braces are legal even around one line: the block is the statement that the branch runs.

Enclose the branch bodies in braces, even for a single statement. Braces make the scope explicit and prevent a common mistake: adding a second line later that you expect to run conditionally, but that runs unconditionally instead. C# doesn't treat whitespace as significant, so indentation alone never decides which statements belong to a branch; only the braces do. Indent your code for readability, but rely on braces to define the block.

## Test several conditions with `else if`

To choose among more than two paths, chain conditions with `else if`. C# evaluates each condition in order and runs the first block whose condition is `true`, then skips the rest. A final `else` handles every remaining case:

:::code language="csharp" source="./snippets/selection-statements/Program.cs" id="ElseIf":::

Order matters in a chain. Because the first matching condition wins, put the most specific conditions first. In the previous example, testing `score >= 80` before `score >= 70` ensures a score of 82 maps to `"B"` rather than `"C"`.

## Match a value with a `switch` statement

When you compare a single value against many discrete cases, a `switch` statement reads more clearly than a long `else if` chain. Like `if`, the `switch` statement is a branching statement: it chooses which code to run. Each `case` label lists a value to match, and each `case` section ends with a `break` statement. Stack labels to share one body, and use the `default` section for values that no case matches:

:::code language="csharp" source="./snippets/selection-statements/Program.cs" id="SwitchStatement":::

Unlike C and Java, C# doesn't allow execution to fall through from one nonempty `case` section into the next. Every section that contains code must end with a `break` (or another jump statement, such as `return` or `goto`). This rule prevents the accidental fall-through bugs common in those languages.

### Test patterns with `case` and `when`

A `case` label isn't limited to constant values. It can test a *pattern*, which is a rule that describes the shape or value of data. A relational pattern such as `< 0` matches any value less than zero. Add a `when` clause to attach an extra condition that must also be `true` for the case to match:

:::code language="csharp" source="./snippets/selection-statements/Program.cs" id="SwitchWhen":::

Pattern-based cases are evaluated top to bottom, so more specific patterns belong before more general ones. For the full catalog of patterns, see [pattern matching](../functional/pattern-matching.md).

## Select a value with an expression

The `if` and `switch` statements decide which code runs. When you instead need to choose a *value*, use an *expression*. An expression evaluates to a value, so you can use it anywhere a value is expected, such as the right side of an assignment or a method argument. C# offers expression forms that select a value from alternatives such as the conditional operator and the `switch` expression.

### Conditional operator `?:`

The conditional operator `?:` chooses between two values based on a Boolean condition. It takes the form `condition ? valueIfTrue : valueIfFalse`:

:::code language="csharp" source="./snippets/selection-statements/Program.cs" id="Ternary":::

Use `?:` when you assign one of two values, because it keeps the assignment in one place and lets you mark the variable `readonly` or `const`. Prefer an `if` statement when the branches do more than produce a value. For the operator's precedence and associativity rules, see the [conditional operator](../../language-reference/operators/conditional-operator.md) in the language reference.

### `switch` expression

A `switch` expression is the expression counterpart to the `switch` statement. Instead of running code for the matching case, it evaluates to a value. It's more concise than assigning a value in each arm of a `switch` statement, and the compiler warns you when the arms don't cover every possible input. The `switch` expression is a core part of pattern matching. To learn when and how to use it, see [pattern matching](../functional/pattern-matching.md) and the [`switch` expression](../../language-reference/operators/switch-expression.md) reference.

## See also

- [Iteration statements](iteration-statements.md)
- [Pattern matching](../functional/pattern-matching.md)
- [Selection statements (language reference)](../../language-reference/statements/selection-statements.md)
- [Conditional operator (language reference)](../../language-reference/operators/conditional-operator.md)
