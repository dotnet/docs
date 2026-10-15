---
description: "Learn more about: ISOSDacInterface::GetHandleEnum Method"
title: "ISOSDacInterface::GetHandleEnum Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::GetHandleEnum Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::GetHandleEnum Method"
helpviewer.keywords:
  - "ISOSDacInterface::GetHandleEnum Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::GetHandleEnum Method

Retrieves an enumerator for runtime handles.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetHandleEnum(ISOSHandleEnum **ppHandleEnum);
```

## Parameters

`ppHandleEnum`\
[out] A pointer to an `ISOSHandleEnum` interface pointer that receives the handle enumerator.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 62nd slot of the virtual method table.

The returned `ISOSHandleEnum` enumerator derives from `ISOSEnum` and provides a `Next` method that returns `SOSHandleData` entries for runtime handles.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [ISOSDacInterface::GetHandleEnumForTypes Method](isosdacinterface-gethandleenumfortypes-method.md)
- [ISOSDacInterface::GetStackReferences Method](isosdacinterface-getstackreferences-method.md)
