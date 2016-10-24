---
title: "How to: Display Command Line Arguments (C# Programming Guide)"
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
  - "command-line arguments [C#], displaying"
ms.assetid: b8479f2d-9e05-4d38-82da-2e61246e5437
caps.latest.revision: 19
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
# How to: Display Command Line Arguments (C# Programming Guide)
Arguments provided to an executable on the command-line are accessible through an optional parameter to `Main`. The arguments are provided in the form of an array of strings. Each element of the array contains one argument. White-space between arguments is removed. For example, consider these command-line invocations of a fictitious executable:  
  
|Input on Command-line|Array of strings passed to Main|  
|----------------------------|-------------------------------------|  
|**executable.exe a b c**|"a"<br /><br /> "b"<br /><br /> "c"|  
|**executable.exe one two**|"one"<br /><br /> "two"|  
|**executable.exe "one two" three**|"one two"<br /><br /> "three"|  
  
> [!NOTE]
>  When you are running an application in Visual Studio, you can specify command-line arguments in the [Debug Page, Project Designer](../Topic/Debug%20Page,%20Project%20Designer.md).  
  
## Example  
 This example displays the command line arguments passed to a command-line application. The output shown is for the first entry in the table above.  
  
 [!code[csProgGuideMain#9](../inside-a-program/codesnippet/CSharp/how-to--display-command-line-arguments--csharp-programming-guide-_1.cs)]  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Command-line Building With csc.exe](../compiler-options/command-line-building-with-csc.exe.md)   
 [Main() and Command-Line Arguments](../main-and-command-args/main---and-command-line-arguments--csharp-programming-guide-.md)   
 [How to: Access Command-Line Arguments Using foreach](../main-and-command-args/how-to--access-command-line-arguments-using-foreach--csharp-programming-guide-.md)   
 [Main() Return Values](../main-and-command-args/main---return-values--csharp-programming-guide-.md)