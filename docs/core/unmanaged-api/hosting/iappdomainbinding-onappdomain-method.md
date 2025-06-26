---
description: "Learn more about: IAppDomainBinding::OnAppDomain Method"
title: "IAppDomainBinding::OnAppDomain Method"
ms.date: "03/30/2017"
api_name:
  - "IAppDomainBinding.OnAppDomain"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "OnAppDomain"
helpviewer_keywords:
  - "IAppDomainBinding::OnAppDomain method [.NET Framework hosting]"
  - "OnAppDomain method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IAppDomainBinding::OnAppDomain Method

Called by the common language runtime (CLR) to notify the host that an application domain has been created.

## Syntax

```cpp
HRESULT OnAppDomain (
    [in] IUnknown* pAppdomain
);
```

## Parameters

 `pAppdomain`
 [in] A pointer to an [IUnknown](/cpp/atl/iunknown) interface object that represents the new application domain.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IAppDomainBinding Interface](iappdomainbinding-interface.md)
