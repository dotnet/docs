---
title: "ICorDebugProcess::ReadMemory Method"
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
  - "ICorDebugProcess.ReadMemory"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess::ReadMemory"
helpviewer_keywords: 
  - "ReadMemory method [.NET Framework debugging]"
  - "ICorDebugProcess::ReadMemory method [.NET Framework debugging]"
ms.assetid: 28e4b2f6-9589-445c-be24-24a3306795e7
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess::ReadMemory Method
Reads a specified area of memory for this process.  
  
## Syntax  
  
```  
HRESULT ReadMemory(  
    [in]  CORDB_ADDRESS address,   
    [in]  DWORD size,  
    [out, size_is(size), length_is(size)] BYTE buffer[],  
    [out] SIZE_T *read);  
```  
  
#### Parameters  
 `address`  
 [in] A `CORDB_ADDRESS` value that specifies the base address of the memory to be read.  
  
 `size`  
 [in] The number of bytes to be read from memory.  
  
 `buffer`  
 [out] A buffer that receives the contents of the memory.  
  
 `read`  
 [out] A pointer to the number of bytes transferred into the specified buffer.  
  
## Remarks  
 The `ReadMemory` method is primarily intended to be used by interop debugging to inspect memory regions that are being used by the unmanaged portion of the debuggee. This method can also be used to read Microsoft intermediate language (MSIL) code and native JIT-compiled code.  
  
 Any managed breakpoints will be removed from the data that is returned in the `buffer` parameter. No adjustments will be made for native breakpoints set by [ICorDebugProcess2::SetUnmanagedBreakpoint](../../../../docs/framework/unmanaged-api/debugging/icordebugprocess2-setunmanagedbreakpoint-method.md).  
  
 No caching of process memory is performed.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
