---
title: "ICorDebugAppDomain::GetName Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAppDomain.GetName"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomain::GetName"
helpviewer_keywords: 
  - "ICorDebugAppDomain::GetName method [.NET Framework debugging]"
  - "GetName method, ICorDebugAppDomain interface [.NET Framework debugging]"
ms.assetid: 02c596d7-00b0-4e2c-856b-5425158fcefd
topic_type: 
  - "apiref"
---
# ICorDebugAppDomain::GetName Method
Gets the name of the application domain.  
  
## Syntax  
  
```cpp  
HRESULT GetName (  
    [in]  ULONG32           cchName,  
    [out] ULONG32           *pcchName,  
    [out, size_is(cchName), length_is(*pcchName)]   
         WCHAR              szName[]  
);  
```  
  
## Parameters  
 `cchName`  
 [in] The size of the `szName` array. Set this value to zero to put this method in query mode.  
  
 `pcchName`  
 [out] A pointer to the size of the name or the number of characters actually returned in `szName`. In query mode, this value lets the caller know how large a buffer to allocate for the name.  
  
 `szName`  
 [out] An array that stores the name of the application domain.  
  
## Remarks  
 A debugger calls the `GetName` method once to get the size of a buffer needed for the name. The debugger allocates the buffer, and then calls the method a second time to fill the buffer. The first call, to get the size of the name, is referred to as *query mode*.  
  
## Requirements  
 **Platforms:** See [System Requirements](../../../../docs/framework/get-started/system-requirements.md).  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]
