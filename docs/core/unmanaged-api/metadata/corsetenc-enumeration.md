---
description: "Learn more about: CorSetENC Enumeration"
title: "CorSetENC Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorSetENC"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorSetENC"
helpviewer_keywords: 
  - "CorSetENC enumeration [.NET Framework metadata]"
ms.assetid: fe4150e8-071d-43fb-8e06-c3c616dbeed2
topic_type: 
  - "apiref"
---
# CorSetENC Enumeration

Contains values used to influence behavior during the generation of metadata.  
  
## Syntax  
  
```cpp  
typedef enum CorSetENC {  
  
    MDSetENCOn                  = 0x00000001,  
    MDSetENCOff                 = 0x00000002,  
  
    MDUpdateENC                 = 0x00000001,  
    MDUpdateFull                = 0x00000002,  
    MDUpdateExtension           = 0x00000003,  
    MDUpdateIncremental         = 0x00000004,  
    MDUpdateDelta               = 0x00000005,  
    MDUpdateMask                = 0x00000007  
  
} CorSetENC;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`MDSetENCOn`|Obsolete.|  
|`MDSetENCOff`|Obsolete.|  
|`MDUpdateENC`|Indicates that whereas metadata can be updated, tokens cannot be moved.|  
|`MDUpdateFull`|Indicates that tokens can be moved during updates.|  
|`MDUpdateExtension`|Indicates that updates can consist only of additions. Tokens cannot be moved.|  
|`MDUpdateIncremental`|Indicates that compilation is incremental.|  
|`MDUpdateDelta`|Indicates that only changed metadata should be saved.|  
|`MDUpdateMask`|Includes `MDUpdateENC`, `MDUpdateFull` and `MDUpdateIncremental`.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
