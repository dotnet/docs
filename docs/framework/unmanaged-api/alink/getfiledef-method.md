---
title: "GetFileDef Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink2.GetFileDef"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetFileDef"
helpviewer_keywords: 
  - "GetFileDef method"
ms.assetid: 4e3fbe6c-b82a-4181-ab17-7faa1263f5b3
topic_type: 
  - "apiref"
---
# GetFileDef Method
Retrieves the actual FileDef token used in metadata (as opposed to the token assigned by ALink).  
  
## Syntax  
  
```cpp  
HRESULT GetFileDef(  
    mdAssembly AssemblyID,  
    mdFile TargetFile,  
    mdFile* pScope  
) PURE;  
```  
  
## Parameters  
 `AssemblyID`  
 ID of the assembly.  
  
 `TargetFile`  
 Token of the added file as retrieved from AddFile Method or AddImport Method.  
  
 `pScope`  
 Receives the FileDef token.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See also

- [IALink2 Interface](ialink2-interface.md)
- [IALink Interface](ialink-interface.md)
- [ALink API](index.md)
