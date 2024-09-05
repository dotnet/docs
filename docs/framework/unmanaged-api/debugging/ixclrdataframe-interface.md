---
description: "Learn more about: IXCLRDataFrame Interface"
title: "IXCLRDataFrame Interface"
ms.date: "07/02/2024"
api.name:
  - "IXCLRDataFrame Interface"
api.location:
  - "mscordacwks.dll"
api.type:
  - "COM"
f1.keywords:
  - "IXCLRDataFrame Interface"
helpviewer.keywords:
  - "IXCLRDataFrame Interface [.NET Framework debugging]"
topic_type:
  - "apiref"
author: "wmessmer"
ms.author: "wmessmer"
---
# IXCLRDataFrame Interface

Provides methods for querying information about a stack frame.

[!INCLUDE[debugging-api-recommended-note](../../../../includes/debugging-api-recommended-note.md)]

## Methods

| Method                                                                                                                  | Description                                 |
| ----------------------------------------------------------------------------------------------------------------------- | ------------------------------------------- |
| [GetNumArguments](ixclrdataframe-getnumarguments-method.md) | Gets the number of arguments on the stack. |
| [GetNumLocalVariables](ixclrdataframe-getnumlocalvariables-method.md) | Gets the number of local variables on the stack. |
| [GetMethodInstance](ixclrdataframe-getmethodinstance-method.md) | Gets the method instance corresponding to the stack frame. |
| [GetArgumentByIndex](ixclrdataframe-getargumentbyindex-method.md) | Gets an argument variable by (0-based) index. |
| [GetLocalVariableByIndex](ixclrdataframe-getlocalvariablebyindex-method.md) | Gets a local variable by (0-based) index. |

## Remarks

This interface lives inside the runtime and is not exposed through any headers or library files. However, it's a COM interface that derives from `IUnknown` with GUID `271498C2-4085-4766-BC3A-7F8ED188A173` that can be obtained through the usual COM mechanisms.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
**Header:** None  
**Library:** None  
**.NET Framework Versions:** [!INCLUDE[net_current_v47plus](../../../../includes/net-current-v47plus.md)]  

## See also

- [Debugging](index.md)
- [Debugging Interfaces](debugging-interfaces.md)
