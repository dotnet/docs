---
description: "Learn more about: IMetaDataImport::EnumMembersWithName Method"
title: "IMetaDataImport::EnumMembersWithName Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.EnumMembersWithName"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::EnumMembersWithName"
  - "EnumMembersWithName method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::EnumMembersWithName Method

Enumerates MemberDef tokens representing members of the specified type with the specified name.

## Syntax

```cpp
HRESULT EnumMembersWithName (
   [in, out] HCORENUM    *phEnum,
   [in]      mdTypeDef   cl,
   [in]      LPCWSTR     szName,
   [out]     mdToken     rMembers[],
   [in]      ULONG       cMax,
   [out]     ULONG       *pcTokens
);
```

## Parameters

 `phEnum`
 [in, out] A pointer to the enumerator.

 `cl`
 [in] A TypeDef token representing the type with members to enumerate.

 `szName`
 [in] The member name that limits the scope of the enumerator.

 `rMembers`
 [out] The array used to store the MemberDef tokens.

 `cMax`
 [in] The maximum size of the `rMembers` array.

 `pcTokens`
 [out] The actual number of MemberDef tokens returned in `rMembers`.

## Remarks

 This method enumerates fields and methods, but not properties or events. Unlike [IMetaDataImport::EnumMembers](imetadataimport-enummembers-method.md), `EnumMembersWithName` discards all field and member tokens that do not have the specified name.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|`S_OK`|`EnumTypeDefs` returned successfully.|
|`S_FALSE`|There are no MemberDef tokens to enumerate. In that case, `pcTokens` is zero.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
