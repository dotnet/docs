---
title: "ICorDebugMDA::GetName Method"
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
  - "ICorDebugMDA.GetName"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugMDA::GetName"
helpviewer_keywords: 
  - "ICorDebugMDA::GetName method [.NET Framework debugging]"
  - "GetName method, ICorDebugMDA interface [.NET Framework debugging]"
ms.assetid: 885bf5e8-00b7-4cd7-9d8d-e720d47918c4
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugMDA::GetName Method
Gets a string containing the name of the managed debugging assistant (MDA) represented by [ICorDebugMDA](../../../../docs/framework/unmanaged-api/debugging/icordebugmda-interface.md).  
  
## Syntax  
  
```  
HRESULT GetName (  
    [in] ULONG32   cchName,  
    [out] ULONG32  *pcchName,  
    [out, size_is(cchName), length_is(*pcchName)]  
        WCHAR      szName[]  
);  
```  
  
#### Parameters  
 `cchName`  
 [in] The size of the `szName` array.  
  
 `pcchName`  
 [out] A pointer to the length of the name.  
  
 `szName`  
 [out] An array in which to store the name.  
  
## Remarks  
 MDA names are unique values. The `GetName` method is a convenient performance alternative to getting the XML stream and extracting the name from the stream based on the schema.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorDebugMDA Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmda-interface.md)  
 [Diagnosing Errors with Managed Debugging Assistants](../../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
