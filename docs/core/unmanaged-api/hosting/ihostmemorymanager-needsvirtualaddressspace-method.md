---
description: "Learn more about: IHostMemoryManager::NeedsVirtualAddressSpace Method"
title: "IHostMemoryManager::NeedsVirtualAddressSpace Method"
ms.date: "03/30/2017"
api_name:
  - "IHostMemoryManager.NeedsVirtualAddressSpace"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostMemoryManager::NeedsVirtualAddressSpace"
helpviewer_keywords:
  - "IHostMemoryManager::NeedsVirtualAddressSpace method [.NET Framework hosting]"
  - "NeedsVirtualAddressSpace method [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostMemoryManager::NeedsVirtualAddressSpace Method

Notifies the host that the common language runtime (CLR) is going to attempt to use the specified memory.

## Syntax

```cpp
HRESULT NeedsVirtualAddressSpace (
    [in] LPVOID  startAddress,
    [in] SIZE_T  size
);
```

## Parameters

 `startAddress`
 [in] The starting address of the memory.

 `size`
 [in] The size, in bytes, of the memory.

## Remarks

 The `NeedsVirtualAddressSpace` method is a callback method and must be implemented by the writer of the hosting application. It is called by the CLR.

 If the host does not want the CLR to use the specified memory, it may return an E_OUTOFMEMORY HRESULT.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IHostMemoryManager Interface](ihostmemorymanager-interface.md)
