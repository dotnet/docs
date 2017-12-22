---
title: "ICorDebugDataTarget::GetThreadContext Method"
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
  - "ICorDebugDataTarget.GetThreadContext Method"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugDataTarget::GetThreadContext"
helpviewer_keywords: 
  - "ICorDebugDataTarget::GetThreadContext method [.NET Framework debugging]"
  - "GetThreadContext method, ICorDebugDataTarget interface [.NET Framework debugging]"
ms.assetid: c8954268-1821-4b23-b665-dbb55f2af31b
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugDataTarget::GetThreadContext Method
Returns the current thread context for the specified thread.  
  
## Syntax  
  
```  
HRESULT GetThreadContext(  
       [in] DWORD dwThreadID,  
       [in] ULONG32 contextFlags,  
       [in] ULONG32 contextSize,  
       [out, size_is(contextSize)] BYTE * pContext);  
```  
  
#### Parameters  
 `dwThreadID`  
 [in] The identifier of the thread whose context is to be retrieved. The identifier is defined by the operating system.  
  
 `contextFlags`  
 [in] A bitwise combination of platform-dependent flags that indicate which portions of the context should be read.  
  
 `contextSize`  
 [in] The size of `pContext`.  
  
 `pContext`  
 [out] The buffer where the thread context will be stored.  
  
## Remarks  
 On Windows platforms, `pContext` must be a `CONTEXT` structure (defined in WinNT.h) that is appropriate for the machine type specified by the [ICorDebugDataTarget::GetPlatform](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-getplatform-method.md) method. `contextFlags` must have the same values as the `ContextFlags` field of the `CONTEXT` structure. The `CONTEXT` structure is processor-specific; refer to the WinNT.h file for details.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICorDebugDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugdatatarget-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
