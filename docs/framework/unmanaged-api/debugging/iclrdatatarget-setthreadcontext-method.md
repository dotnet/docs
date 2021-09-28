---
description: "Learn more about: ICLRDataTarget::SetThreadContext Method"
title: "ICLRDataTarget::SetThreadContext Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDataTarget.SetThreadContext"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget::SetThreadContext"
helpviewer_keywords: 
  - "SetThreadContext method, ICLRDataTarget interface [.NET Framework debugging]"
  - "ICLRDataTarget::SetThreadContext method [.NET Framework debugging]"
ms.assetid: 103c8502-81fe-40d7-9c1e-9008d8fb19e1
topic_type: 
  - "apiref"
---
# ICLRDataTarget::SetThreadContext Method

Sets the current context of the specified thread in the target process. This method is called by the common language runtime (CLR) data access services.  
  
## Syntax  
  
```cpp  
HRESULT SetThreadContext (  
    [in] ULONG32            threadID,  
    [in] ULONG32            contextSize,  
    [in, size_is(contextSize)]
         BYTE               *context  
);  
```  
  
## Parameters  

 `threadID`  
 [in] The operating system identifier of a thread in the target process.  
  
 `contextSize`  
 [in] The size of the context.  
  
 `context`  
 [in] Pointer to a buffer containing the context.  
  
 The data in the `context` buffer will be in the format of the Win32 `CONTEXT` structure. The context specifies processor-specific register data, so the definition of the Win32 `CONTEXT` structure depends on the processor's architecture. Refer to the WinNT.h header file for the definition of the Win32 `CONTEXT` structure.  
  
## Remarks  

 This method is implemented by the writer of the debugging application.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRDataTarget Interface](iclrdatatarget-interface.md)
