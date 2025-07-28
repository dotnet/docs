---
description: "Learn more about: IMetaDataImport::GetClassLayout Method"
title: "IMetaDataImport::GetClassLayout Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetClassLayout"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetClassLayout"
  - "GetClassLayout method, IMetaDataImport interface [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetClassLayout Method

Gets layout information for the class referenced by the specified TypeDef token.

## Syntax

```cpp
HRESULT GetClassLayout  (
   [in]  mdTypeDef          td,
   [out] DWORD              *pdwPackSize,
   [out] COR_FIELD_OFFSET   rFieldOffset[],
   [in]  ULONG              cMax,
   [out] ULONG              *pcFieldOffset,
   [out] ULONG              *pulClassSize
);
```

## Parameters

 `td`
 [in] The TypeDef token for the class with the layout to return.

 `pdwPackSize`
 [out] One of the values 1, 2, 4, 8, or 16, representing the pack size of the class.

 `rFieldOffset`
 [out] An array of [COR_FIELD_OFFSET](../structures/cor-field-offset-structure.md) values.

 `cMax`
 [in] The maximum size of the `rFieldOffset` array.

 `pcFieldOffset`
 [out] The number of elements returned in `rFieldOffset`.

 `pulClassSize`
 [out] The size in bytes of the class represented by `td`.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
