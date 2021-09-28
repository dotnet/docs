---
description: "Learn more about: AddFile2 Method"
title: "AddFile2 Method"
ms.date: "03/30/2017"
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
---
# AddFile2 Method

Adds files to the assembly. Can also be used to create unbound modules.  
  
## Syntax  
  
```cpp  
HRESULT AddFile2(  
    mdAssembly AssemblyID,  
    LPCWSTR pszFilename,  
    DWORD dwFlags,  
    IMetaDataEmit2* pEmitter,  
    mdFile* pFileToken  
) PURE;  
```  
  
## Parameters  

 `AssemblyID`  
 ID for the assembly to which the file is added.  
  
 `pszFilename`  
 Name of the file to be added.  
  
 `dwFlags`  
 COM+ `FileDef` flags such as `ffContainsNoMetaData` and `ffWriteable`. `dwFlags` is passed to [DefineFile Method](../metadata/imetadataassemblyemit-definefile-method.md).  
  
 `pEmitter`  
 Interface to [IMetaDataEmit2 Interface](../metadata/imetadataemit2-interface.md) interface.  
  
 `pFileToken`  
 Receives ID for the file being added.  
  
## Return Value  

 Returns S_OK if the method succeeds.  
  
## Requirements  

 Requires alink.h.  
  
## See also

- [IALink2 Interface](ialink2-interface.md)
- [IALink Interface](ialink-interface.md)
- [ALink API](index.md)
