---
description: "Learn more about: GetScope Method"
title: "GetScope Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink.GetScope"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetScope"
helpviewer_keywords: 
  - "GetScope method"
ms.assetid: e1555328-2c71-4ece-b357-9eb6d3a8efc4
topic_type: 
  - "apiref"
---
# GetScope Method

Gets an import scope.  
  
## Syntax  
  
```cpp  
HRESULT GetScope(  
    mdAssembly AssemblyID,  
    mdToken FileToken,  
    DWORD dwScope,  
    IMetaDataImport** ppImportScope  
) PURE;  
```  
  
## Parameters  

 `AssemblyID`  
 Unique ID of assembly to import to.  
  
 `FileToken`  
 Unique ID of the file to import from.  
  
 `dwScope`  
 Zero-based scope to import.  
  
 `ppImportScope`  
 Receives [IMetaDataImport Interface](../metadata/imetadataimport-interface.md) interface for the scope.  
  
## Return Value  

 Returns S_OK if the method succeeds.  
  
## Requirements  

 Requires alink.h  
  
## See also

- [IALink Interface](ialink-interface.md)
- [IALink2 Interface](ialink2-interface.md)
- [ALink API](index.md)
