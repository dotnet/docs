---
title: "EHostBindingPolicyModifyFlags Enumeration"
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
  - "EHostBindingPolicyModifyFlags"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EHostBindingPolicyModifyFlags"
helpviewer_keywords: 
  - "EHostBindingPolicyModifyFlags enumeration [.NET Framework hosting]"
ms.assetid: 0339af16-ee1d-48ec-837d-a79d9a9c89f8
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# EHostBindingPolicyModifyFlags Enumeration
Allows the host to specify the type of redirection the common language runtime (CLR) should perform when applying policy modifications from a source assembly to a target assembly.  
  
## Syntax  
  
```  
typedef enum _hostBindingPolicyModifyFlags {  
    HOST_BINDING_POLICY_MODIFY_DEFAULT  = 0,  
    HOST_BINDING_POLICY_MODIFY_CHAIN    = 1,  
    HOST_BINDING_POLICY_MODIFY_REMOVE   = 2,  
    HOST_BINDING_POLICY_MODIFY_MAX      = 3  
} EHostBindingPolicyModifyFlags;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`HOST_BINDING_POLICY_MODIFY_CHAIN`|Specifies that the CLR will chain policy values of the source assembly onto those of the target assembly.|  
|`HOST_BINDING_POLICY_MODIFY_DEFAULT`|Specifies that the CLR will perform the default action.|  
|`HOST_BINDING_POLICY_MODIFY_MAX`|Specifies that the CLR will set the policy values of the target assembly to the maximum values.|  
|`HOST_BINDING_POLICY_MODIFY_REMOVE`|Specifies that the CLR will replace policy values of the target assembly with those of the source assembly.|  
  
## Remarks  
 The [ICLRHostBindingPolicyManager::ModifyApplicationPolicy](../../../../docs/framework/unmanaged-api/hosting/iclrhostbindingpolicymanager-modifyapplicationpolicy-method.md) method takes a parameter of type `EHostBindingPolicyModifyFlags`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRHostBindingPolicyManager Interface](../../../../docs/framework/unmanaged-api/hosting/iclrhostbindingpolicymanager-interface.md)  
 [Hosting Enumerations](../../../../docs/framework/unmanaged-api/hosting/hosting-enumerations.md)
