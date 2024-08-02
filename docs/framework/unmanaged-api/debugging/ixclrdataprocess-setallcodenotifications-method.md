---
description: "Learn more about: IXCLRDataProcess::SetAllCodeNotifications Method"
title: "IXCLRDataProcess::SetAllCodeNotifications Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataProcess::SetAllCodeNotifications Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::SetAllCodeNotifications Method"
helpviewer.keywords:
  - "IXCLRDataProcess::SetAllCodeNotifications Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataProcess::SetAllCodeNotifications Method

Requests notifications when code is generated or discarded for any method instance in a given `IXCLRDataModule`

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT SetAllCodeNotifications(
    [in] IXCLRDataModule *mod,
    [in] ULONG32 flags
);
```

## Parameters

`mod`\
[in] The module for which to request code notifications.

`flags`\
[in] The flags defining what kind of code notifications should be delivered.  The `flags` argument is one or more of the flags defined by the `CLRDataMethodCodeNotification` enumeration.

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 37th slot of the virtual method table. The `IXCLRDataAppDomain*` returned is used for interaction with other APIs.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
