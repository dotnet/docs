---
description: "Learn more about: IMetaDataImport::CloseEnum Method"
title: "IMetaDataImport::CloseEnum Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.CloseEnum"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::CloseEnum"
  - "CloseEnum method, IMetaDataImport interface [.NET Framework metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::CloseEnum Method

Closes the enumerator that is identified by the specified handle.

## Syntax

```cpp
void CloseEnum (
   [in] HCORENUM hEnum
);
```

## Parameters

 `hEnum`
 [in] The handle for the enumerator to close.

## Remarks

 The handle specified by `hEnum` is obtained from a previous `Enum`*Name* call (for example, [IMetaDataImport::EnumTypeDefs](imetadataimport-enumtypedefs-method.md)).

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** Included as a resource in MsCorEE.dll

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
