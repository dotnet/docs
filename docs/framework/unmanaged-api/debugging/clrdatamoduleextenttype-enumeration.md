---
description: "Learn more about: CLRDataModuleExtentType Enumeration"
title: "CLRDataModuleExtentType Enumeration"
ms.date: "07/01/2024"
api_name:
  - "CLRDataModuleExtentType"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRDataModuleExtentType"
helpviewer_keywords:
  - "CLRDataModuleExtentType enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# CLRDataModuleExtentType Enumeration

Indicates the type of memory region associated with a module.

## Syntax

```cpp
typedef enum CLRDataModuleExtentType {
    CLRDATA_MODULE_PE_FILE,
    CLRDATA_MODULE_PREJIT_FILE,
    CLRDATA_MODULE_MEMORY_STREAM,
    CLRDATA_MODULE_OTHER
} CLRDataModuleExtentType;
```

## Members

|Member|Description|
|------------|-----------------|
|`CLRDATA_MODULE_PE_FILE`|The memory region is associated with a PE file.|
|`CLRDATA_MODULE_PREJIT_FILE`|The memory region is associated with a PREJIT file.|
|`CLRDATA_MODULE_MEMORY_STREAM`|The memory region is associated with a memory stream.|
|`CLRDATA_MODULE_OTHER`|The memory region is something other than what is described by one of the other enumeration values.|

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
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)
- [IXCLRDataModule::EnumExtent Method](ixclrdatamodule-enumextent-method.md)
- [CLRDATA_MODULE_EXTENT Structure](clrdata-module-extent-structure.md)
