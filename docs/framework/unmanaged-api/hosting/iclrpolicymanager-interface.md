---
title: "ICLRPolicyManager Interface"
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
  - "ICLRPolicyManager"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRPolicyManager"
helpviewer_keywords: 
  - "ICLRPolicyManager interface [.NET Framework hosting]"
ms.assetid: 5c834aa1-f2db-408a-b230-c7bec093d364
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRPolicyManager Interface
Provides methods that allow the host to specify policy actions to be taken in the event of failures and timeouts.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[SetActionOnFailure Method](../../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-setactiononfailure-method.md)|Specifies the policy action the common language runtime (CLR) should take when the specified failure occurs.|  
|[SetActionOnTimeout Method](../../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-setactionontimeout-method.md)|Specifies the policy action the CLR should take when the specified operation times out.|  
|[SetDefaultAction Method](../../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-setdefaultaction-method.md)|Specifies the policy action the CLR should take when the specified operation occurs.|  
|[SetTimeout Method](../../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-settimeout-method.md)|Sets a timeout value for the specified operation.|  
|[SetTimeoutAndAction Method](../../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-settimeoutandaction-method.md)|Sets a timeout value for the specified operation, and specifies the policy action the CLR should take when the operation occurs.|  
|[SetUnhandledExceptionPolicy Method](../../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-setunhandledexceptionpolicy-method.md)|Specifies the behavior of the CLR when an unhandled exception occurs.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [EClrFailure Enumeration](../../../../docs/framework/unmanaged-api/hosting/eclrfailure-enumeration.md)  
 [EClrOperation Enumeration](../../../../docs/framework/unmanaged-api/hosting/eclroperation-enumeration.md)  
 [EPolicyAction Enumeration](../../../../docs/framework/unmanaged-api/hosting/epolicyaction-enumeration.md)  
 [ICLRControl Interface](../../../../docs/framework/unmanaged-api/hosting/iclrcontrol-interface.md)
