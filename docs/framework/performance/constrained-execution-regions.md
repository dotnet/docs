---
title: "Constrained Execution Regions"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "article"
helpviewer_keywords: 
  - "constrained execution regions"
  - "CERs"
ms.assetid: 99354547-39c1-4b0b-8553-938e8f8d1808
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# Constrained Execution Regions
A constrained execution region (CER) is part of a mechanism for authoring reliable managed code. A CER defines an area in which the common language runtime (CLR) is constrained from throwing out-of-band exceptions that would prevent the code in the area from executing in its entirety. Within that region, user code is constrained from executing code that would result in the throwing of out-of-band exceptions. The <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions%2A> method must immediately precede a `try` block and marks `catch`, `finally`, and `fault` blocks as constrained execution regions. Once marked as a constrained region, code must only call other code with strong reliability contracts, and code should not allocate or make virtual calls to unprepared or unreliable methods unless the code is prepared to handle failures. The CLR delays thread aborts for code that is executing in a CER.  
  
 Constrained execution regions are used in different forms in the CLR in addition to an annotated `try` block, notably critical finalizers executing in classes derived from the <xref:System.Runtime.ConstrainedExecution.CriticalFinalizerObject> class and code executed using the <xref:System.Runtime.CompilerServices.RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup%2A> method.  
  
## CER Advance Preparation  
 The CLR prepares CERs in advance to avoid out-of-memory conditions. Advance preparation is required so the CLR does not cause an out of memory condition during just-in-time compilation or type loading.  
  
 The developer is required to indicate that a code region is a CER:  
  
-   The top level CER region and methods in the full call graph that have the <xref:System.Runtime.ConstrainedExecution.ReliabilityContractAttribute> attribute applied are prepared in advance. The <xref:System.Runtime.ConstrainedExecution.ReliabilityContractAttribute> can only state guarantees of <xref:System.Runtime.ConstrainedExecution.Cer.Success> or <xref:System.Runtime.ConstrainedExecution.Cer.MayFail>.  
  
-   Advance preparation cannot be performed for calls that cannot be statically determined, such as virtual dispatch. Use the <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareMethod%2A> method in these cases. When using the <xref:System.Runtime.CompilerServices.RuntimeHelpers.ExecuteCodeWithGuaranteedCleanup%2A> method, the <xref:System.Runtime.ConstrainedExecution.PrePrepareMethodAttribute> attribute should be applied to the clean up code.  
  
## Constraints  
 Users are constrained in the type of code they can write in a CER. The code cannot cause an out-of-band exception, such as might result from the following operations:  
  
-   Explicit allocation.  
  
-   Boxing.  
  
-   Acquiring a lock.  
  
-   Calling unprepared methods virtually.  
  
-   Calling methods with a weak or nonexistent reliability contract.  
  
 In the .NET Framework version 2.0, these constraints are guidelines. Diagnostics are provided through code analysis tools.  
  
## Reliability Contracts  
 The <xref:System.Runtime.ConstrainedExecution.ReliabilityContractAttribute> is a custom attribute that documents the reliability guarantees and the corruption state of a given method.  
  
### Reliability Guarantees  
 Reliability guarantees, represented by <xref:System.Runtime.ConstrainedExecution.Cer> enumeration values, indicate the degree of reliability of a given method:  
  
-   <xref:System.Runtime.ConstrainedExecution.Cer.MayFail>. Under exceptional conditions, the method might fail. In this case, the method reports back to the calling method whether it succeeded or failed. The method must be contained in a CER to ensure that it can report the return value.  
  
-   <xref:System.Runtime.ConstrainedExecution.Cer.None>. The method, type, or assembly has no concept of a CER and is most likely not safe to call within a CER without substantial mitigation from state corruption. It does not take advantage of CER guarantees. This implies the following:  
  
    1.  Under exceptional conditions the method might fail.  
  
    2.  The method might or might not report that it failed.  
  
    3.  The method is not written to use a CER, the most likely scenario.  
  
    4.  If a method, type, or assembly is not explicitly identified to succeed, it is implicitly identified as <xref:System.Runtime.ConstrainedExecution.Cer.None>.  
  
-   <xref:System.Runtime.ConstrainedExecution.Cer.Success>. Under exceptional conditions, the method is guaranteed to succeed. To achieve this level of reliability you should always construct a CER around the method that is called, even when it is called from within a non-CER region. A method is successful if it accomplishes what is intended, although success can be viewed subjectively. For example, marking Count with `ReliabilityContractAttribute(Cer.Success)` implies that when it is run under a CER, it always returns a count of the number of elements in the <xref:System.Collections.ArrayList> and it can never leave the internal fields in an undetermined state.  However, the <xref:System.Threading.Interlocked.CompareExchange%2A> method is marked as success as well, with the understanding that success may mean the value could not be replaced with a new value due to a race condition.  The key point is that the method behaves in the way it is documented to behave, and CER code does not need to be written to expect any unusual behavior beyond what correct but unreliable code would look like.  
  
### Corruption levels  
 Corruption levels, represented by <xref:System.Runtime.ConstrainedExecution.Consistency> enumeration values, indicate how much state may be corrupted in a given environment:  
  
-   <xref:System.Runtime.ConstrainedExecution.Consistency.MayCorruptAppDomain>. Under exceptional conditions, the common language runtime (CLR) makes no guarantees regarding state consistency in the current application domain.  
  
-   <xref:System.Runtime.ConstrainedExecution.Consistency.MayCorruptInstance>. Under exceptional conditions, the method is guaranteed to limit state corruption to the current instance.  
  
-   <xref:System.Runtime.ConstrainedExecution.Consistency.MayCorruptProcess>, Under exceptional conditions, the CLR makes no guarantees regarding state consistency; that is, the condition might corrupt the process.  
  
-   <xref:System.Runtime.ConstrainedExecution.Consistency.WillNotCorruptState>. Under exceptional conditions, the method is guaranteed not to corrupt state.  
  
## Reliability try/catch/finally  
 The reliability `try/catch/finally` is an exception handling mechanism with the same level of predictability guarantees as the unmanaged version. The `catch/finally` block is the CER. Methods in the block require advance preparation and must be noninterruptible.  
  
 In the .NET Framework version 2.0, code informs the runtime that a try is reliable by calling <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions%2A> immediately preceding a try block. <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions%2A> is a member of <xref:System.Runtime.CompilerServices.RuntimeHelpers>, a compiler support class. Call <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions%2A> directly pending its availability through compilers.  
  
## Noninterruptible Regions  
 A noninterruptible region groups a set of instructions into a CER.  
  
 In .NET Framework version 2.0, pending availability through compiler support, user code creates non-interruptible regions with a reliable try/catch/finally that contains an empty try/catch block preceded by a <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareConstrainedRegions%2A> method call.  
  
## Critical Finalizer Object  
 A <xref:System.Runtime.ConstrainedExecution.CriticalFinalizerObject> guarantees that garbage collection will execute the finalizer. Upon allocation, the finalizer and its call graph are prepared in advance. The finalizer method executes in a CER, and must obey all the constraints on CERs and finalizers.  
  
 Any types inheriting from <xref:System.Runtime.InteropServices.SafeHandle> and <xref:System.Runtime.InteropServices.CriticalHandle> are guaranteed to have their finalizer execute within a CER. Implement <xref:System.Runtime.InteropServices.SafeHandle.ReleaseHandle%2A> in <xref:System.Runtime.InteropServices.SafeHandle> derived classes to execute any code that is required to free the handle.  
  
## Code Not Permitted in CERs  
 The following operations are not permitted in CERs:  
  
-   Explicit allocations.  
  
-   Acquiring a lock.  
  
-   Boxing.  
  
-   Multidimensional array access.  
  
-   Method calls through reflection.  
  
-   <xref:System.Threading.Monitor.Enter%2A> or <xref:System.IO.FileStream.Lock%2A>.  
  
-   Security checks. Do not perform demands, only link demands.  
  
-   <xref:System.Reflection.Emit.OpCodes.Isinst> and <xref:System.Reflection.Emit.OpCodes.Castclass> for COM objects and proxies  
  
-   Getting or setting fields on a transparent proxy.  
  
-   Serialization.  
  
-   Function pointers and delegates.  
  
## See Also  
 [Reliability Best Practices](../../../docs/framework/performance/reliability-best-practices.md)
