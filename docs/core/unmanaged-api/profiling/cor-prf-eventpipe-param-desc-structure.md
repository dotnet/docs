---
description: "Learn more about: COR_PRF_EVENTPIPE_PARAM_DESC structure"
title: "COR_PRF_EVENTPIPE_PARAM_DESC structure"
ms.date: "03/19/2021"
api_name:
  - "COR_PRF_EVENTPIPE_PARAM_DESC"
api_location:
  - "coreclr.dll"
  - "corprof.idl"
api_type:
  - "COM"
ms.topic: reference
---
# COR_PRF_EVENTPIPE_PARAM_DESC structure

Describes the parameter name and type for an EventPipe event.

## Syntax

```cpp
typedef struct
{
    UINT32       type;
    UINT32       elementType;
    const WCHAR *name;
} COR_PRF_EVENTPIPE_PARAM_DESC;
```

## Members

|Member|Description|
|------------|-----------------|
|`type`|The type of the parameter.|
|`elementType`|The element type if this parameter is an array type.|
|`name`|A wide character string containing the name of the parameter.|

## Remarks

 The `COR_PRF_EVENTPIPE_PARAM_DESC` structure is used by the [ICorProfilerInfo12::EventPipeDefineEvent](icorprofilerinfo12-eventpipedefineevent-method.md) method to define the parameter types of the event being defined.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorProf.idl, CorProf.h

**.NET Versions:** Available since .NET 5.0

## See also

- [ICorProfilerInfo12::EventPipeDefineEvent](icorprofilerinfo12-eventpipedefineevent-method.md)
