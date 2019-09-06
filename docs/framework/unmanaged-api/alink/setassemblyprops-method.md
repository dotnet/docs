---
title: "SetAssemblyProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink.SetAssemblyProps"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SetAssemblyProps"
helpviewer_keywords: 
  - "SetAssemblyProps method"
ms.assetid: a3d7cf29-1414-49e6-8aae-9b3283c4f5f0
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# SetAssemblyProps Method
Assigns assembly-level properties.  
  
## Syntax  
  
```cpp  
HRESULT SetAssemblyProps(  
    mdAssembly      AssemblyID,  
    mdToken         FileToken,  
    AssemblyOptions Option,  
    VARIANT         Value  
) PURE;  
```  
  
## Parameters  
 `AssemblyID`  
 ID of the assembly.  
  
 `FileToken`  
 File that defines the property. Can be NULL if `AssemblyID` does not indicate an unbound netmodule.  
  
 `Option`  
 Indicates the option to modify.  
  
 `Value`  
 New value of the option.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h.  
  
## See also

- [IALink Interface](ialink-interface.md)
- [IALink2 Interface](ialink2-interface.md)
- [ALink API](index.md)
