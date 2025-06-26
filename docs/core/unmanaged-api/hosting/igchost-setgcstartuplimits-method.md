---
description: "Learn more about: IGCHost::SetGCStartupLimits Method"
title: "IGCHost::SetGCStartupLimits Method"
ms.date: "03/30/2017"
api_name:
  - "IGCHost.SetGCStartupLimits"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "SetGCStartupLimits"
helpviewer_keywords:
  - "SetGCStartupLimits method, IGCHost interface [.NET Framework hosting]"
  - "IGCHost::SetGCStartupLimits method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IGCHost::SetGCStartupLimits Method

Sets the segment size and the maximum size for generation 0.

> [!IMPORTANT]
> Starting with .NET Framework 4.5, you can set segment size and maximum generation 0 size to values greater than `DWORD` by using the [IGCHost2::SetGCStartupLimitsEx](igchost2-setgcstartuplimitsex-method.md) method.

## Syntax

```cpp
HRESULT SetGCStartupLimits (
    [in] DWORD SegmentSize,
    [in] DWORD MaxGen0Size
);
```

## Parameters

 `SegmentSize`
 [in] The size of the segment used by the garbage collection system.

 `MaxGen0Size`
 [in] The maximum size for generation 0.

## Remarks

 The `SetGCStartupLimits` method may be called only once. These values cannot be changed later.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** GCHost.idl, GCHost.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IGCHost Interface](igchost-interface.md)
