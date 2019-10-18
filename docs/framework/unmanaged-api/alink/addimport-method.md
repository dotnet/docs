---
title: "AddImport Method"
ms.date: "03/30/2017"
api_name: 
  - "AddImport"
  - "IALink.AddImport"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "AddImport"
helpviewer_keywords: 
  - "AddImport method"
ms.assetid: 4fedf8a0-08c8-43d0-aa00-20f2a521c991
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# AddImport Method
Adds imports to the assembly.  
  
## Syntax  
  
```cpp  
HRESULT AddImport(  
    mdAssembly      AssemblyID,  
    mdToken         ImportToken,  
    DWORD           dwFlags,  
    mdFile*         pFileToken  
) PURE;  
```  
  
## Parameters  
 `AssemblyID`  
 Unique ID of assembly to be augmented.  
  
 `ImportToken`  
 Unique ID, retrieved from [ImportFile Method](importfile-method.md), of file to be imported.  
  
 `dwFlags`  
 COM+ FileDef flags such as `ffContainsNoMetaData` and `ffWriteable`. `dwFlags` is passed to [DefineFile Method](../metadata/imetadataassemblyemit-definefile-method.md).  
  
 `pFileToken`  
 Pointer to token that receives the ID for the resulting file.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See also

- [IALink Interface](ialink-interface.md)
- [IALink2 Interface](ialink2-interface.md)
- [ALink API](index.md)
