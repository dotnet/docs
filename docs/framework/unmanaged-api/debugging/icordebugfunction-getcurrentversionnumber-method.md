---
description: "Learn more about: ICorDebugFunction::GetCurrentVersionNumber Method"
title: "ICorDebugFunction::GetCurrentVersionNumber Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFunction.GetCurrentVersionNumber"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugFunction::GetCurrentVersionNumber"
helpviewer_keywords:
  - "GetCurrentVersionNumber method [.NET Framework debugging]"
  - "ICorDebugFunction::GetCurrentVersionNumber method [.NET Framework debugging]"
ms.assetid: c3af1575-cbe6-457a-bc08-c53460edcbc8
topic_type:
  - "apiref"
---
# ICorDebugFunction::GetCurrentVersionNumber Method

Gets the version number of the latest edit made to the function represented by this ICorDebugFunction object.

## Syntax

```cpp
HRESULT GetCurrentVersionNumber (
    [out] ULONG32 *pnCurrentVersion
);
```

## Parameters

 `pnCurrentVersion`
 [out] A pointer to an integer value that is the version number of the latest edit made to this function.

## Remarks

 The version number of the latest edit made to this function may be greater than the version number of the function itself. Use either the [ICorDebugFunction2::GetVersionNumber](icordebugfunction2-getversionnumber-method.md) method or the [ICorDebugCode::GetVersionNumber](icordebugcode-getversionnumber-method.md) method to retrieve the version number of the function.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
