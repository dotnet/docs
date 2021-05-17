---
title: "General Structure of a C# Program"
description: Learn about the structure of a C# program by using a skeleton program that contains all the required elements for a program.
ms.date: 05/14/2021
helpviewer_keywords: 
  - "C# language, program structure"
ms.assetid: 5ae964a5-0ef0-40fe-88fb-6d1793371d0d
---
# General Structure of a C# Program

C# programs consist of one or more files. Each file contains zero or more namespaces. A namespace contains types such as classes, structs, interfaces, enumerations, and delegates, or other namespaces. The following example is the skeleton of a C# program that contains all of these elements.

:::code language="csharp" source="snippets/toplevel-structure/Program.cs":::

The preceding example uses *top-level statements* for the program's entry point. This feature was added in C# 9. Prior to C# 9, the entry point was a static method named `Main`, as shown in the following example:

:::code language="csharp" source="snippets/structure/Program.cs":::

## Related Sections

You learn about these program elements in the [types](../types/index.md) section of the fundamentals guide:

- [Classes](../types/classes.md)  
- [Structs](../../language-reference/builtin-types/struct.md)  
- [Namespaces](../types/namespaces.md)  
- [Interfaces](../types/interfaces.md)  
- [Enums](../../language-reference/builtin-types/enum.md)
- [Delegates](../../delegates-overview.md)
  
## C# Language Specification  

For more information, see [Basic concepts](~/_csharplang/spec/basic-concepts.md) in the [C# Language Specification](/dotnet/csharp/language-reference/language-specification/introduction). The language specification is the definitive source for C# syntax and usage.
