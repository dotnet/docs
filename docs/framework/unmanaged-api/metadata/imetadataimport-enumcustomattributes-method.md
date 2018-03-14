---
title: "IMetaDataImport::EnumCustomAttributes Method"
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
  - "IMetaDataImport.EnumCustomAttributes"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::EnumCustomAttributes"
helpviewer_keywords: 
  - "EnumCustomAttributes method [.NET Framework metadata]"
  - "IMetaDataImport::EnumCustomAttributes method [.NET Framework metadata]"
ms.assetid: 798513a0-68b1-4d04-bc5b-782a4445ea68
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::EnumCustomAttributes Method
Enumerates custom attribute-definition tokens associated with the specified type or member.  
  
## Syntax  
  
```  
HRESULT EnumCustomAttributes (   
   [in, out] HCORENUM      *phEnum,  
   [in]  mdToken            tk,   
   [in]  mdToken            tkType,   
   [out] mdCustomAttribute  rCustomAttributes[],   
   [in]  ULONG              cMax,  
   [out, optional] ULONG   *pcCustomAttributes  
);  
```  
  
#### Parameters  
 `phEnum`  
 [in, out] A pointer to the returned enumerator.  
  
 `tk`  
 [in] A token for the scope of the enumeration, or zero for all custom attributes.  
  
 `tkType`  
 [in] A token for the constructor of the type of the attributes to be enumerated, or `null` for all types.  
  
 `rCustomAttributes`  
 [out] An array of custom attribute tokens.  
  
 `cMax`  
 [in] The maximum size of the `rCustomAttributes` array.  
  
 `pcCustomAttributes`  
 [out, optional] The actual number of token values returned in `rCustomAttributes`.  
  
## Return Value  
  
|HRESULT|Description|  
|-------------|-----------------|  
|`S_OK`|`EnumCustomAttributes` returned successfully.|  
|`S_FALSE`|There are no custom attributes to enumerate. In that case, `pcCustomAttributes` is zero.|  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
