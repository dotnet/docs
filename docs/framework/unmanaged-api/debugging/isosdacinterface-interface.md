---
title: "ISOSDacInterface Interface"
ms.date: "01/16/2019"
api.name:
  - "ISOSDacInterface Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "ISOSDacInterface Interface"
helpviewer.keywords:
  - "ISOSDacInterface Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "cshung"
ms.author: "andrewau"
---
# ISOSDacInterface Interface

Provides helper methods to access data from `SOS`.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                               | Description                                                                                                                   |
| -------------------------------------------------------------------------------------------------------------------- | ----------------------------------------------------------------------------------------------------------------------------- |
| [GetMethodDescData](../../../../docs/framework/unmanaged-api/debugging/isosdacinterface-getmethoddescdata-method.md) | Gets the data for the given [MethodDesc](../../../../docs/framework/unmanaged-api/common-data-types-unmanaged-api-reference.md). |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `436f00f2-b42a-4b9f-870c-e73db66ae930` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](../../../../docs/framework/unmanaged-api/debugging/index.md)
- [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
