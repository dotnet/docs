---
description: "Learn more about: IXCLRDataTask::GetCurrentAppDomain Method"
title: "IXCLRDataTask::GetCurrentAppDomain Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataTask::GetCurrentAppDomain Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTask::GetCurrentAppDomain Method"
helpviewer.keywords:
  - "IXCLRDataTask::GetCurrentAppDomain Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTask::GetCurrentAppDomain Method

Gets the application domain that the task is currently running in.  This can change over time.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetCurrentAppDomain(
    [out] IXCLRDataAppDomain **appDomain
);
```

## Parameters

`appDomain`\
[out] The application domain that the task is currently running in.

## Remarks

The provided method is part of the `IXCLRDataTask` interface and corresponds to the 5th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataTask Interface](ixclrdatatask-interface.md)
- [IXCLRDataAppDomain Interface](ixclrdataappdomain-interface.md)
