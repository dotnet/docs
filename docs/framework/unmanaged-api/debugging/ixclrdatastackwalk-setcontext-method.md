---
description: "Learn more about: IXCLRDataStackWalk::SetContext Method"
title: "IXCLRDataStackWalk::SetContext Method"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataStackWalk::SetContext Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataStackWalk::SetContext Method"
helpviewer.keywords:
  - "IXCLRDataStackWalk::SetContext Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataStackWalk::SetContext Method

Changes the current context of this stack walk, allowing the debugger to move it to an arbitrary context.  Does not actually alter the current context of the thread whose stack is being walked.

NOTE: This method is obsolete.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT SetContext(
    [in] ULONG32 contextSize,
    [in, size_is(contextSize)] BYTE context[]
);
```

## Parameters

`contextSize`
[in] The size of the context record in the `context` buffer.

`context`
[in] The context to change the stack walker to.

## Remarks

The provided method is part of the `IXCLRDataStackWalk` interface and corresponds to the 5th slot of the virtual method table.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataStackWalk Interface](ixclrdatastackwalk-interface.md)
