---
title: C# for statement
ms.date: 06/13/2018
f1_keywords:
  - "for"
  - "for_CSharpKeyword"
helpviewer_keywords:
  - "for keyword [C#]"
ms.assetid: 34041a40-2c87-467a-9ffb-a0417d8f67a8
---
# for (C# reference)

The `for` statement executes a statement or a block of statements while a specified Boolean expression evaluates to `true`.

At any point within the `for` statement block, you can break out of the loop by using the [break](break.md) statement, or step to the next iteration in the loop by using the [continue](continue.md) statement. You also can exit a `for` loop by the [goto](goto.md), [return](return.md), or [throw](throw.md) statements.

## Structure of the `for` statement

The `for` statement defines *initializer*, *condition*, and *iterator* sections:

```csharp
for (initializer; condition; iterator)
    body
```

All three sections are optional. The body of the loop is either a statement or a block of statements.

The following example shows the `for` statement with all of the sections defined:

[!code-csharp-interactive[for loop example](~/samples/snippets/csharp/keywords/IterationKeywordsExamples.cs#5)]

### The *initializer* section

The statements in the *initializer* section are executed only once, before entering the loop. The *initializer* section is either of the following:

- The declaration and initialization of a local loop variable, which can't be accessed from outside the loop.

- Zero or more statement expressions from the following list, separated by commas:

  - [assignment](../operators/assignment-operator.md) statement

  - invocation of a method

  - prefix or postfix [increment](../operators/arithmetic-operators.md#increment-operator-) expression, such as `++i` or `i++`

  - prefix or postfix [decrement](../operators/arithmetic-operators.md#decrement-operator---) expression, such as `--i` or `i--`

  - creation of an object by using the [new](../operators/new-operator.md) operator

  - [await](await.md) expression

The *initializer* section in the example above declares and initializes the local loop variable `i`:

```csharp
int i = 0
```

### The *condition* section

The *condition* section, if present, must be a boolean expression. That expression is evaluated before every loop iteration. If the *condition* section is not present or the boolean expression evaluates to `true`, the next loop iteration is executed; otherwise, the loop is exited.

The *condition* section in the example above determines if the loop terminates based on the value of the local loop variable:

```csharp
i < 5
```

### The *iterator* section

The *iterator* section defines what happens after each iteration of the body of the loop. The *iterator* section contains zero or more of the following statement expressions, separated by commas:

- [assignment](../operators/assignment-operator.md) statement

- invocation of a method

- prefix or postfix [increment](../operators/arithmetic-operators.md#increment-operator-) expression, such as `++i` or `i++`

- prefix or postfix [decrement](../operators/arithmetic-operators.md#decrement-operator---) expression, such as `--i` or `i--`

- creation of an object by using the [new](../operators/new-operator.md) operator

- [await](await.md) expression

The *iterator* section in the example above increments the local loop variable:

```csharp
i++
```

## Examples

The following example illustrates several less common usages of the `for` statement sections: assigning a value to an external loop variable in the *initializer* section, invoking a method in both the *initializer* and the *iterator* sections, and changing the values of two variables in the *iterator* section. Select **Run** to run the example code. After that you can modify the code and run it again.

[!code-csharp-interactive[not typical for loop example](~/samples/snippets/csharp/keywords/IterationKeywordsExamples.cs#6)]

The following example defines the infinite `for` loop:

[!code-csharp[infinite for loop example](~/samples/snippets/csharp/keywords/IterationKeywordsExamples.cs#7)]

## C# language specification

For more information, see [The for statement](~/_csharplang/spec/statements.md#the-for-statement) section of the [C# language specification](../language-specification/index.md).

## See also

- [C# Reference](../index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [C# Keywords](index.md)
- [foreach, in](foreach-in.md)
