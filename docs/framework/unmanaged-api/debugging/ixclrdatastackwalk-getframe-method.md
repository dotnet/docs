---
description: "Learn more about: IXCLRDataStackWalk::GetFrame Method"
title: "IXCLRDataStackWalk::GetFrame Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataStackWalk::GetFrame Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataStackWalk::GetFrame Method"
helpviewer.keywords:
  - "IXCLRDataStackWalk::GetFrame Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataStackWalk::GetFrame Method

Gets the current frame of the stack walk, if it is recognized.  Note that upon creation, the stack walk is positioned "before" the first frame on the stack.  Debuggers must call the `Next` method to advance to the first frame before any other functions will work.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetFrame(
    [out] IXCLRDataFrame **frame
);
```

## Parameters

`frame`\
[out] The current frame of the stack walk.

## Remarks

The provided method is part of the `IXCLRDataStackWalk` interface and corresponds to the 9th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataStackWalk Interface](ixclrdatastackwalk-interface.md)
- [IXCLRDataFrame Interface](ixclrdataframe-interface.md)
- [IXCLRDataStackWalk::Next Method](ixclrdatastackwalk-next-method.md)
