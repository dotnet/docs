---
description: "Learn more about: CorNativeLinkFlags Enumeration"
title: "CorNativeLinkFlags Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorNativeLinkFlags"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorNativeLinkFlags"
helpviewer_keywords: 
  - "CorNativeLinkFlags enumeration [.NET Framework metadata]"
ms.assetid: 8027df7c-cfad-4724-bda0-7538d9519070
topic_type: 
  - "apiref"
---
# CorNativeLinkFlags Enumeration

Provides flag values used by the linker when linking native code.  
  
## Syntax  
  
```cpp  
typedef enum  
{  
    nlfNone         = 0x00,  
    nlfLastError    = 0x01,  
    nlfNoMangle     = 0x02,  
    nlfMaxValue     = 0x03  
} CorNativeLinkFlags;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`nlfNone`|Indicates no flags.|  
|`nlfLastError`|Indicates a `setLastError` keyword.|  
|`nlfNoMangle`|Indicates a `nomangle` keyword.|  
|`nlfMaxValue`|Not used.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
