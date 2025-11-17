---
description: "Learn more about: ICorDebugModule2 Interface"
title: "ICorDebugModule2 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugModule2"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugModule2"
helpviewer_keywords:
  - "ICorDebugModule2 interface [.NET debugging]"
topic_type:
  - "apiref"
---
# ICorDebugModule2 Interface

Serves as a logical extension to the ICorDebugModule interface.

## Methods

|Method|Description|
|------------|-----------------|
|[ApplyChanges Method](icordebugmodule2-applychanges-method.md)|Applies the changes in the metadata and the changes in the common intermediate language (CIL) code to the running process.|
|[GetJITCompilerFlags Method](icordebugmodule2-getjitcompilerflags-method.md)|Gets the flags that control the just-in-time (JIT) compilation for this `ICorDebugModule2`.|
|[ResolveAssembly Method](icordebugmodule2-resolveassembly-method.md)|Resolves the assembly referenced by the specified metadata token.|
|[SetJITCompilerFlags Method](icordebugmodule2-setjitcompilerflags-method.md)|Sets the flags that control the JIT compilation for this `ICorDebugModule2`.|
|[SetJMCStatus Method](icordebugmodule2-setjmcstatus-method.md)|Sets the Just My Code (JMC) status of all methods of all the classes in this `ICorDebugModule2` to the specified value, except those in the `pTokens` array, which it sets to the opposite value.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 2.0
