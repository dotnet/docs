---
description: "Learn more about: CLRDataFieldFlag Enumeration"
title: "CLRDataFieldFlag Enumeration"
ms.date: "07/02/2024"
api_name:
  - "CLRDataFieldFlag"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRDataFieldFlag"
helpviewer_keywords:
  - "CLRDataFieldFlag enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# CLRDataFieldFlag Enumeration

Indicates various attributes of a field.

## Syntax

```cpp
typedef enum CLRDataFieldFlag {
    CLRDATA_FIELD_DEFAULT                   = 0x00000000,
    CLRDATA_FIELD_IS_PRIMITIVE              = 0x00000001,
    CLRDATA_FIELD_IS_VALUE_TYPE             = 0x00000002,
    CLRDATA_FIELD_IS_STRING                 = 0x00000004,
    CLRDATA_FIELD_IS_ARRAY                  = 0x00000008,
    CLRDATA_FIELD_IS_REFERENCE              = 0x00000010,
    CLRDATA_FIELD_IS_POINTER                = 0x00000020,
    CLRDATA_FIELD_IS_ENUM                   = 0x00000040,
    CLRDATA_FIELD_ALL_KINDS                 = 0x0000007F,

    CLRDATA_FIELD_IS_INHERITED              = 0x00000080,
    CLRDATA_FIELD_IS_LITERAL                = 0x00000100,

    CLRDATA_FIELD_FROM_INSTANCE             = 0x00000200,
    CLRDATA_FIELD_FROM_TASK_LOCAL           = 0x00000400,
    CLRDATA_FIELD_FROM_STATIC               = 0x00000800,

    CLRDATA_FIELD_ALL_LOCATIONS             = 0x00000e00,

    CLRDATA_FIELD_ALL_FIELDS                = 0x00000eff
} CLRDataFieldFlag;
```

## Members

|Member|Value|Description|
|------------|-----------------|-----------------|
|`CLRDATA_FIELD_DEFAULT`|0x0|Default flags.|
|`CLRDATA_FIELD_IS_PRIMITIVE`|0x1|The field is a primitive value.|
|`CLRDATA_FIELD_IS_VALUE_TYPE`|0x2|The field is a value type.|
|`CLRDATA_FIELD_IS_STRING`|0x4|The field is a string.|
|`CLRDATA_FIELD_IS_ARRAY`|0x8|The field is an array.|
|`CLRDATA_FIELD_IS_REFERENCE`|0x10|The field is a reference.|
|`CLRDATA_FIELD_IS_POINTER`|0x20|The field is a pointer.|
|`CLRDATA_FIELD_IS_ENUM`|0x40|The field is an enum.|
|`CLRDATA_FIELD_ALL_KINDS`|0x7F|Bitwise or of all field kinds.  Such can be used in various enumeration methods.|
|`CLRDATA_FIELD_IS_INHERITED`|0x80|The field is inherited.|
|`CLRDATA_FIELD_IS_LITERAL`|0x100|The field is literal.|
|`CLRDATA_FIELD_FROM_INSTANCE`|0x200|The field is from an instance declaration.|
|`CLRDATA_FIELD_FROM_TASK_LOCAL`|0x400|The field is from a task local declaration.|
|`CLRDATA_FIELD_FROM_STATIC`|0x800|The field is from a static declaration.|
|`CLRDATA_FIELD_ALL_LOCATIONS`|0xe00|Bitwise or of all field locations.  Such can be used in various enumeration methods.|
|`CLRDATA_FIELD_ALL_FIELDS`|0xeff|Bitwise or of all field flags.  Such can be used in various enumeration methods.|

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
