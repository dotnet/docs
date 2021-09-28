---
description: "Learn more about: ICorPublishAppDomain::GetName Method"
title: "ICorPublishAppDomain::GetName Method"
ms.date: "03/30/2017"
api_name: 
  - "ICorPublishAppDomain.GetName"
api_location: 
  - "mscordbi.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ICorPublishAppDomain::GetName"
helpviewer_keywords: 
  - "GetName method, ICorPublishAppDomain interface [.NET Framework debugging]"
  - "ICorPublishAppDomain::GetName method [.NET Framework debugging]"
ms.assetid: 6ef8ac9b-9803-4b65-8b13-25f3e0b1bc6b
topic_type: 
  - "apiref"
---
# ICorPublishAppDomain::GetName Method

Gets the name of the application domain that is represented by this [ICorPublishAppDomain](icorpublishappdomain-interface.md).  
  
## Syntax  
  
```cpp  
HRESULT GetName (  
    [in]  ULONG32   cchName,
    [out] ULONG32   *pcchName,  
    [out, size_is(cchName), length_is(*pcchName)]
        WCHAR       *szName  
);  
```  
  
## Parameters  

 `cchName`  
 [in] The size of the `szName` array.  
  
 `pcchName`  
 [out] A pointer to the number of wide characters, including the null character, returned in the `szName` array.  
  
 `szName`  
 [out] An array in which to store the name.  
  
## Remarks  

 If `szName` is non-null, the `GetName` method copies up to `cchName` characters (including the null terminator) into `szName`. If a non-null is returned in `pcchName`, the actual number of characters in the name (including the null terminator) is stored in the `szName` array.  
  
 The `GetName` method returns an S_OK HRESULT regardless of how many characters were copied.  
  
## Requirements  

 **Platforms:** See [System Requirements](../../get-started/system-requirements.md).  
  
 **Header:** CorPub.idl, CorPub.h  
  
 **Library:** CorGuids.lib  
  
 **.NET Framework Versions:** [!INCLUDE[net_current_v10plus](../../../../includes/net-current-v10plus-md.md)]  
  
## See also

- [ICorPublishAppDomain Interface](icorpublishappdomain-interface.md)
