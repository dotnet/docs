---
title: "Jump statements - C# reference"
description: "Learn about C# jump statements: break, continue, return, and goto."
ms.date: 12/08/2021
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

For information about the `throw` statement that throws an exception and unconditionally transfers control as well, see [throw](../keywords/throw.md).

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

The `return` statement terminates execution of the function in which it appears and returns control and the function's result, if any, to the caller.

If a function member doesn't compute a value, you use the `return` statement without expression, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/jump-statements/ReturnStatement.cs" id="WithoutExpression":::

As the preceding example shows, you typically use the `return` statement without expression to terminate a function member early. If a function member doesn't contain the `return` statement, it terminates after its last statement is executed.

If a function member computes a value, you use the `return` statement with an expression, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/jump-statements/ReturnStatement.cs" id="WithExpression":::

When the `return` statement has an expression, that expression must be implicitly convertible to the return type of a function member unless it's [async](../keywords/async.md). In the case of an `async` function, the expression must be implicitly convertible to the type argument of <xref:System.Threading.Tasks.Task%601> or <xref:System.Threading.Tasks.ValueTask%601>, whichever is the return type of the function. If the return type of an `async` function is <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.ValueTask>, you use the `return` statement without expression.

By default, the `return` statement returns the value of an expression. Beginning with C# 7.0, you can return a reference to a variable. To do that, use the `return` statement with the [`ref` keyword](../keywords/ref.md), as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/jump-statements/ReturnStatement.cs" id="RefReturn":::

For more information about ref returns, see [Ref returns and ref locals](../../programming-guide/classes-and-structs/ref-returns.md).

## The `goto` statement

The `goto` statement transfers control to a statement that is marked by a label, as the following example shows:

:::code language="csharp" source="snippets/jump-statements/GotoStatement.cs" id="NestedLoops":::

As the preceding example shows, you can use the `goto` statement to get out of a nested loop.

> [!TIP]
> When you work with nested loops, consider refactoring separate loops into separate methods. That may lead to a simpler, more readable code without the `goto` statement.

You can also use the `goto` statement in the [`switch` statement](selection-statements.md#the-switch-statement) to transfer control to a switch section with a constant case label, as the following example shows:

:::code language="csharp" interactive="try-dotnet" source="snippets/jump-statements/GotoInSwitchExample.cs":::

Within the `switch` statement, you can also use the statement `goto default;` to transfer control to the switch section with the `default` label.

If a label with the given name doesn't exist in the current function member, or if the `goto` statement is not within the scope of the label, a compile-time error occurs. That is, you can't use the `goto` statement to transfer control out of the current function member or into any nested scope, for example, a `try` block.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharplang/spec/introduction.md):

- [The `break` statement](~/_csharplang/spec/statements.md#the-break-statement)
- [The `continue` statement](~/_csharplang/spec/statements.md#the-continue-statement)
- [The `return` statement](~/_csharplang/spec/statements.md#the-return-statement)
- [The `goto` statement](~/_csharplang/spec/statements.md#the-goto-statement)

## See also

- [C# reference](../index.md)
- [`yield` statement](../keywords/yield.md)
