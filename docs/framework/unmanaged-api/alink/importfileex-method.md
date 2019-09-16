---
title: "ImportFileEx Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink2.ImportFileEx"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ImportFileEx"
helpviewer_keywords: 
  - "ImportFileEx method"
ms.assetid: ad276f3f-b303-46ac-97e0-66a377adaa4f
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ImportFileEx Method
Imports indicated assembly or unbound module.  
  
## Syntax  
  
```cpp  
HRESULT ImportFileEx(  
    LPCWSTR pszFilename,  
    LPCWSTR pszTargetName,  
    BOOL fSmartImport,  
    DWORD dwOpenFlags,  
    mdToken* pImportToken,  
    IMetaDataAssemblyImport** ppAssemblyScope,  
    DWORD* pdwCountOfScopes  
) PURE;  
```  
  
## Parameters  
 `pszFilename`  
 Fully qualified name of file from which to import.  
  
 `pszTargetName`  
 Optional name of target file.  
  
 `fSmartImport`  
 If TRUE, ImportTypes is used, otherwise importing must be performed manually.  
  
 `dwOpenFlags`  
 Flags to be passed along to [OpenScope Method](../metadata/imetadatadispenser-openscope-method.md).  
  
 `pImportToken`  
 Receives ID of the file being imported.  
  
 `ppAssemblyScope`  
 Receives assembly import scope [IMetaDataAssemblyImport Interface](../metadata/imetadataassemblyimport-interface.md) interface. Is set to NULL if file is not an assembly.  
  
 `pdwCountOfScopes`  
 Receives count of imported files and/or scopes.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h.  
  
## See also

- [IALink2 Interface](ialink2-interface.md)
- [IALink Interface](ialink-interface.md)
- [ALink API](index.md)
