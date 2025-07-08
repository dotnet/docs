---
description: "Learn more about: IXCLRDataProcess::EndEnumAppDomains Method"
title: "IXCLRDataProcess::EndEnumAppDomains Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataProcess::EndEnumAppDomains Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::EndEnumAppDomains Method"
helpviewer.keywords:
  - "IXCLRDataProcess::EndEnumAppDomains Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataProcess::EndEnumAppDomains Method

Releases the resources used by internal iterators used during instance enumeration.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EndEnumAppDomains(
    [in] CLRDATA_ENUM handle
);
```

## Parameters

`handle`\
[out] A handle for enumerating the AppDomains.

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 19th slot of the virtual method table.

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
- [IXCLRDataProcess::EnumAppDomain Method](ixclrdataprocess-enumappdomain-method.md)
