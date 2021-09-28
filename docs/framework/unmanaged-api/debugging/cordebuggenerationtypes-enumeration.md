---
description: "Learn more about: CorDebugGenerationTypes Enumeration"
title: "CorDebugGenerationTypes Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorDebugGenerationTypes"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorDebugGenerationTypes"
helpviewer_keywords: 
  - "CorDebugGenerationTypes enumeration [.NET Framework debugging]"
ms.assetid: 9f25b64f-eedd-4ae5-8b0e-cfdfb9b6c5d8
topic_type: 
  - "apiref"
---
# CorDebugGenerationTypes Enumeration

Specifies the generation of a region of memory on the managed heap.  
  
## Syntax  
  
```cpp  
typedef enum CorDebugGenerationTypes {  
    CorDebug_Gen0 = 0,  
    CorDebug_Gen1 = 1,  
    CorDebug_Gen2 = 2,  
    CorDebug_LOH  = 3,  
} CorDebugRegionTypes;  
```  
  
## Members  
  
|Member name|Description|  
|-----------------|-----------------|  
|`CorDebug_Gen0`|Generation 0.|  
|`CorDebug_Gen1`|Generation 1.|  
|`CorDebug_Gen2`|Generation 2.|  
|`CorDebug_LOH`|The large object heap.|  
  
## Remarks  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [Debugging Enumerations](debugging-enumerations.md)
