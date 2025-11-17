---
description: "Learn more about: ICorDebugNativeFrame2 Interface"
title: "ICorDebugNativeFrame2 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugNativeFrame2"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugNativeFrame2"
helpviewer_keywords:
  - "ICorDebugNativeFrame2 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugNativeFrame2 Interface

Provides methods that test for child and parent frame relationships.

## Methods

|Method|Description|
|------------|-----------------|
|[IsChild Method](icordebugnativeframe2-ischild-method.md)|Determines whether the current frame is a child frame.|
|[IsMatchingParentFrame Method](icordebugnativeframe2-ismatchingparentframe-method.md)|Determines whether the specified frame is the parent of the current frame.|
|[GetStackParameterSize Method](icordebugnativeframe2-getstackparametersize-method.md)|Returns the cumulative size of the parameters on the stack on x86 operating systems.|

## Remarks

This interface logically extends the "ICorDebugNativeFrame" interface.

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.0
