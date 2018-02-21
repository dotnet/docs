---
title: "ICLRDataTarget Interface"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
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
caps.latest.revision: 14
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDataTarget Interface
Provides methods for interaction with a target item of the common language runtime (CLR).  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetCurrentThreadID Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-getcurrentthreadid-method.md)|Gets the operating system identifier for the current thread.|  
|[GetImageBase Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-getimagebase-method.md)|Gets the base memory address for the specified image.|  
|[GetMachineType Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-getmachinetype-method.md)|Gets an identifier for the kind of instruction set that the target process is using.|  
|[GetPointerSize Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-getpointersize-method.md)|Gets the size, in bytes, of a pointer to the current target.|  
|[GetThreadContext Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-getthreadcontext-method.md)|Gets a pointer to the context of the thread with the specified identifier.|  
|[GetTLSValue Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-gettlsvalue-method.md)|Gets a value in thread local storage (TLS) at the specified index for the specified thread.|  
|[ReadVirtual Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-readvirtual-method.md)|Reads data from the specified virtual memory address into the specified buffer.|  
|[Request Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-request-method.md)|Called by the common language runtime (CLR) data access services to request an operation, as defined by the implementation.|  
|[SetThreadContext Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-setthreadcontext-method.md)|Sets the current context of the specified thread in the target process.|  
|[SetTLSValue Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-settlsvalue-method.md)|Sets a value in the thread local storage (TLS) of the specified thread in the target process.|  
|[WriteVirtual Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-writevirtual-method.md)|Writes data from the specified buffer to the specified virtual memory address.|  
  
## Remarks  
 The API client (that is, the debugger) must implement this interface as appropriate for the particular target item. For example, a live process would have an implementation different from that of a memory dump.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICLRDataTarget2 Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget2-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
