---
title: "IMetaDataImport::GetClassLayout Method"
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
  - "IMetaDataImport.GetClassLayout"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetClassLayout"
helpviewer_keywords: 
  - "IMetaDataImport::GetClassLayout method [.NET Framework metadata]"
  - "GetClassLayout method, IMetaDataImport interface [.NET Framework metadata]"
ms.assetid: 8f35414d-f40b-4b99-8768-9adb675c622a
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::GetClassLayout Method
Gets layout information for the class referenced by the specified TypeDef token.  
  
## Syntax  
  
```  
HRESULT GetClassLayout  (   
   [in]  mdTypeDef          td,   
   [out] DWORD              *pdwPackSize,  
   [out] COR_FIELD_OFFSET   rFieldOffset[],  
   [in]  ULONG              cMax,  
   [out] ULONG              *pcFieldOffset,  
   [out] ULONG              *pulClassSize  
);  
```  
  
#### Parameters  
 `td`  
 [in] The TypeDef token for the class with the layout to return.  
  
 `pdwPackSize`  
 [out] One of the values 1, 2, 4, 8, or 16, representing the pack size of the class.  
  
 `rFieldOffset`  
 [out] An array of [COR_FIELD_OFFSET](../../../../docs/framework/unmanaged-api/metadata/cor-field-offset-structure.md) values.  
  
 `cMax`  
 [in] The maximum size of the `rFieldOffset` array.  
  
 `pcFieldOffset`  
 [out] The number of elements returned in `rFieldOffset`.  
  
 `pulClassSize`  
 [out] The size in bytes of the class represented by `td`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
