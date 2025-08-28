---
description: "Learn more about: ICorDebugInstanceFieldSymbol Interface"
title: "ICorDebugInstanceFieldSymbol Interface"
ms.date: "03/30/2017"
---
# ICorDebugInstanceFieldSymbol Interface

Represents the debug symbol information for an instance field.

## Methods

|Method|Description|
|------------|-----------------|
|[GetName Method](icordebuginstancefieldsymbol-getname-method.md)|Gets the name of the instance field.|
|[GetOffset Method](icordebuginstancefieldsymbol-getoffset-method.md)|Gets the offset in bytes of this instance field in its parent class.|
|[GetSize Method](icordebuginstancefieldsymbol-getsize-method.md)|Gets the size in bytes of the instance field.|

## Remarks

 The `ICorDebugInstanceFieldSymbol` interface is used to retrieve the debug symbol information for an instance field.

> [!NOTE]
> This interface is available with .NET Native only. If you implement this interface for ICorDebug scenarios outside of .NET Native, the common language runtime will ignore this interface.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugStaticFieldSymbol Interface](icordebugstaticfieldsymbol-interface.md)
