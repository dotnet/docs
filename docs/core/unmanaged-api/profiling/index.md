---
description: "Learn more about unmanaged APIs for profiling .NET apps"
title: .NET profiling (unmanaged API reference)
ms.date: 09/19/2023
ms.topic: article
---
# .NET profiling (unmanaged API reference)

The profiling API enables a profiler to monitor a program's execution by the common language runtime (CLR).

These articles describe APIs that were introduced in .NET Core 2.0 and later versions. For .NET Framework-era unmanaged APIs, most of which can also be used to profile .NET (Core) apps, see [.NET Framework profiling](../../../framework/unmanaged-api/profiling/index.md).

## Structures

- [COR_PRF_EVENT_DATA structure](cor-prf-event-data-structure.md)
- [COR_PRF_EVENTPIPE_PARAM_DESC structure](cor-prf-eventpipe-param-desc-structure.md)
- [COR_PRF_EVENTPIPE_PROVIDER_CONFIG structure](cor-prf-eventpipe-provider-config-structure.md)

## Enumerations

- [COR_PRF_EVENTPIPE_LEVEL enumeration](cor-prf-eventpipe-level-enumeration.md)
- [COR_PRF_EVENTPIPE_PARAM_TYPE enumeration](cor-prf-eventpipe-param-type-enumeration.md)
- [COR_PRF_HANDLE_TYPE enumeration](cor-prf-handle-type-enumeration.md)
- [COR_PRF_REJIT_FLAGS enumeration](cor-prf-rejit-flags-enumeration.md)

## Interfaces

- [ICorProfilerCallback10 interface](icorprofilercallback10-interface.md)
- [ICorProfilerInfo9 interface](icorprofilerinfo9-interface.md)
- [ICorProfilerInfo10 interface](icorprofilerinfo10-interface.md)
- [ICorProfilerInfo11 interface](icorprofilerinfo11-interface.md)
- [ICorProfilerInfo12 interface](icorprofilerinfo12-interface.md)
- [ICorProfilerInfo13 interface](icorprofilerinfo13-interface.md)
