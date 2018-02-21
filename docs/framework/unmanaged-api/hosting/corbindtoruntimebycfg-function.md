---
title: "CorBindToRuntimeByCfg Function"
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
  - "CorBindToRuntimeByCfg"
api_location: 
  - "mscoree.dll"
api_type: 
  - "DLLExport"
f1_keywords: 
  - "CorBindToRuntimeByCfg"
helpviewer_keywords: 
  - "CorBindToRuntimeByCfg function [.NET Framework hosting]"
ms.assetid: ded1e492-a782-4185-9c66-709e421c1782
topic_type: 
  - "apiref"
caps.latest.revision: 15
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorBindToRuntimeByCfg Function
Loads the common language runtime (CLR) into a process by using version information that is read from an XML file.  
  
 This function has been deprecated in the [!INCLUDE[net_v40_long](../../../../includes/net-v40-long-md.md)].  
  
## Syntax  
  
```  
HRESULT CorBindToRuntimeByCfg (  
    [in]  IStream     *pCfgStream,  
    [in]  DWORD        reserved,  
    [in]  DWORD        startupFlags,  
    [in]  REFCLSID     rclsid,  
    [in]  REFIID       riid,   
    [out] LPVOID FAR*  ppv  
);  
```  
  
#### Parameters  
 `pCfgStream`  
 [in] A pointer to an `IStream` object that reads the XML file.  
  
 `reserved`  
 [in] Reserved for future use. Use 0 (zero) as value.  
  
 `startupFlags`  
 [in] A value of the [STARTUP_FLAGS](../../../../docs/framework/unmanaged-api/hosting/startup-flags-enumeration.md) enumeration that specifies the startup behavior of the CLR.  
  
 `rclsid`  
 [in] The `CLSID` of the coclass that implements either the [ICorRuntimeHost](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-interface.md) or the [ICLRRuntimeHost](../../../../docs/framework/unmanaged-api/hosting/iclrruntimehost-interface.md) interface. Supported values are CLSID_CorRuntimeHost or CLSID_CLRRuntimeHost.  
  
 `riid`  
 [in] The `IID` of either the `ICorRuntimeHost` or the `ICLRRuntimeHost` interface. Supported values are IID_ICorRuntimeHost or IID_ICLRRuntimeHost.  
  
 `ppv`  
 [out] A pointer to the address of the returned interface.  
  
## Remarks  
 The format of the XML file is modeled after the standard application configuration file. For more information about XML files, see [Configuration File Schema](../../../../docs/framework/configure-apps/file-schema/index.md).  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [CorBindToCurrentRuntime Function](../../../../docs/framework/unmanaged-api/hosting/corbindtocurrentruntime-function.md)  
 [CorBindToRuntime Function](../../../../docs/framework/unmanaged-api/hosting/corbindtoruntime-function.md)  
 [CorBindToRuntimeEx Function](../../../../docs/framework/unmanaged-api/hosting/corbindtoruntimeex-function.md)  
 [CorBindToRuntimeHost Function](../../../../docs/framework/unmanaged-api/hosting/corbindtoruntimehost-function.md)  
 [ICorRuntimeHost Interface](../../../../docs/framework/unmanaged-api/hosting/icorruntimehost-interface.md)  
 [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md)
