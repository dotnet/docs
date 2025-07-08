---
description: "Learn more about: CLRDataByNameFlag Enumeration"
title: "CLRDataByNameFlag Enumeration"
ms.date: "07/01/2024"
api_name:
  - "CLRDataByNameFlag"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRDataByNameFlag"
helpviewer_keywords:
  - "CLRDataByNameFlag enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# CLRDataByNameFlag Enumeration

Indicates how names should match in a search.

## Syntax

```cpp
typedef enum CLRDataByNameFlag {
    CLRDATA_BYNAME_CASE_SENSITIVE           = 0x00000000,
    CLRDATA_BYNAME_CASE_INSENSITIVE         = 0x00000001
} CLRDataByNameFlag;
```

## Members

|Member|Value|Description|
|------------|-----------------|-----------------|
|`CLRDATA_BYNAME_CASE_SENSITIVE`|0x0|Names should match in a case sensitive manner.|
|`CLRDATA_BYNAME_CASE_INSENSITIVE`|0x1|Names should match in a case insensitive manner.|

## Remarks

This enumeration lives inside the runtime and is not exposed through any headers or library files. To use it, define the enumeration as specified above.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging Enumerations](debugging-enumerations.md)
- [Debugging](index.md)
