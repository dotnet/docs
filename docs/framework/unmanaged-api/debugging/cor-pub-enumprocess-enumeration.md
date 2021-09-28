---
description: "Learn more about: COR_PUB_ENUMPROCESS Enumeration"
title: "COR_PUB_ENUMPROCESS Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "COR_PUB_ENUMPROCESS"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "COR_PUB_ENUMPROCESS"
helpviewer_keywords: 
  - "COR_PUB_ENUMPROCESS enumeration [.NET Framework debugging]"
ms.assetid: 5d3ada6e-feea-47da-a7ed-b664107c137f
topic_type: 
  - "apiref"
---
# COR_PUB_ENUMPROCESS Enumeration

Identifies the type of process to be enumerated.  
  
## Syntax  
  
```cpp  
typedef enum {  
    COR_PUB_MANAGEDONLY    = 0x00000001  
} COR_PUB_ENUMPROCESS;  
```  
  
## Members  
  
|Member name|Description|  
|-----------------|-----------------|  
|`COR_PUB_MANAGEDONLY`|A managed process.|  
  
## Remarks  

 The current version of the unmanaged debugging API enumerates only managed processes.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Debugging Enumerations](debugging-enumerations.md)
