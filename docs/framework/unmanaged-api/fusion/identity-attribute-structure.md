---
title: "IDENTITY_ATTRIBUTE Structure"
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
  - "IDENTITY_ATTRIBUTE"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IDENTITY_ATTRIBUTE"
helpviewer_keywords: 
  - "IDENTITY_ATTRIBUTE structure [.NET Framework fusion]"
ms.assetid: 1ee7c434-9681-4fa8-badd-652cb1a9742b
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IDENTITY_ATTRIBUTE Structure
Contains metadata attribute information about an [IDefinitionIdentity](../../../../docs/framework/unmanaged-api/fusion/idefinitionidentity-interface.md) instance.  
  
## Syntax  
  
```  
typedef struct _IDENTITY_ATTRIBUTE {  
    LPCWSTR  pszNamespace;  
    LPCWSTR  pszName;  
    LPCWSTR  pszValue;  
} IDENTITY_ATTRIBUTE;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`pszNamespace`|A pointer to a null-terminated character string that contains the namespace the attribute is in.|  
|`pszName`|A pointer to a null-terminated character string that contains the name of the attribute.|  
|`pszValue`|A pointer to a null-terminated character string that contains the value of the attribute.|  
  
## Remarks  
 The `IDENTITY_ATTRIBUTE` structure contains three pointers to null-terminated character strings. These three strings describe one attribute.  
  
 An instance of an `IDENTITY_ATTRIBUTE` structure is associated with an instance of an [IDENTITY_ATTRIBUTE_BLOB](../../../../docs/framework/unmanaged-api/fusion/identity-attribute-blob-structure.md) structure. The `IDENTITY_ATTRIBUTE` structure contains the actual strings, and the corresponding `IDENTITY_ATTRIBUTE_BLOB` structure lists the offsets to the three strings listed in the `IDENTITY_ATTRIBUTE` structure.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Isolation.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IDefinitionIdentity Interface](../../../../docs/framework/unmanaged-api/fusion/idefinitionidentity-interface.md)  
 [IDENTITY_ATTRIBUTE_BLOB Structure](../../../../docs/framework/unmanaged-api/fusion/identity-attribute-blob-structure.md)  
 [Fusion Structures](../../../../docs/framework/unmanaged-api/fusion/fusion-structures.md)
