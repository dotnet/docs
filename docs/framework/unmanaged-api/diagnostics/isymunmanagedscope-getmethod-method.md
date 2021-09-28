---
description: "Learn more about: ISymUnmanagedScope::GetMethod Method"
title: "ISymUnmanagedScope::GetMethod Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedScope.GetMethod"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedScope::GetMethod"
helpviewer_keywords: 
  - "GetMethod method, ISymUnmanagedScope interface [.NET Framework debugging]"
  - "ISymUnmanagedScope::GetMethod method [.NET Framework debugging]"
ms.assetid: a61866ee-221a-45b9-a1b7-395825b77872
topic_type: 
  - "apiref"
---
# ISymUnmanagedScope::GetMethod Method

Gets the method that contains this scope.  
  
## Syntax  
  
```cpp  
HRESULT GetMethod(  
    [out, retval] ISymUnmanagedMethod** pRetVal);  
```  
  
## Parameters  

 `pRetVal`  
 [out] A pointer to the returned [ISymUnmanagedMethod](isymunmanagedmethod-interface.md) interface.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedScope Interface](isymunmanagedscope-interface.md)
