---
description: "Learn more about: ICorDebugNativeFrame2::IsChild Method"
title: "ICorDebugNativeFrame2::IsChild Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugNativeFrame2.IsChild Method"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugNativeFrame2::IsChild"
helpviewer_keywords:
  - "IsChild method [.NET debugging]"
  - "ICorDebugNativeFrame2::IsChild method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugNativeFrame2::IsChild Method

Determines whether the current frame is a child frame.

## Syntax

```cpp
HRESULT IsChild([out] BOOL * pIsChild);
```

## Parameters

 `pIsChild`
 [out] A Boolean value that specifies whether the current frame is a child frame.

## Return Value

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The child status was successfully returned.|
|E_FAIL|The child status could not be returned.|
|E_INVALIDARG|`pIsChild` is null.|

## Exceptions

## Remarks

 The `IsChild` method returns `true` if the frame object on which you call the method is a child of another frame. If this is the case, use the [IsMatchingParentFrame](icordebugnativeframe2-ismatchingparentframe-method.md) method to check whether a frame is its parent.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.0

## See also

- [ICorDebugNativeFrame2 Interface](icordebugnativeframe2-interface.md)
