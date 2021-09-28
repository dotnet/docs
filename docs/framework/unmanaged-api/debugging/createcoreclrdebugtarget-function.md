---
description: "Learn more about: CreateCoreClrDebugTarget Function"
title: "CreateCoreClrDebugTarget Function"
ms.date: "03/30/2017"
api_name: 
  - "CreateCorClrDebugTarget"
api_location: 
  - "mscordbi_macx86.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CreateCoreClrDebugTarget"
helpviewer_keywords: 
  - "remote debugging API [Silverlight]"
  - "Silverlight, remote debugging"
  - "CreateCoreClrDebugTarget function"
ms.assetid: 1cf4ca8e-d9bb-4633-9adf-5e24315bf87a
topic_type: 
  - "apiref"
---
# CreateCoreClrDebugTarget Function

Creates a connection to a debugger proxy that is running on a remote machine, and returns an [ICoreClrDebugTarget](icoreclrdebugtarget-interface.md) object that can be used to query running processes and loaded runtimes on the remote machine.  
  
## Syntax  
  
```cpp  
HRESULT CreateCoreClrDebugTarget (  
       [in]  DWORD    dwAddress,
       [out] ICoreClrDebugTarget**     ppTarget  
);  
```  
  
## Parameters  

 `dwAddress`  
 [in] IPv4 address of a remote target machine.  
  
 `ppTarget`  
 [out] Pointer to a pointer to an [ICoreClrDebugTarget](icoreclrdebugtarget-interface.md) object that will be created.  
  
## Return Value  

 S_OK  
 The number of CLRs in the process was successfully determined, and the corresponding handle and path arrays were properly filled.  
  
 E_OUTOFMEMORY  
 Unable to allocate enough memory for `ppTarget`.  
  
 E_FAIL (or other E_ return codes)  
 Other failures.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CoreClrRemoteDebuggingInterfaces.h  
  
 **Library:** mscordbi_macx86.dll  
  
 **.NET Framework Versions:** 3.5 SP1
