---
description: "Learn more about: IMetaDataImport::GetMemberRefProps Method"
title: "IMetaDataImport::GetMemberRefProps Method"
ms.date: "03/30/2017"
api_name: 
  - "IMetaDataImport.GetMemberRefProps"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "IMetaDataImport::GetMemberRefProps"
helpviewer_keywords: 
  - "GetMemberRefProps method [.NET Framework metadata]"
  - "IMetaDataImport::GetMemberRefProps method [.NET Framework metadata]"
ms.assetid: 0ea73055-ece0-4151-a094-414c88ef8941
topic_type: 
  - "apiref"
---
# IMetaDataImport::GetMemberRefProps Method

Gets metadata associated with the member referenced by the specified token.  
  
## Syntax  
  
```cpp  
HRESULT GetMemberRefProps (  
   [in]  mdMemberRef       mr,
   [out] mdToken           *ptk,
   [out] LPWSTR            szMember,
   [in]  ULONG             cchMember,
   [out] ULONG             *pchMember,
   [out] PCCOR_SIGNATURE   *ppvSigBlob,
   [out] ULONG             *pbSig
);  
```  
  
## Parameters  

 `mr`  
 [in] The MemberRef token to return associated metadata for.  
  
 `ptk`  
 [out] A TypeDef or TypeRef, or TypeSpec token that represents the class that declares the member, or a ModuleRef token that represents the module class that declares the member, or a MethodDef that represents the member.  
  
 `szMember`  
 [out] A string buffer for the member's name.  
  
 `cchMember`  
 [in] The requested size in wide characters of `szMember`.  
  
 `pchMember`  
 [out] The returned size in wide characters of `szMember`.  
  
 `ppvSibBlob`  
 [out] A pointer to the binary metadata signature for the member.  
  
 `pbSig`  
 [out] The size in bytes of `ppvSigBlob`.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** Cor.h  
  
 **Library:** Included as a resource in MsCorEE.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
