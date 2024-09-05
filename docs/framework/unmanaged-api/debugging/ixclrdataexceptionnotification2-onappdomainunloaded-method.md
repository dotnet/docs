---
description: "Learn more about: IXCLRDataExceptionNotification2::OnAppDomainUnloaded Method"
title: "IXCLRDataExceptionNotification2::OnAppDomainUnloaded Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataExceptionNotification2::OnAppDomainUnloaded Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionNotification2::OnAppDomainUnloaded Method"
helpviewer.keywords:
  - "IXCLRDataExceptionNotification2::OnAppDomainUnloaded Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionNotification2::OnAppDomainUnloaded Method

Client implemented callback which is made during a call to `IXCLRDataProcess::TranslateExceptionRecordToNotification` when a given exception represents the unloading of an AppDomain.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT OnAppDomainUnloaded(
    [in] IXCLRDataAppDomain *domain
);
```

## Parameters

`domain`\
[in] The AppDomain which was unloaded.

## Remarks

The provided method is part of the `IXCLRDataExceptionNotification2` interface and corresponds to the 13th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess::TranslateExceptionRecordToNotification Method](ixclrdataprocess-translateexceptionrecordtonotification-method.md)
- [IXCLRDataExceptionNotification Interface](ixclrdataexceptionnotification-interface.md)
- [IXCLRDataAppDomain Interface](ixclrdataappdomain-interface.md)
