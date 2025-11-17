---
description: "Learn more about: ICorDebugInternalFrame::GetFrameType Method"
title: "ICorDebugInternalFrame::GetFrameType Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugInternalFrame.GetFrameType"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugInternalFrame::GetFrameType"
helpviewer_keywords:
  - "GetFrameType method [.NET debugging]"
  - "ICorDebugInternalFrame::GetFrameType method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugInternalFrame::GetFrameType Method

Gets the type of this internal frame.

## Syntax

```cpp
HRESULT GetFrameType (
    [out] CorDebugInternalFrameType  *pType
);
```

## Parameters

 `pType`
 [out] A pointer to a value of the CorDebugInternalFrameType enumeration that indicates the type of internal frame represented by this `ICorDebugInternalFrame` object.

## Remarks

The internal frame type will never be STUBFRAME_NONE. Debuggers should gracefully ignore unrecognized internal frame types.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
