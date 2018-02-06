---
title: "ICLRHostProtectionManager Interface"
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
  - "ICLRHostProtectionManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRHostProtectionManager"
helpviewer_keywords: 
  - "ICLRHostProtectionManager interface [.NET Framework hosting]"
ms.assetid: ce2770ae-23d0-45d9-8bcf-46504ac5020e
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRHostProtectionManager Interface
Enables the host to block specific managed classes, methods, properties, and fields from running in partially trusted code.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[SetEagerSerializeGrantSets](../../../../docs/framework/unmanaged-api/hosting/iclrhostprotectionmanager-seteagerserializegrantsets-method.md)|Provides a guarantee that certain rare race conditions that can cause fatal common language runtime (CLR) errors will never arise.|  
|[SetProtectedCategories Method](../../../../docs/framework/unmanaged-api/hosting/iclrhostprotectionmanager-setprotectedcategories-method.md)|Specifies the categories of managed types and members that should be blocked from running in partially trusted code.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [EApiCategories Enumeration](../../../../docs/framework/unmanaged-api/hosting/eapicategories-enumeration.md)  
 [ICLRControl Interface](../../../../docs/framework/unmanaged-api/hosting/iclrcontrol-interface.md)
