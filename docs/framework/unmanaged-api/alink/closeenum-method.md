---
title: "CloseEnum Method"
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
  - "CloseEnum"
  - "IALink.CloseEnum"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CloseEnum"
helpviewer_keywords: 
  - "CloseEnum method"
ms.assetid: aa4a091e-13fe-4264-91de-e12f1c767c87
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# CloseEnum Method
Closes the indicated enumeration and frees associated resources.  
  
## Syntax  
  
```  
HRESULT CloseEnum(  
    HALINKENUM hEnum  
) PURE;  
```  
  
#### Parameters  
 `hEnum`  
 Handle of enumeration to be closed.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See Also  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
