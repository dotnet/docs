---
title: "GetRequestedRuntimeInfo Function"
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
  - "GetRequestedRuntimeInfo"
api_location: 
  - "mscoree.dll"
  - "mscoreei.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "GetRequestedRuntimeInfo"
helpviewer_keywords: 
  - "GetRequestedRuntimeInfo function [.NET Framework hosting]"
ms.assetid: 0dfd7cdc-c116-4e25-b56a-ac7b0378c942
topic_type: 
  - "apiref"
caps.latest.revision: 22
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetRequestedRuntimeInfo Function
Gets version and directory information about the common language runtime (CLR) requested by an application.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
HRESULT GetRequestedRuntimeInfo (  
    [in]  LPCWSTR  pExe,   
    [in]  LPCWSTR  pwszVersion,   
    [in]  LPCWSTR  pConfigurationFile,   
    [in]  DWORD    startupFlags,   
    [in]  DWORD    runtimeInfoFlags,   
    [out] LPWSTR   pDirectory,   
    [in]  DWORD    dwDirectory,   
    [out] DWORD   *dwDirectoryLength,   
    [out] LPWSTR   pVersion,   
    [in]  DWORD    cchBuffer,   
    [out] DWORD   *dwlength  
);  
```  
  
#### Parameters  
 `pExe`  
 [in] The name of the application.  
  
 `pwszVersion`  
 [in] A string specifying the version number of the runtime.  
  
 `pConfigurationFile`  
 [in] The name of the configuration file that is associated with `pExe`.  
  
 `startupFlags`  
 [in] One or more of the [STARTUP_FLAGS](../../../../docs/framework/unmanaged-api/hosting/startup-flags-enumeration.md) enumeration values.  
  
 `runtimeInfoFlags`  
 [in] One or more of the [RUNTIME_INFO_FLAGS](../../../../docs/framework/unmanaged-api/hosting/runtime-info-flags-enumeration.md) enumeration values.  
  
 `pDirectory`  
 [out] A buffer that contains the directory path to the runtime upon successful completion.  
  
 `dwDirectory`  
 [in] The length of the directory buffer.  
  
 `dwDirectoryLength`  
 [out] A pointer to the length of the directory path string.  
  
 `pVersion`  
 [out] A buffer that contains the version number of the runtime upon successful completion.  
  
 `cchBuffer`  
 [in] The length of the version string buffer.  
  
 `dwlength`  
 [out] A pointer to the length of the version string.  
  
## Return Value  
 This method returns standard Component Object Model (COM) error codes, as defined in WinError.h, in addition to the following values.  
  
|Return code|Description|  
|-----------------|-----------------|  
|S_OK|The method completed successfully.|  
|ERROR_INSUFFICIENT_BUFFER|The directory buffer is not large enough to store the directory path.<br /><br /> - or -<br /><br /> The version buffer is not large enough to store the version string.|  
  
## Remarks  
 The `GetRequestedRuntimeInfo` method returns run-time information about the version loaded into the process, which is not necessarily the latest version installed on the computer.  
  
 In the .NET Framework version 2.0, you can get information about the latest installed version by using the `GetRequestedRuntimeInfo` method as follows:  
  
-   Specify the `pExe`, `pwszVersion`, and `pConfigurationFile` parameters as null.  
  
-   Specify the RUNTIME_INFO_UPGRADE_VERSION flag in the `RUNTIME_INFO_FLAGS` enumerations for the `runtimeInfoFlags` parameter.  
  
 The `GetRequestedRuntimeInfo` method does not return the latest CLR version in the following circumstances:  
  
-   An application configuration file that specifies loading a particular CLR version exists. Note that the .NET Framework will use the configuration file even if you specify null for the `pConfigurationFile` parameter.  
  
-   The [CorBindToRuntimeEx](../../../../docs/framework/unmanaged-api/hosting/corbindtoruntimeex-function.md) method was called specifying an earlier CLR version.  
  
-   An application that was compiled for an earlier CLR version is currently running.  
  
 For the `runtimeInfoFlags` parameter, you can specify only one of the architecture constants of the `RUNTIME_INFO_FLAGS` enumeration at a time:  
  
-   RUNTIME_INFO_REQUEST_IA64  
  
-   RUNTIME_INFO_REQUEST_AMD64  
  
-   RUNTIME_INFO_REQUEST_X86  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v11plus](../../../../includes/net-current-v11plus-md.md)]  
  
## See Also  
 [GetRequestedRuntimeVersion Function](../../../../docs/framework/unmanaged-api/hosting/getrequestedruntimeversion-function.md)  
 [GetVersionFromProcess Function](../../../../docs/framework/unmanaged-api/hosting/getversionfromprocess-function.md)  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
