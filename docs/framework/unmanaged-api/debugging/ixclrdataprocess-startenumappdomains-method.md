---
description: "Learn more about: IXCLRDataProcess::StartEnumAppDomains Method"
title: "IXCLRDataProcess::StartEnumAppDomains Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataProcess::StartEnumAppDomains Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::StartEnumAppDomains Method"
helpviewer.keywords:
  - "IXCLRDataProcess::StartEnumAppDomains Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataProcess::StartEnumAppDomains Method

Provides a handle to enumerate the AppDomains within the process.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT StartEnumAppDomains(
    [out] CLRDATA_ENUM *handle
);
```

## Parameters

`handle`\
[out] A handle for enumerating the AppDomains.

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 17th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
- [IXCLRDataAppDomain Interface](ixclrdataappdomain-interface.md)
- [IXCLRDataProcess::EnumAppDomain Method](ixclrdataprocess-enumappdomain-method.md)
- [IXCLRDataProcess::EndEnumAppDomains Method](ixclrdataprocess-endenumappdomains-method.md)
