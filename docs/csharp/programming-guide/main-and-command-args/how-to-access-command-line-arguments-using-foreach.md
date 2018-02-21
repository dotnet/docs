---
title: "How to: Access Command-Line Arguments Using foreach (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "command-line arguments [C#]"
ms.assetid: 89c3e335-3f5b-4e24-8c5a-b8036561fe8a
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Access Command-Line Arguments Using foreach (C# Programming Guide)
Another approach to iterating over the array is to use the [foreach](../../../csharp/language-reference/keywords/foreach-in.md) statement as shown in this example. The `foreach` statement can be used to iterate over an array, a .NET Framework collection class, or any class or struct that implements the <xref:System.Collections.IEnumerable> interface.  
  
> [!NOTE]
>  When running an application in Visual Studio, you can specify command-line arguments in the [Debug Page, Project Designer](/visualstudio/ide/reference/debug-page-project-designer).  
  
## Example  
 This example demonstrates how to print out the command line arguments using `foreach`.  
  
 [!code-csharp[csProgGuideMain#10](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/how-to-access-command-line-arguments-using-foreach_1.cs)]  
  
 [!code-csharp[csProgGuideMain#11](../../../csharp/programming-guide/inside-a-program/codesnippet/CSharp/how-to-access-command-line-arguments-using-foreach_2.cs)]  
  
## See Also  
 <xref:System.Array>  
 <xref:System.Collections>  
 [Command-line Building With csc.exe](../../../csharp/language-reference/compiler-options/command-line-building-with-csc-exe.md)  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [foreach, in](../../../csharp/language-reference/keywords/foreach-in.md)  
 [Main() and Command-Line Arguments](../../../csharp/programming-guide/main-and-command-args/index.md)  
 [How to: Display Command Line Arguments](../../../csharp/programming-guide/main-and-command-args/how-to-display-command-line-arguments.md)  
 [Main() Return Values](../../../csharp/programming-guide/main-and-command-args/main-return-values.md)
