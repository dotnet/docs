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
helpviewer_keywords:
  - "ResetEnum method [.NET Framework metadata]"
  - "IMetaDataImport::ResetEnum method [.NET Framework metadata]"
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

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
