---
title: "How to: Create a New Method for an Enumeration (C# Programming Guide)"
ms.date: 07/20/2015
ms.prod: .net
ms.technology: 
  - "devlang-csharp"
ms.topic: "article"
helpviewer_keywords: 
  - "enumerations [C#]"
  - "extension methods [C#], for enums"
  - "enum extensibility [C#]"
ms.assetid: 100106f9-1e54-462c-8ebe-3892fe23b6eb
caps.latest.revision: 7
author: "BillWagner"
ms.author: "wiwagn"
---
# How to: Create a New Method for an Enumeration (C# Programming Guide)
You can use extension methods to add functionality specific to a particular enum type.  
  
## Example  
 In the following example, the `Grades` enumeration represents the possible letter grades that a student may receive in a class. An extension method named `Passing` is added to the `Grades` type so that each instance of that type now "knows" whether it represents a passing grade or not.  
  
 [!code-csharp[csProgGuideExtensionMethods#2](../../../csharp/programming-guide/classes-and-structs/codesnippet/CSharp/how-to-create-a-new-method-for-an-enumeration_1.cs)]  
  
 Note that the `Extensions` class also contains a static variable that is updated dynamically and that the return value of the extension method reflects the current value of that variable. This demonstrates that, behind the scenes, extension methods are invoked directly on the static class in which they are defined.  
  
## Compiling the Code  
 To run this code, copy and paste it into a Visual C# console application project that has been created in [!INCLUDE[vs_current_short](~/includes/vs-current-short-md.md)]. By default, this project targets version 3.5 of the [!INCLUDE[dnprdnshort](~/includes/dnprdnshort-md.md)], and it has a reference to System.Core.dll and a `using` directive for System.Linq. If one or more of these requirements are missing from the project, you can add them manually.  
  
## See Also  
 [C# Programming Guide](../../../csharp/programming-guide/index.md)  
 [Extension Methods](../../../csharp/programming-guide/classes-and-structs/extension-methods.md)
