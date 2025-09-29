---
description: "Learn more about: ICorDebugModule::GetProcess Method"
title: "ICorDebugModule::GetProcess Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule.GetProcess"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule::GetProcess"
helpviewer_keywords:
  - "GetProcess method, ICorDebugModule interface [.NET debugging]"
  - "ICorDebugModule::GetProcess method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule::GetProcess Method

Gets the containing process of this module.

## Syntax

```cpp
HRESULT GetProcess (
    [out] ICorDebugProcess **ppProcess
);
```

## Parameters

 `ppProcess`
 [out] A pointer to the address of an ICorDebugProcess object that represents the process containing this module.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
