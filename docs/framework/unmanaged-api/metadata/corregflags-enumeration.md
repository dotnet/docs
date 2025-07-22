---
description: "Learn more about: CorRegFlags Enumeration"
title: "CorRegFlags Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorRegFlags"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorRegFlags"
helpviewer_keywords: 
  - "CorRegFlags enumeration [.NET Framework metadata]"
ms.assetid: 8d3080ee-39fe-4c57-8950-51323632d045
topic_type: 
  - "apiref"
---
# CorRegFlags Enumeration

Provides flag values used for registration when installing a module or composite image.  
  
## Syntax  
  
```cpp  
typedef enum
{  
    regNoCopy  = 0x00000001,  
    regConfig  = 0x00000002,  
    regHasRefs = 0x00000004  
} CorRegFlags;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`regNoCopy`|Specifies that files should not be copied into the destination.|  
|`regConfig`|Specifies that the module or composite is a configuration.|  
|`regHasRefs`|Specifies that the module or composite has class references.|  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](metadata-enumerations.md)
