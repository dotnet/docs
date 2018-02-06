---
title: "IMetaDataEmit::DefinePermissionSet Method"
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
  - "IMetaDataEmit.DefinePermissionSet"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataEmit::DefinePermissionSet"
helpviewer_keywords: 
  - "DefinePermissionSet method [.NET Framework metadata]"
  - "IMetaDataEmit::DefinePermissionSet method [.NET Framework metadata]"
ms.assetid: 36cffbf7-82ca-4cf9-bf60-50ab491ac2d9
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataEmit::DefinePermissionSet Method
Creates a definition for a permission set with the specified metadata signature, and gets a token to that permission set definition.  
  
## Syntax  
  
```  
HRESULT DefinePermissionSet (  
    [in]  mdToken        tk,   
    [in]  DWORD          dwAction,   
    [in]  void const     *pvPermission,   
    [in]  ULONG          cbPermission,   
    [out] mdPermission   *ppm   
);  
```  
  
#### Parameters  
 `tk`  
 [in] The object to be decorated.  
  
 `dwAction`  
 [in] A [CorDeclSecurity](../../../../docs/framework/unmanaged-api/metadata/cordeclsecurity-enumeration.md) value that specifies the type of declarative security to be used.  
  
 `pvPermission`  
 [in] The permission BLOB.  
  
 `cbPermission`  
 [in] The size, in bytes, of `pvPermission`.  
  
 `ppm`  
 [out] The returned permission token.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Used as a resource in MSCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataEmit Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit-interface.md)  
 [IMetaDataEmit2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataemit2-interface.md)
