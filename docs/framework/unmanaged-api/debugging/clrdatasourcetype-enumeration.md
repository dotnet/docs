---
title: "CLRDataSourceType Enumeration"
ms.date: "01/16/2019"
api.name:
  - "CLRDataSourceType Enumeration"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "CLRDataSourceType Enumeration"
helpviewer.keywords:
  - "CLRDataSourceType Enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# CLRDataSourceType Enumeration

Provides values that are used by the CLRDATA_IL_ADDRESS_MAP structure.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
typedef enum
{
    CLRDATA_SOURCE_TYPE_INVALID        = 0x00, // To indicate that nothing else applies
} CLRDataSourceType;
```

## Members

| Member                        | Description                           |
| ----------------------------- | ------------------------------------- |
| `CLRDATA_SOURCE_TYPE_INVALID` | To indicate that nothing else applies |

## Remarks

This enumeration lives inside the runtime and is not exposed through any headers or library files. To use it, define an enumeration as defined above in your code. This is also aliased to `CLRDATA_ENUM` as mentioned in [Common Data Types](../../../../docs/framework/unmanaged-api/common-data-types-unmanaged-api-reference.md).

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [Debugging Enumerations](../../../../docs/framework/unmanaged-api/debugging/debugging-enumerations.md)
