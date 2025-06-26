---
description: "Learn more about: IMetaDataImport::CountEnum Method"
title: "IMetaDataImport::CountEnum Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.CountEnum"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::CountEnum"
helpviewer_keywords: 
  - "CountEnum method [.NET Framework metadata]"
  - "IMetaDataImport::CountEnum method [.NET Framework metadata]"
ms.assetid: d1de53ad-9435-4b5f-9df7-07f21210e5b5
topic_type: 
  - "apiref"
---
# IMetaDataImport::CountEnum Method

Gets the number of elements in the enumeration that was retrieved by the specified enumerator.  
  
## Syntax  
  
```cpp  
HRESULT CountEnum (  
   [in]  HCORENUM    hEnum,
   [out] ULONG       *pulCount  
);  
```  
  
## Parameters  

 `hEnum`  
 [in] The handle for the enumerator.  
  
 `pulCount`  
 [out] The number of elements enumerated.  
  
## Remarks  

 The handle specified by `hEnum` is obtained from a previous `Enum`*Name* call (for example, [IMetaDataImport::EnumTypeDefs](imetadataimport-enumtypedefs-method.md)).  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
