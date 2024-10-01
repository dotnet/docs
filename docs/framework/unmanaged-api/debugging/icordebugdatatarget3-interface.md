---
description: "Learn more about: ICorDebugDataTarget3 Interface"
title: "ICorDebugDataTarget3 Interface"
ms.date: "03/30/2017"
ms.assetid: f477af85-994f-4df0-ae78-404ed252bf49
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

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
