---
title: "CLRDATA_IL_ADDRESS_MAP Structure"
ms.date: "01/16/2019"
api.name:
  - "CLRDATA_IL_ADDRESS_MAP Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "CLRDATA_IL_ADDRESS_MAP Structure"
helpviewer.keywords:
  - "CLRDATA_IL_ADDRESS_MAP Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# CLRDATA_IL_ADDRESS_MAP Structure

Defines an IL to address mapping.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
typedef struct
{
    ULONG32 ilOffset;
    CLRDATA_ADDRESS startAddress;
    CLRDATA_ADDRESS endAddress;
    CLRDataSourceType type;
} CLRDATA_IL_ADDRESS_MAP;
```

## Members

| Member         | Description                                            |
| -------------- | ------------------------------------------------------ |
| `ilOffset`     | IL offset for the contained address range              |
| `startAddress` | The start address of the range.                        |
| `endAddress`   | The end address of the range.                          |
| `type`         | The type of the data. This value is currently not used |

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define the structure as specified above, where `CLRDATA_ADDRESS` is a 64-bit unsigned integer.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None   
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [CLRDataSourceType Enumeration](clrdatasourcetype-enumeration.md)
- [Debugging](index.md)
- [Debugging Structures](debugging-structures.md)
