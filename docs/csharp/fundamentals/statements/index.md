---
title: "C# statements"
description: Learn how C# statements declare variables, perform actions, group code into blocks, and control the flow of execution.
ms.date: 08/20/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# C# statements

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. For complete statement syntax, see [Statements](~/_csharpstandard/standard/statements.md) in the C# language specification.
>
> **Coming from another language?** Declarations, conditions, loops, and returns might be familiar. C# uses its own syntax and classification for these features, which this article introduces.

A *statement* is a complete command: "do this." Together, the statements in a program form a recipe that the program follows from start to finish. Most statements run in sequence. Branches choose which steps to run, and loops repeat steps.

This example declares a quantity, displays it, and then uses an `if` statement to decide whether to restock:

:::code language="csharp" source="./snippets/statements-overview/Program.cs" id="StatementRecipe":::

Read the example as complete commands before looking at their parts. The declaration, the first call to `Console.WriteLine`, the entire `if` construct, and the final call to `Console.WriteLine` are statements. The block inside the `if` statement contains two more statements.

## Statements often contain expressions

Statements often contain *expressions*, which are pieces of code that produce values. In the preceding example, the whole `if` construct is a statement. Its condition, `quantity < 10`, is an expression that produces either `true` or `false`.

A *declaration statement* introduces a local variable or constant. An initializer expression can provide its first value:

```csharp
int quantity = 5;
```

The complete line is a declaration statement. The initializer `5` is an expression within that statement. A declaration isn't an expression, so you can't place a declaration where C# expects a value.

An *assignment expression* stores a value in a variable, property, indexer, or other storage location. C# permits an assignment expression to form an *expression statement*:

```csharp
quantity = 10;
```

This statement performs an action rather than merely calculating a value. Method calls and increment operations are other common expression statements:

```csharp
Console.WriteLine("Restocking");
quantity++;
```

Only the following expression forms can be expression statements:

- Assignment expressions
- Method invocation expressions
- Object creation expressions
- Prefix or postfix increment and decrement expressions
- `await` expressions

Not every expression can stand alone as a statement. For example, `quantity + 1;` computes a value but doesn't use it, so the compiler reports [Compiler Error CS0201](../../language-reference/compiler-messages/cs0201.md).

<!-- Remove this HTML comment after dotnet/docs#55469 is merged and this branch is rebased. For more information, see the [Expressions overview](../expressions/index.md). -->

## Group statements in blocks

A *block* groups zero or more statements between braces (`{` and `}`). C# treats the group as one statement. In the opening example, the `if` statement can run both the assignment and the call to `Console.WriteLine` because a block groups them into one body. Blocks can nest inside other blocks.

Selection and iteration statements call their body an *embedded statement*. That body can be one statement without braces or a block that groups multiple statements.

Prefer a block even when a body contains only one statement. Braces show which statements belong to the body and prevent later edits from accidentally placing a statement outside it.

### Blocks and variable scope

Variables declared in a block are in scope from their declaration through the end of that block. A nested block can use variables declared by an enclosing block, but the enclosing block can't use variables declared only in the nested block:

:::code language="csharp" source="./snippets/statements-overview/Program.cs" id="BlocksAndScope":::

## Choose a statement for the task

After you recognize statements as commands, you can choose among their different kinds by purpose:

- **Declare data:** [Declaration statements](../../language-reference/statements/declarations.md) introduce local variables and constants.
- **Perform actions:** Expression statements assign values, call methods, create objects, increment or decrement values, or await asynchronous operations.
- **Choose steps:** [Selection statements](selection.md), such as `if` and `switch`, choose which code runs.
- **Repeat steps:** [Iteration statements](iteration.md), such as `foreach`, `while`, and `for`, repeat a statement or block.
- **Transfer control:** [Jump statements](../../language-reference/statements/jump-statements.md), such as `break`, `continue`, `return`, and `yield`, move execution to another point.
- **Handle exceptions:** [Exception-handling statements](../../language-reference/statements/exception-handling-statements.md), such as `try`, `catch`, and `throw`, respond to or report errors.
- **Manage resources:** The [`using` statement](../../language-reference/statements/using.md) ensures that resources are disposed.
- **Use specialized behavior:** The [`checked` and `unchecked`](../../language-reference/statements/checked-and-unchecked.md), [`fixed`](../../language-reference/statements/fixed.md), and [`lock`](../../language-reference/statements/lock.md) statements support specific scenarios.

## Less common statements

The *empty statement* is a lone semicolon:

```csharp
;
```

It performs no action. An empty statement is legal where C# expects a statement, but a stray semicolon after an `if`, `while`, or `for` can create an empty body and cause unexpected behavior. Use an empty statement only when the no-op is intentional and clear.

## C# language specification

For more information, see the [Statements](~/_csharpstandard/standard/statements.md) section of the [C# language specification](~/_csharpstandard/standard/README.md).

## See also

- [Statement keywords](../../language-reference/keywords/statement-keywords.md)
- [C# operators and expressions](../../language-reference/operators/index.md)
