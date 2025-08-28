---
description: "Learn more about: ICorDebugVariableHome::GetOffset Method"
title: "ICorDebugVariableHome::GetOffset Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugVariableHome.GetOffset"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugVariableHome::GetOffset"
helpviewer_keywords:
  - "ICorDebugVariableHome::GetOffset method [.NET debugging]"
  - "GetOffset method, ICorDebugVariableHome interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugVariableHome::GetOffset Method

Gets the offset from the base register for a variable.

## Syntax

```cpp
HRESULT GetOffset(
    [out] LONG *pOffset
);
```

## Parameters

 `pOffset`
 [out] The offset from the base register.

## Return Value

 The method returns the following values:

|Value|Description|
|-----------|-----------------|
|`S_OK`|The variable is in a register-relative memory location.|
|`E_FAIL`|The variable is not in a register-relative memory location.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6.2

## See also

- [ICorDebugVariableHome Interface](icordebugvariablehome-interface.md)
