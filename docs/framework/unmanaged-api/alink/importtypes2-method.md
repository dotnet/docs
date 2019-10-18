---
title: "ImportTypes2 Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink2.ImportTypes2"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ImportTypes2"
helpviewer_keywords: 
  - "ImportTypes2 method"
ms.assetid: 32f3ba58-9695-41e9-ba58-fd19e45ed396
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ImportTypes2 Method
Initiates the import of types. Call this method to begin importing types from each scope imported via [ImportFile Method](importfile-method.md).  
  
## Syntax  
  
```cpp  
HRESULT ImportTypes2(  
    mdAssembly AssemblyID,  
    mdToken FileToken,  
    DWORD dwScope,  
    HALINKENUM* phEnum,  
    IMetaDataImport2** ppImportScope,  
    DWORD* pdwCountOfTypes  
) PURE;  
```  
  
## Parameters  
 `AssemblyID`  
 ID of assembly into which to import.  
  
 `FileToken`  
 ID of file to from which to import.  
  
 `dwScope`  
 Zero-based scope from which to import.  
  
 `phEnum`  
 Receives enumerator handle for the types in the given scope.  
  
 `ppImportScope`  
 Optionally receives [IMetaDataImport2 Interface](../metadata/imetadataimport2-interface.md) interface.  
  
 `pdwCountOfTypes`  
 Optionally receives count of types in the specified scope.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See also

- [IALink2 Interface](ialink2-interface.md)
- [IALink Interface](ialink-interface.md)
- [ALink API](index.md)
