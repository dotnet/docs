---
description: "Learn more about: ICorDebugAppDomain3::GetCachedWinRTTypesForIIDs Method"
title: "ICorDebugAppDomain3::GetCachedWinRTTypesForIIDs Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorDebugAppDomain3.GetCachedWinRTTypesForIIDs"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorDebugAppDomain3::GetCachedWinRTTypesForIIDs"
helpviewer_keywords: 
  - "ICorDebugAppDomain3::GetCachedWinRTTypesForIIDs method, [.NET Framework debugging]"
  - "GetCachedWinRTTypesForIIDs method, ICorDebugAppDomain3 interface [.NET Framework debugging]"
ms.assetid: 23682ca0-1bcf-48e6-996e-69f7ba337682
topic_type: 
  - "apiref"
---
# ICorDebugAppDomain3::GetCachedWinRTTypesForIIDs Method

Gets an enumerator for cached Windows Runtime types in an application domain based on their interface identifiers.  
  
## Syntax  
  
```cpp  
HRESULT GetCachedWinRTTypesForIIDs (
    [in]  ULONG32            cReqTypes,  
    [in]  GUID                *iidsToResolve,  
    [out] ICorDebugTypeEnum   **ppTypesEnum  
);  
```  
  
## Parameters  

 `cReqTypes`  
 [in] The number of required types.  
  
 `iidsToResolve`  
 [in] A pointer to an array that contains the interface identifiers corresponding to the managed representations of the Windows Runtime types to be retrieved.  
  
 `ppTypesEnum`  
 [out] A pointer to the address of an "ICorDebugTypeEnum" interface object that allows enumeration of the cached managed representations of the Windows Runtime types retrieved, based on the interface identifiers in `iidsToResolve`.  
  
## Remarks  

 If the method fails to retrieve information for a specific interface identifier, the corresponding entry in the "ICorDebugTypeEnum" collection will have a type of `ELEMENT_TYPE_END` for errors due to data retrieval issues, or `ELEMENT_TYPE_VOID` for unknown interface identifiers.  
  
## Requirements  

 **Platforms:** Windows Runtime  
  
 **Header:** CorDebug.idl, CorDebug.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v45plus](../../../../includes/net-current-v45plus-md.md)]  
  
## See also

- [ICorDebugAppDomain3 Interface](icordebugappdomain3-interface.md)
