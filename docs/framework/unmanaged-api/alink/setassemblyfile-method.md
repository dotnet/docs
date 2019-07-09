---
title: "SetAssemblyFile Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink.SetAssemblyFile"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "SetAssemblyFile"
helpviewer_keywords: 
  - "SetAssemblyFile method"
ms.assetid: 3a912787-f139-43ca-a841-8bbda3107ecf
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# SetAssemblyFile Method
Assigns the name of the assembly to be built. Not for use when producing unbound modules.  
  
## Syntax  
  
```cpp  
HRESULT SetAssemblyFile(  
    LPCWSTR pszFilename,  
    IMetaDataEmit* pEmitter,  
    AssemblyFlags afFlags,  
    mdAssembly* pAssemblyID  
) PURE;  
```  
  
## Parameters  
 `pszFilename`  
 Fully qualified name of the manifest file.  
  
 `pEmitter`  
 Pointer to [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md) interface.  
  
 `afFlags`  
 Flags as defined in [AssemblyFlags Enumeration](../../../../docs/framework/unmanaged-api/metadata/assemblyflags-enumeration.md).  
  
 `pAssemblyID`  
 Pointer to ID of resulting assembly.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h.  
  
## See also

- [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)
- [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)
- [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
