---
title: "ICoreClrDebugTarget::FreeMemory Method"
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
  - "ICoreDebugTarget.FreeMemory"
api_location: 
  - "mscordbi_macx86.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICoreClrDebugTarget::FreeMemory"
helpviewer_keywords: 
  - "remote debugging API [Silverlight]"
  - "FreeMemory method, ICoreClrDebugTarget interface [Silverlight debugging]"
  - "ICorClrDebugTarget::FreeMemory method [Silverlight debugging]"
  - "Silverlight, remote debugging"
ms.assetid: 98f2a0db-a6ec-4f9b-861d-f82485237d08
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICoreClrDebugTarget::FreeMemory Method
Frees the memory allocated by the [ICoreClrDebugTarget::EnumProcesses](../../../../docs/framework/unmanaged-api/debugging/icoreclrdebugtarget-enumprocesses-method.md) and [ICoreClrDebugTarget::EnumRuntimes](../../../../docs/framework/unmanaged-api/debugging/icoreclrdebugtarget-enumruntimes-method.md) methods.  
  
## Syntax  
  
```  
void FreeMemory (  
     [in] void*pMemory);  
```  
  
#### Parameters  
 `pMemory`  
 [in] A pointer to the array that is returned by either the [ICoreClrDebugTarget::EnumProcesses](../../../../docs/framework/unmanaged-api/debugging/icoreclrdebugtarget-enumprocesses-method.md) or the [ICoreClrDebugTarget::EnumRuntimes](../../../../docs/framework/unmanaged-api/debugging/icoreclrdebugtarget-enumruntimes-method.md) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CoreClrRemoteDebuggingInterfaces.h  
  
 **Library:** mscordbi_macx86.dll  
  
 **.NET Framework Versions:** 3.5 SP1  
  
## See Also  
 [ICoreClrDebugTarget Interface](../../../../docs/framework/unmanaged-api/debugging/icoreclrdebugtarget-interface.md)
