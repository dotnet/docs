---
description: "Learn more about: ICorDebugDataTarget3 Interface"
title: "ICorDebugDataTarget3 Interface"
ms.date: "03/30/2017"
---
# ICorDebugDataTarget3 Interface

Logically extends the [ICorDebugDataTarget](icordebugdatatarget-interface.md) interface to provide information about loaded modules.

## Method

|Method|Description|
|------------|-----------------|
|[GetLoadedModules Method](icordebugdatatarget3-getloadedmodules-method.md)|Gets a list of the modules that have been loaded so far.|

## Remarks

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
