---
description: "Learn more about: ICorDebugMutableDataTarget Interface"
title: "ICorDebugMutableDataTarget Interface"
ms.date: "03/30/2017"
---
# ICorDebugMutableDataTarget Interface

Extends the [ICorDebugDataTarget](icordebugdatatarget-interface.md) interface to support mutable data targets.

## Methods

|Method|Description|
|------------|-----------------|
|[ContinueStatusChanged Method](icordebugmutabledatatarget-continuestatuschanged-method.md)|Changes the continuation status for the outstanding debug event on the specified thread.|
|[SetThreadContext Method](icordebugmutabledatatarget-setthreadcontext-method.md)|Sets the context (register values) for a thread.|
|[WriteVirtual Method](icordebugmutabledatatarget-writevirtual-method.md)|Writes memory into the target process address space.|

## Remarks

 This extension to the [ICorDebugDataTarget](icordebugdatatarget-interface.md) interface can be implemented by debugging tools that wish to modify the target process (for example, to perform live invasive debugging).

 All of these methods are optional in the sense that no core inspection-based debugging functionality is lost by not implementing this interface or by the failure of calls to these methods.  Any failure `HRESULT` from these methods will propagate out as the `HRESULT` from the ICorDebug method call.

 Note that a single ICorDebug method call may result in multiple mutations, and that there is no mechanism for ensuring related mutations are applied transactionally (all-or-none).  This means that if a mutation fails after others (for the same ICorDebug call) have succeeded, the target process may be left in an inconsistent state and debugging may become unreliable.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
