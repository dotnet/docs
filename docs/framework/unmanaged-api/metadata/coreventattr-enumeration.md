---
title: "CorEventAttr Enumeration"
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
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CorEventAttr Enumeration
Contains values that describe the metadata of an event.  
  
## Syntax  
  
```  
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
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorHdr.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [Metadata Enumerations](../../../../docs/framework/unmanaged-api/metadata/metadata-enumerations.md)
