---
title: "LoadLibraryShim Function"
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
caps.latest.revision: 20
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# LoadLibraryShim Function
Loads a specified version of a DLL that is included in the .NET Framework redistributable package.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)]. Use the [ICLRRuntimeInfo::LoadLibrary](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-loadlibrary-method.md) method instead.  
  
## Syntax  
  
```  
HRESULT LoadLibraryShim (  
    [in]  LPCWSTR  szDllName,  
    [in]  LPCWSTR  szVersion,  
          LPVOID   pvReserved,  
    [out] HMODULE *phModDll  
);  
```  
  
#### Parameters  
 `szDllName`  
 [in] A zero-terminated string that represents the name of the DLL to be loaded from the .NET Framework library.  
  
 `szVersion`  
 [in] A zero-terminated string that represents the version of the DLL to be loaded. If `szVersion` is null, the version selected for loading is the latest version of the specified DLL that is less than version 4. That is, all versions equal to or greater than version 4 are ignored if `szVersion` is null, and if no version less than version 4 is installed, the DLL fails to load. This is to ensure that installation of the [!INCLUDE[net_v40_short](../../../../includes/net-v40-short-md.md)] does not affect pre-existing applications or components. See the entry [In-Proc SxS and Migration Quick Start](http://go.microsoft.com/fwlink/?LinkId=200329) in the CLR team blog.  
  
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
>  Beginning with the .NET Framework version 2.0, loading Fusion.dll causes the CLR to be loaded. This is because the functions in Fusion.dll are now wrappers whose implementations are provided by the runtime.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
