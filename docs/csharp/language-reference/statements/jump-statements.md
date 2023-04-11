---
title: "Jump statements - break, continue, return, and goto"
description: "C# jump statements (break, continue, return, and goto), unconditionally transfer control from the current location to a different statement. These locations jump to a new location."
ms.date: 11/22/2022
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
# Jump statements - `break`, `continue`, `return`, and `goto`

Four C# statements unconditionally transfer control. The `break` [statement](#the-break-statement), terminates the closest enclosing [iteration statement](iteration-statements.md) or `switch` [statement](selection-statements.md#the-switch-statement). The `continue` [statement](#the-continue-statement) starts a new iteration of the closest enclosing [iteration statement](iteration-statements.md). The `return` [statement](#the-return-statement): terminates execution of the function in which it appears and returns control to the caller. The `ref` modifier on a `return` statement indicates the returned expression is returned *by reference*, not *by value*. The `goto` [statement](#the-goto-statement): transfers control to a statement that is marked by a label.

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

When the `return` statement has an expression, that expression must be implicitly convertible to the return type of a function member unless it's [async](../keywords/async.md). The expression returned from an `async` function must be implicitly convertible to the type argument of <xref:System.Threading.Tasks.Task%601> or <xref:System.Threading.Tasks.ValueTask%601>, whichever is the return type of the function. If the return type of an `async` function is <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.ValueTask>, you use the `return` statement without expression.

By default, the `return` statement returns the value of an expression. You can return a reference to a variable. To do that, use the `return` statement with the [`ref` keyword](../keywords/ref.md), as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/jump-statements/ReturnStatement.cs" id="RefReturn":::

### Ref returns

Return values can be returned by reference (`ref` returns). A reference return value allows a method to return a reference to a variable, rather than a value, back to a caller. The caller can then choose to treat the returned variable as if it were returned by value or by reference. The caller can create a new variable that is itself a reference to the returned value, called a [ref local](declarations.md#ref-locals). A *reference return value* means that a method returns a *reference* (or an alias) to some variable. That variable's scope must include the method. That variable's lifetime must extend beyond the return of the method. Modifications to the method's return value by the caller are made to the variable that is returned by the method.

Declaring that a method returns a *reference return value* indicates that the method returns an alias to a variable. The design intent is often that calling code accesses that variable through the alias, including to modify it. Methods returning by reference can't have the return type `void`.

The `ref` return value is an alias to another variable in the called method's scope. You can interpret any use of the ref return as using the variable it aliases:

- When you assign its value, you're assigning a value to the variable it aliases.
- When you read its value, you're reading the value of the variable it aliases.
- If you return it *by reference*, you're returning an alias to that same variable.
- If you pass it to another method *by reference*, you're passing a reference to the variable it aliases.
- When you make a [ref local](declarations.md#ref-locals) alias, you make a new alias to the same variable.

A ref return must be [*ref_safe_to_escape*](../keywords/method-parameters.md#scope-of-references-and-values) to the calling method. That means:

- The return value must have a lifetime that extends beyond the execution of the method. In other words, it can't be a local variable in the method that returns it. It can be an instance or static field of a class, or it can be an argument passed to the method. Attempting to return a local variable generates compiler error CS8168, "Can't return local 'obj' by reference because it isn't a ref local."
- The return value can't be the literal `null`. A method with a ref return can return an alias to a variable whose value is currently the `null` (uninstantiated) value or a [nullable value type](../../language-reference/builtin-types/nullable-value-types.md) for a value type.
- The return value can't be a constant, an enumeration member, the by-value return value from a property, or a method of a `class` or `struct`.

In addition, reference return values aren't allowed on async methods. An asynchronous method may return before it has finished execution, while its return value is still unknown.

A method that returns a *reference return value* must:

- Include the [ref](../../language-reference/keywords/ref.md) keyword in front of the return type.
- Each [return](../../language-reference/statements/jump-statements.md#the-return-statement) statement in the method body includes the [ref](../../language-reference/keywords/ref.md) keyword in front of the name of the returned instance.

The following example shows a method that satisfies those conditions and returns a reference to a `Person` object named `p`:

```csharp
public ref Person GetContactInformation(string fname, string lname)
{
    // ...method implementation...
    return ref p;
}
```

## The `goto` statement

The `goto` statement transfers control to a statement that is marked by a label, as the following example shows:

:::code language="csharp" source="snippets/jump-statements/GotoStatement.cs" id="NestedLoops":::

As the preceding example shows, you can use the `goto` statement to get out of a nested loop.

> [!TIP]
> When you work with nested loops, consider refactoring separate loops into separate methods. That may lead to a simpler, more readable code without the `goto` statement.

You can also use the `goto` statement in the [`switch` statement](selection-statements.md#the-switch-statement) to transfer control to a switch section with a constant case label, as the following example shows:

:::code language="csharp" interactive="try-dotnet" source="snippets/jump-statements/GotoInSwitchExample.cs":::

Within the `switch` statement, you can also use the statement `goto default;` to transfer control to the switch section with the `default` label.

If a label with the given name doesn't exist in the current function member, or if the `goto` statement isn't within the scope of the label, a compile-time error occurs. That is, you can't use the `goto` statement to transfer control out of the current function member or into any nested scope, for example, a `try` block.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [The `break` statement](~/_csharpstandard/standard/statements.md#13102-the-break-statement)
- [The `continue` statement](~/_csharpstandard/standard/statements.md#13103-the-continue-statement)
- [The `return` statement](~/_csharpstandard/standard/statements.md#13105-the-return-statement)
- [The `goto` statement](~/_csharpstandard/standard/statements.md#13104-the-goto-statement)

## See also

- [C# reference](../index.md)
- [`yield` statement](yield.md)
