---
description: "Learn more about: ICorDebugThread4::GetBlockingObjects Method"
title: "ICorDebugThread4::GetBlockingObjects Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugThread4.GetBlockingObjects Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugThread4::GetBlockingObjects"
helpviewer_keywords: 
  - "GetBlockingObjects method [.NET Framework debugging]"
  - "ICorDebugThread4::GetBlockingObjects method [.NET Framework debugging]"
ms.assetid: a7e6c54e-7be9-4e52-bbb4-95f52458e8e4
topic_type: 
  - "apiref"
---
# ICorDebugThread4::GetBlockingObjects Method

Provides an ordered enumeration of [CorDebugBlockingObject](cordebugblockingobject-structure.md) structures that provide thread blocking information.  
  
## Syntax  
  
```cpp  
HRESULT GetBlockingObjects (  
    [out] ICorDebugBlockingObjectEnum **ppBlockingObjectEnum  
```  
  
## Parameters  

 `ppBlockingObjectEnum`  
 [out] A pointer to an ordered enumeration of [CorDebugBlockingObject](cordebugblockingobject-structure.md) structures.  
  
## Remarks  

 The first element in the returned enumeration corresponds to the first structure that is blocking the thread. The second element corresponds to a blocking item that is encountered while running an asynchronous procedure call (APC) when blocked on the first, and so on.  
  
 The enumeration is valid only for the duration of the current synchronized state.  
  
 This method must be called while the debuggee is in a synchronized state.  
  
 If `ppBlockingObjectEnum` is not a valid pointer, the result is undefined.  
  
 If a thread is blocked and the error cannot be determined, the method returns an HRESULT that indicates failure; otherwise, it returns S_OK.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICorDebugThread4 Interface](icordebugthread4-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
