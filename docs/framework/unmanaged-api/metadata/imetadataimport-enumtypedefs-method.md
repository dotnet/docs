---
title: "IMetaDataImport::EnumTypeDefs Method"
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
  - "IMetaDataImport.EnumTypeDefs"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumTypeDefs"
helpviewer_keywords: 
  - "EnumTypeDefs method [.NET Framework metadata]"
  - "IMetaDataImport::EnumTypeDefs method [.NET Framework metadata]"
ms.assetid: 4e508711-da92-4381-aaf8-6803075cdaa2
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::EnumTypeDefs Method
Enumerates TypeDef tokens representing all types within the current scope.  
  
## Syntax  
  
```  
HRESULT EnumTypeDefs (  
   [out] HCORENUM   *phEnum,   
   [in]  mdTypeDef  rTypeDefs[],  
   [in]  ULONG      cMax,   
   [out] ULONG      *pcTypeDefs  
);  
```  
  
#### Parameters  
 `phEnum`  
 [out] A pointer to the new enumerator. This must be NULL for the first call of this method.  
  
 `rTypeDefs`  
 [in] The array used to store the TypeDef tokens.  
  
 `cMax`  
 [in] The maximum size of the `rTypeDefs` array.  
  
 `pcTypeDefs`  
 [out] The number of TypeDef tokens returned in `rTypeDefs`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumTypeDefs` returned successfully.|  
|`S_FALSE`|There are no tokens to enumerate. In that case, `pcTypeDefs` is zero.|  
  
## Remarks  
 The TypeDef token represents a type such as a class or an interface, as well as any type added via an extensibility mechanism.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
