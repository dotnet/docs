---
description: "Learn more about: IXCLRDataExceptionNotification::OnModuleLoaded Method"
title: "IXCLRDataExceptionNotification::OnModuleLoaded Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataExceptionNotification::OnModuleLoaded Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionNotification::OnModuleLoaded Method"
helpviewer.keywords:
  - "IXCLRDataExceptionNotification::OnModuleLoaded Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionNotification::OnModuleLoaded Method

Client implemented callback which is made during a call to `IXCLRDataProcess::TranslateExceptionRecordToNotification` when a given exception represents the loading of a CLR module.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT OnModuleLoaded(
    [in] IXCLRDataModule *mod
);
```

## Parameters

`mod`\
[in] The module which was loaded.

## Remarks

The provided method is part of the `IXCLRDataExceptionNotification` interface and corresponds to the 8th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess::TranslateExceptionRecordToNotification Method](ixclrdataprocess-translateexceptionrecordtonotification-method.md)
- [IXCLRDataModule Interface](ixclrdatamodule-interface.md)
