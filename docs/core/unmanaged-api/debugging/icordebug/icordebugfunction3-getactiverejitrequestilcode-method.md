---
description: "Learn more about: ICorDebugFunction3::GetActiveReJitRequestILCode Method"
title: "ICorDebugFunction3::GetActiveReJitRequestILCode Method"
ms.date: "03/30/2017"
dev_langs:
  - "cpp"
api_name:
  - "ICorDebugFunction3.GetActiveReJitRequestILCode"
api_location:
  - "mscordbi.dll"
api_type:
  - "COM"
topic_type:
  - "apiref"
---
# ICorDebugFunction3::GetActiveReJitRequestILCode Method

Gets an interface pointer to an [ICorDebugILCode](icordebugilcode-interface.md) that contains the IL from an active ReJIT request.

## Syntax

```cpp
HRESULT GetActiveReJitRequestILCode(
   ICorDebugILCode **ppReJitedILCode
);
```

## Parameters

`ppReJitedILCode`\
A pointer to the IL from an active ReJIT request.

## Remarks

If the method represented by this `ICorDebugFunction3` object has an active ReJIT request, `ppReJitedILCode` returns a pointer to its IL. If there is no active request, which is a common case, then `ppReJitedILCode` is **null**.

A ReJIT request becomes active just after execution returns from the [ICorProfilerCallback4::GetReJITParameters](../../../../framework/unmanaged-api/profiling/icorprofilercallback4-getrejitparameters-method.md) method call. It may not yet be JIT-compiled, and threads may still be executing in the original version of the code. A ReJIT request becomes inactive during the profiler's call to the [ICorProfilerInfo4::RequestRevert](../../../../framework/unmanaged-api/profiling/icorprofilerinfo4-requestrevert-method.md) method. Even after the IL is reverted, a thread can still be executing in the JIT-recompiled (ReJIT) code.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** CorDebug.idl, CorDebug.h

 **Library:** CorGuids.lib

 **.NET versions:** Available since .NET Framework 4.5.2

## See also

- [ICorDebugFunction3 Interface](icordebugfunction3-interface.md)
- [ReJIT: A How-To Guide](/archive/blogs/davbr/rejit-a-how-to-guide)
