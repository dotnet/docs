---
title: "IMetaDataImport::GetCustomAttributeProps Method"
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
  - "IMetaDataImport.GetCustomAttributeProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetCustomAttributeProps"
helpviewer_keywords: 
  - "GetCustomAttributeProps method [.NET Framework metadata]"
  - "IMetaDataImport::GetCustomAttributeProps method [.NET Framework metadata]"
ms.assetid: 6eefb243-a281-41c1-bcdc-7e17513bc446
topic_type: 
  - "apiref"
caps.latest.revision: 14
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::GetCustomAttributeProps Method
Gets the value of the custom attribute, given its metadata token.  
  
## Syntax  
  
```  
HRESULT GetCustomAttributeProps (  
   [in]            mdCustomAttribute   cv,  
   [out, optional] mdToken             *ptkObj,  
   [out, optional] mdToken             *ptkType,  
   [out, optional] void const          **ppBlob,  
   [out, optional] ULONG               *pcbSize  
);  
```  
  
#### Parameters  
 `cv`  
 [in] A metadata token that represents the custom attribute to be retrieved.  
  
 `ptkObj`  
 [out, optional] A metadata token representing the object that the custom attribute modifies. This value can be any type of metadata token except `mdCustomAttribute`.  
  
 `ptkType`  
 [out, optional] An `mdMethodDef` or `mdMemberRef` metadata token representing the <xref:System.Type> of the returned custom attribute.  
  
 `ppBlob`  
 [out, optional] A pointer to an array of data that is the value of the custom attribute.  
  
 `pcbSize`  
 [out, optional] The size in bytes of the data returned in *`ppBlob`.  
  
## Remarks  
 A custom attribute is stored as an array of data, the format which is understood by the metadata engine.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
