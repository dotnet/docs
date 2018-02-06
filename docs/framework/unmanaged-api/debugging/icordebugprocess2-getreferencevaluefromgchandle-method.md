---
title: "ICorDebugProcess2::GetReferenceValueFromGCHandle Method"
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
  - "ICorDebugProcess2.GetReferenceValueFromGCHandle"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugProcess2::GetReferenceValueFromGCHandle"
helpviewer_keywords: 
  - "GetReferenceValueFromGCHandle method [.NET Framework debugging]"
  - "ICorDebugProcess2::GetReferenceValueFromGCHandle method [.NET Framework debugging]"
ms.assetid: 8bdd7f4c-19f2-4ede-875e-603773e8c128
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugProcess2::GetReferenceValueFromGCHandle Method
Gets a reference pointer to the specified managed object that has a garbage collection handle.  
  
## Syntax  
  
```  
HRESULT GetReferenceValueFromGCHandle (  
    [in]  UINT_PTR                 handle,  
    [out] ICorDebugReferenceValue  **pOutValue  
);  
```  
  
#### Parameters  
 `handle`  
 [in] A pointer to a managed object that has a garbage collection handle. This value is a <xref:System.IntPtr> object and can be retrieved from the <xref:System.Runtime.InteropServices.GCHandle> for the managed object.  
  
 `pOutValue`  
 [out] A pointer to the address of an ICorDebugReferenceValue object that represents a reference to the specified managed object.  
  
## Remarks  
 Do not confuse the returned reference value with a garbage collection reference value.  
  
 The returned reference behaves like a normal reference. It is disabled when code execution continues after a breakpoint. The lifetime of the target object is not affected by the lifetime of the reference value.  
  
> [!NOTE]
>  The `GetReferenceValueFromGCHandle` method does not validate the handle. Therefore, the `GetReferenceValueFromGCHandle` method can potentially corrupt both the debugger and the code being debugged if an invalid handle is passed.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]
