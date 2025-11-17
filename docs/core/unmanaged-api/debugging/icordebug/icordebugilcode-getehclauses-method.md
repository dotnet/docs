---
description: "Learn more about: ICorDebugILCode::GetEHClauses Method"
title: "ICorDebugILCode::GetEHClauses Method"
ms.date: "03/30/2017"
dev_langs:
  - "cpp"
api_name:
  - "ICorDebugILCode.GetEHClauses"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
topic_type:
  - "apiref"
---
# ICorDebugILCode::GetEHClauses Method

Returns a pointer to a list of exception handling (EH) clauses that are defined for this intermediate language (IL).

## Syntax

```cpp
HRESULT GetEHClauses(
   [in] ULONG32 cClauses,
   [out] ULONG32 * pcClauses,
   [out, size_is(cClauses), length_is(*pcClauses)] CorDebugEHClause clauses[]);
```

## Parameters

 `cClauses`
 [in] The storage capacity of the `clauses` array. See the Remarks section for more information.

 `pcClauses`
 [out] The number of clauses about which information is written to the `clauses` array.

clauses
 [out] An array of [CorDebugEHClause](cordebugehclause-structure.md) objects that contain information on exception handling clauses defined for this IL.

## Remarks

If `cClauses` is 0 and `pcClauses` is non-**null**, `pcClauses` is set to the number of available exception handling clauses. If `cClauses` is non-zero, it represents the storage capacity of the `clauses` array. When the method returns, `clauses` contains a maximum of `cClauses` items, and `pcClauses` is set to the number of clauses actually written to the `clauses` array.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5.2

## See also

- [ICorDebugILCode Interface](icordebugilcode-interface.md)
- [CorDebugEHClause Structure](cordebugehclause-structure.md)
