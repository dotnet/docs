---
title: "invalidCERCall MDA"
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
  - "invalid CER calls"
  - "InvalidCERCall MDA"
  - "MDAs (managed debugging assistants), CER calls"
  - "constrained execution regions"
  - "CER calls"
  - "managed debugging assistants (MDAs), CER calls"
ms.assetid: c4577410-602e-44e5-9dab-fea7c55bcdfe
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# invalidCERCall MDA
The `invalidCERCall` managed debugging assistant (MDA) is activated when there is a call within the constrained execution region (CER) graph to a method that has no reliability contract or an excessively weak contract. A weak contract is a contract that declares that the worst case state corruption is of greater scope than the instance passed to the call, that is, the <xref:System.AppDomain> or process state may become corrupted or that its result is not always deterministically computable when called within a CER.  
  
## Symptoms  
 Unexpected results when executing code in a CER. The symptoms are not specific. They could be an unexpected <xref:System.OutOfMemoryException>, a <xref:System.Threading.ThreadAbortException>, or other exceptions at the call into the unreliable method because the runtime did not prepare it ahead of time or protect it from <xref:System.Threading.ThreadAbortException> exceptions at run time. A greater threat is that any exception resulting from the method at run time could leave the <xref:System.AppDomain> or process in an unstable state, which is contrary to the objective of a CER. The reason a CER is created is to avoid state corruptions such as this. The symptoms of corrupt state are application specific because the definition of consistent state is different between applications.  
  
## Cause  
 Code within a CER is calling a function with no <xref:System.Runtime.ConstrainedExecution.ReliabilityContractAttribute> or with a weak <xref:System.Runtime.ConstrainedExecution.ReliabilityContractAttribute> that is not compatible with running in a CER.  
  
 In terms of reliability contract syntax, a weak contract is a contract that does not specify a <xref:System.Runtime.ConstrainedExecution.Consistency> enumeration value or specifies a <xref:System.Runtime.ConstrainedExecution.Consistency> value of <xref:System.Runtime.ConstrainedExecution.Consistency.MayCorruptProcess>, <xref:System.Runtime.ConstrainedExecution.Consistency.MayCorruptAppDomain>, or <xref:System.Runtime.ConstrainedExecution.Cer.None>. Any of these conditions indicates that the code called may impede the efforts of the other code in the CER to maintain consistent state.  CERs allow code to treat errors in a very deterministic manner, maintaining internal invariants that are important to the application and allowing it to continue running in the face of transient errors such as out-of-memory exceptions.  
  
 The activation of this MDA indicates a possibility the method being called in the CER can fail in a way that the caller did not expect or that leaves the <xref:System.AppDomain> or process state corrupted or unrecoverable. Of course, the called code might execute correctly and the problem is simply a missing contract. However, the issues involved in writing reliable code are subtle and the absence of a contract is a good indicator the code might not execute correctly. The contracts are indicators that the programmer has coded reliably and also promises that these guarantees will not change in future revisions of the code.  That is, the contracts are declarations of intent and not just implementation details.  
  
 Because any method with a weak or nonexistent contract can potentially fail in many unpredictable ways, the runtime does not attempt to remove any of its own unpredictable failures from the method  that are introduced by lazy JIT-compiling, generics dictionary population, or thread aborts, for example. That is, when this MDA is activated, it indicates that the runtime did not include the called method in the CER being defined; the call graph was terminated at this node because continuing to prepare this subtree would help mask the potential error.  
  
## Resolution  
 Add a valid reliability contract to the function or avoid using that function call.  
  
## Effect on the Runtime  
 The effect of calling a weak contract from a CER could be the CER failure to complete its operations. This could lead to corruption of the <xref:System.AppDomain> process state.  
  
## Output  
 The following is sample output from this MDA.  
  
 `Method 'MethodWithCer', while executing within a constrained execution region, makes a call at IL offset 0x000C to 'MethodWithWeakContract', which does not have a sufficiently strong reliability contract and might cause non-deterministic results.`  
  
## Configuration  
  
```xml  
<mdaConfig>  
  <assistants>  
    <invalidCERCall />  
  </assistants>  
</mdaConfig>  
```  
  
## See Also  
 <xref:System.Runtime.CompilerServices.RuntimeHelpers.PrepareMethod%2A>  
 <xref:System.Runtime.ConstrainedExecution>  
 [Diagnosing Errors with Managed Debugging Assistants](../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
