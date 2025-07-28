---
description: "Learn more about: IMetaDataImport::GetNameFromToken Method"
title: "IMetaDataImport::GetNameFromToken Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataImport.GetNameFromToken"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataImport::GetNameFromToken"
  - "IMetaDataImport::GetNameFromToken method [.NET metadata]"
topic_type:
  - "apiref"
---
# IMetaDataImport::GetNameFromToken Method

Gets the UTF-8 name of the object referenced by the specified metadata token. This method is obsolete.

## Syntax

```cpp
HRESULT GetNameFromToken (
   [in] mdToken      tk,
   [out] MDUTF8CSTR  *pszUtf8NamePtr
);
```

## Parameters

 `tk`
 [in] The token representing the object to return the name for.

 `pszUtf8NamePtr`
 [out] A pointer to the UTF-8 object name in the heap.

## Remarks

 `GetNameFromToken` is obsolete. As an alternative, call a method to get the properties of the particular type of token required, such as `GetFieldProps` for a field or `GetMethodProps` for a method.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** Cor.h

 **Library:** CorGuids.lib

 **.NET versions:** 1.0

## See also

- [IMetaDataImport Interface](imetadataimport-interface.md)
- [IMetaDataImport2 Interface](imetadataimport2-interface.md)
