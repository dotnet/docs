---
description: "Learn more about: ICLRDataTarget Interface"
title: "ICLRDataTarget Interface"
ms.date: "03/30/2017"
api_name: 
  - "ICLRDataTarget"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICLRDataTarget"
helpviewer_keywords: 
  - "ICLRDataTarget interface [.NET Framework debugging]"
ms.assetid: e2f05155-9bef-4e11-b703-7f05890665ca
topic_type: 
  - "apiref"
---
# ICLRDataTarget Interface

Provides methods for interaction with a target item of the common language runtime (CLR).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetCurrentThreadID Method](iclrdatatarget-getcurrentthreadid-method.md)|Gets the operating system identifier for the current thread.|  
|[GetImageBase Method](iclrdatatarget-getimagebase-method.md)|Gets the base memory address for the specified image.|  
|[GetMachineType Method](iclrdatatarget-getmachinetype-method.md)|Gets an identifier for the kind of instruction set that the target process is using.|  
|[GetPointerSize Method](iclrdatatarget-getpointersize-method.md)|Gets the size, in bytes, of a pointer to the current target.|  
|[GetThreadContext Method](iclrdatatarget-getthreadcontext-method.md)|Gets a pointer to the context of the thread with the specified identifier.|  
|[GetTLSValue Method](iclrdatatarget-gettlsvalue-method.md)|Gets a value in thread local storage (TLS) at the specified index for the specified thread.|  
|[ReadVirtual Method](iclrdatatarget-readvirtual-method.md)|Reads data from the specified virtual memory address into the specified buffer.|  
|[Request Method](iclrdatatarget-request-method.md)|Called by the common language runtime (CLR) data access services to request an operation, as defined by the implementation.|  
|[SetThreadContext Method](iclrdatatarget-setthreadcontext-method.md)|Sets the current context of the specified thread in the target process.|  
|[SetTLSValue Method](iclrdatatarget-settlsvalue-method.md)|Sets a value in the thread local storage (TLS) of the specified thread in the target process.|  
|[WriteVirtual Method](iclrdatatarget-writevirtual-method.md)|Writes data from the specified buffer to the specified virtual memory address.|  
  
## Remarks  

 The API client (that is, the debugger) must implement this interface as appropriate for the particular target item. For example, a live process would have an implementation different from that of a memory dump.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICLRDataTarget2 Interface](iclrdatatarget2-interface.md)
- [Debugging Interfaces](debugging-interfaces.md)
