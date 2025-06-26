---
description: "Learn more about: IHostMemoryManager::CreateMAlloc Method"
title: "IHostMemoryManager::CreateMAlloc Method"
ms.date: "03/30/2017"
api_name:
  - "IHostMemoryManager.CreateMAlloc"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostMemoryManager::CreateMAlloc"
helpviewer_keywords:
  - "CreateAlloc method [.NET Framework hosting]"
  - "IHostMemoryManager::CreateMAlloc method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostMemoryManager::CreateMAlloc Method

Gets an interface pointer to an [IHostMAlloc](ihostmalloc-interface.md) instance that is used to make allocation requests from a heap created by the host.

## Syntax

```cpp
HRESULT CreateMalloc (
    [in]  DWORD         dwMallocType,
    [out] IHostMalloc **ppMalloc
);
```

## Parameters

 `dwMallocType`
 [in] A combination of [MALLOC_TYPE](malloc-type-enumeration.md) flags that specifies the characteristics of the memory that is being allocated.

 `ppMAlloc`
 [out] A pointer to the address of an `IHostMAlloc` instance provided by the host.

## Return Value

|HRESULT|Description|
|-------------|-----------------|
|S_OK|`CreateMAlloc` returned successfully.|
|HOST_E_CLRNOTAVAILABLE|The common language runtime (CLR) has not been loaded into a process, or the CLR is in a state in which it cannot run managed code or process the call successfully.|
|HOST_E_TIMEOUT|The call timed out.|
|HOST_E_NOT_OWNER|The caller does not own the lock.|
|HOST_E_ABANDONED|An event was canceled while a blocked thread or fiber was waiting on it.|
|E_FAIL|An unknown catastrophic failure occurred. When a method returns E_FAIL, the CLR is no longer usable within the process. Subsequent calls to hosting methods return HOST_E_CLRNOTAVAILABLE.|
|E_OUTOFMEMORY|Not enough physical memory was available to complete the allocation request.|

## Remarks

 `CreateMAlloc` returns an object that allows the CLR to make allocation requests through the host instead of using the standard Win32 functions.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IHostMalloc Interface](ihostmalloc-interface.md)
- [IHostMemoryManager Interface](ihostmemorymanager-interface.md)
