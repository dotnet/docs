---
description: "Learn more about: IHostMemoryManager::ReleasedVirtualAddressSpace Method"
title: "IHostMemoryManager::ReleasedVirtualAddressSpace Method"
ms.date: "03/30/2017"
api_name:
  - "IHostMemoryManager.ReleasedVirtualAddressSpace"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostMemoryManager::ReleasedVirtualAddressSpace"
helpviewer_keywords:
  - "ReleasedVirtualAddressSpace method [.NET Framework hosting]"
  - "IHostMemoryManager::ReleasedVirtualAddressSpace method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostMemoryManager::ReleasedVirtualAddressSpace Method

Notifies the host that the common language runtime (CLR) has finished using the specified memory.

## Syntax

```cpp
HRESULT ReleasedVirtualAddressSpace(
    [in] LPVOID startAddress
);
```

## Parameters

 `startAddress`
 [in] Pointer to the starting address of the memory to be released.

## Remarks

 The `ReleasedVirtualAddressSpace` method is a callback method and must be implemented by the writer of the hosting application. It is called by the CLR.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IHostMemoryManager Interface](ihostmemorymanager-interface.md)
