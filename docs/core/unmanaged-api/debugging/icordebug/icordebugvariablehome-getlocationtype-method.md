---
description: "Learn more about: ICorDebugVariableHome::GetLocationType Method"
title: "ICorDebugVariableHome::GetLocationType Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugVariableHome.GetLocationType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugVariableHome::GetLocationType"
helpviewer_keywords:
  - "ICorDebugVariableHome::GetLocationType method [.NET debugging]"
  - "GetLocationType method, ICorDebugVariableHome interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugVariableHome::GetLocationType Method

Gets the type of the variable's native location.

## Syntax

```cpp
HRESULT GetLocationType(
    [out] VariableLocationType *pLocationType
);
```

## Parameters

 `pLocationType`
 [out] A pointer to the type of the variable's native location.  See the [VariableLocationType](variablelocationtype-enumeration.md) enumeration for more information.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6.2

## See also

- [ICorDebugVariableHome Interface](icordebugvariablehome-interface.md)
- [VariableLocationType Enumeration](variablelocationtype-enumeration.md)
