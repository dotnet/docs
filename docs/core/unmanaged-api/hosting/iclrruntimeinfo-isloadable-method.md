---
description: "Learn more about: ICLRRuntimeInfo::IsLoadable Method"
title: "ICLRRuntimeInfo::IsLoadable Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRRuntimeInfo.IsLoadable"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeInfo::IsLoadable"
helpviewer_keywords: 
  - "IsLoadable method [.NET Framework hosting]"
  - "ICLRRuntimeInfo::IsLoadable method [.NET Framework hosting]"
ms.assetid: 205ca53b-e78e-49b2-9a46-2a7823e96b8c
topic_type: 
  - "apiref"
---
# ICLRRuntimeInfo::IsLoadable Method

Indicates whether the runtime associated with this interface can be loaded into the current process, taking into account other runtimes that might already be loaded into the process.  
  
## Syntax  
  
```cpp  
HRESULT IsLoadable(  
        [out, retval] BOOL *pbLoadable);  
```  
  
## Parameters  

 `pbLoadable`  
 [out] `true` if this runtime could be loaded into the current process; otherwise, `false`.  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`pbLoadable` is null.|  
  
## Remarks  

 If another runtime is already loaded into the process, and the runtime associated with this interface can be loaded for in-process side-by-side execution, `pbLoadable` returns `true`. If the two runtimes cannot run side-by-side in-process, `pbLoadable` returns `false`. For example, the common language runtime (CLR) version 4 can run side-by-side in the same process with CLR version 2.0 or CLR version 1.1. However, CLR version 1.1 and CLR version 2.0 cannot run side-by-side in-process.  
  
 If no runtimes are loaded into the process, this method always returns `true`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRRuntimeInfo Interface](iclrruntimeinfo-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
