---
description: "Learn more about: ICorDebugInternalFrame2::IsCloserToLeaf Method"
title: "ICorDebugInternalFrame2::IsCloserToLeaf Method"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugInternalFrame2.IsCloserToLeaf Method"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugInternalFrame2::IsCloserToLeaf"
helpviewer_keywords:
  - "ICorDebugInternalFrame2::IsCloserToLeaf method [.NET debugging]"
  - "IsCloserToLeaf method [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugInternalFrame2::IsCloserToLeaf Method

Checks whether the `this` internal frame is closer to the leaf than the specified ICorDebugFrame object.

## Syntax

```cpp
HRESULT IsCloserToLeaf([in] ICorDebugFrame * pFrameToCompare,
                       [out] BOOL * pIsCloser);
```

## Parameters

 `pFrameToCompare`
 [in] A pointer to the comparison `ICorDebugFrame` object.

 `pIsCloser`
 [out] `true` if the `this` internal frame is closer to the leaf than the frame specified by `pFrameToCompare`; otherwise, `false`.

## Return Value

 This method returns the following specific HRESULTs as well as HRESULT errors that indicate method failure.

|HRESULT|Description|
|-------------|-----------------|
|S_OK|The comparison was successfully performed.|
|E_FAIL|The comparison could not be performed.|
|E_INVALIDARG|`pFrameToCompare` or `pIsCloser` is null.|

## Remarks

 `IsCloserToLeaf` can be used to implement a policy for interleaving internal frames with other frames on the stack.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.0

## See also

- [ICorDebugInternalFrame2 Interface](icordebuginternalframe2-interface.md)
