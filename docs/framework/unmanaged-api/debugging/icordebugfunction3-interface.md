---
description: "Learn more about: ICorDebugFunction3 Interface"
title: "ICorDebugFunction3 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugFunction3"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
ms.assetid: b22717b9-ead5-4eea-887e-789b52d613dc
topic_type:
  - "apiref"
---
# ICorDebugFunction3 Interface

[Supported in the .NET Framework 4.5.2 and later versions]

 Logically extends the ICorDebugFunction interface to provide access to code from a ReJIT request.

## Methods

|Method|Description|
|------------|-----------------|
|[GetActiveReJitRequestILCode Method](icordebugfunction3-getactiverejitrequestilcode-method.md)|Gets an interface pointer to an [ICorDebugILCode](icordebugilcode-interface.md) that contains the IL from an active ReJIT request.|

## Remarks

## Requirements

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET Framework Versions:** [!INCLUDE[net_current_v452plus](../../../../includes/net-current-v452plus-md.md)]

## See also

- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
- [ReJIT: A How-To Guide](/archive/blogs/davbr/rejit-a-how-to-guide)
