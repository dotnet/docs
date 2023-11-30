---
description: "Learn more about: ICorProfilerInfo13 Interface"
title: "ICorProfilerInfo13 Interface"
ms.date: "03/19/2021"
api_name:
  - "ICorProfilerInfo13"
api_location:
  - "coreclr.dll"
  - "corprof.idl"
api_type:
  - "COM"
---
# ICorProfilerInfo13 interface

 A subclass of [ICorProfilerInfo12](icorprofilerinfo12-interface.md) that provides methods to manage weak, strong, and pinned handles that wrap objects.

## Methods

|Method|Description|
|------------|-----------------|
|[CreateHandle Method](icorprofilerinfo13-createhandle-method.md)|Creates a weak, strong, or pinned handle wrapping an object.|
|[DestroyHandle Method](icorprofilerinfo13-destroyhandle-method.md)|Destroys a handle.|
|[GetObjectIDFromHandle Method](icorprofilerinfo13-getobjectidfromhandle-method.md)|Gets the object wrapped by a handle.|

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorProf.idl, CorProf.h

**.NET Versions:** Available since .NET 7.0
