---
title: "ICLRRuntimeInfo::GetInterface Method"
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
  - "ICLRRuntimeInfo.GetInterface"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeInfo::GetInterface"
helpviewer_keywords: 
  - "GetInterface method [.NET Framework hosting]"
  - "ICLRRuntimeInfo::GetInterface method [.NET Framework hosting]"
ms.assetid: cc7b0e5b-48c3-4509-8ebb-611ddb1f7ec2
topic_type: 
  - "apiref"
caps.latest.revision: 21
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRRuntimeInfo::GetInterface Method
Loads the CLR into the current process and returns runtime interface pointers, such as [ICLRRuntimeHost](../../../../docs/framework/unmanaged-api/hosting/iclrruntimehost-interface.md), [ICLRStrongName](../../../../docs/framework/unmanaged-api/hosting/iclrstrongname-interface.md), and [IMetaDataDispenserEx](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenser-interface.md).  
  
 This method supersedes all the `CorBindTo`* functions in the [Deprecated CLR Hosting Functions](../../../../docs/framework/unmanaged-api/hosting/deprecated-clr-hosting-functions.md) section.  
  
## Syntax  
  
```  
HRESULT GetInterface(  
[in]  REFCLSID rclsid,  
[in]  REFIID   riid,  
[out, iid_is(riid), retval] LPVOID *ppUnk);  
```  
  
#### Parameters  
 `rclsid`  
 [in] The CLSID interface for the coclass.  
  
 `riid`  
 [in] The IID of the requested `rclsid` interface.  
  
 `ppUnk`  
 [out] A pointer to the queried interface.  
  
## Return Value  
 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|The method completed successfully.|  
|E_POINTER|`ppUnk` is null.|  
|E_OUTOFMEMORY|Not enough memory is available to handle the request.|  
|CLR_E_SHIM_LEGACYRUNTIMEALREADYBOUND|A different runtime was already bound to the legacy CLR version 2 activation policy.|  
  
## Remarks  
 This method causes the CLR to be loaded but not initialized.  
  
 The following table shows the supported combinations for `rclsid` and `riid`.  
  
|`rclsid`|`riid`|  
|--------------|------------|  
|CLSID_CorMetaDataDispenser|IID_IMetaDataDispenser, IID_IMetaDataDispenserEx|  
|CLSID_CorMetaDataDispenserRuntime|IID_IMetaDataDispenser, IID_IMetaDataDispenserEx|  
|CLSID_CorRuntimeHost|IID_ICorRuntimeHost|  
|CLSID_CLRRuntimeHost|IID_ICLRRuntimeHost|  
|CLSID_TypeNameFactory|IID_ITypeNameFactory|  
|CLSID_CLRDebuggingLegacy|IID_ICorDebug|  
|||  
|CLSID_CLRStrongName|IID_ICLRStrongName|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICLRRuntimeInfo Interface](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)
