---
title: "Jump statements - break, continue, return, and goto"
description: "C# jump statements (break, continue, return, and goto) unconditionally transfer control from the current location to a different statement."
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

The jump statements unconditionally transfer control. The [`break` statement](#the-break-statement) terminates the closest enclosing [iteration statement](iteration-statements.md) or [`switch` statement](selection-statements.md#the-switch-statement). The [`continue` statement](#the-continue-statement) starts a new iteration of the closest enclosing [iteration statement](iteration-statements.md). The [`return` statement](#the-return-statement) terminates execution of the function in which it appears and returns control to the caller. The [`goto` statement](#the-goto-statement) transfers control to a statement that is marked by a label.

For information about the `throw` statement that throws an exception and unconditionally transfers control as well, see [The `throw` statement](exception-handling-statements.md#the-throw-statement) section of the [Exception-handling statements](exception-handling-statements.md) article.

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

### Ref returns

By default, the `return` statement returns the value of an expression. You can return a reference to a variable. Reference return values (or ref returns) are values that a method returns by reference to the caller. That is, the caller can modify the value returned by a method, and that change is reflected in the state of the object in the called method. To do that, use the `return` statement with the `ref` keyword, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/jump-statements/ReturnStatement.cs" id="RefReturn":::

A reference return value allows a method to return a reference to a variable, rather than a value, back to a caller. The caller can then choose to treat the returned variable as if it were returned by value or by reference. The caller can create a new variable that is itself a reference to the returned value, called a [ref local](declarations.md#reference-variables). A *reference return value* means that a method returns a *reference* (or an alias) to some variable. That variable's scope must include the method. That variable's lifetime must extend beyond the return of the method. Modifications to the method's return value by the caller are made to the variable that is returned by the method.

Declaring that a method returns a *reference return value* indicates that the method returns an alias to a variable. The design intent is often that calling code accesses that variable through the alias, including to modify it. Methods returning by reference can't have the return type `void`.

In order for the caller to modify the object's state, the reference return value must be stored to a variable that is explicitly defined as a [reference variable](../statements/declarations.md#reference-variables).

The `ref` return value is an alias to another variable in the called method's scope. You can interpret any use of the ref return as using the variable it aliases:

- When you assign its value, you're assigning a value to the variable it aliases.
- When you read its value, you're reading the value of the variable it aliases.
- If you return it *by reference*, you're returning an alias to that same variable.
- If you pass it to another method *by reference*, you're passing a reference to the variable it aliases.
- When you make a [ref local](declarations.md#reference-variables) alias, you make a new alias to the same variable.

A ref return must be [*ref-safe-context*](../keywords/method-parameters.md#safe-context-of-references-and-values) to the calling method. That means:

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

Here's a more complete ref return example, showing both the method signature and method body.

:::code language="csharp" source="snippets/jump-statements/RefParameterModifier.cs" id="SnippetFindReturningRef":::

The called method may also declare the return value as `ref readonly` to return the value by reference, and enforce that the calling code can't modify the returned value. The calling method can avoid copying the returned value by storing the value in a local `ref readonly` reference variable.

The following example defines a `Book` class that has two <xref:System.String> fields, `Title` and `Author`. It also defines a `BookCollection` class that includes a private array of `Book` objects. Individual book objects are returned by reference by calling its `GetBookByTitle` method.

:::code language="csharp" source="snippets/jump-statements/RefParameterModifier.cs" id="Snippet4":::

When the caller stores the value returned by the `GetBookByTitle` method as a ref local, changes that the caller makes to the return value are reflected in the `BookCollection` object, as the following example shows.

:::code language="csharp" source="snippets/jump-statements/RefParameterModifier.cs" id="Snippet5":::

## The `goto` statement

The `goto` statement transfers control to a statement that is marked by a label, as the following example shows:

:::code language="csharp" source="snippets/jump-statements/GotoStatement.cs" id="NestedLoops":::

As the preceding example shows, you can use the `goto` statement to get out of a nested loop.

> [!TIP]
> When you work with nested loops, consider refactoring separate loops into separate methods. That may lead to a simpler, more readable code without the `goto` statement.

You can also use the `goto` statement in the [`switch` statement](selection-statements.md#the-switch-statement) to transfer control to a switch section with a constant case label, as the following example shows:

:::code language="csharp" interactive="try-dotnet" source="snippets/jump-statements/GotoInSwitchExample.cs":::

Within the `switch` statement, you can also use the statement `goto default;` to transfer control to the switch section with the `default` label.

If a label with the given name doesn't exist in the current function member, or if the `goto` statement isn't within the scope of the label, a compile-time error occurs. That is, you can't use the `goto` statement to transfer control out of the current function member or into any nested scope.

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [The `break` statement](~/_csharpstandard/standard/statements.md#13102-the-break-statement)
- [The `continue` statement](~/_csharpstandard/standard/statements.md#13103-the-continue-statement)
- [The `return` statement](~/_csharpstandard/standard/statements.md#13105-the-return-statement)
- [The `goto` statement](~/_csharpstandard/standard/statements.md#13104-the-goto-statement)

## See also

- [`yield` statement](yield.md)
