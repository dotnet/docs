---
title: "EmitInternalExportedTypes Method"
ms.date: "03/30/2017"
api_name: 
  - "EmitInternalExportedTypes"
  - "IALink2.EmitInternalExportedTypes"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EmitInternalExportedTypes"
helpviewer_keywords: 
  - "EmitInternalExportedTypes method"
ms.assetid: 28c8b00d-2c14-40b4-aed5-a1db0e2428eb
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# EmitInternalExportedTypes Method
Emits types added to the assembly. Call this method after known internal types have been added.  
  
## Syntax  
  
```cpp  
HRESULT EmitInternalExportedTypes(  
    mdAssembly AssemblyID  
) PURE;  
```  
  
## Parameters  
 `AssemblyID`  
 ID of assembly.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See also

- [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)
- [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)
- [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
