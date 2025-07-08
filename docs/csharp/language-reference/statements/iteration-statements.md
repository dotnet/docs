---
title: "Iteration statements -for, foreach, do, and while"
description: "C# iteration statements (for, foreach, do, and while) repeatedly execute a block of code. You use those statements to create loops or iterate through a collection."
ms.date: 11/22/2022
f1_keywords:
  - "for_CSharpKeyword"
  - "foreach_CSharpKeyword"
  - "do_CSharpKeyword"
  - "while_CSharpKeyword"
helpviewer_keywords:
  - "for keyword [C#]"
  - "for statement [C#]"
  - "foreach keyword [C#]"
  - "foreach statement [C#]"
  - "in keyword [C#]"
  - "do keyword [C#]"
  - "do statement [C#]"
  - "while keyword [C#]"
  - "while statement [C#]"
---
# Iteration statements - `for`, `foreach`, `do`, and `while`

The iteration statements repeatedly execute a statement or a block of statements. The [`for` statement](#the-for-statement) executes its body while a specified Boolean expression evaluates to `true`. The [`foreach` statement](#the-foreach-statement) enumerates the elements of a collection and executes its body for each element of the collection. The [`do` statement](#the-do-statement) conditionally executes its body one or more times. The [`while` statement](#the-while-statement) conditionally executes its body zero or more times.

At any point within the body of an iteration statement, you can break out of the loop using the [`break` statement](jump-statements.md#the-break-statement). You can step to the next iteration in the loop using the [`continue` statement](jump-statements.md#the-continue-statement).

## The `for` statement

The `for` statement executes a statement or a block of statements while a specified Boolean expression evaluates to `true`. The following example shows the `for` statement that executes its body while an integer counter is less than three:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/iteration-statements/ForStatement.cs" id="TypicalExample":::

The preceding example shows the elements of the `for` statement:

- The *initializer* section that is executed only once, before entering the loop. Typically, you declare and initialize a local loop variable in that section. The declared variable can't be accessed from outside the `for` statement.

  The *initializer* section in the preceding example declares and initializes an integer counter variable:

  ```csharp
  int i = 0
  ```

- The *condition* section that determines if the next iteration in the loop should be executed. If it evaluates to `true` or isn't present, the next iteration is executed; otherwise, the loop is exited. The *condition* section must be a Boolean expression.

  The *condition* section in the preceding example checks if a counter value is less than three:

  ```csharp
  i < 3
  ```

- The *iterator* section that defines what happens after each execution of the body of the loop.

  The *iterator* section in the preceding example increments the counter:

  ```csharp
  i++
  ```

- The body of the loop, which must be a statement or a block of statements.

The iterator section can contain zero or more of the following statement expressions, separated by commas:

- prefix or postfix [increment](../operators/arithmetic-operators.md#increment-operator-) expression, such as `++i` or `i++`
- prefix or postfix [decrement](../operators/arithmetic-operators.md#decrement-operator---) expression, such as `--i` or `i--`
- [assignment](../operators/assignment-operator.md)
- invocation of a method
- [`await` expression](../operators/await.md)
- creation of an object by using the [`new` operator](../operators/new-operator.md)

If you don't declare a loop variable in the initializer section, you can use zero or more of the expressions from the preceding list in the initializer section as well. The following example shows several less common usages of the initializer and iterator sections: assigning a value to an external variable in the initializer section, invoking a method in both the initializer and the iterator sections, and changing the values of two variables in the iterator section:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/iteration-statements/ForStatement.cs" id="MultipleExpressions":::

All the sections of the `for` statement are optional. For example, the following code defines the infinite `for` loop:

:::code language="csharp" source="snippets/iteration-statements/ForStatement.cs" id="InfiniteLoop":::

## The `foreach` statement

The `foreach` statement executes a statement or a block of statements for each element in an instance of the type that implements the <xref:System.Collections.IEnumerable?displayProperty=nameWithType> or <xref:System.Collections.Generic.IEnumerable%601?displayProperty=nameWithType> interface, as the following example shows:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/iteration-statements/ForeachStatement.cs" id="WithIEnumerable":::

The `foreach` statement isn't limited to those types. You can use it with an instance of any type that satisfies the following conditions:

- A type has the public parameterless `GetEnumerator` method. The `GetEnumerator` method can be a type's [extension method](../../programming-guide/classes-and-structs/extension-methods.md).
- The return type of the `GetEnumerator` method has the public `Current` property and the public parameterless `MoveNext` method whose return type is `bool`.

The following example uses the `foreach` statement with an instance of the <xref:System.Span%601?displayProperty=nameWithType> type, which doesn't implement any interfaces:

:::code language="csharp" source="snippets/iteration-statements/ForeachStatement.cs" id="WithSpan" :::

If the enumerator's `Current` property returns a [reference return value](jump-statements.md#ref-returns) (`ref T` where `T` is the type of a collection element), you can declare an iteration variable with the `ref` or `ref readonly` modifier, as the following example shows:

:::code language="csharp" source="snippets/iteration-statements/ForeachStatement.cs" id="RefIterationVariable" :::

If the source collection of the `foreach` statement is empty, the body of the `foreach` statement isn't executed and skipped. If the `foreach` statement is applied to `null`, a <xref:System.NullReferenceException> is thrown.

### await foreach

You can use the `await foreach` statement to consume an asynchronous stream of data, that is, the collection type that implements the <xref:System.Collections.Generic.IAsyncEnumerable%601> interface. Each iteration of the loop may be suspended while the next element is retrieved asynchronously. The following example shows how to use the `await foreach` statement:

:::code language="csharp" source="snippets/iteration-statements/ForeachStatement.cs" id="AwaitForeach" :::

You can also use the `await foreach` statement with an instance of any type that satisfies the following conditions:

- A type has the public parameterless `GetAsyncEnumerator` method. That method can be a type's [extension method](../../programming-guide/classes-and-structs/extension-methods.md).
- The return type of the `GetAsyncEnumerator` method has the public `Current` property and the public parameterless `MoveNextAsync` method whose return type is [`Task<bool>`](xref:System.Threading.Tasks.Task%601), [`ValueTask<bool>`](xref:System.Threading.Tasks.ValueTask%601), or any other awaitable type whose awaiter's `GetResult` method returns a `bool` value.

By default, stream elements are processed in the captured context. If you want to disable capturing of the context, use the <xref:System.Threading.Tasks.TaskAsyncEnumerableExtensions.ConfigureAwait%2A?displayProperty=nameWithType> extension method. For more information about synchronization contexts and capturing the current context, see [Consuming the Task-based asynchronous pattern](../../../standard/asynchronous-programming-patterns/consuming-the-task-based-asynchronous-pattern.md). For more information about asynchronous streams, see the [Asynchronous streams tutorial](../../asynchronous-programming/generate-consume-asynchronous-stream.md).

### Type of an iteration variable

You can use the [`var` keyword](declarations.md#implicitly-typed-local-variables) to let the compiler infer the type of an iteration variable in the `foreach` statement, as the following code shows:

```csharp
foreach (var item in collection) { }
```

> [!NOTE]
> Type of `var` can be inferred by the compiler as a nullable reference type, depending on whether the [nullable aware context](../../language-reference/builtin-types/nullable-reference-types.md) is enabled and whether the type of an initialization expression is a reference type.
> For more information see [Implicitly-typed local variables](./declarations.md#implicitly-typed-local-variables).

You can also explicitly specify the type of an iteration variable, as the following code shows:

```csharp
IEnumerable<T> collection = new T[5];
foreach (V item in collection) { }
```

In the preceding form, type `T` of a collection element must be implicitly or explicitly convertible to type `V` of an iteration variable. If an explicit conversion from `T` to `V` fails at run time, the `foreach` statement throws an <xref:System.InvalidCastException>. For example, if `T` is a non-sealed class type, `V` can be any interface type, even the one that `T` doesn't implement. At run time, the type of a collection element may be the one that derives from `T` and actually implements `V`. If that's not the case, an <xref:System.InvalidCastException> is thrown.

## The `do` statement

The `do` statement executes a statement or a block of statements while a specified Boolean expression evaluates to `true`. Because that expression is evaluated after each execution of the loop, a `do` loop executes one or more times. The `do` loop differs from the [`while` loop](#the-while-statement), which executes zero or more times.

The following example shows the usage of the `do` statement:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/iteration-statements/DoStatement.cs" id="Example":::

## The `while` statement

The `while` statement executes a statement or a block of statements while a specified Boolean expression evaluates to `true`. Because that expression is evaluated before each execution of the loop, a `while` loop executes zero or more times. The `while` loop differs from the [`do` loop](#the-do-statement), which executes one or more times.

The following example shows the usage of the `while` statement:

:::code language="csharp" interactive="try-dotnet-method" source="snippets/iteration-statements/WhileStatement.cs" id="Example":::

## C# language specification

For more information, see the following sections of the [C# language specification](~/_csharpstandard/standard/README.md):

- [The `for` statement](~/_csharpstandard/standard/statements.md#1394-the-for-statement)
- [The `foreach` statement](~/_csharpstandard/standard/statements.md#1395-the-foreach-statement)
- [The `do` statement](~/_csharpstandard/standard/statements.md#1393-the-do-statement)
- [The `while` statement](~/_csharpstandard/standard/statements.md#1392-the-while-statement)

For more information about these features, see the following feature proposal notes:

- [Async streams](~/_csharplang/proposals/csharp-8.0/async-streams.md)
- [Extension `GetEnumerator` support for `foreach` loops](~/_csharplang/proposals/csharp-9.0/extension-getenumerator.md)

## See also

- [Declarations](./declarations.md)
- [Iterators](../../iterators.md)
