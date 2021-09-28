---
description: "Learn more about: ICorDebugMDA::GetXML Method"
title: "ICorDebugMDA::GetXML Method"
ms.date: "03/30/2017"
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
---
# ICorDebugMDA::GetXML Method

Gets the full XML stream associated with the managed debugging assistant (MDA) represented by [ICorDebugMDA](icordebugmda-interface.md).  
  
## Syntax  
  
```cpp  
HRESULT GetXML (  
    [in] ULONG32   cchName,  
    [out] ULONG32  *pcchName,  
    [out, size_is(cchName), length_is(*pcchName)]  
        WCHAR      szName[]  
);  
```  
  
## Parameters  

 `cchName`  
 [in] The size of the `szName` array.  
  
 `pcchName`  
 [out] A pointer to the length of the XML stream.  
  
 `szName`  
 [out] An array in which to store the XML stream. The array may be empty.  
  
## Remarks  

 The `GetXML` method can potentially affect performance, depending on the size of the associated XML stream.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v20plus](../../../../includes/net-current-v20plus-md.md)]  
  
## See also

- [ICorDebugMDA Interface](icordebugmda-interface.md)
- [Diagnosing Errors with Managed Debugging Assistants](../../debug-trace-profile/diagnosing-errors-with-managed-debugging-assistants.md)
