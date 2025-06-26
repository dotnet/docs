---
description: "Learn more about: CoUninitializeEE Function"
title: "CoUninitializeEE Function"
ms.date: "03/30/2017"
api_name:
  - "CoUninitializeEE"
api_location:
  - "mscoree.dll"
  - "mscorsvr.dll"
api_type:
  - "DLLExport"
f1_keywords:
  - "CoUninitializeEE"
helpviewer_keywords:
  - "CoUninitializeEE function [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# CoUninitializeEE Function

`CoUninitializeEE` is obsolete and provides no functionality.

## Syntax

```cpp
void CoUninitializeEE (
    BOOL fFlags
);
```

## Remarks

 The common language runtime execution engine cannot be unloaded from a process. To shut down the execution engine call [CorExitProcess](corexitprocess-function.md).

## See also

- [CoInitializeEE Function](coinitializeee-function.md)
- [Metadata Global Static Functions](../metadata/metadata-global-static-functions.md)
