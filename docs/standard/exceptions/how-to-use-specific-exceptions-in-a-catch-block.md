---
description: "Learn more about: How to use specific exceptions in a catch block"
title: "How to: Use Specific Exceptions in a Catch Block"
ms.date: "03/30/2017"
dev_langs: 
  - "csharp"
  - "vb"
  - "cpp"
helpviewer_keywords: 
  - "exceptions, try/catch blocks"
  - "try/catch blocks"
  - "catch blocks"
ms.assetid: 12af9ff3-8587-4f31-90cf-6c2244e0fdae
---
# How to use specific exceptions in a catch block

In general, it's good programming practice to catch a specific type of exception rather than use a basic `catch` statement.

When an exception occurs, it is passed up the stack and each catch block is given the opportunity to handle it. The order of catch statements is important. Put catch blocks targeted to specific exceptions before a general exception catch block or the compiler might issue an error. The proper catch block is determined by matching the type of the exception to the name of the exception specified in the catch block. If there is no specific catch block, the exception is caught by a general catch block, if one exists.

The following code example uses a `try`/`catch` block to catch an <xref:System.InvalidCastException>. The sample creates a class called `Employee` with a single property, employee level (`Emlevel`). A method, `PromoteEmployee`, takes an object and increments the employee level. An <xref:System.InvalidCastException> occurs when a <xref:System.DateTime> instance is passed to the `PromoteEmployee` method.

:::code language="cpp" source="./snippets/how-to-use-specific-exceptions-in-a-catch-block/cpp/catchexception.cpp" id="Snippet2":::
:::code language="csharp" source="./snippets/how-to-use-specific-exceptions-in-a-catch-block/csharp/catchexception.cs" id="Snippet2":::
:::code language="vb" source="./snippets/how-to-use-specific-exceptions-in-a-catch-block/vb/catchexception.vb" id="Snippet2":::

## See also

- [Exceptions](index.md)
