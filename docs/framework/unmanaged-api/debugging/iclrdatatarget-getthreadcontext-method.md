---
title: "ICLRDataTarget::GetThreadContext Method"
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
  - "ICLRDataTarget.GetThreadContext"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget::GetThreadContext"
helpviewer_keywords: 
  - "ICLRDataTarget::GetThreadContext method [.NET Framework debugging]"
  - "GetThreadContext method, ICLRDataTarget interface [.NET Framework debugging]"
ms.assetid: b9d8c3b5-3a2e-4225-95d4-dd052c4532c3
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDataTarget::GetThreadContext Method
Gets the current execution context for the given thread in the target process. This method is called by the common language runtime data access services.  
  
## Syntax  
  
```  
HRESULT GetThreadContext (  
    [in] ULONG32            threadID,  
    [in] ULONG32            contextFlags,  
    [in] ULONG32            contextSize,  
    [out, size_is(contextSize)]   
        BYTE                *context  
);  
```  
  
#### Parameters  
 `threadID`  
 [in] The operating system identifier of a thread in the target process.  
  
 `contextFlags`  
 [in] Flags that specify which parts of the context to return. The implementation will return at least these parts of the context.  
  
 `contextSize`  
 [in] The size of the context.  
  
 `context`  
 [out] Pointer to a buffer in which to place the context.  
  
 The data in the `context` buffer must be in the format of the Win32 `CONTEXT` structure. The context specifies processor-specific register data, so the definition of the Win32 `CONTEXT` structure depends on the processor's architecture. Refer to the WinNT.h header file for the definition of the Win32 `CONTEXT` structure.  
  
## Remarks  
 This method is implemented by the writer of the debugging application.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-interface.md)
