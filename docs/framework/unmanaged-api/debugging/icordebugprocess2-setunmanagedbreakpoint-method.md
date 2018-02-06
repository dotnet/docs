---
title: "ICorDebugProcess2::SetUnmanagedBreakpoint Method"
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
  - "ICorDebugProcess2.SetUnmanagedBreakpoint"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess2::SetUnmanagedBreakpoint"
helpviewer_keywords: 
  - "ICorDebugProcess2::SetUnmanagedBreakpoint method [.NET Framework debugging]"
  - "SetUnmanagedBreakpoint method [.NET Framework debugging]"
ms.assetid: 93829d15-d942-4e2d-b7a4-dfc9d7fb96be
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess2::SetUnmanagedBreakpoint Method
Sets an unmanaged breakpoint at the specified native image offset.  
  
## Syntax  
  
```  
HRESULT SetUnmanagedBreakpoint (  
    [in]  CORDB_ADDRESS    address,  
    [in]  ULONG32          bufsize,  
    [out, size_is(bufsize), length_is(*bufLen)]   
        BYTE               buffer[],  
    [out] ULONG32          *bufLen  
);  
```  
  
#### Parameters  
 `address`  
 [in] A `CORDB_ADDRESS` object that specifies the native image offset.  
  
 `bufsize`  
 [in] The size, in bytes, of the `buffer` array.  
  
 `buffer`  
 [out] An array that contains the opcode that is replaced by the breakpoint.  
  
 `bufLen`  
 [out] A pointer to the number of bytes returned in the `buffer` array.  
  
## Remarks  
 If the native image offset is within the common language runtime (CLR), the breakpoint will be ignored. This allows the CLR to avoid dispatching an out-of-band breakpoint, when the breakpoint is set by the debugger.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
