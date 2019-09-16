---
title: "yield contextual keyword - C# Reference"
ms.custom: seodec18
ms.date: 07/20/2015
f1_keywords: 
  - "yield"
  - "yield_CSharpKeyword"
helpviewer_keywords: 
  - "yield keyword [C#]"
ms.assetid: 1089194f-9e53-46a2-8642-53ccbe9d414d
---
# yield (C# Reference)

When you use the `yield` [contextual keyword](index.md#contextual-keywords) in a statement, you indicate that the method, operator, or `get` accessor in which it appears is an iterator. Using `yield` to define an iterator removes the need for an explicit extra class (the class that holds the state for an enumeration, see <xref:System.Collections.Generic.IEnumerator%601> for an example) when you implement the <xref:System.Collections.IEnumerable> and <xref:System.Collections.IEnumerator> pattern for a custom collection type.

The following example shows the two forms of the `yield` statement.

```csharp
yield return <expression>;
yield break;
```

## Remarks

You use a `yield return` statement to return each element one at a time.

The sequence returned from an iterator method can be consumed by using a [foreach](foreach-in.md) statement or LINQ query. Each iteration of the `foreach` loop calls the iterator method. When a `yield return` statement is reached in the iterator method, `expression` is returned, and the current location in code is retained. Execution is restarted from that location the next time that the iterator function is called.

You can use a `yield break` statement to end the iteration.

For more information about iterators, see [Iterators](../../iterators.md).

## Iterator methods and get accessors

The declaration of an iterator must meet the following requirements:

- The return type must be <xref:System.Collections.IEnumerable>, <xref:System.Collections.Generic.IEnumerable%601>, <xref:System.Collections.IEnumerator>, or <xref:System.Collections.Generic.IEnumerator%601>.

- The declaration can't have any [in](in-parameter-modifier.md) [ref](ref.md) or [out](out-parameter-modifier.md) parameters.

The `yield` type of an iterator that returns <xref:System.Collections.IEnumerable> or <xref:System.Collections.IEnumerator> is `object`.  If the iterator returns <xref:System.Collections.Generic.IEnumerable%601> or <xref:System.Collections.Generic.IEnumerator%601>, there must be an implicit conversion from the type of the expression in the `yield return` statement to the generic type parameter .

You can't include a `yield return` or `yield break` statement in:

- [Lambda expressions](../../programming-guide/statements-expressions-operators/lambda-expressions.md) and [anonymous methods](../operators/delegate-operator.md).

- Methods that contain unsafe blocks. For more information, see [unsafe](unsafe.md).

## Exception handling

A `yield return` statement can't be located in a try-catch block. A `yield return` statement can be located in the try block of a try-finally statement.

A `yield break` statement can be located in a try block or a catch block but not a finally block.

If the `foreach` body (outside of the iterator method) throws an exception, a `finally` block in the iterator method is executed.

## Technical implementation

The following code returns an `IEnumerable<string>` from an iterator method and then iterates through its elements.

```csharp
IEnumerable<string> elements = MyIteratorMethod();
foreach (string element in elements)
{
   ...
}
```

The call to `MyIteratorMethod` doesn't execute the body of the method. Instead the call returns an `IEnumerable<string>` into the `elements` variable.

On an iteration of the `foreach` loop, the <xref:System.Collections.IEnumerator.MoveNext%2A> method is called for `elements`. This call executes the body of `MyIteratorMethod` until the next `yield return` statement is reached. The expression returned by the `yield return` statement determines not only the value of the `element` variable for consumption by the loop body but also the <xref:System.Collections.Generic.IEnumerator%601.Current%2A> property of `elements`, which is an `IEnumerable<string>`.

On each subsequent iteration of the `foreach` loop, the execution of the iterator body continues from where it left off, again stopping when it reaches a `yield return` statement. The `foreach` loop completes when the end of the iterator method or a `yield break` statement is reached.

## Example

The following example has a `yield return` statement that's inside a `for` loop. Each iteration of the `foreach` statement body in the `Main` method creates a call to the `Power` iterator function. Each call to the iterator function proceeds to the next execution of the `yield return` statement, which occurs during the next iteration of the `for` loop.

The return type of the iterator method is <xref:System.Collections.IEnumerable>, which is an iterator interface type. When the iterator method is called, it returns an enumerable object that contains the powers of a number.

[!code-csharp[csrefKeywordsContextual#5](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsContextual/CS/csrefKeywordsContextual.cs#5)]

## Example

The following example demonstrates a `get` accessor that is an iterator. In the example, each `yield return` statement returns an instance of a user-defined class.

[!code-csharp[csrefKeywordsContextual#21](~/samples/snippets/csharp/VS_Snippets_VBCSharp/csrefKeywordsContextual/CS/csrefKeywordsContextual.cs#21)]

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also

- [C# Reference](../../language-reference/index.md)
- [C# Programming Guide](../../programming-guide/index.md)
- [foreach, in](foreach-in.md)
- [Iterators](../../iterators.md)
