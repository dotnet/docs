---
description: "Learn more about: ExportTypeForwarder Method"
title: "ExportTypeForwarder Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink.ExportTypeForwarder"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ExportTypeForwarder"
helpviewer_keywords: 
  - "ExportTypeForwarder method"
ms.assetid: 55989fa9-ab43-4f08-8eb6-2eb56fa7ca76
topic_type: 
  - "apiref"
---
# ExportTypeForwarder Method

Adds a type forwarder to the type table of the given assembly.  
  
## Syntax  
  
```cpp  
HRESULT ExportTypeForwarder(  
    mdAssemblyRef   tkAssemblyRef,  
    LPCWSTR         pszTypename,  
    DWORD           dwFlags,  
    mdExportedType* pType  
) PURE;  
```  
  
## Parameters  

 `tkAssemblyRef`  
 Reference to the assembly to which the type forwarder refers.  
  
 `pszTypename`  
 Fully qualified type name to export.  
  
 `dwFlags`  
 `ComType` flags such as `tdPublic` or `tdNested`. This value may be passed to [DefineExportedType Method](../metadata/imetadataassemblyemit-defineexportedtype-method.md).  
  
 `pType`  
 Receives the token of the exported type. This is necessary only for emitting nested types.  
  
## Return Value  

 Returns S_OK if the method succeeds.  
  
## Requirements  

 Requires alink.h  
  
## See also

- [IALink Interface](ialink-interface.md)
- [IALink2 Interface](ialink2-interface.md)
- [ALink API](index.md)
