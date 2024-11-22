---
description: "Learn more about: CLRDataOtherNotifyFlag Enumeration"
title: "CLRDataOtherNotifyFlag Enumeration"
ms.date: "07/01/2024"
api_name:
  - "CLRDataOtherNotifyFlag"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRDataOtherNotifyFlag"
helpviewer_keywords:
  - "CLRDataOtherNotifyFlag enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# CLRDataOtherNotifyFlag Enumeration

Indicates the type of notifications which should be delivered.

## Syntax

```cpp
typedef enum CLRDataOtherNotifyFlag {
    CLRDATA_NOTIFY_ON_MODULE_LOAD           = 0x00000001,
    CLRDATA_NOTIFY_ON_MODULE_UNLOAD         = 0x00000002,
    CLRDATA_NOTIFY_ON_EXCEPTION             = 0x00000004,
    CLRDATA_NOTIFY_ON_EXCEPTION_CATCH_ENTER = 0x00000008
} CLRDataOtherNotifyFlag;
```

## Members

|Member|Value|Description|
|------------|-----------------|-----------------|
|`CLRDATA_NOTIFY_ON_MODULE_LOAD`|0x1|Notification should occur when a module is loaded.|
|`CLRDATA_NOTIFY_ON_MODULE_UNLOAD`|0x2|Notification should occur when a module is unloaded.|
|`CLRDATA_NOTIFY_ON_EXCEPTION`|0x4|Notification should occur when a managed exception is raised.|
|`CLRDATA_NOTIFY_ON_EXCEPTION_CATCH_ENTER`|0x8|Notification should occur when a managed catch block is entered.|

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
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
- [IXCLRDataProcess::SetOtherNotificationFlags Method](ixclrdataprocess-setothernotificationflags-method.md)
