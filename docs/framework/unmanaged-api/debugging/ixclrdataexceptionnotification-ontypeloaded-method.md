---
description: "Learn more about: IXCLRDataExceptionNotification::OnTypeLoaded Method"
title: "IXCLRDataExceptionNotification::OnTypeLoaded Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataExceptionNotification::OnTypeLoaded Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionNotification::OnTypeLoaded Method"
helpviewer.keywords:
  - "IXCLRDataExceptionNotification::OnTypeLoaded Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionNotification::OnTypeLoaded Method

Client implemented callback which is made during a call to `IXCLRDataProcess::TranslateExceptionRecordToNotification` when a given exception represents the loading of a type instance.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT OnTypeLoaded(
    [in] IXCLRDataTypeInstance *typeInst
);
```

## Parameters

`typeInst`\
[in] The type instance which was loaded.

## Remarks

The provided method is part of the `IXCLRDataExceptionNotification` interface and corresponds to the 10th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess::TranslateExceptionRecordToNotification Method](ixclrdataprocess-translateexceptionrecordtonotification-method.md)
- [IXCLRDataTypeInstance Interface](ixclrdatatypeinstance-interface.md)
