---
description: "Learn more about: IXCLRDataProcess::EndEnumMethodDefinitionsByAddress Method"
title: "IXCLRDataProcess::EndEnumMethodDefinitionsByAddress Method"
ms.date: "01/16/2019"
api.name:
  - "IXCLRDataProcess::EndEnumMethodDefinitionsByAddress Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::EndEnumMethodDefinitionsByAddress Method"
helpviewer.keywords:
  - "IXCLRDataProcess::EndEnumMethodDefinitionsByAddress Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# IXCLRDataProcess::EndEnumMethodDefinitionsByAddress Method

Releases the resources used by internal iterators used during definition enumeration.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EndEnumMethodDefinitionsByAddress(
    [in] CLRDATA_ENUM handle
);
```

## Parameters

`handle`\
[out] A handle for enumerating the method definitions.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [CLRDataSourceType Enumeration](clrdatasourcetype-enumeration.md)
- [Debugging](index.md)
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
