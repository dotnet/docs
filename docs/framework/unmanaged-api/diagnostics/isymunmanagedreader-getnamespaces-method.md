---
title: "ISymUnmanagedReader::GetNamespaces Method"
ms.date: "03/30/2017"
api_name: 
  - "ISymUnmanagedReader.GetNamespaces"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedReader::GetNamespaces"
helpviewer_keywords: 
  - "ISymUnmanagedReader::GetNamespaces method [.NET Framework debugging]"
  - "GetNamespaces method, ISymUnmanagedReader interface [.NET Framework debugging]"
ms.assetid: 3feb4796-2fab-45ce-beca-6f5bc530b971
topic_type: 
  - "apiref"
author: "mairaw"
ms.author: "mairaw"
---
# ISymUnmanagedReader::GetNamespaces Method
Gets the namespaces defined at global scope within this symbol store.  
  
## Syntax  
  
```  
HRESULT GetNamespaces (  
    [in]  ULONG32  cNameSpaces,  
    [out] ULONG32  *pcNameSpaces,  
    [out, size_is (cNameSpaces),  
        length_is (*pcNameSpaces)]  
        ISymUnmanagedNamespace*  namespaces[]);  
```  
  
#### Parameters  
 `cNameSpaces`  
 [in] The size of the namespaces array.  
  
 `pcNameSpaces`  
 [out] A pointer to a variable that receives the length of the namespace list.  
  
 `namespaces`  
 [out] A pointer to a variable that receives the namespace list.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See also
 [ISymUnmanagedReader Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedreader-interface.md)
