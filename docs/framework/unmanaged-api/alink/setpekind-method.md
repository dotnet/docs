---
title: "SetPEKind Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink2.SetPEKind"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SetPEKind"
helpviewer_keywords: 
  - "SetPEKind method"
ms.assetid: 050e77ee-3014-45c0-9e29-2ebe29347b0d
topic_type: 
  - "apiref"
---
# SetPEKind Method
Determines the portable executable type, either machine-specific or machine-agnostic.  
  
## Syntax  
  
```cpp  
HRESULT SetPEKind(  
    mdAssembly AssemblyID,  
    mdToken FileToken,  
    DWORD dwPEKind,  
    DWORD dwMachine  
) PURE;   
```  
  
## Parameters  
 `AssemblyID`  
 ID of the assembly.  
  
 `FileToken`  
 Token of file for which the PE type is to be set. Can be NULL if `AssemblyID` does not indicate an unbound netmodule.  
  
 `dwPEKind`  
 The type of PE, as indicated by the [CorPEKind Enumeration](../metadata/corpekind-enumeration.md).  
  
 `dwMachine`  
 The target machine architecture, as indicated in the NT header.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h.  
  
## See also

- [GetPEKind Method](../metadata/imetadataimport2-getpekind-method.md)
- [IALink2 Interface](ialink2-interface.md)
- [IALink Interface](ialink-interface.md)
- [ALink API](index.md)
