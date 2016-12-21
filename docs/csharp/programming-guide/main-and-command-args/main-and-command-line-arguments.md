---
title: "Main() and Command-Line Arguments (C# Programming Guide) | Microsoft Docs"

ms.date: "2015-07-20"
ms.prod: .net


ms.technology: 
  - "devlang-csharp"

ms.topic: "article"
f1_keywords: 
  - "CS5001"
  - "main_CSharpKeyword"
  - "Main"
dev_langs: 
  - "CSharp"
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

translation.priority.ht: 
  - "cs-cz"
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "pl-pl"
  - "pt-br"
  - "ru-ru"
  - "tr-tr"
  - "zh-cn"
  - "zh-tw"
---
# Main() and Command-Line Arguments (C# Programming Guide)
The `Main` method is the entry point of a C# console application or windows application. (Libraries and services do not require a `Main` method as an entry point.). When the application is started, the `Main` method is the first method that is invoked.  
  
 There can only be one entry point in a C# program. If you have more than one class that has a `Main` method, you must compile your program with the **/main** compiler option to specify which `Main` method to use as the entry point. For more information, see [/main (C# Compiler Options)](../../../csharp/language-reference/compiler-options/main-compiler-option.md).  
  
 [!code-cs[csProgGuideMain#17](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/main-and-command-line-arguments_1.cs)]  
  
## Overview  
  
-   The `Main` method is the entry point of an .exe program; it is where the program control starts and ends.  
  
-   `Main` is declared inside a class or struct. `Main` must be [static](../../../csharp/language-reference/keywords/static.md) and it should not be [public](../../../csharp/language-reference/keywords/public.md). (In the earlier example, it receives the default access of [private](../../../csharp/language-reference/keywords/private.md).) The enclosing class or struct is not required to be static.  
  
-   `Main` can either have a `void` or `int` return type.  
  
-   The `Main` method can be declared with or without a `string[]` parameter that contains command-line arguments. When using [!INCLUDE[vsprvs](../../../csharp/includes/vsprvs_md.md)] to create Windows Forms applications, you can add the parameter manually or else use the <xref:System.Environment> class to obtain the command-line arguments. Parameters are read as zero-indexed command-line arguments. Unlike C and C++, the name of the program is not treated as the first command-line argument.  
  
## In This Section  
  
-   [Command-Line Arguments](../../../csharp/programming-guide/main-and-command-args/command-line-arguments.md)  
  
-   [How to: Display Command Line Arguments](../../../csharp/programming-guide/main-and-command-args/how-to-display-command-line-arguments.md)  
  
-   [How to: Access Command-Line Arguments Using foreach](../../../csharp/programming-guide/main-and-command-args/how-to-access-command-line-arguments-using-foreach.md)  
  
-   [Main() Return Values](../../../csharp/programming-guide/main-and-command-args/main-return-values.md)  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../../../csharp/language-reference/keywords/includes/csharplangspec_md.md)]  
  
## See Also  
 [Command-line Building With csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md)   
 [C# Programming Guide](../../../csharp/programming-guide/index.md)   
 [Methods](../../../csharp/programming-guide/classes-and-structs/methods.md)   
 [Inside a C# Program](../../../csharp/programming-guide/inside-a-program/index.md)   
 [\<paveover>C# Sample Applications](http://msdn.microsoft.com/en-us/9a9d7aaa-51d3-4224-b564-95409b0f3e15)