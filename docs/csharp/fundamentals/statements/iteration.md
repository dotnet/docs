---
title: "Iteration statements in C#"
description: Use foreach, while, do-while, and for to repeat a block of code, and use break and continue to control the flow of a loop.
ms.date: 07/09/2026
ms.topic: concept-article
ai-usage: ai-assisted
---

# Iteration statements

> [!TIP]
> This article is part of the **Fundamentals** section for developers who already know at least one programming language and are learning C#. If you're new to programming, start with the [Get started](../../tour-of-csharp/tutorials/index.md) tutorials first. For the complete syntax, see [iteration statements](../../language-reference/statements/iteration-statements.md) in the language reference.
>
> **Coming from another language?** All four C# loops (`foreach`, `while`, `do`-`while`, and `for`) have direct equivalents in Java, C++, and JavaScript. You use `foreach` most often. It iterates a collection without an index, like Java's enhanced `for` or JavaScript's `for...of`.

Iteration statements run a block of code repeatedly. Each pass through the block is an *iteration*, and a repeating block is a *loop*. C# provides four loops. Start with `foreach` for collections, use `while` and `do`-`while` when a condition controls the repetition, and use `for` when you need an explicit index.

## Iterate a collection with `foreach`

The `foreach` statement runs its body once for each element in a collection, in order. It's the most common choice for reading a collection because you don't manage an index or a bounds check. The `foreach` statement prevents typical off-by-one errors:

:::code language="csharp" source="./snippets/iteration-statements/Program.cs" id="Foreach":::

`foreach` works with any type that C# recognizes as a sequence, including arrays, <xref:System.Collections.Generic.List`1>, and <xref:System.Collections.Generic.Dictionary`2>. The iteration variable (`name` in the previous example) is read-only, so you can't reassign it inside the loop.

The body of a loop is a single *statement*, such as an assignment or a method call. A *block statement* is itself a single statement that encloses zero or more statements in braces (`{ }`).

Many coding standards recommend that you enclose the loop body in braces, even for a single statement. Braces make the scope explicit. It prevents a common mistake: adding a second line later that you expect to run each iteration, but that runs once after the loop instead. Only the braces decide which statements belong to the loop. C# doesn't treat whitespace as significant, so indentation alone never does. Braces are legal even around one line: the block is the single statement that the loop repeats. Indent your code for readability, but rely on braces to define the block.

## Repeat while a condition holds with `while`

A `while` loop checks its Boolean condition *before* each iteration. If the condition is `false` at the start, the body never runs, so a `while` loop runs zero or more times:

:::code language="csharp" source="./snippets/iteration-statements/Program.cs" id="While":::

Make sure something inside the loop changes the condition. In the previous example, `countdown--` eventually makes the condition `false`. A loop whose condition never becomes `false` runs forever.

## Run the body at least once with `do`-`while`

A `do`-`while` loop checks its condition *after* each iteration, so the body always runs at least once. Use it when the first pass must happen before you can evaluate the condition, such as prompting for input and then validating it:

:::code language="csharp" source="./snippets/iteration-statements/Program.cs" id="DoWhile":::

## Count with `for`

A `for` loop statement contains three parts: an *initializer* that runs once before the loop, a *condition* that's checked before each iteration, and an *iterator* that runs after each iteration. Use `for` when you need the index itself, not just the elements. Typically, you need the index when you want to modify the element rather than reading its value.

:::code language="csharp" source="./snippets/iteration-statements/Program.cs" id="For":::

When you only read the elements, when you don't use the positions or assign new values, prefer `foreach`. It states the intent more clearly and avoids index arithmetic.

## Exit or skip with `break` and `continue`

Two jump statements give you finer control inside any loop. The `break` statement exits the loop immediately, skipping any remaining iterations:

:::code language="csharp" source="./snippets/iteration-statements/Program.cs" id="Break":::

The `continue` statement skips the rest of the current iteration and moves on to the next one:

:::code language="csharp" source="./snippets/iteration-statements/Program.cs" id="Continue":::

## Iterate an asynchronous stream with `await foreach`

An *asynchronous stream* is a reader that uses an asynchronous task to produce each next element. C# represents it with the <xref:System.Collections.Generic.IAsyncEnumerable`1> interface. Data that arrives over time, such as pages from a web API or rows from a database, fits this model: retrieving the next element is an awaitable operation instead of an immediate return.

To consume an asynchronous stream, put the `await` keyword before `foreach`. Each iteration awaits the next element, so the loop suspends while that element is produced instead of blocking the thread:

:::code language="csharp" source="./snippets/iteration-statements/Program.cs" id="AwaitForeach":::

Asynchronous streams build on `async` and `await`. For a full walkthrough, see [Generate and consume asynchronous streams](../../asynchronous-programming/generate-consume-asynchronous-stream.md).

## See also

- [Selection statements](selection.md)
- [Iteration statements (language reference)](../../language-reference/statements/iteration-statements.md)
- [Generate and consume asynchronous streams](../../asynchronous-programming/generate-consume-asynchronous-stream.md)
