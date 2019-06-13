---
title: "CorSaveSize Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorSaveSize"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorSaveSize"
helpviewer_keywords: 
  - "CorSaveSize enumeration [.NET Framework metadata]"
ms.assetid: eb95ce39-5688-43c1-a34d-578794b32faa
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# CorSaveSize Enumeration
Contains values indicating the level of precision required when querying for the size of a save operation.  
  
## Syntax  
  
```  
typedef enum CorSaveSize {  
    cssAccurate                = 0x0000,   
    cssQuick                   = 0x0001,   
    cssDiscardTransientCAs     = 0x0002  
} CorSaveSize;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`cssAccurate`|Specifies that the return value should be exact.|  
|`cssQuick`|Specifies that the return value should be estimated.|  
|`cssDiscardTransientCAs`|Specifies that discardable types should be removed.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **Library:** Used as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
