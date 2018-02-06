---
title: "IMetaDataImport::GetPropertyProps Method"
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
  - "IMetaDataImport.GetPropertyProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetPropertyProps"
helpviewer_keywords: 
  - "GetPropertyProps method [.NET Framework metadata]"
  - "IMetaDataImport::GetPropertyProps method [.NET Framework metadata]"
ms.assetid: dc0ff3e6-7e7d-4f6c-948d-52b28f5cb78c
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# IMetaDataImport::GetPropertyProps Method
Gets the metadata for the property represented by the specified token.  
  
## Syntax  
  
```  
HRESULT GetPropertyProps (  
   [in]  mdProperty        prop,  
   [out] mdTypeDef         *pClass,   
   [out] LPCWSTR           szProperty,   
   [in]  ULONG             cchProperty,   
   [out] ULONG             *pchProperty,   
   [out] DWORD             *pdwPropFlags,   
   [out] PCCOR_SIGNATURE   *ppvSig,   
   [out] ULONG             *pbSig,   
   [out] DWORD             *pdwCPlusTypeFlag,   
   [out] UVCP_CONSTANT     *ppDefaultValue,  
   [out] ULONG             *pcchDefaultValue,  
   [out] mdMethodDef       *pmdSetter,   
   [out] mdMethodDef       *pmdGetter,   
   [out] mdMethodDef       rmdOtherMethod[],  
   [in]  ULONG             cMax,   
   [out] ULONG             *pcOtherMethod   
);  
```  
  
#### Parameters  
 `prop`  
 [in] A token that represents the property to return metadata for.  
  
 `pClass`  
 [out] A pointer to the TypeDef token that represents the type that implements the property.  
  
 `szProperty`  
 [out] A buffer to hold the property name.  
  
 `cchProperty`  
 [in] The size in wide characters of `szProperty`.  
  
 `pchProperty`  
 [out] The number of wide characters returned in `szProperty`.  
  
 `pdwPropFlags`  
 [out] A pointer to any attribute flags applied to the property. This value is a bitmask from the [CorPropertyAttr](../../../../docs/framework/unmanaged-api/metadata/corpropertyattr-enumeration.md) enumeration.  
  
 `ppvSig`  
 [out] A pointer to the metadata signature of the property.  
  
 `pbSig`  
 [out] The number of bytes returned in `ppvSig`.  
  
 `pdwCPlusTypeFlag`  
 [out] A flag specifying the type of the constant that is the default value of the property. This value is from the CorElementType enumeration.  
  
 `ppDefaultValue`  
 [out] A pointer to the bytes that store the default value for this property.  
  
 `pcchDefaultValue`  
 [out] The size in wide characters of `ppDefaultValue`, if `pdwCPlusTypeFlag` is ELEMENT_TYPE_STRING; otherwise, this value is not relevant. In that case, the length of `ppDefaultValue` is inferred from the type that is specified by `pdwCPlusTypeFlag`.  
  
 `pmdSetter`  
 [out] A pointer to the MethodDef token that represents the set accessor method for the property.  
  
 `pmdGetter`  
 [out] A pointer to the MethodDef token that represents the get accessor method for the property.  
  
 `rmdOtherMethod`  
 [out] An array of MethodDef tokens that represent other methods associated with the property.  
  
 `cMax`  
 [in] The maximum size of the `rmdOtherMethod` array. If you do not provide an array large enough to hold all the methods, they are skipped without warning.  
  
 `pcOtherMethod`  
 [out] The number of MethodDef tokens returned in `rmdOtherMethod`.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See Also  
 [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)  
 [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
