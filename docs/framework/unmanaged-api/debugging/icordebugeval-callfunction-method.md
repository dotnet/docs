---
description: "Learn more about: ICorDebugEval::CallFunction Method"
title: "ICorDebugEval::CallFunction Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEval.CallFunction"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEval::CallFunction"
helpviewer_keywords:
  - "ICorDebugEval::CallFunction method [.NET Framework debugging]"
  - "CallFunction method [.NET Framework debugging]"
ms.assetid: 7f470c5c-e1c0-4d8d-aad8-830f113ae751
topic_type:
  - "apiref"
---
# ICorDebugEval::CallFunction Method

Sets up a call to the specified function.

This method is obsolete in the .NET Framework version 2.0. Use [ICorDebugEval2::CallParameterizedFunction](icordebugeval2-callparameterizedfunction-method.md) instead.

## Syntax

```cpp
HRESULT CallFunction (
    [in] ICorDebugFunction  *pFunction,
    [in] ULONG32            nArgs,
    [in, size_is(nArgs)] ICorDebugValue *ppArgs[]
);
```

## Parameters

`pFunction`\
[in] Pointer to an ICorDebugFunction object that specifies the function to be called.

`nArgs`\
[in] The number of arguments for the function.

`ppArgs`\
[in] An array of pointers, each of which points to an ICorDebugValue object that specifies an argument to be passed to the function.

## Remarks

If the function is virtual, `CallFunction` will perform virtual dispatch. If the function is in a different application domain, a transition will occur as long as all arguments are also in that application domain.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** CorDebug.idl, CorDebug.h

**Library:** CorGuids.lib

**.NET Framework Versions:** 1.1, 1.0

## See also

- [CallParameterizedFunction Method](icordebugeval2-callparameterizedfunction-method.md)
