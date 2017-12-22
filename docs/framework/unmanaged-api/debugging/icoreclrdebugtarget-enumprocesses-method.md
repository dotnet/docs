---
title: "ICoreClrDebugTarget::EnumProcesses Method"
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
  - "ICoreClrDebugTarget.EnumProcesses"
api_location: 
  - "mscordbi_macx86.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICoreClrDebugTarget::EnumProcesses"
helpviewer_keywords: 
  - "remote debugging API [Silverlight]"
  - "EnumProcesses method, ICorClrDebugTarget interface [Silverlight debugging]"
  - "ICorClrDebugTarget::EnumProcesses method [Silverlight debugging]"
  - "Silverlight, remote debugging"
ms.assetid: e00fd477-4f49-43d3-bd0e-3094824b1136
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICoreClrDebugTarget::EnumProcesses Method
Enumerates the processes that are running on a remote computer.  
  
## Syntax  
  
```  
HRESULT EnumProcesses (  
       [out]  DWORD*                  pcProcs,   
       [out]  CoreClrDebugProcInfo**  ppProcs  
);  
```  
  
#### Parameters  
 `pcProcs`  
 [out] The number of processes returned in `ppProcs`. This value can be 0 (zero).  
  
 `ppProcs`  
 [out] An array of [CoreClrDebugProcInfo](../../../../docs/framework/unmanaged-api/debugging/coreclrdebugprocinfo-structure.md) structures that represent the processes running on the remote computer.  
  
## Return Value  
 S_OK  
 Success.  
  
 E_OUTOFMEMORY  
 Unable to allocate enough memory for `ppProcs`.  
  
 E_FAIL (or other E_ return codes)  
 Other failures.  
  
## Remarks  
 To free the memory that was allocated by this method, call the [ICoreClrDebugTarget::FreeMemory](../../../../docs/framework/unmanaged-api/debugging/icoreclrdebugtarget-freememory-method.md) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CoreClrRemoteDebuggingInterfaces.h  
  
 **Library:** mscordbi_macx86.dll  
  
 **.NET Framework Versions:** 3.5 SP1  
  
## See Also  
 [ICoreClrDebugTarget Interface](../../../../docs/framework/unmanaged-api/debugging/icoreclrdebugtarget-interface.md)
