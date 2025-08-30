---
description: "Learn more about: ICorDebugProcess::GetID Method"
title: "ICorDebugProcess::GetID Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess.GetID"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess::GetID"
helpviewer_keywords:
  - "GetID method, ICorDebugProcess interface [.NET debugging]"
  - "ICorDebugProcess::GetID method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugProcess::GetID Method

Gets the operating system (OS) ID of the process.

## Syntax

```cpp
HRESULT GetID([out] DWORD *pdwProcessId);
```

## Parameters

 `pdwProcessId`
 [out] The unique ID of the process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 1.0
