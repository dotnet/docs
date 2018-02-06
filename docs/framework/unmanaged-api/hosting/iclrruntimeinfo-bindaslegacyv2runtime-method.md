---
title: "ICLRRuntimeInfo::BindAsLegacyV2Runtime Method"
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
  - "ICLRRuntimeInfo.BindAsLegacyV2Runtime"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRRuntimeInfo::BindAsLegacyV2Runtime"
helpviewer_keywords: 
  - "ICLRRuntimeInfo::BindAsLegacyV2Runtime method [.NET Framework hosting]"
  - "BindAsLegacyV2Runtime method [.NET Framework hosting]"
ms.assetid: 65fd55ac-4a24-4479-9384-a2e8013bfb2b
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRRuntimeInfo::BindAsLegacyV2Runtime Method
Binds the current runtime for all legacy common language runtime (CLR) version 2 activation policy decisions.  
  
## Syntax  
  
```  
HRESULT BindAsLegacyV2Runtime ();  
```  
  
## Return Value  
 This method returns the following specific HRESULTs:  
  
|HRESULT|Description|  
|-------------|-----------------|  
|S_OK|Either binding succeeded, or this runtime was already bound as the legacy CLR version 2 activation policy runtime.|  
|CLR_E_SHIM_LEGACYRUNTIMEALREADYBOUND|A different runtime was already bound to the legacy CLR version 2 activation policy.|  
  
## Remarks  
 If the current runtime is already bound for all legacy CLR version 2 activation policy decisions (for example, by using the `useLegacyV2RuntimeActivationPolicy` attribute on the [\<startup> element](../../../../docs/framework/configure-apps/file-schema/startup/startup-element.md) in the configuration file), this method does not return an error result; instead, the result is S_OK, just as it would be if the method had successfully bound legacy activation policy.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MetaHost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [ICLRRuntimeInfo Interface](../../../../docs/framework/unmanaged-api/hosting/iclrruntimeinfo-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [Hosting](../../../../docs/framework/unmanaged-api/hosting/index.md)  
 [\<startup> Element](../../../../docs/framework/configure-apps/file-schema/startup/startup-element.md)
