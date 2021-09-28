---
description: "Learn more about: ASM_DISPLAY_FLAGS Enumeration"
title: "ASM_DISPLAY_FLAGS Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "ASM_DISPLAY_FLAGS"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ASM_DISPLAY_FLAGS"
helpviewer_keywords: 
  - "ASM_DISPLAY_FLAGS enumeration [.NET Framework fusion]"
ms.assetid: dbade6c9-9d26-4a79-9fd2-46108edd12d7
topic_type: 
  - "apiref"
---
# ASM_DISPLAY_FLAGS Enumeration

Indicates the version, build, culture, signature, and so on, of the assembly whose display name will be retrieved by the [IAssemblyName::GetDisplayName](iassemblyname-getdisplayname-method.md) method.  
  
## Syntax  
  
```cpp  
typedef enum {  
  
    ASM_DISPLAYF_VERSION                 = 0x01,  
    ASM_DISPLAYF_CULTURE                 = 0x02,  
    ASM_DISPLAYF_PUBLIC_KEY_TOKEN        = 0x04,  
    ASM_DISPLAYF_PUBLIC_KEY              = 0x08,  
    ASM_DISPLAYF_CUSTOM                  = 0x10,  
    ASM_DISPLAYF_PROCESSORARCHITECTURE   = 0x20,  
    ASM_DISPLAYF_LANGUAGEID              = 0x40,  
    ASM_DISPLAYF_RETARGET                = 0x80,  
    ASM_DISPLAYF_CONFIG_MASK             = 0x100,  
    ASM_DISPLAYF_MVID                    = 0x200,  
    ASM_DISPLAYF_FULL                    =
                      ASM_DISPLAYF_VERSION           |
                      ASM_DISPLAYF_CULTURE           |
                      ASM_DISPLAYF_PUBLIC_KEY_TOKEN  |
                      ASM_DISPLAYF_RETARGET          |
                      ASM_DISPLAYF_PROCESSORARCHITECTURE  
  
} ASM_DISPLAY_FLAGS;  
```  
  
## Remarks  

 `ASM_DISPLAYF_FULL` reflects any changes made to the version of the [IAssemblyName](iassemblyname-interface.md) object. Do not assume that the returned value is immutable.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IAssemblyName Interface](iassemblyname-interface.md)
- [Fusion Enumerations](fusion-enumerations.md)
