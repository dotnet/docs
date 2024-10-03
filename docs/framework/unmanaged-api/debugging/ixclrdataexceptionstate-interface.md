---
description: "Learn more about: IXCLRDataExceptionState Interface"
title: "IXCLRDataExceptionState Interface"
ms.date: "07/03/2024"
api.name:
  - "IXCLRDataExceptionState Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataExceptionState Interface"
helpviewer.keywords:
  - "IXCLRDataExceptionState Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataExceptionState Interface

Provides methods for querying information about the state of a managed exception.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                  | Description                                 |
| ----------------------------------------------------------------------------------------------------------------------- | ------------------------------------------- |
| [Request](ixclrdataexceptionstate-request-method.md) | Requests to populate the buffer given with the exception's data. |
| [IsSameState](ixclrdataexceptionstate-issamestate-method.md) | Determines whether the exception state is the same as the given exception state. |
| [IsSameState2](ixclrdataexceptionstate-issamestate2-method.md) | Determines whether the exception state is the same as the given exception state. |
| [GetPrevious](ixclrdataexceptionstate-getprevious-method.md) | For nested exceptions, get the exception that was being handled when this exception occurred. |
| [GetManagedObject](ixclrdataexceptionstate-getmanagedobject-method.md) | Gets the managed object representing the exception. |
| [GetString](ixclrdataexceptionstate-getstring-method.md) | Gets exception information. |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `75DA9E4C-BD33-43C8-8F5C-96E8A5241F57` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).
**Header:** None
**Library:** None
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
