---
title: "How to: Write a Parallel.For Loop with Thread-Local Variables"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net"
ms.reviewer: ""
ms.suite: ""
ms.technology: dotnet-standard
ms.tgt_pltfrm: ""
ms.topic: "article"
dev_langs: 
  - "csharp"
  - "vb"
helpviewer_keywords: 
  - "parallel for loops, how to use local state"
ms.assetid: 68384064-7ee7-41e2-90e3-71f00bde01bb
caps.latest.revision: 23
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Write a Parallel.For Loop with Thread-Local Variables
This example shows how to use thread-local variables to store and retrieve state in each separate task that is created by a <xref:System.Threading.Tasks.Parallel.For%2A> loop. By using thread-local data, you can avoid the overhead of synchronizing a large number of accesses to shared state. Instead of writing to a shared resource on each iteration, you compute and store the value until all iterations for the task are complete. You can then write the final result once to the shared resource, or pass it to another method.  
  
## Example  
 The following example calls the <xref:System.Threading.Tasks.Parallel.For%60%601%28System.Int32%2CSystem.Int32%2CSystem.Func%7B%60%600%7D%2CSystem.Func%7BSystem.Int32%2CSystem.Threading.Tasks.ParallelLoopState%2C%60%600%2C%60%600%7D%2CSystem.Action%7B%60%600%7D%29> method to calculate the sum of the values in an array that contains one million elements. The value of each element is equal to its index.  
  
 [!code-csharp[TPL_Parallel#05](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_parallel/cs/forandforeach_simple.cs#05)]
 [!code-vb[TPL_Parallel#05](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_parallel/vb/forwiththreadlocal.vb#05)]  
  
 The first two parameters of every <xref:System.Threading.Tasks.Parallel.For%2A> method specify the beginning and ending iteration values. In this overload of the method, the third parameter is where you initialize your local state. In this context, local state means a variable whose lifetime extends from just before the first iteration of the loop on the current thread, to just after the last iteration.  
  
 The type of the third parameter is a <xref:System.Func%601> where `TResult` is the type of the variable that will store the thread-local state. Its type is defined by the generic type argument supplied when calling the generic <xref:System.Threading.Tasks.Parallel.For%60%601%28System.Int32%2CSystem.Int32%2CSystem.Func%7B%60%600%7D%2CSystem.Func%7BSystem.Int32%2CSystem.Threading.Tasks.ParallelLoopState%2C%60%600%2C%60%600%7D%2CSystem.Action%7B%60%600%7D%29> method, which in this case is <xref:System.Int64>. The type argument tells the compiler the type of the temporary variable that will be used to store the thread-local state. In this example, the expression `() => 0` (or `Function() 0` in Visual Basic) initializes the thread-local variable to zero. If the generic type argument is a reference type or user-defined value type, the expression would look like this:  
  
```csharp  
() => new MyClass()  
```  
  
```vb  
Function() new MyClass()  
```  
  
 The fourth parameter defines the loop logic. It must be a delegate or lambda expression whose signature is `Func<int, ParallelLoopState, long, long>` in C# or `Func(Of Integer, ParallelLoopState, Long, Long)` in Visual Basic. The first parameter is the value of the loop counter for that iteration of the loop. The second is a <xref:System.Threading.Tasks.ParallelLoopState> object that can be used to break out of the loop; this object is provided by the <xref:System.Threading.Tasks.Parallel> class to each occurrence of the loop. The third parameter is the thread-local variable. The last parameter is the return type. In this case, the type is <xref:System.Int64> because that is the type we specified in the <xref:System.Threading.Tasks.Parallel.For%2A> type argument. That variable is named `subtotal` and is returned by the lambda expression. The return value is used to initialize `subtotal` on each subsequent iteration of the loop. You can also think of this last parameter as a value that is passed to each iteration, and then passed to the `localFinally` delegate when the last iteration is complete.  
  
 The fifth parameter defines the method that is called once, after all the iterations on a particular thread have completed. The type of the input argument again corresponds to the type argument of the <xref:System.Threading.Tasks.Parallel.For%60%601%28System.Int32%2CSystem.Int32%2CSystem.Func%7B%60%600%7D%2CSystem.Func%7BSystem.Int32%2CSystem.Threading.Tasks.ParallelLoopState%2C%60%600%2C%60%600%7D%2CSystem.Action%7B%60%600%7D%29> method and the type returned by the body lambda expression. In this example, the value is added to a variable at class scope in a thread safe way by calling the <xref:System.Threading.Interlocked.Add%2A?displayProperty=nameWithType> method. By using a thread-local variable, we have avoided writing to this class variable on every iteration of the loop.  
  
 For more information about how to use lambda expressions, see [Lambda Expressions in PLINQ and TPL](../../../docs/standard/parallel-programming/lambda-expressions-in-plinq-and-tpl.md).  
  
## See Also  
 [Data Parallelism](../../../docs/standard/parallel-programming/data-parallelism-task-parallel-library.md)  
 [Parallel Programming](../../../docs/standard/parallel-programming/index.md)  
 [Task Parallel Library (TPL)](../../../docs/standard/parallel-programming/task-parallel-library-tpl.md)  
 [Lambda Expressions in PLINQ and TPL](../../../docs/standard/parallel-programming/lambda-expressions-in-plinq-and-tpl.md)
