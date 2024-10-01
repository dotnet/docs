---
description: "Learn more about: ICorDebugEnum Interface"
title: "ICorDebugEnum Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugEnum"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugEnum"
helpviewer_keywords:
  - "ICorDebugEnum interface [.NET Framework debugging]"
ms.assetid: 80be7efe-2c32-4b9f-8c52-40c6f6268219
topic_type:
  - "apiref"
---
# ICorDebugEnum Interface

Serves as the abstract base interface for the enumerators that are used by a debugging application.

## Methods

|Method|Description|
|------------|-----------------|
|[Clone Method](icordebugenum-clone-method.md)|Creates a copy of this `ICorDebugEnum` object.|
|[GetCount Method](icordebugenum-getcount-method.md)|Gets the number of items in the enumeration.|
|[Reset Method](icordebugenum-reset-method.md)|Moves the cursor to the beginning of the enumeration.|
|[Skip Method](icordebugenum-skip-method.md)|Moves the cursor forward in the enumeration by the specified number of items.|

## Remarks

 The following enumerators derive from `ICorDebugEnum`:

- "ICorDebugAppDomainEnum"

- "ICorDebugAssemblyEnum"

- [ICorDebugBlockingObjectEnum](icordebugblockingobjectenum-interface.md)

- "ICorDebugBreakpointEnum"

- "ICorDebugChainEnum"

- "ICorDebugCodeEnum"

- "ICorDebugErrorInfoEnum"

- [ICorDebugExceptionObjectCallStackEnum](icordebugexceptionobjectcallstackenum-interface.md)

- "ICorDebugFrameEnum"

- [ICorDebugGCReferenceEnum](icordebuggcreferenceenum-interface.md)

- [ICorDebugGuidToTypeEnum](icordebugguidtotypeenum-interface.md)

- [ICorDebugHeapEnum](icordebugheapenum-interface.md)

- [ICorDebugHeapSegmentEnum](icordebugheapsegmentenum-interface.md)

- "ICorDebugModuleEnum"

- "ICorDebugObjectEnum"

- "ICorDebugProcessEnum"

- "ICorDebugStepperEnum"

- "ICorDebugThreadEnum"

- "ICorDebugTypeEnum"

- "ICorDebugValueEnum"

- [ICorDebugVariableHomeEnum](icordebugvariablehomeenum-interface.md)

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
