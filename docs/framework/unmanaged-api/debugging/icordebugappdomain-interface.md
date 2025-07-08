---
description: "Learn more about: ICorDebugAppDomain Interface"
title: "ICorDebugAppDomain Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugAppDomain"
api_location:
  - "corguids.lib"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugAppDomain"
helpviewer_keywords:
  - "ICorDebugAppDomain interface [.NET Framework debugging]"
ms.assetid: be7ae711-1217-4a44-be40-166e29641b77
topic_type:
  - "apiref"
---
# ICorDebugAppDomain Interface

Provides methods for debugging application domains. This interface is a subclass of ICorDebugController.

## Methods

|Method|Description|
|------------|-----------------|
|[Attach Method](icordebugappdomain-attach-method.md)|Attaches the debugger to the application domain.|
|[EnumerateAssemblies Method](icordebugappdomain-enumerateassemblies-method.md)|Gets an enumerator for the assemblies in the application domain.|
|[EnumerateBreakpoints Method](icordebugappdomain-enumeratebreakpoints-method.md)|Gets an enumerator for all active breakpoints in the application domain.|
|[EnumerateSteppers Method](icordebugappdomain-enumeratesteppers-method.md)|Gets an enumerator for all active steppers in the application domain.|
|[GetId Method](icordebugappdomain-getid-method.md)|Gets the unique ID of the application domain.|
|[GetModuleFromMetaDataInterface Method](icordebugappdomain-getmodulefrommetadatainterface-method.md)|Gets the ICorDebugModule object with the given metadata interface.|
|[GetName Method](icordebugappdomain-getname-method.md)|Gets the name of the application domain.|
|[GetObject Method](icordebugappdomain-getobject-method.md)|Gets an interface pointer to the common language runtime (CLR) application domain.|
|[GetProcess Method](icordebugappdomain-getprocess-method.md)|Gets the process containing the application domain.|
|[IsAttached Method](icordebugappdomain-isattached-method.md)|Determines whether the debugger is attached to the application domain.|

## Remarks

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
