---
title: "ICorDebugRegisterSet::GetThreadContext Method"
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
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugRegisterSet::GetThreadContext Method
Gets the context of the current thread.  
  
## Syntax  
  
```  
HRESULT GetThreadContext(  
    [in] ULONG32 contextSize,  
    [in, out, length_is(contextSize),  
        size_is(contextSize)] BYTE context[]  
);  
```  
  
#### Parameters  
 `contextSize`  
 [in] The size, in bytes, of the `context` array.  
  
 `context`  
 [in, out] An array of bytes that compose the Win32 `CONTEXT` structure for the current platform.  
  
## Remarks  
 The debugger should call this function instead of the Win32 `GetThreadContext` function, because the thread may be in a "hijacked" state where its context has been temporarily changed. The data returned is a Win32 `CONTEXT` structure for the current platform.  
  
 For non-leaf frames, clients should check which registers are valid by using [ICorDebugRegisterSet::GetRegistersAvailable](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-getregistersavailable-method.md).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [ICorDebugRegisterSet Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset-interface.md)  
 [ICorDebugRegisterSet2 Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugregisterset2-interface.md)
