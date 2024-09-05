---
description: "Learn more about: IXCLRDataExceptionNotification4::ExceptionCatcherEnter Method"
title: "IXCLRDataExceptionNotification4::ExceptionCatcherEnter Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataExceptionNotification4::ExceptionCatcherEnter Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionNotification4::ExceptionCatcherEnter Method"
helpviewer.keywords:
  - "IXCLRDataExceptionNotification4::ExceptionCatcherEnter Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionNotification4::ExceptionCatcherEnter Method

Client implemented callback which is made during a call to `IXCLRDataProcess::TranslateExceptionRecordToNotification` when a given exception represents the entry into a managed catch block.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT ExceptionCatcherEnter(
    [in] IXCLRDataMethodInstance *catchingMethod,
    [in] DWORD catcherNativeOffset
);
```

## Parameters

`catchingMethod`\
[in] The method instance which contains the managed catch block

`catcherNativeOffset`\
[in] The native code offset in bytes to the catching block

## Remarks

The provided method is part of the `IXCLRDataExceptionNotification4` interface and corresponds to the 16th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess::TranslateExceptionRecordToNotification Method](ixclrdataprocess-translateexceptionrecordtonotification-method.md)
- [IXCLRDataMethodInstance Interface](ixclrdatamethodinstance-interface.md)
- [IXCLRDataExceptionNotification Interface](ixclrdataexceptionnotification-interface.md)
- [IXCLRDataExceptionNotification2 Interface](ixclrdataexceptionnotification2-interface.md)
- [IXCLRDataExceptionNotification3 Interface](ixclrdataexceptionnotification3-interface.md)
