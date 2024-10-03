---
description: "Learn more about: ICorDebugStaticFieldSymbol Interface"
title: "ICorDebugStaticFieldSymbol Interface"
ms.date: "03/30/2017"
ms.assetid: c0b93609-631e-4b15-878a-189ede922631
---
# ICorDebugStaticFieldSymbol Interface

Represents the debug symbol information for a static field.

## Methods

|Method|Description|
|------------|-----------------|
|[GetAddress Method](icordebugstaticfieldsymbol-getaddress-method.md)|Gets the address of the static field.|
|[GetName Method](icordebugstaticfieldsymbol-getname-method.md)|Gets the name of the static field.|
|[GetSize Method](icordebugstaticfieldsymbol-getsize-method.md)|Gets the size in bytes of the static field.|

## Remarks

 The `ICorDebugStaticFieldSymbol` interface is used to retrieve the debug symbol information for a static field.

> [!NOTE]
> This interface is available with .NET Native only. If you implement this interface for ICorDebug scenarios outside of .NET Native, the common language runtime will ignore this interface.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_46_native](../../../../includes/net-46-native-md.md)]

## See also

- [ICorDebugInstanceFieldSymbol Interface](icordebuginstancefieldsymbol-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
