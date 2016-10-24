---
title: "How to: Access Command-Line Arguments Using foreach (C# Programming Guide)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "command-line arguments [C#]"
ms.assetid: 89c3e335-3f5b-4e24-8c5a-b8036561fe8a
caps.latest.revision: 15
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
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
# How to: Access Command-Line Arguments Using foreach (C# Programming Guide)
Another approach to iterating over the array is to use the [foreach](../keywords/foreach--in--csharp-reference-.md) statement as shown in this example. The `foreach` statement can be used to iterate over an array, a .NET Framework collection class, or any class or struct that implements the <xref:System.Collections.IEnumerable> interface.  
  
> [!NOTE]
>  When running an application in Visual Studio, you can specify command-line arguments in the [Debug Page, Project Designer](../Topic/Debug%20Page,%20Project%20Designer.md).  
  
## Example  
 This example demonstrates how to print out the command line arguments using `foreach`.  
  
 [!code[csProgGuideMain#10](../inside-a-program/codesnippet/CSharp/how-to--access-command-line-arguments-using-foreach--csharp-programming-guide-_1.cs)]  
  
 [!code[csProgGuideMain#11](../inside-a-program/codesnippet/CSharp/how-to--access-command-line-arguments-using-foreach--csharp-programming-guide-_2.cs)]  
  
## See Also  
 <xref:System.Array>   
 <xref:System.Collections>   
 [Command-line Building With csc.exe](../compiler-options/command-line-building-with-csc.exe.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [foreach, in](../keywords/foreach--in--csharp-reference-.md)   
 [Main() and Command-Line Arguments](../main-and-command-args/main---and-command-line-arguments--csharp-programming-guide-.md)   
 [How to: Display Command Line Arguments](../main-and-command-args/how-to--display-command-line-arguments--csharp-programming-guide-.md)   
 [Main() Return Values](../main-and-command-args/main---return-values--csharp-programming-guide-.md)