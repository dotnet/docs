---
description: "Learn more about: ICorDebugEval2::CallParameterizedFunction Method"
title: "ICorDebugEval2::CallParameterizedFunction Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEval2.CallParameterizedFunction"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEval2::CallParameterizedFunction"
helpviewer_keywords:
  - "ICorDebugEval2::CallParameterizedFunction method [.NET debugging]"
  - "CallParameterizedFunction method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEval2::CallParameterizedFunction Method

Sets up a call to the specified ICorDebugFunction, which can be nested inside a class whose constructor takes <xref:System.Type> parameters, or can itself take <xref:System.Type> parameters.

## Syntax

```cpp
HRESULT CallParameterizedFunction (
    [in] ICorDebugFunction     *pFunction,
    [in] ULONG32               nTypeArgs,
    [in, size_is(nTypeArgs)] ICorDebugType *ppTypeArgs[],
    [in] ULONG32               nArgs,
    [in, size_is(nArgs)] ICorDebugValue *ppArgs[]
);
```

## Parameters

 `pFunction`
 [in] A pointer to an `ICorDebugFunction` object that represents the function to be called.

 `nTypeArgs`
 [in] The number of arguments that the function takes.

 `ppTypeArgs`
 [in] An array of pointers, each of which points to an ICorDebugType object that represents a function argument.

 `nArgs`
 [in] The number of values passed in the function.

 `ppArgs`
 [in] An array of pointers, each of which points to an ICorDebugValue object that represents a value passed in a function argument.

## Remarks

 `CallParameterizedFunction` is like [ICorDebugEval::CallFunction](icordebugeval-callfunction-method.md) except that the function may be inside a class with type parameters, may itself take type parameters, or both. The type arguments should be given first for the class, and then for the function.

If the function is in a different application domain, a transition will occur. However, all type and value arguments must be in the target application domain.

Function evaluation can be performed only in limited scenarios. If `CallParameterizedFunction` or `ICorDebugEval::CallFunction` fails, the returned HRESULT will indicate the most general possible reason for failure.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
