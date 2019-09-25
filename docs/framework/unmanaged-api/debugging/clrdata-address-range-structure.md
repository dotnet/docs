---
title: "CLRDATA_ADDRESS_RANGE Structure"
ms.date: "01/16/2019"
api.name:
  - "CLRDATA_ADDRESS_RANGE Structure"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "CLRDATA_ADDRESS_RANGE Structure"
helpviewer.keywords:
  - "CLRDATA_ADDRESS_RANGE Structure [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# CLRDATA_ADDRESS_RANGE Structure

Defines an address range.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
typedef struct
{
    CLRDATA_ADDRESS startAddress;
    CLRDATA_ADDRESS endAddress;
} CLRDATA_ADDRESS_RANGE;
```

## Members

| Member         | Description                     |
| -------------- | ------------------------------- |
| `startAddress` | The start address of the range. |
| `endAddress`   | The end address of the range.   |

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define the structure as specified above, where `CLRDATA_ADDRESS` is a 64-bit unsigned integer.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [Debugging Structures](debugging-structures.md)
