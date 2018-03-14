---
title: "CLR_DEBUGGING_VERSION Structure"
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
  - "CLR_DEBUGGING_VERSION"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CLR_DEBUGGING_VERSION"
helpviewer_keywords: 
  - "CLR_DEBUGGING_VERSION structure [.NET Framework debugging]"
ms.assetid: 4d821186-3ddf-405a-ac44-d79438a9f7f3
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CLR_DEBUGGING_VERSION Structure
Defines the product version of the common language runtime (CLR) for debugging purposes.  
  
## Syntax  
  
```  
Typedef struct _CLR_DEBUGGING_VERSION  
{  
WORD wStructVersion;  
WORD wMajor;   
WORD wMinor;  
WORD wBuild;  
WORD wRevision;  
}  CLR_DEBUGGING_VERSION;  
```  
  
## Members  
  
|Member|Description|  
|------------|-----------------|  
|`wStructVersion`|The structure version number|  
|`wMajor`|The major version number.|  
|`wMinor`|The minor version number.|  
|`wBuild`|The build number.|  
|`wRevision`|The revision number.|  
  
## Remarks  
 The `CLR_DEBUGGING_VERSION` structure is the same as the COR_VERSION structure, however, the `CLR_DEBUGGING_VERSION` structure provides an additional structure version field (`wStructVersion`). Currently, this field must be set to zero.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v40plus](../../../../includes/net-current-v40plus-md.md)]  
  
## See Also  
 [Debugging Structures](../../../../docs/framework/unmanaged-api/debugging/debugging-structures.md)  
 [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
