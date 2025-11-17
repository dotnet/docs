---
description: "Learn more about: VariableLocationType Enumeration"
title: "VariableLocationType Enumeration"
ms.date: "03/30/2017"
api_name:
  - "VariableLocationType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "VariableLocationType"
helpviewer_keywords:
  - "VariableLocationType enumeration [.NET debugging]"
topic_type:
  - "apiref"
---
# VariableLocationType Enumeration

Indicates the native location type of a variable.

## Syntax

```cpp
typedef enum VariableLocationType
{
    VLT_REGISTER,
    VLT_REGISTER_RELATIVE,
    VLT_INVALID
} VariableLocationType;
```

## Members

| Member                  | Description                                                                      |
|-------------------------|----------------------------------------------------------------------------------|
| `VLT_REGISTER`          | The variable is in a register.                                                   |
| `VLT_REGISTER_RELATIVE` | The variable is in a register-relative memory location.                          |
| `VLT_INVALID`           | The variable is not stored in a register or a register-relative memory location. |

## Remarks

 A member of the `VariableLocationType` enumeration is returned by the [ICorDebugVariableHome::GetLocationType](icordebugvariablehome-getlocationtype-method.md) method.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6.2
