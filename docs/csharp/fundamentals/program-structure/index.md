---
title: "General Structure of a Program"
description: Learn about the structure of a C# program by using a skeleton program that contains all the required elements for a program.
ms.date: 08/01/2024
helpviewer_keywords: 
  - "C# language, program structure"
ms.assetid: 5ae964a5-0ef0-40fe-88fb-6d1793371d0d
---
# General Structure of a C# Program

C# programs consist of one or more files. Each file contains zero or more namespaces. A namespace contains types such as classes, structs, interfaces, enumerations, and delegates, or other namespaces. The following example is the skeleton of a C# program that contains all of these elements.

:::code language="csharp" source="snippets/toplevel-structure/Program.cs":::

The preceding example uses [*top-level statements*](top-level-statements.md) for the program's entry point. Only one file can have top-level statements. The program's entry point is the first line of program text in that file. In this case, it's the `Console.WriteLine("Hello world!");`.
You can also create a static method named [`Main`](main-command-line.md) as the program's entry point, as shown in the following example:

:::code language="csharp" source="snippets/structure/Program.cs":::

In that case the program will start in the first line of `Main` method, which is `Console.WriteLine("Hello world!");`

## Expressions and statements

C# programs are built using *expressions* and *statements*. Expressions produce a value, and statements perform an action:

An *expression* is a combination of values, variables, operators, and method calls that evaluates to a single value. Expressions produce a result and can be used wherever a value is expected. The following examples are expressions:

- `42` (literal value)
- `x + y` (arithmetic operation)
- `Math.Max(a, b)` (method call)
- `condition ? trueValue : falseValue` (conditional expression)
- `new Person("John")` (object creation)

A *statement* is a complete instruction that performs an action. Statements don't return values; instead, they control program flow, declare variables, or perform operations. The following examples are statements:

- `int x = 42;` (declaration statement)
- `Console.WriteLine("Hello");` (expression statement - wraps a method call expression)
- `if (condition) { /* code */ }` (conditional statement)
- `return result;` (return statement)

The key distinction: expressions evaluate to values, while statements perform actions. Some constructs, like method calls, can be both. For example, `Math.Max(a, b)` is an expression when used in `int result = Math.Max(a, b);`, but becomes an expression statement when written alone as `Math.Max(a, b);`.

For detailed information about statements, see [Statements](../../programming-guide/statements-expressions-operators/statements.md). For information about expression-bodied members and other expression features, see [Expression-bodied members](../../programming-guide/statements-expressions-operators/expression-bodied-members.md).

## Related Sections

You learn about these program elements in the [types](../types/index.md) section of the fundamentals guide:

- [Classes](../types/classes.md)  
- [Structs](../../language-reference/builtin-types/struct.md)  
- [Namespaces](../types/namespaces.md)  
- [Interfaces](../types/interfaces.md)  
- [Enums](../../language-reference/builtin-types/enum.md)
- [Delegates](../../delegates-overview.md)
  
## C# Language Specification  

For more information, see [Basic concepts](~/_csharpstandard/standard/basic-concepts.md) in the [C# Language Specification](~/_csharpstandard/standard/README.md). The language specification is the definitive source for C# syntax and usage.
