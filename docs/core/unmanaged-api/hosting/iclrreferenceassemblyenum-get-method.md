---
description: "Learn more about: ICLRReferenceAssemblyEnum::Get Method"
title: "ICLRReferenceAssemblyEnum::Get Method"
ms.date: "03/30/2017"
api_name:
  - "ICLRReferenceAssemblyEnum.Get"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "ICLRReferenceAssemblyEnum::Get"
helpviewer_keywords:
  - "ICLRReferenceAssemblyEnum::Get method [.NET Framework hosting]"
  - "Get method, ICLRReferenceAssemblyEnum interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# ICLRReferenceAssemblyEnum::Get Method

Gets the assembly identity at the supplied index.

## Syntax

```cpp
HRESULT Get (
    [in] DWORD dwIndex,
    [out, size_is(*pcchBufferSize)] LPWSTR pwzBuffer,
    [in, out] DWORD *pcchBufferSize
);
```

## Parameters

 `dwIndex`
 [in] The zero-based index of the assembly identity to return.

 `pwzBuffer`
 [out] A buffer containing the assembly identity data.

 `pcchBufferSize`
 [in, out] The size of the `pwzBuffer` buffer.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`Get` returned successfully.|
|ERROR_INSUFFICIENT_BUFFER|`pwzBuffer` is too small.|
|ERROR_NO_MORE_ITEMS|The enumeration contains no more items.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. If a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|

## Remarks

 `Get` is typically called twice. The first call supplies a null value for `pwzBuffer`, and sets `pcchBufferSize` to the size appropriate for `pwzBuffer`. The second call supplies an appropriately sized `pwzBuffer`, and contains the canonical assembly identity data upon completion.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [ICLRAssemblyReferenceList Interface](iclrassemblyreferencelist-interface.md)
- [ICLRReferenceAssemblyEnum Interface](iclrreferenceassemblyenum-interface.md)
