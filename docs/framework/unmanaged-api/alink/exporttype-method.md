---
title: "ExportType Method"
ms.date: "03/30/2017"
api_name: 
  - "IALink.ExportType"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ExportType"
helpviewer_keywords: 
  - "ExportType method"
ms.assetid: 91a7ce63-f5b8-4f16-b2c4-e1d0baa88944
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ExportType Method
Specifies that a type is exportable.  
  
## Syntax  
  
```cpp  
HRESULT ExportType(  
    mdAssembly      AssemblyID,  
    mdToken         FileToken,  
    mdTypeDef       TypeToken,  
    LPCWSTR         pszTypename,  
    DWORD           dwFlags,  
    mdExportedType* pType  
) PURE;  
```  
  
## Parameters  
 `AssemblyID`  
 ID of the assembly to export from.  
  
 `FileToken`  
 File token or assembly ID of file that defines the exportable type.  
  
 `TypeToken`  
 Token of type to be made exportable.  
  
 `pszTypename`  
 Fully qualified type name to be made exportable.  
  
 `dwFlags`  
 `ComType` flags such as `tdPublic` or `tdNested`. This parameter may be passed to [DefineExportedType Method](../metadata/imetadataassemblyemit-defineexportedtype-method.md).  
  
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
