---
title: "CorManifestResourceFlags Enumeration"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 8
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
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
  
## See Also  
 [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
