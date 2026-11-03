---
description: "Learn more about: ISOSDacInterface::GetHandleEnumForTypes Method"
title: "ISOSDacInterface::GetHandleEnumForTypes Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetHandleEnumForTypes Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetHandleEnumForTypes Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetHandleEnumForTypes Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetHandleEnumForTypes Method

Retrieves an enumerator for runtime handles whose types match the specified type values.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetHandleEnumForTypes(unsigned int types[], unsigned int count, ISOSHandleEnum **ppHandleEnum);
```

## Parameters

`types`\
[in] An array of handle type values to include in the enumeration.

`count`\
[in] The number of elements in the `types` array.

`ppHandleEnum`\
[out] A pointer to an `ISOSHandleEnum` interface pointer that receives the handle enumerator.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 63rd slot of the virtual method table.

The returned `ISOSHandleEnum` enumerator derives from `ISOSEnum` and provides a `Next` method that returns `SOSHandleData` entries for runtime handles that match the requested handle types.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [ISOSDacInterface::GetHandleEnum Method](isosdacinterface-gethandleenum-method.md)
- [ISOSDacInterface::GetStackReferences Method](isosdacinterface-getstackreferences-method.md)
