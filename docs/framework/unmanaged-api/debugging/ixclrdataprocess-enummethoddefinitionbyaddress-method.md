---
description: "Learn more about: IXCLRDataProcess::EnumMethodDefinitionByAddress Method"
title: "IXCLRDataProcess::EnumMethodDefinitionByAddress Method"
ms.date: "07/01/2024"
api.name:
  - "IXCLRDataProcess::EnumMethodDefinitionByAddress Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataProcess::EnumMethodDefinitionByAddress Method"
helpviewer.keywords:
  - "IXCLRDataProcess::EnumMethodDefinitionByAddress Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataProcess::EnumMethodDefinitionByAddress Method

Enumerates the method definitions of this process at an IL code address.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT EnumMethodDefinitionByAddress(
    [in] CLRDATA_ENUM *handle,
    [out] IXCLRDataMethodDefinition **method
);
```

## Parameters

`handle`\
[in] A handle for enumerating the method definitions.

`method`\
[out] The enumerated method definition.

## Remarks

The provided method is part of the `IXCLRDataProcess` interface and corresponds to the 45th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataProcess Interface](ixclrdataprocess-interface.md)
- [IXCLRDataProcess::StartEnumMethodDefinitionsByAddress Method](ixclrdataprocess-startenummethoddefinitionsbyaddress-method.md)
- [IXCLRDataProcess::EndEnumMethodDefinitionsByAddress Method](ixclrdataprocess-endenummethoddefinitionsbyaddress-method.md)
