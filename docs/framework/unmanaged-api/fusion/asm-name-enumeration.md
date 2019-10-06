---
title: "ASM_NAME Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "ASM_NAME"
api_location: 
  - "fusion.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ASM_NAME"
helpviewer_keywords: 
  - "ASM_NAME enumeration [.NET Framework fusion]"
ms.assetid: c8b65b19-d777-428f-bc0c-0d84c78a37bc
topic_type: 
  - "apiref"
author: "rpetrusha"
ms.author: "ronpet"
---
# ASM_NAME Enumeration
Indicates the version, build, culture, signature, and so on, of the assembly whose properties will be retrieved or set by [IAssemblyName](iassemblyname-interface.md) methods.  
  
## Syntax  
  
```cpp  
typedef enum {  
  
    ASM_NAME_PUBLIC_KEY = 0,  
    ASM_NAME_PUBLIC_KEY_TOKEN,  
    ASM_NAME_HASH_VALUE,  
    ASM_NAME_NAME,  
    ASM_NAME_MAJOR_VERSION,  
    ASM_NAME_MINOR_VERSION,  
    ASM_NAME_BUILD_NUMBER,  
    ASM_NAME_REVISION_NUMBER,  
    ASM_NAME_CULTURE,  
    ASM_NAME_PROCESSOR_ID_ARRAY,  
    ASM_NAME_OSINFO_ARRAY,  
    ASM_NAME_HASH_ALGID,  
    ASM_NAME_ALIAS,  
    ASM_NAME_CODEBASE_URL,  
    ASM_NAME_CODEBASE_LASTMOD,  
    ASM_NAME_NULL_PUBLIC_KEY,  
    ASM_NAME_NULL_PUBLIC_KEY_TOKEN,  
    ASM_NAME_CUSTOM,  
    ASM_NAME_NULL_CUSTOM,   
    ASM_NAME_MVID,  
    ASM_NAME_FILE_MAJOR_VERSION,  
    ASM_NAME_FILE_MINOR_VERSION,  
    ASM_NAME_FILE_BUILD_NUMBER,  
    ASM_NAME_FILE_REVISION_NUMBER,  
    ASM_NAME_RETARGET,  
    ASM_NAME_SIGNATURE_BLOB,  
    ASM_NAME_CONFIG_MASK,  
    ASM_NAME_ARCHITECTURE,  
    ASM_NAME_MAX_PARAMS  
  
} ASM_NAME;  
```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Fusion.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [IAssemblyName Interface](iassemblyname-interface.md)
- [Fusion Enumerations](fusion-enumerations.md)
