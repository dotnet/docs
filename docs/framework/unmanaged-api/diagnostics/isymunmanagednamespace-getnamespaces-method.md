---
description: "Learn more about: ISymUnmanagedNamespace::GetNamespaces Method"
title: "ISymUnmanagedNamespace::GetNamespaces Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedNamespace.GetNamespaces"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedNamespace::GetNamespaces"
helpviewer_keywords: 
  - "ISymUnmanagedNamespace::GetNamespaces method [.NET Framework debugging]"
  - "GetNamespaces method, ISymUnmanagedNamespace interface [.NET Framework debugging]"
ms.assetid: 0ea9d9af-8709-4a46-872b-f54d9e840088
topic_type: 
  - "apiref"
---
# ISymUnmanagedNamespace::GetNamespaces Method

Gets the children of this namespace.  
  
## Syntax  
  
```cpp  
HRESULT GetNamespaces(  
    [in]  ULONG32  cNameSpaces,  
    [out] ULONG32  *pcNameSpaces,  
    [out, size_is(cNameSpaces), length_is(*pcNameSpaces)]  
        ISymUnmanagedNamespace* namespaces[]);  
```  
  
## Parameters  

 `cNameSpaces`  
 [in] A `ULONG32` that indicates the size of the `namespaces` array.  
  
 `pcNameSpaces`  
 [out] A pointer to a `ULONG32` that receives the size, in characters, of the buffer required to contain the namespaces.  
  
 `namespaces`  
 [out] A pointer to the buffer that contains the namespaces.  
  
## Return Value  

 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  

 **Header:** CorSym.idl, CorSym.h  
  
## See also

- [ISymUnmanagedNamespace Interface](isymunmanagednamespace-interface.md)
