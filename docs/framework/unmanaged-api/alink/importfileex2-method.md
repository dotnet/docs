---
title: "ImportFileEx2 Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ImportFileEx2 Method
Imports assemblies and unbound modules. This method is like [ImportFile Method](../../../../docs/framework/unmanaged-api/alink/importfile-method.md), but works even if the file being imported does not exist on disk.  
  
## Syntax  
  
```  
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
  
#### Parameters  
 `pszFilename`  
 Name of file to be imported.  
  
 `pszTargetName`  
 Optional name of target file.  
  
 `pAssemblyScopeIn`  
 Optional import scope [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md) interface.  
  
 `fSmartImport`  
 If TRUE, ImportTypes is used, otherwise importing must be performed manually.  
  
 `dwOpenFlags`  
 Flags to be passed along to [OpenScope Method](../../../../docs/framework/unmanaged-api/metadata/imetadatadispenser-openscope-method.md).  
  
 `pImportToken`  
 Receives unique ID for the assembly or file.  
  
 `ppAssemblyScope`  
 Receives assembly import scope [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md) interface. Can be NULL if the file is not an assembly.  
  
 `pdwCountOfScopes`  
 Receives the number of files and/or scopes imported.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h.  
  
## See Also  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
