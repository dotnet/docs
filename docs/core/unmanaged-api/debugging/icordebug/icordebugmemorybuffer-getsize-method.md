---
description: "Learn more about: ICorDebugMemoryBuffer::GetSize Method"
title: "ICorDebugMemoryBuffer::GetSize Method"
ms.date: "03/30/2017"
---
# ICorDebugMemoryBuffer::GetSize Method

Gets the size of the memory buffer in bytes.

## Syntax

```cpp
HRESULT GetSize(
   [out] ULONG32 *pcbBufferLength
);
```

## Parameters

 `pcbBufferLength`
 [out] A pointer to the size of the memory buffer.

## Remarks

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugMemoryBuffer Interface](icordebugmemorybuffer-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
