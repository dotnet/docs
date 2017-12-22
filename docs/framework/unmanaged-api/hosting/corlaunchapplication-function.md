---
title: "CorLaunchApplication Function"
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
  - "CorLaunchApplication"
api_location: 
  - "mscoree.dll"
  - "clr.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorLaunchApplication"
helpviewer_keywords: 
  - "CorLaunchApplication function [.NET Framework hosting]"
ms.assetid: 71f362a9-8fe2-47ce-9302-05a645cf3d7d
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorLaunchApplication Function
Starts the application at the specified network path, using the specified manifests and other application data.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
HRESULT CorLaunchApplication (  
    [in]  HOST_TYPE                dwClickOnceHost,  
    [in]  LPCWSTR                  pwzAppFullName,  
    [in]  DWORD                    dwManifestPaths,  
    [in]  LPCWSTR                 *ppwzManifestPaths,  
    [in]  DWORD                    dwActivationData,  
    [in]  LPCWSTR                 *ppwzActivationData,  
    [out] LPPROCESS_INFORMATION    lpProcessInformation  
);  
```  
  
#### Parameters  
 `dwClickOnceHost`  
 [in] A value of the [HOST_TYPE](../../../../docs/framework/unmanaged-api/hosting/host-type-enumeration.md) enumeration that specifies the type of host that is launching the application.  
  
 `pwzAppFullName`  
 [in] The full name of the application that is being launched.  
  
 `dwManifestPaths`  
 [in] The number of manifest paths for the application.  
  
 `ppwzManifestPaths`  
 [in] An array of strings, each of which specifies a path to a manifest for the application that is being launched.  
  
 `dwActivationData`  
 [in] The number of activation data items for the application that is being launched.  
  
 `ppwzActivationData`  
 [in] An array of strings, each of which is an activation data item for the application that is being launched.  
  
 `lpProcessInformation`  
 [out] A pointer to information about the process in which the application has been loaded.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
