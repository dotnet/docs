---
description: "Learn more about: CLRDataValueFlag Enumeration"
title: "CLRDataValueFlag Enumeration"
ms.date: "07/03/2024"
api_name:
  - "CLRDataValueFlag"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRDataValueFlag"
helpviewer_keywords:
  - "CLRDataValueFlag enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# CLRDataValueFlag Enumeration

Indicates various attributes of a value.

## Syntax

```cpp
typedef enum CLRDataValueFlag {
    CLRDATA_VALUE_DEFAULT                   = 0x00000000,
    CLRDATA_VALUE_IS_PRIMITIVE              = 0x00000001,
    CLRDATA_VALUE_IS_VALUE_TYPE             = 0x00000002,
    CLRDATA_VALUE_IS_STRING                 = 0x00000004,
    CLRDATA_VALUE_IS_ARRAY                  = 0x00000008,
    CLRDATA_VALUE_IS_REFERENCE              = 0x00000010,
    CLRDATA_VALUE_IS_POINTER                = 0x00000020,
    CLRDATA_VALUE_IS_ENUM                   = 0x00000040,
    CLRDATA_VALUE_ALL_KINDS                 = 0x0000007F,

    CLRDATA_VALUE_IS_INHERITED              = 0x00000080,
    CLRDATA_VALUE_IS_LITERAL                = 0x00000100,

    CLRDATA_VALUE_FROM_INSTANCE             = 0x00000200,
    CLRDATA_VALUE_FROM_TASK_LOCAL           = 0x00000400,
    CLRDATA_VALUE_FROM_STATIC               = 0x00000800,

    CLRDATA_VALUE_ALL_LOCATIONS             = 0x00000e00,

    CLRDATA_VALUE_ALL_FIELDS                = 0x00000eff,

    CLRDATA_VALUE_IS_BOXED                  = 0x00001000
} CLRDataValueFlag;
```

## Members

|Member|Value|Description|
|------------|-----------------|-----------------|
|`CLRDATA_VALUE_DEFAULT`|0x0|Default flags.|
|`CLRDATA_VALUE_IS_PRIMITIVE`|0x1|The value is a primitive value.|
|`CLRDATA_VALUE_IS_VALUE_TYPE`|0x2|The value is a value type.|
|`CLRDATA_VALUE_IS_STRING`|0x4|The value is a string.|
|`CLRDATA_VALUE_IS_ARRAY`|0x8|The value is an array.|
|`CLRDATA_VALUE_IS_REFERENCE`|0x10|The value is a reference.|
|`CLRDATA_VALUE_IS_POINTER`|0x20|The value is a pointer.|
|`CLRDATA_VALUE_IS_ENUM`|0x40|The value is an enum.|
|`CLRDATA_VALUE_ALL_KINDS`|0x7F|Bitwise or of all value kinds.|
|`CLRDATA_VALUE_IS_INHERITED`|0x80|The value is inherited.|
|`CLRDATA_VALUE_IS_LITERAL`|0x100|The value is literal.|
|`CLRDATA_VALUE_FROM_INSTANCE`|0x200|The value is from an instance declaration.|
|`CLRDATA_VALUE_FROM_TASK_LOCAL`|0x400|The value is from a task local declaration.|
|`CLRDATA_VALUE_FROM_STATIC`|0x800|The value is from a static declaration.|
|`CLRDATA_VALUE_ALL_LOCATIONS`|0xe00|Bitwise or of all value locations.|
|`CLRDATA_VALUE_ALL_FIELDS`|0xeff|Bitwise or of all value flags.|
|`CLRDATA_VALUE_IS_BOXED`|0x1000|The value is boxed.|

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
