---
description: "Learn more about: ISymUnmanagedMethod::GetNamespace Method"
title: "ISymUnmanagedMethod::GetNamespace Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedMethod.GetNamespace"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedMethod::GetNamespace"
helpviewer_keywords: 
  - "ISymUnmanagedMethod::GetNamespace method [.NET Framework debugging]"
  - "GetNamespace method [.NET Framework debugging]"
ms.assetid: 7fbbac42-b966-406d-9ae9-67bf3aea74ce
topic_type: 
  - "apiref"
---
# ISymUnmanagedMethod::GetNamespace Method

Gets the namespace within which this method is defined.  
  
## Syntax  
  
```cpp  
HRESULT GetNamespace(  
   [out] ISymUnmanagedNamespace  **pRetVal);  
```  
  
## Parameters  

 `pRetVal`  
 [out] A pointer that is set to the returned [ISymUnmanagedNamespace](isymunmanagednamespace-interface.md) interface.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedMethod Interface](isymunmanagedmethod-interface.md)
