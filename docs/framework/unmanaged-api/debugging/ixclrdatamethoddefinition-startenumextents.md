---
description: "Learn more about: IXCLRDataMethodDefinition::StartEnumExtents Method"
title: "IXCLRDataMethodDefinition::StartEnumExtents Method"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataMethodDefinition::StartEnumExtents Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataMethodDefinition::StartEnumExtents Method"
helpviewer.keywords:
  - "IXCLRDataMethodDefinition::StartEnumExtents Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataMethodDefinition::StartEnumExtents Method

Provides a handle for the enumeration of IL code regions associated with the method.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT StartEnumExtents(
    [out] CLRDATA_ENUM *handle
);
```

## Parameters

`handle`\
[out] A handle for enumerating the IL code regions associated with the method.

## Remarks

The provided method is part of the `IXCLRDataMethodDefinition` interface and corresponds to the 13th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataMethodDefinition Interface](ixclrdatamethoddefinition-interface.md)
- [IXCLRDataMethodDefinition::EnumExtent Method](ixclrdatamethoddefinition-enumextent-method.md)
- [IXCLRDataMethodDefinition::EndEnumExtents Method](ixclrdatamethoddefinition-endenumextents-method.md)
- [CLRDATA_METHDEF_EXTENT Structure](clrdata-methdef-extent-structure.md)
