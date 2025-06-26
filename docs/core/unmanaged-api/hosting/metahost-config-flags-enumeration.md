---
description: "Learn more about: METAHOST_CONFIG_FLAGS Enumeration"
title: "METAHOST_CONFIG_FLAGS Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "METAHOST_CONFIG_FLAGS"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "METAHOST_CONFIG_FLAGS"
helpviewer_keywords: 
  - "METAHOST_CONFIG_FLAGS enumeration [.NET Framework hosting]"
ms.assetid: 6f1e389f-ed99-4d6a-a0ba-72d7d869a01d
topic_type: 
  - "apiref"
---
# METAHOST_CONFIG_FLAGS Enumeration

Describes the possible flags returned in the `pdwConfigFlags` parameter of the [ICLRMetaHostPolicy::GetRequestedRuntime](iclrmetahostpolicy-getrequestedruntime-method.md) method, indicating the presence and setting of the `useLegacyV2RuntimeActivationPolicy` attribute in the [\<startup> element](../../configure-apps/file-schema/startup/startup-element.md) of the configuration file.  
  
## Syntax  
  
```cpp  
typedef enum {  
    METAHOST_CONFIG_FLAGS_LEGACY_V2_ACTIVATION_POLICY_UNSET  = 0x00,  
    METAHOST_CONFIG_FLAGS_LEGACY_V2_ACTIVATION_POLICY_TRUE   = 0x01,  
    METAHOST_CONFIG_FLAGS_LEGACY_V2_ACTIVATION_POLICY_FALSE  = 0x02,  
    METAHOST_CONFIG_FLAGS_LEGACY_V2_ACTIVATION_POLICY_MASK   = 0x03  
} METAHOST_CONFIG_FLAGS;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`METAHOST_CONFIG_FLAGS_LEGACY_V2_ACTIVATION_POLICY_UNSET`|The `useLegacyV2RuntimeActivationPolicy` attribute was not present in the [\<startup> Element](../../configure-apps/file-schema/startup/startup-element.md).|  
|`METAHOST_CONFIG_FLAGS_LEGACY_V2_ACTIVATION_POLICY_TRUE`|The `useLegacyV2RuntimeActivationPolicy` attribute was present and set to `true`.|  
|`METAHOST_CONFIG_FLAGS_LEGACY_V2_ACTIVATION_POLICY_FALSE`|The `useLegacyV2RuntimeActivationPolicy` attribute was present and set to `false`.|  
|`METAHOST_CONFIG_FLAGS_LEGACY_V2_ACTIVATION_POLICY_MASK`|Apply this mask to the value returned in `pdwConfigFlags` to get the values relevant to `useLegacyV2RuntimeActivationPolicy`.|  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Metahost.h  
  
 **Library:** Included as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See also

- [Hosting Enumerations](hosting-enumerations.md)
- [GetRequestedRuntime Method](iclrmetahostpolicy-getrequestedruntime-method.md)
- [\<startup> Element](../../configure-apps/file-schema/startup/startup-element.md)
