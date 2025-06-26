---
description: "Learn more about: IGCThreadControl::SuspensionStarting Method"
title: "IGCThreadControl::SuspensionStarting Method"
ms.date: "03/30/2017"
api_name:
  - "IGCThreadControl.SuspensionStarting"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "SuspensionStarting"
helpviewer_keywords:
  - "IGCThreadControl::SuspensionStarting method [.NET Framework hosting]"
  - "SuspensionStarting method, IGCThreadControl interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IGCThreadControl::SuspensionStarting Method

Notifies the host that the runtime is beginning a thread suspension for a garbage collection or other suspension.

## Syntax

```cpp
HRESULT SuspensionStarting ( );
```

## Remarks

 Do not reschedule any threads during the `SuspensionStarting` callback.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IGCThreadControl Interface](igcthreadcontrol-interface.md)
