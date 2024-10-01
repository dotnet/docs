---
description: "Learn more about: CLRDataMethodCodeNotification Enumeration"
title: "CLRDataMethodCodeNotification Enumeration"
ms.date: "07/01/2024"
api_name:
  - "CLRDataMethodCodeNotification"
api_location:
  - "mscordacwks.dll"
api_type:
  - "COM"
f1_keywords:
  - "CLRDataMethodCodeNotification"
helpviewer_keywords:
  - "CLRDataMethodCodeNotification enumeration [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# CLRDataMethodCodeNotification Enumeration

Indicates the type of notifications pertaining to method instance code which should be delivered.

## Syntax

```cpp
typedef enum CLRDataMethodCodeNotification {
    CLRDATA_METHNOTIFY_NONE      = 0x00000000,
    CLRDATA_METHNOTIFY_GENERATED = 0x00000001,
    CLRDATA_METHNOTIFY_DISCARDED = 0x00000002
} CLRDataMethodCodeNotification;
```

## Members

|Member|Value|Description|
|------------|-----------------|-----------------|
|`CLRDATA_METHNOTIFY_NONE`|0|No method notification.|
|`CLRDATA_METHNOTIFY_GENERATED`|1|Notification should occur on code generation for the method.|
|`CLRDATA_METHNOTIFY_DISCARDED`|2|Notification should occur on discarding code for the method.|

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
- [IXCLRDataProcess::SetCodeNotifications Method](ixclrdataprocess-setcodenotifications-method.md)
- [IXCLRDataProcess::SetAllCodeNotifications Method](ixclrdataprocess-setallcodenotifications-method.md)
