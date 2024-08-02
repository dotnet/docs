---
description: "Learn more about: IXCLRDataStackWalk Interface"
title: "IXCLRDataStackWalk Interface"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataStackWalk Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataStackWalk Interface"
helpviewer.keywords:
  - "IXCLRDataStackWalk Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataStackWalk Interface

Provides methods for walking the stack.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                  | Description                                 |
| ----------------------------------------------------------------------------------------------------------------------- | ------------------------------------------- |
| [SetContext](ixclrdatastackwalk-setcontext-method.md) | Change the context of this stack walk. |
| [GetFrameType](ixclrdatastackwalk-getframetype-method.md) | Gets information about the type of the current frame. |
| [GetFrame](ixclrdatastackwalk-getframe-method.md) | Gets the current frame if it is recognized. |
| [Request](ixclrdatastackwalk-request-method.md) | Requests to populate the buffer given with the stack walker's data. |
| [Next](ixclrdatastackwalk-next-method.md) | Moves the stack walker to the next frame. |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `E59D8D22-ADA7-49a2-89B5-A415AFCFC95F` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
