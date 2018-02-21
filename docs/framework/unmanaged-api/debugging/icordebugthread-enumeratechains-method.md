---
title: "ICorDebugThread::EnumerateChains Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ICorDebugThread.EnumerateChains"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread::EnumerateChains"
helpviewer_keywords: 
  - "EnumerateChains method [.NET Framework debugging]"
  - "ICorDebugThread::EnumerateChains method [.NET Framework debugging]"
ms.assetid: ec00bc21-117e-4acd-9301-2cfafd5be8d3
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugThread::EnumerateChains Method
Gets an interface pointer to an ICorDebugChainEnum enumerator that contains all the stack chains in this ICorDebugThread object.  
  
## Syntax  
  
```  
HRESULT EnumerateChains (  
    [out] ICorDebugChainEnum **ppChains  
);  
```  
  
#### Parameters  
 `ppChains`  
 [out] A pointer to the address of an `ICorDebugChainEnum` object that allows enumeration of all the stack chains in this thread, starting at the active (that is, the most recent) chain.  
  
## Remarks  
 The stack chain represents the physical call stack for the thread. The following circumstances create a stack chain boundary:  
  
-   A managed-to-unmanaged or unmanaged-to-managed transition.  
  
-   A context switch.  
  
-   A debugger hijacking of a user thread.  
  
 In the simple case for a thread that is running purely managed code in a single context, a one-to-one correspondence will exist between threads and stack chains.  
  
 A debugger may want to rearrange the physical call stacks of all threads into logical call stacks. This would involve sorting all the threads' chains by their caller/callee relationships and regrouping them.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
