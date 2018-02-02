---
title: "ExportNestedTypeForwarder Method"
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
  - "IALink.ExportNestedTypeForwarder"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ExportNestedTypeForwarder"
helpviewer_keywords: 
  - "ExportNestedTypeForwarder method"
ms.assetid: 886ea6c5-6b26-4b88-8bf6-448d6d191950
topic_type: 
  - "apiref"
caps.latest.revision: 4
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ExportNestedTypeForwarder Method
Adds a type forwarder for a nested type to the type table of the given assembly.  
  
## Syntax  
  
```  
HRESULT ExportNestedTypeForwarder(  
    mdAssembly      AssemblyID,  
    mdToken         FileToken,  
    mdTypeDef       TypeToken,  
    mdExportedType  ParentType,  
    LPCWSTR         pszTypename,  
    DWORD           dwFlags,  
    mdExportedType* pType  
) PURE;  
```  
  
#### Parameters  
 `AssemblyID`  
 ID of the assembly to export from.  
  
 `FileToken`  
 File token or assembly ID of file that defines the type.  
  
 `TypeToken`  
 Token for the type.  
  
 `ParentType`  
 Token of parent type.  
  
 `pszTypename`  
 Fully qualified type name to export.  
  
 `dwFlags`  
 `ComType` flags such as `tdPublic` or `tdNested`.  
  
 `pType`  
 Receives token of export type. This is necessary only for emitting nested types.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See Also  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
