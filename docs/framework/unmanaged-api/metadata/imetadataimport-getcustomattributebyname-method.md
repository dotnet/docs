---
title: "IMetaDataImport::GetCustomAttributeByName Method"
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
  - "IMetaDataImport.GetCustomAttributeByName"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetCustomAttributeByName"
helpviewer_keywords: 
  - "IMetaDataImport::GetCustomAttributeByName method [.NET Framework metadata]"
  - "GetCustomAttributeByName method [.NET Framework metadata]"
ms.assetid: 909aa530-2e3b-4d0a-a38a-a2750e535d7d
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::GetCustomAttributeByName Method
Gets the custom attribute, given its name and owner.  
  
## Syntax  
  
```  
HRESULT GetCustomAttributeByName (  
   [in]  mdToken          tkObj,  
   [in]  LPCWSTR          szName,  
   [out] const void       **ppData,  
   [out] ULONG            *pcbData  
);  
```  
  
#### Parameters  
 `tkObj`  
 [in] A metadata token representing the object that owns the custom attribute.  
  
 `szName`  
 [in] The name of the custom attribute.  
  
 `ppData`  
 [out] A pointer to an array of data that is the value of the custom attribute.  
  
 `pcbData`  
 [out] The size in bytes of the data returned in *`ppData`.  
  
## Remarks  
 It is legal to define multiple custom attributes for the same owner; they may even have the same name. However, `GetCustomAttributeByName` returns only one instance. (`GetCustomAttributeByName` returns the first instance that it encounters.) To find all instances of a custom attribute, call the [IMetaDataImport::EnumCustomAttributes](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-enumcustomattributes-method.md) method.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
