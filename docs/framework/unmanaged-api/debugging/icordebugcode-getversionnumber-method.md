---
description: "Learn more about: ICorDebugCode::GetVersionNumber Method"
title: "ICorDebugCode::GetVersionNumber Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugCode.GetVersionNumber"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugCode::GetVersionNumber"
helpviewer_keywords: 
  - "GetVersionNumber method, ICorDebugCode interface [.NET Framework debugging]"
  - "ICorDebugCode::GetVersionNumber method [.NET Framework debugging]"
ms.assetid: c8e02518-679f-4e9f-8a28-ba4a89a3876f
topic_type: 
  - "apiref"
---
# ICorDebugCode::GetVersionNumber Method

Gets the one-based number that identifies the version of the code that this "ICorDebugCode" represents.

## Syntax

```cpp
HRESULT GetVersionNumber (
    [out] ULONG32    *nVersion
);
```

## Parameters

 `nVersion`  
 [out] A pointer to the version number of the code.

## Remarks

 The version number is incremented each time an edit-and-continue (EnC) operation is performed on the code.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
