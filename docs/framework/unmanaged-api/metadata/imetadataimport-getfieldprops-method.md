---
title: "IMetaDataImport::GetFieldProps Method"
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
  - "IMetaDataImport.GetFieldProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetFieldProps"
helpviewer_keywords: 
  - "IMetaDataImport::GetFieldProps method [.NET Framework metadata]"
  - "GetFieldProps method [.NET Framework metadata]"
ms.assetid: 7b0e9b10-8cef-4ba6-8432-40bf63e65ab1
topic_type: 
  - "apiref"
caps.latest.revision: 12
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::GetFieldProps Method
Gets metadata associated with the field referenced by the specified FieldDef token.  
  
## Syntax  
  
```  
HRESULT GetFieldProps (  
   [in]  mdFieldDef        mb,   
   [out] mdTypeDef         *pClass,  
   [out] LPWSTR            szField,  
   [in]  ULONG             cchField,   
   [out] ULONG             *pchField,  
   [out] DWORD             *pdwAttr,  
   [in]  PCCOR_SIGNATURE   *ppvSigBlob,   
   [out] ULONG             *pcbSigBlob,   
   [out] DWORD             *pdwCPlusTypeFlag,   
   [out] UVCP_CONSTANT     *ppValue,  
   [out] ULONG             *pcchValue  
);  
```  
  
#### Parameters  
 `mb`  
 [in] A FieldDef token that represents the field to get associated metadata for.  
  
 `pClass`  
 [out] A pointer to a TypeDef token that represents the type of the class that the field belongs to.  
  
 `szField`  
 [out] The name of the field.  
  
 `cchField`  
 [in] The size in wide characters of the buffer for *szField*.  
  
 `pchField`  
 [out] The actual size of the returned buffer.  
  
 `pdwAttr`  
 [out] Flags associated with the field's metadata.  
  
 `ppvSigBlob`  
 [in] A pointer to the binary metadata value that describes the field.  
  
 `pcbSigBlob`  
 [out] The size in bytes of `ppvSigBlob`.  
  
 `pdwCPlusTypeFlag`  
 [out] A flag that specifies the value type of the field.  
  
 `ppValue`  
 [out] A constant value for the field.  
  
 `pcchValue`  
 [out] The size in chars of `ppValue`, or zero if no string exists.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
