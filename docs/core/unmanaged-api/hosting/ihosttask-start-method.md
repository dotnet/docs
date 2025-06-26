---
description: "Learn more about: IHostTask::Start Method"
title: "IHostTask::Start Method"
ms.date: "03/30/2017"
api_name:
  - "IHostTask.Start"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostTask::Start"
helpviewer_keywords:
  - "IHostTask::Start method [.NET Framework hosting]"
  - "Start method, IHostTask interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostTask::Start Method

Requests that the host move the task represented by the current [IHostTask](ihosttask-interface.md) instance from a suspended to a live state, in which code can be executed.

## Syntax

```cpp
HRESULT Start ();
```

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|Start returned successfully.|
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the common language runtime (CLR) is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Remarks

 `Start` always returns an HRESULT value of S_OK, except in cases where a catastrophic failure has occurred.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRTask Interface](iclrtask-interface.md)
- [ICLRTaskManager Interface](iclrtaskmanager-interface.md)
- [IHostTask Interface](ihosttask-interface.md)
- [IHostTaskManager Interface](ihosttaskmanager-interface.md)
