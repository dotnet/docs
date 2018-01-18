---
title: "Try...Catch...Finally Statement (Visual Basic)"
ms.date: 07/20/2015
ms.prod: .net
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "devlang-visual-basic"
ms.topic: "article"
f1_keywords: 
  - "vb.Try...Catch...Finally"
  - "vb.when"
  - "vb.Finally"
  - "vb.Catch"
  - "vb.Try"
helpviewer_keywords: 
  - "Try...Catch...Finally statements"
  - "Try statement [Visual Basic]"
  - "try-catch exception handling, Try...Catch...Finally statements"
  - "error handling, while running code"
  - "Try statement [Visual Basic], Try...Catch...Finally"
  - "Finally keyword [Visual Basic], Try...Catch...Finally"
  - "Catch statement [Visual Basic]"
  - "When keyword [Visual Basic]"
  - "Visual Basic code, handling errors while running"
  - "structured exception handling, Try...Catch...Finally statements"
ms.assetid: d6488026-ccb3-42b8-a810-0d97b9d6472b
caps.latest.revision: 69
author: dotnet-bot
ms.author: dotnetcontent
---
# Try...Catch...Finally Statement (Visual Basic)
Provides a way to handle some or all possible errors that may occur in a given block of code, while still running code.  
  
## Syntax  
  
```  
Try  
    [ tryStatements ]  
    [ Exit Try ]  
[ Catch [ exception [ As type ] ] [ When expression ]  
    [ catchStatements ]  
    [ Exit Try ] ]  
[ Catch ... ]  
[ Finally  
    [ finallyStatements ] ]  
End Try  
```  
  
## Parts  
  
|Term|Definition|  
|---|---|  
|`tryStatements`|Optional. Statement(s) where an error can occur. Can be a compound statement.|  
|`Catch`|Optional. Multiple `Catch` blocks permitted. If an exception occurs when processing the `Try` block, each `Catch` statement is examined in textual order to determine whether it handles the exception, with `exception` representing the exception that has been thrown.|  
|`exception`|Optional. Any variable name. The initial value of `exception` is the value of the thrown error. Used with `Catch` to specify the error caught. If omitted, the `Catch` statement catches any exception.|  
|`type`|Optional. Specifies the type of class filter. If the value of `exception` is of the type specified by `type` or of a derived type, the identifier becomes bound to the exception object.|  
|`When`|Optional. A `Catch` statement with a `When` clause catches exceptions only when `expression` evaluates to `True`. A `When` clause is applied only after checking the type of the exception, and `expression` may refer to the identifier representing the exception.|  
|`expression`|Optional. Must be implicitly convertible to `Boolean`. Any expression that describes a generic filter. Typically used to filter by error number. Used with `When` keyword to specify circumstances under which the error is caught.|  
|`catchStatements`|Optional. Statement(s) to handle errors that occur in the associated `Try` block. Can be a compound statement.|  
|`Exit Try`|Optional. Keyword that breaks out of the `Try...Catch...Finally` structure. Execution resumes with the code immediately following the `End Try` statement. The `Finally` statement will still be executed. Not allowed in `Finally` blocks.|  
|`Finally`|Optional. A `Finally` block is always executed when execution leaves any part of the `Try...Catch` statement.|  
|`finallyStatements`|Optional. Statement(s) that are executed after all other error processing has occurred.|  
|`End Try`|Terminates the `Try...Catch...Finally` structure.|  
  
## Remarks  
 If you expect that a particular exception might occur during a particular section of code, put the code in a `Try` block and use a `Catch` block to retain control and handle the exception if it occurs.  
  
 A `Try…Catch` statement consists of a `Try` block followed by one or more `Catch` clauses, which specify handlers for various exceptions. When an exception is thrown in a `Try` block, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] looks for the `Catch` statement that handles the exception. If a matching `Catch` statement is not found, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] examines the method that called the current method, and so on up the call stack. If no `Catch` block is found, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] displays an unhandled exception message to the user and stops execution of the program.  
  
 You can use more than one `Catch` statement in a `Try…Catch` statement. If you do this, the order of the `Catch` clauses is significant because they are examined in order. Catch the more specific exceptions before the less specific ones.  
  
 The following `Catch` statement conditions are the least specific, and will catch all exceptions that derive from the <xref:System.Exception> class. You should ordinarily use one of these variations as the last `Catch` block in the `Try...Catch...Finally` structure, after catching all the specific exceptions you expect. Control flow can never reach a `Catch` block that follows either of these variations.  
  
-   The `type` is `Exception`, for example: `Catch ex As Exception`  
  
-   The statement has no `exception` variable, for example: `Catch`  
  
 When a `Try…Catch…Finally` statement is nested in another `Try` block, [!INCLUDE[vbprvb](~/includes/vbprvb-md.md)] first examines each `Catch` statement in the innermost `Try` block. If no matching `Catch` statement is found, the search proceeds to the `Catch` statements of the outer `Try…Catch…Finally` block.  
  
 Local variables from a `Try` block are not available in a `Catch` block because they are separate blocks. If you want to use a variable in more than one block, declare the variable outside the `Try...Catch...Finally` structure.  
  
> [!TIP]
>  The `Try…Catch…Finally` statement is available as an IntelliSense code snippet. In the Code Snippets Manager, expand **Code Patterns - If, For Each, Try Catch, Property, etc**, and then **Error Handling (Exceptions)**. For more information, see [Code Snippets](/visualstudio/ide/code-snippets).  
  
## Finally Block  
 If you have one or more statements that must run before you exit the `Try` structure, use a `Finally` block. Control passes to the `Finally` block just before it passes out of the `Try…Catch` structure. This is true even if an exception occurs anywhere inside the `Try` structure.  
  
 A `Finally` block is useful for running any code that must execute even if there is an exception. Control is passed to the `Finally` block regardless of how the `Try...Catch` block exits.  
  
 The code in a `Finally` block runs even if your code encounters a `Return` statement in a `Try` or `Catch` block. Control does not pass from a `Try` or `Catch` block to the corresponding `Finally` block in the following cases:  
  
-   An [End Statement](../../../visual-basic/language-reference/statements/end-statement.md) is encountered in the `Try` or `Catch` block.  
  
-   A <xref:System.StackOverflowException> is thrown in the `Try` or `Catch` block.  
  
 It is not valid to explicitly transfer execution into a `Finally` block. Transferring execution out of a `Finally` block is not valid, except through an exception.  
  
 If a `Try` statement does not contain at least one `Catch` block, it must contain a `Finally` block.  
  
> [!TIP]
>  If you do not have to catch specific exceptions, the `Using` statement behaves like a `Try…Finally` block, and guarantees disposal of the resources, regardless of how you exit the block. This is true even with an unhandled exception. For more information, see [Using Statement](../../../visual-basic/language-reference/statements/using-statement.md).  
  
## Exception Argument  
 The `Catch` block `exception` argument is an instance of the <xref:System.Exception> class or a class that derives from the `Exception` class. The `Exception` class instance corresponds to the error that occurred in the `Try` block.  
  
 The properties of the `Exception` object help to identify the cause and location of an exception. For example, the <xref:System.Exception.StackTrace%2A> property lists the called methods that led to the exception, helping you find where the error occurred in the code. <xref:System.Exception.Message%2A> returns a message that describes the exception. <xref:System.Exception.HelpLink%2A> returns a link to an associated Help file. <xref:System.Exception.InnerException%2A> returns the `Exception` object that caused the current exception, or it returns `Nothing` if there is no original `Exception`.  
  
## Considerations When Using a Try…Catch Statement  
 Use a `Try…Catch` statement only to signal the occurrence of unusual or unanticipated program events. Reasons for this include the following:  
  
-   Catching exceptions at runtime creates additional overhead, and is likely to be slower than pre-checking to avoid exceptions.  
  
-   If a `Catch` block is not handled correctly, the exception might not be reported correctly to users.  
  
-   Exception handling makes a program more complex.  
  
 You do not always need a `Try…Catch` statement to check for a condition that is likely to occur. The following example checks whether a file exists before trying to open it. This reduces the need for catching an exception thrown by the <xref:System.IO.File.OpenText%2A> method.  
  
 [!code-vb[VbVbalrStatements#94](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/try-catch-finally-statement_1.vb)]  
  
 Ensure that code in `Catch` blocks can properly report exceptions to users, whether through thread-safe logging or appropriate messages. Otherwise, exceptions might remain unknown.  
  
## Async Methods  
 If you mark a method with the [Async](../../../visual-basic/language-reference/modifiers/async.md) modifier, you can use the [Await](../../../visual-basic/language-reference/operators/await-operator.md) operator in the method. A statement with the `Await` operator suspends execution of the method until the awaited task completes. The task represents ongoing work. When the task that's associated with the `Await` operator finishes, execution resumes in the same method. For more information, see [Control Flow in Async Programs](../../../visual-basic/programming-guide/concepts/async/control-flow-in-async-programs.md).  
  
 A task returned by an Async method may end in a faulted state, indicating that it completed due to an unhandled exception. A task may also end in a canceled state, which results in an `OperationCanceledException` being thrown out of the await expression. To catch either type of exception, place the `Await` expression that's associated with the task in a `Try` block, and catch the exception in the `Catch` block. An example is provided later in this topic.  
  
 A task can be in a faulted state because multiple exceptions were responsible for its faulting. For example, the task might be the result of a call to <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType>. When you await such a task, the caught exception is only one of the exceptions, and you can't predict which exception will be caught. An example is provided later in this topic.  
  
 An `Await` expression can't be inside a `Catch` block or `Finally` block.  
  
## Iterators  
 An iterator function or `Get` accessor performs a custom iteration over a collection. An iterator uses a [Yield](../../../visual-basic/language-reference/statements/yield-statement.md) statement to return each element of the collection one at a time. You call an iterator function by using a [For Each...Next Statement](../../../visual-basic/language-reference/statements/for-each-next-statement.md).  
  
 A `Yield` statement can be inside a `Try` block. A `Try` block that contains a `Yield` statement can have `Catch` blocks, and can have a `Finally` block. See the "Try Blocks in Visual Basic" section of [Iterators](../../programming-guide/concepts/iterators.md) for an example.  
  
 A `Yield` statement cannot be inside a `Catch` block or a `Finally` block.  
  
 If the `For Each` body (outside of the iterator function) throws an exception, a `Catch` block in the iterator function is not executed, but a `Finally` block in the iterator function is executed. A `Catch` block inside an iterator function catches only exceptions that occur inside the iterator function.  
  
## Partial-Trust Situations  
 In partial-trust situations, such as an application hosted on a network share, `Try...Catch...Finally` does not catch security exceptions that occur before the method that contains the call is invoked. The following example, when you put it on a server share and run from there, produces the error "System.Security.SecurityException: Request Failed." For more information about security exceptions, see the <xref:System.Security.SecurityException> class.  
  
 [!code-vb[VbVbalrStatements#85](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/try-catch-finally-statement_2.vb)]  
  
 In such a partial-trust situation, you have to put the `Process.Start` statement in a separate `Sub`. The initial call to the `Sub` will fail. This enables `Try...Catch` to catch it before the `Sub` that contains `Process.Start` is started and the security exception produced.  
  
## Example  
 The following example illustrates the structure of the `Try...Catch...Finally` statement.  
  
 [!code-vb[VbVbalrStatements#86](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/try-catch-finally-statement_3.vb)]  
  
## Example  
 In the following example, the `CreateException` method throws a `NullReferenceException`. The code that generates the exception is not in a `Try` block. Therefore, the `CreateException` method does not handle the exception. The `RunSample` method does handle the exception because the call to the `CreateException` method is in a `Try` block.  
  
 The example includes `Catch` statements for several types of exceptions, ordered from the most specific to the most general.  
  
 [!code-vb[VbVbalrStatements#91](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/try-catch-finally-statement_4.vb)]  
  
## Example  
 The following example shows how to use a `Catch When` statement to filter on a conditional expression. If the conditional expression evaluates to `True`, the code in the `Catch` block runs.  
  
 [!code-vb[VbVbalrStatements#92](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/try-catch-finally-statement_5.vb)]  
  
## Example  
 The following example has a `Try…Catch` statement that is contained in a `Try` block. The inner `Catch` block throws an exception that has its `InnerException` property set to the original exception. The outer `Catch` block reports its own exception and the inner exception.  
  
 [!code-vb[VbVbalrStatements#93](../../../visual-basic/language-reference/error-messages/codesnippet/VisualBasic/try-catch-finally-statement_6.vb)]  
  
## Example  
 The following example illustrates exception handling for async methods. To catch an exception that applies to an async task, the `Await` expression is in a `Try` block of the caller, and the exception is caught in the `Catch` block.  
  
 Uncomment the `Throw New Exception` line in the example to demonstrate exception handling. The exception is caught in the `Catch` block, the task's `IsFaulted` property is set to `True`, and the task's `Exception.InnerException` property is set to the exception.  
  
 Uncomment the `Throw New OperationCancelledException` line to demonstrate what happens when you cancel an asynchronous process. The exception is caught in the `Catch` block, and the task's `IsCanceled` property is set to `True`. However, under some conditions that don't apply to this example, `IsFaulted` is set to `True` and `IsCanceled` is set to `False`.  
  
 [!code-vb[csAsyncExceptions#1](../../../csharp/language-reference/keywords/codesnippet/VisualBasic/try-catch-finally-statement_7.vb)]  
  
## Example  
 The following example illustrates exception handling where multiple tasks can result in multiple exceptions. The `Try` block has the `Await` expression for the task that <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType> returned. The task is complete when the three tasks to which <xref:System.Threading.Tasks.Task.WhenAll%2A?displayProperty=nameWithType> is applied are complete.  
  
 Each of the three tasks causes an exception. The `Catch` block iterates through the exceptions, which are found in the `Exception.InnerExceptions` property of the task that `Task.WhenAll` returned.  
  
 [!code-vb[csAsyncExceptions#3](../../../csharp/language-reference/keywords/codesnippet/VisualBasic/try-catch-finally-statement_8.vb)]  
  
## See Also  
 <xref:Microsoft.VisualBasic.Information.Err%2A>  
 <xref:System.Exception>  
 [Exit Statement](../../../visual-basic/language-reference/statements/exit-statement.md)  
 [On Error Statement](../../../visual-basic/language-reference/statements/on-error-statement.md)  
 [Best Practices for Using Code Snippets](/visualstudio/ide/best-practices-for-using-code-snippets)  
 [Exception Handling](../../../standard/parallel-programming/exception-handling-task-parallel-library.md)  
 [Throw Statement](../../../visual-basic/language-reference/statements/throw-statement.md)
