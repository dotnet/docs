---
description: "Learn more about: CorValidatorModuleType Enumeration"
title: "CorValidatorModuleType Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorValidatorModuleType"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorValidatorModuleType"
helpviewer_keywords: 
  - "CorValidatorModuleType enumeration [.NET Framework metadata]"
ms.assetid: 748f1ab2-fbcb-4f55-89ec-8d23d81ebc80
topic_type: 
  - "apiref"
---
# CorValidatorModuleType Enumeration

Specifies the type of a module.  
  
## Syntax  
  
```cpp  
typedef enum  
{  
    ValidatorModuleTypeInvalid  = 0x0,  
    ValidatorModuleTypeMin      = 0x00000001,  
    ValidatorModuleTypePE       = 0x00000001,  
    ValidatorModuleTypeObj      = 0x00000002,  
    ValidatorModuleTypeEnc      = 0x00000003,  
    ValidatorModuleTypeIncr     = 0x00000004,  
    ValidatorModuleTypeMax      = 0x00000004  
} CorValidatorModuleType;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`ValidatorModuleTypeInvalid`|The module is an invalid type.|  
|`ValidatorModuleTypeMin`|The minimum value of the `CorValidatorModuleType` enum.|  
|`ValidatorModuleTypePE`|The module is a portable executable (PE) file.|  
|`ValidatorModuleTypeObj`|The module is a .obj file.|  
|`ValidatorModuleTypeEnc`|The module is an edit-and-continue debugger session.|  
|`ValidatorModuleTypeIncr`|The module is one that has been incrementally built.|  
|`ValidatorModuleTypeMax`|The maximum value of the `CorValidatorModuleType` enum.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
