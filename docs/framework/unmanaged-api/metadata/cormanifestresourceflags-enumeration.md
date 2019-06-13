---
title: "CorManifestResourceFlags Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorManifestResourceFlags"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorManifestResourceFlags"
helpviewer_keywords: 
  - "CorManifestResourceFlags enumeration [.NET Framework metadata]"
ms.assetid: 1b0306b7-622b-4b57-8edc-3c713bb147ae
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# CorManifestResourceFlags Enumeration
Indicates the visibility of resources encoded in an assembly manifest.  
  
## Syntax  
  
```  
typedef enum CorManifestResourceFlags {  
  
    mrVisibilityMask        =   0x0007,  
    mrPublic                =   0x0001,  
    mrPrivate               =   0x0002  
  
} CorManifestResourceFlags;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`mrVisibilityMask`|Reserved.|  
|`mrPublic`|The resources are public.|  
|`mrPrivate`|The resources are private.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
