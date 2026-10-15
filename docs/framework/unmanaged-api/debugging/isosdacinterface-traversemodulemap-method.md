---
description: "Learn more about: ISOSDacInterface::TraverseModuleMap Method"
title: "ISOSDacInterface::TraverseModuleMap Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::TraverseModuleMap Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::TraverseModuleMap Method"
helpviewer.keywords:
  - "ISOSDacInterface::TraverseModuleMap Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::TraverseModuleMap Method

Traverses a module map and invokes a callback for each entry.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT TraverseModuleMap(ModuleMapType mmt, CLRDATA_ADDRESS moduleAddr, MODULEMAPTRAVERSE pCallback, LPVOID token);
```

## Parameters

`mmt`\
[in] A [ModuleMapType enumeration](modulemaptype-enumeration.md) value that indicates which module map to traverse.

`moduleAddr`\
[in] The address of the module whose map to traverse.

`pCallback`\
[in] A `MODULEMAPTRAVERSE` callback function to invoke for each map entry.

`token`\
[in] A caller-defined value that is passed to the callback function.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 15th slot of the virtual method table.

The `MODULEMAPTRAVERSE` callback has the following signature: `typedef void (*MODULEMAPTRAVERSE)(UINT index, CLRDATA_ADDRESS methodTable,LPVOID token);`. The callback receives the map entry index, the method table address for that entry, and the caller-defined token.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [ModuleMapType Enumeration](modulemaptype-enumeration.md)
- [ISOSDacInterface::GetModule Method](isosdacinterface-getmodule-method.md)
- [ISOSDacInterface::GetModuleData Method](isosdacinterface-getmoduledata-method.md)
- [ISOSDacInterface::GetILForModule Method](isosdacinterface-getilformodule-method.md)
