---
title: "ICLRDataTarget3 Interface"
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
  - "ICLRDataTarget3"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
ms.assetid: d2711bdf-64b3-404c-a0c3-01ba4907f703
topic_type: 
  - "apiref"
caps.latest.revision: 6
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICLRDataTarget3 Interface
A subclass of [ICLRDataTarget2](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget2-interface.md) that provides access to exception information.  
  
## Methods  
  
|Method|Description|  
|------------|-----------------|  
|[GetExceptionRecord Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget3-getexceptionrecord-method.md)|Called by the common language runtime (CLR) data access services to retrieve the exception record associated with the target process.|  
|[GetExceptionContextRecord Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget3-getexceptioncontextrecord-method.md)|Called by the CLR data access services to retrieve the context record associated with the target process.|  
|[GetExceptionThreadID Method](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget3-getexceptionthreadid-method.md)|Called by the CLR data access services to get the ID of the thread that threw the exception.|  
  
## Remarks  
 The API client (that is, the debugger) must implement this interface as appropriate for the particular target process. For example, a live process would have an implementation different from that of a memory dump. The target may not support modification of its memory regions.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** ClrData.idl, ClrData.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[v451_update](../../../../includes/v451-update-md.md)]  
  
## See Also  
 [ICLRDataTarget Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget-interface.md)  
 [ICLRDataTarget2 Interface](../../../../docs/framework/unmanaged-api/debugging/iclrdatatarget2-interface.md)  
 [Debugging Interfaces](../../../../docs/framework/unmanaged-api/debugging/debugging-interfaces.md)
