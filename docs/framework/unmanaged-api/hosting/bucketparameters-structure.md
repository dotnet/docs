---
title: "BucketParameters Structure"
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
  - "BucketParameters"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "BucketParameters"
helpviewer_keywords: 
  - "BucketParameters structure [.NET Framework hosting]"
ms.assetid: 9432487e-f276-45d6-9a13-9a68024dbd46
topic_type: 
  - "apiref"
caps.latest.revision: 8
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# BucketParameters Structure
Stores the type name of an event and the parameters for the current exception that is associated with the event.  
  
## Syntax  
  
```  
typedef struct _BucketParameters {  
    BOOL  fInited;                    
    WCHAR pszEventTypeName[255];      
    WCHAR pszParams[10][255];         
} BucketParameters;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`fInited`|`true`, if the rest of this structure is valid; otherwise, `false`.|  
|`pszEventTypeName`|Name of the event type.|  
|`pszParams`|An array of strings, each of which specifies a parameter for the current exception associated with the event.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** MSCorEE.idl  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Hosting Structures](../../../../docs/framework/unmanaged-api/hosting/hosting-structures.md)
