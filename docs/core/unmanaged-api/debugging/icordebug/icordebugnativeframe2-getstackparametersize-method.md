---
description: "Learn more about: ICorDebugNativeFrame2::GetStackParameterSize Method"
title: "ICorDebugNativeFrame2::GetStackParameterSize Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugNativeFrame2.GetStackParameterSize Method"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugNativeFrame2::GetStackParameterSize"
helpviewer_keywords:
  - "ICorDebugNativeFrame2::GetStackParameterSize method [.NET debugging]"
  - "GetStackParameterSize method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugNativeFrame2::GetStackParameterSize Method

Returns the cumulative size of the parameters on the stack on x86 operating systems.

## Syntax

```cpp
HRESULT GetStackParameterSize([out] ULONG32 * pSize)
```

## Parameters

 `pSize`
 [out] A pointer to the cumulative size of the parameters on the stack.

## Return Value

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The stack size was successfully returned.|
|S_FALSE|`GetStackParameterSize` was called on a non-x86 platform.|
|E_FAIL|`The size of the parameters could not be returned`.|
|E_INVALIDARG|`pSize` Is `null`.|

## Exceptions

## Remarks

 The [ICorDebugStackWalk](icordebugstackwalk-interface.md) methods do not adjust the stack pointer for parameters that are pushed on the stack. Instead, you can use the value returned by `GetStackParameterSize` to adjust the stack pointer to seed a native unwinder, which does adjust for the parameters.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.0

## See also

- [ICorDebugNativeFrame2 Interface](icordebugnativeframe2-interface.md)
