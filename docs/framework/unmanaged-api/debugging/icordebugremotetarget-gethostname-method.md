---
title: "ICorDebugRemoteTarget::GetHostName Method"
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
  - "ICorDebugRemoteTarget.GetHostName"
api_location: 
  - "CorDebug.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugRemoteTarget::GetHostName"
helpviewer_keywords: 
  - "ICorDebugRemoteTarget::GetHostName method [.NET Framework debugging]"
  - "GetHostName method, ICorDebugRemoteTarget interface [.NET Framework debugging]"
ms.assetid: 1c7276f7-7e54-470c-808c-e13745ac07a1
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugRemoteTarget::GetHostName Method
Returns the fully qualified domain name or IPv4 address of the remote debugging target machine. IPV6 is not supported at this time.  
  
## Syntax  
  
```  
HRESULT GetHostName (  
    [in] ULONG32      cchHostName,  
    [out] ULONG32*    pcchHostName,  
    [out, size_is(cchHostName), length_is(*pcchHostName)]  
            WCHAR szHostName[]  
```  
  
#### Parameters  
 `cchHostName`  
 [in] The size, in characters, of the `szHostName` buffer. If this parameter is 0 (zero), `szHostName` must be null.  
  
 `pcchHostName`  
 [out] The number of characters, including a null terminator, in the host name or IP address. This parameter can be null.  
  
 `szHostName`  
 [out] Buffer that contains the host name or IP address.  
  
## Return Value  
 S_OK  
 The host name or IP address was successfully returned.  
  
 E_FAIL (or other E_ return codes)  
 Unable to return the host name or IP address.  
  
## Remarks  
 This method is implemented by the debugger writer. It must follow the multiple call paradigm: On the first call, the caller passes null to both `cchHostName` and `szHostName`, and `pcchHostName` returns the size of the required buffer . On the second call, the size that was previously returned is passed in `cchHostName`, and an appropriately sized buffer is passed in `szHostName`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** 3.5 SP1  
  
## See Also  
 [ICorDebugRemoteTarget Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugremotetarget-interface.md)  
 [ICorDebug Interface](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)
