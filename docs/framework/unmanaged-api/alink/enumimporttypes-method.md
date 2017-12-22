---
title: "EnumImportTypes Method"
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
  - "EnumImportTypes"
  - "IALink.EnumImportTypes"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EnumImportTypes"
helpviewer_keywords: 
  - "EnumImportTypes method"
ms.assetid: 83a0e4e7-ec06-40cb-9b63-700b9695bb04
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# EnumImportTypes Method
Enumerates each type in each scope.  
  
## Syntax  
  
```  
HRESULT EnumImportTypes(  
    HALINKENUM   hEnum,  
    DWORD        dwMax,  
    mdTypeDef    aTypeDefs[],  
    DWORD*       pdwCount  
) PURE;  
```  
  
#### Parameters  
 `hEnum`  
 Handle for enumerator.  
  
 `dwMax`  
 Maximum number of types to retrieve.  
  
 `aTypeDefs`  
 Recieves type tokens, not to exceed `dwMax`.  
  
 `pdwCount`  
 Receives actual number of type in `aTypeDefs`.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See Also  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
