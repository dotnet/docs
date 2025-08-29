---
description: "Learn more about: ICorDebugDataTarget Interface"
title: "ICorDebugDataTarget Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugDataTarget"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugDataTarget"
helpviewer_keywords:
  - "ICorDebugDataTarget interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugDataTarget Interface

Provides a callback interface that provides access to a particular target process.

## Methods

| Method | Description |
|--------|-------------|
|[GetPlatform Method](icordebugdatatarget-getplatform-method.md)|Provides information about the platform, including processor architecture and operating system, on which the target process is running.|
|[ReadVirtual Method](icordebugdatatarget-readvirtual-method.md)|Gets a block of contiguous memory starting at the specified address, and returns it in the supplied buffer.|
|[GetThreadContext Method](icordebugdatatarget-getthreadcontext-method.md)|Requests the current thread context for the specified thread.|

## Remarks

 `ICorDebugDataTarget` and its methods have the following characteristics:

- The debugging services call methods on this interface to access memory and other data in the target process.
- The debugger client must implement this interface as appropriate for the particular target (for example, a live process or a memory dump).
- The `ICorDebugDataTarget` methods can be invoked only from within methods implemented in other `ICorDebug*` interfaces. This ensures that the debugger client has control over which thread it is invoked on, and when.
- The `ICorDebugDataTarget` implementation must always return up-to-date information about the target.

The target process should be stopped and not changed in any way while `ICorDebug*` interfaces (and therefore `ICorDebugDataTarget` methods) are being called. If the target is a live process and its state changes, the [ICLRDebugging::OpenVirtualProcess](../../../../framework/unmanaged-api/debugging/iclrdebugging-openvirtualprocess-method.md) method has to be called again to provide a replacement `ICorDebugProcess` instance.

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.0
