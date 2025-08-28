---
description: "Learn more about: ICorDebugThread3::CreateStackWalk Method"
title: "ICorDebugThread3::CreateStackWalk Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugThread3.CreateStackWalk Method"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugThread3::CreateStackWalk"
helpviewer_keywords:
  - "CreateStackWalk method [.NET debugging]"
  - "ICorDebugThread3::CreateStackWalk method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugThread3::CreateStackWalk Method

Creates an [ICorDebugStackWalk](icordebugstackwalk-interface.md) object for the thread whose stack you want to unwind.

## Syntax

```cpp
HRESULT CreateStackWalk([out] ICorDebugStackWalk **ppStackWalk);
```

## Parameters

 `ppStackWalk`
 [out] A pointer to address of the [ICorDebugStackWalk](icordebugstackwalk-interface.md) object for the thread whose stack you want to unwind.

## Return Value

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The `ICorDebugStackWalk` object was successfully created.|
|E_FAIL|The `ICorDebugStackWalk` object was not created.|

## Exceptions

## Remarks

 If the `CreateStackWalk` method succeeds, the returned `ICorDebugStackWalk` object's context is set to the thread's current context.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.0
