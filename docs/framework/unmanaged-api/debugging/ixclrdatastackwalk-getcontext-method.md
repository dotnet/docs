---
description: "Learn more about: IXCLRDataStackWalk::GetContext Method"
title: "IXCLRDataStackWalk::GetContext Method"
ms.date: "07/30/2026"
api.name:
  - "IXCLRDataStackWalk::GetContext Method"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataStackWalk::GetContext Method"
helpviewer.keywords:
  - "IXCLRDataStackWalk::GetContext Method [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "leculver"
ms.author: "leculver"
ai-usage: ai-assisted
---
# IXCLRDataStackWalk::GetContext Method

Gets the current context of this stack walk.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Syntax

```cpp
HRESULT GetContext(
    [in] ULONG32 contextFlags,
    [in] ULONG32 contextBufSize,
    [out] ULONG32* contextSize,
    [out, size_is(contextBufSize)] BYTE contextBuf[]
);
```

## Parameters

`contextFlags`\
[in] The flags that control which parts of the context to return.

`contextBufSize`\
[in] The size of the `contextBuf` buffer.

`contextSize`\
[out] A pointer to the number of bytes actually written into the `contextBuf` buffer.

`contextBuf`\
[out, size_is(contextBufSize)] A buffer that stores the context.

## Remarks

The provided method is part of the `IXCLRDataStackWalk` interface and corresponds to the 4th slot of the virtual method table.

The context is the original context with any unwinding applied to it. As unwinding may restore only a subset of the registers, such as only non-volatile registers, the context may not exactly match the register state at the time of the actual call.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [IXCLRDataStackWalk Interface](ixclrdatastackwalk-interface.md)
