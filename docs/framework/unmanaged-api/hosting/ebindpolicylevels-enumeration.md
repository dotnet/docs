---
title: "EBindPolicyLevels Enumeration"
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
  - "EBindPolicyLevels"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EBindPolicyLevels"
helpviewer_keywords: 
  - "EBindPolicyLevels enumeration [.NET Framework hosting]"
ms.assetid: a9e00b4f-b6d0-4257-bd88-4fe9af97b8fa
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# EBindPolicyLevels Enumeration
Provides flags to specify the level at which to apply or modify assembly policy.  
  
## Syntax  
  
```  
typedef enum {  
    ePolicyLevelNone         = 0x0,  
    ePolicyLevelRetargetable = 0x1,  
    ePolicyUnifiedToCLR      = 0x2,  
    ePolicyLevelApp          = 0x4,  
    ePolicyLevelPublisher    = 0x8,  
    ePolicyLevelHost         = 0x10,  
    ePolicyLevelAdmin        = 0x20  
    ePolicyPortability       = 0x40  
} EBindPolicyLevels;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`ePolicyLevelAdmin`|Specifies that policy should be applied at the administrator level.|  
|`ePolicyLevelApp`|Specifies that policy should be applied at the application level.|  
|`ePolicyLevelHost`|Specifies that policy should be applied at the host level.|  
|`ePolicyLevelNone`|Specifies no policy-level flags.|  
|`ePolicyLevelPublisher`|Specifies that policy should be applied at the publisher level.|  
|`ePolicyLevelRetargetable`|Specifies that policy should be applicable at variable levels.|  
|`ePolicyPortability`|Specifies that policy should support portability between implementations of a .NET Framework assembly. See the [\<supportPortability>](../../../../docs/framework/configure-apps/file-schema/runtime/supportportability-element.md) configuration file element.|  
|`ePolicyUnifiedToCLR`|Specifies that policy should be unified to that of the common language runtime (CLR).|  
  
## Remarks  
 This enumeration is passed to methods of the [ICLRHostBindingPolicyManager](../../../../docs/framework/unmanaged-api/hosting/iclrhostbindingpolicymanager-interface.md) interface to specify changes in application policy.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRAssemblyIdentityManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrassemblyidentitymanager-interface.md)  
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
