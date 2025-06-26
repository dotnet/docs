---
description: "Learn more about: ICLRRuntimeInfo::LoadLibrary Method"
title: "ICLRRuntimeInfo::LoadLibrary Method"
ms.date: "03/30/2017"
api_name: 
  - "ICLRRuntimeInfo.LoadLibrary"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeInfo::LoadLibrary"
helpviewer_keywords: 
  - "ICLRRuntimeInfo::LoadLibrary method [.NET Framework hosting]"
  - "LoadLibrary method [.NET Framework hosting]"
ms.assetid: 4517ada3-4417-4ac5-a150-73da7a87c686
topic_type: 
  - "apiref"
---
# ICLRRuntimeInfo::LoadLibrary Method

Loads a .NET Framework library from the common language runtime (CLR) represented by an [ICLRRuntimeInfo](iclrruntimeinfo-interface.md) interface.  
  
 This method supersedes the [LoadLibraryShim](loadlibraryshim-function.md) function.  
  
## Syntax  
  
```cpp  
HRESULT LoadLibrary(  
     [in]  LPCWSTR pwzDllName,  
     [out, retval] HMODULE *phndModule);  
```  
  
## Parameters  

 `pwzDllName`  
 [in] The name of the assembly to be loaded.  
  
 `phndModule`  
 [out] A handle to the loaded assembly.  
  
## Return Value  

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`pwzDllName` or `phndModule` is null.|  
|E_OUTOFMEMORY|Not enough memory is available to handle the request.|  
  
## Remarks  

 This method only loads DLLs included in the .NET Framework redistributable package. It can not load user-generated assemblies.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [ICLRRuntimeInfo Interface](iclrruntimeinfo-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
- [Hosting](index.md)
