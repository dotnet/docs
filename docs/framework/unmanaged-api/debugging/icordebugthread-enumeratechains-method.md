---
description: "Learn more about: ICorDebugThread::EnumerateChains Method"
title: "ICorDebugThread::EnumerateChains Method"
ms.date: "03/30/2017"
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
---
# ICorDebugThread::EnumerateChains Method

Gets an interface pointer to an ICorDebugChainEnum enumerator that contains all the stack chains in this ICorDebugThread object.  
  
## Syntax  
  
```cpp  
HRESULT EnumerateChains (  
    [out] ICorDebugChainEnum **ppChains  
);  
```  
  
## Parameters  

 `ppChains`  
 [out] A pointer to the address of an `ICorDebugChainEnum` object that allows enumeration of all the stack chains in this thread, starting at the active (that is, the most recent) chain.  
  
## Remarks  

 The stack chain represents the physical call stack for the thread. The following circumstances create a stack chain boundary:  
  
- A managed-to-unmanaged or unmanaged-to-managed transition.  
  
- A context switch.  
  
- A debugger hijacking of a user thread.  
  
 In the simple case for a thread that is running purely managed code in a single context, a one-to-one correspondence will exist between threads and stack chains.  
  
 A debugger may want to rearrange the physical call stacks of all threads into logical call stacks. This would involve sorting all the threads' chains by their caller/callee relationships and regrouping them.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
