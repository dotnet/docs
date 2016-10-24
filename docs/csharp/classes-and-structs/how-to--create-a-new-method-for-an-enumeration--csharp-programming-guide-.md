---
title: "How to: Create a New Method for an Enumeration (C# Programming Guide)"
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
  - "enumerations [C#]"
  - "extension methods [C#], for enums"
  - "enum extensibility [C#]"
ms.assetid: 100106f9-1e54-462c-8ebe-3892fe23b6eb
caps.latest.revision: 7
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
# How to: Create a New Method for an Enumeration (C# Programming Guide)
You can use extension methods to add functionality specific to a particular enum type.  
  
## Example  
 In the following example, the `Grades` enumeration represents the possible letter grades that a student may receive in a class. An extension method named `Passing` is added to the `Grades` type so that each instance of that type now "knows" whether it represents a passing grade or not.  
  
 [!code[csProgGuideExtensionMethods#2](../classes-and-structs/codesnippet/CSharp/how-to--create-a-new-method-for-an-enumeration--csharp-programming-guide-_1.cs)]  
  
 Note that the `Extensions` class also contains a static variable that is updated dynamically and that the return value of the extension method reflects the current value of that variable. This demonstrates that, behind the scenes, extension methods are invoked directly on the static class in which they are defined.  
  
## Compiling the Code  
 To run this code, copy and paste it into a Visual C# console application project that has been created in [!INCLUDE[vs_current_short](../classes-and-structs/includes/vs_current_short_md.md)]. By default, this project targets version 3.5 of the [!INCLUDE[dnprdnshort](../classes-and-structs/includes/dnprdnshort_md.md)], and it has a reference to System.Core.dll and a `using` directive for System.Linq. If one or more of these requirements are missing from the project, you can add them manually. For more information, see [How to: Create a LINQ Project](../Topic/How%20to:%20Create%20a%20LINQ%20Project.md).  
  
## See Also  
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Extension Methods](../classes-and-structs/extension-methods--csharp-programming-guide-.md)