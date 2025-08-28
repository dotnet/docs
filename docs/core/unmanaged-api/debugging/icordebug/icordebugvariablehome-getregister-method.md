---
description: "Learn more about: ICorDebugVariableHome::GetRegister Method"
title: "ICorDebugVariableHome::GetRegister Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugVariableHome.GetRegister"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugVariableHome::GetRegister"
helpviewer_keywords:
  - "ICorDebugVariableHome::GetRegister method [.NET debugging]"
  - "GetRegister method, ICorDebugVariableHome interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugVariableHome::GetRegister Method

Gets the register that contains a variable with a location type of `VLT_REGISTER`, and the base register for a variable with a location type of `VLT_REGISTER_RELATIVE`.

## Syntax

```cpp
HRESULT GetRegister(
    [out] CorDebugRegister *pRegister
);
```

## Parameters

 `pRegister`
 [out] A CorDebugRegister enumeration value  that indicates the register for a variable with a location type of `VLT_REGISTER`, and the base register for a variable with a location type of `VLT_REGISTER_RELATIVE`.

## Return Value

 The method returns the following values:

|Value|Description|
|-----------|-----------------|
|`S_OK`|The variable is in the register indicated by the `pRegister` argument.|
|`E_FAIL`|The variable is not in a register or a register-relative location.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6.2

## See also

- [VariableLocationType Enumeration](variablelocationtype-enumeration.md)
- [ICorDebugVariableHome Interface](icordebugvariablehome-interface.md)
