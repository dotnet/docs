---
description: "Learn more about: ICorDebugLoadedModule Interface"
title: "ICorDebugLoadedModule Interface"
ms.date: "03/30/2017"
---
# ICorDebugLoadedModule Interface

Provides information about a loaded module.

## Methods

|Method|Description|
|------------|-----------------|
|[GetBaseAddress Method](icordebugloadedmodule-getbaseaddress-method.md)|Gets the base address of the loaded module.|
|[GetName Method](icordebugloadedmodule-getname-method.md)|Gets the name of the loaded module.|
|[GetSize Method](icordebugloadedmodule-getsize-method.md)|Gets the size in bytes of the loaded module.|

## Remarks

 The `ICorDebugLoadedModule` interface is implemented by a debugger and is used by the CLR debugging interfaces to get information about the loaded module from the debugger.

> [!NOTE]
> This interface is available with .NET Native only. If you implement this interface for ICorDebug scenarios outside of .NET Native, the common language runtime will ignore this interface.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
