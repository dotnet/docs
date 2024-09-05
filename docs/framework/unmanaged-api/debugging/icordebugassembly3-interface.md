---
description: "Learn more about: ICorDebugAssembly3 Interface"
title: "ICorDebugAssembly3 Interface"
ms.date: "03/30/2017"
ms.assetid: 17fc5d76-75a9-4933-83f0-594de7f973f3
---
# ICorDebugAssembly3 Interface

Logically extends the ICorDebugAssembly interface to provide support for container assemblies and their contained assemblies.

## Methods

|Method|Description|
|------------|-----------------|
|[EnumerateContainedAssemblies Method](icordebugassembly3-enumeratecontainedassemblies-method.md)|Gets an enumerator for the assemblies contained in this assembly.|
|[GetContainerAssembly Method](icordebugassembly3-getcontainerassembly-method.md)|Returns the container assembly of this `ICorDebugAssembly3` object.|

## Remarks

> [!NOTE]
> The interface is available with .NET Native only. Attempting to call `QueryInterface` to retrieve an interface pointer returns `E_NOINTERFACE` for ICorDebug scenarios outside of .NET Native.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
