---
description: "Learn more about: CLRDataExceptionSameFlag Enumeration"
title: "CLRDataExceptionSameFlag Enumeration"
ms.date: "07/03/2024"
api_name:
  - "CLRDataExceptionSameFlag"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRDataExceptionSameFlag"
helpviewer_keywords:
  - "CLRDataExceptionSameFlag enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# CLRDataExceptionSameFlag Enumeration

Indicates how exception states should match against system records.

## Syntax

```cpp
typedef enum CLRDataExceptionSameFlag {
    CLRDATA_EXSAME_SECOND_CHANCE  = 0x00000000,
    CLRDATA_EXSAME_FIRST_CHANCE   = 0x00000001
} CLRDataExceptionSameFlag;
```

## Members

|Member|Value|Description|
|------------|-----------------|-----------------|
|`CLRDATA_EXSAME_SECOND_CHANGE`|0x0|The exception should match on second chance.|
|`CLRDATA_EXSAME_FIRST_CHANCE`|0x1|The exception should match on first chance..|

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
