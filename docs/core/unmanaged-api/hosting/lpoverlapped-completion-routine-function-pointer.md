---
description: "Learn more about: LPOVERLAPPED_COMPLETION_ROUTINE Function Pointer"
title: "LPOVERLAPPED_COMPLETION_ROUTINE Function Pointer"
ms.date: "03/30/2017"
api_name: 
  - "LPOVERLAPPED_COMPLETION_ROUTINE"
api_location: 
  - "mscoree.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "LPOVERLAPPED_COMPLETION_ROUTINE"
helpviewer_keywords: 
  - "LPOVERLAPPED_COMPLETION_ROUTINE function pointer [.NET Framework hosting]"
ms.assetid: 5fb645d9-b818-401c-8c2c-c30d86de58ba
topic_type: 
  - "apiref"
---
# LPOVERLAPPED_COMPLETION_ROUTINE Function Pointer

Points to a function that notifies the host when an overlapped (that is, asynchronous) I/O to a device has completed.  
  
 This function pointer has been deprecated in the .NET Framework 4.  
  
## Syntax  
  
```cpp  
typedef VOID (*LPOVERLAPPED_COMPLETION_ROUTINE) (  
    [in] DWORD  dwErrorCode,  
    [in] DWORD  dwNumberOfBytesTransfered,  
    [in] LPVOID lpOverlapped  
);  
```  
  
## Parameters  

 `dwErrorCode`  
 [in] A value that is an error code if the device has been closed; otherwise, this value is zero.  
  
 Closing a device causes all pending I/O to the device to be completed immediately.  
  
 `dwNumberOfBytesTransfered`  
 [in] The number of bytes transferred by the I/O operation.  
  
 `lpOverlapped`  
 [in] A pointer to a structure that contains information to be used to complete the I/O request.  
  
## Remarks  

 The function to which `LPOVERLAPPED_COMPLETION_ROUTINE` points is a callback function and must be implemented by the writer of the hosting application. The callback function allows the host to process the completed I/O request.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** MSCorEE.h  
  
 **Library:** MSCorWks.dll  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [Deprecated CLR Hosting Functions](deprecated-clr-hosting-functions.md)
