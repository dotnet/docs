---
title: "GetResolutionScope Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink.GetResolutionScope"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetResolutionScope"
helpviewer_keywords: 
  - "GetResolutionScope method"
ms.assetid: 5b48ca60-dacd-44b2-9979-4a5122f00812
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# GetResolutionScope Method
Retrieves the scope of a given type.  
  
## Syntax  
  
```cpp  
HRESULT GetResolutionScope(  
    mdAssembly  AssemblyID,  
    mdToken     FileToken,  
    mdToken     TargetFile,  
    mdToken*    pScope  
) PURE;  
```  
  
## Parameters  
 `AssemblyID`  
 ID of the assembly.  
  
 `FileToken`  
 File that is in need of a reference.  
  
 `TargetFile`  
 Token of file that type is defined in, usually retrieved with [ImportFile Method](importfile-method.md).  
  
 `pScope`  
 Receives the assembly or module reference.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h.  
  
## See also

- [IALink Interface](ialink-interface.md)
- [IALink2 Interface](ialink2-interface.md)
- [ALink API](index.md)
