---
title: "EmitAssembly Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink2.EmitAssembly"
  - "EmitAssembly"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "EmitAssembly"
helpviewer_keywords: 
  - "EmitAssembly method"
ms.assetid: 605ff39e-e5cc-4bff-8196-e8d68a9715b9
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# EmitAssembly Method
Creates the assembly. Call this method after all other files are closed except for the assembly file. Do not call this method when producing unbound modules.  
  
## Syntax  
  
```cpp  
HRESULT EmitAssembly(  
    mdAssembly AssemblyID  
) PURE;  
```  
  
## Parameters  
 `AssemblyID`  
 ID of the assembly.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See also

- [IALink Interface](ialink-interface.md)
- [IALink2 Interface](ialink2-interface.md)
- [ALink API](index.md)
