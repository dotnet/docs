---
description: "Learn more about: ICorDebugVariableSymbol Interface"
title: "ICorDebugVariableSymbol Interface"
ms.date: "03/30/2017"
ms.assetid: 0e58b85e-69bd-41ff-bedb-8cdc8be6a7a2
---
# ICorDebugVariableSymbol Interface

Retrieves the debug symbol information for a variable.

## Methods

|Method|Description|
|------------|-----------------|
|[GetName Method](icordebugvariablesymbol-getname-method.md)|Gets the name of a variable.|
|[GetSize Method](icordebugvariablesymbol-getsize-method.md)|Gets the size of a variable in bytes.|
|[GetSlotIndex Method](icordebugvariablesymbol-getslotindex-method.md)|Gets the managed slot index of a local variable.|
|[GetValue Method](icordebugvariablesymbol-getvalue-method.md)|Gets the value of a variable as a byte array.|
|[SetValue Method](icordebugvariablesymbol-setvalue-method.md)|Assigns the value of a byte array to a variable.|

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
