---
description: "Learn more about: IMetaDataTables::GetUserString Method"
title: "IMetaDataTables::GetUserString Method"
ms.date: "03/30/2017"
api_name:
  - "IMetaDataTables.GetUserString"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IMetaDataTables::GetUserString"
helpviewer_keywords:
  - "IMetaDataTables::GetUserString method [.NET Framework metadata]"
  - "GetUserString method, IMetaDataTables interface [.NET Framework metadata]"
ms.assetid: 35b8f0d6-9aba-4714-adb2-62020a38fb7e
topic_type:
  - "apiref"
---

# IMetaDataTables::GetUserString Method

Gets the hard-coded string at the specified index in the string column in the current scope.

## Syntax

```cpp
HRESULT GetUserString (
    [in]  ULONG       ixUserString,
    [out] ULONG       *pcbData,
    [out] const void  **ppData
);
```

## Parameters

`ixUserString`\
[in] The index value from which the hard-coded string will be retrieved.

`pcbData`\
[out] A pointer to the size of `ppData`.

`ppData`\
[out] A pointer to a pointer to the returned string.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** Cor.h

**Library:** Used as a resource in MsCorEE.dll

**.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]

## See also

- [IMetaDataTables Interface](imetadatatables-interface.md)
- [IMetaDataTables2 Interface](imetadatatables2-interface.md)
