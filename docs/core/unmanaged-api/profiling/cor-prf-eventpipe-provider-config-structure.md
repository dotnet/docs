---
description: "Learn more about: COR_PRF_EVENTPIPE_PROVIDER_CONFIG structure"
title: "COR_PRF_EVENTPIPE_PROVIDER_CONFIG structure"
ms.date: "03/19/2021"
api_name:
  - "COR_PRF_EVENTPIPE_PROVIDER_CONFIG"
api_location:
  - "coreclr.dll"
  - "corprof.idl"
api_type:
  - "COM"
---
# COR_PRF_EVENTPIPE_PROVIDER_CONFIG structure

Describes the fields necessary to configure an EventPipe provider.

## Syntax

```cpp
typedef struct
{
    const WCHAR* providerName;
    UINT64       keywords;
    UINT32       loggingLevel;
    const WCHAR* filterData;
} COR_PRF_EVENTPIPE_PROVIDER_CONFIG;
```

## Members

|Member|Description|
|------------|-----------------|
|`providerName`|The name of the provider to enable.|
|`keywords`|The keywords to enable on the provider.|
|`loggingLevel`|The level to enable on the provider.|
|`filterData`|A wide character string containing the filterdata to use when enabling the provider.|

## Remarks

 The `COR_PRF_EVENTPIPE_PROVIDER_CONFIG` structure is used by the [ICorProfilerInfo12::EventPipeAddProviderToSession](icorprofilerinfo12-eventpipeaddprovidertosession-method.md) method to indicate the configuration for the provider being added to the session.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).
**Header:** CorProf.idl, CorProf.h
**.NET Versions:** Available since .NET 5.0

## See also

- [Profiling Enumerations](profiling-enumerations.md)
- [ICorProfilerInfo12::EventPipeAddProviderToSession](icorprofilerinfo12-eventpipeaddprovidertosession-method.md)
