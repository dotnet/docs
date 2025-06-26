---
description: "Learn more about: IGCHost::Collect Method"
title: "IGCHost::Collect Method"
ms.date: "03/30/2017"
api_name:
  - "IGCHost.Collect"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "Collect"
helpviewer_keywords:
  - "Collect method, IGCHost interface [.NET Framework hosting]"
  - "IGCHost::Collect method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IGCHost::Collect Method

Forces a collection to occur for the given generation, regardless of the state of the current garbage collection.

## Syntax

```cpp
HRESULT Collect (
    [in] LONG Generation
);
```

## Parameters

 `Generation`
 [in] The generation on which to perform the garbage collection. A value of -1 indicates that all generations will undergo a garbage collection.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** GCHost.idl, GCHost.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IGCHost Interface](igchost-interface.md)
