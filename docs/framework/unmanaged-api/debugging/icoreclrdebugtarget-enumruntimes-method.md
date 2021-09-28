---
description: "Learn more about: ICoreClrDebugTarget::EnumRuntimes Method"
title: "ICoreClrDebugTarget::EnumRuntimes Method"
ms.date: "03/30/2017"
api_name: 
  - "ICoreClrDebugTarget.EnumRuntimes"
api_location: 
  - "mscordbi_macx86.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICoreClrDebugTarget::EnumRuntimes"
helpviewer_keywords: 
  - "remote debugging API [Silverlight]"
  - "ICorClrDebugTarget::EnumRuntimes method [Silverlight debugging]"
  - "EnumRuntimes method, ICoreClrDebugTarget interface [Silverlight debugging]"
  - "Silverlight, remote debugging"
ms.assetid: 316df866-442d-40cc-b049-45e8adcb65d1
topic_type: 
  - "apiref"
---
# ICoreClrDebugTarget::EnumRuntimes Method

Enumerates the common language runtimes (CLRs) in the specified process that is running on a remote computer.  
  
## Syntax  
  
```cpp  
HRESULT EnumRuntimes (  
      [in] DWORD       dwInternalProcessID,  
      [out] DWORD*     pcRuntimes,  
      [out] CoreClrDebugRuntimeInfo**    ppRuntimes  
    );  
```  
  
## Parameters  

 `dwInternalProcessID`  
 [in] The internal process ID of the process for which you want to enumerate runtimes. This will be `m_dwInternalID` from the corresponding [CoreClrDebugProcInfo](coreclrdebugprocinfo-structure.md).  
  
 `pcRuntimes`  
 [out] The number of runtimes returned in `ppRuntimes`. This value can be 0 (zero).  
  
 `ppRuntimes`  
 [out] An array of [CoreClrDebugRuntimeInfo](coreclrdebugruntimeinfo-structure.md) structures that represent the runtimes loaded in the remote target process.  
  
## Return Value  

 S_OK  
 Success.  
  
 S_FALSE  
 `dwInternalProcessID` does not match any process that is running on the computer, probably because the process was terminated. `pcRuntimes` and `ppRuntimes` will be null.  
  
 E_OUTOFMEMORY  
 Unable to allocate enough memory for `ppRuntimes`.  
  
 E_FAIL (or other E_ return codes)  
 Other failures.  
  
## Remarks  

 To free the memory that was allocated by this method, call the [ICoreClrDebugTarget::FreeMemory](icoreclrdebugtarget-freememory-method.md) method.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CoreClrRemoteDebuggingInterfaces.h  
  
 **Library:** mscordbi_macx86.dll  
  
 **.NET Framework Versions:** 3.5 SP1  
  
## See also

- [ICoreClrDebugTarget Interface](icoreclrdebugtarget-interface.md)
