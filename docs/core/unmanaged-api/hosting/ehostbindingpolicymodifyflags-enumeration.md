---
description: "Learn more about: EHostBindingPolicyModifyFlags Enumeration"
title: "EHostBindingPolicyModifyFlags Enumeration"
ms.date: "03/30/2017"
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
---
# EHostBindingPolicyModifyFlags Enumeration

Allows the host to specify the type of redirection the common language runtime (CLR) should perform when applying policy modifications from a source assembly to a target assembly.  
  
## Syntax  
  
```cpp  
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

 The [ICLRHostBindingPolicyManager::ModifyApplicationPolicy](iclrhostbindingpolicymanager-modifyapplicationpolicy-method.md) method takes a parameter of type `EHostBindingPolicyModifyFlags`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRHostBindingPolicyManager Interface](iclrhostbindingpolicymanager-interface.md)
- [Hosting Enumerations](hosting-enumerations.md)
