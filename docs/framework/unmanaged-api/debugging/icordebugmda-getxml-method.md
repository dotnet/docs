---
title: "ICorDebugMDA::GetXML Method"
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
  - "ICorDebugMDA.GetXML"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugMDA::GetXML"
helpviewer_keywords: 
  - "ICorDebugMDA::GetXML method [.NET Framework debugging]"
  - "GetXML method [.NET Framework debugging]"
ms.assetid: 29746b24-3766-4255-8813-0426c45e73e5
topic_type: 
  - "apiref"
caps.latest.revision: 10
author: "rpetrusha"
ms.author: "ronpet"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ICorDebugMDA::GetXML Method
Gets the full XML stream associated with the managed debugging assistant (MDA) represented by [ICorDebugMDA](../../../../docs/framework/unmanaged-api/debugging/icordebugmda-interface.md).  
  
## Syntax  
  
```  
HRESULT GetXML (  
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
 [out] A pointer to the length of the XML stream.  
  
 `szName`  
 [out] An array in which to store the XML stream. The array may be empty.  
  
## Remarks  
 The `GetXML` method can potentially affect performance, depending on the size of the associated XML stream.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See Also  
 [ICorDebugMDA Interface](../../../../docs/framework/unmanaged-api/debugging/icordebugmda-interface.md)  
 [Diagnosing Errors with Managed Debugging Assistants](../../../../docs/framework/debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
