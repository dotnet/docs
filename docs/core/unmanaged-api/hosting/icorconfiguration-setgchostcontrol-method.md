---
description: "Learn more about: ICorConfiguration::SetGCHostControl Method"
title: "ICorConfiguration::SetGCHostControl Method"
ms.date: "03/30/2017"
api_name:
  - "ICorConfiguration.SetGCHostControl"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "SetGCHostControl"
helpviewer_keywords:
  - "ICorConfiguration::SetGCHostControl method [.NET Framework hosting]"
  - "SetGCHostControl method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICorConfiguration::SetGCHostControl Method

Sets the callback interface to be used by the garbage collector to request the host to change the limits of virtual memory.

## Syntax

```cpp
HRESULT SetGCHostControl (
    [in] IGCHostControl* pGCHostControl
);
```

## Parameters

 `pGCHostControl`
 [in] A pointer to an [IGCHostControl](igchostcontrol-interface.md) object that allows the garbage collector to request the host to change the limits of virtual memory.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICorConfiguration Interface](icorconfiguration-interface.md)
