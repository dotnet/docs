---
description: "Learn more about: ISymUnmanagedScope::GetParent Method"
title: "ISymUnmanagedScope::GetParent Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedScope.GetParent"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedScope::GetParent"
helpviewer_keywords: 
  - "GetParent method [.NET Framework debugging]"
  - "ISymUnmanagedScope::GetParent method [.NET Framework debugging]"
ms.assetid: c7963c87-6ec5-49b3-a5cd-e0fe0c43f9b4
topic_type: 
  - "apiref"
---
# ISymUnmanagedScope::GetParent Method

Gets the parent scope of this scope.  
  
## Syntax  
  
```cpp  
HRESULT GetParent(  
    [out, retval] ISymUnmanagedScope** pRetVal);  
```  
  
## Parameters  

 `pRetVal`  
 [out] A pointer to the returned [ISymUnmanagedScope](isymunmanagedscope-interface.md) interface.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedScope Interface](isymunmanagedscope-interface.md)
- [GetChildren Method](isymunmanagedscope-getchildren-method.md)
