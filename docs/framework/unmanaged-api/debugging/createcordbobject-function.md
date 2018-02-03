---
title: "CreateCordbObject Function"
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
  - "CreateCoredbObject"
api_location: 
  - "mscordbi_macx86.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CreateCordbObject"
helpviewer_keywords: 
  - "remote debugging API [Silverlight]"
  - "CreateCordbObject function"
  - "Silverlight, remote debugging"
ms.assetid: b259821d-4fa7-464d-85cf-304dfffc8089
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CreateCordbObject Function
Creates a debugger interface ([ICorDebug](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md)) that provides functionality for instantiating a managed debugging session on a remote process.  
  
## Syntax  
  
```  
HRESULT CordbCreateObject (  
       [in]  int         iDebuggerVersion,   
       [out] IUnknown**  ppCordb  
);  
```  
  
#### Parameters  
 `iDebuggerVersion`  
 [in] Debugger version of the target process. This parameter must be CorDebugVersion_2_0 for remote debugging.  
  
 `ppCordb`  
 [out] Pointer to a pointer to an object that will be cast to an [ICorDebug](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md) interface and returned.  
  
## Return Value  
 S_OK  
 The number of CLRs in the process was successfully determined, and the corresponding handle and path arrays were properly filled.  
  
 E_INVALIDARG  
 `ppCordb` is null, or `iDebuggerVersion` is not CorDebugVersion_2_0.  
  
 E_OUTOFMEMORY  
 Unable to allocate enough memory for `ppCordb`  
  
 E_FAIL (or other E_ return codes)  
 Other failures.  
  
## Remarks  
 The [ICorDebug](../../../../docs/framework/unmanaged-api/debugging/icordebug-interface.md) interface that is returned in `ppCordb` is the top-level debugging interface for all managed debugging services.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CoreClrRemoteDebuggingInterfaces.h  
  
 **Library:** mscordbi_macx86.dll  
  
 **.NET Framework Versions:** 3.5 SP1
