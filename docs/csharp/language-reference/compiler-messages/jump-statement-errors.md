---
title: "Resolve errors and warnings related to jump statements"
description: "This article helps you diagnose and correct compiler errors and warnings related to the break, continue, goto, and return jump statements."
f1_keywords:
  - "CS0126"
  - "CS0127"
  - "CS0139"
  - "CS0153"
  - "CS0159"
  - "CS0161"
  - "CS0163"
  - "CS0469"
  - "CS9393"
  - "CS9394"
helpviewer_keywords:
  - "CS0126"
  - "CS0127"
  - "CS0139"
  - "CS0153"
  - "CS0159"
  - "CS0161"
  - "CS0163"
  - "CS0469"
  - "CS9393"
  - "CS9394"
ms.date: 07/17/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for jump statements

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error / warning for SEO purposes.
 -->

The following errors occur when you use a `break`, `continue`, `goto`, or `return` statement in a way that doesn't match the surrounding control flow:

- [**CS0126**](#return-statement-values): *An object of a type convertible to 'type' is required*
- [**CS0127**](#return-statement-values): *Since 'method' returns void, a return keyword must not be followed by an object expression*
- [**CS0139**](#break-and-continue-targets): *No enclosing loop out of which to break or continue*
- [**CS0153**](#goto-statement-targets): *A goto case is only valid inside a switch statement*
- [**CS0159**](#goto-statement-targets): *No such label 'label' within the scope of the goto statement*
- [**CS0161**](#return-statement-values): *'method': not all code paths return a value*
- [**CS0163**](#switch-section-termination): *Control cannot fall through from one case label ('label') to another*
- [**CS9393**](#break-and-continue-targets): *No enclosing loop or switch statement with the label 'label' out of which to break*
- [**CS9394**](#break-and-continue-targets): *No enclosing loop with the label 'label' out of which to continue*

The following warning occurs when a `goto case` statement targets a value that requires a conversion:

- [**CS0469**](#goto-statement-targets): *The 'goto case' value is not implicitly convertible to type 'type'*

## Break and continue targets

- **CS0139**: *No enclosing loop out of which to break or continue*
- **CS9393**: *No enclosing loop or switch statement with the label 'label' out of which to break*
- **CS9394**: *No enclosing loop with the label 'label' out of which to continue*

The `break` statement transfers control out of the nearest enclosing loop or `switch` statement, and the `continue` statement starts the next iteration of the nearest enclosing loop. The compiler reports these diagnostics when it can't find that target.

To resolve these errors:

- Place the `break` or `continue` statement inside a `while`, `do`, `for`, or `foreach` loop. A `break` statement can also appear in a `switch` section. A bare `break` or `continue` that isn't nested in one of these statements has no target (**CS0139**).
- When you write a labeled `break` (`break label;`), apply the same label to an enclosing loop or `switch` statement. The label must name a loop or `switch` that contains the `break` statement (**CS9393**).
- When you write a labeled `continue` (`continue label;`), apply the same label to an enclosing loop. A labeled `continue` can target only a loop, not a `switch` statement, because `continue` starts the next loop iteration (**CS9394**).

> [!NOTE]
> CS9393 and CS9394 are planned for C# 15, and labeled `break` and `continue` aren't available in public builds yet. Labeled `break` and `continue` let a statement in a nested loop target a specific enclosing loop or `switch` statement by name, which replaces the need for a `goto` statement or a flag variable. You apply a label to the target loop or `switch` statement, then reference that label in the `break` or `continue` statement, as in `outer: for (...) { ... break outer; }`. For more information about this feature, see the [labeled break and continue proposal](https://github.com/dotnet/csharplang/blob/main/proposals/labeled-break-continue.md).

For more information about these statements, see [The `break` statement](../statements/jump-statements.md#the-break-statement) and [The `continue` statement](../statements/jump-statements.md#the-continue-statement) in the jump statements article.

## Goto statement targets

- **CS0153**: *A goto case is only valid inside a switch statement*
- **CS0159**: *No such label 'label' within the scope of the goto statement*
- **CS0469**: *The 'goto case' value is not implicitly convertible to type 'type'*

The `goto` statement transfers control to a labeled statement, to a `case` label, or to the `default` label of a `switch` statement. The compiler reports these diagnostics when the target label doesn't exist or isn't reachable from the `goto` statement.

To resolve these errors:

- Use `goto case` and `goto default` only inside a `switch` statement. Both forms name a section of the enclosing `switch` statement, so they have no meaning outside one (**CS0153**).
- Add a label that matches the name in the `goto` statement, and confirm that the label is within the scope of the `goto` statement. A `goto` statement can't jump into a nested block, and `goto case` requires a matching `case` label in the same `switch` statement (**CS0159**).
- Give the `goto case` value the same type as the `switch` governing expression, or add an explicit cast so an implicit conversion exists. For example, use `goto case (char)127;` rather than `goto case 127;` when the `switch` governs a `char` value (**CS0469**).

For more information about the `goto` statement, see [The `goto` statement](../statements/jump-statements.md#the-goto-statement) in the jump statements article. For more information about `goto case` and `goto default`, see [The `switch` statement](../statements/selection-statements.md#the-switch-statement) in the selection statements article.

## Switch section termination

- **CS0163**: *Control cannot fall through from one case label ('label') to another*

C# doesn't allow control to fall through from one `switch` section to the next. When a `switch` statement contains more than one section, you must explicitly terminate each section, including the last one.

To resolve this error, end each `switch` section that contains statements with a jump statement, such as `break`, `return`, `goto case`, `goto default`, or `throw`. To run the same statements for more than one value, stack the `case` labels with no statements between them; that arrangement isn't fall-through. When you want one section to continue into another, use `goto case` or `goto default` to name the next section explicitly (**CS0163**).

For more information about the `switch` statement, see [The `switch` statement](../statements/selection-statements.md#the-switch-statement) in the selection statements article. For more information about the `throw` statement, see [The `throw` statement](../statements/exception-handling-statements.md#the-throw-statement) in the exception handling statements article.

## Return statement values

- **CS0126**: *An object of a type convertible to 'type' is required*
- **CS0127**: *Since 'method' returns void, a return keyword must not be followed by an object expression*
- **CS0161**: *'method': not all code paths return a value*

The `return` statement ends execution of the containing member and returns control to the caller. A `return` statement can also return a value.

To resolve these errors:

- Supply a value in each `return` statement of a member that has a non-`void` return type, and make sure the value is convertible to that return type. A `get` accessor and a value-returning method both require a `return` statement that includes a value (**CS0126**).
- Remove the value from any `return` statement in a member that returns `void`, such as a `set` accessor or a method with a `void` return type. Use a bare `return;` statement to exit early (**CS0127**).
- Make sure every code path in a value-returning member ends with a `return` statement or a `throw` statement. A member returns on all code paths when each branch of every conditional statement returns a value, or when a final `return` statement follows the conditional logic (**CS0161**).

For more information about `return` statements in async methods and members that return `Task` or `ValueTask` types, see [Errors and warnings related to async and await](async-await-errors.md). For more information about `return` statements in iterators, see [Errors and warnings related to iterators](iterator-yield.md).

For more information about the `return` statement, see [The `return` statement](../statements/jump-statements.md#the-return-statement) in the jump statements article.

## C# language specification

For more information, see the [Jump statements](~/_csharpstandard/standard/statements.md#1310-jump-statements) section of the C# language specification.

## See also

- [C# jump statements](../statements/jump-statements.md)
- [C# selection statements](../statements/selection-statements.md)
