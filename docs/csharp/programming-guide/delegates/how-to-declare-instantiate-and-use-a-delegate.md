---
title: "How to declare, instantiate, and use a delegate"
description: Learn how to declare, instantiate, and use a delegate. This article provides several examples of declaring, instantiating, and invoking delegates.
ms.topic: how-to
ms.date: 12/20/2024
helpviewer_keywords: 
  - "delegates [C#], declaring and instantiating"
---
# How to declare, instantiate, and use a Delegate (C# Programming Guide)

You can declare delegates using any of the following methods:

- Declare a delegate type and declare a method with a matching signature:

  :::code language="csharp" source="./snippets/HowToDeclareAndUse.cs" id="DeclareNamedDelegate":::

  :::code language="csharp" source="./snippets/HowToDeclareAndUse.cs" id="CreateNamedInstance":::

- Assign a method group to a delegate type:

  :::code language="csharp" source="./snippets/HowToDeclareAndUse.cs" id="MethodGroup":::

- Declare an anonymous method

  :::code language="csharp" source="./snippets/HowToDeclareAndUse.cs" id="AnonymousMethod":::

- Use a lambda expression:

  :::code language="csharp" source="./snippets/HowToDeclareAndUse.cs" id="LambdaExpression":::

For more information, see [Lambda Expressions](../../language-reference/operators/lambda-expressions.md).

The following example illustrates declaring, instantiating, and using a delegate. The `BookDB` class encapsulates a bookstore database that maintains a database of books. It exposes a method, `ProcessPaperbackBooks`, which finds all paperback books in the database and calls a delegate for each one. The `delegate` type is named `ProcessBookCallback`. The `Test` class uses this class to print the titles and average price of the paperback books.

The use of delegates promotes good separation of functionality between the bookstore database and the client code. The client code has no knowledge of how the books are stored or how the bookstore code finds paperback books. The bookstore code has no knowledge of what processing is performed on the paperback books after it finds them.

:::code language="csharp" source="./snippets/BookStore.cs":::

## See also

- [Events](../events/index.md)
- [Delegates](./index.md)
