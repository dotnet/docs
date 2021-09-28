---
description: "Learn more about: IXCLRDataProcess::EndEnumModules Method"
title: "IXCLRDataProcess::EndEnumModules Method"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataProcess::EndEnumModules Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::EndEnumModules Method"
helpviewer.keywords:
  - "IXCLRDataProcess::EndEnumModules Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess::EndEnumModules Method

Releases the resources used by internal iterators used during module enumeration.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EndEnumModules(
    [in] CLRDATA_ENUM handle
);
```

## Parameters

`handle`\
[out] A handle for enumerating the modules.

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 26th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
