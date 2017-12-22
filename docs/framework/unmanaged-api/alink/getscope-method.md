---
title: "GetScope Method1"
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
  - "IALink.GetScope"
api_location: 
  - "alink.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "GetScope"
helpviewer_keywords: 
  - "GetScope method"
ms.assetid: e1555328-2c71-4ece-b357-9eb6d3a8efc4
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# GetScope Method1
Gets an import scope.  
  
## Syntax  
  
```  
HRESULT GetScope(  
    mdAssembly AssemblyID,  
    mdToken FileToken,  
    DWORD dwScope,  
    IMetaDataImport** ppImportScope  
) PURE;  
```  
  
#### Parameters  
 `AssemblyID`  
 Unique ID of assembly to import to.  
  
 `FileToken`  
 Unique ID of the file to import from.  
  
 `dwScope`  
 Zero-based scope to import.  
  
 `ppImportScope`  
 Receives [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md) interface for the scope.  
  
## Return Value  
 Returns S_OK if the method succeeds.  
  
## Requirements  
 Requires alink.h  
  
## See Also  
 [IALink Interface](../../../../docs/framework/unmanaged-api/alink/ialink-interface.md)  
 [IALink2 Interface](../../../../docs/framework/unmanaged-api/alink/ialink2-interface.md)  
 [ALink API](../../../../docs/framework/unmanaged-api/alink/index.md)
