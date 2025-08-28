---
description: "Learn more about: ICorDebugVirtualUnwinder Interface"
title: "ICorDebugVirtualUnwinder Interface"
ms.date: "03/30/2017"
---
# ICorDebugVirtualUnwinder Interface

Provides methods to help in stack unwinding.

## Methods

|Method|Name|
|------------|----------|
|[GetContext Method](icordebugvirtualunwinder-getcontext-method.md)|Gets the current context of this unwinder.|
|[Next Method](icordebugvirtualunwinder-next-method.md)|Advances to the caller's context.|

## Remarks

 The members of the `ICorDebugVirtualUnwinder` interface are implemented by the debugger to help in stack unwinding.

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
