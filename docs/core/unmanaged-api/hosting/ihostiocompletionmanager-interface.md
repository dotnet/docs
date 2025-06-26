---
description: "Learn more about: IHostIoCompletionManager Interface"
title: "IHostIoCompletionManager Interface"
ms.date: "03/30/2017"
api_name:
  - "IHostIoCompletionManager"
api_location:
  - "mscoree.dll"
api_type:
  - "COM"
f1_keywords:
  - "IHostIoCompletionManager"
helpviewer_keywords:
  - "IHostIoCompletionManager interface [.NET Framework hosting]"
topic_type:
  - "apiref"
---
# IHostIoCompletionManager Interface

Provides methods that allow the common language runtime (CLR) to interact with I/O completion ports provided by the host.

## Methods

|Method|Description|
|------------|-----------------|
|[Bind Method](ihostiocompletionmanager-bind-method.md)|Binds a handle to an I/O completion port.|
|[CloseIoCompletionPort Method](ihostiocompletionmanager-closeiocompletionport-method.md)|Closes a port that was created through an earlier call to `CreateIoCompletionPort`.|
|[CreateIoCompletionPort Method](ihostiocompletionmanager-createiocompletionport-method.md)|Requests that the host create a new I/O completion port.|
|[GetAvailableThreads Method](ihostiocompletionmanager-getavailablethreads-method.md)|Gets the number of I/O completion threads that are not currently processing requests.|
|[GetHostOverlappedSize Method](ihostiocompletionmanager-gethostoverlappedsize-method.md)|Gets the size of any custom data the host intends to append to I/O requests.|
|[GetMaxThreads Method](ihostiocompletionmanager-getmaxthreads-method.md)|Gets the maximum number of threads that the host can allot to service I/O requests.|
|[GetMinThreads Method](ihostiocompletionmanager-getminthreads-method.md)|Gets the minimum number of threads that the host provides to service I/O requests.|
|[InitializeHostOverlapped Method](ihostiocompletionmanager-initializehostoverlapped-method.md)|Provides the host with an opportunity to initialize any custom data about an I/O request.|
|[SetCLRIoCompletionManager Method](ihostiocompletionmanager-setclriocompletionmanager-method.md)|Provides the host with an interface pointer to an [ICLRIoCompletionManager](iclriocompletionmanager-interface.md) instance implemented by the CLR.|
|[SetMaxThreads Method](ihostiocompletionmanager-setmaxthreads-method.md)|Sets the maximum number of threads that the host allots to service I/O requests.|
|[SetMinThreads Method](ihostiocompletionmanager-setminthreads-method.md)|Sets the minimum number of threads that the host should allot to I/O completion.|

## Remarks

 `IHostIoCompletionManager` corresponds to the `ICLRIoCompletionManager` interface implemented by the CLR. The CLR calls the methods of `IHostIoCompletionManager` to bind handles to the ports that the host provides, and the host calls the methods of `ICLRIoCompletionManager` to report the completion of I/O requests.

## Requirements

 **Platforms:** See [System Requirements](../../../framework/get-started/system-requirements.md).

 **Header:** MSCorEE.h

 **Library:** Included as a resource in MSCorEE.dll

 **.NET versions:** Available since .NET Framework 2.0

## See also

- [Hosting Interfaces](hosting-interfaces.md)
