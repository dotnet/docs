---
title: "PreCloseAssembly Method"
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
  - "IALink.PreCloseAssembly"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "PreCloseAssembly"
helpviewer_keywords: 
  - "PreCloseAssembly method"
ms.assetid: 6d23ac54-15ea-4027-a172-9ebef43e8f56
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# PreCloseAssembly Method
Closes the assembly file. Call this method after closing all other files, but before closing the assembly file. Do not call this method for unbound modules.  
  
## Syntax  
  
```  
HRESULT PreCloseAssembly(  
    mdAssembly AssemblyID  
) PURE;  
```  
  
#### Parameters  
 `AssemblyID`  
 ID of the assembly.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h.  
  
## See Also  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
