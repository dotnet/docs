---
description: "Learn more about: IXCLRDataProcess::EnumAppDomain Method"
title: "IXCLRDataProcess::EnumAppDomain Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataProcess::EnumAppDomain Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::EnumAppDomain Method"
helpviewer.keywords:
  - "IXCLRDataProcess::EnumAppDomain Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataProcess::EnumAppDomain Method

Enumerates the AppDomains of this process.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EnumAppDomain(
    [in] CLRDATA_ENUM *handle,
    [out] IXCLRAppDomain **appDomain
);
```

## Parameters

`handle`\
[in] A handle for enumerating the AppDomains.

`appDomain`\
[out] The enumerated AppDomain.

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 18th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
- [IXCLRDataAppDomain Interface](ixclrdataappdomain-interface.md)
- [IXCLRDataProcess::StartEnumAppDomains Method](ixclrdataprocess-startenumappdomains-method.md)
- [IXCLRDataProcess::EndEnumAppDomains Method](ixclrdataprocess-endenumappdomains-method.md)
