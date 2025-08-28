---
description: "Learn more about: ICorDebugMergedAssemblyRecord::GetCulture Method"
title: "ICorDebugMergedAssemblyRecord::GetCulture Method"
ms.date: "03/30/2017"
---
# ICorDebugMergedAssemblyRecord::GetCulture Method

Gets the culture name string of the assembly.

## Syntax

```cpp
HRESULT GetCulture(
   [in] ULONG32 cchCulture,
   [out] ULONG32 *pcchCulture,
   [out, size_is(cchCulture), length_is(*pcchCulture)] WCHAR szCulture[]
);
```

## Parameters

 `cchCulture`
 [in] The number of characters in the `szCulture` buffer.

 `pcchCulture`
 [out] The number of characters actually written to the `szCulture` buffer.

 `szCulture`
 [out] A character array that contains the culture name.

## Remarks

 The culture name is a unique string that identifies a culture, such as "en-US" (for the English (United States) culture), or "neutral" (for a neutral culture).

> [!NOTE]
> This method is available with .NET Native only.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.6

## See also

- [ICorDebugMergedAssemblyRecord Interface](icordebugmergedassemblyrecord-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
