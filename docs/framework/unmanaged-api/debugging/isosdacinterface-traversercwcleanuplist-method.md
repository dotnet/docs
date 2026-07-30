---
description: "Learn more about: ISOSDacInterface::TraverseRCWCleanupList Method"
title: "ISOSDacInterface::TraverseRCWCleanupList Method"
ms.date: "07/30/2026"
api.name:
  - "ISOSDacInterface::TraverseRCWCleanupList Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface::TraverseRCWCleanupList Method"
helpviewer.keywords:
  - "ISOSDacInterface::TraverseRCWCleanupList Method [.NET Framework debugging]"
topic_type:
  - "apiref"
ai-usage: ai-assisted
author: "leculver"
ms.author: "leculver"
---
# ISOSDacInterface::TraverseRCWCleanupList Method

Traverses the runtime callable wrapper (RCW) cleanup list and calls a visitor callback for each entry.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT TraverseRCWCleanupList(CLRDATA_ADDRESS cleanupListPtr, VISITRCWFORCLEANUP pCallback, LPVOID token);
```

## Parameters

`cleanupListPtr`\
[in] The address of the RCW cleanup list to traverse.

`pCallback`\
[in] A `VISITRCWFORCLEANUP` callback function that the runtime calls for each cleanup-list entry.

`token`\
[in] A caller-supplied value that the runtime passes to `pCallback`.

## Remarks

The provided method is part of the `ISOSDacInterface` interface and corresponds to the 79th slot of the virtual method table.

The `VISITRCWFORCLEANUP` callback has the following signature:

```cpp
typedef BOOL (*VISITRCWFORCLEANUP)(CLRDATA_ADDRESS RCW,CLRDATA_ADDRESS Context,CLRDATA_ADDRESS Thread, 
    BOOL bIsFreeThreaded, LPVOID token);
```

The callback receives the RCW address, COM context address, thread address, a flag that indicates whether the RCW is free-threaded, and the caller-supplied `token` value.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [ISOSDacInterface Interface](isosdacinterface-interface.md)
- [ISOSDacInterface::GetRCWData Method](isosdacinterface-getrcwdata-method.md)
- [ISOSDacInterface::GetRCWInterfaces Method](isosdacinterface-getrcwinterfaces-method.md)
