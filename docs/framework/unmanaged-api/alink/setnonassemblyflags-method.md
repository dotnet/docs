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
---
# SetNonAssemblyFlags Method
Sets flags that are not assembly-specific.  
  
## Syntax  
  
```cpp  
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

- [IALink Interface](ialink-interface.md)
- [IALink2 Interface](ialink2-interface.md)
- [ALink API](index.md)
