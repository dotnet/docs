---
description: "Learn more about: ICorDebugMemoryBuffer::GetStartAddress Method"
title: "ICorDebugMemoryBuffer::GetStartAddress Method"
ms.date: "03/30/2017"
---
# ICorDebugMemoryBuffer::GetStartAddress Method

Gets the starting address of the memory buffer.

## Syntax

```cpp
HRESULT GetStartAddress(
   [out] LPCVOID *address
);
```

## Parameters

 `address`
 [out] A pointer to the starting address of the memory buffer.

## Remarks

> [!WARNING]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugMemoryBuffer Interface](icordebugmemorybuffer-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
