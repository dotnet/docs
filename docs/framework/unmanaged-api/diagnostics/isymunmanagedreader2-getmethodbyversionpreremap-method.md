---
description: "Learn more about: ISymUnmanagedReader2::GetMethodByVersionPreRemap Method"
title: "ISymUnmanagedReader2::GetMethodByVersionPreRemap Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReader2.GetMethodByVersionPreRemap"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader2::GetMethodByVersionPreRemap"
helpviewer_keywords: 
  - "GetMethodByVersionPreRemap method [.NET Framework debugging]"
  - "ISymUnmanagedReader2::GetMethodByVersionPreRemap method [.NET Framework debugging]"
ms.assetid: 0d144ed4-bdb0-4cac-960c-cb90f4dca173
topic_type: 
  - "apiref"
---
# ISymUnmanagedReader2::GetMethodByVersionPreRemap Method

Gets a symbol reader method, given a method token and an edit-and-continue version number. Version numbers start at 1 and are incremented each time the method is changed as a result of an edit-and-continue operation.  
  
## Syntax  
  
```cpp  
HRESULT GetMethodByVersionPreRemap(  
    [in]  mdMethodDef token,  
    [in]  int version,  
    [out, retval] ISymUnmanagedMethod** pRetVal);  
```  
  
## Parameters  

 `token`  
 [in] The method metadata token.  
  
 `version`  
 [in] The method version.  
  
 `pRetVal`  
 [out] A pointer to the returned [ISymUnmanagedMethod](isymunmanagedmethod-interface.md) interface.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl. CorSym.h  
  
## See also

- [ISymUnmanagedReader2 Interface](isymunmanagedreader2-interface.md)
