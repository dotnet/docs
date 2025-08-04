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
  - "IMetaDataImport::CountEnum method [.NET metadata]"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
