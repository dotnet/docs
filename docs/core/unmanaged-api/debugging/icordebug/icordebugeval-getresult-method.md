---
description: "Learn more about: ICorDebugEval::GetResult Method"
title: "ICorDebugEval::GetResult Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEval.GetResult"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEval::GetResult"
helpviewer_keywords:
  - "ICorDebugEval::GetResult method [.NET debugging]"
  - "GetResult method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugEval::GetResult Method

Gets the results of this evaluation.

## Syntax

```cpp
HRESULT GetResult (
    [out] ICorDebugValue    **ppResult
);
```

## Parameters

 `ppResult`
 [out] Pointer to the address of an ICorDebugValue object that represents the results of this evaluation, if the evaluation completes normally.

## Remarks

The `GetResult` method is valid only after the evaluation is completed.

If the evaluation completes normally, `ppResult` specifies the results. If it terminates with an exception, the result is the exception thrown. If the evaluation was for a new object, the result is the reference to the new object.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
