---
title: "ICorDebugFunction::GetCurrentVersionNumber Method"
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
  - "ICorDebugFunction.GetCurrentVersionNumber"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugFunction::GetCurrentVersionNumber"
helpviewer_keywords: 
  - "GetCurrentVersionNumber method [.NET Framework debugging]"
  - "ICorDebugFunction::GetCurrentVersionNumber method [.NET Framework debugging]"
ms.assetid: c3af1575-cbe6-457a-bc08-c53460edcbc8
topic_type: 
  - "apiref"
caps.latest.revision: 11
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugFunction::GetCurrentVersionNumber Method
Gets the version number of the latest edit made to the function represented by this ICorDebugFunction object.  
  
## Syntax  
  
```  
HRESULT GetCurrentVersionNumber (  
    [out] ULONG32 *pnCurrentVersion  
);  
```  
  
#### Parameters  
 `pnCurrentVersion`  
 [out] A pointer to an integer value that is the version number of the latest edit made to this function.  
  
## Remarks  
 The version number of the latest edit made to this function may be greater than the version number of the function itself. Use either the [ICorDebugFunction2::GetVersionNumber](../../../../docs/framework/unmanaged-api/debugging/icordebugfunction2-getversionnumber-method.md) method or the [ICorDebugCode::GetVersionNumber](../../../../docs/framework/unmanaged-api/debugging/icordebugcode-getversionnumber-method.md) method to retrieve the version number of the function.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
