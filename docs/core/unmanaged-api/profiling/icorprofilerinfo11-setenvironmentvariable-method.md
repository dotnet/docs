---
description: "Learn more about: ICorProfilerInfo11::SetEnvironmentVariable Method"
title: "ICorProfilerInfo11::SetEnvironmentVariable Method"
ms.date: "03/19/2021"
api_name:
  - "ICorProfilerInfo11.SetEnvironmentVariable"
api_location:
  - "coreclr.dll"
  - "corprof.idl"
api_type:
  - "COM"
ms.topic: article
---
# ICorProfilerInfo11::SetEnvironmentVariable method

Sets an environment variable in the process. On non-Windows platforms the runtime keeps an internal cache of environment variables to ensure thread safety. This means that if the profiler calls `setenv` the new environment variable will not be picked up by managed code running in the process.

## Syntax

```cpp
    HRESULT SetEnvironmentVariable(
                [in, string] const WCHAR *szName,
                [in, string] const WCHAR *szValue);
```

## Parameters

`szName`\
[in] A pointer to a null terminated wide character string containing the name of the environment variable to set.

`szValue`\
[in] A pointer to a null terminated wide character string containing the value of the environment variable to set.

## Requirements

**Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

**Header:** CorProf.idl, CorProf.h

**.NET Versions:** Available since .NET Core 3.1
