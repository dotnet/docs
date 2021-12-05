---
title: "Jump statements - C# reference"
description: "Learn about C# jump statements: break, continue, return, and goto."
ms.date: 12/06/2021
f1_keywords:
  - "break_CSharpKeyword"
  - "continue_CSharpKeyword"
  - "return_CSharpKeyword"
  - "goto_CSharpKeyword"
helpviewer_keywords:
  - "break statement [C#]"
  - "break keyword [C#]"
  - "continue statement [C#]"
  - "continue keyword [C#]"
  - "return statement [C#]"
  - "return keyword [C#]"
  - "goto statement [C#]"
  - "goto keyword [C#]"
---
# Jump statements (C# reference)

The following statements unconditionally transfer control:

- The [`break` statement](#the-break-statement): terminates the closest enclosing [iteration statement](iteration-statements.md) or [`switch` statement](selection-statements.md#the-switch-statement).
- The [`continue` statement](#the-continue-statement): starts a new iteration of the closest enclosing [iteration statement](iteration-statements.md).
- The [`return` statement](#the-return-statement): terminates execution of the function in which it appears and returns control to the caller.
- The [`goto` statement](#the-goto-statement): transfers control to a statement that is marked by a label.

## The `break` statement

The `break` statement terminates the closest enclosing [iteration statement](iteration-statements.md) (that is, `for`, `foreach`, `while`, or `do` loop) or [`switch` statement](selection-statements.md#the-switch-statement). The `break` statement transfers control to the statement that follows the terminated statement, if any.

:::code language="csharp" interactive="try-dotnet-method" source="snippets/jump-statements/BreakStatement.cs" id="BasicExample":::

In nested loops, the `break` statement terminates only the innermost loop that contains it, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/jump-statements/BreakStatement.cs" id="NestedLoop":::

When you use the `switch` statement inside a loop, a `break` statement at the end of a switch section transfers control only out of the `switch` statement. The loop that contains the `switch` statement is unaffected, as the following example shows:

:::code language="csharp" source="snippets/jump-statements/BreakStatement.cs" id="SwitchInsideLoop":::

## The `continue` statement

The `continue` statement starts a new iteration of the closest enclosing [iteration statement](iteration-statements.md) (that is, `for`, `foreach`, `while`, or `do` loop), as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/jump-statements/ContinueStatement.cs" id="BasicExample":::

## The `return` statement

The `return` statement terminates execution of the function in which it appears and returns control and the function's result, if any, to the caller. The `return` statement can be any of the following two forms:

- Without expression, as in the following example:

  :::code language="csharp" interactive="try-dotnet-method" source="snippets/jump-statements/ReturnStatement.cs" id="WithoutExpression":::

  You can use the `return` statement without expression in a function that doesn't compute a value, that is:

  - a [method](../../programming-guide/classes-and-structs/methods.md), [local function](../../programming-guide/classes-and-structs/local-functions.md), or [lambda expression](../operators/lambda-expressions.md) with the result type [`void`](../builtin-types/void.md)
  - an [async](../keywords/async.md) method, local function, or lambda expression with the result type <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.ValueTask>
  - the `set` accessor of a [property](../../programming-guide/classes-and-structs/properties.md) or an [indexer](../../programming-guide/indexers/index.md)
  - a [constructor](../../programming-guide/classes-and-structs/constructors.md)
  - a [finalizer](../../programming-guide/classes-and-structs/finalizers.md)
  - the `add` and `remove` accessors of an [event](../../programming-guide/events/index.md)

  You typically use the `return` statement without expression to terminate a function early. If a function doesn't contain the `return` statement, it terminates after its last statement is executed.

- With expression, as in the following example:

  :::code language="csharp" interactive="try-dotnet-method" source="snippets/jump-statements/ReturnStatement.cs" id="WithExpression":::

  You use the `return` statement with expression in a function that computes a value, that is:

  - a [method](../../programming-guide/classes-and-structs/methods.md), [local function](../../programming-guide/classes-and-structs/local-functions.md), or [lambda expression](../operators/lambda-expressions.md) with a non-void result type
  - an [async](../keywords/async.md) method, local function, or lambda expression with the result type <xref:System.Threading.Tasks.Task%601> or <xref:System.Threading.Tasks.ValueTask%601>
  - the `get` accessor of a [property](../../programming-guide/classes-and-structs/properties.md) or an [indexer](../../programming-guide/indexers/index.md)
  - an [overloaded operator](../operators/operator-overloading.md)

  By default, the `return` statement returns the value of an expression. Beginning with C# 7.0, you can return a reference to a variable. To do that, use the `return` statement with the [`ref` keyword](../keywords/ref.md), as the following example shows:

  :::code language="csharp" source="snippets/jump-statements/ReturnStatement.cs" id="RefReturn":::

  For more information about ref returns, see [Ref returns and ref locals](../../programming-guide/classes-and-structs/ref-returns.md).

## The `goto` statement

The `goto` statement transfers control to a statement that is marked by a label, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/jump-statements/GotoStatement.cs" id="NestedLoops":::

As the preceding example shows, you can use the `goto` statement to get out of a nested loop.

> [!TIP]
> When you work with nested loops, consider refactoring separate loops into separate methods. That may lead to a simpler, more readable code without the `goto` statement.

You can also use the `goto` statement in the [`switch` statement](selection-statements.md#the-switch-statement) to transfer control to a switch section with a constant case label, as the following example shows:

:::code language="csharp" interactive="try-dotnet" source="snippets/jump-statements/GotoStatement.cs" id="InsideSwitch":::

Within the `switch` statement, you can also use the statement `goto default;` to transfer control to the switch section with the `default` label.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [The `break` statement](~/_csharplang/spec/statements.md#the-break-statement)
- [The `continue` statement](~/_csharplang/spec/statements.md#the-continue-statement)
- [The `return` statement](~/_csharplang/spec/statements.md#the-return-statement)
- [The `goto` statement](~/_csharplang/spec/statements.md#the-goto-statement)

## See also

- [C# reference](../index.md)
- [`yield` statement](../keywords/yield.md)
