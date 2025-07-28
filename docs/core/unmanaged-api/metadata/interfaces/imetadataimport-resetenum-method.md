---
description: "Learn more about: IMetaDataImport::ResetEnum Method"
title: "IMetaDataImport::ResetEnum Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.ResetEnum"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::ResetEnum"
  - "IMetaDataImport::ResetEnum method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::ResetEnum Method

Resets the specified enumerator to the specified position.

## Syntax

```cpp
HRESULT ResetEnum (
   [in] HCORENUM    hEnum,
   [in] ULONG       ulPos
);
```

## Parameters

 `hEnum`
 [in] The enumerator to reset.

 `ulPos`
 [in] The new position at which to place the enumerator.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
