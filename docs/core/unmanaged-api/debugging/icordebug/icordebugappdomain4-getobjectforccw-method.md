---
description: "Learn more about: ICorDebugAppDomain4::GetObjectForCCW Method"
title: "ICorDebugAppDomain4::GetObjectForCCW Method"
ms.date: "03/30/2017"
---
# ICorDebugAppDomain4::GetObjectForCCW Method

Gets a managed object from a COM callable wrapper (CCW) pointer.

## Syntax

```cpp
HRESULT GetObjectForCCW(
   [in]CORDB_ADDRESS ccwPointer,
   [out]ICorDebugValue **ppManagedObject
);
```

## Parameters

 `ccwPointer`
 [in] A COM callable wrapper (CCW) pointer.

 `ppManagedObject`
 [out] A pointer to the address of an "ICorDebugValue" object that represents the managed object that corresponds to the given CCW pointer.

## Remarks

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugAppDomain4 Interface](icordebugappdomain4-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
