---
title: "ExportNestedType Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink.ExportNestedType"
  - "ExportNestedType"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ExportNestedType"
helpviewer_keywords: 
  - "ExportNestedType method"
ms.assetid: dec7df60-4d30-47c8-99db-72e0419e5f76
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ExportNestedType Method
Specifies nested types as exportable. The [ExportType Method](exporttype-method.md) can also export nested types, but this method is faster.  
  
## Syntax  
  
```cpp  
HRESULT ExportNestedType(  
    mdAssembly      AssemblyID,  
    mdToken         FileToken,  
    mdTypeDef       TypeToken,  
    mdExportedType  ParentType,  
    LPCWSTR         pszTypename,  
    DWORD           dwFlags,  
    mdExportedType* pType  
) PURE;   
```  
  
## Parameters  
 `AssemblyID`  
 ID of assembly to export from.  
  
 `FileToken`  
 File token or Assembly of file that defines the type to be made exportable.  
  
 `TypeToken`  
 Type token of type to be made exportable.  
  
 `ParentType`  
 Token of parent type.  
  
 `pszTypename`  
 Fully qualified type name to export.  
  
 `dwFlags`  
 `ComType` flags such as `tdPublic` or `tdNested`. This value may be passed to [DefineExportedType Method](../metadata/imetadataassemblyemit-defineexportedtype-method.md).  
  
 `pType`  
 Receives token for exported type.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See also

- [IALink Interface](ialink-interface.md)
- [IALink2 Interface](ialink2-interface.md)
- [ALink API](index.md)
