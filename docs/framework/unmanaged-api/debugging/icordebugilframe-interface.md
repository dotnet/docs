---
description: "Learn more about: ICorDebugILFrame Interface"
title: "ICorDebugILFrame Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugILFrame"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugILFrame"
helpviewer_keywords:
  - "ICorDebugILFrame interface [.NET Framework debugging]"
ms.assetid: d5cf5056-da4d-4629-914d-afe42a5393df
topic_type:
  - "apiref"
---
# ICorDebugILFrame Interface

Represents a stack frame of common intermediate language (CIL) code. This interface is a subclass of the ICorDebugFrame interface.

## Methods

|Method|Description|
|------------|-----------------|
|[CanSetIP Method](icordebugilframe-cansetip-method.md)|Gets a value that indicates whether it is safe to set the instruction pointer to the specified offset location.|
|[EnumerateArguments Method](icordebugilframe-enumeratearguments-method.md)|Gets an enumerator for the arguments in this frame.|
|[EnumerateLocalVariables Method](icordebugilframe-enumeratelocalvariables-method.md)|Gets an enumerator for the local variables in this frame.|
|[GetArgument Method](icordebugilframe-getargument-method.md)|Gets the value of the specified argument in this CIL stack frame.|
|[GetIP Method](icordebugilframe-getip-method.md)|Gets the value of the instruction pointer and a bitwise combination value that describes how the value of the instruction pointer was obtained.|
|[GetLocalVariable Method](icordebugilframe-getlocalvariable-method.md)|Gets the value of the specified local variable in this CIL stack frame.|
|[GetStackDepth Method](icordebugilframe-getstackdepth-method.md)|Not implemented.|
|[GetStackValue Method](icordebugilframe-getstackvalue-method.md)|Not implemented.|
|[SetIP Method](icordebugilframe-setip-method.md)|Sets the instruction pointer to the specified offset location in the CIL code.|

## Remarks

 The `ICorDebugILFrame` interface is a specialized ICorDebugFrame interface. It is used either for CIL code frames or for just-in-time (JIT) compiled frames. The JIT-compiled frames implement both the `ICorDebugILFrame` interface and the ICorDebugNativeFrame interface.

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
