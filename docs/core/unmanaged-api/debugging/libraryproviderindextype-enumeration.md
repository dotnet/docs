---
description: "Learn more about: LIBRARY_PROVIDER_INDEX_TYPE Enumeration"
title: "LIBRARY_PROVIDER_INDEX_TYPE Enumeration"
ms.date: "03/30/2017"
api_name:
  - "LIBRARY_PROVIDER_INDEX_TYPE"
api_location:
  - "dbgshim.dll"
  - "libdbgshim.so"
  - "libdbgshim.dylib"
api_type:
  - "COM"
f1_keywords:
  - "LIBRARY_PROVIDER_INDEX_TYPE"
helpviewer_keywords:
  - "LIBRARY_PROVIDER_INDEX_TYPE enumeration [.NET Core debugging]"
topic_type:
  - "apiref"
---
# LIBRARY_PROVIDER_INDEX_TYPE enumeration

The type of index information passed to the library provider is either the identity of the requested module or of the runtime (CoreCLR) module.

## Syntax

```cpp
typedef enum
{
    Unknown = 0,
    Identity = 1,
    Runtime = 2,
}  LIBRARY_PROVIDER_INDEX_TYPE;
```

## Members

|Member|Description|
|------------|-----------------|
|`Unknown`|Invalid index type.|
|`Identity`|The index information of the requested module.|
|`Runtime`|The runtime module's index information.|

## Remarks

The "index information" is the timestamp or file size on Windows, or the build ID on Linux and macOS.

## Requirements

 **Platforms:** See [.NET supported operating systems](https://github.com/dotnet/core/blob/main/os-lifecycle-policy.md).

 **Header:** dbgshim.h

 **Library:** dbgshim.dll, libdbgshim.so, libdbgshim.dylib

 **.NET Versions:** Available since .NET 6.0
