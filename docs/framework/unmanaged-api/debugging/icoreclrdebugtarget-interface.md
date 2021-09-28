---
description: "Learn more about: ICoreClrDebugTarget Interface"
title: "ICoreClrDebugTarget Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICoreClrDebugTarget"
api_location: 
  - "mscordbi_macx86.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICoreClrDebugTarget"
helpviewer_keywords: 
  - "remote debugging API [Silverlight]"
  - "ICorClrDebugTarget interface"
  - "Silverlight, remote debugging"
ms.assetid: 7cfaee76-e284-4a66-a431-8e33f0f60038
topic_type: 
  - "apiref"
---
# ICoreClrDebugTarget Interface

Provides methods that control reference counts, enumerate processes, and free the memory associated with a debugger that is attached to a remote Macintosh Silverlight target.  
  
## Syntax  
  
```cpp  
class ICoreClrDebugTarget {  
      HRESULT EnumProcesses (  
          [out] DWORD*                    pcProcs,  
          [out] CoreClrDebugProcInfo**    ppProcs  
      );  
  
      HRESULT EnumRuntimes (  
      [in]  DWORD                      dwInternalProcessID,  
      [out] DWORD*                     pcRuntimes,  
      [out] CoreClrDebugRuntimeInfo**  ppRuntimes  
      );  
  
      void FreeMemory (  
      [in] void*      pMemory  
    );  
};  
```  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[ICoreClrDebugTarget::EnumProcesses Method](icoreclrdebugtarget-enumprocesses-method.md)|Enumerates the processes that are running on a remote computer.|  
|[ICoreClrDebugTarget::EnumRuntimes Method](icoreclrdebugtarget-enumruntimes-method.md)|Enumerates the common language runtimes (CLRs) in the specified process on a remote computer.|  
|[ICoreClrDebugTarget::FreeMemory Method](icoreclrdebugtarget-freememory-method.md)|Frees the memory that is allocated by the enumeration methods in this class.|  
  
## Remarks  

 Currently, this functionality is supported only for debugging a Silverlight-based application target that is running on a remote Macintosh computer.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CoreClrRemoteDebuggingInterfaces.h  
  
 **Library:** mscordbi_macx86.dll  
  
 **.NET Framework Versions:** 3.5 SP1  
  
## See also

- [ICorDebugRemoteTarget Interface](icordebugremotetarget-interface.md)
- [ICorDebug Interface](icordebug-interface.md)

- [Debugging Interfaces](debugging-interfaces.md)
