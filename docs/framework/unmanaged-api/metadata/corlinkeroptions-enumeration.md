---
title: "CorLinkerOptions Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorLinkerOptions"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorLinkerOptions"
helpviewer_keywords: 
  - "CorLinkerOptions enumeration [.NET Framework metadata]"
ms.assetid: a656aad6-cc7e-4994-8251-004a6a45e18f
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# CorLinkerOptions Enumeration
Specifies flags to select options for the metadata linker.  
  
## Syntax  
  
```cpp  
typedef enum CorLinkerOptions {  
    MDAssembly          = 0x00000000,  
    MDNetModule         = 0x00000001,  
} CorLinkerOptions;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`MDAssembly`|The private types and global functions are not preserved.|  
|`MDNetModule`|The private types and global functions are preserved.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
