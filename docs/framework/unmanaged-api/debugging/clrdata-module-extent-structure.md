---
description: "Learn more about: CLRDATA_MODULE_EXTENT Structure"
title: "CLRDATA_MODULE_EXTENT Structure"
ms.date: "07/01/2024"
api_name:
  - "CLRDATA_MODULE_EXTENT"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRDATA_MODULE_EXTENT"
helpviewer_keywords:
  - "CLRDATA_MODULE_EXTENT structure [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# CLRDATA_MODULE_EXTENT Structure

Describes a memory region associated with a module.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
struct CLRDATA_MODULE_EXTENT
{
    CLRDATA_ADDRESS base;
    ULONG32 length;
    CLRDataModuleExtentType type;
};
```

## Members

|Member|Description|
|------------|-----------------|
|`base`|The base address of the memory range associated with the module.|
|`length`|The length of the memory range associated with the module.|
|`type`|The type of memory range associated with the module.|

## Remarks

This structure lives inside the runtime and is not exposed through any headers or library files. To use it, define the structure as specified above, where `CLRDATA_ADDRESS` is a 64-bit unsigned integer.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging Structures](debugging-structures.md)
- [Debugging](index.md)
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)
- [CLRDataModuleExtentType Enumeration](clrdatamoduleextenttype-enumeration.md)
