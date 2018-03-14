---
title: "GetAssemblyRefHash Method"
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
  - "IALink.GetAssemblyRefHash"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetAssemblyRefHash"
helpviewer_keywords: 
  - "GetAssemblyRefHash method"
ms.assetid: 091a18bd-e901-46f6-b999-74d71c8a7c41
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetAssemblyRefHash Method
Retrieves a hash blob for a given assembly.  
  
## Syntax  
  
```  
HRESULT GetAssemblyRefHash(  
    mdToken FileToken,  
    const void** ppvHash,  
    DWORD* pcbHash  
) PURE;  
```  
  
#### Parameters  
 `FileToken`  
 ID of assembly to which the hash will refer.  
  
 `ppvHash`  
 Receives the resulting hash blob.  
  
 `pcbHash`  
 Receives size, in bytes, of hash blob.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See Also  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
