---
description: "Learn more about: ICorDebugStaticFieldSymbol Interface"
title: "ICorDebugStaticFieldSymbol Interface"
ms.date: "03/30/2017"
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

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugInstanceFieldSymbol Interface](icordebuginstancefieldsymbol-interface.md)
