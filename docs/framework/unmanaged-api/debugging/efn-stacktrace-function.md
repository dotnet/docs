---
title: "_EFN_StackTrace Function"
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
  - "_EFN_StackTrace"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "_EFN_StackTrace"
helpviewer_keywords: 
  - "_EFN_StackTrace function [.NET Framework debugging]"
ms.assetid: caea7754-867c-4360-a65c-5ced4408fd9d
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# _EFN_StackTrace Function
Provides a text representation of a managed stack trace and an array of `CONTEXT` records, one for each transition between unmanaged and managed code.  
  
## Syntax  
  
```  
HRESULT CALLBACK _EFN_StackTrace(  
    [in]  PDEBUG_CLIENT  Client,  
    [out] WCHAR          wszTextOut[],  
    [out] size_t         *puiTextLength,  
    [out] LPVOID         pTransitionContexts,  
    [out] size_t         *puiTransitionContextCount,  
    [in]  size_t         uiSizeOfContext,  
    [in]  DWORD          Flags  
);  
```  
  
#### Parameters  
 `Client`  
 [in] The client being debugged.  
  
 `wszTextOut`  
 [out] The text representation of the stack trace.  
  
 `puiTextLength`  
 [out] A pointer to the number of characters in `wszTextOut`.  
  
 `pTransitionContexts`  
 [out] The array of transition contexts.  
  
 `puiTransitionContextCount`  
 [out] A pointer to the number of transition contexts in the array.  
  
 `uiSizeOfContext`  
 [in] The size of the context structure.  
  
 `Flags`  
 [in] Set to either 0 or SOS_STACKTRACE_SHOWADDRESSES (0x01) to show the EBP register and the enter stack pointer (ESP) in front of each `module!functionname` line.  
  
## Remarks  
 The `_EFN_StackTrace` structure can be called from a WinDbg programmatic interface. Parameters are used as follows:  
  
-   If `wszTextOut` is null and `puiTextLength` is not null, the function returns the string length in `puiTextLength`.  
  
-   If `wszTextOut` is not null, the function stores text in `wszTextOut` up to the location indicated by `puiTextLength`. It returns successfully if there was enough room in the buffer, or returns E_OUTOFMEMORY if the buffer was not long enough.  
  
-   The transition portion of the function is ignored if `pTransitionContexts` and `puiTransitionContextCount` are both null. In this case, the function provides callers with text output of only the function names.  
  
-   If `pTransitionContexts` is null and `puiTransitionContextCount` is not null, the function returns the necessary number of context entries in `puiTransitionContextCount`.  
  
-   If `pTransitionContexts` is not null, the function treats it as an array of structures of length `puiTransitionContextCount`. The structure size is given by `uiSizeOfContext`, and must be the size of [SimpleContext](../../../../docs/framework/unmanaged-api/debugging/stacktrace-simplecontext-structure.md) or `CONTEXT` for the architecture.  
  
-   `wszTextOut` is written in the following format:  
  
    ```  
    "<ModuleName>!<Function Name>[+<offset in hex>]  
    ...  
    (TRANSITION)  
    ..."  
    ```  
  
-   If the offset in hex is 0x0, no offset is written.  
  
-   If there is no managed code on the thread currently in context, the function returns SOS_E_NOMANAGEDCODE.  
  
-   The `Flags` parameter is either 0 or SOS_STACKTRACE_SHOWADDRESSES to see EBP and ESP in front of each `module!functionname` line. By default, it is 0.  
  
    ```  
    #define SOS_STACKTRACE_SHOWADDRESSES   0x00000001  
    ```  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** SOS_Stacktrace.h  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [Debugging Global Static Functions](../../../../docs/framework/unmanaged-api/debugging/debugging-global-static-functions.md)
