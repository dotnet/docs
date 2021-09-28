---
description: "Learn more about: LoadLibraryShim Function"
title: "LoadLibraryShim Function"
ms.date: "03/30/2017"
api_name: 
  - "LoadLibraryShim"
api_location: 
  - "mscoree.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "LoadLibraryShim"
helpviewer_keywords: 
  - "LoadLibraryShim function [.NET Framework hosting]"
ms.assetid: 30931874-4d0e-4df1-b3d1-e425b50655d1
topic_type: 
  - "apiref"
---
# LoadLibraryShim Function

Loads a specified version of a DLL that is included in the .NET Framework redistributable package.  
  
 This function has been deprecated in the .NET Framework 4. Use the [ICLRRuntimeInfo::LoadLibrary](iclrruntimeinfo-loadlibrary-method.md) method instead.  
  
## Syntax  
  
```cpp  
HRESULT LoadLibraryShim (  
    [in]  LPCWSTR  szDllName,  
    [in]  LPCWSTR  szVersion,  
          LPVOID   pvReserved,  
    [out] HMODULE *phModDll  
);  
```  
  
## Parameters  

 `szDllName`  
 [in] A zero-terminated string that represents the name of the DLL to be loaded from the .NET Framework library.  
  
 `szVersion`  
 [in] A zero-terminated string that represents the version of the DLL to be loaded. If `szVersion` is null, the version selected for loading is the latest version of the specified DLL that is less than version 4. That is, all versions equal to or greater than version 4 are ignored if `szVersion` is null, and if no version less than version 4 is installed, the DLL fails to load. This is to ensure that installation of the .NET Framework 4 does not affect pre-existing applications or components. See the entry [In-Proc SxS and Migration Quick Start](https://devblogs.microsoft.com/dotnet/in-proc-sxs-and-migration-quick-start/) in the CLR team blog.  
  
 `pvReserved`  
 Reserved for future use.  
  
 `phModDll`  
 [out] A pointer to the handle of the module.  
  
## Return Value  

 This method returns standard Component Object Model (COM) error codes, as defined in WinError.h, in addition to the following values.  
  
|Return code|Description|  
|-----------------|-----------------|  
|S_OK|The method completed successfully.|  
|CLR_E_SHIM_RUNTIMELOAD|Loading `szDllName` requires loading the common language runtime (CLR), and the necessary version of the CLR cannot be loaded.|  
  
## Remarks  

 This function is used to load DLLs that are included in the .NET Framework redistributable package. It does not load user-generated DLLs.  
  
> [!NOTE]
> Beginning with the .NET Framework version 2.0, loading Fusion.dll causes the CLR to be loaded. This is because the functions in Fusion.dll are now wrappers whose implementations are provided by the runtime.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
