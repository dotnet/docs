---
title: "Exception Handling (C# Programming Guide)"
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
  - "exception handling [C#], about exception handling"
  - "exceptions [C#], handling"
ms.assetid: b4e4ecf2-b907-4e58-891f-2563762258e9
caps.latest.revision: 24
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
# Exception Handling (C# Programming Guide)
A [try](../keywords/try-catch--csharp-reference-.md) block is used by C# programmers to partition code that might be affected by an exception. Associated [catch](../keywords/try-catch--csharp-reference-.md) blocks are used to handle any resulting exceptions. A [finally](../keywords/try-finally--csharp-reference-.md) block contains code that is run regardless of whether or not an exception is thrown in the `try` block, such as releasing resources that are allocated in the `try` block. A `try` block requires one or more associated `catch` blocks, or a `finally` block, or both.  
  
 The following examples show a `try-catch` statement, a `try-finally` statement, and a `try-catch-finally` statement.  
  
 [!code[csProgGuideExceptions#6](../exceptions/codesnippet/CSharp/exception-handling--csharp-programming-guide-_1.cs)]  
  
 [!code[csProgGuideExceptions#7](../exceptions/codesnippet/CSharp/exception-handling--csharp-programming-guide-_2.cs)]  
  
 [!code[csProgGuideExceptions#8](../exceptions/codesnippet/CSharp/exception-handling--csharp-programming-guide-_3.cs)]  
  
 A `try` block without a `catch` or `finally` block causes a compiler error.  
  
## Catch Blocks  
 A `catch` block can specify the type of exception to catch. The type specification is called an *exception filter*. The exception type should be derived from <xref:System.Exception>. In general, do not specify <xref:System.Exception> as the exception filter unless either you know how to handle all exceptions that might be thrown in the `try` block, or you have included a [throw](../keywords/throw--csharp-reference-.md) statement at the end of your `catch` block.  
  
 Multiple `catch` blocks with different exception filters can be chained together. The `catch` blocks are evaluated from top to bottom in your code, but only one `catch` block is executed for each exception that is thrown. The first `catch` block that specifies the exact type or a base class of the thrown exception is executed. If no `catch` block specifies a matching exception filter, a `catch` block that does not have a filter is selected, if one is present in the statement. It is important to position `catch` blocks with the most specific (that is, the most derived) exception types first.  
  
 You should catch exceptions when the following conditions are true:  
  
-   You have a good understanding of why the exception might be thrown, and you can implement a specific recovery, such as prompting the user to enter a new file name when you catch a <xref:System.IO.FileNotFoundException> object.  
  
-   You can create and throw a new, more specific exception.  
  
     [!code[csProgGuideExceptions#9](../exceptions/codesnippet/CSharp/exception-handling--csharp-programming-guide-_4.cs)]  
  
-   You want to partially handle an exception before passing it on for additional handling. In the following example, a `catch` block is used to add an entry to an error log before re-throwing the exception.  
  
     [!code[csProgGuideExceptions#10](../exceptions/codesnippet/CSharp/exception-handling--csharp-programming-guide-_5.cs)]  
  
## Finally Blocks  
 A `finally` block enables you to clean up actions that are performed in a `try` block. If present, the `finally` block executes last, after the `try` block and any matched `catch` block. A `finally` block always runs, regardless of whether an exception is thrown or a `catch` block matching the exception type is found.  
  
 The `finally` block can be used to release resources such as file streams, database connections, and graphics handles without waiting for the garbage collector in the runtime to finalize the objects. See [using Statement](../keywords/using-statement--csharp-reference-.md) for more information.  
  
 In the following example, the `finally` block is used to close a file that is opened in the `try` block. Notice that the state of the file handle is checked before the file is closed. If the `try` block cannot open the file, the file handle still has the value `null` and the `finally` block does not try to close it. Alternatively, if the file is opened successfully in the `try` block, the `finally` block closes the open file.  
  
 [!code[csProgGuideExceptions#11](../exceptions/codesnippet/CSharp/exception-handling--csharp-programming-guide-_6.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [Exceptions and Exception Handling](../exceptions/exceptions-and-exception-handling--csharp-programming-guide-.md)   
 [try-catch](../keywords/try-catch--csharp-reference-.md)   
 [try-finally](../keywords/try-finally--csharp-reference-.md)   
 [try-catch-finally](../keywords/try-catch-finally--csharp-reference-.md)   
 [using Statement](../keywords/using-statement--csharp-reference-.md)