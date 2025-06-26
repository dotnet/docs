---
description: "Learn more about: IHostMemoryManager Interface"
title: "IHostMemoryManager Interface"
ms.date: "03/30/2017"
api_name:
  - "IHostMemoryManager"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostMemoryManager"
helpviewer_keywords:
  - "IHostMemoryManager interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostMemoryManager Interface

Provides methods that allow the common language runtime (CLR) to make virtual memory requests through the host, instead of using the standard Win32 virtual memory functions.

## Methods

|Method|Description|
|------------|-----------------|
|[AcquiredVirtualAddressSpace Method](ihostmemorymanager-acquiredvirtualaddressspace-method.md)|Notifies the host that the common language runtime (CLR) has acquired the specified memory from the operating system.|
|[CreateMAlloc Method](ihostmemorymanager-createmalloc-method.md)|Gets an interface pointer to an [IHostMAlloc](ihostmalloc-interface.md) instance that is used to request memory allocations from a heap created by the host.|
|[GetMemoryLoad Method](ihostmemorymanager-getmemoryload-method.md)|Gets the amount of physical memory that is currently being used, as reported by the host.|
|[NeedsVirtualAddressSpace Method](ihostmemorymanager-needsvirtualaddressspace-method.md)|Notifies the host that the CLR is going to attempt to use the specified memory.|
|[RegisterMemoryNotificationCallback Method](ihostmemorymanager-registermemorynotificationcallback-method.md)|Registers a pointer to a callback function that the host invokes to notify the CLR of the current memory load on the computer.|
|[ReleasedVirtualAddressSpace Method](ihostmemorymanager-releasedvirtualaddressspace-method.md)|Notifies the host that the CLR has finished using the specified memory.|
|[VirtualAlloc Method](ihostmemorymanager-virtualalloc-method.md)|Serves as a logical wrapper for the corresponding Win32 function, which reserves or commits a region of pages in the virtual address space of the calling process.|
|[VirtualFree Method](ihostmemorymanager-virtualfree-method.md)|Serves as a logical wrapper for the corresponding Win32 function, which releases, decommits, or releases and decommits a region of pages within the virtual address space of the calling process.|
|[VirtualProtect Method](ihostmemorymanager-virtualprotect-method.md)|Serves as a logical wrapper for the corresponding Win32 function, which changes the protection on a region of committed pages in the virtual address space of the calling process.|
|[VirtualQuery Method](ihostmemorymanager-virtualquery-method.md)|Serves as a logical wrapper for the corresponding Win32 function, which retrieves information about a range of pages in the virtual address space of the calling process.|

## Remarks

 `IHostMemoryManager` also provides methods for the CLR to obtain a pointer through which to make memory requests on the heap and to get the level of memory pressure in the process, as reported by the host.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [IHostMalloc Interface](ihostmalloc-interface.md)
- [Hosting Interfaces](hosting-interfaces.md)
