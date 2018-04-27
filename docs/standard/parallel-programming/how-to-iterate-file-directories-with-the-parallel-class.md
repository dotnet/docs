---
title: "How to: Iterate File Directories with the Parallel Class"
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
  - "parallel loops, how to iterate directories"
ms.assetid: 555e9f48-f53d-4774-9bcf-3e965c732ec5
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
  - "dotnetcore"
---
# How to: Iterate File Directories with the Parallel Class
In many cases, file iteration is an operation that can be easily parallelized. The topic [How to: Iterate File Directories with PLINQ](../../../docs/standard/parallel-programming/how-to-iterate-file-directories-with-plinq.md) shows the easiest way to perform this task for many scenarios. However, complications can arise when your code has to deal with the many types of exceptions that can arise when accessing the file system. The following example shows one approach to the problem. It uses a stack-based iteration to traverse all files and folders under a specified directory, and it enables your code to catch and handle various exceptions. Of course, the way that you handle the exceptions is up to you.  
  
## Example  
 The following example iterates the directories sequentially, but processes the files in parallel. This is probably the best approach when you have a large file-to-directory ratio. It is also possible to parallelize the directory iteration, and access each file sequentially. It is probably not efficient to parallelize both loops unless you are specifically targeting a machine with a large number of processors. However, as in all cases, you should test your application thoroughly to determine the best approach.  
  
 [!code-csharp[TPL_Parallel#08](../../../samples/snippets/csharp/VS_Snippets_Misc/tpl_parallel/cs/parallel_file.cs#08)]
 [!code-vb[TPL_Parallel#08](../../../samples/snippets/visualbasic/VS_Snippets_Misc/tpl_parallel/vb/fileiteration08.vb#08)]  
  
 In this example, the file I/O is performed synchronously. When dealing with large files or slow network connections, it might be preferable to access the files asynchronously. You can combine asynchronous I/O techniques with parallel iteration. For more information, see [TPL and Traditional .NET Framework Asynchronous Programming](../../../docs/standard/parallel-programming/tpl-and-traditional-async-programming.md).  
  
 The example uses the local `fileCount` variable to maintain a count of the total number of files processed. Because the variable might be accessed concurrently by multiple tasks, access to it is synchronized by calling the <xref:System.Threading.Interlocked.Add%2A?displayProperty=nameWithType> method.  
  
 Note that if an exception is thrown on the main thread, the threads that are started by the <xref:System.Threading.Tasks.Parallel.ForEach%2A> method might continue to run. To stop these threads, you can set a Boolean variable in your exception handlers, and check its value on each iteration of the parallel loop. If the value indicates that an exception has been thrown, use the <xref:System.Threading.Tasks.ParallelLoopState> variable to stop or break from the loop. For more information, see [How to: Stop or Break from a Parallel.For Loop](https://msdn.microsoft.com/library/de52e4f1-9346-4ad5-b582-1a4d54dc7f7e).  
  
## See Also  
 [Data Parallelism](../../../docs/standard/parallel-programming/data-parallelism-task-parallel-library.md)
