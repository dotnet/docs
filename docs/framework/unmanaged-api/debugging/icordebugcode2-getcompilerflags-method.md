---
description: "Learn more about: ICorDebugCode2::GetCompilerFlags Method"
title: "ICorDebugCode2::GetCompilerFlags Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCode2.GetCompilerFlags"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCode2::GetCompilerFlags"
helpviewer_keywords:
  - "GetCompilerFlags method [.NET Framework debugging]"
  - "ICorDebugCode2::GetCompilerFlags method [.NET Framework debugging]"
ms.assetid: 532e9dfd-d114-4c75-b952-1accce102643
topic_type:
  - "apiref"
---
# ICorDebugCode2::GetCompilerFlags Method

Gets the flags that specify the conditions under which this code object was either just-in-time (JIT) compiled or generated using the native image generator (Ngen.exe).

## Syntax

```cpp
HRESULT GetCompilerFlags (
    [out] DWORD *pdwFlags
);
```

## Parameters

`pdwFlags`  
[out] A pointer to a value of the [CorDebugJITCompilerFlags](cordebugjitcompilerflags-enumeration.md) enumeration that specifies the behavior of the JIT compiler or the native image generator.

## Requirements

**Platforms:** See [System Requirements](../../get-started/system-requirements.md).

**Header:** CorDebug.idl, CorDebug.h

**Library:** CorGuids.lib

**.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
