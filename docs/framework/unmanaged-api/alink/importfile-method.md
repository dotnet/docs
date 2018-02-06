---
title: "ImportFile Method"
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
  - "IALink.ImportFile"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ImportFile"
helpviewer_keywords: 
  - "ImportFile method"
ms.assetid: bcbe321f-b83a-4e9a-9f10-8d913e244dc9
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ImportFile Method
Imports assemblies and unbound modules.  
  
## Syntax  
  
```  
HRESULT ImportFile(  
    LPCWSTR pszFilename,  
    LPCWSTR pszTargetName,  
    BOOL fSmartImport,  
    mdToken* pImportToken,  
    IMetaDataAssemblyImport** ppAssemblyScope,  
    DWORD* pdwCountOfScopes  
) PURE;  
```  
  
#### Parameters  
 `pszFilename`  
 Fully qualified name of file to be imported.  
  
 `pszTargetName`  
 Optional output file name that can be used to rename the file as it is linked into the assembly.  
  
 `fSmartImport`  
 If TRUE, ImportTypes is used, otherwise importing must be performed manually.  
  
 `pImportToken`  
 Pointer to token where a unique file ID will be stored. The file can be an assembly or a file.  
  
 `ppAssemblyScope`  
 Receives pointer to [IMetaDataAssemblyImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyimport-interface.md). Can be NULL if the file is not an assembly.  
  
 `pdwCountOfScopes`  
 Pointer to the count of files and/or scopes that have been imported.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See Also  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
