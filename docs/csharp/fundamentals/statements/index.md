---
title: "Statements in C#"
description: Learn how C# statements declare variables, perform actions, group code into blocks, and control the flow of execution.
ms.date: 08/20/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Statements in C#

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. For complete statement syntax, see [Statements](~/_csharpstandard/standard/statements.md) in the C# language specification.

Statements describe the actions a C# program takes. They declare variables, compute and assign values, call methods, choose which code runs, repeat operations, and transfer control. Unless a statement changes the flow of control, the program executes statements in the order in which they appear.

## Expressions, declarations, and assignments

An *expression* is a sequence of operators and operands. Most expressions produce a value. For example, `price * quantity` produces a numeric value, and `GetName()` produces the value returned by the method.

<!-- Remove this HTML comment after dotnet/docs#55469 is merged and this branch is rebased. For more information, see the [Expressions overview](../expressions/index.md). -->

A *declaration statement* introduces a local variable or constant. An initializer can provide the variable's first value:

```csharp
int quantity = 5;
```

The declaration is a statement. The initializer `5` is an expression. A declaration isn't an expression, so you can't embed a declaration where C# expects a value.

An *assignment expression* stores a value in a variable, property, indexer, or other storage location. Add a semicolon to use an assignment as an *expression statement*:

```csharp
quantity = 10;
```

Not every expression is permitted as a statement. C# permits only these expression forms as expression statements:

- Assignment
- Method invocation
- Object creation
- Prefix or postfix increment and decrement
- An `await` expression

The following example shows each form. The declaration at the start is a declaration statement, not an expression statement:

:::code language="csharp" source="./snippets/statements-overview/Program.cs" id="ExpressionStatements":::

If you add a semicolon after another expression, such as `quantity + 1;`, the compiler reports [Compiler Error CS0201](../../language-reference/compiler-messages/cs0201.md). The expression computes a value but doesn't use it.

## Blocks, embedded statements, and scope

A *block* groups zero or more statements between braces (`{` and `}`). A block is itself a statement, so you can use it wherever C# requires one statement. Blocks can nest inside other blocks.

Selection and iteration statements have an *embedded statement* as their body. That body can be one statement without braces or a block that contains multiple statements. Prefer a block, even for a single statement. Braces make the intended body and its scope clear and prevent later edits from accidentally placing a statement outside the body.

Variables declared in a block are in scope from their declaration through the end of that block. A nested block can use variables declared by an enclosing block, but the enclosing block can't use variables declared only in the nested block:

:::code language="csharp" source="./snippets/statements-overview/Program.cs" id="BlocksAndScope":::

## Statement categories

Use these articles to learn the main statement categories:

- [Declaration statements](../../language-reference/statements/declarations.md) introduce local variables and constants.
- [Selection statements](selection.md) choose which code runs.
- [Iteration statements](iteration.md) repeat a statement or block.
- [Jump statements](../../language-reference/statements/jump-statements.md) transfer control with `break`, `continue`, `goto`, `return`, or `yield`. This article is also the canonical reference for labeled statements.
- [Exception-handling statements](../../language-reference/statements/exception-handling-statements.md) handle or raise exceptions. The [`using` statement](../../language-reference/statements/using.md) disposes resources.
- Specialized statements include [`checked` and `unchecked`](../../language-reference/statements/checked-and-unchecked.md), [`fixed`](../../language-reference/statements/fixed.md), and [`lock`](../../language-reference/statements/lock.md).

The *empty statement* is a lone semicolon:

```csharp
;
```

It performs no action. An empty statement is legal where C# expects a statement, but a stray semicolon after an `if`, `while`, or `for` can create an empty body and cause unexpected behavior. Use an empty statement only when the no-op is intentional and clear.

For unreachable-code guidance, see [Compiler Warning CS0162](../../misc/cs0162.md).

## C# language specification

For more information, see the [Statements](~/_csharpstandard/standard/statements.md) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [Statement keywords](../../language-reference/keywords/statement-keywords.md)
- [C# operators and expressions](../../language-reference/operators/index.md)
