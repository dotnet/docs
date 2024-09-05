---
description: "Learn more about: CLRDataSimpleFrameType Enumeration"
title: "CLRDataSimpleFrameType Enumeration"
ms.date: "07/03/2024"
api_name:
  - "CLRDataSimpleFrameType"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRDataSimpleFrameType"
helpviewer_keywords:
  - "CLRDataSimpleFrameType enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# CLRDataSimpleFrameType Enumeration

Describes a type of frame in the call stack.

## Syntax

```cpp
typedef enum CLRDataSimpleFrameType {
    CLRDATA_SIMPFRAME_UNRECOGNIZED           = 0x1,
    CLRDATA_SIMPFRAME_MANAGED_METHOD         = 0x2,
    CLRDATA_SIMPFRAME_RUNTIME_MANAGED_CODE   = 0x4,
    CLRDATA_SIMPFRAME_RUNTIME_UNMANAGED_CODE = 0x8
} CLRDataSimpleFrameType;
```

## Members

|Member|Value|Description|
|------------|-----------------|-----------------|
|`CLRDATA_SIMPFRAME_UNRECOGNIZED`|0x1|The frame is an unrecognized type.|
|`CLRDATA_SIMPFRAME_MANAGED_METHOD`|0x2|The frame is a managed method.|
|`CLRDATA_SIMPFRAME_RUNTIME_MANAGED_CODE`|0x4|The frame is a runtime controlled managed method.|
|`CLRDATA_SIMPFRAME_RUNTIME_UNMANAGED_CODE`|0x8|The frame is a runtime controlled unmanaged method.|

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
- [IXCLRDataStackWalk Interface](ixclrdatastackwalk-interface.md)
- [IXCLRDataStackWalk::GetFrameType Method](ixclrdatastackwalk-getframetype-method.md)
