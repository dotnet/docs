---
description: "Learn more about: ICorDebugILCode2 Interface"
title: "ICorDebugILCode2 Interface"
ms.date: "03/30/2017"
api_name:
  - "ICorDebugILCode2"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
topic_type:
  - "apiref"
---
# ICorDebugILCode2 Interface

[Supported in the .NET Framework 4.5.2 and later versions]

 Logically extends the [ICorDebugILCode](icordebugilcode-interface.md) interface to provide methods that return the token for a function's local variable signature, and that map a profiler's instrumented intermediate language (IL) offsets to original method IL offsets.

## Methods

|Method|Description|
|------------|-----------------|
|[GetInstrumentedILMap Method](icordebugilcode2-getinstrumentedilmap-method.md)|Returns a map from profiler instrumented IL offsets to original method IL offsets for this instance.|
|[GetLocalVarSigToken Method](icordebugilcode2-getlocalvarsigtoken-method.md)|Gets the metadata token for the local variable signature for the function that is represented by this instance.|

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5.2

## See also

- [ICorDebugILCode Interface](icordebugilcode-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
- [Debugging](index.md)
