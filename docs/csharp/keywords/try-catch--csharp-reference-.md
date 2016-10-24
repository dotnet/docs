---
title: "try-catch (C# Reference)"
ms.custom: ""
ms.date: "2015-07-20"
ms.prod: "visual-studio-dev14"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-csharp"
ms.tgt_pltfrm: ""
ms.topic: "article"
f1_keywords: 
  - "try"
  - "try_CSharpKeyword"
  - "catch"
  - "catch_CSharpKeyword"
dev_langs: 
  - "CSharp"
helpviewer_keywords: 
  - "catch keyword [C#]"
  - "try-catch statement [C#]"
ms.assetid: cb5503c7-bfa1-4610-8fc2-ddcd2e84c438
caps.latest.revision: 45
author: "BillWagner"
ms.author: "wiwagn"
manager: "wpickett"
translation.priority.ht: 
  - "de-de"
  - "es-es"
  - "fr-fr"
  - "it-it"
  - "ja-jp"
  - "ko-kr"
  - "ru-ru"
  - "zh-cn"
  - "zh-tw"
translation.priority.mt: 
  - "cs-cz"
  - "pl-pl"
  - "pt-br"
  - "tr-tr"
---
# try-catch (C# Reference)
The try-catch statement consists of a `try` block followed by one or more `catch` clauses, which specify handlers for different exceptions.  
  
## Remarks  
 When an exception is thrown, the common language runtime (CLR) looks for the `catch` statement that handles this exception. If the currently executing method does not contain such a `catch` block, the CLR looks at the method that called the current method, and so on up the call stack. If no `catch` block is found, then the CLR displays an unhandled exception message to the user and stops execution of the program.  
  
 The `try` block contains the guarded code that may cause the exception. The block is executed until an exception is thrown or it is completed successfully. For example, the following attempt to cast a `null` object raises the <xref:System.NullReferenceException> exception:  
  
```c#  
object o2 = null;  
try  
{  
    int i2 = (int)o2;   // Error  
}  
```  
  
 Although the `catch` clause can be used without arguments to catch any type of exception, this usage is not recommended. In general, you should only catch those exceptions that you know how to recover from. Therefore, you should always specify an object argument derived from <xref:System.Exception?displayProperty=fullName> For example:  
  
```c#  
catch (InvalidCastException e)   
{  
}  
```  
  
 It is possible to use more than one specific `catch` clause in the same try-catch statement. In this case, the order of the `catch` clauses is important because the `catch` clauses are examined in order. Catch the more specific exceptions before the less specific ones. The compiler produces an error if you order your catch blocks so that a later block can never be reached.  
  
 Using `catch` arguments is one way to filter for the exceptions you want to handle.  You can also use a predicate expression that further examines the exception to decide whether to handle it.  If the predicate expression returns false, then the search for a handler continues.  
  
```c#  
catch (ArgumentException e) when (e.ParamName == “…”)  
{  
}  
```  
  
 Exception filters are preferable to catching and rethrowing (explained below) because filters leave the stack unharmed.  If a later handler dumps the stack, you can see where the exception originally came from, rather than just the last place it was rethrown.  A common use of exception filter expressions is logging.  You can create a predicate function that always returns false that also outputs to a log, you can log exceptions as they go by without having to handle them and rethrow.  
  
 A [throw](../keywords/throw--csharp-reference-.md) statement can be used in a `catch` block to re-throw the exception that is caught by the `catch` statement. The following example extracts source information from an <xref:System.IO.IOException> exception, and then throws the exception to the parent method.  
  
```c#  
catch (FileNotFoundException e)  
{  
    // FileNotFoundExceptions are handled here.  
}  
catch (IOException e)  
{  
    // Extract some information from this exception, and then   
    // throw it to the parent method.  
    whenDo not initialize (e.Source != null)  
        Console.WriteLine("IOException source: {0}", e.Source);  
    throw;  
}  
```  
  
 You can catch one exception and throw a different exception. When you do this, specify the exception that you caught as the inner exception, as shown in the following example.  
  
```c#  
catch (InvalidCastException e)   
{  
    // Perform some action here, and then throw a new exception.  
    throw new YourCustomException("Put your error message here.", e);  
}  
```  
  
 You can also re-throw an exception when a specified condition is true, as shown in the following example.  
  
```c#  
  
catch (InvalidCastException e)  
{  
    if (e.Data == null)  
    {  
        throw;  
    }  
    else  
    {  
        // Take some action.  
    }  
 }  
```  
  
 From inside a `try` block, initialize only variables that are declared therein. Otherwise, an exception can occur before the execution of the block is completed. For example, in the following code example, the variable `n` is initialized inside the `try` block. An attempt to use this variable outside the `try` block in the `Write(n)` statement will generate a compiler error.  
  
```c#  
static void Main()   
{  
    int n;  
    try   
    {  
        // Do not initialize this variable here.  
        n = 123;  
    }  
    catch  
    {  
    }  
    // Error: Use of unassigned local variable 'n'.  
    Console.Write(n);  
}  
```  
  
 For more information about catch, see [try-catch-finally](../keywords/try-catch-finally--csharp-reference-.md).  
  
## Exceptions in Async Methods  
 An async method is marked  by an  [async](../keywords/async--csharp-reference-.md) modifier and usually contains one or more await expressions or statements. An await expression applies the [await](../keywords/await--csharp-reference-.md) operator to a <xref:System.Threading.Tasks.Task> or <xref:System.Threading.Tasks.Task`1>.  
  
 When control reaches an `await` in the async method, progress in the method is suspended until the awaited task completes. When the task  is complete, execution can resume in the method. For more information, see [Asynchronous Programming with Async and Await](../Topic/Asynchronous%20Programming%20with%20Async%20and%20Await%20\(C%23%20and%20Visual%20Basic\).md) and [Control Flow in Async Programs](../Topic/Control%20Flow%20in%20Async%20Programs%20\(C%23%20and%20Visual%20Basic\).md).  
  
 The completed task to which `await` is applied might be in a faulted state because of an unhandled exception in the method that returns the task. Awaiting the task throws an exception. A task can also end up in a canceled state if the asynchronous process that returns it is canceled. Awaiting a canceled task throws  an `OperationCanceledException`. For more information about how to cancel an asynchronous process, see [Fine-Tuning Your Async Application](../Topic/Fine-Tuning%20Your%20Async%20Application%20\(C%23%20and%20Visual%20Basic\).md).  
  
 To catch the exception, await the task in a `try` block, and catch the exception in the associated `catch` block. For an example, see the "Example" section.  
  
 A task can be in a faulted state because multiple exceptions occurred in the awaited async method. For example, the task might be the result of a call to <xref:System.Threading.Tasks.Task.WhenAll*?displayProperty=fullName>. When you await such a task, only one of the exceptions is caught, and you can't predict which exception will be caught. For an example, see the "Example" section.  
  
## Example  
 In the following example, the `try` block contains a call to the `ProcessString` method that may cause an exception. The `catch` clause contains the exception handler that just displays a message on the screen. When the `throw` statement is called from inside `MyMethod`, the system looks for the `catch` statement and displays the message `Exception caught`.  
  
 [!code[csrefKeywordsExceptions#2](../keywords/codesnippet/CSharp/try-catch--csharp-reference-_1.cs)]  
  
## Example  
 In the following example, two catch blocks are used, and the most specific exception, which comes first, is caught.  
  
 To catch the least specific exception, you can replace the throw statement in `ProcessString` with the following statement: `throw new Exception()`.  
  
 If you place the least-specific catch block first in the example, the following  error message appears: `A previous catch clause already catches all exceptions of this or a super type ('System.Exception')`.  
  
 [!code[csrefKeywordsExceptions#3](../keywords/codesnippet/CSharp/try-catch--csharp-reference-_2.cs)]  
  
## Example  
 The following example illustrates exception handling for async methods. To catch an exception that an async task throws, place the `await` expression in a `try` block, and catch the exception in a `catch` block.  
  
 Uncomment the `throw new Exception` line in the example to demonstrate exception handling. The task's `IsFaulted` property is set to `True`, the task's `Exception.InnerException` property is set to the exception, and the exception is caught in the `catch` block.  
  
 Uncomment the `throw new OperationCancelledException` line to demonstrate what happens when you cancelan asynchronous process. The task's `IsCanceled` property is set to `true`, and the exception is caught in the `catch` block. Under some conditions that don't apply to this example, the task's `IsFaulted` property is set to `true` and `IsCanceled` is set to `false`.  
  
 [!code[csAsyncExceptions#2](../keywords/codesnippet/CSharp/try-catch--csharp-reference-_3.cs)]  
  
## Example  
 The following example illustrates exception handling where multiple tasks can result in multiple exceptions. The `try` block awaits the task that's returned by a call to <xref:System.Threading.Tasks.Task.WhenAll*?displayProperty=fullName>. The task is complete when the three tasks to which WhenAll is applied are complete.  
  
 Each of the three tasks causes an exception. The `catch` block iterates through the exceptions, which are found in the `Exception.InnerExceptions` property of the task that was returned by <xref:System.Threading.Tasks.Task.WhenAll*?displayProperty=fullName>.  
  
 [!code[csAsyncExceptions#4](../keywords/codesnippet/CSharp/try-catch--csharp-reference-_4.cs)]  
  
## C# Language Specification  
 [!INCLUDE[CSharplangspec](../arrays/includes/csharplangspec_md.md)]  
  
## See Also  
 [C# Reference](../language-reference/csharp-reference.md)   
 [C# Programming Guide](../programming-guide/csharp-programming-guide.md)   
 [C# Keywords](../keywords/csharp-keywords.md)   
 [try, throw, and catch Statements (C++)](../Topic/try,%20throw,%20and%20catch%20Statements%20\(C++\).md)   
 [Exception Handling Statements](../keywords/exception-handling-statements--csharp-reference-.md)   
 [throw](../keywords/throw--csharp-reference-.md)   
 [try-finally](../keywords/try-finally--csharp-reference-.md)   
 [How to: Explicitly Throw Exceptions](../Topic/How%20to:%20Explicitly%20Throw%20Exceptions.md)