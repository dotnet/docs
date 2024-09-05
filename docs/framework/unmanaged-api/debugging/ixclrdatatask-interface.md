---
description: "Learn more about: IXCLRDataTask Interface"
title: "IXCLRDataTask Interface"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataTask Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataTask Interface"
helpviewer.keywords:
  - "IXCLRDataTask Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataTask Interface

Provides methods for querying information about a managed task.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                  | Description                                 |
| ----------------------------------------------------------------------------------------------------------------------- | ------------------------------------------- |
| [GetCurrentAppDomain](ixclrdatatask-getcurrentappdomain-method.md) | Gets the current AppDomain of the task. |
| [CreateStackWalk](ixclrdatatask-createstackwalk-method.md) | Starts a stack walk for the task. |
| [GetLastExceptionState](ixclrdatatask-getlastexceptionstate-method.md) | Gets the last exception state of the task. |
| [GetCurrentExceptionState](ixclrdatatask-getcurrentexceptionstate-method.md) | Gets the current exception state of the task. |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `A5B0BEEA-EC62-4618-8012-A24FFC23934C` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
