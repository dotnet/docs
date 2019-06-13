---
title: "CorFileFlags Enumeration"
ms.date: "03/30/2017"
api_name: 
  - "CorFileFlags"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CorFileFlags"
helpviewer_keywords: 
  - "CorFileFlags enumeration [.NET Framework metadata]"
ms.assetid: d16703fd-518f-412e-92cb-74433d11032e
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# CorFileFlags Enumeration
Contains values that describe the type of file defined in a call to [IMetaDataAssemblyEmit::DefineFile](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-definefile-method.md).  
  
## Syntax  
  
```  
typedef enum CorFileFlags {  
  
    ffContainsMetaData      =   0x0000,  
    ffContainsNoMetaData    =   0x0001  
  
} CorFileFlags;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`ffContainsMetaData`|Indicates that the file is not a resource file.|  
|`ffContainsNoMetaData`|Indicates that the file, possibly a resource file, does not contain metadata.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
