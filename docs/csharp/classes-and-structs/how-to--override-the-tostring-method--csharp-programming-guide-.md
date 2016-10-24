---
title: "How to: Override the ToString Method (C# Programming Guide)"
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
  - "ToString method, overriding in C#"
  - "inheritance [C#], overriding OnPaint and ToString"
ms.assetid: 8016db69-1f19-420c-8e17-98e8bebb7749
caps.latest.revision: 21
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
# How to: Override the ToString Method (C# Programming Guide)
Every class or struct in C# implicitly inherits the <xref:System.Object> class. Therefore, every object in C# gets the <xref:System.Object.ToString*> method, which returns a string representation of that object. For example, all variables of type `int` have a `ToString` method, which enables them to return their contents as a string:  
  
 [!code[csProgGuideInheritance#37](../classes-and-structs/codesnippet/CSharp/how-to--override-the-tostring-method--csharp-programming-guide-_1.cs)]  
  
 When you create a custom class or struct, you should override the <xref:System.Object.ToString*> method in order to provide information about your type to client code.  
  
 For information about how to use format strings and other types of custom formatting with the `ToString` method, see [Formatting Types](../Topic/Formatting%20Types%20in%20the%20.NET%20Framework.md).  
  
> [!IMPORTANT]
>  When you decide what information to provide through this method, consider whether your class or struct will ever be used by untrusted code. Be careful to ensure that you do not provide any information that could be exploited by malicious code.  
  
### To override the ToString method in your class or struct  
  
1.  Declare a `ToString` method with the following modifiers and return type:  
  
    ```c#  
    public override string ToString(){}  
    ```  
  
2.  Implement the method so that it returns a string.  
  
     The following example returns the name of the class in addition to the data specific to a particular instance of the class.  
  
     [!code[csProgGuideInheritance#36](../classes-and-structs/codesnippet/CSharp/how-to--override-the-tostring-method--csharp-programming-guide-_2.cs)]  
  
     You can test the `ToString` method as shown in the following code example:  
  
     [!code[csProgGuideInheritance#38](../classes-and-structs/codesnippet/CSharp/how-to--override-the-tostring-method--csharp-programming-guide-_3.cs)]  
  
## See Also  
 <xref:System.IFormattable>   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Classes and Structs](../classes-and-structs/classes-and-structs--csharp-programming-guide-.md)   
 [Strings](../strings/strings--csharp-programming-guide-.md)   
 [string](../keywords/string--csharp-reference-.md)   
 [new](../keywords/new--csharp-reference-.md)   
 [override](../keywords/override--csharp-reference-.md)   
 [virtual](../keywords/virtual--csharp-reference-.md)   
 [Formatting Types](../Topic/Formatting%20Types%20in%20the%20.NET%20Framework.md)