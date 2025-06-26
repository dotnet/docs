---
description: "Learn more about: ICorConfiguration::SetGCThreadControl Method"
title: "ICorConfiguration::SetGCThreadControl Method"
ms.date: "03/30/2017"
api_name:
  - "ICorConfiguration.SetGCThreadControl"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "SetGCThreadControl"
helpviewer_keywords:
  - "ICorConfiguration::SetGCThreadControl method [.NET Framework hosting]"
  - "SetGCThreadControl method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICorConfiguration::SetGCThreadControl Method

Sets the callback interface for scheduling threads for non-runtime tasks that would otherwise be blocked for a garbage collection.

## Syntax

```cpp
HRESULT SetGCThreadControl (
    [in] IGCThreadControl* pGCThreadControl
);
```

## Parameters

 `pGCThreadControl`
 [in] A pointer to an [IGCThreadControl](igcthreadcontrol-interface.md) object that notifies the host about the suspension of threads for non-runtime tasks.

## Remarks

 The host may choose within the [IGCThreadControl::ThreadIsBlockingForSuspension](igcthreadcontrol-threadisblockingforsuspension-method.md) callback whether to reschedule a thread.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorConfiguration Interface](icorconfiguration-interface.md)
