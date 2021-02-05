---
description: "Learn more about: ICoreClrDebugTarget::FreeMemory Method"
title: "ICoreClrDebugTarget::FreeMemory Method"
ms.date: "03/30/2017"
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
---
# ICoreClrDebugTarget::FreeMemory Method

Frees the memory allocated by the [ICoreClrDebugTarget::EnumProcesses](icoreclrdebugtarget-enumprocesses-method.md) and [ICoreClrDebugTarget::EnumRuntimes](icoreclrdebugtarget-enumruntimes-method.md) methods.  
  
## Syntax  
  
```cpp  
void FreeMemory (  
     [in] void*pMemory);  
```  
  
## Parameters  

 `pMemory`  
 [in] A pointer to the array that is returned by either the [ICoreClrDebugTarget::EnumProcesses](icoreclrdebugtarget-enumprocesses-method.md) or the [ICoreClrDebugTarget::EnumRuntimes](icoreclrdebugtarget-enumruntimes-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CoreClrRemoteDebuggingInterfaces.h  
  
 **Library:** mscordbi_macx86.dll  
  
 **.NET Framework Versions:** 3.5 SP1  
  
## See also

- [ICoreClrDebugTarget Interface](icoreclrdebugtarget-interface.md)
