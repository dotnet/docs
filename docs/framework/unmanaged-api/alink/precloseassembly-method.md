---
title: "PreCloseAssembly Method"
ms.date: "03/30/2017"
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
author: "mairaw"
ms.author: "mairaw"
---
# PreCloseAssembly Method
Closes the assembly file. Call this method after closing all other files, but before closing the assembly file. Do not call this method for unbound modules.  
  
## Syntax  
  
```cpp  
HRESULT PreCloseAssembly(  
    mdAssembly AssemblyID  
) PURE;  
```  
  
## Parameters  
 `AssemblyID`  
 ID of the assembly.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h.  
  
## See also

- [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)
- [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)
- [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
