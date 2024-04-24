---
description: "Learn more about: ICorDebugCode Interface"
title: "ICorDebugCode Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugCode"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICorDebugCode"
helpviewer_keywords:
  - "ICorDebugCode interface [.NET Framework debugging]"
ms.assetid: 7bd14fb6-8b54-4484-a891-e3c21859c019
topic_type:
  - "apiref"
---
# ICorDebugCode Interface

Represents a segment of either common intermediate language (CIL) code or native code.

## Methods

|Method|Description|
|------------|-----------------|
|[CreateBreakpoint Method](icordebugcode-createbreakpoint-method.md)|Creates a breakpoint at the specified offset.|
|[GetAddress Method](icordebugcode-getaddress-method.md)|Gets the relative virtual address (RVA) of the code segment that this `ICorDebugCode` represents.|
|[GetCode Method](icordebugcode-getcode-method.md)|Gets all the code for the specified function, formatted for disassembly. This method has been deprecated; use [ICorDebugCode2::GetCodeChunks](icordebugcode2-getcodechunks-method.md) instead.|
|[GetEnCRemapSequencePoints Method](icordebugcode-getencremapsequencepoints-method.md)|Not implemented.|
|[GetFunction Method](icordebugcode-getfunction-method.md)|Gets the "ICorDebugFunction" associated with this `ICorDebugCode`.|
|[GetILToNativeMapping Method](icordebugcode-getiltonativemapping-method.md)|Gets an array of "COR_DEBUG_IL_TO_NATIVE_MAP" instances that represent mappings from CIL offsets to native offsets.|
|[GetSize Method](icordebugcode-getsize-method.md)|Gets the size, in bytes, of the binary code represented by this `ICorDebugCode`.|
|[GetVersionNumber Method](icordebugcode-getversionnumber-method.md)|Gets the one-based number that identifies the version of the code that this `ICorDebugCode` represents.|
|[IsIL Method](icordebugcode-isil-method.md)|Gets a value that indicates whether this `ICorDebugCode` is compiled in CIL.|

## Remarks

 `ICorDebugCode` can represent either CIL or native code. An "ICorDebugFunction" object that represents CIL code can have either zero or one `ICorDebugCode` objects associated with it. An "ICorDebugFunction" object that represents native code can have any number of `ICorDebugCode` objects associated with it.

> [!NOTE]
> This interface does not support being called remotely, either cross-machine or cross-process.

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]

## See also

- [ICorDebugCode3 Interface](icordebugcode3-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
