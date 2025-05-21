---
title: "General Structure of a Program"
description: Learn about the structure of a C# program by using a skeleton program that contains all the required elements for a program.
ms.date: 08/01/2024
helpviewer_keywords: 
  - "C# language, program structure"
ms.assetid: 5ae964a5-0ef0-40fe-88fb-6d1793371d0d
ms.topic: article
---
# General Structure of a C# Program

C# programs consist of one or more files. Each file contains zero or more namespaces. A namespace contains types such as classes, structs, interfaces, enumerations, and delegates, or other namespaces. The following example is the skeleton of a C# program that contains all of these elements.

:::code language="csharp" source="snippets/toplevel-structure/Program.cs":::

The preceding example uses [*top-level statements*](top-level-statements.md) for the program's entry point. Only one file can have top-level statements. The program's entry point is the first line of program text in that file. In this case, it's the `Console.WriteLine("Hello world!");`.
You can also create a static method named [`Main`](main-command-line.md) as the program's entry point, as shown in the following example:

:::code language="csharp" source="snippets/structure/Program.cs":::

In that case the program will start in the first line of `Main` method, which is `Console.WriteLine("Hello world!");`

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
