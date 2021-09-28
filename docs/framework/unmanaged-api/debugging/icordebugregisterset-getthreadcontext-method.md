---
description: "Learn more about: ICorDebugRegisterSet::GetThreadContext Method"
title: "ICorDebugRegisterSet::GetThreadContext Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugRegisterSet.GetThreadContext"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugRegisterSet::GetThreadContext"
helpviewer_keywords: 
  - "GetThreadContext method, ICorDebugRegisterSet interface [.NET Framework debugging]"
  - "ICorDebugRegisterSet::GetThreadContext method [.NET Framework debugging]"
ms.assetid: 0f63400b-dc1c-48d6-b51a-75c3f7f28e03
topic_type: 
  - "apiref"
---
# ICorDebugRegisterSet::GetThreadContext Method

Gets the context of the current thread.  
  
## Syntax  
  
```cpp  
HRESULT GetThreadContext(  
    [in] ULONG32 contextSize,  
    [in, out, length_is(contextSize),  
        size_is(contextSize)] BYTE context[]  
);  
```  
  
## Parameters  

 `contextSize`  
 [in] The size, in bytes, of the `context` array.  
  
 `context`  
 [in, out] An array of bytes that compose the Win32 `CONTEXT` structure for the current platform.  
  
## Remarks  

 The debugger should call this function instead of the Win32 `GetThreadContext` function, because the thread may be in a "hijacked" state where its context has been temporarily changed. The data returned is a Win32 `CONTEXT` structure for the current platform.  
  
 For non-leaf frames, clients should check which registers are valid by using [ICorDebugRegisterSet::GetRegistersAvailable](icordebugregisterset-getregistersavailable-method.md).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorDebugRegisterSet Interface](icordebugregisterset-interface.md)
- [ICorDebugRegisterSet2 Interface](icordebugregisterset2-interface.md)
