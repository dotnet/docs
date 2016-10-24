---
title: "using Statement (C# Reference)"
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
  - "using statement [C#]"
ms.assetid: afc355e6-f0b9-4240-94dd-0d93f17d9fc3
caps.latest.revision: 31
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
# using Statement (C# Reference)
Provides a convenient syntax that ensures the correct use of <xref:System.IDisposable> objects.  
  
## Example  
 The following example shows how to use the using statement.  
  
 [!code[csrefKeywordsNamespace#4](../keywords/codesnippet/CSharp/using-statement--csharp-reference-_1.cs)]  
  
## Remarks  
 <xref:System.IO.File> and <xref:System.Drawing.Font> are examples of managed types that access unmanaged resources (in this case file handles and device contexts). There are many other kinds of unmanaged resources and class library types that encapsulate them. All such types must implement the <xref:System.IDisposable> interface.  
  
 As a rule, when you use an `IDisposable` object, you should declare and instantiate it in a `using` statement. The `using` statement calls the <xref:System.IDisposable.Dispose*> method on the object in the correct way, and (when you use it as shown earlier) it also causes the object itself to go out of scope as soon as <xref:System.IDisposable.Dispose*> is called. Within the `using` block, the object is read-only and cannot be modified or reassigned.  
  
 The `using` statement ensures that <xref:System.IDisposable.Dispose*> is called even if an exception occurs while you are calling methods on the object. You can achieve the same result by putting the object inside a try block and then calling <xref:System.IDisposable.Dispose*> in a finally block; in fact, this is how the `using` statement is translated by the compiler. The code example earlier expands to the following code at compile time (note the extra curly braces to create the limited scope for the object):  
  
 [!code[csrefKeywordsNamespace#5](../keywords/codesnippet/CSharp/using-statement--csharp-reference-_2.cs)]  
  
 Multiple instances of a type can be declared in a `using` statement, as shown in the following example.  
  
 [!code[csrefKeywordsNamespace#6](../keywords/codesnippet/CSharp/using-statement--csharp-reference-_3.cs)]  
  
 You can instantiate the resource object and then pass the variable to the `using` statement, but this is not a best practice. In this case, the object remains in scope after control leaves the `using` block even though it will probably no longer have access to its unmanaged resources. In other words, it will no longer be fully initialized. If you try to use the object outside the `using` block, you risk causing an exception to be thrown. For this reason, it is generally better to instantiate the object in the `using` statement and limit its scope to the `using` block.  
  
 [!code[csrefKeywordsNamespace#7](../keywords/codesnippet/CSharp/using-statement--csharp-reference-_4.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [using Directive](../keywords/using-directive--csharp-reference-.md)   
 [Garbage Collection](../Topic/Garbage%20Collection.md)   
 [Implementing a Dispose Method](../Topic/Implementing%20a%20Dispose%20Method.md)