---
title: "Resolve errors and warnings related to jump statements"
description: "This article helps you diagnose and correct compiler errors and warnings related to the break, continue, goto, and return jump statements."
f1_keywords:
  - "CS0126"
  - "CS0127"
  - "CS0139"
  - "CS0140"
  - "CS0153"
  - "CS0157"
  - "CS0158"
  - "CS0159"
  - "CS0161"
  - "CS0162"
  - "CS0163"
  - "CS0164"
  - "CS0469"
  - "CS8070"
  - "CS9393"
  - "CS9394"
helpviewer_keywords:
  - "CS0126"
  - "CS0127"
  - "CS0139"
  - "CS0140"
  - "CS0153"
  - "CS0157"
  - "CS0158"
  - "CS0159"
  - "CS0161"
  - "CS0162"
  - "CS0163"
  - "CS0164"
  - "CS0469"
  - "CS8070"
  - "CS9393"
  - "CS9394"
ms.date: 10/30/2026
ai-usage: ai-assisted
---
# Resolve errors and warnings for jump statements

This article covers the following compiler errors and warnings:

<!-- The text in this list generates issues for Acrolinx, because they don't use contractions.
That's by design. The text closely matches the text of the compiler error or warning for SEO purposes.
 -->

- [**CS0126**](#return-the-required-values): *An object of a type convertible to 'type' is required*
- [**CS0127**](#return-the-required-values): *Since 'method' returns void, a return keyword must not be followed by an object expression*
- [**CS0139**](#choose-valid-jump-targets): *No enclosing loop out of which to break or continue*
- [**CS0140**](#define-and-reference-labels-consistently): *The label 'label' is a duplicate*
- [**CS0153**](#choose-valid-jump-targets): *A goto case is only valid inside a switch statement*
- [**CS0157**](#choose-valid-jump-targets): *Control cannot leave the body of a finally clause*
- [**CS0158**](#define-and-reference-labels-consistently): *The label 'label' shadows another label by the same name in a contained scope*
- [**CS0159**](#choose-valid-jump-targets): *No such label 'label' within the scope of the goto statement*
- [**CS0161**](#return-the-required-values): *'method': not all code paths return a value*
- [**CS0162**](#remove-unreachable-code): *Unreachable code detected*
- [**CS0163**](#terminate-switch-sections-explicitly): *Control cannot fall through from one case label ('label') to another*
- [**CS0164**](#define-and-reference-labels-consistently): *This label has not been referenced*
- [**CS0469**](#choose-valid-jump-targets): *The 'goto case' value is not implicitly convertible to type 'type'*
- [**CS8070**](#terminate-switch-sections-explicitly): *Control cannot fall out of switch from final case label ('label')*
- [**CS9393**](#choose-valid-jump-targets): *No enclosing loop or switch statement with the label 'label' out of which to break*
- [**CS9394**](#choose-valid-jump-targets): *No enclosing loop with the label 'label' out of which to continue*

## Choose valid jump targets

- **CS0139**: *No enclosing loop out of which to break or continue*
- **CS0153**: *A goto case is only valid inside a switch statement*
- **CS0157**: *Control cannot leave the body of a finally clause*
- **CS0159**: *No such label 'label' within the scope of the goto statement*
- **CS0469**: *The 'goto case' value is not implicitly convertible to type 'type'*
- **CS9393**: *No enclosing loop or switch statement with the label 'label' out of which to break*
- **CS9394**: *No enclosing loop with the label 'label' out of which to continue*

- Place `break` inside a loop or `switch` statement, and place `continue` inside a loop. Each statement needs an enclosing construct to target (**CS0139**).
- Apply the label in `break label;` to an enclosing loop or `switch` statement (**CS9393**). Apply the label in `continue label;` to an enclosing loop, not a `switch` statement (**CS9394**).
- Place `goto case` and `goto default` inside the `switch` statement that contains their destination (**CS0153**).
- Define the named destination within the `goto` statement's scope, or correct the target name. A `goto` statement can't enter a nested block or another member (**CS0159**).
- Give a `goto case` value a type that's implicitly convertible to the `switch` governing type. For example, use `goto case (char)127;` rather than `goto case 127;` when the destination is a character case label (**CS0469**).
- Move a `return`, `break`, `continue`, or `goto` that exits a `finally` block outside that block. Jumps within the block are valid only when their targets also remain inside it (**CS0157**).

See [Jump statements](../statements/jump-statements.md) and [The try-finally statement](../statements/exception-handling-statements.md#the-try-finally-statement) for the applicable control-flow rules.

## Define and reference labels consistently

- **CS0140**: *The label 'label' is a duplicate*
- **CS0158**: *The label 'label' shadows another label by the same name in a contained scope*
- **CS0164**: *This label has not been referenced*

- Rename labels that have the same name in the same or nested scopes, and update the corresponding `goto` targets. Remove a duplicate label if the existing label already marks the intended destination (**CS0140**, **CS0158**).
- Remove an unused label while keeping its statement. If a `goto` was intended to reach that statement, correct its target label instead (**CS0164**).

For label scope and target resolution, see [The goto statement](../statements/jump-statements.md#the-goto-statement).

## Terminate switch sections explicitly

- **CS0163**: *Control cannot fall through from one case label ('label') to another*
- **CS8070**: *Control cannot fall out of switch from final case label ('label')*

Add a jump statement such as `break`, `return`, `goto case`, `goto default`, or `throw` wherever control could otherwise reach the end of a `switch` section. Control can't fall into the next section (**CS0163**) or out of the final section (**CS8070**), even when the `switch` has only one section.

For example, terminate both the named case and the final `default` section:

```csharp
switch (number)
{
    case 0:
        number++;
        break;
    default:
        number = 0;
        break;
}
```

To share statements between values, stack their `case` labels with no intervening statements. To transfer control to another section explicitly, use `goto case` or `goto default`.

See [The switch statement](../statements/selection-statements.md#the-switch-statement) and [The throw statement](../statements/exception-handling-statements.md#the-throw-statement).

## Return the required values

- **CS0126**: *An object of a type convertible to 'type' is required*
- **CS0127**: *Since 'method' returns void, a return keyword must not be followed by an object expression*
- **CS0161**: *'method': not all code paths return a value*

- Supply an expression after `return` when the containing member requires a value, and make its type convertible to the required return type (**CS0126**).
- Use `return;` without an expression in a member that doesn't return a value, such as a `void` method or a property setter (**CS0127**).
- Cover every reachable exit from a value-returning member. Add a return for an uncovered branch, or throw when a branch can't produce a result (**CS0161**).

For return forms and requirements, see [The return statement](../statements/jump-statements.md#the-return-statement).

## Remove unreachable code

- **CS0162**: *Unreachable code detected*

Remove statements that follow an unconditional jump when no control-flow path can reach them. For example, remove `break;` immediately after `return` in a `switch` section; the return already exits the member (**CS0162**).

If the statements were intended to execute, move them before the jump or correct the condition or jump target that makes them unreachable. See [Jump statements](../statements/jump-statements.md) for how each statement transfers control.

## C# language specification

For more information, see the [Jump statements](~/_csharpstandard/standard/statements.md#1310-jump-statements) section of the C# language specification.

## See also

- [C# jump statements](../statements/jump-statements.md)
- [C# selection statements](../statements/selection-statements.md)
