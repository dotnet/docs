---
description: "Learn more about: ICorProfilerInfo13::CreateHandle Method"
title: "ICorProfilerInfo13::CreateHandle Method"
ms.date: "03/19/2021"
api_name:
  - "ICorProfilerInfo13.CreateHandle"
api_location:
  - "coreclr.dll"
  - "corprof.idl"
api_type:
  - "COM"
ms.topic: article
---
# ICorProfilerInfo13::CreateHandle method

Creates a handle that wraps a specified object.

## Syntax

```cpp
    HRESULT CreateHandle(
                [in] ObjectID            object,
                [in] COR_PRF_HANDLE_TYPE type,
                [out] ObjectHandleID*    pHandle);
```

## Parameters

`object`\
[in] The object reference to wrap with a handle.

`type`\
[in] The type of handle to create.

`pHandle`\
[out] A caller-provided pointer that will point to the handle created to wrap the specified `object`.

## Remarks

Following are the expected usages depending on the specified `COR_PRF_HANDLE_TYPE` value:

- `COR_PRF_HANDLE_TYPE_WEAK`: Monitors if an object stays in memory over time. If the wrapped object has been collected, [ICorProfilerInfo13::GetObjectIDFromHandle](icorprofilerinfo13-getobjectidfromhandle-method.md) returns a null `ObjectID`.
- `COR_PRF_HANDLE_TYPE_STRONG`: Enforces that an object survives garbage collections even if no other object references it.
- `COR_PRF_HANDLE_TYPE_PINNED`: Same as a strong handle but also ensures that the object stays at the same address in memory during garbage collections.

To ensure that the `object` reference is valid, this method has to be called from a `ICorProfilerCallback` method such as [ICorProfilerCallback::ObjectAllocated](../../../framework/unmanaged-api/profiling/icorprofilercallback-objectallocated-method.md). You cannot call `CreateHandle` from an EventPipe asynchronous listener. The object received via an event payload might have been disposed or moved in memory if a garbage collection occurred between the time the event was emitted and when it was received.

Do not forget to call [ICorProfilerInfo13::DestroyHandle](icorprofilerinfo13-destroyhandle-method.md) once a created handle is no longer needed.
It is recommended to have less than 4096 handles allocated at the same time to avoid impacting the performance of the garbage collector.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorProf.idl, CorProf.h

**.NET Versions:** Available since .NET 7.0

## See also

- [ICorProfilerInfo13 Interface](icorprofilerinfo13-interface.md)
- [COR_PRF_HANDLE_TYPE Enumeration](cor-prf-handle-type-enumeration.md)
- [DestroyHandle Method](icorprofilerinfo13-destroyhandle-method.md)
