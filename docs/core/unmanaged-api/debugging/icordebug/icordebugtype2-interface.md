---
description: "Learn more about: ICorDebugType2 Interface"
title: "ICorDebugType2 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugType2"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugType2"
helpviewer_keywords:
  - "ICorDebugType2 interface"
topic_type:
  - "apiref"
---
# ICorDebugType2 Interface

Extends the ICorDebugType interface to retrieve the type identifier  of a base type or complex (user-defined) type.

## Methods

| Method                                                 | Description                                                 |
| ------------------------------------------------------ | ----------------------------------------------------------- |
| [GetTypeID Method](icordebugtype2-gettypeid-method.md) | Gets a [COR_TYPEID](cor-typeid-structure.md) for this type. |

## Remarks

 This interface is a logical extension of the ICorDebugType interface.

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Example

 The following code fragment illustrates the use of the [ICorDebugType2::GetTypeID](icordebugtype2-gettypeid-method.md) method.

```cpp
// (error checking omitted for brevity)
// given an ICorDebugType *pType

ICorDebugType2 *pType2 = NULL;
pType->QueryInterface(IID_ICorDebugType2, &pType);

COR_TYPEID id;
pType2->GetTypeID(&id);

// now we can use existing APIs to get information about this COR_TYPEID
```

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6.2

## See also

- [Debugging Interfaces](debugging-interfaces.md)
