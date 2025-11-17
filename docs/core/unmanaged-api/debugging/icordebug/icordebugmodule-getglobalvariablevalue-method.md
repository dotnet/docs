---
description: "Learn more about: ICorDebugModule::GetGlobalVariableValue Method"
title: "ICorDebugModule::GetGlobalVariableValue Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule.GetGlobalVariableValue"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule::GetGlobalVariableValue"
helpviewer_keywords:
  - "ICorDebugModule::GetGlobalVariableValue method [.NET debugging]"
  - "GetGlobalVariableValue method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule::GetGlobalVariableValue Method

Gets the value of the specified global variable.

## Syntax

```cpp
HRESULT GetGlobalVariableValue(
    [in]  mdFieldDef      fieldDef,
    [out] ICorDebugValue  **ppValue
);
```

## Parameters

 `fieldDef`
 [in] An `mdFieldDef` token that references the metadata describing the global variable.

 `ppValue`
 [out] A pointer to the address of an ICorDebugValue object that represents the value of the specified global variable.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
