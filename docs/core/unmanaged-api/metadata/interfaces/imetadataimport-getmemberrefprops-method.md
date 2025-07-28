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
  - "IMetaDataImport::GetMemberRefProps method [.NET metadata]"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
