---
title: "CloseAssembly Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink.CloseAssembly"
  - "CloseAssembly"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "CloseAssembly"
helpviewer_keywords: 
  - "CloseAssembly method"
ms.assetid: f66a43bc-a5c5-4190-acbe-63fd27640634
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# CloseAssembly Method
Finalizes assembly operations. Call this method before beginning a new assembly or unbound module.  
  
## Syntax  
  
```  
HRESULT CloseAssembly(  
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
  
## See also
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
