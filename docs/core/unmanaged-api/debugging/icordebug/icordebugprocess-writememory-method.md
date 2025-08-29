---
description: "Learn more about: ICorDebugProcess::WriteMemory Method"
title: "ICorDebugProcess::WriteMemory Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess.WriteMemory"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess::WriteMemory"
helpviewer_keywords:
  - "ICorDebugProcess::WriteMemory method [.NET debugging]"
  - "WriteMemory method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess::WriteMemory Method

Writes data to an area of memory in this process.

## Syntax

```cpp
HRESULT WriteMemory(
    [in]  CORDB_ADDRESS address,
    [in]  DWORD size,
    [in, size_is(size)] BYTE buffer[],
    [out] SIZE_T *written);
```

## Parameters

 `address`
 [in] A `CORDB_ADDRESS` value that is the base address of the memory area to which data is written. Before data transfer occurs, the system verifies that the memory area of the specified size, beginning at the base address, is accessible for writing. If it is not accessible, the method fails.

 `size`
 [in] The number of bytes to be written to the memory area.

 `buffer`
 [in] A buffer that contains data to be written.

 `written`
 [out] A pointer to a variable that receives the number of bytes written to the memory area in this process. If `written` is NULL, this parameter is ignored.

## Remarks

Data is automatically written behind any breakpoints. Native debuggers should not use this method to inject breakpoints into the instruction stream. Use [ICorDebugProcess2::SetUnmanagedBreakpoint](icordebugprocess2-setunmanagedbreakpoint-method.md) instead.

The `WriteMemory` method should be used only outside of managed code. This method can corrupt the runtime if used improperly.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
