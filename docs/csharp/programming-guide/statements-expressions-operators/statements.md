---
title: "Statements - C# Programming Guide"
description: Learn about statements in C# programming. See a list of statement types, and view code examples and additional resources.
ms.date: 07/20/2015
helpviewer_keywords: 
  - "statements [C#], about statements"
  - "C# language, statements"
ms.assetid: 901bcde7-87de-4e15-833c-f9cfd40c8ce3
---
# Statements (C# Programming Guide)

The actions that a program takes are expressed in statements. Common actions include declaring variables, assigning values, calling methods, looping through collections, and branching to one or another block of code, depending on a given condition. The order in which statements are executed in a program is called the flow of control or flow of execution. The flow of control may vary every time that a program is run, depending on how the program reacts to input that it receives at run time.

A statement can consist of a single line of code that ends in a semicolon, or a series of single-line statements in a block. A statement block is enclosed in {} brackets and can contain nested blocks. The following code shows two examples of single-line statements, and a multi-line statement block:

[!code-csharp[csProgGuideStatements#1](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStatements/CS/Statements.cs#1)]

## Types of statements

The following table lists the various types of statements in C# and their associated keywords, with links to topics that include more information:

|Category|C# keywords / notes|
|--------------|---------------------------|
|[Declaration statements](#declaration-statements)|A declaration statement introduces a new variable or constant. A variable declaration can optionally assign a value to the variable. In a constant declaration, the assignment is required.|
|[Expression statements](#expression-statements)|Expression statements that calculate a value must store the value in a variable.|
|Selection statements|Selection statements enable you to branch to different sections of code, depending on one or more specified conditions. For more information, see the following topics: <ul><li>[if](../../language-reference/statements/selection-statements.md#the-if-statement)</li><li>[switch](../../language-reference/statements/selection-statements.md#the-switch-statement)</li></ul>|
|Iteration statements|Iteration statements enable you to loop through collections like arrays, or perform the same set of statements repeatedly until a specified condition is met. For more information, see the following topics: <ul><li>[do](../../language-reference/statements/iteration-statements.md#the-do-statement)</li><li>[for](../../language-reference/statements/iteration-statements.md#the-for-statement)</li><li>[foreach](../../language-reference/statements/iteration-statements.md#the-foreach-statement)</li><li>[while](../../language-reference/statements/iteration-statements.md#the-while-statement)</li></ul>|
|Jump statements|Jump statements transfer control to another section of code. For more information, see the following topics: <ul><li>[break](../../language-reference/statements/jump-statements.md#the-break-statement)</li><li>[continue](../../language-reference/statements/jump-statements.md#the-continue-statement)</li><li>[goto](../../language-reference/statements/jump-statements.md#the-goto-statement)</li><li>[return](../../language-reference/statements/jump-statements.md#the-return-statement)</li><li>[yield](../../language-reference/keywords/yield.md)</li></ul>|
|Exception handling statements|Exception handling statements enable you to gracefully recover from exceptional conditions that occur at run time. For more information, see the following topics: <ul><li>[throw](../../language-reference/keywords/throw.md)</li><li>[try-catch](../../language-reference/keywords/try-catch.md)</li><li>[try-finally](../../language-reference/keywords/try-finally.md)</li><li>[try-catch-finally](../../language-reference/keywords/try-catch-finally.md)</li></ul>|
|[Checked and unchecked](../../language-reference/keywords/checked-and-unchecked.md)|Checked and unchecked statements enable you to specify whether numerical operations are allowed to cause an overflow when the result is stored in a variable that is too small to hold the resulting value. For more information, see [checked](../../language-reference/keywords/checked.md) and [unchecked](../../language-reference/keywords/unchecked.md).|
|The `await` statement|If you mark a method with the [async](../../language-reference/keywords/async.md) modifier, you can use the [await](../../language-reference/operators/await.md) operator in the method. When control reaches an `await` expression in the async method, control returns to the caller, and progress in the method is suspended until the awaited task completes. When the task is complete, execution can resume in the method.<br /><br /> For a simple example, see the "Async Methods" section of [Methods](../classes-and-structs/methods.md). For more information, see [Asynchronous Programming with async and await](../concepts/async/index.md).|
|The `yield return` statement|An iterator performs a custom iteration over a collection, such as a list or an array. An iterator uses the [yield return](../../language-reference/keywords/yield.md) statement to return each element one at a time. When a `yield return` statement is reached, the current location in code is remembered. Execution is restarted from that location when the iterator is called the next time.<br /><br /> For more information, see [Iterators](../concepts/iterators.md).|
|The `fixed` statement|The fixed statement prevents the garbage collector from relocating a movable variable. For more information, see [fixed](../../language-reference/keywords/fixed-statement.md).|
|The `lock` statement|The lock statement enables you to limit access to blocks of code to only one thread at a time. For more information, see [lock](../../language-reference/statements/lock.md).|
|Labeled statements|You can give a statement a label and then use the [goto](../../language-reference/statements/jump-statements.md#the-goto-statement) keyword to jump to the labeled statement. (See the example in the following row.)|
|The [empty statement](#the-empty-statement)|The empty statement consists of a single semicolon. It does nothing and can be used in places where a statement is required but no action needs to be performed.|

## Declaration statements

The following code shows examples of variable declarations with and without an initial assignment, and a constant declaration with the necessary initialization.

[!code-csharp[csProgGuideStatements#23](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStatements/CS/Statements.cs#23)]

## Expression statements

The following code shows examples of expression statements, including assignment, object creation with assignment, and method invocation.

[!code-csharp[csProgGuideStatements#24](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStatements/CS/Statements.cs#24)]

## The empty statement

The following examples show two uses for an empty statement:

[!code-csharp[csProgGuideStatements#25](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStatements/CS/Statements.cs#25)]

## Embedded statements

Some statements, for example, [iteration statements](../../language-reference/statements/iteration-statements.md), always have an embedded statement that follows them. This embedded statement may be either a single statement or multiple statements enclosed by {} brackets in a statement block. Even single-line embedded statements can be enclosed in {} brackets, as shown in the following example:

[!code-csharp[csProgGuideStatements#26](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStatements/CS/Statements.cs#26)]

An embedded statement that is not enclosed in {} brackets cannot be a declaration statement or a labeled statement. This is shown in the following example:

[!code-csharp[csProgGuideStatements#27](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStatements/CS/Statements.cs#27)]

Put the embedded statement in a block to fix the error:

[!code-csharp[csProgGuideStatements#28](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStatements/CS/Statements.cs#28)]

## Nested statement blocks

Statement blocks can be nested, as shown in the following code:

[!code-csharp[csProgGuideStatements#29](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStatements/CS/Statements.cs#29)]

## Unreachable statements

If the compiler determines that the flow of control can never reach a particular statement under any circumstances, it will produce warning CS0162, as shown in the following example:

[!code-csharp[csProgGuideStatements#22](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csProgGuideStatements/CS/Statements.cs#22)]

## C# language specification

For more information, see the [Statements](~/_csharplang/spec/statements.md) section of the [C# language specification](~/_csharplang/spec/introduction.md).

## See also

- [C# Programming Guide](../index.md)
- [Statement keywords](../../language-reference/keywords/statement-keywords.md)
- [C# operators and expressions](../../language-reference/operators/index.md)
