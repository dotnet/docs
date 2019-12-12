---
title: "IMetaDataImport::GetMemberProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.GetMemberProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetMemberProps"
helpviewer_keywords: 
  - "IMetaDataImport::GetMemberProps method [.NET Framework metadata]"
  - "GetMemberProps method [.NET Framework metadata]"
ms.assetid: 42790918-4142-4938-b8f4-a56979a55846
topic_type: 
  - "apiref"
---
# IMetaDataImport::GetMemberProps Method
Gets information stored in the metadata for a specified member definition, including the name, binary signature, and relative virtual address, of the <xref:System.Type> member referenced by the specified metadata token. This is a simple helper method: if *mb* is a MethodDef, then **GetMethodProps** is called; if *mb* is a FieldDef, then **GetFieldProps** is called. See these other methods for details. 
  
## Syntax  
  
```cpp  
HRESULT GetMemberProps (  
   [in]  mdToken           mb,   
   [out] mdTypeDef         *pClass,  
   [out] LPWSTR            szMember,   
   [in]  ULONG             cchMember,   
   [out] ULONG             *pchMember,   
   [out] DWORD             *pdwAttr,  
   [out] PCCOR_SIGNATURE   *ppvSigBlob,   
   [out] ULONG             *pcbSigBlob,   
   [out] ULONG             *pulCodeRVA,   
   [out] DWORD             *pdwImplFlags,   
   [out] DWORD             *pdwCPlusTypeFlag,   
   [out] UVCP_CONSTANT     *ppValue,  
   [out] ULONG             *pcchValue  
);  
```  
  
## Parameters  
 `mb`  
 [in] The token that references the member to get the associated metadata for.  
  
 `pClass`  
 [out] A pointer to the metadata token that represents the class of the member.  
  
 `szMember`  
 [out] The name of the member.  
  
 `cchMember`  
 [in] The size in wide characters of the `szMember` buffer.  
  
 `pchMember`  
 [out] The size in wide characters of the returned name.  
  
 `pdwAttr`  
 [out] Any flag values applied to the member.  
  
 `ppvSigBlob`  
 [out] A pointer to the binary metadata signature of the member.  
  
 `pcbSigBlob`  
 [out] The size in bytes of `ppvSigBlob`.  
  
 `pulCodeRVA`  
 [out] A pointer to the relative virtual address of the member.  
  
 `pdwImplFlags`  
 [out] Any method implementation flags associated with the member.  
  
 `pdwCPlusTypeFlag`  
 [out] A flag that marks a <xref:System.ValueType>. It is one of the `ELEMENT_TYPE_*` values.
  
 `ppValue`  
 [out] A constant string value returned by this member.  
  
 `pcchValue`  
 [out] The size in characters of `ppValue`, or zero if `ppValue` does not hold a string.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport-interface.md)
- [IMetaDataImport2 Interface](../../../../docs/framework/unmanaged-api/metadata/imetadataimport2-interface.md)
