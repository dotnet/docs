---
title: "AddFile2 Method"
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
  - "AddFile2"
  - "IALink2.AddFile2"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "AddFile2"
helpviewer_keywords: 
  - "AddFile2 method"
ms.assetid: 03bc49bf-a89b-4fb6-a88d-97482e061195
topic_type: 
  - "apiref"
caps.latest.revision: 7
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# AddFile2 Method
Adds files to the assembly. Can also be used to create unbound modules.  
  
## Syntax  
  
```  
HRESULT AddFile2(  
    mdAssembly AssemblyID,  
    LPCWSTR pszFilename,  
    DWORD dwFlags,  
    IMetaDataEmit2* pEmitter,  
    mdFile* pFileToken  
) PURE;  
```  
  
#### Parameters  
 `AssemblyID`  
 ID for the assembly to which the file is added.  
  
 `pszFilename`  
 Name of the file to be added.  
  
 `dwFlags`  
 COM+ `FileDef` flags such as `ffContainsNoMetaData` and `ffWriteable`. `dwFlags` is passed to [DefineFile Method](../../../../docs/framework/unmanaged-api/metadata/imetadataassemblyemit-definefile-method.md).  
  
 `pEmitter`  
 Interface to [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md) interface.  
  
 `pFileToken`  
 Receives ID for the file being added.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h.  
  
## See Also  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
