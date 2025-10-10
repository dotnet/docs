---
description: "Learn more about: ICorDebugMDA::GetName Method"
title: "ICorDebugMDA::GetName Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugMDA.GetName"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugMDA::GetName"
helpviewer_keywords:
  - "ICorDebugMDA::GetName method [.NET debugging]"
  - "GetName method, ICorDebugMDA interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugMDA::GetName Method

Gets a string containing the name of the managed debugging assistant (MDA) represented by [ICorDebugMDA](icordebugmda-interface.md).

## Syntax

```cpp
HRESULT GetName (
    [in] ULONG32   cchName,
    [out] ULONG32  *pcchName,
    [out, size_is(cchName), length_is(*pcchName)]
        WCHAR      szName[]
);
```

## Parameters

 `cchName`
 [in] The size of the `szName` array.

 `pcchName`
 [out] A pointer to the length of the name.

 `szName`
 [out] An array in which to store the name.

## Remarks

MDA names are unique values. The `GetName` method is a convenient performance alternative to getting the XML stream and extracting the name from the stream based on the schema.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorDebugMDA Interface](icordebugmda-interface.md)
- [Diagnose Errors with Managed Debugging Assistants](../../../../framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
