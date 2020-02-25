---
title: "ICorDebugProcess2::GetVersion Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugProcess2.GetVersion"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugProcess2::GetVersion"
helpviewer_keywords:
  - "GetVersion method, ICorDebugProcess2 interface [.NET Framework debugging]"
  - "ICorDebugProcess2::GetVersion method [.NET Framework debugging]"
ms.assetid: e11d5a75-61d9-4548-aedf-79c26079bd17
topic_type:
  - "apiref"
---

# ICorDebugProcess2::GetVersion Method

Gets the version number of the common language runtime (CLR) that is running in this process.

## Syntax

```cpp
HRESULT GetVersion (
    [out] COR_VERSION     *version
);
```

## Parameters

`version`\
[out] A pointer to a COR_VERSION structure that stores the version number of the runtime.

## Remarks

The `GetVersion` method returns an error code if no runtime has been loaded in the process.

## Requirements

**Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).

**Header:** CorDebug.idl, CorDebug.h

**Library:** CorGuids.lib

**.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
