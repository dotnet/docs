---
description: "Learn more about: CorMarkThreadInThreadPool Function"
title: "CorMarkThreadInThreadPool Function"
ms.date: "03/30/2017"
api_name:
  - "CorMarkThreadInThreadPool"
api_location:
  - "mscoree.dll"
api_type:
  - "DLLExport"
f1_keywords:
  - "CorMarkThreadInThreadPool"
helpviewer_keywords:
  - "CorMarkThreadInThreadPool function [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# CorMarkThreadInThreadPool Function

Marks the currently executing thread-pool thread for the execution of managed code. Starting with .NET Framework version 2.0, this function has no effect. It is not required, and can be removed from your code. This function is deprecated in the .NET Framework 4.

## Syntax

```cpp
void CorMarkThreadInThreadPool ();
```

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** MSCorEE.dll

 **.NET versions:** Available since .NET Framework 1.0

## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
