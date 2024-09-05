---
description: "Learn more about: IXCLRDataStackWalk::Next Method"
title: "IXCLRDataStackWalk::Next Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataStackWalk::Next Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataStackWalk::Next Method"
helpviewer.keywords:
  - "IXCLRDataStackWalk::Next Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataStackWalk::Next Method

Attempts to advance the stack walk to the next frame that matches the stack walk's filter.  If the current frame type is `CLRDATA_UNRECOGNIZED_FRAME`, the `Next` method will be unable to advance.  (The debugger will have to walk the unrecognized frame itself, reset the walk's context, and try again).

Note that upon creation, the stack walk is positioned "before" the first frame on the stack.  Debuggers must call the `Next` method to advance to the first frame before any other functions will work.  The function will output S_FALSE when there are no more frames that meet its filter criteria.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT Next();
```

## Parameters

None

## Remarks

The provided method is part of the `IXCLRDataStackWalk` interface and corresponds to the 6th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataStackWalk Interface](ixclrdatastackwalk-interface.md)
