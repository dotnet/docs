---
title: "SetNonAssemblyFlags Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink.SetNonAssemblyFlags"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SetNonAssemblyFlags"
helpviewer_keywords: 
  - "SetNonAssemblyFlags method"
ms.assetid: f8ba6fc8-f5aa-4066-ac96-56332758f5ec
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# SetNonAssemblyFlags Method
Sets flags that are not assembly-specific.  
  
## Syntax  
  
```  
HRESULT SetNonAssemblyFlags(  
    AssemblyFlags afFlags  
) PURE;  
```  
  
## Parameters  
 `afFlags`  
 ALink flags.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See also

- [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)
- [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)
- [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
