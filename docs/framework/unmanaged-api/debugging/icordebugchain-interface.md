---
description: "Learn more about: ICorDebugChain Interface"
title: "ICorDebugChain Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugChain"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugChain"
helpviewer_keywords: 
  - "ICorDebugChain interface [.NET Framework debugging]"
ms.assetid: f671f519-1cb3-4ae5-b9f1-abc5e783459f
topic_type: 
  - "apiref"
---
# ICorDebugChain Interface

Represents a segment of a physical or logical call stack.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[EnumerateFrames Method](icordebugchain-enumerateframes-method.md)|Gets an enumerator that contains all the managed stack frames in the chain, starting with the most recent frame.|  
|[GetActiveFrame Method](icordebugchain-getactiveframe-method.md)|Gets the active (that is, most recent) frame on the chain.|  
|[GetCallee Method](icordebugchain-getcallee-method.md)|Gets the chain that was called by this chain.|  
|[GetCaller Method](icordebugchain-getcaller-method.md)|Gets the chain that called this chain.|  
|[GetContext Method](icordebugchain-getcontext-method.md)|Not implemented.|  
|[GetNext Method](icordebugchain-getnext-method.md)|Gets the next chain of frames for the thread.|  
|[GetPrevious Method](icordebugchain-getprevious-method.md)|Gets the previous chain of frames for the thread.|  
|[GetReason Method](icordebugchain-getreason-method.md)|Gets the reason for the genesis of this calling chain.|  
|[GetRegisterSet Method](icordebugchain-getregisterset-method.md)|Gets the register set for the active part of this chain.|  
|[GetStackRange Method](icordebugchain-getstackrange-method.md)|Gets the address range of the stack segment for this chain.|  
|[GetThread Method](icordebugchain-getthread-method.md)|Gets the physical thread this call chain is part of.|  
|[IsManaged Method](icordebugchain-ismanaged-method.md)|Gets a value that indicates whether this chain is running managed code.|  
  
## Remarks  

 The stack frames in a chain occupy contiguous stack space and share the same thread and context. A chain may represent either managed or unmanaged code chains. An empty `ICorDebugChain` instance represents an unmanaged code chain.  
  
> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Interfaces](debugging-interfaces.md)
