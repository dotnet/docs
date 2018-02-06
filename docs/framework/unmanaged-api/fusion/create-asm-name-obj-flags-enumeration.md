---
title: "CREATE_ASM_NAME_OBJ_FLAGS Enumeration"
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
  - "CREATE_ASM_NAME_OBJ_FLAGS"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CREATE_ASM_NAME_OBJ_FLAGS"
helpviewer_keywords: 
  - "CREATE_ASM_NAME_OBJ_FLAGS enumeration [.NET Framework fusion]"
ms.assetid: a5ed2fd0-c7d2-4603-aaca-5d0caad92675
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CREATE_ASM_NAME_OBJ_FLAGS Enumeration
Specifies the attributes of an [IAssemblyName Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md) object when it is constructed by the [CreateAssemblyNameObject](../../../../docs/framework/unmanaged-api/fusion/createassemblynameobject-function.md) function.  
  
## Syntax  
  
```  
typedef enum {  
  
    CANOF_PARSE_DISPLAY_NAME            = 0x1,  
    CANOF_SET_DEFAULT_VALUES            = 0x2,  
    CANOF_VERIFY_FRIEND_ASSEMBLYNAME    = 0x4,  
    CANOF_PARSE_FRIEND_DISPLAY_NAME     =   
        CANOF_PARSE_DISPLAY_NAME | CANOF_VERIFY_FRIEND_ASSEMBLYNAME  
  
} CREATE_ASM_NAME_OBJ_FLAGS;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`CANOF_PARSE_DISPLAY_NAME`|Indicates that the parameter passed is a textual identity.|  
|`CANOF_SET_DEFAULT_VALUES`|Sets a few default values.|  
|`CANOF_VERIFY_FRIEND_ASSEMBLYNAME`|Verifies the friend assembly rule (only name and public key). This member is for internal use only.|  
|`CANOF_PARSE_FRIEND_DISPLAY_NAME`|A combination of the `CANOF_PARSE_DISPLAY_NAME` and `CANOF_VERIFY_FRIEND_ASSEMBLYNAME` flags. This member is for internal use only.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [IAssemblyName Interface](../../../../docs/framework/unmanaged-api/fusion/iassemblyname-interface.md)  
 [CreateAssemblyNameObject Function](../../../../docs/framework/unmanaged-api/fusion/createassemblynameobject-function.md)  
 [Fusion Enumerations](../../../../docs/framework/unmanaged-api/fusion/fusion-enumerations.md)
