---
description: "Learn more about: ImportFileEx2 Method"
title: "ImportFileEx2 Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink2.ImportFileEx2"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ImportFileEx2"
helpviewer_keywords: 
  - "ImportFileEx2 method"
ms.assetid: 02c789fd-16fc-48c6-9619-56e87e2a37ca
topic_type: 
  - "apiref"
---
# ImportFileEx2 Method

Imports assemblies and unbound modules. This method is like [ImportFile Method](importfile-method.md), but works even if the file being imported does not exist on disk.  
  
## Syntax  
  
```cpp  
HRESULT ImportFileEx2(  
    LPCWSTR pszFilename,  
    LPCWSTR pszTargetName,  
    IMetaDataAssemblyImport* pAssemblyScopeIn,  
    BOOL fSmartImport,  
    DWORD dwOpenFlags,  
    mdToken* pImportToken,  
    IMetaDataAssemblyImport** ppAssemblyScope,  
    DWORD* pdwCountOfScopes  
) PURE;  
```  
  
## Parameters  

 `pszFilename`  
 Name of file to be imported.  
  
 `pszTargetName`  
 Optional name of target file.  
  
 `pAssemblyScopeIn`  
 Optional import scope [IMetaDataAssemblyImport Interface](../metadata/imetadataassemblyimport-interface.md) interface.  
  
 `fSmartImport`  
 If TRUE, ImportTypes is used, otherwise importing must be performed manually.  
  
 `dwOpenFlags`  
 Flags to be passed along to [OpenScope Method](../metadata/imetadatadispenser-openscope-method.md).  
  
 `pImportToken`  
 Receives unique ID for the assembly or file.  
  
 `ppAssemblyScope`  
 Receives assembly import scope [IMetaDataAssemblyImport Interface](../metadata/imetadataassemblyimport-interface.md) interface. Can be NULL if the file is not an assembly.  
  
 `pdwCountOfScopes`  
 Receives the number of files and/or scopes imported.  
  
## Return Value  

 Returns S_OK if the method succeeds.  
  
## Requirements  

 Requires alink.h.  
  
## See also

- [IALink2 Interface](ialink2-interface.md)
- [IALink Interface](ialink-interface.md)
- [ALink API](index.md)
