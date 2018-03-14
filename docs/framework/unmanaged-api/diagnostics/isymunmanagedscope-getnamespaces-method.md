---
title: "ISymUnmanagedScope::GetNamespaces Method"
ms.custom: ""
ms.date: "03/30/2017"
ms.prod: ".net-framework"
ms.reviewer: ""
ms.suite: ""
ms.technology: 
  - "dotnet-clr"
ms.tgt_pltfrm: ""
ms.topic: "reference"
api_name: 
  - "ISymUnmanagedScope.GetNamespaces"
api_location: 
  - "diasymreader.dll"
api_type: 
  - "COM"
f1_keywords: 
  - "ISymUnmanagedScope::GetNamespaces"
helpviewer_keywords: 
  - "GetNamespaces method, ISymUnmanagedScope interface [.NET Framework debugging]"
  - "ISymUnmanagedScope::GetNamespaces method [.NET Framework debugging]"
ms.assetid: c44b0440-04bd-460a-84fb-41afecf44503
topic_type: 
  - "apiref"
caps.latest.revision: 9
author: "mairaw"
ms.author: "mairaw"
manager: "wpickett"
ms.workload: 
  - "dotnet"
---
# ISymUnmanagedScope::GetNamespaces Method
Gets the namespaces that are being used within this scope.  
  
## Syntax  
  
```  
HRESULT GetNamespaces(  
    [in]  ULONG32  cNameSpaces,  
    [out] ULONG32  *pcNameSpaces,  
    [out, size_is(cNameSpaces),  
        length_is(*pcNameSpaces)]  
        ISymUnmanagedNamespace* namespaces[]);  
```  
  
#### Parameters  
 `cNameSpaces`  
 [in] The size of the `namespaces` array.  
  
 `pcNameSpaces`  
 [out] A pointer to a `ULONG32` that receives the size of the buffer required to contain the namespaces.  
  
 `namespaces`  
 [out] The array that receives the namespaces.  
  
## Return Value  
 S_OK if the method succeeds; otherwise, E_FAIL or some other error code.  
  
## Requirements  
 **Header:** CorSym.idl, CorSym.h  
  
## See Also  
 [ISymUnmanagedScope Interface](../../../../docs/framework/unmanaged-api/diagnostics/isymunmanagedscope-interface.md)
