---
description: "Learn more about: ICorDebugMemoryBuffer Interface"
title: "ICorDebugMemoryBuffer Interface"
ms.date: "03/30/2017"
---
# ICorDebugMemoryBuffer Interface

Represents an in-memory buffer.

## Methods

|Method|Description|
|------------|-----------------|
|[GetSize Method](icordebugmemorybuffer-getsize-method.md)|Gets the size of the memory buffer in bytes.|
|[GetStartAddress Method](icordebugmemorybuffer-getstartaddress-method.md)|Gets the starting address of the memory buffer.|

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
