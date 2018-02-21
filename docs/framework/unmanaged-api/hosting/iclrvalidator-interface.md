---
title: "ICLRValidator Interface"
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
  - "ICLRValidator"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRValidator"
helpviewer_keywords: 
  - "ICLRValidator interface [.NET Framework hosting]"
ms.assetid: 2edd0a10-77fb-4173-91eb-f2970cc364d0
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRValidator Interface
Provides methods for validating portable executable (PE) images and reporting validation errors.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[FormatEventInfo Method](../../../../docs/framework/unmanaged-api/hosting/iclrvalidator-formateventinfo-method.md)|Gets a detailed message about the specified validation error.|  
|[Validate Method](../../../../docs/framework/unmanaged-api/hosting/iclrvalidator-validate-method.md)|Validates the portable executable or Microsoft intermediate language (MSIL) in the specified file.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** IValidator.idl, IValidator.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRErrorReportingManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrerrorreportingmanager-interface.md)  
 [Hosting Interfaces](../../../../docs/framework/unmanaged-api/hosting/hosting-interfaces.md)  
 [CLRRuntimeHost Coclass](../../../../docs/framework/unmanaged-api/hosting/clrruntimehost-coclass.md)
