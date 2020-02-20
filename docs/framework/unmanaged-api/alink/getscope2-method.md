---
title: "GetScope2 Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink2.GetScope2"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetScope2"
helpviewer_keywords: 
  - "GetScope2 method"
ms.assetid: 49435665-6f5a-4acd-9034-8c9244a04a63
topic_type: 
  - "apiref"
---
# GetScope2 Method
Gets an import scope.  
  
## Syntax  
  
```cpp  
HRESULT GetScope2(  
    mdAssembly AssemblyID,  
    mdToken FileToken,  
    DWORD dwScope,  
    IMetaDataImport2** ppImportScope  
) PURE;   
```  
  
## Parameters  
 `AssemblyID`  
 ID of target assembly.  
  
 `FileToken`  
 ID of file from which to import.  
  
 `dwScope`  
 Zero-based scope to import.  
  
 `ppImportScope`  
 Receives pointer to [IMetaDataImport2 Interface](../metadata/imetadataimport2-interface.md) interface for indicated scope.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h.  
  
## See also

- [IALink2 Interface](ialink2-interface.md)
- [IALink Interface](ialink-interface.md)
- [ALink API](index.md)
