---
description: "Learn more about: CorEventAttr Enumeration"
title: "CorEventAttr Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorEventAttr"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorEventAttr"
helpviewer_keywords: 
  - "CorEventAttr enumeration [.NET Framework metadata]"
ms.assetid: dc2b3281-3820-487e-930d-350b66dc6417
topic_type: 
  - "apiref"
---
# CorEventAttr Enumeration

Contains values that describe the metadata of an event.  
  
## Syntax  
  
```cpp  
typedef enum CorEventAttr {  
  
    evSpecialName           =   0x0200,  
  
    evReservedMask          =   0x0400,  
    evRTSpecialName         =   0x0400,  
  
} CorEventAttr;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`evSpecialName`|Specifies that the event is special, and that its name describes how.|  
|`evReservedMask`|Reserved for internal use by the common language runtime.|  
|`evRTSpecialName`|Specifies that the common language runtime should check the encoding of the event name.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
