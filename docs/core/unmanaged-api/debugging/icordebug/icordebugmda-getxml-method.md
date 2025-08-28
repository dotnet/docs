---
description: "Learn more about: ICorDebugMDA::GetXML Method"
title: "ICorDebugMDA::GetXML Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugMDA.GetXML"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugMDA::GetXML"
helpviewer_keywords:
  - "ICorDebugMDA::GetXML method [.NET debugging]"
  - "GetXML method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugMDA::GetXML Method

Gets the full XML stream associated with the managed debugging assistant (MDA) represented by [ICorDebugMDA](icordebugmda-interface.md).

## Syntax

```cpp
HRESULT GetXML (
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
 [out] A pointer to the length of the XML stream.

 `szName`
 [out] An array in which to store the XML stream. The array may be empty.

## Remarks

 The `GetXML` method can potentially affect performance, depending on the size of the associated XML stream.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorDebugMDA Interface](icordebugmda-interface.md)
- [Diagnose Errors with Managed Debugging Assistants](../../../../framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
