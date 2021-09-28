---
description: "Learn more about: ICorDebugMutableDataTarget::ContinueStatusChanged Method"
title: "ICorDebugMutableDataTarget::ContinueStatusChanged Method"
ms.date: "03/30/2017"
ms.assetid: 5a66d3f4-dd16-4d62-9dcc-0eab7041d894
---
# ICorDebugMutableDataTarget::ContinueStatusChanged Method

Changes the continuation status for the outstanding debug event on the specified thread.  
  
## Syntax  
  
```cpp  
HRESULT ContinueStatusChanged(  
   [in] DWORD dwThreadId,  
   [in] CORDB_CONTINUE_STATUS continueStatus);  
```  
  
## Parameters  

 `dwThreadId`  
 The operating system-defined thread identifier.  
  
 `continueStatus`  
 A [COREDB_CONTINUE_STATUS](../common-data-types-unmanaged-api-reference.md) value that represents the new requested continuation status.  
  
## Remarks  

 The debugger calls the `ContinueStatusChanged` method when it calls an ICorDebug method that requires the current debug event to be handled in a way that is potentially different from the way in which it normally would be handled. For example, if there is an outstanding exception, and the debugger requests an operation that would cancel the exception (such as [ICorDebugILFrame::SetIP](icordebugilframe-setip-method.md) or `FuncEval`), this API is used to request that the exception be cancelled.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v46plus](../../../../includes/net-current-v46plus-md.md)]  
  
## See also

- [ICorDebugMutableDataTarget Interface](icordebugmutabledatatarget-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
