---
description: "Learn more about: ICorDebugDataTarget2 Interface"
title: "ICorDebugDataTarget2 Interface"
ms.date: "03/30/2017"
---
# ICorDebugDataTarget2 Interface

Logically extends the [ICorDebugDataTarget](icordebugdatatarget-interface.md)interface.

## Methods

|Method|Description|
|------------|-----------------|
|[CreateVirtualUnwinder Method](icordebugdatatarget2-createvirtualunwinder-method.md)|Creates a new stack unwinder that starts unwinding from an initial context (which isn't necessarily the leaf of a thread).|
|[EnumerateThreadIDs Method](icordebugdatatarget2-enumeratethreadids-method.md)|Returns a list of active thread IDs.|
|[GetImageFromPointer Method](icordebugdatatarget2-getimagefrompointer-method.md)|Returns the module base address and size from an address in that module.|
|[GetImageLocation Method](icordebugdatatarget2-getimagelocation-method.md)|Returns the path of a module from the module's base address.|
|[GetSymbolProviderForImage Method](icordebugdatatarget2-getsymbolproviderforimage-method.md)|Returns the symbol-provider for a module from the base address of that module.|

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
