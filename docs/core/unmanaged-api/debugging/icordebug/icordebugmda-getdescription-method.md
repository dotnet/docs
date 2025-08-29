---
description: "Learn more about: ICorDebugMDA::GetDescription Method"
title: "ICorDebugMDA::GetDescription Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugMDA.GetDescription"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugMDA::GetDescription"
helpviewer_keywords:
  - "GetDescription method [.NET debugging]"
  - "ICorDebugMDA::GetDescription method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugMDA::GetDescription Method

Gets a string containing the description of the managed debugging assistant (MDA) represented by [ICorDebugMDA](icordebugmda-interface.md).

## Syntax

```cpp
HRESULT GetDescription (
    [in] ULONG32   cchName,
    [out] ULONG32  *pcchName,
    [out, size_is(cchName), length_is(*pcchName)]
        WCHAR      szName[]
);
```

## Parameters

 `cchName`
 [in] The size of the string buffer that will store the description.

 `pcchName`
 [out] A pointer to the number of bytes returned in the string buffer.

 `szName`
 [out] A string buffer containing the description of the MDA.

## Remarks

The string can be zero in length.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorDebugMDA Interface](icordebugmda-interface.md)
- [Diagnose Errors with Managed Debugging Assistants](../../../../framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
