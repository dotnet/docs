---
title: "CVStruct Structure"
ms.date: "03/30/2017"
api_name: 
  - "CVStruct"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CVStruct"
helpviewer_keywords: 
  - "CVStruct structure [.NET Framework metadata]"
ms.assetid: e9e4e497-d5fb-464b-991c-3bdd824664fd
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# CVStruct Structure
Contains information that is used when installing a module or a composite image.  
  
## Syntax  
  
```cpp  
typedef struct {  
    short Major;  
    short Minor;  
    short Sub;  
    short Build;  
} CVStruct;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|Major|Major version build number.|  
|Minor|Minor version build number.|  
|Sub|Sub-build number.|  
|Build|Build number.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Structures](../../../../docs/framework/unmanaged-api/metadata/metadata-structures.md)
