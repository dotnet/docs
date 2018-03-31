---
title: "Main() and command-line arguments (C# Programming Guide)"
ms.date: 08/02/2017
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
f1_keywords: 
  - "CS5001"
  - "main_CSharpKeyword"
  - "Main"
helpviewer_keywords: 
  - "Main method [C#]"
  - "C# language, command-line arguments"
  - "arguments [C#], command-line"
  - "command line [C#], arguments"
  - "command-line arguments [C#], Main method"
ms.assetid: 73a17231-cf96-44ea-aa8a-54807c6fb1f4
caps.latest.revision: 30
author: "BillWagner"
ms.author: "wiwagn"
---
# Main() and command-line arguments (C# Programming Guide)

The `Main` method is the entry point of a C# application. (Libraries and services do not require a `Main` method as an entry point.) When the application is started, the `Main` method is the first method that is invoked.

 There can only be one entry point in a C# program. If you have more than one class that has a `Main` method, you must compile your program with the **/main** compiler option to specify which `Main` method to use as the entry point. For more information, see [/main (C# Compiler Options)](../../../csharp/language-reference/compiler-options/main-compiler-option.md).

 [!code-csharp[csProgGuideMain#17](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/main-and-command-line-arguments_1.cs)]

## Overview

- The `Main` method is the entry point of an executable program; it is where the program control starts and ends.
- `Main` is declared inside a class or struct. `Main` must be [static](../../../csharp/language-reference/keywords/static.md) and it need not be [public](../../../csharp/language-reference/keywords/public.md). (In the earlier example, it receives the default access of [private](../../../csharp/language-reference/keywords/private.md).) The enclosing class or struct is not required to be static.
- `Main` can either have a `void`, `int`, or, starting with C# 7.1, `Task`, or `Task<int>` return type.
- If and only if `Main` returns a `Task` or `Task<int>`, the declaration of `Main` may include the [`async`](../../language-reference/keywords/async.md) modifier. Note that this specifically excludes an `async void Main` method.
- The `Main` method can be declared with or without a `string[]` parameter that contains command-line arguments. When using [!INCLUDE[vsprvs](~/includes/vsprvs-md.md)] to create Windows applications, you can add the parameter manually or else use the <xref:System.Environment> class to obtain the command-line arguments. Parameters are read as zero-indexed command-line arguments. Unlike C and C++, the name of the program is not treated as the first command-line argument.

The addition of `async` and `Task`, `Task<int>` return types simplifies program code when console applications need to start and `await` asynchronous operations in `Main`.

## C# language specification

[!INCLUDE[CSharplangspec](~/includes/csharplangspec-md.md)]

## See also
[Command-line Building With csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md)  
[C# Programming Guide](../../../csharp/programming-guide/index.md)  
[Methods](../../../csharp/programming-guide/classes-and-structs/methods.md)  
[Inside a C# Program](../../../csharp/programming-guide/inside-a-program/index.md)  
