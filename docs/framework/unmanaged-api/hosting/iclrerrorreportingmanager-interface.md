---
title: "ICLRErrorReportingManager Interface"
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
  - "ICLRErrorReportingManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRErrorReportingManager"
helpviewer_keywords: 
  - "ICLRErrorReportingManager interface [.NET Framework hosting]"
ms.assetid: ea8af0d5-4133-4472-8a1f-50570d7e85fa
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRErrorReportingManager Interface
Provides methods that allow the host to configure custom stack dumps for error reporting.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[BeginCustomDump Method](../../../../docs/framework/unmanaged-api/hosting/iclrerrorreportingmanager-begincustomdump-method.md)|Specifies the configuration of custom stack dumps for error reporting.|  
|[EndCustomDump Method](../../../../docs/framework/unmanaged-api/hosting/iclrerrorreportingmanager-endcustomdump-method.md)|Clears the custom stack dump configuration that was set by an earlier call to `BeginCustomDump`.|  
|[GetBucketParametersForCurrentException Method](../../../../docs/framework/unmanaged-api/hosting/iclrerrorreportingmanager-getbucketparametersforcurrentexception-method.md)|Gets the Watson bucket for the current exception on the calling thread.|  
  
## Remarks  
 The `BeginCustomDump` method sets custom stack dump configuration. The `EndCustomDump` method clears the custom stack dump configuration and frees any associated state. It should be called after the custom dump is complete.  
  
> [!IMPORTANT]
>  Failure to call `EndCustomDump` causes memory to leak.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ECustomDumpItemKind Enumeration](../../../../docs/framework/unmanaged-api/hosting/ecustomdumpitemkind-enumeration.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)
