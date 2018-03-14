---
title: "EClrUnhandledException Enumeration"
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
  - "EClrUnhandledException"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EClrUnhandledException"
helpviewer_keywords: 
  - "EClrUnhandledException enumeration [.NET Framework hosting]"
ms.assetid: d231044e-2b53-4836-93f9-8117ff0e5c3a
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# EClrUnhandledException Enumeration
Describes the available options for managing exceptions that are unhandled in user code.  
  
## Syntax  
  
```  
typedef enum {  
    eRuntimeDeterminedPolicy,  
    eHostDeterminedPolicy  
} EClrUnhandledException;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`eRuntimeDeterminedPolicy`|Specifies that the default behavior occurs. The process is torn down.|  
|`eHostDeterminedPolicy`|Specifies that the common language runtime (CLR) ignores unhandled exceptions and lets the host determine any further action.|  
  
## Remarks  
 To specify that the CLR behave like earlier versions, use the `eHostDeterminedPolicy` member.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [EClrFailure Enumeration](../../../../docs/framework/unmanaged-api/hosting/eclrfailure-enumeration.md)  
 [EClrOperation Enumeration](../../../../docs/framework/unmanaged-api/hosting/eclroperation-enumeration.md)  
 [ICLRPolicyManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-interface.md)  
 [SetUnhandledExceptionPolicy Method](../../../../docs/framework/unmanaged-api/hosting/iclrpolicymanager-setunhandledexceptionpolicy-method.md)  
 [IHostPolicyManager Interface](../../../../docs/framework/unmanaged-api/hosting/ihostpolicymanager-interface.md)  
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
