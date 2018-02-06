---
title: "ICorDebugILFrame::CanSetIP Method"
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
  - "ICorDebugILFrame.CanSetIP"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugILFrame::CanSetIP"
helpviewer_keywords: 
  - "CanSetIP method, ICorDebugILFrame interface [.NET Framework debugging]"
  - "ICorDebugILFrame::CanSetIP method [.NET Framework debugging]"
ms.assetid: 16caf02f-c71e-486c-90b0-f0e54357d8f0
topic_type: 
  - "apiref"
caps.latest.revision: 13
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugILFrame::CanSetIP Method
Gets an HRESULT that indicates whether it is safe to set the instruction pointer to the specified offset location in Microsoft Intermediate Language (MSIL) code.  
  
## Syntax  
  
```  
HRESULT CanSetIP (  
    [in] ULONG32   nOffset  
);  
```  
  
#### Parameters  
 `nOffset`  
 [in] The desired setting for the instruction pointer.  
  
## Remarks  
 Use the `CanSetIP` method before calling the [ICorDebugILFrame::SetIP](../../../../docs/framework/unmanaged-api/debugging/icordebugilframe-setip-method.md) method. If `CanSetIP` returns any HRESULT other than S_OK, you can still invoke `ICorDebugILFrame::SetIP`, but there is no guarantee that the debugger will continue the safe and correct execution of the code being debugged.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug,h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
